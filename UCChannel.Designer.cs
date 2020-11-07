namespace ModbusRTU_TP1608
{
    partial class UCChannel
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
            this.uiChannelTime = new Sunny.UI.UILabel();
            this.uiInfo = new System.Windows.Forms.PictureBox();
            this.uiChannelUnit = new Sunny.UI.UILabel();
            this.uiChannelData = new Sunny.UI.UILabel();
            this.uiChannelName = new Sunny.UI.UILabel();
            this.uiPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // uiPanel
            // 
            this.uiPanel.BackColor = System.Drawing.Color.White;
            this.uiPanel.Controls.Add(this.uiChannelTime);
            this.uiPanel.Controls.Add(this.uiInfo);
            this.uiPanel.Controls.Add(this.uiChannelUnit);
            this.uiPanel.Controls.Add(this.uiChannelData);
            this.uiPanel.Controls.Add(this.uiChannelName);
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
            this.uiPanel.Text = null;
            this.uiPanel.Click += new System.EventHandler(this.uiPanel_Click);
            // 
            // uiChannelTime
            // 
            this.uiChannelTime.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiChannelTime.Location = new System.Drawing.Point(16, 96);
            this.uiChannelTime.Margin = new System.Windows.Forms.Padding(0);
            this.uiChannelTime.Name = "uiChannelTime";
            this.uiChannelTime.Size = new System.Drawing.Size(130, 20);
            this.uiChannelTime.Style = Sunny.UI.UIStyle.Custom;
            this.uiChannelTime.TabIndex = 24;
            this.uiChannelTime.Text = "--:--:--.---";
            this.uiChannelTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiChannelTime.Click += new System.EventHandler(this.uiChannelTime_Click);
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
            // uiChannelUnit
            // 
            this.uiChannelUnit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiChannelUnit.Location = new System.Drawing.Point(16, 66);
            this.uiChannelUnit.Name = "uiChannelUnit";
            this.uiChannelUnit.Size = new System.Drawing.Size(130, 22);
            this.uiChannelUnit.Style = Sunny.UI.UIStyle.Custom;
            this.uiChannelUnit.TabIndex = 2;
            this.uiChannelUnit.Text = "--";
            this.uiChannelUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiChannelUnit.Click += new System.EventHandler(this.uiChannelUnit_Click);
            // 
            // uiChannelData
            // 
            this.uiChannelData.Font = new System.Drawing.Font("Times New Roman", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiChannelData.Location = new System.Drawing.Point(16, 22);
            this.uiChannelData.Margin = new System.Windows.Forms.Padding(0);
            this.uiChannelData.Name = "uiChannelData";
            this.uiChannelData.Size = new System.Drawing.Size(130, 44);
            this.uiChannelData.Style = Sunny.UI.UIStyle.Custom;
            this.uiChannelData.TabIndex = 1;
            this.uiChannelData.Text = "0.000";
            this.uiChannelData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiChannelData.Click += new System.EventHandler(this.uiChannelData_Click);
            // 
            // uiChannelName
            // 
            this.uiChannelName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiChannelName.Location = new System.Drawing.Point(16, 2);
            this.uiChannelName.Margin = new System.Windows.Forms.Padding(0);
            this.uiChannelName.Name = "uiChannelName";
            this.uiChannelName.Size = new System.Drawing.Size(156, 20);
            this.uiChannelName.Style = Sunny.UI.UIStyle.Custom;
            this.uiChannelName.TabIndex = 0;
            this.uiChannelName.Text = "数据采集1";
            this.uiChannelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiChannelName.Click += new System.EventHandler(this.uiChannelName_Click);
            // 
            // UCChannel
            // 
            this.Controls.Add(this.uiPanel);
            this.Name = "UCChannel";
            this.Size = new System.Drawing.Size(200, 120);
            this.uiPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIPanel uiPanel;
        private System.Windows.Forms.PictureBox uiInfo;
        public Sunny.UI.UILabel uiChannelName;
        public Sunny.UI.UILabel uiChannelData;
        public Sunny.UI.UILabel uiChannelUnit;
        public Sunny.UI.UILabel uiChannelTime;
    }
}
