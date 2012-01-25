//#define DEBUGCOMM
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace MaiRimokon
{
    public partial class MaiRButtonPropertiesControl : UserControl
    {
        private IMaiRButton maiRButton;
        public MaiRButtonPropertiesControl(IMaiRButton maiRButton)
        {
            InitializeComponent();
#if DEBUGCOMM
#else
            string[] ports = SerialPort.GetPortNames();
            if (ports.Length == 0)
            {
                this.frameReadButton.Enabled = false;
            }
            else
            {
                this.frameReadButton.Enabled = false;
                foreach (string port in ports)
                {
                    if (port.Equals(MaiRimokon.Properties.Settings.Default.ComPort))
                    {
                        this.frameReadButton.Enabled = true;
                        break;
                    }
                }
            }
#endif
            this.maiRButton = maiRButton;
            if (this.maiRButton != null)
            {
                this.typeComboBox.SelectedIndex = (int)this.maiRButton.Type;
                this.colorComboBox.SelectedIndex = (int)this.maiRButton.Color;
                this.upperLabelTextBox.Text = this.maiRButton.UpperLabel;
                this.innerLabelTextBox.Text = this.maiRButton.InnerLabel;
                if (this.maiRButton.LongPush == false)
                {
                    this.longPushComboBox.SelectedIndex = 0;
                }
                else
                {
                    this.longPushComboBox.SelectedIndex = 1;
                }
                if (this.maiRButton.Disable == false)
                {
                    this.disableComboBox.SelectedIndex = 0;
                }
                else
                {
                    this.disableComboBox.SelectedIndex = 1;
                }
                if (this.maiRButton.Frames != null && this.maiRButton.Frames.Count > 0)
                {
                    SetFramesTextBoxValue(this.maiRButton.Frames);
                    
                }

            }
        }

        private void TypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.maiRButton != null)
            {
                switch(this.typeComboBox.SelectedIndex)
                {
                    case 0:
                        this.maiRButton.Type = MaiRControlValue.ButtonType.Type1; 
                        break;
                    case 1:
                        this.maiRButton.Type = MaiRControlValue.ButtonType.Type2;
                        break;
                    case 2:
                        this.maiRButton.Type = MaiRControlValue.ButtonType.Type3;
                        break;
                }
            }
        }

        private void ColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.maiRButton != null)
            {
                switch (this.colorComboBox.SelectedIndex)
                {
                    case 0:
                        this.maiRButton.Color = MaiRControlValue.ButtonColor.Default;
                        break;
                    case 1:
                        this.maiRButton.Color = MaiRControlValue.ButtonColor.Blue;
                        break;
                    case 2:
                        this.maiRButton.Color = MaiRControlValue.ButtonColor.Red;
                        break;
                    case 3:
                        this.maiRButton.Color = MaiRControlValue.ButtonColor.Green;
                        break;
                    case 4:
                        this.maiRButton.Color = MaiRControlValue.ButtonColor.Yellow;
                        break;
                }
            }
        }

        private void UpperLabelTextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.maiRButton != null)
            {
                this.maiRButton.UpperLabel = this.upperLabelTextBox.Text;
            }
        }

        private void InnerLabelTextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.maiRButton != null)
            {
                this.maiRButton.InnerLabel = this.innerLabelTextBox.Text;
            }
        }

        private void LongPushComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.maiRButton != null)
            {
                switch (this.longPushComboBox.SelectedIndex)
                {
                    case 0:
                        this.maiRButton.LongPush= false;
                        break;
                    case 1:
                        this.maiRButton.LongPush = true;
                        break;
                }
            }
        }

        private void DisableComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.maiRButton != null)
            {
                switch (this.disableComboBox.SelectedIndex)
                {
                    case 0:
                        this.maiRButton.Disable = false;
                        break;
                    case 1:
                        this.maiRButton.Disable = true;
                        break;
                }
            }
        }

        private void FrameReadButton_Click(object sender, EventArgs e)
        {
            ReadForm f = new ReadForm();
            DialogResult ret = f.ShowDialog();
            if (ret == DialogResult.OK)
            {
                List<IRFrame> frames = f.Frames;
                if (frames != null && frames.Count > 0)
                {
                    this.maiRButton.Format = f.Format;
                    this.maiRButton.Frames = frames;
                    SetFramesTextBoxValue(frames);
                }
                else
                {
                    this.maiRButton.Frames = null;
                    this.framesTextBox.Text = "";
                }
            }
            f.Dispose();

        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            if (this.maiRButton != null)
            {
                this.maiRButton.Frames = null;
            }
            this.framesTextBox.Text = "";
        }
        private void SetFramesTextBoxValue(List<IRFrame> frames)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <frames.Count; i++)
            {
                IRFrame frame = frames[i];
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
    }
}
