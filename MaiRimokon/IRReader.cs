using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaiRimokon
{
    public class IRReader
    {
        public const int TYPE_DEBUG = 0;
        public const int TYPE_SERIAL = 1;
        private Comm conn;

        public IRReader(int type, string comPort)
        {
            this.conn = null;
            switch (type)
            {
                case TYPE_SERIAL:
                    conn = new SerialComm(comPort);
                    break;
            }
        }
        public IRReader(int type)
        {
            this.conn = null;
            switch (type)
            {
                case TYPE_DEBUG:
                    conn = new DebugComm();
                    break;
            }
        }

        public bool Connect()
        {
            bool ret = false;
            if (this.conn != null)
            {
                ret = this.conn.Connect();
            }
            else
            {
                ret = false;
            }

            return ret;
        }
        public bool Start()
        {
            bool ret = false;
            if (this.conn != null)
            {
                ret = this.conn.SendStartCommand();
            }
            else
            {
                ret = false;
            }

            return ret;
        }
        public int Recv()
        {
            int ret;
            if (this.conn != null)
            {
                ret = this.conn.Recv();
            }
            else
            {
                ret = -1;
            }
            return ret;
        }

        public int RecvAsync()
        {
            int ret;
            if (this.conn != null)
            {
                ret = this.conn.RecvAsync();
            }
            else
            {
                ret = -1;
            }
            return ret;
        }

        public void StopRecvAsync()
        {
            if (this.conn != null)
            {
                this.conn.StopRecvAsync();
            }
        }

        public bool Stop()
        {
            bool ret = false;
            if (this.conn != null)
            {
                ret = this.conn.SendEndCommand();
            }
            else
            {
                ret = false;
            }

            return ret;
        }
        public bool Close()
        {
            bool ret = false;
            if (this.conn != null)
            {
                ret = this.conn.Close();
            }
            else
            {
                ret = false;
            }

            return ret;
        }

        public void setFinishedCallback(Comm.FinishedCallback callback)
        {
            if (this.conn != null)
            {
                this.conn.setFinishedCallback(callback);
            }
        }
        public bool CheckRecvData()
        {
            if (this.conn != null)
            {
                return this.conn.CheckRecvData();
            }
            else
            {
                return false;
            }
        }
        public String RecvData
        {
            get
            {
                if (this.conn != null)
                {
                    return this.conn.RecvData;
                }
                else
                {
                    return "";
                }
            }
        }
        public List<PulseData> DataList
        {
            get
            {
                if (this.conn != null)
                {
                    return this.conn.DataList;
                }
                else
                {
                    return null;
                }
            }
        }
        public List<IRFrame> GetFrames(int format, IRFrameParam param)
        {
            List<IRFrame> frameList = new List<IRFrame>();

            if (this.DataList != null && this.DataList.Count > 0)
            {
                List<int> startIndexes = GetFrameStartIndexes(format, param, this.DataList);
                for (int i = 0; i < startIndexes.Count; i++)
                {
                    IRFrame frame;
                    List<PulseData> datalist = new List<PulseData>();
                    if (i == startIndexes.Count - 1)
                    {
                        for (int j = startIndexes[i]; j < this.DataList.Count; j++)
                        {
                            datalist.Add(this.DataList[j]);
                        }
                    }
                    else
                    {
                        for (int j = startIndexes[i]; j < startIndexes[i + 1]; j++)
                        {
                            datalist.Add(this.DataList[j]);
                        }
                    }
                    frame = new IRFrame(format, param, datalist);
                    if (frame.ValueValid == false)
                    {
                        frameList.Clear();
                        break;
                    }
                    else
                    {
                        frameList.Add(frame);
                    }
                }
            }

            return frameList;
        }
        private List<int> GetFrameStartIndexes(int format, IRFrameParam param,  List<PulseData> dataList)
        {
            List<int> ret = new List<int>();
            bool firstFrame = true;
            bool high = false;
            bool stop = false;
            int i = 0;
            int time = 0;
            while (i < dataList.Count)
            {
                PulseData data = dataList[i];
                if (firstFrame == true)
                {
                    if (data.Value == 1)
                    {
                        ret.Add(i);
                        time = time + data.MicroSecond;
                        firstFrame = false;
                        i++;
                        if (i < dataList.Count)
                        {
                            if (dataList[i].Value == 0)
                            {
                                time = time + dataList[i].MicroSecond;
                                high = false;
                                i++;
                            }
                            else
                            {
                                ret.Clear();
                                break;
                            }
                        }
                        else
                        {
                            ret.Clear();
                            break;
                        }
                    }
                    else
                    {
                        i++;
                    }
                }
                else
                {
                    if (data.Value == 1 && high == true)
                    {
                        ret.Clear();
                        break;
                    }
                    if (data.Value == 0 && high == false)
                    {
                        ret.Clear();
                        break;
                    }
                    if (data.Value == 1)
                    {
                        if (stop == false)
                        {
                            time = time + data.MicroSecond;
                        }
                        else
                        {
                            ret.Add(i);
                            stop = false;
                            time = data.MicroSecond;
                        }
                        high = true;
                        i++;
                    }
                    else
                    {
                        time = time + data.MicroSecond;
                        high = false;
                        if (param.FrameInterval > 0)
                        {
                            if (time > param.FrameInterval - (int)((float)param.FrameInterval * 0.2F))
                            {
                                stop = true;
                            }
                            if (format != IRFrame.FORMAT_NEC)
                            {
                                i++;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else if (param.StopLow > 0)
                        {
                            if (data.MicroSecond > param.StopLow - (int)((float)param.StopLow * 0.2F) &&
                                data.MicroSecond < param.StopLow + (int)((float)param.StopLow * 0.2F))
                            {
                                stop = true;
                            }
                            i++;
                        }
                        else
                        {
                            ret.Clear();
                            break;
                        }
                    }
                }
            }

            return ret;
        }
    }
}
