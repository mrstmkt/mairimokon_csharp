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
    public partial class MaiRPanelPropertiesControl : UserControl
    {
        private IMaiRPanel maiRPanel;
        private MainForm mainForm;
        public MaiRPanelPropertiesControl(IMaiRPanel maiRPanel, MainForm main)
        {
            InitializeComponent();
            this.maiRPanel = maiRPanel;
            this.mainForm = main;
            if (this.maiRPanel != null)
            {
                switch (this.maiRPanel.Type)
                {
                    case MaiRControlValue.PanelType.Type1:
                        this.typeTextBox.Text = "Type1";
                        break;
                    case MaiRControlValue.PanelType.Type2:
                        this.typeTextBox.Text = "Type2";
                        break;
                    case MaiRControlValue.PanelType.Type3:
                        this.typeTextBox.Text = "Type3";
                        break;
                    case MaiRControlValue.PanelType.Type4:
                        this.typeTextBox.Text = "Type4";
                        break;
                }
                this.titleTextBox.Text = this.maiRPanel.Title;
            }
        }

        private void TitleTextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.maiRPanel != null)
            {
                this.maiRPanel.Title = this.titleTextBox.Text;
            }
            if (this.mainForm != null)
            {
                this.mainForm.UpdateRimoconInfo();
            }
        }
    }
}
