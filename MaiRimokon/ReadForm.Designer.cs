namespace MaiRimokon
{
    partial class ReadForm
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
            this.startStopButton = new System.Windows.Forms.Button();
            this.analysisButton = new System.Windows.Forms.Button();
            this.formatComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.framesTextBox = new System.Windows.Forms.TextBox();
            this.propSaveButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.messageLabel2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.repeatLowTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.leaderHighTextBox = new System.Windows.Forms.TextBox();
            this.leaderLowTextBox = new System.Windows.Forms.TextBox();
            this.pulse0HighTextBox = new System.Windows.Forms.TextBox();
            this.pulse0LowTextBox = new System.Windows.Forms.TextBox();
            this.pulse1HighTextBox = new System.Windows.Forms.TextBox();
            this.pulse1LowTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.stopHighTextBox = new System.Windows.Forms.TextBox();
            this.stopLowTextBox = new System.Windows.Forms.TextBox();
            this.repeatHighTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.frameIntervalTextBox = new System.Windows.Forms.TextBox();
            this.messageLabel1 = new System.Windows.Forms.Label();
            this.LEDLabel = new System.Windows.Forms.Label();
            this.pulseDataTextBox = new System.Windows.Forms.TextBox();
            this.pulseDrawPictureBox1 = new MaiRimokon.PulseDrawPictureBox();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pulseDrawPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // startStopButton
            // 
            this.startStopButton.Location = new System.Drawing.Point(12, 12);
            this.startStopButton.Name = "startStopButton";
            this.startStopButton.Size = new System.Drawing.Size(97, 23);
            this.startStopButton.TabIndex = 0;
            this.startStopButton.Text = "読み込み開始";
            this.startStopButton.UseVisualStyleBackColor = true;
            this.startStopButton.Click += new System.EventHandler(this.StartStopButton_Click);
            // 
            // analysisButton
            // 
            this.analysisButton.Location = new System.Drawing.Point(288, 10);
            this.analysisButton.Name = "analysisButton";
            this.analysisButton.Size = new System.Drawing.Size(75, 23);
            this.analysisButton.TabIndex = 2;
            this.analysisButton.Text = "解析";
            this.analysisButton.UseVisualStyleBackColor = true;
            this.analysisButton.Click += new System.EventHandler(this.AnalysisButton_Click);
            // 
            // formatComboBox
            // 
            this.formatComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.formatComboBox.FormattingEnabled = true;
            this.formatComboBox.Items.AddRange(new object[] {
            "NECフォーマット",
            "SONYフォーマット",
            "家電製品協会フォーマット",
            "ユニデンフォーマット",
            "その他"});
            this.formatComboBox.Location = new System.Drawing.Point(104, 12);
            this.formatComboBox.Name = "formatComboBox";
            this.formatComboBox.Size = new System.Drawing.Size(178, 20);
            this.formatComboBox.TabIndex = 1;
            this.formatComboBox.SelectedIndexChanged += new System.EventHandler(this.FormatComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "リモコンフォーマット";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.framesTextBox);
            this.panel1.Controls.Add(this.propSaveButton);
            this.panel1.Controls.Add(this.clearButton);
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Controls.Add(this.messageLabel2);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.formatComboBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.analysisButton);
            this.panel1.Location = new System.Drawing.Point(12, 159);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(396, 392);
            this.panel1.TabIndex = 4;
            // 
            // framesTextBox
            // 
            this.framesTextBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.framesTextBox.Location = new System.Drawing.Point(17, 268);
            this.framesTextBox.Multiline = true;
            this.framesTextBox.Name = "framesTextBox";
            this.framesTextBox.ReadOnly = true;
            this.framesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.framesTextBox.Size = new System.Drawing.Size(361, 87);
            this.framesTextBox.TabIndex = 17;
            // 
            // propSaveButton
            // 
            this.propSaveButton.Location = new System.Drawing.Point(345, 221);
            this.propSaveButton.Name = "propSaveButton";
            this.propSaveButton.Size = new System.Drawing.Size(48, 23);
            this.propSaveButton.TabIndex = 16;
            this.propSaveButton.Text = "保存";
            this.propSaveButton.UseVisualStyleBackColor = true;
            this.propSaveButton.Click += new System.EventHandler(this.PropSaveButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(288, 361);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 19;
            this.clearButton.Text = "クリア";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(193, 361);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 18;
            this.saveButton.Text = "閉じる";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // messageLabel2
            // 
            this.messageLabel2.AutoSize = true;
            this.messageLabel2.Location = new System.Drawing.Point(15, 253);
            this.messageLabel2.Name = "messageLabel2";
            this.messageLabel2.Size = new System.Drawing.Size(50, 12);
            this.messageLabel2.TabIndex = 6;
            this.messageLabel2.Text = "message";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.tableLayoutPanel1.Controls.Add(this.label10, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.repeatLowTextBox, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.leaderHighTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.leaderLowTextBox, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.pulse0HighTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.pulse0LowTextBox, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.pulse1HighTextBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.pulse1LowTextBox, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.stopHighTextBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.stopLowTextBox, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.repeatHighTextBox, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.frameIntervalTextBox, 1, 7);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 39);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(327, 202);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(134, 156);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 12);
            this.label10.TabIndex = 16;
            this.label10.Text = "μs";
            // 
            // repeatLowTextBox
            // 
            this.repeatLowTextBox.Location = new System.Drawing.Point(204, 128);
            this.repeatLowTextBox.MaxLength = 5;
            this.repeatLowTextBox.Name = "repeatLowTextBox";
            this.repeatLowTextBox.Size = new System.Drawing.Size(100, 19);
            this.repeatLowTextBox.TabIndex = 14;
            this.repeatLowTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 131);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "リピート信号";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "High(μs)";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(238, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "Low(μｓ)";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "リーダー信号";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "論理パルス0";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "論理パルス1";
            // 
            // leaderHighTextBox
            // 
            this.leaderHighTextBox.Location = new System.Drawing.Point(93, 28);
            this.leaderHighTextBox.MaxLength = 5;
            this.leaderHighTextBox.Name = "leaderHighTextBox";
            this.leaderHighTextBox.Size = new System.Drawing.Size(100, 19);
            this.leaderHighTextBox.TabIndex = 5;
            this.leaderHighTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // leaderLowTextBox
            // 
            this.leaderLowTextBox.Location = new System.Drawing.Point(204, 28);
            this.leaderLowTextBox.MaxLength = 5;
            this.leaderLowTextBox.Name = "leaderLowTextBox";
            this.leaderLowTextBox.Size = new System.Drawing.Size(100, 19);
            this.leaderLowTextBox.TabIndex = 6;
            this.leaderLowTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pulse0HighTextBox
            // 
            this.pulse0HighTextBox.Location = new System.Drawing.Point(93, 53);
            this.pulse0HighTextBox.MaxLength = 5;
            this.pulse0HighTextBox.Name = "pulse0HighTextBox";
            this.pulse0HighTextBox.Size = new System.Drawing.Size(100, 19);
            this.pulse0HighTextBox.TabIndex = 7;
            this.pulse0HighTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pulse0LowTextBox
            // 
            this.pulse0LowTextBox.Location = new System.Drawing.Point(204, 53);
            this.pulse0LowTextBox.MaxLength = 5;
            this.pulse0LowTextBox.Name = "pulse0LowTextBox";
            this.pulse0LowTextBox.Size = new System.Drawing.Size(100, 19);
            this.pulse0LowTextBox.TabIndex = 8;
            this.pulse0LowTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pulse1HighTextBox
            // 
            this.pulse1HighTextBox.Location = new System.Drawing.Point(93, 78);
            this.pulse1HighTextBox.MaxLength = 5;
            this.pulse1HighTextBox.Name = "pulse1HighTextBox";
            this.pulse1HighTextBox.Size = new System.Drawing.Size(100, 19);
            this.pulse1HighTextBox.TabIndex = 9;
            this.pulse1HighTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pulse1LowTextBox
            // 
            this.pulse1LowTextBox.Location = new System.Drawing.Point(204, 78);
            this.pulse1LowTextBox.MaxLength = 5;
            this.pulse1LowTextBox.Name = "pulse1LowTextBox";
            this.pulse1LowTextBox.Size = new System.Drawing.Size(100, 19);
            this.pulse1LowTextBox.TabIndex = 10;
            this.pulse1LowTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "ストップ信号";
            // 
            // stopHighTextBox
            // 
            this.stopHighTextBox.Location = new System.Drawing.Point(93, 103);
            this.stopHighTextBox.MaxLength = 5;
            this.stopHighTextBox.Name = "stopHighTextBox";
            this.stopHighTextBox.Size = new System.Drawing.Size(100, 19);
            this.stopHighTextBox.TabIndex = 11;
            this.stopHighTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // stopLowTextBox
            // 
            this.stopLowTextBox.Location = new System.Drawing.Point(204, 103);
            this.stopLowTextBox.MaxLength = 5;
            this.stopLowTextBox.Name = "stopLowTextBox";
            this.stopLowTextBox.Size = new System.Drawing.Size(100, 19);
            this.stopLowTextBox.TabIndex = 12;
            this.stopLowTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // repeatHighTextBox
            // 
            this.repeatHighTextBox.Location = new System.Drawing.Point(93, 128);
            this.repeatHighTextBox.MaxLength = 5;
            this.repeatHighTextBox.Name = "repeatHighTextBox";
            this.repeatHighTextBox.Size = new System.Drawing.Size(100, 19);
            this.repeatHighTextBox.TabIndex = 13;
            this.repeatHighTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 182);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 12);
            this.label9.TabIndex = 19;
            this.label9.Text = "フレーム間隔";
            // 
            // frameIntervalTextBox
            // 
            this.frameIntervalTextBox.Location = new System.Drawing.Point(93, 178);
            this.frameIntervalTextBox.MaxLength = 7;
            this.frameIntervalTextBox.Name = "frameIntervalTextBox";
            this.frameIntervalTextBox.Size = new System.Drawing.Size(100, 19);
            this.frameIntervalTextBox.TabIndex = 15;
            this.frameIntervalTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // messageLabel1
            // 
            this.messageLabel1.AutoSize = true;
            this.messageLabel1.Location = new System.Drawing.Point(167, 17);
            this.messageLabel1.Name = "messageLabel1";
            this.messageLabel1.Size = new System.Drawing.Size(50, 12);
            this.messageLabel1.TabIndex = 5;
            this.messageLabel1.Text = "message";
            // 
            // LEDLabel
            // 
            this.LEDLabel.AutoSize = true;
            this.LEDLabel.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LEDLabel.ForeColor = System.Drawing.Color.Red;
            this.LEDLabel.Location = new System.Drawing.Point(129, 17);
            this.LEDLabel.Name = "LEDLabel";
            this.LEDLabel.Size = new System.Drawing.Size(20, 13);
            this.LEDLabel.TabIndex = 7;
            this.LEDLabel.Text = "●";
            // 
            // pulseDataTextBox
            // 
            this.pulseDataTextBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.pulseDataTextBox.Location = new System.Drawing.Point(14, 98);
            this.pulseDataTextBox.Multiline = true;
            this.pulseDataTextBox.Name = "pulseDataTextBox";
            this.pulseDataTextBox.ReadOnly = true;
            this.pulseDataTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.pulseDataTextBox.Size = new System.Drawing.Size(394, 53);
            this.pulseDataTextBox.TabIndex = 8;
            // 
            // pulseDrawPictureBox1
            // 
            this.pulseDrawPictureBox1.BackColor = System.Drawing.Color.White;
            this.pulseDrawPictureBox1.Location = new System.Drawing.Point(12, 41);
            this.pulseDrawPictureBox1.Name = "pulseDrawPictureBox1";
            this.pulseDrawPictureBox1.Size = new System.Drawing.Size(396, 50);
            this.pulseDrawPictureBox1.TabIndex = 6;
            this.pulseDrawPictureBox1.TabStop = false;
            // 
            // ReadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 563);
            this.Controls.Add(this.pulseDataTextBox);
            this.Controls.Add(this.LEDLabel);
            this.Controls.Add(this.pulseDrawPictureBox1);
            this.Controls.Add(this.messageLabel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.startStopButton);
            this.Name = "ReadForm";
            this.Text = "リモコンデータ読み込み";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pulseDrawPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startStopButton;
        private System.Windows.Forms.Button analysisButton;
        private System.Windows.Forms.ComboBox formatComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox leaderHighTextBox;
        private System.Windows.Forms.TextBox leaderLowTextBox;
        private System.Windows.Forms.TextBox pulse0HighTextBox;
        private System.Windows.Forms.TextBox pulse0LowTextBox;
        private System.Windows.Forms.TextBox pulse1HighTextBox;
        private System.Windows.Forms.TextBox pulse1LowTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox stopLowTextBox;
        private System.Windows.Forms.TextBox stopHighTextBox;
        private System.Windows.Forms.Label messageLabel2;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label messageLabel1;
        private PulseDrawPictureBox pulseDrawPictureBox1;
        private System.Windows.Forms.Label LEDLabel;
        private System.Windows.Forms.TextBox pulseDataTextBox;
        private System.Windows.Forms.Button propSaveButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox repeatLowTextBox;
        private System.Windows.Forms.TextBox repeatHighTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox frameIntervalTextBox;
        private System.Windows.Forms.TextBox framesTextBox;
    }
}