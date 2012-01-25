using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;

namespace MaiRimokon
{
    public class SerialComm:Comm
    {
        public static int BAUDRATE = 115200;
        private SerialPort port;
        private bool threadStop;

        public SerialComm(String comPort):base()
        {
            port = new SerialPort(comPort, BAUDRATE, Parity.None, 8, StopBits.One);
            port.ReadTimeout = 10000;
            port.WriteTimeout = 10000;
            this.RecvData = "";
            this.threadStop = true;
        }
        override public bool Connect()
        {
            bool ret = false;
            try
            {
                port.Open();
                port.DtrEnable = false;
                port.RtsEnable = false;
                ret = true;
            }
            catch
            {
                ret = false;
            }
            return ret;
        }
        override public bool SendStartCommand()
        {
            bool ret = false;
            try
            {
//                Thread.Sleep(3000);
                port.ReadTimeout = 10000;
                port.Write(STARTCOMMAND);
                ret = WaitCommandRecv(OKMESSAGE);
            }
            catch
            {
                ret = false;
            }
            return ret;
        }
        override public bool SendEndCommand()
        {
            bool ret = false;
            try
            {
                port.ReadTimeout = 10000;
                port.Write(ENDCOMMAND);
                ret = WaitCommandRecv(QUITMESSAGE);
            }
            catch
            {
                ret = false;
            }

            return ret;
        }
        override public int Recv()
        {
            int ret = -1;
            try
            {
                ret = -1;
                while (port.BytesToRead >= 0 )
                {
                    if (port.BytesToRead > 0)
                    {
                        port.ReadTimeout = 30000;
                        this.RecvData = this.RecvData + port.ReadLine();
                        if (this.RecvData.EndsWith(Comm.FINISHEDSTR))
                        {
                            this.RecvData = this.RecvData.Replace(Comm.FINISHEDSTR, "");
                            ret = this.RecvData.Length;
                            SendEndCommand();
                            break;
                        }
                    }
                    Thread.Sleep(100);
                }
            }
            catch
            {
                ret = -1;
            }

            return ret;
        }
        override public int RecvAsync()
        {
            int ret = -1;
            Thread th = new Thread(new ThreadStart(ThreadRecv));
            try
            {
                th.Start();
                ret = 0;
            }
            catch
            {
                ret = -1;
            }
            return ret;
        }

        private void ThreadRecv()
        {
            this.threadStop = false;
            try
            {
                while (port.BytesToRead >= 0 && this.threadStop == false)
                {
                    if (port.BytesToRead > 0)
                    {
                        port.ReadTimeout = 60000;
                        this.RecvData = this.RecvData + port.ReadLine();
                        if (this.RecvData.EndsWith(Comm.FINISHEDSTR))
                        {
                            this.RecvData = this.RecvData.Replace(Comm.FINISHEDSTR, "");
                            SendEndCommand();
                            CallFinishedCallback();
                            break;
                        }
                    }
                    Thread.Sleep(100);
                }
            }
            catch
            {
                this.threadStop = true;
            }
            this.threadStop = true;
        }
        public override void StopRecvAsync()
        {
            this.threadStop = true;
            SendEndCommand();
        }
        override public bool Close()
        {
            bool ret = false;
            try
            {
                StopRecvAsync();
                port.Close();
                ret = true;
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        private bool WaitCommandRecv(char message)
        {
            bool ret = false;
            try
            {
                //int count = 0;
                //while (port.BytesToRead >= 0 && count < 100)
                //{
                //    if (port.BytesToRead > 0)
                //    {
                //        int recvInt = port.ReadByte();
                //        char recvChar = (char)recvInt;
                //        if (recvChar == message)
                //        {
                //            ret = true;
                //        }
                //        else
                //        {
                //            ret = false;
                //        }
                //        break;
                //    }
                //    count++;
                //    Thread.Sleep(100);
                //}
                //ret = true;
                port.ReadTimeout = 10000;
                int recvInt = port.ReadByte();
                char recvChar = (char)recvInt;
                if (recvChar == message)
                {
                    ret = true;
                }
                else
                {
                    ret = false;
                }
            }
            catch
            {
                ret = false;
            }

            return ret;
        }
    }
}
