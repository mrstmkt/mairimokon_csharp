//#define DEBUGCOMM
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace MaiRimokon
{
    public abstract class Comm
    {
        public delegate void FinishedCallback();
        public const string STARTCOMMAND = "s";
        public const string ENDCOMMAND = "e";
        public const char OKMESSAGE = 'o';
        public const char QUITMESSAGE = 'q';
        public const string FINISHEDSTR = "e";
        private FinishedCallback callback;


        public List<PulseData> DataList
        {
            get;
            internal set;
        }

        public String RecvData
        {
            get;
            internal set;
        }
        public Comm()
        {
            this.DataList = new List<PulseData>();
        }
        public abstract bool Connect();
        public abstract bool SendStartCommand();
        public abstract bool SendEndCommand();
        public abstract int Recv();
        public abstract int RecvAsync();
        public abstract void StopRecvAsync();
        public abstract bool Close();
        public void setFinishedCallback(FinishedCallback callback)
        {
            this.callback = callback;
        }
        public void CallFinishedCallback()
        {
            if (this.callback != null)
            {
                this.callback();
            }
        }
        public bool CheckRecvData()
        {
            bool ret = false;
            this.DataList.Clear();
            int baudrateHose = 0;
            if (this.RecvData == null || this.RecvData.Length == 0)
            {
                ret = false;
            }
            else
            {
                string[] sepalator1 = new string[1] { " " };
                string[] dataArr1 = this.RecvData.Split(sepalator1, StringSplitOptions.RemoveEmptyEntries);
                if (dataArr1 == null || dataArr1.Length == 0)
                {
                    return false;
                }
                int i = 0;
                foreach (string command in dataArr1)
                {
                    string[] sepalator2 = new string[1] { "-" };
                    string[] dataArr2 = command.Split(sepalator2, StringSplitOptions.RemoveEmptyEntries);
                    if (dataArr2 == null || dataArr2.Length < 2)
                    {
                        return false;
                    }
                    int value = 0;
                    int microsecond = 0;
                    if (Int32.TryParse(dataArr2[0], out value) == false)
                    {
                        return false;
                    }
                    if (Int32.TryParse(dataArr2[1], out microsecond) == false)
                    {
                        return false;
                    }
                    if (i == 0 && value == 0)
                    {
                        microsecond = 100;
                    }
                    else
                    {
                        microsecond = microsecond - baudrateHose;
                    }
                    this.DataList.Add(new PulseData(value, microsecond));
                    i++;
#if DEBUGCOM
                    baudrateHose = command.Length * 1000000 / SerialComm.BAUDRATE;
#endif
                }
                ret = true;
            }

            return ret;
        }
    }

    public class PulseData
    {
        public int Value
        {
            get;
            set;
        }
        public int MicroSecond
        {
            get;
            set;
        }
        public PulseData(int value, int microsec)
        {
            this.Value = value;
            this.MicroSecond = microsec;
        }
    }
}
