using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MaiRimokon
{
    public partial class MaiRButtonView : UserControl, IMaiRButton
    {
        private const int TYPE1_BUTTON_WIDTH = 240 / 3 - 2;
        private const int TYPE1_BUTTON_HEIGHT = (int)(TYPE1_BUTTON_WIDTH * 0.7F) ;
        private const int TYPE2_BUTTON_WIDTH = (int)(TYPE1_BUTTON_WIDTH * 0.6F);
        private const int TYPE2_BUTTON_HEIGHT = TYPE2_BUTTON_WIDTH;
        private const int TYPE3_BUTTON_WIDTH = 240/4 - 2;
        private const int TYPE3_BUTTON_HEIGHT = TYPE3_BUTTON_WIDTH/2;
        private MaiRControlValue.ButtonType type;
        public MaiRControlValue.ButtonType Type
        {
            get { return type;}
            set
            {
                bool changed = false;
                if (this.type != value)
                {
                    changed = true;
                }

                this.type = value;
                switch(type)
                {
                    case MaiRControlValue.ButtonType.Type1:
                        this.button.Size = new Size(TYPE1_BUTTON_WIDTH, TYPE1_BUTTON_HEIGHT);
                        break;
                    case MaiRControlValue.ButtonType.Type2:
                        this.button.Size = new Size(TYPE2_BUTTON_WIDTH, TYPE2_BUTTON_HEIGHT);
                        break;
                    case MaiRControlValue.ButtonType.Type3:
                        this.button.Size = new Size(TYPE3_BUTTON_WIDTH, TYPE3_BUTTON_HEIGHT);
                        break;
                    default:
                        this.button.Size = new Size(TYPE1_BUTTON_WIDTH, TYPE1_BUTTON_HEIGHT);
                        break;
                }
                this.panel1.Size = new Size(this.button.Width, this.upperlabel.Height + this.button.Height + 2);
                this.Size = new Size(this.button.Width, this.upperlabel.Height + this.button.Height + 2);
                this.rimokonDataLabel.Location = new Point(this.panel1.Width - this.rimokonDataLabel.Width,this.rimokonDataLabel.Location.Y);
                if(changed == true)
                {
                    RaiseValueChangedEvent(this, new ValueChangedEventArgs("Type", value));
                }
            }
        }

        private MaiRControlValue.ButtonColor color;
        public MaiRControlValue.ButtonColor Color
        {
            get
            {
                return color;
            }
            set
            {
                bool changed = false;
                if (!this.color.Equals(value))
                {
                    changed = true;
                }
                this.color = value;
                switch (this.color)
                {
                    case MaiRControlValue.ButtonColor.Default:
                        this.button.BackColor = System.Drawing.Color.White;
                        this.button.ForeColor = System.Drawing.Color.Black;
                        break;
                    case MaiRControlValue.ButtonColor.Blue:
                        this.button.BackColor = System.Drawing.Color.Blue;
                        this.button.ForeColor = System.Drawing.Color.White;
                        break;
                    case MaiRControlValue.ButtonColor.Red:
                        this.button.BackColor = System.Drawing.Color.Red;
                        this.button.ForeColor = System.Drawing.Color.White;
                        break;
                    case MaiRControlValue.ButtonColor.Green:
                        this.button.BackColor = System.Drawing.Color.LightGreen;
                        this.button.ForeColor = System.Drawing.Color.Black;
                        break;
                    case MaiRControlValue.ButtonColor.Yellow:
                        this.button.BackColor = System.Drawing.Color.Yellow;
                        this.button.ForeColor = System.Drawing.Color.Black;
                        break;
                    default:
                        this.button.BackColor = System.Drawing.Color.White;
                        this.button.ForeColor = System.Drawing.Color.Black;
                        break;
                }
                if (changed == true)
                {
                    RaiseValueChangedEvent(this, new ValueChangedEventArgs("Color", value));
                }
            }
        }
        public int Format
        {
            get;
            set;
        }
        private List<IRFrame> frames;
        public List<IRFrame> Frames
        {
            get
            {
                return frames;
            }
            set
            {
                bool changed = false;
                if (frames == null && value != null)
                {
                    changed = true;
                }
                if (frames != null && !frames.Equals(value))
                {
                    changed = true;
                }

                this.frames = value;
                if (this.frames != null && this.frames.Count > 0)
                {
                    this.Format = this.frames[0].Format;
                    this.rimokonDataLabel.Visible = true;
                }
                else
                {
                    this.rimokonDataLabel.Visible = false;
                }
                if (changed == true)
                {
                    RaiseValueChangedEvent(this, new ValueChangedEventArgs("IRFrames", value));
                }
            }
        }
        //private IRFrame frame;
        //public IRFrame Frame
        //{
        //    get
        //    {
        //        return frame;
        //    }
        //    set
        //    {
        //        bool changed = false;
        //        if (frame == null && value != null)
        //        {
        //            changed = true;
        //        }
        //        if (frame != null && !frame.Equals(value))
        //        {
        //            changed = true;
        //        }

        //        this.frame = value;
        //        if (this.frame != null)
        //        {
        //            this.rimokonDataLabel.Visible = true;
        //        }
        //        else
        //        {
        //            this.rimokonDataLabel.Visible = false;
        //        }
        //        if (changed == true)
        //        {
        //            RaiseValueChangedEvent(this, new ValueChangedEventArgs("IRFrame", value));
        //        }
        //    }
        //}
        public string UpperLabel
        {
            get
            {
                return this.upperlabel.Text;
            }
            set
            {
                bool changed = false;
                if (!this.upperlabel.Text.Equals(value))
                {
                    changed = true;
                }

                this.upperlabel.Text = value;

                if (changed == true)
                {
                    RaiseValueChangedEvent(this, new ValueChangedEventArgs("UpperLabel", value));
                }
            }
        }
        public string InnerLabel
        {
            get
            {
                return this.button.Text;
            }
            set
            {
                bool changed = false;
                if (!this.button.Text.Equals(value))
                {
                    changed = true;
                }

                this.button.Text = value;

                if (changed == true)
                {
                    RaiseValueChangedEvent(this, new ValueChangedEventArgs("InnerLabel", value));
                }
            }
        }
        private bool longPush;
        public bool LongPush
        {
            get
            {
                return longPush;
            }
            set
            {
                bool changed = false;
                if (longPush != value)
                {
                    changed = true;
                }

                longPush = value;

                if (changed == true)
                {
                    RaiseValueChangedEvent(this, new ValueChangedEventArgs("LongPush", value));
                }
            }
        }
        private bool disable;
        public bool Disable
        {
            get
            {
                return disable;
            }

            set
            {
                bool changed = false;
                if (disable != value)
                {
                    changed = true;
                }
                this.disable = value;
//                this.button.Enabled = !value;
                this.upperlabel.Visible = !value;
                this.button.Visible = !value;
                if (changed == true)
                {
                    RaiseValueChangedEvent(this, new ValueChangedEventArgs("Disable", value));
                }
            }
        }
        public bool Selected
        {
            get;
            set;
        }
        public MainForm MainForm
        {
            internal get;
            set;
        }

        public event MaiRControlValue.ValueChangedHandler ValueChanged;
        protected void RaiseValueChangedEvent(object sender, ValueChangedEventArgs e)
        {
            MaiRControlValue.ValueChangedHandler handler = ValueChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        public event MaiRControlValue.SelectChangedHandler SelectChanged;
        protected void RaiseSelectChangedEvent(object sender)
        {
            MaiRControlValue.SelectChangedHandler handler = SelectChanged;
            if (handler != null)
            {
                handler(this);
            }
        }

        public MaiRButtonView()
        {
            InitializeComponent();
            this.TabStop = true;
            this.type = MaiRControlValue.ButtonType.Type1;
            this.Type = MaiRControlValue.ButtonType.Type1;
            this.color = MaiRControlValue.ButtonColor.Default;
            this.Color = MaiRControlValue.ButtonColor.Default;
            this.disable = false;
            this.longPush = false;
            this.frames = null;
            this.MainForm = null;
            this.UpperLabel = "";
            this.InnerLabel = "";
            this.rimokonDataLabel.Visible = false;
            this.Selected = false;
            this.Format = IRFrame.FORMAT_DENKYO;
        }

        private void MaiRButtonView_Click(object sender, EventArgs e)
        {
            if (this.MainForm != null)
            {
                this.MainForm.ShowEditArea(this);
            }
            RaiseSelectChangedEvent(this);
        }

        private void button_Click(object sender, EventArgs e)
        {
            MaiRButtonView_Click(this, e);
        }

        private void Upperlabel_Click(object sender, EventArgs e)
        {
            MaiRButtonView_Click(this, e);
        }

        private void MaiRButtonView_Enter(object sender, EventArgs e)
        {

        }

        private void MaiRButtonView_Leave(object sender, EventArgs e)
        {

        }

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    base.OnPaint(e);
        //    if (this.MainForm != null)
        //    {
        //        if (this.Selected == true)
        //        {
        //            Graphics g = e.Graphics;
        //            Pen p = new Pen(System.Drawing.Color.Red, 10);
        //            g.DrawRectangle(p, 0, 0, this.Width, this.Height);
        //        }
        //    }
        //}
        public void ViewSelect(bool value)
        {
            if (value == true)
            {
                this.BackColor = System.Drawing.Color.DarkCyan;
                this.Selected = true;
            }
            else
            {
                this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
                this.Selected = false;
            }
        }
    }
}
