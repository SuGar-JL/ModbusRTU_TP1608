namespace ModbusRTU_TP1608
{
    partial class F_AddDeviceRTU
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
            this.deviceAddress = new Sunny.UI.UITextBox();
            this.deviceType = new Sunny.UI.UIComboBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.deviceName = new Sunny.UI.UITextBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.deviceChennalNum = new Sunny.UI.UIComboBox();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.deviceStartChennal = new Sunny.UI.UIComboBox();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.devicePosition = new Sunny.UI.UITextBox();
            this.deviceBaudRate = new Sunny.UI.UIComboBox();
            this.uiLabel9 = new Sunny.UI.UILabel();
            this.deviceSerialPort = new Sunny.UI.UIComboBox();
            this.uiLabel8 = new Sunny.UI.UILabel();
            this.SuspendLayout();
            // 
            // pnlBtm
            // 
            this.pnlBtm.Location = new System.Drawing.Point(1, 387);
            this.pnlBtm.Size = new System.Drawing.Size(398, 55);
            this.pnlBtm.Style = Sunny.UI.UIStyle.Custom;
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(25, 143);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(100, 23);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 12;
            this.uiLabel1.Text = "设备地址：";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // deviceAddress
            // 
            this.deviceAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.deviceAddress.FillColor = System.Drawing.Color.White;
            this.deviceAddress.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.deviceAddress.Location = new System.Drawing.Point(127, 141);
            this.deviceAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deviceAddress.Maximum = 2147483647D;
            this.deviceAddress.Minimum = -2147483648D;
            this.deviceAddress.Name = "deviceAddress";
            this.deviceAddress.Padding = new System.Windows.Forms.Padding(5);
            this.deviceAddress.Radius = 8;
            this.deviceAddress.Size = new System.Drawing.Size(225, 29);
            this.deviceAddress.Style = Sunny.UI.UIStyle.Custom;
            this.deviceAddress.TabIndex = 13;
            this.deviceAddress.Watermark = "";
            // 
            // deviceType
            // 
            this.deviceType.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.deviceType.FillColor = System.Drawing.Color.White;
            this.deviceType.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.deviceType.Items.AddRange(new object[] {
            "TP1608P-AI-A"});
            this.deviceType.Location = new System.Drawing.Point(127, 63);
            this.deviceType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deviceType.MinimumSize = new System.Drawing.Size(63, 0);
            this.deviceType.Name = "deviceType";
            this.deviceType.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.deviceType.Radius = 8;
            this.deviceType.Size = new System.Drawing.Size(225, 29);
            this.deviceType.Style = Sunny.UI.UIStyle.Custom;
            this.deviceType.TabIndex = 16;
            this.deviceType.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.deviceType.Watermark = "";
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel2.Location = new System.Drawing.Point(25, 63);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(100, 23);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 17;
            this.uiLabel2.Text = "设备类型：";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // deviceName
            // 
            this.deviceName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.deviceName.FillColor = System.Drawing.Color.White;
            this.deviceName.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.deviceName.Location = new System.Drawing.Point(127, 102);
            this.deviceName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deviceName.Maximum = 2147483647D;
            this.deviceName.Minimum = -2147483648D;
            this.deviceName.Name = "deviceName";
            this.deviceName.Padding = new System.Windows.Forms.Padding(5);
            this.deviceName.Radius = 8;
            this.deviceName.Size = new System.Drawing.Size(225, 29);
            this.deviceName.Style = Sunny.UI.UIStyle.Custom;
            this.deviceName.TabIndex = 18;
            this.deviceName.Watermark = "";
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel3.Location = new System.Drawing.Point(25, 104);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(100, 23);
            this.uiLabel3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel3.TabIndex = 19;
            this.uiLabel3.Text = "设备名称：";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel4.Location = new System.Drawing.Point(25, 183);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(100, 23);
            this.uiLabel4.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel4.TabIndex = 21;
            this.uiLabel4.Text = "通道数量：";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // deviceChennalNum
            // 
            this.deviceChennalNum.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.deviceChennalNum.FillColor = System.Drawing.Color.White;
            this.deviceChennalNum.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.deviceChennalNum.Items.AddRange(new object[] {
            "1 通道",
            "2 通道",
            "3 通道",
            "4 通道",
            "5 通道",
            "6 通道",
            "7 通道",
            "8 通道"});
            this.deviceChennalNum.Location = new System.Drawing.Point(127, 180);
            this.deviceChennalNum.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deviceChennalNum.MinimumSize = new System.Drawing.Size(63, 0);
            this.deviceChennalNum.Name = "deviceChennalNum";
            this.deviceChennalNum.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.deviceChennalNum.Radius = 8;
            this.deviceChennalNum.Size = new System.Drawing.Size(225, 29);
            this.deviceChennalNum.Style = Sunny.UI.UIStyle.Custom;
            this.deviceChennalNum.TabIndex = 20;
            this.deviceChennalNum.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.deviceChennalNum.Watermark = "";
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel5.Location = new System.Drawing.Point(25, 222);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(100, 23);
            this.uiLabel5.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel5.TabIndex = 23;
            this.uiLabel5.Text = "起始通道：";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // deviceStartChennal
            // 
            this.deviceStartChennal.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.deviceStartChennal.FillColor = System.Drawing.Color.White;
            this.deviceStartChennal.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.deviceStartChennal.Items.AddRange(new object[] {
            "第 1 通道",
            "第 2 通道",
            "第 3 通道",
            "第 4 通道",
            "第 5 通道",
            "第 6 通道",
            "第 7 通道",
            "第 8 通道"});
            this.deviceStartChennal.Location = new System.Drawing.Point(127, 219);
            this.deviceStartChennal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deviceStartChennal.MinimumSize = new System.Drawing.Size(63, 0);
            this.deviceStartChennal.Name = "deviceStartChennal";
            this.deviceStartChennal.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.deviceStartChennal.Radius = 8;
            this.deviceStartChennal.Size = new System.Drawing.Size(225, 29);
            this.deviceStartChennal.Style = Sunny.UI.UIStyle.Custom;
            this.deviceStartChennal.TabIndex = 22;
            this.deviceStartChennal.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.deviceStartChennal.Watermark = "";
            // 
            // uiLabel6
            // 
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel6.Location = new System.Drawing.Point(25, 339);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(100, 23);
            this.uiLabel6.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel6.TabIndex = 25;
            this.uiLabel6.Text = "安装位置：";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // devicePosition
            // 
            this.devicePosition.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.devicePosition.FillColor = System.Drawing.Color.White;
            this.devicePosition.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.devicePosition.Location = new System.Drawing.Point(127, 336);
            this.devicePosition.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.devicePosition.Maximum = 2147483647D;
            this.devicePosition.Minimum = -2147483648D;
            this.devicePosition.Name = "devicePosition";
            this.devicePosition.Padding = new System.Windows.Forms.Padding(5);
            this.devicePosition.Radius = 8;
            this.devicePosition.Size = new System.Drawing.Size(225, 29);
            this.devicePosition.Style = Sunny.UI.UIStyle.Custom;
            this.devicePosition.TabIndex = 26;
            this.devicePosition.Watermark = "";
            // 
            // deviceBaudRate
            // 
            this.deviceBaudRate.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.deviceBaudRate.FillColor = System.Drawing.Color.White;
            this.deviceBaudRate.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.deviceBaudRate.Items.AddRange(new object[] {
            "75",
            "110",
            "134",
            "150",
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "7200",
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200",
            "128000"});
            this.deviceBaudRate.Location = new System.Drawing.Point(127, 297);
            this.deviceBaudRate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deviceBaudRate.MinimumSize = new System.Drawing.Size(63, 0);
            this.deviceBaudRate.Name = "deviceBaudRate";
            this.deviceBaudRate.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.deviceBaudRate.Radius = 8;
            this.deviceBaudRate.Size = new System.Drawing.Size(225, 29);
            this.deviceBaudRate.Style = Sunny.UI.UIStyle.Custom;
            this.deviceBaudRate.TabIndex = 36;
            this.deviceBaudRate.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.deviceBaudRate.Watermark = "";
            // 
            // uiLabel9
            // 
            this.uiLabel9.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel9.Location = new System.Drawing.Point(25, 300);
            this.uiLabel9.Name = "uiLabel9";
            this.uiLabel9.Size = new System.Drawing.Size(100, 23);
            this.uiLabel9.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel9.TabIndex = 37;
            this.uiLabel9.Text = "波特率：";
            this.uiLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // deviceSerialPort
            // 
            this.deviceSerialPort.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.deviceSerialPort.FillColor = System.Drawing.Color.White;
            this.deviceSerialPort.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.deviceSerialPort.Items.AddRange(new object[] {
            "第 1 通道",
            "第 2 通道",
            "第 3 通道",
            "第 4 通道",
            "第 5 通道",
            "第 6 通道",
            "第 7 通道",
            "第 8 通道"});
            this.deviceSerialPort.Location = new System.Drawing.Point(127, 258);
            this.deviceSerialPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deviceSerialPort.MinimumSize = new System.Drawing.Size(63, 0);
            this.deviceSerialPort.Name = "deviceSerialPort";
            this.deviceSerialPort.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.deviceSerialPort.Radius = 8;
            this.deviceSerialPort.Size = new System.Drawing.Size(225, 29);
            this.deviceSerialPort.Style = Sunny.UI.UIStyle.Custom;
            this.deviceSerialPort.TabIndex = 34;
            this.deviceSerialPort.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.deviceSerialPort.Watermark = "";
            // 
            // uiLabel8
            // 
            this.uiLabel8.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel8.Location = new System.Drawing.Point(25, 261);
            this.uiLabel8.Name = "uiLabel8";
            this.uiLabel8.Size = new System.Drawing.Size(100, 23);
            this.uiLabel8.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel8.TabIndex = 35;
            this.uiLabel8.Text = "串口：";
            this.uiLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // F_AddDeviceRTU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 445);
            this.Controls.Add(this.deviceBaudRate);
            this.Controls.Add(this.uiLabel9);
            this.Controls.Add(this.deviceSerialPort);
            this.Controls.Add(this.uiLabel8);
            this.Controls.Add(this.devicePosition);
            this.Controls.Add(this.uiLabel6);
            this.Controls.Add(this.uiLabel5);
            this.Controls.Add(this.deviceStartChennal);
            this.Controls.Add(this.uiLabel4);
            this.Controls.Add(this.deviceChennalNum);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.deviceName);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.deviceType);
            this.Controls.Add(this.deviceAddress);
            this.Controls.Add(this.uiLabel1);
            this.Name = "F_AddDeviceRTU";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "新建设备";
            this.Load += new System.EventHandler(this.F_AddDeviceRTU_Load);
            this.Controls.SetChildIndex(this.uiLabel1, 0);
            this.Controls.SetChildIndex(this.deviceAddress, 0);
            this.Controls.SetChildIndex(this.deviceType, 0);
            this.Controls.SetChildIndex(this.uiLabel2, 0);
            this.Controls.SetChildIndex(this.deviceName, 0);
            this.Controls.SetChildIndex(this.uiLabel3, 0);
            this.Controls.SetChildIndex(this.deviceChennalNum, 0);
            this.Controls.SetChildIndex(this.uiLabel4, 0);
            this.Controls.SetChildIndex(this.deviceStartChennal, 0);
            this.Controls.SetChildIndex(this.uiLabel5, 0);
            this.Controls.SetChildIndex(this.uiLabel6, 0);
            this.Controls.SetChildIndex(this.devicePosition, 0);
            this.Controls.SetChildIndex(this.pnlBtm, 0);
            this.Controls.SetChildIndex(this.uiLabel8, 0);
            this.Controls.SetChildIndex(this.deviceSerialPort, 0);
            this.Controls.SetChildIndex(this.uiLabel9, 0);
            this.Controls.SetChildIndex(this.deviceBaudRate, 0);
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UILabel uiLabel6;
        public Sunny.UI.UITextBox deviceAddress;
        public Sunny.UI.UIComboBox deviceType;
        public Sunny.UI.UITextBox deviceName;
        public Sunny.UI.UIComboBox deviceChennalNum;
        public Sunny.UI.UIComboBox deviceStartChennal;
        public Sunny.UI.UITextBox devicePosition;
        public Sunny.UI.UIComboBox deviceBaudRate;
        private Sunny.UI.UILabel uiLabel9;
        public Sunny.UI.UIComboBox deviceSerialPort;
        private Sunny.UI.UILabel uiLabel8;
    }
}