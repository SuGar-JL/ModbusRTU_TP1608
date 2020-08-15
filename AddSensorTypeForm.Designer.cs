namespace ModbusRTU_TP1608
{
    partial class AddSensorTypeForm
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
            this.label_sensorTypeName = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label_dbTableName = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_ok = new System.Windows.Forms.Button();
            this.button_no = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_sensorTypeName
            // 
            this.label_sensorTypeName.AutoSize = true;
            this.label_sensorTypeName.Location = new System.Drawing.Point(47, 20);
            this.label_sensorTypeName.Name = "label_sensorTypeName";
            this.label_sensorTypeName.Size = new System.Drawing.Size(65, 12);
            this.label_sensorTypeName.TabIndex = 0;
            this.label_sensorTypeName.Text = "类型名称：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(118, 17);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 1;
            // 
            // label_dbTableName
            // 
            this.label_dbTableName.AutoSize = true;
            this.label_dbTableName.Location = new System.Drawing.Point(23, 51);
            this.label_dbTableName.Name = "label_dbTableName";
            this.label_dbTableName.Size = new System.Drawing.Size(89, 12);
            this.label_dbTableName.TabIndex = 2;
            this.label_dbTableName.Text = "数据库表名称：";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(118, 48);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(224, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "注：英文字母与“_”";
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(49, 112);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 5;
            this.button_ok.Text = "确定";
            this.button_ok.UseVisualStyleBackColor = true;
            // 
            // button_no
            // 
            this.button_no.Location = new System.Drawing.Point(212, 112);
            this.button_no.Name = "button_no";
            this.button_no.Size = new System.Drawing.Size(75, 23);
            this.button_no.TabIndex = 6;
            this.button_no.Text = "取消";
            this.button_no.UseVisualStyleBackColor = true;
            // 
            // AddSensorTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 147);
            this.Controls.Add(this.button_no);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label_dbTableName);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label_sensorTypeName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddSensorTypeForm";
            this.ShowIcon = false;
            this.Text = "传感器类型管理";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_sensorTypeName;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label_dbTableName;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_no;
    }
}