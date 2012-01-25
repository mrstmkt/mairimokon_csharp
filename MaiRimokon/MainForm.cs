using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace MaiRimokon
{
    public partial class MainForm : Form
    {
        private bool changed;
        private String fileName;
        private MaiRimoconData data;
        private int selectedPanelIndex;
        public MainForm()
        {
            InitializeComponent();
            this.changed = false;
            this.fileName = "";
            string[] ports = SerialPort.GetPortNames();
            foreach(string port in ports)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(port);
                item.Click += new EventHandler(Item_Click);
                if (port.Equals(MaiRimokon.Properties.Settings.Default.ComPort))
                {
                    item.Checked = true;
                }
                this.SettingToolStripMenuItem.DropDownItems.Add(item);
            }

            this.selectedPanelIndex = -1;
            this.data = new MaiRimoconData();
            Init();
            UpdateFormTitle();
        }

        void Item_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                ToolStripMenuItem item = (ToolStripMenuItem)sender;
                item.Checked = true;
                MaiRimokon.Properties.Settings.Default.ComPort = item.Text;
                MaiRimokon.Properties.Settings.Default.Save();
            }
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReadButton_Click(object sender, EventArgs e)
        {
            ReadForm f = new ReadForm();
            f.ShowDialog();
            f.Dispose();
        }

        public void ShowEditArea(object control)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            if (control is IMaiRButton)
            {
                this.splitContainer1.Panel2.Controls.Add(new MaiRButtonPropertiesControl((IMaiRButton)control));
            }
            else if (control is IMaiRPanel)
            {
                this.splitContainer1.Panel2.Controls.Add(new MaiRPanelPropertiesControl((IMaiRPanel)control, this));
            }
        }

        private void Init()
        {
            this.titleTextBox.Text = "";
            this.descriptionTextBox.Text = "";
            this.typeComboBox.SelectedIndex = 0;
            this.appTitleLabel.Text = "";
            if (this.dispFlowLayoutPanel.Controls.Count == 2)
            {
                this.dispFlowLayoutPanel.Controls.RemoveAt(1);
            }
            this.splitContainer1.Panel2.Controls.Clear();

            UpdateRimoconInfo();
            UpdateDelButton();
            UpdatePaging();

        }
        public void UpdateRimoconInfo()
        {
            if (this.data != null)
            {
                this.titleTextBox.Text = this.data.Title;
                this.descriptionTextBox.Text = this.data.Description;
                if (selectedPanelIndex < 0)
                {
                    this.appTitleLabel.Text = this.data.Title;
                }
                else
                {
                    if (selectedPanelIndex < this.data.PanelItems.Count)
                    {
                        this.appTitleLabel.Text = this.data.Title + " " + this.data.PanelItems[selectedPanelIndex].Title;
                    }
                    else
                    {
                        this.appTitleLabel.Text = this.data.Title;
                    }
                }
            }
            else
            {
                this.titleTextBox.Text = "";
                this.descriptionTextBox.Text = "";
                this.appTitleLabel.Text = "";
            }
        }

        private void UpdateDelButton()
        {
            if (this.selectedPanelIndex < 0)
            {
                this.delButton.Enabled = false;
            }
            else if (this.selectedPanelIndex < this.data.PanelItems.Count)
            {
                this.delButton.Enabled = true;
            }
            else
            {
                this.delButton.Enabled = false;
            }
        }

        private void UpdatePaging()
        {
            if (this.selectedPanelIndex < 0)
            {
                this.prevButton.Enabled = false;
                this.nextButton.Enabled = false;
            }
            else if (this.selectedPanelIndex < this.data.PanelItems.Count)
            {
                if (this.selectedPanelIndex == 0)
                {
                    this.prevButton.Enabled = false;
                    if (this.data.PanelItems.Count >= 2)
                    {
                        this.nextButton.Enabled = true;
                    }
                    else
                    {
                        this.nextButton.Enabled = false;
                    }
                }
                else if (this.selectedPanelIndex == this.data.PanelItems.Count - 1)
                {
                    this.prevButton.Enabled = true;
                    this.nextButton.Enabled = false;
                }
                else
                {
                    this.prevButton.Enabled = true;
                    this.nextButton.Enabled = true;
                }
            }
            else
            {
                this.prevButton.Enabled = false;
                this.nextButton.Enabled = false;
            }
            if (this.data.PanelItems.Count == 0)
            {
                this.pageLabel.Text = "0";
            }
            else
            {
                this.pageLabel.Text = (this.selectedPanelIndex + 1) + "/" + this.data.PanelItems.Count;
            }
        }

        private void TitleTextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.data != null)
            {
                this.data.Title = this.titleTextBox.Text;
            }
            UpdateRimoconInfo();
            this.changed = true;
            UpdateFormTitle();
        }

        private void DescriptionTextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.data != null)
            {
                this.data.Description = this.descriptionTextBox.Text;
            }
            UpdateRimoconInfo();
            this.changed = true;
            UpdateFormTitle();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (this.data != null)
            {
                switch (this.typeComboBox.SelectedIndex)
                {
                    case 0:
                        MaiRPanel1View panel1View = new MaiRPanel1View(this);
                        panel1View.ValueChanged += new MaiRControlValue.ValueChangedHandler(View_ValueChanged);
                        this.data.PanelItems.Add((IMaiRPanel)panel1View);
                        break;
                    case 1:
                        MaiRPanel2View panel2View = new MaiRPanel2View(this);
                        panel2View.ValueChanged += new MaiRControlValue.ValueChangedHandler(View_ValueChanged);
                        this.data.PanelItems.Add((IMaiRPanel)panel2View);
                        break;
                    case 2:
                        MaiRPanel3View panel3View = new MaiRPanel3View(this);
                        panel3View.ValueChanged += new MaiRControlValue.ValueChangedHandler(View_ValueChanged);
                        this.data.PanelItems.Add((IMaiRPanel)panel3View);
                        break;
                    case 3:
                        MaiRPanel4View panel4View = new MaiRPanel4View(this);
                        panel4View.ValueChanged += new MaiRControlValue.ValueChangedHandler(View_ValueChanged);
                        this.data.PanelItems.Add((IMaiRPanel)panel4View);
                        break;
                }
                ShowMaiRPanel(this.data.PanelItems.Count - 1);
                this.changed = true;
                UpdateFormTitle();
            }
        }

        void View_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            this.changed = true;
            UpdateFormTitle();
        }
        private void UpdateFormTitle()
        {
            if (fileName.Length > 0)
            {
                if (this.changed == true)
                {
                    this.Text = "まいりもこん *" + fileName;
                }
                else
                {
                    this.Text = "まいりもこん " + fileName;
                }
            }
            else
            {
                if (this.changed == true)
                {
                    this.Text = "まいりもこん *";
                }
                else
                {
                    this.Text = "まいりもこん ";
                }
            }
        }

        private void ShowMaiRPanel(int index)
        {
            if (this.dispFlowLayoutPanel.Controls.Count == 2)
            {
                this.dispFlowLayoutPanel.Controls.RemoveAt(1);
            }
            this.dispFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            if (this.data != null)
            {
                if (index < 0)
                {
                    this.selectedPanelIndex = -1;
                }
                else if (index >= this.data.PanelItems.Count)
                {
                    this.selectedPanelIndex = -1;
                }
                else
                {
                    switch (this.data.PanelItems[index].Type)
                    {
                        case MaiRControlValue.PanelType.Type1:
                            this.dispFlowLayoutPanel.Controls.Add((MaiRPanel1View)this.data.PanelItems[index]);
                            break;
                        case MaiRControlValue.PanelType.Type2:
                            this.dispFlowLayoutPanel.Controls.Add((MaiRPanel2View)this.data.PanelItems[index]);
                            break;
                        case MaiRControlValue.PanelType.Type3:
                            this.dispFlowLayoutPanel.Controls.Add((MaiRPanel3View)this.data.PanelItems[index]);
                            break;
                        case MaiRControlValue.PanelType.Type4:
                            this.dispFlowLayoutPanel.Controls.Add((MaiRPanel4View)this.data.PanelItems[index]);
                            break;
                    }
                    this.data.PanelItems[index].SelectChanged += new MaiRControlValue.SelectChangedHandler(Select_Changed);
                    this.selectedPanelIndex = index;
                }
            }
            else
            {
                this.selectedPanelIndex = -1;
            }
            UpdateRimoconInfo();
            UpdateDelButton();
            UpdatePaging();
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            if(this.data != null)
            {
                if (this.selectedPanelIndex >= 0)
                {
                    if (this.selectedPanelIndex == 0)
                    {
                        if (this.data.PanelItems.Count >= 2)
                        {
                            this.data.PanelItems.RemoveAt(this.selectedPanelIndex);
                            this.selectedPanelIndex = 0;
                        }
                        else
                        {
                            this.data.PanelItems.RemoveAt(this.selectedPanelIndex);
                            this.selectedPanelIndex = -1;
                        }
                        ShowMaiRPanel(this.selectedPanelIndex);
                    }
                    else if (this.selectedPanelIndex < this.data.PanelItems.Count)
                    {
                        this.data.PanelItems.RemoveAt(this.selectedPanelIndex);
                        this.selectedPanelIndex--;
                        ShowMaiRPanel(this.selectedPanelIndex);
                    }
                    this.changed = true;
                    UpdateFormTitle();
                }
            }
            UpdateRimoconInfo();
            UpdateDelButton();
            UpdatePaging();
        }

        private void PrevButton_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            this.selectedPanelIndex--;
            ShowMaiRPanel(this.selectedPanelIndex);
            UpdateRimoconInfo();
            UpdateDelButton();
            UpdatePaging();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            this.selectedPanelIndex++;
            ShowMaiRPanel(this.selectedPanelIndex);
            UpdateRimoconInfo();
            UpdateDelButton();
            UpdatePaging();
        }

        private void Select_Changed(object sender)
        {
            if (sender is IMaiRPanel)
            {
                IMaiRPanel panel = (IMaiRPanel)sender;
                foreach (IMaiRButton button in panel.ButtonItems)
                {
                    button.ViewSelect(false);
                }
                panel.ViewSelect(true);
            }
            else if (sender is IMaiRButton)
            {
                if (this.selectedPanelIndex >= 0 && this.selectedPanelIndex < this.data.PanelItems.Count)
                {
                    IMaiRPanel panel = this.data.PanelItems[this.selectedPanelIndex];
                    panel.ViewSelect(false);
                    foreach (IMaiRButton button in panel.ButtonItems)
                    {
                        if (!button.Equals(sender))
                        {
                            button.ViewSelect(false);
                        }
                        else
                        {
                            button.ViewSelect(true);
                        }
                    }
                }
            }
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.changed == true)
            {
                DialogResult ret = MessageBox.Show("編集中のデータを保存しますか？","確認",MessageBoxButtons.YesNo);
                if (ret == DialogResult.Yes)
                {
                    SaveToolStripMenuItem_Click(sender, e);
                }
            }
            this.openFileDialog1.ShowDialog();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.fileName.Length > 0)
            {
                XmlConvert xmlCovert = new XmlConvert(this.data);
                if (xmlCovert.Valid == true)
                {
                    if (xmlCovert.SaveXml(this.fileName))
                    {
                        this.changed = false;
                        UpdateFormTitle();
                    }
                }
            }
            else
            {
                SaveAsToolStripMenuItem_Click(sender, e);
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.saveFileDialog1.ShowDialog();
        }

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string openFilename = this.openFileDialog1.FileName;
            XmlConvert xmlConvert = new XmlConvert(openFilename);
            if (xmlConvert.Valid == true)
            {
                if (this.dispFlowLayoutPanel.Controls.Count == 2)
                {
                    this.dispFlowLayoutPanel.Controls.RemoveAt(1);
                }
                this.splitContainer1.Panel2.Controls.Clear();

                this.data = xmlConvert.ConvertXmlToData(this, View_ValueChanged);
                this.titleTextBox.Text = this.data.Title;
                this.descriptionTextBox.Text = this.data.Description;
                if (this.data.PanelItems.Count > 0)
                {
                    this.selectedPanelIndex = 0;
                    ShowMaiRPanel(0);
                }
                else
                {
                    this.selectedPanelIndex = -1;
                }
                this.fileName = openFilename;
                this.changed = false;
                UpdateFormTitle();
            }
        }

        private void SaveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            this.fileName = this.saveFileDialog1.FileName;
            SaveToolStripMenuItem_Click(sender, null);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.changed == true)
            {
                DialogResult ret = MessageBox.Show("編集中のデータを保存しますか？", "確認", MessageBoxButtons.YesNo);
                if (ret == DialogResult.Yes)
                {
                    SaveToolStripMenuItem_Click(sender, e);
                }
            }
        }
    }
}
