namespace MaiRimokon
{
    partial class MaiRPanelPropertiesControl
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
            this.label2 = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.typeTextBox = new System.Windows.Forms.TextBox();
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Title";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(82, 39);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(168, 19);
            this.titleTextBox.TabIndex = 5;
            this.titleTextBox.TextChanged += new System.EventHandler(this.TitleTextBox_TextChanged);
            // 
            // typeTextBox
            // 
            this.typeTextBox.Location = new System.Drawing.Point(82, 11);
            this.typeTextBox.Name = "typeTextBox";
            this.typeTextBox.ReadOnly = true;
            this.typeTextBox.Size = new System.Drawing.Size(91, 19);
            this.typeTextBox.TabIndex = 14;
            // 
            // MaiRPanelPropertiesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.typeTextBox);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MaiRPanelPropertiesControl";
            this.Size = new System.Drawing.Size(260, 77);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.TextBox typeTextBox;
    }
}
