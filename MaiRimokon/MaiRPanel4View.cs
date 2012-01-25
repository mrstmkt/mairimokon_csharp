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
    public partial class MaiRPanel4View : UserControl, IMaiRPanel
    {
        public MaiRControlValue.PanelType Type
        {
            get
            {
                return MaiRControlValue.PanelType.Type4;
            }
        }

        private List<IMaiRButton> buttonItems;
        public List<IMaiRButton> ButtonItems
        {
            get
            {
                return this.buttonItems;
            }
            set
            {
                if (this.buttonItems != null)
                {
                    for (int i = 0; i < value.Count && i < this.buttonItems.Count; i++)
                    {
                        this.buttonItems[i].Type = value[i].Type;
                        this.buttonItems[i].UpperLabel = value[i].UpperLabel;
                        this.buttonItems[i].InnerLabel = value[i].InnerLabel;
                        this.buttonItems[i].Color = value[i].Color;
                        this.buttonItems[i].LongPush = value[i].LongPush;
                        this.buttonItems[i].Disable = value[i].Disable;
                        this.buttonItems[i].Frames = value[i].Frames;
                    }
                }
            }
        }
        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                bool changed = false;
                if (title == null && value != null)
                {
                    changed = true;
                }
                title = value;
                if (changed == true)
                {
                    RaiseValueChangedEvent(this, new ValueChangedEventArgs("Title", value));
                }
            }
        }
        public bool Selected
        {
            get;
            set;
        }

        private MainForm mainForm;
        public MainForm MainForm
        {
            internal get
            {
                return mainForm;
            }
            set
            {
                this.mainForm = value;
                foreach (MaiRButtonView button in this.ButtonItems)
                {
                    button.MainForm = value;
                }
            }
        }
        private event MaiRControlValue.ValueChangedHandler valueChanged;
        public event MaiRControlValue.ValueChangedHandler ValueChanged
        {
            add
            {
                this.valueChanged += value;
                foreach (IMaiRButton button in this.ButtonItems)
                {
                    button.ValueChanged += value;
                }
            }
            remove
            {
                this.valueChanged -= value;
                foreach (IMaiRButton button in this.ButtonItems)
                {
                    button.ValueChanged -= value;
                }
            }
        }
        protected void RaiseValueChangedEvent(object sender, ValueChangedEventArgs e)
        {
            MaiRControlValue.ValueChangedHandler handler = this.valueChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private event MaiRControlValue.SelectChangedHandler selectChanged;
        public event MaiRControlValue.SelectChangedHandler SelectChanged
        {
            add
            {
                this.selectChanged += value;
                foreach (IMaiRButton button in this.ButtonItems)
                {
                    button.SelectChanged += value;
                }
            }
            remove
            {
                this.selectChanged -= value;
                foreach (IMaiRButton button in this.ButtonItems)
                {
                    button.SelectChanged -= value;
                }
            }
        }
        protected void RaiseSelectChangedEvent(object sender)
        {
            MaiRControlValue.SelectChangedHandler handler = this.selectChanged;
            if (handler != null)
            {
                handler(this);
            }
        }


        public MaiRPanel4View()
            : this(null)
        {
//            this.buttonItems = new List<IMaiRButton>();
        }
        public MaiRPanel4View(MainForm main)
        {
            InitializeComponent();
            this.topDownFlowLayoutPanel.TabStop = true;
            this.topDownFlowLayoutPanel.Width = this.Width;
            this.topDownFlowLayoutPanel.Height = this.Height;
            this.title = "";
            this.buttonItems = new List<IMaiRButton>();
            this.ButtonItems.Add(this.button1_1);
            this.ButtonItems.Add(this.button1_2);
            this.ButtonItems.Add(this.button1_3);
            this.ButtonItems.Add(this.button2_1);
            this.ButtonItems.Add(this.button2_2);
            this.ButtonItems.Add(this.button2_3);
            this.ButtonItems.Add(this.button2_4);
            this.ButtonItems.Add(this.button3_1);
            this.ButtonItems.Add(this.button3_2);
            this.ButtonItems.Add(this.button3_3);
            this.ButtonItems.Add(this.button3_4);
            this.ButtonItems.Add(this.button4_1);
            this.ButtonItems.Add(this.button4_2);
            this.ButtonItems.Add(this.button4_3);
            this.ButtonItems.Add(this.button4_4);
            this.ButtonItems.Add(this.button5_1);
            this.ButtonItems.Add(this.button5_2);
            this.ButtonItems.Add(this.button5_3);
            this.ButtonItems.Add(this.button5_4);
            this.ButtonItems.Add(this.button6_1);
            this.ButtonItems.Add(this.button6_2);
            this.ButtonItems.Add(this.button6_3);
            this.ButtonItems.Add(this.button6_4);
            this.MainForm = main;
        }

        private void TopDownFlowLayoutPanel_Click(object sender, EventArgs e)
        {
            if (this.MainForm != null)
            {
                this.MainForm.ShowEditArea(this);
            }
            RaiseSelectChangedEvent(this);
        }

        private void TopDownFlowLayoutPanel_Enter(object sender, EventArgs e)
        {

        }

        private void TopDownFlowLayoutPanel_Leave(object sender, EventArgs e)
        {

        }

        private void TopDownFlowLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }
        public void ViewSelect(bool value)
        {
            if (value == true)
            {
                this.Selected = true;
            }
            else
            {
                this.Selected = false;
            }
        }

    }
}
