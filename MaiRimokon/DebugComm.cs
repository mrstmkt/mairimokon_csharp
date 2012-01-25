﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MaiRimokon
{
    public class DebugComm : Comm
    {
        public DebugComm():base()
        {
        }
        override public bool Connect()
        {
            return true;
        }
        override public bool SendStartCommand()
        {
            return true;
        }
        override public bool SendEndCommand()
        {
            return true;
        }
        override public int Recv()
        {
            this.RecvData = "0-1000 1-1000 0-200 1-540 0-1000";
            int ret = this.RecvData.Length;
            return ret;
        }
        override public int RecvAsync()
        {
            Thread th = new Thread(new ThreadStart(() => {
                Thread.Sleep(2000);
//                this.RecvData = "0-1000 1-1000 0-200 1-540 0-1000";
                //NEC
                //this.RecvData = "0-1000 1-9000 0-4500 " +  //Leader
                //    "1-560 0-560 1-560 0-560 1-560 0-1690 1-560 0-1690 1-560 0-1690 1-560 0-1690 1-560 0-1690 1-560 0-1690 " + //00111111 0x3F
                //    "1-560 0-560 1-560 0-560 1-560 0-1690 1-560 0-1690 1-560 0-1690 1-560 0-1690 1-560 0-1690 " + //0011111 0x3E
                //    "1-560 0-23000"; //Stop

                //this.RecvData = "0-1000 1-9060 0-4570 " +  //Leader
                //    "1-560 0-560 1-570 0-560 1-560 0-1680 1-560 0-1700 1-560 0-1690 1-560 0-1690 1-560 0-1690 1-560 0-560 " + //00111111 0x3E
                //    "1-560 0-560 1-560 0-560 1-560 0-1690 1-560 0-1690 1-560 0-1690 1-560 0-1720 1-560 0-600 " + //0011111 0x3C
                //    "1-560 0-23000"; //Stop

                //this.RecvData = "0-1000 1-9060 0-4570 " +  //Leader
                //    "1-560 0-560 1-570 0-560 1-560 0-1680 1-560 0-1700 1-560 0-1690 1-560 0-1690 1-560 0-1690 1-560 0-560 " + //00111111 0x3E
                //    "1-560 0-560 1-560 0-560 1-560 0-1690 1-560 0-1690 1-560 0-1690 1-560 0-1720 1-560 0-600 " + //0011111 0x3C
                //    "1-560 0-100000 "; //Stop
                //this.RecvData = this.RecvData + "1-9060 0-4570 " +  //Leader
                //    "1-560 0-560 1-570 0-560 1-560 0-1680 1-560 0-1700 1-560 0-1690 1-560 0-1690 1-560 0-1690 1-560 0-560 " + //00111111 0x3E
                //    "1-560 0-560 1-560 0-560 1-560 0-1690 1-560 0-1690 1-560 0-1690 1-560 0-1720 1-560 0-600 " + //0011111 0x3C
                //    "1-560 0-100000"; //Stop

                //SONY
                //this.RecvData = "0-1000 1-2500 0-550 " +  //Leader
                //    "1-650 0-550 1-650 0-550 1-1250 0-550 1-1250 0-550 1-1250 0-550 1-1250 0-550 1-1250 0-550 1-1250 0-550 " + //00111111 0x3F
                //    "1-650 0-550 1-650 0-550 1-1250 0-550 1-1250 0-550 1-1250 0-550 1-1250 0-550 1-1250 0-10000 "; //0011111 0x3E
                //this.RecvData = "0-1000 1-2520 0-530 " +  //Leader
                //    "1-650 0-550 1-650 0-550 1-1250 0-550 1-1250 0-550 1-1250 0-550 1-1250 0-550 1-1250 0-550 1-650 0-550 " + //00111111 0x3E
                //    "1-620 0-560 1-650 0-550 1-1250 0-550 1-1230 0-530 1-1250 0-550 1-1250 0-550 1-650 0-10000 "; //0011111 0x3C

                this.RecvData = "0-1000 1-2520 0-530 " +  //Leader
                    "1-650 0-550 1-650 0-550 1-1250 0-550 1-1250 0-550 1-1250 0-550 1-1250 0-550 1-1250 0-550 1-650 0-550 " + //00111111 0x3E
                    "1-620 0-560 1-650 0-550 1-1250 0-550 1-1230 0-530 1-1250 0-550 1-1250 0-550 1-650 0-40000 "; //0011111 0x3C
                this.RecvData = this.RecvData + "1-2520 0-530 " +  //Leader
                    "1-650 0-550 1-650 0-550 1-1250 0-550 1-1250 0-550 1-1250 0-550 1-1250 0-550 1-1250 0-550 1-650 0-550 " + //00111111 0x3E
                    "1-620 0-560 1-650 0-550 1-1250 0-550 1-1230 0-530 1-1250 0-550 1-1250 0-550 1-650 0-40000 "; //0011111 0x3C

                //家電協
                //this.RecvData = "0-1000 1-3200 0-1620 " +  //Leader
                //    "1-400 0-400 1-400 0-400 1-400 0-1220 1-400 0-1200 1-400 0-1200 1-400 0-1200 1-400 0-1200 1-400 0-1200 " + //00111111 0x3F
                //    "1-400 0-400 1-400 0-400 1-400 0-1200 1-420 0-1200 1-400 0-1200 1-400 0-1200 1-400 0-1200 " + //0011111 0x3E
                //    "1-400 0-8000 "; //Stop
                //this.RecvData = this.RecvData + "1-3200 0-1620 " +  //Leader
                //    "1-400 0-400 1-400 0-400 1-400 0-1220 1-400 0-1200 1-400 0-1200 1-400 0-1200 1-400 0-1200 1-400 0-1200 " + //00111111 0x3F
                //    "1-400 0-400 1-400 0-400 1-400 0-1200 1-420 0-1200 1-400 0-1200 1-400 0-1200 1-400 0-1200 " + //0011111 0x3E
                //    "1-400 0-8000 "; //Stop

                CallFinishedCallback();
            }));
            th.Start();
            return 0;
        }
        public override void StopRecvAsync()
        {
        }
        override public bool Close()
        {
            return true;
        }
    }
}