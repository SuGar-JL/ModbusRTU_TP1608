namespace ModbusRTU_TP1608
{
    partial class F_AddDevice
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
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiTB_deviceAddress = new Sunny.UI.UITextBox();
            this.uiCB_deviceType = new Sunny.UI.UIComboBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiTB_deviceName = new Sunny.UI.UITextBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.uiCB_chennalNum = new Sunny.UI.UIComboBox();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.uiCB_startChennal = new Sunny.UI.UIComboBox();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.uiTB_installAddress = new Sunny.UI.UITextBox();
            this.SuspendLayout();
            // 
            // pnlBtm
            // 
            this.pnlBtm.Location = new System.Drawing.Point(1, 318);
            this.pnlBtm.Size = new System.Drawing.Size(397, 55);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(23, 143);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(100, 23);
            this.uiLabel1.TabIndex = 12;
            this.uiLabel1.Text = "设备地址：";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiTB_deviceAddress
            // 
            this.uiTB_deviceAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTB_deviceAddress.FillColor = System.Drawing.Color.White;
            this.uiTB_deviceAddress.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiTB_deviceAddress.Location = new System.Drawing.Point(125, 141);
            this.uiTB_deviceAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTB_deviceAddress.Maximum = 2147483647D;
            this.uiTB_deviceAddress.Minimum = -2147483648D;
            this.uiTB_deviceAddress.Name = "uiTB_deviceAddress";
            this.uiTB_deviceAddress.Padding = new System.Windows.Forms.Padding(5);
            this.uiTB_deviceAddress.Size = new System.Drawing.Size(246, 29);
            this.uiTB_deviceAddress.TabIndex = 13;
            // 
            // uiCB_deviceType
            // 
            this.uiCB_deviceType.FillColor = System.Drawing.Color.White;
            this.uiCB_deviceType.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiCB_deviceType.Items.AddRange(new object[] {
            "TP1608P-AI-A"});
            this.uiCB_deviceType.Location = new System.Drawing.Point(125, 63);
            this.uiCB_deviceType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiCB_deviceType.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiCB_deviceType.Name = "uiCB_deviceType";
            this.uiCB_deviceType.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.uiCB_deviceType.Size = new System.Drawing.Size(246, 29);
            this.uiCB_deviceType.TabIndex = 16;
            this.uiCB_deviceType.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel2.Location = new System.Drawing.Point(23, 63);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(100, 23);
            this.uiLabel2.TabIndex = 17;
            this.uiLabel2.Text = "设备类型：";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiTB_deviceName
            // 
            this.uiTB_deviceName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTB_deviceName.FillColor = System.Drawing.Color.White;
            this.uiTB_deviceName.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiTB_deviceName.Location = new System.Drawing.Point(125, 102);
            this.uiTB_deviceName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTB_deviceName.Maximum = 2147483647D;
            this.uiTB_deviceName.Minimum = -2147483648D;
            this.uiTB_deviceName.Name = "uiTB_deviceName";
            this.uiTB_deviceName.Padding = new System.Windows.Forms.Padding(5);
            this.uiTB_deviceName.Size = new System.Drawing.Size(246, 29);
            this.uiTB_deviceName.TabIndex = 18;
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel3.Location = new System.Drawing.Point(23, 104);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(100, 23);
            this.uiLabel3.TabIndex = 19;
            this.uiLabel3.Text = "设备名称：";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel4.Location = new System.Drawing.Point(23, 183);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(100, 23);
            this.uiLabel4.TabIndex = 21;
            this.uiLabel4.Text = "通道数量：";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiCB_chennalNum
            // 
            this.uiCB_chennalNum.FillColor = System.Drawing.Color.White;
            this.uiCB_chennalNum.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiCB_chennalNum.Location = new System.Drawing.Point(125, 180);
            this.uiCB_chennalNum.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiCB_chennalNum.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiCB_chennalNum.Name = "uiCB_chennalNum";
            this.uiCB_chennalNum.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.uiCB_chennalNum.Size = new System.Drawing.Size(246, 29);
            this.uiCB_chennalNum.TabIndex = 20;
            this.uiCB_chennalNum.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel5.Location = new System.Drawing.Point(23, 222);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(100, 23);
            this.uiLabel5.TabIndex = 23;
            this.uiLabel5.Text = "起始通道：";
            // 
            // uiCB_startChennal
            // 
            this.uiCB_startChennal.FillColor = System.Drawing.Color.White;
            this.uiCB_startChennal.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiCB_startChennal.Location = new System.Drawing.Point(125, 219);
            this.uiCB_startChennal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiCB_startChennal.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiCB_startChennal.Name = "uiCB_startChennal";
            this.uiCB_startChennal.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.uiCB_startChennal.Size = new System.Drawing.Size(246, 29);
            this.uiCB_startChennal.TabIndex = 22;
            this.uiCB_startChennal.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel6
            // 
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel6.Location = new System.Drawing.Point(23, 261);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(100, 23);
            this.uiLabel6.TabIndex = 25;
            this.uiLabel6.Text = "部署位置：";
            // 
            // uiTB_installAddress
            // 
            this.uiTB_installAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTB_installAddress.FillColor = System.Drawing.Color.White;
            this.uiTB_installAddress.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiTB_installAddress.Location = new System.Drawing.Point(125, 258);
            this.uiTB_installAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTB_installAddress.Maximum = 2147483647D;
            this.uiTB_installAddress.Minimum = -2147483648D;
            this.uiTB_installAddress.Name = "uiTB_installAddress";
            this.uiTB_installAddress.Padding = new System.Windows.Forms.Padding(5);
            this.uiTB_installAddress.Size = new System.Drawing.Size(246, 29);
            this.uiTB_installAddress.TabIndex = 26;
            // 
            // F_AddDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 376);
            this.Controls.Add(this.uiTB_installAddress);
            this.Controls.Add(this.uiLabel6);
            this.Controls.Add(this.uiLabel5);
            this.Controls.Add(this.uiCB_startChennal);
            this.Controls.Add(this.uiLabel4);
            this.Controls.Add(this.uiCB_chennalNum);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.uiTB_deviceName);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiCB_deviceType);
            this.Controls.Add(this.uiTB_deviceAddress);
            this.Controls.Add(this.uiLabel1);
            this.Name = "F_AddDevice";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新建设备";
            this.Load += new System.EventHandler(this.AddDeviceForm_Load);
            this.Controls.SetChildIndex(this.uiLabel1, 0);
            this.Controls.SetChildIndex(this.uiTB_deviceAddress, 0);
            this.Controls.SetChildIndex(this.uiCB_deviceType, 0);
            this.Controls.SetChildIndex(this.uiLabel2, 0);
            this.Controls.SetChildIndex(this.uiTB_deviceName, 0);
            this.Controls.SetChildIndex(this.uiLabel3, 0);
            this.Controls.SetChildIndex(this.uiCB_chennalNum, 0);
            this.Controls.SetChildIndex(this.uiLabel4, 0);
            this.Controls.SetChildIndex(this.uiCB_startChennal, 0);
            this.Controls.SetChildIndex(this.uiLabel5, 0);
            this.Controls.SetChildIndex(this.pnlBtm, 0);
            this.Controls.SetChildIndex(this.uiLabel6, 0);
            this.Controls.SetChildIndex(this.uiTB_installAddress, 0);
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox uiTB_deviceAddress;
        private Sunny.UI.UIComboBox uiCB_deviceType;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UITextBox uiTB_deviceName;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UIComboBox uiCB_chennalNum;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UIComboBox uiCB_startChennal;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UITextBox uiTB_installAddress;
    }
}