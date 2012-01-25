namespace MaiRimokon
{
    partial class MaiRButtonView
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
            this.upperlabel = new System.Windows.Forms.Label();
            this.button = new System.Windows.Forms.Button();
            this.rimokonDataLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // upperlabel
            // 
            this.upperlabel.AutoSize = true;
            this.upperlabel.BackColor = System.Drawing.Color.Transparent;
            this.upperlabel.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.upperlabel.Location = new System.Drawing.Point(5, 1);
            this.upperlabel.Name = "upperlabel";
            this.upperlabel.Size = new System.Drawing.Size(57, 12);
            this.upperlabel.TabIndex = 0;
            this.upperlabel.Text = "upperlabel";
            this.upperlabel.Click += new System.EventHandler(this.Upperlabel_Click);
            // 
            // button
            // 
            this.button.BackColor = System.Drawing.Color.White;
            this.button.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button.ForeColor = System.Drawing.Color.Black;
            this.button.Location = new System.Drawing.Point(0, 16);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(60, 42);
            this.button.TabIndex = 1;
            this.button.TabStop = false;
            this.button.Text = "button";
            this.button.UseVisualStyleBackColor = false;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // rimokonDataLabel
            // 
            this.rimokonDataLabel.AutoSize = true;
            this.rimokonDataLabel.BackColor = System.Drawing.Color.Transparent;
            this.rimokonDataLabel.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rimokonDataLabel.ForeColor = System.Drawing.Color.DarkOrange;
            this.rimokonDataLabel.Location = new System.Drawing.Point(47, 1);
            this.rimokonDataLabel.Name = "rimokonDataLabel";
            this.rimokonDataLabel.Size = new System.Drawing.Size(14, 12);
            this.rimokonDataLabel.TabIndex = 2;
            this.rimokonDataLabel.Text = "R";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rimokonDataLabel);
            this.panel1.Controls.Add(this.button);
            this.panel1.Controls.Add(this.upperlabel);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(62, 59);
            this.panel1.TabIndex = 3;
            this.panel1.Click += new System.EventHandler(this.MaiRButtonView_Click);
            // 
            // MaiRButtonView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "MaiRButtonView";
            this.Size = new System.Drawing.Size(62, 59);
            this.Click += new System.EventHandler(this.MaiRButtonView_Click);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label upperlabel;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.Label rimokonDataLabel;
        private System.Windows.Forms.Panel panel1;
    }
}
