namespace ModbusRTU_TP1608
{
    partial class F_SelectProtocol
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
            this.RTU = new Sunny.UI.UIRadioButton();
            this.TCP = new Sunny.UI.UIRadioButton();
            this.SuspendLayout();
            // 
            // pnlBtm
            // 
            this.pnlBtm.Location = new System.Drawing.Point(1, 99);
            this.pnlBtm.Size = new System.Drawing.Size(325, 55);
            // 
            // RTU
            // 
            this.RTU.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RTU.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.RTU.Location = new System.Drawing.Point(20, 50);
            this.RTU.Name = "RTU";
            this.RTU.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.RTU.Size = new System.Drawing.Size(150, 29);
            this.RTU.TabIndex = 2;
            this.RTU.Text = "Modbus RTU";
            // 
            // TCP
            // 
            this.TCP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TCP.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TCP.Location = new System.Drawing.Point(176, 50);
            this.TCP.Name = "TCP";
            this.TCP.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.TCP.Size = new System.Drawing.Size(150, 29);
            this.TCP.TabIndex = 3;
            this.TCP.Text = "Modbus TCP";
            // 
            // F_SelectProtocol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 157);
            this.Controls.Add(this.TCP);
            this.Controls.Add(this.RTU);
            this.Name = "F_SelectProtocol";
            this.Text = "通信协议";
            this.Load += new System.EventHandler(this.F_SelectProtocol_Load);
            this.Controls.SetChildIndex(this.pnlBtm, 0);
            this.Controls.SetChildIndex(this.RTU, 0);
            this.Controls.SetChildIndex(this.TCP, 0);
            this.ResumeLayout(false);

        }

        #endregion

        public Sunny.UI.UIRadioButton RTU;
        public Sunny.UI.UIRadioButton TCP;
    }
}