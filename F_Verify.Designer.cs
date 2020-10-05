namespace ModbusRTU_TP1608
{
    partial class F_Verify
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
            this.msg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlBtm
            // 
            this.pnlBtm.Location = new System.Drawing.Point(1, 169);
            this.pnlBtm.Size = new System.Drawing.Size(398, 55);
            // 
            // msg
            // 
            this.msg.AutoSize = true;
            this.msg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.msg.Location = new System.Drawing.Point(1, 35);
            this.msg.Name = "msg";
            this.msg.Size = new System.Drawing.Size(154, 21);
            this.msg.TabIndex = 2;
            this.msg.Text = "确定要删除设备吗？";
            // 
            // F_Verify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 227);
            this.Controls.Add(this.msg);
            this.Name = "F_Verify";
            this.Text = "F_Verify";
            this.Controls.SetChildIndex(this.pnlBtm, 0);
            this.Controls.SetChildIndex(this.msg, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label msg;
    }
}