namespace updater_script_builder
{
    partial class Update
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.updateBox = new System.Windows.Forms.TextBox();
            this.checkUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // updateBox
            // 
            this.updateBox.AcceptsTab = true;
            this.updateBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.updateBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.updateBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.updateBox.Location = new System.Drawing.Point(12, 12);
            this.updateBox.Multiline = true;
            this.updateBox.Name = "updateBox";
            this.updateBox.ReadOnly = true;
            this.updateBox.Size = new System.Drawing.Size(256, 292);
            this.updateBox.TabIndex = 3;
            this.updateBox.Text = "[当前版本]\r\nVersion:\r\n\r\n[最新版本]\r\n未知\r\n\r\n[更新日志]\r\n未知";
            // 
            // checkUpdate
            // 
            this.checkUpdate.Location = new System.Drawing.Point(12, 310);
            this.checkUpdate.Name = "checkUpdate";
            this.checkUpdate.Size = new System.Drawing.Size(75, 23);
            this.checkUpdate.TabIndex = 4;
            this.checkUpdate.Text = "检查更新";
            this.checkUpdate.UseVisualStyleBackColor = true;
            this.checkUpdate.Click += new System.EventHandler(this.checkUpdate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(143, 315);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "DroidBetaDevTeam 2018";
            // 
            // Update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 343);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkUpdate);
            this.Controls.Add(this.updateBox);
            this.Name = "Update";
            this.Text = "更新检查";
            this.Load += new System.EventHandler(this.Update_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox updateBox;
        private System.Windows.Forms.Button checkUpdate;
        private System.Windows.Forms.Label label1;
    }
}