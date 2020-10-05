namespace ModbusRTU_TP1608
{
    partial class F_ChennalInfo
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
            this.chennalName = new Sunny.UI.UITextBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.chennalUnit = new Sunny.UI.UIComboBox();
            this.chennalID = new Sunny.UI.UITextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.chennalLabel = new Sunny.UI.UITextBox();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.chennalDecimalPlaces = new Sunny.UI.UIComboBox();
            this.uiLabel8 = new Sunny.UI.UILabel();
            this.chennalType = new Sunny.UI.UIComboBox();
            this.uiLabel7 = new Sunny.UI.UILabel();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.chennalSensorType = new Sunny.UI.UIComboBox();
            this.chennalSensorName = new Sunny.UI.UITextBox();
            this.uiLabel9 = new Sunny.UI.UILabel();
            this.chennalSensorRangeL = new Sunny.UI.UITextBox();
            this.chennalSensorRangeH = new Sunny.UI.UITextBox();
            this.uiLine1 = new Sunny.UI.UILine();
            this.uiLabel10 = new Sunny.UI.UILabel();
            this.chennalWarning1L = new Sunny.UI.UITextBox();
            this.uiLine2 = new Sunny.UI.UILine();
            this.uiLine3 = new Sunny.UI.UILine();
            this.uiLabel11 = new Sunny.UI.UILabel();
            this.uiLine4 = new Sunny.UI.UILine();
            this.uiLabel12 = new Sunny.UI.UILabel();
            this.chennalSensorRangeUnit = new System.Windows.Forms.Label();
            this.chennalWarning1Unit = new System.Windows.Forms.Label();
            this.chennalWarning1H = new Sunny.UI.UITextBox();
            this.chennalWarning2L = new Sunny.UI.UITextBox();
            this.chennalWarning2Unit = new System.Windows.Forms.Label();
            this.chennalWarning2H = new Sunny.UI.UITextBox();
            this.chennalWarning3L = new Sunny.UI.UITextBox();
            this.chennalWarning3Unit = new System.Windows.Forms.Label();
            this.chennalWarning3H = new Sunny.UI.UITextBox();
            this.SuspendLayout();
            // 
            // pnlBtm
            // 
            this.pnlBtm.Location = new System.Drawing.Point(1, 389);
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
            // chennalName
            // 
            this.chennalName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.chennalName.FillColor = System.Drawing.Color.White;
            this.chennalName.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.chennalName.Location = new System.Drawing.Point(122, 60);
            this.chennalName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chennalName.Maximum = 2147483647D;
            this.chennalName.Minimum = -2147483648D;
            this.chennalName.Name = "chennalName";
            this.chennalName.Padding = new System.Windows.Forms.Padding(5);
            this.chennalName.Radius = 8;
            this.chennalName.Size = new System.Drawing.Size(200, 29);
            this.chennalName.TabIndex = 22;
            this.chennalName.Watermark = "";
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
            // chennalUnit
            // 
            this.chennalUnit.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.chennalUnit.FillColor = System.Drawing.Color.White;
            this.chennalUnit.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.chennalUnit.Items.AddRange(new object[] {
            "ppm",
            "℃"});
            this.chennalUnit.Location = new System.Drawing.Point(442, 99);
            this.chennalUnit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chennalUnit.MinimumSize = new System.Drawing.Size(63, 0);
            this.chennalUnit.Name = "chennalUnit";
            this.chennalUnit.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.chennalUnit.Radius = 8;
            this.chennalUnit.Size = new System.Drawing.Size(200, 29);
            this.chennalUnit.TabIndex = 20;
            this.chennalUnit.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.chennalUnit.Watermark = "";
            this.chennalUnit.SelectedIndexChanged += new System.EventHandler(this.chennalUnit_SelectedIndexChanged);
            // 
            // chennalID
            // 
            this.chennalID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.chennalID.FillColor = System.Drawing.Color.White;
            this.chennalID.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.chennalID.Location = new System.Drawing.Point(442, 60);
            this.chennalID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chennalID.Maximum = 2147483647D;
            this.chennalID.Minimum = -2147483648D;
            this.chennalID.Name = "chennalID";
            this.chennalID.Padding = new System.Windows.Forms.Padding(5);
            this.chennalID.Radius = 8;
            this.chennalID.Size = new System.Drawing.Size(200, 29);
            this.chennalID.TabIndex = 24;
            this.chennalID.Watermark = "";
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
            // chennalLabel
            // 
            this.chennalLabel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.chennalLabel.FillColor = System.Drawing.Color.White;
            this.chennalLabel.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.chennalLabel.Location = new System.Drawing.Point(122, 99);
            this.chennalLabel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chennalLabel.Maximum = 2147483647D;
            this.chennalLabel.Minimum = -2147483648D;
            this.chennalLabel.Name = "chennalLabel";
            this.chennalLabel.Padding = new System.Windows.Forms.Padding(5);
            this.chennalLabel.Radius = 8;
            this.chennalLabel.Size = new System.Drawing.Size(200, 29);
            this.chennalLabel.TabIndex = 25;
            this.chennalLabel.Watermark = "";
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
            // uiLabel6
            // 
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel6.Location = new System.Drawing.Point(340, 141);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(100, 23);
            this.uiLabel6.TabIndex = 32;
            this.uiLabel6.Text = "小数位：";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chennalDecimalPlaces
            // 
            this.chennalDecimalPlaces.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.chennalDecimalPlaces.FillColor = System.Drawing.Color.White;
            this.chennalDecimalPlaces.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.chennalDecimalPlaces.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.chennalDecimalPlaces.Location = new System.Drawing.Point(442, 138);
            this.chennalDecimalPlaces.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chennalDecimalPlaces.MinimumSize = new System.Drawing.Size(63, 0);
            this.chennalDecimalPlaces.Name = "chennalDecimalPlaces";
            this.chennalDecimalPlaces.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.chennalDecimalPlaces.Radius = 8;
            this.chennalDecimalPlaces.Size = new System.Drawing.Size(200, 29);
            this.chennalDecimalPlaces.TabIndex = 31;
            this.chennalDecimalPlaces.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.chennalDecimalPlaces.Watermark = "";
            // 
            // uiLabel8
            // 
            this.uiLabel8.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel8.Location = new System.Drawing.Point(8, 141);
            this.uiLabel8.Name = "uiLabel8";
            this.uiLabel8.Size = new System.Drawing.Size(112, 23);
            this.uiLabel8.TabIndex = 35;
            this.uiLabel8.Text = "通道类型：";
            this.uiLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chennalType
            // 
            this.chennalType.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.chennalType.FillColor = System.Drawing.Color.White;
            this.chennalType.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.chennalType.Location = new System.Drawing.Point(122, 138);
            this.chennalType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chennalType.MinimumSize = new System.Drawing.Size(63, 0);
            this.chennalType.Name = "chennalType";
            this.chennalType.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.chennalType.Radius = 8;
            this.chennalType.Size = new System.Drawing.Size(200, 29);
            this.chennalType.TabIndex = 34;
            this.chennalType.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.chennalType.Watermark = "";
            // 
            // uiLabel7
            // 
            this.uiLabel7.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel7.Location = new System.Drawing.Point(329, 180);
            this.uiLabel7.Name = "uiLabel7";
            this.uiLabel7.Size = new System.Drawing.Size(111, 23);
            this.uiLabel7.TabIndex = 39;
            this.uiLabel7.Text = "传感器名称：";
            this.uiLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel5.Location = new System.Drawing.Point(4, 180);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(116, 23);
            this.uiLabel5.TabIndex = 38;
            this.uiLabel5.Text = "传感器类型：";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chennalSensorType
            // 
            this.chennalSensorType.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.chennalSensorType.FillColor = System.Drawing.Color.White;
            this.chennalSensorType.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.chennalSensorType.Location = new System.Drawing.Point(122, 177);
            this.chennalSensorType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chennalSensorType.MinimumSize = new System.Drawing.Size(63, 0);
            this.chennalSensorType.Name = "chennalSensorType";
            this.chennalSensorType.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.chennalSensorType.Radius = 8;
            this.chennalSensorType.Size = new System.Drawing.Size(200, 29);
            this.chennalSensorType.TabIndex = 37;
            this.chennalSensorType.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.chennalSensorType.Watermark = "";
            // 
            // chennalSensorName
            // 
            this.chennalSensorName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.chennalSensorName.FillColor = System.Drawing.Color.White;
            this.chennalSensorName.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.chennalSensorName.Location = new System.Drawing.Point(442, 177);
            this.chennalSensorName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chennalSensorName.Maximum = 2147483647D;
            this.chennalSensorName.Minimum = -2147483648D;
            this.chennalSensorName.Name = "chennalSensorName";
            this.chennalSensorName.Padding = new System.Windows.Forms.Padding(5);
            this.chennalSensorName.Radius = 8;
            this.chennalSensorName.Size = new System.Drawing.Size(200, 29);
            this.chennalSensorName.TabIndex = 36;
            this.chennalSensorName.Watermark = "";
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
            // chennalSensorRangeL
            // 
            this.chennalSensorRangeL.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.chennalSensorRangeL.FillColor = System.Drawing.Color.White;
            this.chennalSensorRangeL.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.chennalSensorRangeL.Location = new System.Drawing.Point(122, 216);
            this.chennalSensorRangeL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chennalSensorRangeL.Maximum = 2147483647D;
            this.chennalSensorRangeL.Minimum = -2147483648D;
            this.chennalSensorRangeL.Name = "chennalSensorRangeL";
            this.chennalSensorRangeL.Padding = new System.Windows.Forms.Padding(5);
            this.chennalSensorRangeL.Radius = 8;
            this.chennalSensorRangeL.Size = new System.Drawing.Size(150, 29);
            this.chennalSensorRangeL.TabIndex = 41;
            this.chennalSensorRangeL.Text = "0.00";
            this.chennalSensorRangeL.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.chennalSensorRangeL.Watermark = "";
            // 
            // chennalSensorRangeH
            // 
            this.chennalSensorRangeH.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.chennalSensorRangeH.FillColor = System.Drawing.Color.White;
            this.chennalSensorRangeH.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.chennalSensorRangeH.Location = new System.Drawing.Point(418, 216);
            this.chennalSensorRangeH.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chennalSensorRangeH.Maximum = 2147483647D;
            this.chennalSensorRangeH.Minimum = -2147483648D;
            this.chennalSensorRangeH.Name = "chennalSensorRangeH";
            this.chennalSensorRangeH.Padding = new System.Windows.Forms.Padding(5);
            this.chennalSensorRangeH.Radius = 8;
            this.chennalSensorRangeH.Size = new System.Drawing.Size(150, 29);
            this.chennalSensorRangeH.TabIndex = 42;
            this.chennalSensorRangeH.Text = "0.00";
            this.chennalSensorRangeH.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.chennalSensorRangeH.Watermark = "";
            // 
            // uiLine1
            // 
            this.uiLine1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine1.Location = new System.Drawing.Point(299, 216);
            this.uiLine1.MinimumSize = new System.Drawing.Size(2, 2);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(91, 29);
            this.uiLine1.TabIndex = 43;
            // 
            // uiLabel10
            // 
            this.uiLabel10.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel10.Location = new System.Drawing.Point(5, 258);
            this.uiLabel10.Name = "uiLabel10";
            this.uiLabel10.Size = new System.Drawing.Size(116, 23);
            this.uiLabel10.TabIndex = 44;
            this.uiLabel10.Text = "一级报警：";
            this.uiLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chennalWarning1L
            // 
            this.chennalWarning1L.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.chennalWarning1L.FillColor = System.Drawing.Color.White;
            this.chennalWarning1L.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.chennalWarning1L.Location = new System.Drawing.Point(122, 255);
            this.chennalWarning1L.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chennalWarning1L.Maximum = 2147483647D;
            this.chennalWarning1L.Minimum = -2147483648D;
            this.chennalWarning1L.Name = "chennalWarning1L";
            this.chennalWarning1L.Padding = new System.Windows.Forms.Padding(5);
            this.chennalWarning1L.Radius = 8;
            this.chennalWarning1L.Size = new System.Drawing.Size(150, 29);
            this.chennalWarning1L.TabIndex = 45;
            this.chennalWarning1L.Text = "0.00";
            this.chennalWarning1L.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.chennalWarning1L.Watermark = "";
            // 
            // uiLine2
            // 
            this.uiLine2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine2.Location = new System.Drawing.Point(299, 255);
            this.uiLine2.MinimumSize = new System.Drawing.Size(2, 2);
            this.uiLine2.Name = "uiLine2";
            this.uiLine2.Size = new System.Drawing.Size(91, 29);
            this.uiLine2.TabIndex = 47;
            // 
            // uiLine3
            // 
            this.uiLine3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine3.Location = new System.Drawing.Point(299, 294);
            this.uiLine3.MinimumSize = new System.Drawing.Size(2, 2);
            this.uiLine3.Name = "uiLine3";
            this.uiLine3.Size = new System.Drawing.Size(91, 29);
            this.uiLine3.TabIndex = 51;
            // 
            // uiLabel11
            // 
            this.uiLabel11.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel11.Location = new System.Drawing.Point(5, 297);
            this.uiLabel11.Name = "uiLabel11";
            this.uiLabel11.Size = new System.Drawing.Size(116, 23);
            this.uiLabel11.TabIndex = 48;
            this.uiLabel11.Text = "二级报警：";
            this.uiLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiLine4
            // 
            this.uiLine4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine4.Location = new System.Drawing.Point(299, 333);
            this.uiLine4.MinimumSize = new System.Drawing.Size(2, 2);
            this.uiLine4.Name = "uiLine4";
            this.uiLine4.Size = new System.Drawing.Size(91, 29);
            this.uiLine4.TabIndex = 55;
            // 
            // uiLabel12
            // 
            this.uiLabel12.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel12.Location = new System.Drawing.Point(5, 335);
            this.uiLabel12.Name = "uiLabel12";
            this.uiLabel12.Size = new System.Drawing.Size(116, 23);
            this.uiLabel12.TabIndex = 52;
            this.uiLabel12.Text = "三级报警：";
            this.uiLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chennalSensorRangeUnit
            // 
            this.chennalSensorRangeUnit.AutoSize = true;
            this.chennalSensorRangeUnit.Location = new System.Drawing.Point(587, 219);
            this.chennalSensorRangeUnit.Margin = new System.Windows.Forms.Padding(0);
            this.chennalSensorRangeUnit.Name = "chennalSensorRangeUnit";
            this.chennalSensorRangeUnit.Size = new System.Drawing.Size(42, 21);
            this.chennalSensorRangeUnit.TabIndex = 58;
            this.chennalSensorRangeUnit.Text = "单位";
            // 
            // chennalWarning1Unit
            // 
            this.chennalWarning1Unit.AutoSize = true;
            this.chennalWarning1Unit.Location = new System.Drawing.Point(587, 259);
            this.chennalWarning1Unit.Margin = new System.Windows.Forms.Padding(0);
            this.chennalWarning1Unit.Name = "chennalWarning1Unit";
            this.chennalWarning1Unit.Size = new System.Drawing.Size(42, 21);
            this.chennalWarning1Unit.TabIndex = 61;
            this.chennalWarning1Unit.Text = "单位";
            // 
            // chennalWarning1H
            // 
            this.chennalWarning1H.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.chennalWarning1H.FillColor = System.Drawing.Color.White;
            this.chennalWarning1H.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.chennalWarning1H.Location = new System.Drawing.Point(418, 255);
            this.chennalWarning1H.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chennalWarning1H.Maximum = 2147483647D;
            this.chennalWarning1H.Minimum = -2147483648D;
            this.chennalWarning1H.Name = "chennalWarning1H";
            this.chennalWarning1H.Padding = new System.Windows.Forms.Padding(5);
            this.chennalWarning1H.Radius = 8;
            this.chennalWarning1H.Size = new System.Drawing.Size(150, 29);
            this.chennalWarning1H.TabIndex = 60;
            this.chennalWarning1H.Text = "0.00";
            this.chennalWarning1H.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.chennalWarning1H.Watermark = "";
            // 
            // chennalWarning2L
            // 
            this.chennalWarning2L.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.chennalWarning2L.FillColor = System.Drawing.Color.White;
            this.chennalWarning2L.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.chennalWarning2L.Location = new System.Drawing.Point(122, 294);
            this.chennalWarning2L.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chennalWarning2L.Maximum = 2147483647D;
            this.chennalWarning2L.Minimum = -2147483648D;
            this.chennalWarning2L.Name = "chennalWarning2L";
            this.chennalWarning2L.Padding = new System.Windows.Forms.Padding(5);
            this.chennalWarning2L.Radius = 8;
            this.chennalWarning2L.Size = new System.Drawing.Size(150, 29);
            this.chennalWarning2L.TabIndex = 62;
            this.chennalWarning2L.Text = "0.00";
            this.chennalWarning2L.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.chennalWarning2L.Watermark = "";
            // 
            // chennalWarning2Unit
            // 
            this.chennalWarning2Unit.AutoSize = true;
            this.chennalWarning2Unit.Location = new System.Drawing.Point(587, 298);
            this.chennalWarning2Unit.Margin = new System.Windows.Forms.Padding(0);
            this.chennalWarning2Unit.Name = "chennalWarning2Unit";
            this.chennalWarning2Unit.Size = new System.Drawing.Size(42, 21);
            this.chennalWarning2Unit.TabIndex = 65;
            this.chennalWarning2Unit.Text = "单位";
            // 
            // chennalWarning2H
            // 
            this.chennalWarning2H.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.chennalWarning2H.FillColor = System.Drawing.Color.White;
            this.chennalWarning2H.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.chennalWarning2H.Location = new System.Drawing.Point(418, 294);
            this.chennalWarning2H.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chennalWarning2H.Maximum = 2147483647D;
            this.chennalWarning2H.Minimum = -2147483648D;
            this.chennalWarning2H.Name = "chennalWarning2H";
            this.chennalWarning2H.Padding = new System.Windows.Forms.Padding(5);
            this.chennalWarning2H.Radius = 8;
            this.chennalWarning2H.Size = new System.Drawing.Size(150, 29);
            this.chennalWarning2H.TabIndex = 64;
            this.chennalWarning2H.Text = "0.00";
            this.chennalWarning2H.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.chennalWarning2H.Watermark = "";
            // 
            // chennalWarning3L
            // 
            this.chennalWarning3L.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.chennalWarning3L.FillColor = System.Drawing.Color.White;
            this.chennalWarning3L.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.chennalWarning3L.Location = new System.Drawing.Point(122, 332);
            this.chennalWarning3L.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chennalWarning3L.Maximum = 2147483647D;
            this.chennalWarning3L.Minimum = -2147483648D;
            this.chennalWarning3L.Name = "chennalWarning3L";
            this.chennalWarning3L.Padding = new System.Windows.Forms.Padding(5);
            this.chennalWarning3L.Radius = 8;
            this.chennalWarning3L.Size = new System.Drawing.Size(150, 29);
            this.chennalWarning3L.TabIndex = 66;
            this.chennalWarning3L.Text = "0.00";
            this.chennalWarning3L.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.chennalWarning3L.Watermark = "";
            // 
            // chennalWarning3Unit
            // 
            this.chennalWarning3Unit.AutoSize = true;
            this.chennalWarning3Unit.Location = new System.Drawing.Point(587, 336);
            this.chennalWarning3Unit.Margin = new System.Windows.Forms.Padding(0);
            this.chennalWarning3Unit.Name = "chennalWarning3Unit";
            this.chennalWarning3Unit.Size = new System.Drawing.Size(42, 21);
            this.chennalWarning3Unit.TabIndex = 69;
            this.chennalWarning3Unit.Text = "单位";
            // 
            // chennalWarning3H
            // 
            this.chennalWarning3H.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.chennalWarning3H.FillColor = System.Drawing.Color.White;
            this.chennalWarning3H.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.chennalWarning3H.Location = new System.Drawing.Point(418, 332);
            this.chennalWarning3H.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chennalWarning3H.Maximum = 2147483647D;
            this.chennalWarning3H.Minimum = -2147483648D;
            this.chennalWarning3H.Name = "chennalWarning3H";
            this.chennalWarning3H.Padding = new System.Windows.Forms.Padding(5);
            this.chennalWarning3H.Radius = 8;
            this.chennalWarning3H.Size = new System.Drawing.Size(150, 29);
            this.chennalWarning3H.TabIndex = 68;
            this.chennalWarning3H.Text = "0.00";
            this.chennalWarning3H.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.chennalWarning3H.Watermark = "";
            // 
            // F_ChennalInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 447);
            this.Controls.Add(this.chennalWarning3Unit);
            this.Controls.Add(this.chennalWarning3H);
            this.Controls.Add(this.chennalWarning3L);
            this.Controls.Add(this.chennalWarning2Unit);
            this.Controls.Add(this.chennalWarning2H);
            this.Controls.Add(this.chennalWarning2L);
            this.Controls.Add(this.chennalWarning1Unit);
            this.Controls.Add(this.chennalWarning1H);
            this.Controls.Add(this.chennalSensorRangeUnit);
            this.Controls.Add(this.uiLine4);
            this.Controls.Add(this.uiLabel12);
            this.Controls.Add(this.uiLine3);
            this.Controls.Add(this.uiLabel11);
            this.Controls.Add(this.uiLine2);
            this.Controls.Add(this.chennalWarning1L);
            this.Controls.Add(this.uiLabel10);
            this.Controls.Add(this.chennalSensorRangeH);
            this.Controls.Add(this.chennalSensorRangeL);
            this.Controls.Add(this.uiLabel9);
            this.Controls.Add(this.uiLabel7);
            this.Controls.Add(this.uiLabel5);
            this.Controls.Add(this.chennalSensorType);
            this.Controls.Add(this.chennalSensorName);
            this.Controls.Add(this.uiLabel8);
            this.Controls.Add(this.chennalType);
            this.Controls.Add(this.uiLabel6);
            this.Controls.Add(this.chennalDecimalPlaces);
            this.Controls.Add(this.uiLabel4);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.chennalLabel);
            this.Controls.Add(this.chennalID);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.chennalName);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.chennalUnit);
            this.Controls.Add(this.uiLine1);
            this.Name = "F_ChennalInfo";
            this.Text = "通道属性";
            this.Controls.SetChildIndex(this.uiLine1, 0);
            this.Controls.SetChildIndex(this.chennalUnit, 0);
            this.Controls.SetChildIndex(this.uiLabel2, 0);
            this.Controls.SetChildIndex(this.chennalName, 0);
            this.Controls.SetChildIndex(this.uiLabel3, 0);
            this.Controls.SetChildIndex(this.chennalID, 0);
            this.Controls.SetChildIndex(this.chennalLabel, 0);
            this.Controls.SetChildIndex(this.uiLabel1, 0);
            this.Controls.SetChildIndex(this.uiLabel4, 0);
            this.Controls.SetChildIndex(this.chennalDecimalPlaces, 0);
            this.Controls.SetChildIndex(this.uiLabel6, 0);
            this.Controls.SetChildIndex(this.chennalType, 0);
            this.Controls.SetChildIndex(this.uiLabel8, 0);
            this.Controls.SetChildIndex(this.chennalSensorName, 0);
            this.Controls.SetChildIndex(this.chennalSensorType, 0);
            this.Controls.SetChildIndex(this.uiLabel5, 0);
            this.Controls.SetChildIndex(this.uiLabel7, 0);
            this.Controls.SetChildIndex(this.uiLabel9, 0);
            this.Controls.SetChildIndex(this.chennalSensorRangeL, 0);
            this.Controls.SetChildIndex(this.chennalSensorRangeH, 0);
            this.Controls.SetChildIndex(this.uiLabel10, 0);
            this.Controls.SetChildIndex(this.chennalWarning1L, 0);
            this.Controls.SetChildIndex(this.uiLine2, 0);
            this.Controls.SetChildIndex(this.uiLabel11, 0);
            this.Controls.SetChildIndex(this.uiLine3, 0);
            this.Controls.SetChildIndex(this.uiLabel12, 0);
            this.Controls.SetChildIndex(this.uiLine4, 0);
            this.Controls.SetChildIndex(this.chennalSensorRangeUnit, 0);
            this.Controls.SetChildIndex(this.pnlBtm, 0);
            this.Controls.SetChildIndex(this.chennalWarning1H, 0);
            this.Controls.SetChildIndex(this.chennalWarning1Unit, 0);
            this.Controls.SetChildIndex(this.chennalWarning2L, 0);
            this.Controls.SetChildIndex(this.chennalWarning2H, 0);
            this.Controls.SetChildIndex(this.chennalWarning2Unit, 0);
            this.Controls.SetChildIndex(this.chennalWarning3L, 0);
            this.Controls.SetChildIndex(this.chennalWarning3H, 0);
            this.Controls.SetChildIndex(this.chennalWarning3Unit, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunny.UI.UILabel uiLabel3;
        public Sunny.UI.UITextBox chennalName;
        private Sunny.UI.UILabel uiLabel2;
        public Sunny.UI.UIComboBox chennalUnit;
        public Sunny.UI.UITextBox chennalID;
        private Sunny.UI.UILabel uiLabel1;
        public Sunny.UI.UITextBox chennalLabel;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel6;
        public Sunny.UI.UIComboBox chennalDecimalPlaces;
        private Sunny.UI.UILabel uiLabel8;
        public Sunny.UI.UIComboBox chennalType;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UILabel uiLabel5;
        public Sunny.UI.UIComboBox chennalSensorType;
        public Sunny.UI.UITextBox chennalSensorName;
        private Sunny.UI.UILabel uiLabel9;
        public Sunny.UI.UITextBox chennalSensorRangeL;
        public Sunny.UI.UITextBox chennalSensorRangeH;
        private Sunny.UI.UILine uiLine1;
        private Sunny.UI.UILabel uiLabel10;
        public Sunny.UI.UITextBox chennalWarning1L;
        private Sunny.UI.UILine uiLine2;
        private Sunny.UI.UILine uiLine3;
        private Sunny.UI.UILabel uiLabel11;
        private Sunny.UI.UILine uiLine4;
        private Sunny.UI.UILabel uiLabel12;
        private System.Windows.Forms.Label chennalSensorRangeUnit;
        private System.Windows.Forms.Label chennalWarning1Unit;
        public Sunny.UI.UITextBox chennalWarning1H;
        public Sunny.UI.UITextBox chennalWarning2L;
        private System.Windows.Forms.Label chennalWarning2Unit;
        public Sunny.UI.UITextBox chennalWarning2H;
        public Sunny.UI.UITextBox chennalWarning3L;
        private System.Windows.Forms.Label chennalWarning3Unit;
        public Sunny.UI.UITextBox chennalWarning3H;
    }
}