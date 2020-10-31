namespace ModbusRTU_TP1608
{
    partial class F_TitlePage
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
            this.tB_DeviceName = new System.Windows.Forms.TextBox();
            this.uiLine5 = new Sunny.UI.UILine();
            this.uiLine6 = new Sunny.UI.UILine();
            this.onDelete = new System.Windows.Forms.PictureBox();
            this.onEdit = new System.Windows.Forms.PictureBox();
            this.BtnStop = new Sunny.UI.UIAvatar();
            this.BtnStart = new Sunny.UI.UIAvatar();
            this.ucChennal8 = new ModbusRTU_TP1608.UCChennal();
            this.ucChennal2 = new ModbusRTU_TP1608.UCChennal();
            this.ucChennal7 = new ModbusRTU_TP1608.UCChennal();
            this.ucChennal6 = new ModbusRTU_TP1608.UCChennal();
            this.ucChennal5 = new ModbusRTU_TP1608.UCChennal();
            this.ucChennal4 = new ModbusRTU_TP1608.UCChennal();
            this.ucChennal3 = new ModbusRTU_TP1608.UCChennal();
            this.ucChennal1 = new ModbusRTU_TP1608.UCChennal();
            this.ucChartLine1 = new ModbusRTU_TP1608.UCChartLine();
            ((System.ComponentModel.ISupportInitialize)(this.onDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.onEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // tB_DeviceName
            // 
            this.tB_DeviceName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.tB_DeviceName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tB_DeviceName.Enabled = false;
            this.tB_DeviceName.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_DeviceName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.tB_DeviceName.Location = new System.Drawing.Point(50, 20);
            this.tB_DeviceName.Margin = new System.Windows.Forms.Padding(2);
            this.tB_DeviceName.Name = "tB_DeviceName";
            this.tB_DeviceName.ReadOnly = true;
            this.tB_DeviceName.Size = new System.Drawing.Size(145, 32);
            this.tB_DeviceName.TabIndex = 0;
            this.tB_DeviceName.Text = "数据采集1";
            // 
            // uiLine5
            // 
            this.uiLine5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLine5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.uiLine5.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.uiLine5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine5.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.uiLine5.Location = new System.Drawing.Point(50, 49);
            this.uiLine5.MinimumSize = new System.Drawing.Size(2, 2);
            this.uiLine5.Name = "uiLine5";
            this.uiLine5.Size = new System.Drawing.Size(898, 29);
            this.uiLine5.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine5.TabIndex = 25;
            // 
            // uiLine6
            // 
            this.uiLine6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLine6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.uiLine6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.uiLine6.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine6.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.uiLine6.Location = new System.Drawing.Point(-1, -13);
            this.uiLine6.MinimumSize = new System.Drawing.Size(2, 2);
            this.uiLine6.Name = "uiLine6";
            this.uiLine6.Size = new System.Drawing.Size(1002, 29);
            this.uiLine6.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine6.TabIndex = 27;
            // 
            // onDelete
            // 
            this.onDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.onDelete.Image = global::ModbusRTU_TP1608.Properties.Resources.delete1;
            this.onDelete.Location = new System.Drawing.Point(917, 27);
            this.onDelete.Name = "onDelete";
            this.onDelete.Size = new System.Drawing.Size(25, 25);
            this.onDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.onDelete.TabIndex = 29;
            this.onDelete.TabStop = false;
            this.onDelete.Click += new System.EventHandler(this.onDelete_Click);
            // 
            // onEdit
            // 
            this.onEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.onEdit.Image = global::ModbusRTU_TP1608.Properties.Resources.update1;
            this.onEdit.Location = new System.Drawing.Point(877, 27);
            this.onEdit.Name = "onEdit";
            this.onEdit.Size = new System.Drawing.Size(25, 25);
            this.onEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.onEdit.TabIndex = 28;
            this.onEdit.TabStop = false;
            this.onEdit.Click += new System.EventHandler(this.onEdit_Click);
            // 
            // BtnStop
            // 
            this.BtnStop.AvatarSize = 0;
            this.BtnStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnStop.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.BtnStop.Icon = Sunny.UI.UIAvatar.UIIcon.Image;
            this.BtnStop.Image = global::ModbusRTU_TP1608.Properties.Resources.stop1;
            this.BtnStop.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BtnStop.Location = new System.Drawing.Point(828, 24);
            this.BtnStop.Margin = new System.Windows.Forms.Padding(2);
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(30, 30);
            this.BtnStop.Style = Sunny.UI.UIStyle.Custom;
            this.BtnStop.SymbolSize = 30;
            this.BtnStop.TabIndex = 6;
            this.BtnStop.Text = "stop";
            this.BtnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // BtnStart
            // 
            this.BtnStart.AvatarSize = 0;
            this.BtnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnStart.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.BtnStart.Icon = Sunny.UI.UIAvatar.UIIcon.Image;
            this.BtnStart.Image = global::ModbusRTU_TP1608.Properties.Resources.start2;
            this.BtnStart.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BtnStart.Location = new System.Drawing.Point(783, 24);
            this.BtnStart.Margin = new System.Windows.Forms.Padding(2);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(30, 30);
            this.BtnStart.Style = Sunny.UI.UIStyle.Custom;
            this.BtnStart.SymbolSize = 30;
            this.BtnStart.TabIndex = 5;
            this.BtnStart.Text = "start";
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // ucChennal8
            // 
            this.ucChennal8.Location = new System.Drawing.Point(742, 231);
            this.ucChennal8.Name = "ucChennal8";
            this.ucChennal8.Size = new System.Drawing.Size(200, 120);
            this.ucChennal8.TabIndex = 37;
            this.ucChennal8.ShowInfo += new System.EventHandler(this.ucChennal_ShowInfo_Click);
            // 
            // ucChennal2
            // 
            this.ucChennal2.Location = new System.Drawing.Point(283, 80);
            this.ucChennal2.Name = "ucChennal2";
            this.ucChennal2.Size = new System.Drawing.Size(200, 120);
            this.ucChennal2.TabIndex = 31;
            this.ucChennal2.ShowInfo += new System.EventHandler(this.ucChennal_ShowInfo_Click);
            // 
            // ucChennal7
            // 
            this.ucChennal7.Location = new System.Drawing.Point(517, 231);
            this.ucChennal7.Name = "ucChennal7";
            this.ucChennal7.Size = new System.Drawing.Size(200, 120);
            this.ucChennal7.TabIndex = 36;
            this.ucChennal7.ShowInfo += new System.EventHandler(this.ucChennal_ShowInfo_Click);
            // 
            // ucChennal6
            // 
            this.ucChennal6.Location = new System.Drawing.Point(283, 231);
            this.ucChennal6.Name = "ucChennal6";
            this.ucChennal6.Size = new System.Drawing.Size(200, 120);
            this.ucChennal6.TabIndex = 35;
            this.ucChennal6.ShowInfo += new System.EventHandler(this.ucChennal_ShowInfo_Click);
            // 
            // ucChennal5
            // 
            this.ucChennal5.Location = new System.Drawing.Point(50, 231);
            this.ucChennal5.Name = "ucChennal5";
            this.ucChennal5.Size = new System.Drawing.Size(200, 120);
            this.ucChennal5.TabIndex = 34;
            this.ucChennal5.ShowInfo += new System.EventHandler(this.ucChennal_ShowInfo_Click);
            // 
            // ucChennal4
            // 
            this.ucChennal4.Location = new System.Drawing.Point(742, 80);
            this.ucChennal4.Name = "ucChennal4";
            this.ucChennal4.Size = new System.Drawing.Size(200, 120);
            this.ucChennal4.TabIndex = 33;
            this.ucChennal4.ShowInfo += new System.EventHandler(this.ucChennal_ShowInfo_Click);
            // 
            // ucChennal3
            // 
            this.ucChennal3.Location = new System.Drawing.Point(517, 80);
            this.ucChennal3.Name = "ucChennal3";
            this.ucChennal3.Size = new System.Drawing.Size(200, 120);
            this.ucChennal3.TabIndex = 32;
            this.ucChennal3.ShowInfo += new System.EventHandler(this.ucChennal_ShowInfo_Click);
            // 
            // ucChennal1
            // 
            this.ucChennal1.Location = new System.Drawing.Point(50, 80);
            this.ucChennal1.Name = "ucChennal1";
            this.ucChennal1.Size = new System.Drawing.Size(200, 120);
            this.ucChennal1.TabIndex = 30;
            this.ucChennal1.ShowInfo += new System.EventHandler(this.ucChennal_ShowInfo_Click);
            // 
            // ucChartLine1
            // 
            this.ucChartLine1.BackColor = System.Drawing.Color.White;
            this.ucChartLine1.Location = new System.Drawing.Point(50, 366);
            this.ucChartLine1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ucChartLine1.Name = "ucChartLine1";
            this.ucChartLine1.Size = new System.Drawing.Size(892, 227);
            this.ucChartLine1.TabIndex = 38;
            // 
            // F_TitlePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(1000, 610);
            this.Controls.Add(this.ucChartLine1);
            this.Controls.Add(this.ucChennal8);
            this.Controls.Add(this.ucChennal2);
            this.Controls.Add(this.ucChennal7);
            this.Controls.Add(this.ucChennal6);
            this.Controls.Add(this.ucChennal5);
            this.Controls.Add(this.ucChennal4);
            this.Controls.Add(this.ucChennal3);
            this.Controls.Add(this.ucChennal1);
            this.Controls.Add(this.onDelete);
            this.Controls.Add(this.onEdit);
            this.Controls.Add(this.BtnStop);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.tB_DeviceName);
            this.Controls.Add(this.uiLine5);
            this.Controls.Add(this.uiLine6);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "F_TitlePage";
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "F_TitlePage";
            this.Load += new System.EventHandler(this.F_TitlePage_Load);
            this.SizeChanged += new System.EventHandler(this.F_TitlePage_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.onDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.onEdit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Sunny.UI.UIAvatar BtnStart;
        private Sunny.UI.UIAvatar BtnStop;
        private Sunny.UI.UILine uiLine5;
        private Sunny.UI.UILine uiLine6;
        public System.Windows.Forms.TextBox tB_DeviceName;
        private System.Windows.Forms.PictureBox onEdit;
        private System.Windows.Forms.PictureBox onDelete;
        public UCChennal ucChennal1;
        public UCChennal ucChennal2;
        public UCChennal ucChennal3;
        public UCChennal ucChennal4;
        public UCChennal ucChennal5;
        public UCChennal ucChennal6;
        public UCChennal ucChennal7;
        public UCChennal ucChennal8;
        private UCChartLine ucChartLine1;
    }
}