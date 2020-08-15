namespace ModbusRTU_TP1608
{
    partial class SetSensorForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_sensorName = new System.Windows.Forms.TextBox();
            this.button_addSensorType = new System.Windows.Forms.Button();
            this.textBox_sensorLabel = new System.Windows.Forms.TextBox();
            this.textBox_sensorUnit = new System.Windows.Forms.TextBox();
            this.comboBox_sensorType = new System.Windows.Forms.ComboBox();
            this.button_ok = new System.Windows.Forms.Button();
            this.button_no = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "传感器名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "传感器类型：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "监测项：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "监测单位：";
            // 
            // textBox_sensorName
            // 
            this.textBox_sensorName.Location = new System.Drawing.Point(103, 17);
            this.textBox_sensorName.Name = "textBox_sensorName";
            this.textBox_sensorName.Size = new System.Drawing.Size(119, 21);
            this.textBox_sensorName.TabIndex = 5;
            // 
            // button_addSensorType
            // 
            this.button_addSensorType.Location = new System.Drawing.Point(103, 95);
            this.button_addSensorType.Name = "button_addSensorType";
            this.button_addSensorType.Size = new System.Drawing.Size(119, 23);
            this.button_addSensorType.TabIndex = 7;
            this.button_addSensorType.Text = "传感器类型管理";
            this.button_addSensorType.UseVisualStyleBackColor = true;
            this.button_addSensorType.Click += new System.EventHandler(this.button_addSensorType_Click);
            // 
            // textBox_sensorLabel
            // 
            this.textBox_sensorLabel.Location = new System.Drawing.Point(103, 136);
            this.textBox_sensorLabel.Name = "textBox_sensorLabel";
            this.textBox_sensorLabel.Size = new System.Drawing.Size(119, 21);
            this.textBox_sensorLabel.TabIndex = 8;
            // 
            // textBox_sensorUnit
            // 
            this.textBox_sensorUnit.Location = new System.Drawing.Point(103, 176);
            this.textBox_sensorUnit.Name = "textBox_sensorUnit";
            this.textBox_sensorUnit.ReadOnly = true;
            this.textBox_sensorUnit.Size = new System.Drawing.Size(119, 21);
            this.textBox_sensorUnit.TabIndex = 9;
            // 
            // comboBox_sensorType
            // 
            this.comboBox_sensorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_sensorType.FormattingEnabled = true;
            this.comboBox_sensorType.Items.AddRange(new object[] {
            "CO2",
            "PM10"});
            this.comboBox_sensorType.Location = new System.Drawing.Point(103, 55);
            this.comboBox_sensorType.Name = "comboBox_sensorType";
            this.comboBox_sensorType.Size = new System.Drawing.Size(119, 20);
            this.comboBox_sensorType.TabIndex = 10;
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(25, 223);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 11;
            this.button_ok.Text = "确定";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // button_no
            // 
            this.button_no.Location = new System.Drawing.Point(147, 223);
            this.button_no.Name = "button_no";
            this.button_no.Size = new System.Drawing.Size(75, 23);
            this.button_no.TabIndex = 12;
            this.button_no.Text = "取消";
            this.button_no.UseVisualStyleBackColor = true;
            this.button_no.Click += new System.EventHandler(this.button_no_Click);
            // 
            // SetSensorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 270);
            this.Controls.Add(this.button_no);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.comboBox_sensorType);
            this.Controls.Add(this.textBox_sensorUnit);
            this.Controls.Add(this.textBox_sensorLabel);
            this.Controls.Add(this.button_addSensorType);
            this.Controls.Add(this.textBox_sensorName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetSensorForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "配置传感器";
            this.Load += new System.EventHandler(this.SetSensorForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_sensorName;
        private System.Windows.Forms.Button button_addSensorType;
        private System.Windows.Forms.TextBox textBox_sensorLabel;
        private System.Windows.Forms.TextBox textBox_sensorUnit;
        private System.Windows.Forms.ComboBox comboBox_sensorType;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_no;
    }
}