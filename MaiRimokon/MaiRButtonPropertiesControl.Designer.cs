namespace MaiRimokon
{
    partial class MaiRButtonPropertiesControl
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

        #region コンポーネント デザイナで生成されたコード

        /// <summary> 
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.colorComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.upperLabelTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.innerLabelTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.longPushComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.disableComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.frameReadButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.framesTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Type";
            // 
            // typeComboBox
            // 
            this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeComboBox.Enabled = false;
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Items.AddRange(new object[] {
            "Type1",
            "Type2",
            "Type3"});
            this.typeComboBox.Location = new System.Drawing.Point(82, 11);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(121, 20);
            this.typeComboBox.TabIndex = 1;
            this.typeComboBox.SelectedIndexChanged += new System.EventHandler(this.TypeComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Color";
            // 
            // colorComboBox
            // 
            this.colorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorComboBox.FormattingEnabled = true;
            this.colorComboBox.Items.AddRange(new object[] {
            "Default",
            "Blue",
            "Red",
            "Green",
            "Yellow"});
            this.colorComboBox.Location = new System.Drawing.Point(82, 39);
            this.colorComboBox.Name = "colorComboBox";
            this.colorComboBox.Size = new System.Drawing.Size(121, 20);
            this.colorComboBox.TabIndex = 3;
            this.colorComboBox.SelectedIndexChanged += new System.EventHandler(this.ColorComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "UpperLabel";
            // 
            // upperLabelTextBox
            // 
            this.upperLabelTextBox.Location = new System.Drawing.Point(82, 64);
            this.upperLabelTextBox.Name = "upperLabelTextBox";
            this.upperLabelTextBox.Size = new System.Drawing.Size(168, 19);
            this.upperLabelTextBox.TabIndex = 5;
            this.upperLabelTextBox.TextChanged += new System.EventHandler(this.UpperLabelTextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "InnerLabel";
            // 
            // innerLabelTextBox
            // 
            this.innerLabelTextBox.Location = new System.Drawing.Point(82, 90);
            this.innerLabelTextBox.Name = "innerLabelTextBox";
            this.innerLabelTextBox.Size = new System.Drawing.Size(168, 19);
            this.innerLabelTextBox.TabIndex = 7;
            this.innerLabelTextBox.TextChanged += new System.EventHandler(this.InnerLabelTextBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "LongPush";
            // 
            // longPushComboBox
            // 
            this.longPushComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.longPushComboBox.FormattingEnabled = true;
            this.longPushComboBox.Items.AddRange(new object[] {
            "False",
            "True"});
            this.longPushComboBox.Location = new System.Drawing.Point(82, 119);
            this.longPushComboBox.Name = "longPushComboBox";
            this.longPushComboBox.Size = new System.Drawing.Size(91, 20);
            this.longPushComboBox.TabIndex = 9;
            this.longPushComboBox.SelectedIndexChanged += new System.EventHandler(this.LongPushComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "Disable";
            // 
            // disableComboBox
            // 
            this.disableComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.disableComboBox.FormattingEnabled = true;
            this.disableComboBox.Items.AddRange(new object[] {
            "False",
            "True"});
            this.disableComboBox.Location = new System.Drawing.Point(82, 148);
            this.disableComboBox.Name = "disableComboBox";
            this.disableComboBox.Size = new System.Drawing.Size(91, 20);
            this.disableComboBox.TabIndex = 11;
            this.disableComboBox.SelectedIndexChanged += new System.EventHandler(this.DisableComboBox_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 178);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "Frame";
            // 
            // frameReadButton
            // 
            this.frameReadButton.Location = new System.Drawing.Point(84, 178);
            this.frameReadButton.Name = "frameReadButton";
            this.frameReadButton.Size = new System.Drawing.Size(48, 23);
            this.frameReadButton.TabIndex = 16;
            this.frameReadButton.Text = "読";
            this.frameReadButton.UseVisualStyleBackColor = true;
            this.frameReadButton.Click += new System.EventHandler(this.FrameReadButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(212, 178);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(45, 23);
            this.clearButton.TabIndex = 17;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // framesTextBox
            // 
            this.framesTextBox.Location = new System.Drawing.Point(16, 207);
            this.framesTextBox.Multiline = true;
            this.framesTextBox.Name = "framesTextBox";
            this.framesTextBox.ReadOnly = true;
            this.framesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.framesTextBox.Size = new System.Drawing.Size(234, 153);
            this.framesTextBox.TabIndex = 18;
            // 
            // MaiRButtonPropertiesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.framesTextBox);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.frameReadButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.disableComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.longPushComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.innerLabelTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.upperLabelTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.colorComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.typeComboBox);
            this.Controls.Add(this.label1);
            this.Name = "MaiRButtonPropertiesControl";
            this.Size = new System.Drawing.Size(260, 378);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox colorComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox upperLabelTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox innerLabelTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox longPushComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox disableComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button frameReadButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.TextBox framesTextBox;
    }
}
