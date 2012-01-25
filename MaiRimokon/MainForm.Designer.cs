namespace MaiRimokon
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SerialPortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dispFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.appTitlePanel = new System.Windows.Forms.Panel();
            this.appTitleLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.delButton = new System.Windows.Forms.Button();
            this.prevButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.pageLabel = new System.Windows.Forms.Label();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.dispFlowLayoutPanel.SuspendLayout();
            this.appTitlePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.SettingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(585, 26);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripMenuItem,
            this.SaveToolStripMenuItem,
            this.SaveAsToolStripMenuItem,
            this.CloseToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(68, 22);
            this.FileToolStripMenuItem.Text = "ファイル";
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.OpenToolStripMenuItem.Text = "開く";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.SaveToolStripMenuItem.Text = "保存";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // SaveAsToolStripMenuItem
            // 
            this.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
            this.SaveAsToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.SaveAsToolStripMenuItem.Text = "名前を付けて保存";
            this.SaveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // CloseToolStripMenuItem
            // 
            this.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem";
            this.CloseToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.CloseToolStripMenuItem.Text = "終了";
            this.CloseToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // SettingToolStripMenuItem
            // 
            this.SettingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SerialPortToolStripMenuItem});
            this.SettingToolStripMenuItem.Name = "SettingToolStripMenuItem";
            this.SettingToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.SettingToolStripMenuItem.Text = "設定";
            // 
            // SerialPortToolStripMenuItem
            // 
            this.SerialPortToolStripMenuItem.Name = "SerialPortToolStripMenuItem";
            this.SerialPortToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.SerialPortToolStripMenuItem.Text = "シリアルポート";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 123);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dispFlowLayoutPanel);
            this.splitContainer1.Size = new System.Drawing.Size(585, 450);
            this.splitContainer1.SplitterDistance = 245;
            this.splitContainer1.TabIndex = 2;
            // 
            // dispFlowLayoutPanel
            // 
            this.dispFlowLayoutPanel.Controls.Add(this.appTitlePanel);
            this.dispFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.dispFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.dispFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.dispFlowLayoutPanel.Name = "dispFlowLayoutPanel";
            this.dispFlowLayoutPanel.Size = new System.Drawing.Size(240, 450);
            this.dispFlowLayoutPanel.TabIndex = 0;
            this.dispFlowLayoutPanel.WrapContents = false;
            // 
            // appTitlePanel
            // 
            this.appTitlePanel.Controls.Add(this.appTitleLabel);
            this.appTitlePanel.Location = new System.Drawing.Point(0, 0);
            this.appTitlePanel.Margin = new System.Windows.Forms.Padding(0);
            this.appTitlePanel.Name = "appTitlePanel";
            this.appTitlePanel.Size = new System.Drawing.Size(238, 22);
            this.appTitlePanel.TabIndex = 0;
            // 
            // appTitleLabel
            // 
            this.appTitleLabel.AutoSize = true;
            this.appTitleLabel.Location = new System.Drawing.Point(3, 0);
            this.appTitleLabel.Name = "appTitleLabel";
            this.appTitleLabel.Size = new System.Drawing.Size(25, 12);
            this.appTitleLabel.TabIndex = 0;
            this.appTitleLabel.Text = "title";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Title";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(84, 33);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(290, 19);
            this.titleTextBox.TabIndex = 4;
            this.titleTextBox.TextChanged += new System.EventHandler(this.TitleTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Description";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(84, 64);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(290, 19);
            this.descriptionTextBox.TabIndex = 6;
            this.descriptionTextBox.TextChanged += new System.EventHandler(this.DescriptionTextBox_TextChanged);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(81, 97);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(50, 23);
            this.addButton.TabIndex = 8;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // delButton
            // 
            this.delButton.Location = new System.Drawing.Point(137, 97);
            this.delButton.Name = "delButton";
            this.delButton.Size = new System.Drawing.Size(50, 23);
            this.delButton.TabIndex = 9;
            this.delButton.Text = "Del";
            this.delButton.UseVisualStyleBackColor = true;
            this.delButton.Click += new System.EventHandler(this.delButton_Click);
            // 
            // prevButton
            // 
            this.prevButton.Location = new System.Drawing.Point(207, 97);
            this.prevButton.Name = "prevButton";
            this.prevButton.Size = new System.Drawing.Size(28, 23);
            this.prevButton.TabIndex = 10;
            this.prevButton.Text = "<";
            this.prevButton.UseVisualStyleBackColor = true;
            this.prevButton.Click += new System.EventHandler(this.PrevButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(239, 97);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(28, 23);
            this.nextButton.TabIndex = 11;
            this.nextButton.Text = ">";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // pageLabel
            // 
            this.pageLabel.AutoSize = true;
            this.pageLabel.Location = new System.Drawing.Point(273, 102);
            this.pageLabel.Name = "pageLabel";
            this.pageLabel.Size = new System.Drawing.Size(11, 12);
            this.pageLabel.TabIndex = 11;
            this.pageLabel.Text = "0";
            // 
            // typeComboBox
            // 
            this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Items.AddRange(new object[] {
            "Type1",
            "Type2",
            "Type3",
            "Type4"});
            this.typeComboBox.Location = new System.Drawing.Point(4, 99);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(71, 20);
            this.typeComboBox.TabIndex = 7;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "リモコンデータファイル|*.mrxml";
            this.openFileDialog1.Title = "開く";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog1_FileOk);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "mrxml";
            this.saveFileDialog1.Filter = "リモコンデータファイル|*.mrxml";
            this.saveFileDialog1.Title = "保存";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveFileDialog1_FileOk);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 574);
            this.Controls.Add(this.typeComboBox);
            this.Controls.Add(this.pageLabel);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.prevButton);
            this.Controls.Add(this.delButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "まいりもこん";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.dispFlowLayoutPanel.ResumeLayout(false);
            this.appTitlePanel.ResumeLayout(false);
            this.appTitlePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CloseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SerialPortToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel dispFlowLayoutPanel;
        private System.Windows.Forms.Panel appTitlePanel;
        private System.Windows.Forms.Label appTitleLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button delButton;
        private System.Windows.Forms.Button prevButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Label pageLabel;
        private System.Windows.Forms.ComboBox typeComboBox;
//        private MaiRPanel1View maiRPanel1View1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsToolStripMenuItem;
    }
}

