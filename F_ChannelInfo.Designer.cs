namespace ModbusRTU_TP1608
{
    partial class F_ChannelInfo
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
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.ChannelName = new Sunny.UI.UITextBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.ChannelUnit = new Sunny.UI.UIComboBox();
            this.ChannelID = new Sunny.UI.UITextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.ChannelLabel = new Sunny.UI.UITextBox();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.uiLabel7 = new Sunny.UI.UILabel();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.ChannelSensorType = new Sunny.UI.UIComboBox();
            this.ChannelSensorName = new Sunny.UI.UITextBox();
            this.uiLabel9 = new Sunny.UI.UILabel();
            this.ChannelSensorRangeL = new Sunny.UI.UITextBox();
            this.ChannelSensorRangeH = new Sunny.UI.UITextBox();
            this.uiLine1 = new Sunny.UI.UILine();
            this.uiLabel10 = new Sunny.UI.UILabel();
            this.ChannelWarning1L = new Sunny.UI.UITextBox();
            this.uiLine2 = new Sunny.UI.UILine();
            this.ChannelWarning1H = new Sunny.UI.UITextBox();
            this.isWraning = new Sunny.UI.UICheckBox();
            this.uiLabel12 = new Sunny.UI.UILabel();
            this.ChannelWarning3L = new Sunny.UI.UITextBox();
            this.uiLine4 = new Sunny.UI.UILine();
            this.ChannelWarning3H = new Sunny.UI.UITextBox();
            this.ChannelWarning2H = new Sunny.UI.UITextBox();
            this.uiLine3 = new Sunny.UI.UILine();
            this.ChannelWarning2L = new Sunny.UI.UITextBox();
            this.uiLabel11 = new Sunny.UI.UILabel();
            this.ChannelTypeWrite = new Sunny.UI.UIButton();
            this.ChannelTypeRead = new Sunny.UI.UIButton();
            this.uiLabel8 = new Sunny.UI.UILabel();
            this.ChannelType = new Sunny.UI.UIComboBox();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.ChannelDecimalPlaces = new Sunny.UI.UIComboBox();
            this.uiLabel13 = new Sunny.UI.UILabel();
            this.ChannelSensorId = new Sunny.UI.UIComboBox();
            this.uiLabel14 = new Sunny.UI.UILabel();
            this.uiTextBox1 = new Sunny.UI.UITextBox();
            this.uiLabel15 = new Sunny.UI.UILabel();
            this.SuspendLayout();
            // 
            // pnlBtm
            // 
            this.pnlBtm.Location = new System.Drawing.Point(1, 471);
            this.pnlBtm.Size = new System.Drawing.Size(683, 55);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel3.Location = new System.Drawing.Point(20, 63);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(100, 23);
            this.uiLabel3.TabIndex = 23;
            this.uiLabel3.Text = "通道名称：";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ChannelName
            // 
            this.ChannelName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ChannelName.FillColor = System.Drawing.Color.White;
            this.ChannelName.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ChannelName.Location = new System.Drawing.Point(122, 60);
            this.ChannelName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ChannelName.Maximum = 2147483647D;
            this.ChannelName.Minimum = -2147483648D;
            this.ChannelName.MinimumSize = new System.Drawing.Size(1, 1);
            this.ChannelName.Name = "ChannelName";
            this.ChannelName.Padding = new System.Windows.Forms.Padding(5);
            this.ChannelName.Radius = 8;
            this.ChannelName.Size = new System.Drawing.Size(200, 29);
            this.ChannelName.TabIndex = 22;
            this.ChannelName.Watermark = "";
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel2.Location = new System.Drawing.Point(340, 63);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(100, 23);
            this.uiLabel2.TabIndex = 21;
            this.uiLabel2.Text = "通道ID：";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ChannelUnit
            // 
            this.ChannelUnit.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.ChannelUnit.FillColor = System.Drawing.Color.White;
            this.ChannelUnit.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ChannelUnit.Items.AddRange(new object[] {
            "ppm",
            "℃",
            "Pa",
            "MPa",
            "%",
            "m",
            "m/s"});
            this.ChannelUnit.Location = new System.Drawing.Point(442, 99);
            this.ChannelUnit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ChannelUnit.MinimumSize = new System.Drawing.Size(63, 0);
            this.ChannelUnit.Name = "ChannelUnit";
            this.ChannelUnit.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.ChannelUnit.Radius = 8;
            this.ChannelUnit.Size = new System.Drawing.Size(200, 29);
            this.ChannelUnit.TabIndex = 20;
            this.ChannelUnit.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.ChannelUnit.Watermark = "";
            // 
            // ChannelID
            // 
            this.ChannelID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ChannelID.Enabled = false;
            this.ChannelID.FillColor = System.Drawing.Color.White;
            this.ChannelID.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ChannelID.Location = new System.Drawing.Point(442, 60);
            this.ChannelID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ChannelID.Maximum = 2147483647D;
            this.ChannelID.Minimum = -2147483648D;
            this.ChannelID.MinimumSize = new System.Drawing.Size(1, 1);
            this.ChannelID.Name = "ChannelID";
            this.ChannelID.Padding = new System.Windows.Forms.Padding(5);
            this.ChannelID.Radius = 8;
            this.ChannelID.ReadOnly = true;
            this.ChannelID.Size = new System.Drawing.Size(200, 29);
            this.ChannelID.TabIndex = 24;
            this.ChannelID.Watermark = "";
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(20, 102);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(100, 23);
            this.uiLabel1.TabIndex = 26;
            this.uiLabel1.Text = "监测项：";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ChannelLabel
            // 
            this.ChannelLabel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ChannelLabel.FillColor = System.Drawing.Color.White;
            this.ChannelLabel.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ChannelLabel.Location = new System.Drawing.Point(122, 99);
            this.ChannelLabel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ChannelLabel.Maximum = 2147483647D;
            this.ChannelLabel.Minimum = -2147483648D;
            this.ChannelLabel.MinimumSize = new System.Drawing.Size(1, 1);
            this.ChannelLabel.Name = "ChannelLabel";
            this.ChannelLabel.Padding = new System.Windows.Forms.Padding(5);
            this.ChannelLabel.Radius = 8;
            this.ChannelLabel.Size = new System.Drawing.Size(200, 29);
            this.ChannelLabel.TabIndex = 25;
            this.ChannelLabel.Watermark = "";
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel4.Location = new System.Drawing.Point(340, 102);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(100, 23);
            this.uiLabel4.TabIndex = 28;
            this.uiLabel4.Text = "监测单位：";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiLabel7
            // 
            this.uiLabel7.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel7.Location = new System.Drawing.Point(329, 141);
            this.uiLabel7.Name = "uiLabel7";
            this.uiLabel7.Size = new System.Drawing.Size(111, 23);
            this.uiLabel7.TabIndex = 39;
            this.uiLabel7.Text = "传感器名称：";
            this.uiLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel5.Location = new System.Drawing.Point(4, 141);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(116, 23);
            this.uiLabel5.TabIndex = 38;
            this.uiLabel5.Text = "传感器类型：";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ChannelSensorType
            // 
            this.ChannelSensorType.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.ChannelSensorType.FillColor = System.Drawing.Color.White;
            this.ChannelSensorType.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ChannelSensorType.Items.AddRange(new object[] {
            "流量传感器",
            "水压传感器",
            "风压传感器",
            "风速传感器",
            "温度传感器",
            "CO2浓度传感器",
            "CO浓度传感器",
            "烟雾浓度传感器",
            "屋顶水箱液位信号",
            "室外水箱液位信号",
            "压力传感器",
            "其它"});
            this.ChannelSensorType.Location = new System.Drawing.Point(122, 138);
            this.ChannelSensorType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ChannelSensorType.MinimumSize = new System.Drawing.Size(63, 0);
            this.ChannelSensorType.Name = "ChannelSensorType";
            this.ChannelSensorType.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.ChannelSensorType.Radius = 8;
            this.ChannelSensorType.Size = new System.Drawing.Size(200, 29);
            this.ChannelSensorType.TabIndex = 37;
            this.ChannelSensorType.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.ChannelSensorType.Watermark = "";
            // 
            // ChannelSensorName
            // 
            this.ChannelSensorName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ChannelSensorName.FillColor = System.Drawing.Color.White;
            this.ChannelSensorName.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ChannelSensorName.Location = new System.Drawing.Point(442, 138);
            this.ChannelSensorName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ChannelSensorName.Maximum = 2147483647D;
            this.ChannelSensorName.Minimum = -2147483648D;
            this.ChannelSensorName.MinimumSize = new System.Drawing.Size(1, 1);
            this.ChannelSensorName.Name = "ChannelSensorName";
            this.ChannelSensorName.Padding = new System.Windows.Forms.Padding(5);
            this.ChannelSensorName.Radius = 8;
            this.ChannelSensorName.Size = new System.Drawing.Size(200, 29);
            this.ChannelSensorName.TabIndex = 36;
            this.ChannelSensorName.Watermark = "";
            // 
            // uiLabel9
            // 
            this.uiLabel9.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel9.Location = new System.Drawing.Point(4, 218);
            this.uiLabel9.Name = "uiLabel9";
            this.uiLabel9.Size = new System.Drawing.Size(116, 23);
            this.uiLabel9.TabIndex = 40;
            this.uiLabel9.Text = "传感器量程：";
            this.uiLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ChannelSensorRangeL
            // 
            this.ChannelSensorRangeL.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ChannelSensorRangeL.FillColor = System.Drawing.Color.White;
            this.ChannelSensorRangeL.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ChannelSensorRangeL.Location = new System.Drawing.Point(122, 216);
            this.ChannelSensorRangeL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ChannelSensorRangeL.Maximum = 2147483647D;
            this.ChannelSensorRangeL.Minimum = -2147483648D;
            this.ChannelSensorRangeL.MinimumSize = new System.Drawing.Size(1, 1);
            this.ChannelSensorRangeL.Name = "ChannelSensorRangeL";
            this.ChannelSensorRangeL.Padding = new System.Windows.Forms.Padding(5);
            this.ChannelSensorRangeL.Radius = 8;
            this.ChannelSensorRangeL.Size = new System.Drawing.Size(200, 29);
            this.ChannelSensorRangeL.TabIndex = 41;
            this.ChannelSensorRangeL.Text = "0.00";
            this.ChannelSensorRangeL.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.ChannelSensorRangeL.Watermark = "";
            // 
            // ChannelSensorRangeH
            // 
            this.ChannelSensorRangeH.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ChannelSensorRangeH.FillColor = System.Drawing.Color.White;
            this.ChannelSensorRangeH.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ChannelSensorRangeH.Location = new System.Drawing.Point(440, 216);
            this.ChannelSensorRangeH.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ChannelSensorRangeH.Maximum = 2147483647D;
            this.ChannelSensorRangeH.Minimum = -2147483648D;
            this.ChannelSensorRangeH.MinimumSize = new System.Drawing.Size(1, 1);
            this.ChannelSensorRangeH.Name = "ChannelSensorRangeH";
            this.ChannelSensorRangeH.Padding = new System.Windows.Forms.Padding(5);
            this.ChannelSensorRangeH.Radius = 8;
            this.ChannelSensorRangeH.Size = new System.Drawing.Size(200, 29);
            this.ChannelSensorRangeH.TabIndex = 42;
            this.ChannelSensorRangeH.Text = "0.00";
            this.ChannelSensorRangeH.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.ChannelSensorRangeH.Watermark = "";
            // 
            // uiLine1
            // 
            this.uiLine1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine1.Location = new System.Drawing.Point(354, 216);
            this.uiLine1.MinimumSize = new System.Drawing.Size(2, 2);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(50, 29);
            this.uiLine1.TabIndex = 43;
            // 
            // uiLabel10
            // 
            this.uiLabel10.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel10.Location = new System.Drawing.Point(4, 343);
            this.uiLabel10.Name = "uiLabel10";
            this.uiLabel10.Size = new System.Drawing.Size(116, 23);
            this.uiLabel10.TabIndex = 44;
            this.uiLabel10.Text = "一级报警：";
            this.uiLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ChannelWarning1L
            // 
            this.ChannelWarning1L.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ChannelWarning1L.FillColor = System.Drawing.Color.White;
            this.ChannelWarning1L.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ChannelWarning1L.Location = new System.Drawing.Point(121, 340);
            this.ChannelWarning1L.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ChannelWarning1L.Maximum = 2147483647D;
            this.ChannelWarning1L.Minimum = -2147483648D;
            this.ChannelWarning1L.MinimumSize = new System.Drawing.Size(1, 1);
            this.ChannelWarning1L.Name = "ChannelWarning1L";
            this.ChannelWarning1L.Padding = new System.Windows.Forms.Padding(5);
            this.ChannelWarning1L.Radius = 8;
            this.ChannelWarning1L.Size = new System.Drawing.Size(201, 29);
            this.ChannelWarning1L.TabIndex = 45;
            this.ChannelWarning1L.Text = "0.00";
            this.ChannelWarning1L.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.ChannelWarning1L.Watermark = "";
            // 
            // uiLine2
            // 
            this.uiLine2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine2.Location = new System.Drawing.Point(356, 340);
            this.uiLine2.MinimumSize = new System.Drawing.Size(2, 2);
            this.uiLine2.Name = "uiLine2";
            this.uiLine2.Size = new System.Drawing.Size(50, 29);
            this.uiLine2.TabIndex = 47;
            // 
            // ChannelWarning1H
            // 
            this.ChannelWarning1H.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ChannelWarning1H.FillColor = System.Drawing.Color.White;
            this.ChannelWarning1H.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ChannelWarning1H.Location = new System.Drawing.Point(441, 340);
            this.ChannelWarning1H.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ChannelWarning1H.Maximum = 2147483647D;
            this.ChannelWarning1H.Minimum = -2147483648D;
            this.ChannelWarning1H.MinimumSize = new System.Drawing.Size(1, 1);
            this.ChannelWarning1H.Name = "ChannelWarning1H";
            this.ChannelWarning1H.Padding = new System.Windows.Forms.Padding(5);
            this.ChannelWarning1H.Radius = 8;
            this.ChannelWarning1H.Size = new System.Drawing.Size(201, 29);
            this.ChannelWarning1H.TabIndex = 60;
            this.ChannelWarning1H.Text = "0.00";
            this.ChannelWarning1H.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.ChannelWarning1H.Watermark = "";
            // 
            // isWraning
            // 
            this.isWraning.Cursor = System.Windows.Forms.Cursors.Hand;
            this.isWraning.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.isWraning.Location = new System.Drawing.Point(39, 298);
            this.isWraning.MinimumSize = new System.Drawing.Size(1, 1);
            this.isWraning.Name = "isWraning";
            this.isWraning.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.isWraning.Size = new System.Drawing.Size(69, 29);
            this.isWraning.TabIndex = 70;
            this.isWraning.Text = "报警";
            // 
            // uiLabel12
            // 
            this.uiLabel12.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel12.Location = new System.Drawing.Point(4, 420);
            this.uiLabel12.Name = "uiLabel12";
            this.uiLabel12.Size = new System.Drawing.Size(116, 23);
            this.uiLabel12.TabIndex = 52;
            this.uiLabel12.Text = "三级报警：";
            this.uiLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ChannelWarning3L
            // 
            this.ChannelWarning3L.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ChannelWarning3L.FillColor = System.Drawing.Color.White;
            this.ChannelWarning3L.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ChannelWarning3L.Location = new System.Drawing.Point(121, 417);
            this.ChannelWarning3L.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ChannelWarning3L.Maximum = 2147483647D;
            this.ChannelWarning3L.Minimum = -2147483648D;
            this.ChannelWarning3L.MinimumSize = new System.Drawing.Size(1, 1);
            this.ChannelWarning3L.Name = "ChannelWarning3L";
            this.ChannelWarning3L.Padding = new System.Windows.Forms.Padding(5);
            this.ChannelWarning3L.Radius = 8;
            this.ChannelWarning3L.Size = new System.Drawing.Size(201, 29);
            this.ChannelWarning3L.TabIndex = 66;
            this.ChannelWarning3L.Text = "0.00";
            this.ChannelWarning3L.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.ChannelWarning3L.Watermark = "";
            // 
            // uiLine4
            // 
            this.uiLine4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine4.Location = new System.Drawing.Point(356, 418);
            this.uiLine4.MinimumSize = new System.Drawing.Size(2, 2);
            this.uiLine4.Name = "uiLine4";
            this.uiLine4.Size = new System.Drawing.Size(50, 29);
            this.uiLine4.TabIndex = 55;
            // 
            // ChannelWarning3H
            // 
            this.ChannelWarning3H.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ChannelWarning3H.FillColor = System.Drawing.Color.White;
            this.ChannelWarning3H.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ChannelWarning3H.Location = new System.Drawing.Point(441, 417);
            this.ChannelWarning3H.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ChannelWarning3H.Maximum = 2147483647D;
            this.ChannelWarning3H.Minimum = -2147483648D;
            this.ChannelWarning3H.MinimumSize = new System.Drawing.Size(1, 1);
            this.ChannelWarning3H.Name = "ChannelWarning3H";
            this.ChannelWarning3H.Padding = new System.Windows.Forms.Padding(5);
            this.ChannelWarning3H.Radius = 8;
            this.ChannelWarning3H.Size = new System.Drawing.Size(201, 29);
            this.ChannelWarning3H.TabIndex = 68;
            this.ChannelWarning3H.Text = "0.00";
            this.ChannelWarning3H.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.ChannelWarning3H.Watermark = "";
            // 
            // ChannelWarning2H
            // 
            this.ChannelWarning2H.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ChannelWarning2H.FillColor = System.Drawing.Color.White;
            this.ChannelWarning2H.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ChannelWarning2H.Location = new System.Drawing.Point(441, 379);
            this.ChannelWarning2H.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ChannelWarning2H.Maximum = 2147483647D;
            this.ChannelWarning2H.Minimum = -2147483648D;
            this.ChannelWarning2H.MinimumSize = new System.Drawing.Size(1, 1);
            this.ChannelWarning2H.Name = "ChannelWarning2H";
            this.ChannelWarning2H.Padding = new System.Windows.Forms.Padding(5);
            this.ChannelWarning2H.Radius = 8;
            this.ChannelWarning2H.Size = new System.Drawing.Size(201, 29);
            this.ChannelWarning2H.TabIndex = 64;
            this.ChannelWarning2H.Text = "0.00";
            this.ChannelWarning2H.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.ChannelWarning2H.Watermark = "";
            // 
            // uiLine3
            // 
            this.uiLine3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine3.Location = new System.Drawing.Point(356, 379);
            this.uiLine3.MinimumSize = new System.Drawing.Size(2, 2);
            this.uiLine3.Name = "uiLine3";
            this.uiLine3.Size = new System.Drawing.Size(50, 29);
            this.uiLine3.TabIndex = 51;
            // 
            // ChannelWarning2L
            // 
            this.ChannelWarning2L.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ChannelWarning2L.FillColor = System.Drawing.Color.White;
            this.ChannelWarning2L.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ChannelWarning2L.Location = new System.Drawing.Point(121, 379);
            this.ChannelWarning2L.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ChannelWarning2L.Maximum = 2147483647D;
            this.ChannelWarning2L.Minimum = -2147483648D;
            this.ChannelWarning2L.MinimumSize = new System.Drawing.Size(1, 1);
            this.ChannelWarning2L.Name = "ChannelWarning2L";
            this.ChannelWarning2L.Padding = new System.Windows.Forms.Padding(5);
            this.ChannelWarning2L.Radius = 8;
            this.ChannelWarning2L.Size = new System.Drawing.Size(201, 29);
            this.ChannelWarning2L.TabIndex = 62;
            this.ChannelWarning2L.Text = "0.00";
            this.ChannelWarning2L.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.ChannelWarning2L.Watermark = "";
            // 
            // uiLabel11
            // 
            this.uiLabel11.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel11.Location = new System.Drawing.Point(4, 382);
            this.uiLabel11.Name = "uiLabel11";
            this.uiLabel11.Size = new System.Drawing.Size(116, 23);
            this.uiLabel11.TabIndex = 48;
            this.uiLabel11.Text = "二级报警：";
            this.uiLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ChannelTypeWrite
            // 
            this.ChannelTypeWrite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChannelTypeWrite.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ChannelTypeWrite.Location = new System.Drawing.Point(544, 255);
            this.ChannelTypeWrite.MinimumSize = new System.Drawing.Size(1, 1);
            this.ChannelTypeWrite.Name = "ChannelTypeWrite";
            this.ChannelTypeWrite.Size = new System.Drawing.Size(68, 29);
            this.ChannelTypeWrite.TabIndex = 78;
            this.ChannelTypeWrite.Text = "写入";
            // 
            // ChannelTypeRead
            // 
            this.ChannelTypeRead.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChannelTypeRead.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ChannelTypeRead.Location = new System.Drawing.Point(439, 255);
            this.ChannelTypeRead.MinimumSize = new System.Drawing.Size(1, 1);
            this.ChannelTypeRead.Name = "ChannelTypeRead";
            this.ChannelTypeRead.Size = new System.Drawing.Size(68, 29);
            this.ChannelTypeRead.TabIndex = 77;
            this.ChannelTypeRead.Text = "读取";
            this.ChannelTypeRead.Click += new System.EventHandler(this.ChannelTypeRead_Click);
            // 
            // uiLabel8
            // 
            this.uiLabel8.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel8.Location = new System.Drawing.Point(8, 258);
            this.uiLabel8.Name = "uiLabel8";
            this.uiLabel8.Size = new System.Drawing.Size(112, 23);
            this.uiLabel8.TabIndex = 76;
            this.uiLabel8.Text = "通道类型：";
            this.uiLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ChannelType
            // 
            this.ChannelType.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.ChannelType.FillColor = System.Drawing.Color.White;
            this.ChannelType.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ChannelType.Items.AddRange(new object[] {
            "电压-20~+20mV",
            "电压-78~+78mV",
            "电压-312~+312mV",
            "PT100",
            "电流4~20mA",
            "电流0~20mA",
            "电压0~10V",
            "电压0~5000mV",
            "J",
            "K",
            "T",
            "E",
            "R",
            "S",
            "B",
            "湿度AM2302"});
            this.ChannelType.Location = new System.Drawing.Point(122, 255);
            this.ChannelType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ChannelType.MinimumSize = new System.Drawing.Size(63, 0);
            this.ChannelType.Name = "ChannelType";
            this.ChannelType.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.ChannelType.Radius = 8;
            this.ChannelType.Size = new System.Drawing.Size(200, 29);
            this.ChannelType.TabIndex = 75;
            this.ChannelType.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.ChannelType.Watermark = "";
            // 
            // uiLabel6
            // 
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel6.Location = new System.Drawing.Point(341, 181);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(100, 23);
            this.uiLabel6.TabIndex = 79;
            this.uiLabel6.Text = "小数位：";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ChannelDecimalPlaces
            // 
            this.ChannelDecimalPlaces.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.ChannelDecimalPlaces.FillColor = System.Drawing.Color.White;
            this.ChannelDecimalPlaces.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ChannelDecimalPlaces.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.ChannelDecimalPlaces.Location = new System.Drawing.Point(442, 177);
            this.ChannelDecimalPlaces.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ChannelDecimalPlaces.MinimumSize = new System.Drawing.Size(63, 0);
            this.ChannelDecimalPlaces.Name = "ChannelDecimalPlaces";
            this.ChannelDecimalPlaces.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.ChannelDecimalPlaces.Radius = 8;
            this.ChannelDecimalPlaces.Size = new System.Drawing.Size(200, 29);
            this.ChannelDecimalPlaces.TabIndex = 80;
            this.ChannelDecimalPlaces.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.ChannelDecimalPlaces.Watermark = "";
            // 
            // uiLabel13
            // 
            this.uiLabel13.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel13.Location = new System.Drawing.Point(4, 180);
            this.uiLabel13.Name = "uiLabel13";
            this.uiLabel13.Size = new System.Drawing.Size(116, 23);
            this.uiLabel13.TabIndex = 82;
            this.uiLabel13.Text = "传感器ID：";
            this.uiLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ChannelSensorId
            // 
            this.ChannelSensorId.FillColor = System.Drawing.Color.White;
            this.ChannelSensorId.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ChannelSensorId.Items.AddRange(new object[] {
            "以下ID不能再使用："});
            this.ChannelSensorId.Location = new System.Drawing.Point(122, 177);
            this.ChannelSensorId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ChannelSensorId.MinimumSize = new System.Drawing.Size(63, 0);
            this.ChannelSensorId.Name = "ChannelSensorId";
            this.ChannelSensorId.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.ChannelSensorId.Radius = 8;
            this.ChannelSensorId.Size = new System.Drawing.Size(200, 29);
            this.ChannelSensorId.TabIndex = 81;
            this.ChannelSensorId.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.ChannelSensorId.Watermark = "不选择，手动输...";
            // 
            // uiLabel14
            // 
            this.uiLabel14.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel14.Location = new System.Drawing.Point(341, 302);
            this.uiLabel14.Name = "uiLabel14";
            this.uiLabel14.Size = new System.Drawing.Size(100, 23);
            this.uiLabel14.TabIndex = 83;
            this.uiLabel14.Text = "保存间隔：";
            this.uiLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiTextBox1
            // 
            this.uiTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox1.FillColor = System.Drawing.Color.White;
            this.uiTextBox1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiTextBox1.Location = new System.Drawing.Point(439, 301);
            this.uiTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox1.Maximum = 2147483647D;
            this.uiTextBox1.Minimum = -2147483648D;
            this.uiTextBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTextBox1.Name = "uiTextBox1";
            this.uiTextBox1.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBox1.Radius = 8;
            this.uiTextBox1.Size = new System.Drawing.Size(183, 29);
            this.uiTextBox1.TabIndex = 84;
            this.uiTextBox1.Text = "0.00";
            this.uiTextBox1.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.uiTextBox1.Watermark = "";
            // 
            // uiLabel15
            // 
            this.uiLabel15.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel15.Location = new System.Drawing.Point(627, 304);
            this.uiLabel15.Name = "uiLabel15";
            this.uiLabel15.Size = new System.Drawing.Size(16, 23);
            this.uiLabel15.TabIndex = 85;
            this.uiLabel15.Text = "s";
            this.uiLabel15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // F_ChannelInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 529);
            this.Controls.Add(this.uiLabel15);
            this.Controls.Add(this.uiTextBox1);
            this.Controls.Add(this.uiLabel14);
            this.Controls.Add(this.uiLabel13);
            this.Controls.Add(this.ChannelSensorId);
            this.Controls.Add(this.ChannelDecimalPlaces);
            this.Controls.Add(this.uiLabel6);
            this.Controls.Add(this.ChannelTypeWrite);
            this.Controls.Add(this.ChannelTypeRead);
            this.Controls.Add(this.uiLabel8);
            this.Controls.Add(this.ChannelType);
            this.Controls.Add(this.isWraning);
            this.Controls.Add(this.ChannelWarning3H);
            this.Controls.Add(this.ChannelWarning3L);
            this.Controls.Add(this.ChannelWarning2H);
            this.Controls.Add(this.ChannelWarning2L);
            this.Controls.Add(this.ChannelWarning1H);
            this.Controls.Add(this.uiLine4);
            this.Controls.Add(this.uiLabel12);
            this.Controls.Add(this.uiLine3);
            this.Controls.Add(this.uiLabel11);
            this.Controls.Add(this.uiLine2);
            this.Controls.Add(this.ChannelWarning1L);
            this.Controls.Add(this.uiLabel10);
            this.Controls.Add(this.ChannelSensorRangeH);
            this.Controls.Add(this.ChannelSensorRangeL);
            this.Controls.Add(this.uiLabel9);
            this.Controls.Add(this.uiLabel7);
            this.Controls.Add(this.uiLabel5);
            this.Controls.Add(this.ChannelSensorType);
            this.Controls.Add(this.ChannelSensorName);
            this.Controls.Add(this.uiLabel4);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.ChannelLabel);
            this.Controls.Add(this.ChannelID);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.ChannelName);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.ChannelUnit);
            this.Controls.Add(this.uiLine1);
            this.Name = "F_ChannelInfo";
            this.Text = "通道属性";
            this.Controls.SetChildIndex(this.uiLine1, 0);
            this.Controls.SetChildIndex(this.ChannelUnit, 0);
            this.Controls.SetChildIndex(this.uiLabel2, 0);
            this.Controls.SetChildIndex(this.ChannelName, 0);
            this.Controls.SetChildIndex(this.uiLabel3, 0);
            this.Controls.SetChildIndex(this.ChannelID, 0);
            this.Controls.SetChildIndex(this.ChannelLabel, 0);
            this.Controls.SetChildIndex(this.uiLabel1, 0);
            this.Controls.SetChildIndex(this.uiLabel4, 0);
            this.Controls.SetChildIndex(this.ChannelSensorName, 0);
            this.Controls.SetChildIndex(this.ChannelSensorType, 0);
            this.Controls.SetChildIndex(this.uiLabel5, 0);
            this.Controls.SetChildIndex(this.uiLabel7, 0);
            this.Controls.SetChildIndex(this.uiLabel9, 0);
            this.Controls.SetChildIndex(this.ChannelSensorRangeL, 0);
            this.Controls.SetChildIndex(this.ChannelSensorRangeH, 0);
            this.Controls.SetChildIndex(this.uiLabel10, 0);
            this.Controls.SetChildIndex(this.ChannelWarning1L, 0);
            this.Controls.SetChildIndex(this.uiLine2, 0);
            this.Controls.SetChildIndex(this.uiLabel11, 0);
            this.Controls.SetChildIndex(this.uiLine3, 0);
            this.Controls.SetChildIndex(this.uiLabel12, 0);
            this.Controls.SetChildIndex(this.uiLine4, 0);
            this.Controls.SetChildIndex(this.ChannelWarning1H, 0);
            this.Controls.SetChildIndex(this.ChannelWarning2L, 0);
            this.Controls.SetChildIndex(this.ChannelWarning2H, 0);
            this.Controls.SetChildIndex(this.ChannelWarning3L, 0);
            this.Controls.SetChildIndex(this.ChannelWarning3H, 0);
            this.Controls.SetChildIndex(this.isWraning, 0);
            this.Controls.SetChildIndex(this.pnlBtm, 0);
            this.Controls.SetChildIndex(this.ChannelType, 0);
            this.Controls.SetChildIndex(this.uiLabel8, 0);
            this.Controls.SetChildIndex(this.ChannelTypeRead, 0);
            this.Controls.SetChildIndex(this.ChannelTypeWrite, 0);
            this.Controls.SetChildIndex(this.uiLabel6, 0);
            this.Controls.SetChildIndex(this.ChannelDecimalPlaces, 0);
            this.Controls.SetChildIndex(this.ChannelSensorId, 0);
            this.Controls.SetChildIndex(this.uiLabel13, 0);
            this.Controls.SetChildIndex(this.uiLabel14, 0);
            this.Controls.SetChildIndex(this.uiTextBox1, 0);
            this.Controls.SetChildIndex(this.uiLabel15, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UILabel uiLabel3;
        public Sunny.UI.UITextBox ChannelName;
        private Sunny.UI.UILabel uiLabel2;
        public Sunny.UI.UIComboBox ChannelUnit;
        public Sunny.UI.UITextBox ChannelID;
        private Sunny.UI.UILabel uiLabel1;
        public Sunny.UI.UITextBox ChannelLabel;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UILabel uiLabel5;
        public Sunny.UI.UIComboBox ChannelSensorType;
        public Sunny.UI.UITextBox ChannelSensorName;
        private Sunny.UI.UILabel uiLabel9;
        public Sunny.UI.UITextBox ChannelSensorRangeL;
        public Sunny.UI.UITextBox ChannelSensorRangeH;
        private Sunny.UI.UILine uiLine1;
        private Sunny.UI.UILabel uiLabel10;
        public Sunny.UI.UITextBox ChannelWarning1L;
        private Sunny.UI.UILine uiLine2;
        public Sunny.UI.UITextBox ChannelWarning1H;
        private Sunny.UI.UILabel uiLabel12;
        public Sunny.UI.UITextBox ChannelWarning3L;
        private Sunny.UI.UILine uiLine4;
        public Sunny.UI.UITextBox ChannelWarning3H;
        public Sunny.UI.UITextBox ChannelWarning2H;
        private Sunny.UI.UILine uiLine3;
        public Sunny.UI.UITextBox ChannelWarning2L;
        private Sunny.UI.UILabel uiLabel11;
        private Sunny.UI.UIButton ChannelTypeWrite;
        private Sunny.UI.UIButton ChannelTypeRead;
        private Sunny.UI.UILabel uiLabel8;
        public Sunny.UI.UIComboBox ChannelType;
        private Sunny.UI.UILabel uiLabel6;
        public Sunny.UI.UIComboBox ChannelDecimalPlaces;
        public Sunny.UI.UICheckBox isWraning;
        private Sunny.UI.UILabel uiLabel13;
        public Sunny.UI.UIComboBox ChannelSensorId;
        private Sunny.UI.UILabel uiLabel14;
        public Sunny.UI.UITextBox uiTextBox1;
        private Sunny.UI.UILabel uiLabel15;
    }
}