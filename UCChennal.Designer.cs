namespace ModbusRTU_TP1608
{
    partial class UCChennal
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.uiPanel = new Sunny.UI.UIPanel();
            this.uiChennalName = new Sunny.UI.UILabel();
            this.uiChennalData = new Sunny.UI.UILabel();
            this.uiChennalUnit = new Sunny.UI.UILabel();
            this.uiLine2 = new Sunny.UI.UILine();
            this.uiChennalTime = new Sunny.UI.UILabel();
            this.uiInfo = new System.Windows.Forms.PictureBox();
            this.uiPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // uiPanel
            // 
            this.uiPanel.BackColor = System.Drawing.Color.White;
            this.uiPanel.Controls.Add(this.uiChennalTime);
            this.uiPanel.Controls.Add(this.uiInfo);
            this.uiPanel.Controls.Add(this.uiChennalUnit);
            this.uiPanel.Controls.Add(this.uiChennalData);
            this.uiPanel.Controls.Add(this.uiChennalName);
            this.uiPanel.Controls.Add(this.uiLine2);
            this.uiPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPanel.FillColor = System.Drawing.Color.White;
            this.uiPanel.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiPanel.Location = new System.Drawing.Point(0, 0);
            this.uiPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel.Name = "uiPanel";
            this.uiPanel.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.uiPanel.Size = new System.Drawing.Size(200, 120);
            this.uiPanel.Style = Sunny.UI.UIStyle.Custom;
            this.uiPanel.TabIndex = 0;
            // 
            // uiChennalName
            // 
            this.uiChennalName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiChennalName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.uiChennalName.Location = new System.Drawing.Point(16, 2);
            this.uiChennalName.Margin = new System.Windows.Forms.Padding(0);
            this.uiChennalName.Name = "uiChennalName";
            this.uiChennalName.Size = new System.Drawing.Size(130, 20);
            this.uiChennalName.Style = Sunny.UI.UIStyle.Custom;
            this.uiChennalName.TabIndex = 0;
            this.uiChennalName.Text = "数据采集1";
            this.uiChennalName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiChennalData
            // 
            this.uiChennalData.Font = new System.Drawing.Font("Times New Roman", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiChennalData.ForeColor = System.Drawing.SystemColors.WindowText;
            this.uiChennalData.Location = new System.Drawing.Point(16, 22);
            this.uiChennalData.Margin = new System.Windows.Forms.Padding(0);
            this.uiChennalData.Name = "uiChennalData";
            this.uiChennalData.Size = new System.Drawing.Size(130, 44);
            this.uiChennalData.Style = Sunny.UI.UIStyle.Custom;
            this.uiChennalData.TabIndex = 1;
            this.uiChennalData.Text = "2.000";
            this.uiChennalData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiChennalUnit
            // 
            this.uiChennalUnit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiChennalUnit.ForeColor = System.Drawing.SystemColors.WindowText;
            this.uiChennalUnit.Location = new System.Drawing.Point(16, 66);
            this.uiChennalUnit.Name = "uiChennalUnit";
            this.uiChennalUnit.Size = new System.Drawing.Size(130, 22);
            this.uiChennalUnit.Style = Sunny.UI.UIStyle.Custom;
            this.uiChennalUnit.TabIndex = 2;
            this.uiChennalUnit.Text = "℃";
            this.uiChennalUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLine2
            // 
            this.uiLine2.BackColor = System.Drawing.Color.White;
            this.uiLine2.FillColor = System.Drawing.Color.White;
            this.uiLine2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.uiLine2.Location = new System.Drawing.Point(14, 78);
            this.uiLine2.MinimumSize = new System.Drawing.Size(2, 2);
            this.uiLine2.Name = "uiLine2";
            this.uiLine2.Size = new System.Drawing.Size(172, 29);
            this.uiLine2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine2.TabIndex = 21;
            // 
            // uiChennalTime
            // 
            this.uiChennalTime.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiChennalTime.ForeColor = System.Drawing.SystemColors.WindowText;
            this.uiChennalTime.Location = new System.Drawing.Point(16, 96);
            this.uiChennalTime.Margin = new System.Windows.Forms.Padding(0);
            this.uiChennalTime.Name = "uiChennalTime";
            this.uiChennalTime.Size = new System.Drawing.Size(130, 20);
            this.uiChennalTime.Style = Sunny.UI.UIStyle.Custom;
            this.uiChennalTime.TabIndex = 24;
            this.uiChennalTime.Text = "11:21:55.328";
            this.uiChennalTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiInfo
            // 
            this.uiInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiInfo.Image = global::ModbusRTU_TP1608.Properties.Resources.info4;
            this.uiInfo.Location = new System.Drawing.Point(175, 3);
            this.uiInfo.Name = "uiInfo";
            this.uiInfo.Size = new System.Drawing.Size(20, 20);
            this.uiInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.uiInfo.TabIndex = 23;
            this.uiInfo.TabStop = false;
            this.uiInfo.Click += new System.EventHandler(this.uiInfo_Click);
            // 
            // UCChennal
            // 
            this.Controls.Add(this.uiPanel);
            this.Name = "UCChennal";
            this.Size = new System.Drawing.Size(200, 120);
            this.uiPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIPanel uiPanel;
        private Sunny.UI.UILine uiLine2;
        private System.Windows.Forms.PictureBox uiInfo;
        public Sunny.UI.UILabel uiChennalName;
        public Sunny.UI.UILabel uiChennalData;
        public Sunny.UI.UILabel uiChennalUnit;
        public Sunny.UI.UILabel uiChennalTime;
    }
}
