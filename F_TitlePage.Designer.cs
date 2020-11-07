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
            this.ucChartLine1 = new ModbusRTU_TP1608.UCChartLine();
            this.ucChannel8 = new ModbusRTU_TP1608.UCChannel();
            this.ucChannel2 = new ModbusRTU_TP1608.UCChannel();
            this.ucChannel7 = new ModbusRTU_TP1608.UCChannel();
            this.ucChannel6 = new ModbusRTU_TP1608.UCChannel();
            this.ucChannel5 = new ModbusRTU_TP1608.UCChannel();
            this.ucChannel4 = new ModbusRTU_TP1608.UCChannel();
            this.ucChannel3 = new ModbusRTU_TP1608.UCChannel();
            this.ucChannel1 = new ModbusRTU_TP1608.UCChannel();
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
            // ucChartLine1
            // 
            this.ucChartLine1.BackColor = System.Drawing.Color.White;
            this.ucChartLine1.Location = new System.Drawing.Point(50, 366);
            this.ucChartLine1.Margin = new System.Windows.Forms.Padding(0);
            this.ucChartLine1.Name = "ucChartLine1";
            this.ucChartLine1.Size = new System.Drawing.Size(892, 227);
            this.ucChartLine1.TabIndex = 38;
            // 
            // ucChannel8
            // 
            this.ucChannel8.Location = new System.Drawing.Point(742, 231);
            this.ucChannel8.Name = "ucChannel8";
            this.ucChannel8.Size = new System.Drawing.Size(200, 120);
            this.ucChannel8.TabIndex = 37;
            this.ucChannel8.ShowInfo += new System.EventHandler(this.ucChannel_ShowInfo_Click);
            this.ucChannel8.ControlClick += new System.EventHandler(this.ucChannel_ControlClick);
            // 
            // ucChannel2
            // 
            this.ucChannel2.Location = new System.Drawing.Point(283, 80);
            this.ucChannel2.Name = "ucChannel2";
            this.ucChannel2.Size = new System.Drawing.Size(200, 120);
            this.ucChannel2.TabIndex = 31;
            this.ucChannel2.ShowInfo += new System.EventHandler(this.ucChannel_ShowInfo_Click);
            this.ucChannel2.ControlClick += new System.EventHandler(this.ucChannel_ControlClick);
            // 
            // ucChannel7
            // 
            this.ucChannel7.Location = new System.Drawing.Point(517, 231);
            this.ucChannel7.Name = "ucChannel7";
            this.ucChannel7.Size = new System.Drawing.Size(200, 120);
            this.ucChannel7.TabIndex = 36;
            this.ucChannel7.ShowInfo += new System.EventHandler(this.ucChannel_ShowInfo_Click);
            this.ucChannel7.ControlClick += new System.EventHandler(this.ucChannel_ControlClick);
            // 
            // ucChannel6
            // 
            this.ucChannel6.Location = new System.Drawing.Point(283, 231);
            this.ucChannel6.Name = "ucChannel6";
            this.ucChannel6.Size = new System.Drawing.Size(200, 120);
            this.ucChannel6.TabIndex = 35;
            this.ucChannel6.ShowInfo += new System.EventHandler(this.ucChannel_ShowInfo_Click);
            this.ucChannel6.ControlClick += new System.EventHandler(this.ucChannel_ControlClick);
            // 
            // ucChannel5
            // 
            this.ucChannel5.Location = new System.Drawing.Point(50, 231);
            this.ucChannel5.Name = "ucChannel5";
            this.ucChannel5.Size = new System.Drawing.Size(200, 120);
            this.ucChannel5.TabIndex = 34;
            this.ucChannel5.ShowInfo += new System.EventHandler(this.ucChannel_ShowInfo_Click);
            this.ucChannel5.ControlClick += new System.EventHandler(this.ucChannel_ControlClick);
            // 
            // ucChannel4
            // 
            this.ucChannel4.Location = new System.Drawing.Point(742, 80);
            this.ucChannel4.Name = "ucChannel4";
            this.ucChannel4.Size = new System.Drawing.Size(200, 120);
            this.ucChannel4.TabIndex = 33;
            this.ucChannel4.ShowInfo += new System.EventHandler(this.ucChannel_ShowInfo_Click);
            this.ucChannel4.ControlClick += new System.EventHandler(this.ucChannel_ControlClick);
            // 
            // ucChannel3
            // 
            this.ucChannel3.Location = new System.Drawing.Point(517, 80);
            this.ucChannel3.Name = "ucChannel3";
            this.ucChannel3.Size = new System.Drawing.Size(200, 120);
            this.ucChannel3.TabIndex = 32;
            this.ucChannel3.ShowInfo += new System.EventHandler(this.ucChannel_ShowInfo_Click);
            this.ucChannel3.ControlClick += new System.EventHandler(this.ucChannel_ControlClick);
            // 
            // ucChannel1
            // 
            this.ucChannel1.Location = new System.Drawing.Point(50, 80);
            this.ucChannel1.Name = "ucChannel1";
            this.ucChannel1.Size = new System.Drawing.Size(200, 120);
            this.ucChannel1.TabIndex = 30;
            this.ucChannel1.ShowInfo += new System.EventHandler(this.ucChannel_ShowInfo_Click);
            this.ucChannel1.ControlClick += new System.EventHandler(this.ucChannel_ControlClick);
            // 
            // F_TitlePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(1000, 610);
            this.Controls.Add(this.ucChartLine1);
            this.Controls.Add(this.ucChannel8);
            this.Controls.Add(this.ucChannel2);
            this.Controls.Add(this.ucChannel7);
            this.Controls.Add(this.ucChannel6);
            this.Controls.Add(this.ucChannel5);
            this.Controls.Add(this.ucChannel4);
            this.Controls.Add(this.ucChannel3);
            this.Controls.Add(this.ucChannel1);
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
        public UCChannel ucChannel1;
        public UCChannel ucChannel2;
        public UCChannel ucChannel3;
        public UCChannel ucChannel4;
        public UCChannel ucChannel5;
        public UCChannel ucChannel6;
        public UCChannel ucChannel7;
        public UCChannel ucChannel8;
        public UCChartLine ucChartLine1;
    }
}