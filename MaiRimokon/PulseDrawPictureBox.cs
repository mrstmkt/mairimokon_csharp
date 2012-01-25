using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace MaiRimokon
{
    class PulseDrawPictureBox:PictureBox
    {
        private List<PulseData> dataList;
        public PulseDrawPictureBox()
            : base()
        {
            this.dataList = null;
        }
        public void Clear()
        {
            if (this.dataList != null)
            {
                this.dataList.Clear();
            }
            Invalidate();
        }

        public void DrawData(List<PulseData> dataList)
        {
            this.dataList = dataList;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Graphics g = pe.Graphics;
            Brush brush = new SolidBrush(this.BackColor);
            g.FillRectangle(brush, 0, 0, this.Width, this.Height);
            if (this.dataList != null && this.dataList.Count > 0)
            {
                int micros = 0;
                foreach (PulseData data in this.dataList)
                {
                    micros = micros + data.MicroSecond;
                }
                float microWidth = (float)this.Width / (float)micros;

                Pen scalePen = new Pen(Color.Gray);
                g.DrawLine(scalePen, 0, this.Height - 5, this.Width, this.Height - 5);
                float hPos = microWidth * 1000; //1000microsecond毎にメモリをつける
                while ((int)hPos < this.Width)
                {
                    g.DrawLine(scalePen, hPos, (float)this.Height - 7.0F, hPos, (float)this.Height - 3.0F);
                    hPos = hPos + microWidth * 1000;
                }
                scalePen.Dispose();
                float vHigh = (float)(this.Height - this.Height * 0.9);
                float vLow = this.Height - 10;
                hPos = 0;
                Pen pen = new Pen(Color.Red);
                PulseData prevData = null;
                int i = 0;
                foreach (PulseData data in this.dataList)
                {
                    if (prevData != null)
                    {
                        if (data.Value == prevData.Value)
                        {
                            if (data.Value == 0)
                            {
                                g.DrawLine(pen, hPos, vLow, hPos + microWidth * (float)prevData.MicroSecond, vLow);
                                hPos = hPos + microWidth * prevData.MicroSecond;
                            }
                            else
                            {
                                g.DrawLine(pen, hPos, vHigh, hPos + microWidth * (float)prevData.MicroSecond, vHigh);
                                hPos = hPos + microWidth * (float)prevData.MicroSecond;
                            }
                        }
                        else
                        {
                            if (data.Value == 0)
                            {
                                g.DrawLine(pen, hPos, vHigh, hPos + (float)microWidth * prevData.MicroSecond, vHigh);
                                hPos = hPos + microWidth * (float)prevData.MicroSecond;
                                g.DrawLine(pen, hPos, vHigh, hPos, vLow);
                            }
                            else
                            {
                                g.DrawLine(pen, hPos, vLow, hPos + microWidth * (float)prevData.MicroSecond, vLow);
                                hPos = hPos + microWidth * (float)prevData.MicroSecond;
                                g.DrawLine(pen, hPos, vLow, hPos, vHigh);
                            }
                        }
                        prevData = data;
                        if (i == this.dataList.Count - 1)
                        {
                            if (data.Value == 0)
                            {
                                g.DrawLine(pen, hPos, vLow, hPos + (float)microWidth * data.MicroSecond, vLow);
                            }
                            else
                            {
                                g.DrawLine(pen, hPos, vHigh, hPos + (float)microWidth * data.MicroSecond, vHigh);
                            }
                        }
                    }
                    else
                    {
                        prevData = data;
                    }
                    i++;
                }
                pen.Dispose();
            }
        }
    }
}
