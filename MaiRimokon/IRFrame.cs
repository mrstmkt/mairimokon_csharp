using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaiRimokon
{
    public class IRFrame
    {
        public const int FORMAT_NEC = 0;
        public const int FORMAT_SONY = 1;
        public const int FORMAT_DENKYO = 2;
        public const int FORMAT_UNIDEN = 3;
        public const int FORMAT_OTHER = 4;
        public int Format
        {
            get;
            internal set;
        }
        public IRFrameParam FrameParam
        {
            get;
            internal set;
        }
        public List<PulseData> DataList
        {
            get;
            internal set;
        }
        public bool ValueValid
        {
            get;
            internal set;
        }
        public IRFrameValue Value
        {
            get;
            internal set;
        }
        public int CarrierHigh
        {
            get
            {
                return this.FrameParam.CarrierHigh;
            }
        }//micro second
        public int CarrierLow
        {
            get
            {
                return this.FrameParam.CarrierLow;
            }
        }//micro second
        public int LeaderHigh
        {
            get
            {
                return this.FrameParam.LeaderHigh;
            }
        }//micro second
        public int LeaderLow
        {
            get
            {
                return this.FrameParam.LeaderLow;
            }
        }//micro second
        public int Pulse0Modulation
        {
            get
            {
                return this.FrameParam.Pulse0Modulation;
            }
        }//micro second
        public int Pulse0High
        {
            get
            {
                return this.FrameParam.Pulse0High;
            }
        }//micro second
        public int Pulse0Low
        {
            get
            {
                return this.FrameParam.Pulse0Low;
            }
        }//micro second
        public int Pulse1Modulation
        {
            get
            {
                return this.FrameParam.Pulse1Modulation;
            }
        }//micro second
        public int Pulse1High
        {
            get
            {
                return this.FrameParam.Pulse1High;
            }
        }//micro second
        public int Pulse1Low
        {
            get
            {
                return this.FrameParam.Pulse1Low;
            }
        }//micro second
        public int StopHigh
        {
            get
            {
                return this.FrameParam.StopHigh;
            }
        }//micro second
        public int StopLow
        {
            get
            {
                return this.FrameParam.StopLow;
            }
        }//micro second

        public int FrameInterval
        {
            get
            {
                return this.FrameParam.FrameInterval;
            }
        }//micro second

        public int RepeatHigh
        {
            get
            {
                return this.FrameParam.RepeatHigh;
            }
        }//micro second

        public int RepeatLow
        {
            get
            {
                return this.FrameParam.RepeatLow;
            }
        }//micro second

        private static Dictionary<Int32, IRFrameParam> defaultParamDic = new Dictionary<Int32, IRFrameParam>()
            {
                {FORMAT_NEC, new IRFrameParam(12,14, 9000, 4500,
                                            IRFrameParam.PPM_HIGH_LOW, 560, 560,
                                            IRFrameParam.PPM_HIGH_LOW, 560, 1690,
                                            560, 0,108000, 9000, 2250)},
                {FORMAT_SONY, new IRFrameParam(12,14, 2500, 550,
                                            IRFrameParam.PPM_HIGH_LOW, 550, 550,
                                            IRFrameParam.PPM_HIGH_LOW, 1250, 550,
                                            0, 0, 45000, 0, 0)},
                {FORMAT_DENKYO, new IRFrameParam(12,14, 3200, 1600,
                                            IRFrameParam.PPM_HIGH_LOW, 400, 400,
                                            IRFrameParam.PPM_HIGH_LOW, 400, 1200,
                                            400, 8000, 0, 0, 0)},
                {FORMAT_UNIDEN, new IRFrameParam(12,14, 2350, 1100,
                                            IRFrameParam.PPM_HIGH_LOW, 550, 550,
                                            IRFrameParam.PPM_HIGH_LOW, 550, 1550,
                                            550, 0, 50000, 0, 0)},
                {FORMAT_OTHER, new IRFrameParam(MaiRimokon.Properties.Settings.Default.OtherCarrierHigh,
                                                MaiRimokon.Properties.Settings.Default.OtherCarrierLow,
                                                MaiRimokon.Properties.Settings.Default.OtherLeaderHigh,
                                                MaiRimokon.Properties.Settings.Default.OtherLeaderLow,
                                                MaiRimokon.Properties.Settings.Default.OtherPulse0Modulation,
                                                MaiRimokon.Properties.Settings.Default.OtherPulse0High,
                                                MaiRimokon.Properties.Settings.Default.OtherPulse0Low,
                                                MaiRimokon.Properties.Settings.Default.OtherPulse1Modulation,
                                                MaiRimokon.Properties.Settings.Default.OtherPulse1High,
                                                MaiRimokon.Properties.Settings.Default.OtherPulse1Low,
                                                MaiRimokon.Properties.Settings.Default.OtherStopHigh,
                                                MaiRimokon.Properties.Settings.Default.OtherStopLow,
                                                MaiRimokon.Properties.Settings.Default.OtherFrameInterval,
                                                MaiRimokon.Properties.Settings.Default.OtherRepeatHigh, 
                                                MaiRimokon.Properties.Settings.Default.OtherRepeatLow)}
            };
        public static void UpdateDefaultParamDic()
        {
            if(defaultParamDic.ContainsKey(FORMAT_OTHER))
            {
                defaultParamDic.Remove(FORMAT_OTHER);
            }
            IRFrameParam param = new IRFrameParam(MaiRimokon.Properties.Settings.Default.OtherCarrierHigh,
                                                MaiRimokon.Properties.Settings.Default.OtherCarrierLow,
                                                MaiRimokon.Properties.Settings.Default.OtherLeaderHigh,
                                                MaiRimokon.Properties.Settings.Default.OtherLeaderLow,
                                                MaiRimokon.Properties.Settings.Default.OtherPulse0Modulation,
                                                MaiRimokon.Properties.Settings.Default.OtherPulse0High,
                                                MaiRimokon.Properties.Settings.Default.OtherPulse0Low,
                                                MaiRimokon.Properties.Settings.Default.OtherPulse1Modulation,
                                                MaiRimokon.Properties.Settings.Default.OtherPulse1High,
                                                MaiRimokon.Properties.Settings.Default.OtherPulse1Low,
                                                MaiRimokon.Properties.Settings.Default.OtherStopHigh,
                                                MaiRimokon.Properties.Settings.Default.OtherStopLow,
                                                MaiRimokon.Properties.Settings.Default.OtherFrameInterval,
                                                MaiRimokon.Properties.Settings.Default.OtherRepeatHigh,
                                                MaiRimokon.Properties.Settings.Default.OtherRepeatLow);
            defaultParamDic.Add(FORMAT_OTHER, param);
        }
        public static IRFrameParam GetDefaultParam(int format)
        {
            if (defaultParamDic.ContainsKey(format) == true)
            {
                return defaultParamDic[format];
            }
            else
            {
                return defaultParamDic[FORMAT_DENKYO];
            }
        }
        public IRFrame(int format)
            : this(format, null, (List<PulseData>)null)
        {
        }
        public IRFrame(int format, IRFrameParam param)
            : this(format, param, (List<PulseData>)null)
        {
        }
        public IRFrame(int format, IRFrameParam param, List<PulseData> dataList)
        {
            this.ValueValid = false;
            this.DataList = dataList;
            if (param == null)
            {
                this.Format = format;
                if (defaultParamDic.ContainsKey(format) == true)
                {
                    this.FrameParam = defaultParamDic[format];
                }
                else
                {
                    this.FrameParam = defaultParamDic[FORMAT_DENKYO];
                }
            }
            else
            {
                this.Format = format;
                this.FrameParam = param;
            }
            MakeValue();
        }
        public IRFrame(int format, IRFrameParam param, IRFrameValue value)
        {
            if (param == null)
            {
                this.Format = format;
                if (defaultParamDic.ContainsKey(format) == true)
                {
                    this.FrameParam = defaultParamDic[format];
                }
                else
                {
                    this.FrameParam = defaultParamDic[FORMAT_DENKYO];
                }
            }
            else
            {
                this.Format = format;
                this.FrameParam = param;
            }
            if (value != null)
            {
                if (value.ValueList != null && value.ValueList.Count > 0)
                {
                    this.Value = value;
                    this.ValueValid = true;
                }
                else
                {
                    this.ValueValid = false;
                }
            }
            else
            {
                this.ValueValid = false;
            }
        }

        private void MakeValue()
        {
            if (this.DataList == null || this.DataList.Count == 0)
            {
                this.ValueValid = false;
                return;
            }
            int leaderHigh = 0;
            int leaderLow = 0;
            int time = 0;
            int stopHigh = 0;
            int stopLow = 0;
            int mode = 0; // 0: Leader 1:Data 2:Stop
            int length = 0;
            this.Value = new IRFrameValue();
            bool error = false;
//            bool leaderStart = false;
            float rate = 0.3F; //
            byte temp = 0;
            bool high = false;
            int highMicros = 0;
            int lowMicros = 0;
            bool exit = false;
            int i = 0;
            int highRate = (int)Math.Round((float)this.Pulse1High / (float)this.Pulse0High, MidpointRounding.AwayFromZero);
            int lowRate = (int)Math.Round((float)this.Pulse1Low / (float)this.Pulse0Low, MidpointRounding.AwayFromZero);
            foreach (PulseData data in this.DataList)
            {

                switch (mode)
                {
                    case 0: //Leader
                        if (i == 0 && data.Value == 0)
                        {
                            error = true;
                            break;
                        }
                        if (data.Value == 1)
                        {
                            leaderHigh = data.MicroSecond;
                            time = time + data.MicroSecond;
                            high = true;
                        }
                        else
                        {
                            leaderLow = data.MicroSecond;
                            time = time + data.MicroSecond;
                            high = false;
                            mode = 1;
                            length = 0;
                        }
                        break;
                    case 1:
                        if (data.Value == 1 && high == true)
                        {
                            error = true;
                            break;
                        }
                        if (data.Value == 0 && high == false)
                        {
                            error = true;
                            break;
                        }
                        if (length % 8 == 0)
                        {
                            temp = 0;
                        }
                        if (data.Value == 1)
                        {
                            highMicros = data.MicroSecond;
                            lowMicros = 0;
                            high = true;
                            time = time + data.MicroSecond;
                            stopHigh = data.MicroSecond;
                            //if ((float)data.MicroSecond > (float)this.FrameParam.Pulse0High - (float)this.FrameParam.Pulse0High * rate &&
                            //    (float)data.MicroSecond < (float)this.FrameParam.Pulse0High + (float)this.FrameParam.Pulse0High * rate)
                            //{
                            //    highMicros = this.FrameParam.Pulse0High;
                            //    lowMicros = 0;
                            //    high = true;
                            //    time = time + data.MicroSecond;
                            //    stopHigh = data.MicroSecond;
                            //}
                            //else if ((float)data.MicroSecond > (float)this.FrameParam.Pulse1High - (float)this.FrameParam.Pulse1High * rate &&
                            //    (float)data.MicroSecond < (float)this.FrameParam.Pulse1High + (float)this.FrameParam.Pulse1High * rate)
                            //{
                            //    highMicros = this.FrameParam.Pulse1High;
                            //    lowMicros = 0;
                            //    high = true;
                            //    time = time + data.MicroSecond;
                            //    stopHigh = data.MicroSecond;
                            //}
                            //else
                            //{
                            //    error = true;
                            //    break;
                            //}
                        }
                        else
                        {
                            int val = -1;
                            lowMicros = data.MicroSecond;
                            high = false;
                            time = time + data.MicroSecond;
                            stopLow = data.MicroSecond;
                            if(this.FrameParam.FrameInterval > 0 &&
                                    (float)time > (float)this.FrameParam.FrameInterval - (float)this.FrameParam.FrameInterval * 0.2F)
                            {
                                lowMicros = 0;
                                high = false;
                                mode = 2;
                            }
                            else if (this.FrameParam.StopLow > 0 &&
                                (float)data.MicroSecond > (float)this.FrameParam.StopLow - (float)this.FrameParam.StopLow * rate)
                            {
                                lowMicros = 0;
                                high = false;
                                mode = 2;
                            }
                            else if (lowRate >= 2)
                            {
                                if ((int)Math.Round((float)lowMicros / (float)highMicros, MidpointRounding.AwayFromZero) >= lowRate)
                                {
                                    val = 1;
                                }
                                else if (this.Format == IRFrame.FORMAT_NEC &&
                                    (float)lowMicros / (float)highMicros > 2.0)
                                {
                                    val = 1;
                                }
                                else if (this.Format == IRFrame.FORMAT_UNIDEN &&
                                    (float)lowMicros / (float)highMicros > 2.0)
                                {
                                    val = 1;
                                }
                                else if (this.Format == IRFrame.FORMAT_UNIDEN &&
                                    (float)lowMicros > (float)this.FrameParam.Pulse1Low - (float)this.FrameParam.Pulse1Low * 0.3F)
                                {
                                    val = 1;
                                }
                                else if ((float)lowMicros > (float)this.FrameParam.Pulse1Low - (float)this.FrameParam.Pulse1Low * 0.2F)
                                {
                                    val = 1;
                                }
                                else
                                {
                                    val = 0;
                                }
                            }
                            else if (highRate >= 2)
                            {
                                if ((int)Math.Round((float)highMicros / (float)lowMicros, MidpointRounding.AwayFromZero) >= highRate)
                                {
                                    val = 1;
                                }
                                else if (this.Format != IRFrame.FORMAT_SONY &&
                                    (float)highMicros > (float)this.FrameParam.Pulse1High - (float)this.FrameParam.Pulse1High * 0.3F)
                                {
                                    val = 1;
                                }
                                else
                                {
                                    val = 0;
                                }
                            }
                            else
                            {
                                error = true;
                                break;
                            }
                            if (val == 0)
                            {
                                if (length % 8 == 7)
                                {
                                    this.Value.ValueList.Add(temp);
                                }
                                length++;
                                this.Value.ValueLength = length;
                            }
                            else if (val == 1)
                            {
                                byte flag = 0x80;
                                flag = (byte)(flag >> (length % 8));
                                temp = (byte)(temp | flag);
                                if (length % 8 == 7)
                                {
                                    this.Value.ValueList.Add(temp);
                                }
                                length++;
                                this.Value.ValueLength = length;
                            }

                            if (mode == 2)
                            {
                                if (length % 8 != 0)
                                {
                                    this.Value.ValueList.Add(temp);
                                    this.Value.ValueLength = length;
                                }
                            }

                            //if ((float)data.MicroSecond > (float)this.FrameParam.Pulse0Low - (float)this.FrameParam.Pulse0Low * rate &&
                            //    (float)data.MicroSecond < (float)this.FrameParam.Pulse0Low + (float)this.FrameParam.Pulse0Low * rate)
                            //{
                            //    lowMicros = this.FrameParam.Pulse0Low;
                            //    high = false;
                            //}
                            //else if ((float)data.MicroSecond > (float)this.FrameParam.Pulse1Low - (float)this.FrameParam.Pulse1Low * rate &&
                            //    (float)data.MicroSecond < (float)this.FrameParam.Pulse1Low + (float)this.FrameParam.Pulse1Low * rate)
                            //{
                            //    lowMicros = this.FrameParam.Pulse1Low;
                            //    high = false;
                            //}
                            //else if(this.FrameParam.FrameInterval > 0 &&
                            //        (float)time > (float)this.FrameParam.FrameInterval - (float)this.FrameParam.FrameInterval * rate)
                            //{
                            //    lowMicros = 0;
                            //    high = false;
                            //    mode = 2;
                            //}
                            //else if (this.FrameParam.StopLow > 0 &&
                            //    (float)data.MicroSecond > (float)this.FrameParam.StopLow - (float)this.FrameParam.StopLow * rate)
                            //{
                            //    lowMicros = 0;
                            //    high = false;
                            //    mode = 2;
                            //}
                            //else
                            //{
                            //    error = true;
                            //    break;
                            //}

                            //if (highMicros == this.FrameParam.Pulse0High && lowMicros == this.FrameParam.Pulse0Low)
                            //{
                            //    if (length % 8 == 7)
                            //    {
                            //        this.Value.ValueList.Add(temp);
                            //    }
                            //    length++;
                            //}
                            //else if (highMicros == this.FrameParam.Pulse1High && lowMicros == this.FrameParam.Pulse1Low)
                            //{
                            //    byte flag = 0x80;
                            //    flag = (byte)(flag >> (length % 8));
                            //    temp = (byte)(temp | flag);
                            //    if (length % 8 == 7)
                            //    {
                            //        this.Value.ValueList.Add(temp);
                            //    }
                            //    length++;
                            //    this.Value.ValueLength = length;
                            //}

                            //if (mode == 2)
                            //{
                            //    if (length % 8 != 0)
                            //    {
                            //        this.Value.ValueList.Add(temp);
                            //        this.Value.ValueLength = length;
                            //    }
                            //}

                        }
                        break;
                    case 2: //
                        if (data.Value == 1 && high == true)
                        {
                            error = true;
                            break;
                        }
                        if (data.Value == 0 && high == false)
                        {
                            error = true;
                            break;
                        }
                        this.Value.ValueLength = length;
                        exit = true;
                        break;
                }
                if (error == true)
                {
                    break;
                }
                if (exit == true)
                {
                    break;
                }
                i++;
            }
            if (error == true)
            {
                this.ValueValid = false;
                this.Value.ValueList.Clear();
                this.Value.ValueLength = 0;
            }
            else
            {
                if (this.Format == FORMAT_OTHER)
                {
                    this.FrameParam.LeaderHigh = leaderHigh;
                    this.FrameParam.LeaderLow = leaderLow;
                }
                if (this.Format == IRFrame.FORMAT_UNIDEN)
                {
                    if (this.Value.ValueList.Count == 2)
                    {
                        if (Value.ValueLength != 16)
                        {

                            this.Value.ValueList[1] = 0x20;
                            this.Value.ValueLength = 16;
                        }
                        this.ValueValid = true;
                    }
                    else if (this.Value.ValueList.Count == 1)
                    {
                        this.Value.ValueList.Add(0x20);
                        this.Value.ValueLength = 16;
                        this.ValueValid = true;
                    }
                    else
                    {
                        this.Value.ValueList.Clear();
                        this.Value.ValueLength = 0;
                        this.ValueValid = false;
                    }
                }
                else
                {
                    if (this.FrameParam.StopLow == 0)
                    {
                        this.FrameParam.StopHigh = stopHigh;
                        this.FrameParam.StopLow = stopLow;
                    }
                    if (this.FrameParam.FrameInterval == 0)
                    {
                        int dataTime = 0;
                        if (this.FrameParam.Pulse0High + this.FrameParam.Pulse0Low > this.FrameParam.Pulse1High + this.FrameParam.Pulse1Low)
                        {
                            dataTime = (this.FrameParam.Pulse0High + this.FrameParam.Pulse0Low) * this.Value.ValueLength;
                        }
                        else
                        {
                            dataTime = (this.FrameParam.Pulse1High + this.FrameParam.Pulse1Low) * this.Value.ValueLength;
                        }
                        this.FrameParam.FrameInterval = this.LeaderHigh + this.LeaderLow + dataTime + this.StopHigh + this.StopLow;
                    }

                    this.ValueValid = true;
                }

            }
        }

    }

    public class IRFrameParam
    {
        public const int PPM_HIGH_LOW = 0;
        public const int PPM_LOW_HIGH = 1;
        public int CarrierHigh
        {
            get;
            set;
        }//micro second
        public int CarrierLow
        {
            get;
            set;
        }//micro second
        public int LeaderHigh
        {
            get;
            set;
        }//micro second
        public int LeaderLow
        {
            get;
            set;
        }//micro second
        public int Pulse0Modulation
        {
            get;
            set;
        }//micro second
        public int Pulse0High
        {
            get;
            set;
        }//micro second
        public int Pulse0Low
        {
            get;
            set;
        }//micro second
        public int Pulse1Modulation
        {
            get;
            set;
        }//micro second
        public int Pulse1High
        {
            get;
            set;
        }//micro second
        public int Pulse1Low
        {
            get;
            set;
        }//micro second
        public int StopHigh
        {
            get;
            set;
        }//micro second
        public int StopLow
        {
            get;
            set;
        }//micro second
        public int FrameInterval
        {
            get;
            set;
        }//micro second
        public int RepeatHigh
        {
            get;
            set;
        }//micro second
        public int RepeatLow
        {
            get;
            set;
        }//micro second

        public IRFrameParam(int carrierHigh, int carrierLow,
                            int leaderHigh, int leaderLow,
                            int pulse0Modulation, int pulse0High, int pulse0Low,
                            int pulse1Modulation, int pulse1High, int pulse1Low,
                            int stopHigh, int stopLow,
                            int frameInterval,
                            int repeatHigh, int repeatLow)
        {
            this.CarrierHigh = carrierHigh;
            this.CarrierLow = carrierLow;
            this.LeaderHigh = leaderHigh;
            this.LeaderLow = leaderLow;
            this.Pulse0Modulation = pulse0Modulation;
            this.Pulse0High = pulse0High;
            this.Pulse0Low = pulse0Low;
            this.Pulse1Modulation = pulse1Modulation;
            this.Pulse1High = pulse1High;
            this.Pulse1Low = pulse1Low;
            this.StopHigh = stopHigh;
            this.StopLow = stopLow;
            this.FrameInterval = frameInterval;
            this.RepeatHigh = repeatHigh;
            this.RepeatLow = repeatLow;
        }
    }

    public class IRFrameValue
    {
        public List<Byte> ValueList
        {
            get;
            set;
        }
        public int ValueLength
        {
            get;
            set;
        }
        public IRFrameValue()
        {
            this.ValueList = new List<byte>();
            this.ValueLength = 0;
        }
    }
}
