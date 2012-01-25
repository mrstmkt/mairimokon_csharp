//#define DEBUGCOMM
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MaiRimokon
{
    public partial class ReadForm : Form
    {
        private bool readStart;
        private IRReader reader;
        private List<IRFrame> frames;

        public int Format
        {
            get;
            internal set;
        }
        public List<IRFrame> Frames
        {
            get
            {
                return frames;
            }
        }
        public ReadForm()
        {
            InitializeComponent();
            SetDefault();
        }

        private void SetDefault()
        {
            this.panel1.Enabled = false;
            this.messageLabel1.Text = "";
            this.messageLabel2.Text = "";
            this.framesTextBox.Text = "";
            this.pulseDrawPictureBox1.Clear();
            this.pulseDataTextBox.Text="";
            this.Format = IRFrame.FORMAT_DENKYO;
            showLED(false);
            this.propSaveButton.Visible = false;
            IRFrameParam defaultFrame;
            if (MaiRimokon.Properties.Settings.Default.SelectedFormat == IRFrame.FORMAT_NEC)
            {
                this.formatComboBox.SelectedIndex = 0;
                defaultFrame = IRFrame.GetDefaultParam(IRFrame.FORMAT_NEC);
            }
            else if (MaiRimokon.Properties.Settings.Default.SelectedFormat == IRFrame.FORMAT_SONY)
            {
                this.formatComboBox.SelectedIndex = 1;
                defaultFrame = IRFrame.GetDefaultParam(IRFrame.FORMAT_SONY);
            }
            else if (MaiRimokon.Properties.Settings.Default.SelectedFormat == IRFrame.FORMAT_DENKYO)
            {
                this.formatComboBox.SelectedIndex = 2;
                defaultFrame = IRFrame.GetDefaultParam(IRFrame.FORMAT_DENKYO);
            }
            else if (MaiRimokon.Properties.Settings.Default.SelectedFormat == IRFrame.FORMAT_UNIDEN)
            {
                this.formatComboBox.SelectedIndex = 3;
                defaultFrame = IRFrame.GetDefaultParam(IRFrame.FORMAT_UNIDEN);
            }
            else if (MaiRimokon.Properties.Settings.Default.SelectedFormat == IRFrame.FORMAT_OTHER)
            {
                this.formatComboBox.SelectedIndex = 4;
                defaultFrame = IRFrame.GetDefaultParam(IRFrame.FORMAT_OTHER);
                this.propSaveButton.Visible = true;
            }
            else
            {
                this.formatComboBox.SelectedIndex = 2;
                defaultFrame = IRFrame.GetDefaultParam(IRFrame.FORMAT_DENKYO);
            }
            leaderHighTextBox.Text = Convert.ToString(defaultFrame.LeaderHigh);
            leaderLowTextBox.Text = Convert.ToString(defaultFrame.LeaderLow);
            pulse0HighTextBox.Text = Convert.ToString(defaultFrame.Pulse0High);
            pulse0LowTextBox.Text = Convert.ToString(defaultFrame.Pulse0Low);
            pulse1HighTextBox.Text = Convert.ToString(defaultFrame.Pulse1High);
            pulse1LowTextBox.Text = Convert.ToString(defaultFrame.Pulse1Low);
            stopHighTextBox.Text = Convert.ToString(defaultFrame.StopHigh);
            stopLowTextBox.Text = Convert.ToString(defaultFrame.StopLow);
            repeatHighTextBox.Text = Convert.ToString(defaultFrame.RepeatHigh);
            repeatLowTextBox.Text = Convert.ToString(defaultFrame.RepeatLow);
            frameIntervalTextBox.Text = Convert.ToString(defaultFrame.FrameInterval);
            this.readStart = false;
            this.reader = null;
            this.frames = null;
        }

        private void StartStopButton_Click(object sender, EventArgs e)
        {
            if (this.readStart == false)
            {
                ClearReadArea();
                startStopButton.Enabled = false;
                this.panel1.Enabled = false;
                this.frames = null;
#if DEBUGCOMM
                this.reader = new IRReader(IRReader.TYPE_DEBUG);
#else
                this.reader = new IRReader(IRReader.TYPE_SERIAL, MaiRimokon.Properties.Settings.Default.ComPort);
#endif
                if (this.reader.Connect() == false)
                {
                    this.messageLabel1.Text = "Connect Error.";
                    startStopButton.Enabled = true;
                    this.readStart = false;
                    return;
                }
                if (this.reader.Start() == false)
                {
                    this.messageLabel1.Text = "StartCommand Send Error";
                    startStopButton.Enabled = true;
                    this.readStart = false;
                    this.reader.Close();
                    return;
                }
                showLED(true);
                this.reader.setFinishedCallback(RecvFinishedCallback);
                if (this.reader.RecvAsync() < 0)
                {
                    this.messageLabel1.Text = "Recv Error";
                    startStopButton.Enabled = true;
                    this.readStart = false;
                    showLED(false);
                    this.reader.Close();
                    return;
                }
                this.messageLabel1.Text = "読込中・・・";
                this.startStopButton.Text = "読み込み終了";
                this.readStart = true;
                startStopButton.Enabled = true;
            }
            else
            {
                RecvFinished();
            }
        }
        private void ClearReadArea()
        {
            this.messageLabel1.Text = "";
            this.pulseDrawPictureBox1.Clear();
            this.pulseDataTextBox.Text = "";
            showLED(false);
            this.frames = null;
            this.messageLabel2.Text = "";
            this.framesTextBox.Text = "";
        }
        private delegate void RecvFinishedInvoker();
        private void RecvFinishedCallback()
        {
            Invoke(new RecvFinishedInvoker(RecvFinished));
        }
        private void RecvFinished()
        {
            showLED(false);
            startStopButton.Enabled = false;
            if (this.reader != null)
            {
                this.reader.StopRecvAsync();
                this.reader.Close();
                if (this.reader.CheckRecvData() == true)
                {
                    this.pulseDrawPictureBox1.DrawData(this.reader.DataList);
                    StringBuilder sb = new StringBuilder();
                    foreach (PulseData data in this.reader.DataList)
                    {
                        sb.Append(data.Value + "-" + data.MicroSecond);
                        sb.Append(" ");
                    }
                    this.pulseDataTextBox.Text = sb.ToString();
                    this.panel1.Enabled = true;
                    this.messageLabel1.Text = "";
                }
                else
                {
                    this.panel1.Enabled = false;
                    this.messageLabel1.Text = "Read Data Error.";
                }
            }
            else
            {
                this.panel1.Enabled = false;
                this.messageLabel1.Text = "";
            }
            this.startStopButton.Text = "読み込み開始";
            this.readStart = false;
            startStopButton.Enabled = true;
        }

        private void FormatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            IRFrameParam defaultFrame;
            this.propSaveButton.Visible = false;
            if (formatComboBox.SelectedIndex == 0)
            {
                defaultFrame = IRFrame.GetDefaultParam(IRFrame.FORMAT_NEC);
                MaiRimokon.Properties.Settings.Default.SelectedFormat = IRFrame.FORMAT_NEC;
            }
            else if (formatComboBox.SelectedIndex == 1)
            {
                defaultFrame = IRFrame.GetDefaultParam(IRFrame.FORMAT_SONY);
                MaiRimokon.Properties.Settings.Default.SelectedFormat = IRFrame.FORMAT_SONY;
            }
            else if (formatComboBox.SelectedIndex == 2)
            {
                defaultFrame = IRFrame.GetDefaultParam(IRFrame.FORMAT_DENKYO);
                MaiRimokon.Properties.Settings.Default.SelectedFormat = IRFrame.FORMAT_DENKYO;
            }
            else if (formatComboBox.SelectedIndex == 3)
            {
                defaultFrame = IRFrame.GetDefaultParam(IRFrame.FORMAT_UNIDEN);
                MaiRimokon.Properties.Settings.Default.SelectedFormat = IRFrame.FORMAT_UNIDEN;
            }
            else if (formatComboBox.SelectedIndex == 4)
            {
                defaultFrame = IRFrame.GetDefaultParam(IRFrame.FORMAT_OTHER);
                MaiRimokon.Properties.Settings.Default.SelectedFormat = IRFrame.FORMAT_OTHER;
                this.propSaveButton.Visible = true;
            }
            else
            {
                defaultFrame = IRFrame.GetDefaultParam(IRFrame.FORMAT_DENKYO);
                MaiRimokon.Properties.Settings.Default.SelectedFormat = IRFrame.FORMAT_DENKYO;
            }
            MaiRimokon.Properties.Settings.Default.Save();
            leaderHighTextBox.Text = Convert.ToString(defaultFrame.LeaderHigh);
            leaderLowTextBox.Text = Convert.ToString(defaultFrame.LeaderLow);
            pulse0HighTextBox.Text = Convert.ToString(defaultFrame.Pulse0High);
            pulse0LowTextBox.Text = Convert.ToString(defaultFrame.Pulse0Low);
            pulse1HighTextBox.Text = Convert.ToString(defaultFrame.Pulse1High);
            pulse1LowTextBox.Text = Convert.ToString(defaultFrame.Pulse1Low);
            stopHighTextBox.Text = Convert.ToString(defaultFrame.StopHigh);
            stopLowTextBox.Text = Convert.ToString(defaultFrame.StopLow);
            repeatHighTextBox.Text = Convert.ToString(defaultFrame.RepeatHigh);
            repeatLowTextBox.Text = Convert.ToString(defaultFrame.RepeatLow);
            frameIntervalTextBox.Text = Convert.ToString(defaultFrame.FrameInterval);
        }

        private void AnalysisButton_Click(object sender, EventArgs e)
        {
            this.analysisButton.Enabled = false;
            if (this.reader == null || this.reader.DataList == null || this.reader.DataList.Count == 0)
            {
                this.messageLabel2.Text = "データ未取得";
                this.analysisButton.Enabled = true;
                return;
            }
            int format;
            if(this.formatComboBox.SelectedIndex == 0)
            {
                format = IRFrame.FORMAT_NEC;
            }
            else if(this.formatComboBox.SelectedIndex == 1)
            {
                format = IRFrame.FORMAT_SONY;
            }
            else if (this.formatComboBox.SelectedIndex == 2)
            {
                format = IRFrame.FORMAT_DENKYO;
            }
            else if (this.formatComboBox.SelectedIndex == 3)
            {
                format = IRFrame.FORMAT_UNIDEN;
            }
            else if (this.formatComboBox.SelectedIndex == 4)
            {
                format = IRFrame.FORMAT_OTHER;
            }
            else
            {
                format = IRFrame.FORMAT_DENKYO;
            }
            IRFrameParam defaultParam = IRFrame.GetDefaultParam(format);
            int leaderHigh = 0;
            if(Int32.TryParse(this.leaderHighTextBox.Text, out leaderHigh) == false)
            {
                leaderHigh = defaultParam.LeaderHigh;
                this.leaderHighTextBox.Text = Convert.ToString(leaderHigh);
            }
            int leaderLow = 0;
            if(Int32.TryParse(this.leaderLowTextBox.Text, out leaderLow) == false)
            {
                leaderLow = defaultParam.LeaderLow;
                this.leaderLowTextBox.Text = Convert.ToString(leaderLow);
            }
            int pulse0High = 0;
            if(Int32.TryParse(this.pulse0HighTextBox.Text, out pulse0High) == false)
            {
                pulse0High = defaultParam.Pulse0High;
                this.pulse0HighTextBox.Text = Convert.ToString(pulse0High);
            }
            int pulse0Low = 0;
            if(Int32.TryParse(this.pulse0LowTextBox.Text, out pulse0Low) == false)
            {
                pulse0Low = defaultParam.Pulse0Low;
                this.pulse0LowTextBox.Text = Convert.ToString(pulse0Low);
            }
            int pulse1High = 0;
            if(Int32.TryParse(this.pulse1HighTextBox.Text, out pulse1High) == false)
            {
                pulse1High = defaultParam.Pulse1High;
                this.pulse1HighTextBox.Text = Convert.ToString(pulse1High);
            }
            int pulse1Low = 0;
            if(Int32.TryParse(this.pulse1LowTextBox.Text, out pulse1Low) == false)
            {
                pulse1Low = defaultParam.Pulse1Low;
                this.pulse1LowTextBox.Text = Convert.ToString(pulse1Low);
            }
            int stopHigh = 0;
            if(Int32.TryParse(this.stopHighTextBox.Text, out stopHigh) == false)
            {
                stopHigh = defaultParam.StopHigh;
                this.stopHighTextBox.Text = Convert.ToString(stopHigh);
            }
            int stopLow = 0;
            if(Int32.TryParse(this.stopLowTextBox.Text, out stopLow) == false)
            {
                stopLow = defaultParam.StopLow;
                this.stopLowTextBox.Text = Convert.ToString(stopLow);
            }
            int repeatHigh = 0;
            if (Int32.TryParse(this.repeatHighTextBox.Text, out repeatHigh) == false)
            {
                repeatHigh = defaultParam.RepeatHigh;
                this.repeatHighTextBox.Text = Convert.ToString(repeatHigh);
            }
            int repeatLow = 0;
            if (Int32.TryParse(this.repeatLowTextBox.Text, out repeatLow) == false)
            {
                repeatLow = defaultParam.RepeatLow;
                this.repeatLowTextBox.Text = Convert.ToString(repeatLow);
            }
            int frameInterval = 0;
            if (Int32.TryParse(this.frameIntervalTextBox.Text, out frameInterval) == false)
            {
                frameInterval = defaultParam.FrameInterval;
                this.frameIntervalTextBox.Text = Convert.ToString(frameInterval);
            }
            IRFrameParam param = new IRFrameParam(defaultParam.CarrierHigh,
                                                defaultParam.CarrierLow,
                                                leaderHigh,
                                                leaderLow,
                                                defaultParam.Pulse0Modulation,
                                                pulse0High,
                                                pulse0Low,
                                                defaultParam.Pulse1Modulation,
                                                pulse1High,
                                                pulse1Low,
                                                stopHigh,
                                                stopLow,
                                                frameInterval,
                                                repeatHigh,
                                                repeatLow);
            this.frames = this.reader.GetFrames(format, param);
            if (this.frames == null || this.frames.Count == 0)
            {
                this.messageLabel2.Text = "解析失敗";
                this.framesTextBox.Text = "";
            }
            else
            {
                this.Format = format;
                this.messageLabel2.Text = "";
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < this.frames.Count; i++)
                {
                    IRFrame frame = this.frames[i];
                    sb.Append("Frame" + i + ": ");
                    switch (frame.Format)
                    {
                        case IRFrame.FORMAT_NEC:
                            sb.Append("フォーマット=NEC, ");
                            break;
                        case IRFrame.FORMAT_SONY:
                            sb.Append("フォーマット=SONY, ");
                            break;
                        case IRFrame.FORMAT_DENKYO:
                            sb.Append("フォーマット=家電協, ");
                            break;
                        case IRFrame.FORMAT_UNIDEN:
                            sb.Append("フォーマット=ユニデン, ");
                            break;
                        case IRFrame.FORMAT_OTHER:
                            sb.Append("フォーマット=その他, ");
                            break;
                    }
                    sb.Append("リーダHigh=" + frame.FrameParam.LeaderHigh + ", ");
                    sb.Append("リーダLow=" + frame.FrameParam.LeaderLow + ", ");
                    sb.Append("Value=");
                    foreach (byte dat in frame.Value.ValueList)
                    {
                        string hex = Convert.ToString(dat, 16);
                        if (hex.Length < 2)
                        {
                            hex = "0" + hex;
                        }
                        sb.Append(hex);
                    }
                    sb.Append(", ");
                    sb.Append("ValueLen=" + frame.Value.ValueLength + "bit, ");
                    sb.Append("ストップHigh=" + frame.FrameParam.StopHigh + ", ");
                    sb.Append("ストップLow=" + frame.FrameParam.StopLow + ", ");
                    sb.AppendLine("フレーム間隔=" + frame.FrameParam.FrameInterval);
                }
                this.framesTextBox.Text = sb.ToString();
            }
            this.analysisButton.Enabled = true;

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (this.frames != null && this.frames.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                DialogResult ret = MessageBox.Show("リモコンデータが読み取れていません。\n終了しますか？", "確認", MessageBoxButtons.YesNo);
                if (ret == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            SetDefault();
        }

        private void showLED(bool value)
        {
            this.LEDLabel.Visible = value;
        }

        private void PropSaveButton_Click(object sender, EventArgs e)
        {
            if (this.formatComboBox.SelectedIndex == 4)
            {
                IRFrameParam defaultParam = IRFrame.GetDefaultParam(IRFrame.FORMAT_OTHER);
                int leaderHigh = 0;
                if (Int32.TryParse(this.leaderHighTextBox.Text, out leaderHigh) == false)
                {
                    leaderHigh = defaultParam.LeaderHigh;
                    this.leaderHighTextBox.Text = Convert.ToString(leaderHigh);
                }
                MaiRimokon.Properties.Settings.Default.OtherLeaderHigh = leaderHigh;

                int leaderLow = 0;
                if (Int32.TryParse(this.leaderLowTextBox.Text, out leaderLow) == false)
                {
                    leaderLow = defaultParam.LeaderLow;
                    this.leaderLowTextBox.Text = Convert.ToString(leaderLow);
                }
                MaiRimokon.Properties.Settings.Default.OtherLeaderLow = leaderLow;

                int pulse0High = 0;
                if (Int32.TryParse(this.pulse0HighTextBox.Text, out pulse0High) == false)
                {
                    pulse0High = defaultParam.Pulse0High;
                    this.pulse0HighTextBox.Text = Convert.ToString(pulse0High);
                }
                MaiRimokon.Properties.Settings.Default.OtherPulse0High = pulse0High;

                int pulse0Low = 0;
                if (Int32.TryParse(this.pulse0LowTextBox.Text, out pulse0Low) == false)
                {
                    pulse0Low = defaultParam.Pulse0Low;
                    this.pulse0LowTextBox.Text = Convert.ToString(pulse0Low);
                }
                MaiRimokon.Properties.Settings.Default.OtherPulse0Low = pulse0Low;

                int pulse1High = 0;
                if (Int32.TryParse(this.pulse1HighTextBox.Text, out pulse1High) == false)
                {
                    pulse1High = defaultParam.Pulse1High;
                    this.pulse1HighTextBox.Text = Convert.ToString(pulse1High);
                }
                MaiRimokon.Properties.Settings.Default.OtherPulse1High = pulse1High;

                int pulse1Low = 0;
                if (Int32.TryParse(this.pulse1LowTextBox.Text, out pulse1Low) == false)
                {
                    pulse1Low = defaultParam.Pulse1Low;
                    this.pulse1LowTextBox.Text = Convert.ToString(pulse1Low);
                }
                MaiRimokon.Properties.Settings.Default.OtherPulse1Low = pulse1Low;

                int stopHigh = 0;
                if (Int32.TryParse(this.stopHighTextBox.Text, out stopHigh) == false)
                {
                    stopHigh = defaultParam.StopHigh;
                    this.stopHighTextBox.Text = Convert.ToString(stopHigh);
                }
                MaiRimokon.Properties.Settings.Default.OtherStopHigh = stopHigh;

                int stopLow = 0;
                if (Int32.TryParse(this.stopLowTextBox.Text, out stopLow) == false)
                {
                    stopLow = defaultParam.StopLow;
                    this.stopLowTextBox.Text = Convert.ToString(stopLow);
                }
                MaiRimokon.Properties.Settings.Default.OtherStopLow = stopLow;

                int repeatHigh = 0;
                if (Int32.TryParse(this.repeatHighTextBox.Text, out repeatHigh) == false)
                {
                    repeatHigh = defaultParam.RepeatHigh;
                    this.repeatHighTextBox.Text = Convert.ToString(repeatHigh);
                }
                MaiRimokon.Properties.Settings.Default.OtherRepeatHigh = repeatHigh;

                int repeatLow = 0;
                if (Int32.TryParse(this.repeatLowTextBox.Text, out repeatLow) == false)
                {
                    repeatLow = defaultParam.RepeatLow;
                    this.repeatLowTextBox.Text = Convert.ToString(repeatLow);
                }
                MaiRimokon.Properties.Settings.Default.OtherRepeatLow = repeatLow;

                int frameInterval = 0;
                if (Int32.TryParse(this.frameIntervalTextBox.Text, out frameInterval) == false)
                {
                    frameInterval = defaultParam.FrameInterval;
                    this.frameIntervalTextBox.Text = Convert.ToString(frameInterval);
                }
                MaiRimokon.Properties.Settings.Default.OtherFrameInterval = frameInterval;
                MaiRimokon.Properties.Settings.Default.Save();
                IRFrame.UpdateDefaultParamDic();
            }
        }
    }
}
