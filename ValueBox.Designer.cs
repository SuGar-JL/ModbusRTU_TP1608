namespace ModbusRTU_TP1608
{
    partial class ValueBox
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pB_Info = new System.Windows.Forms.PictureBox();
            this.tB_ChennalName = new System.Windows.Forms.TextBox();
            this.tB_DateTime = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tB_Unit = new System.Windows.Forms.TextBox();
            this.tB_Value = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pB_Info)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tB_DateTime, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.03448F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.96552F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(250, 150);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.95744F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.04255F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel2.Controls.Add(this.pB_Info, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tB_ChennalName, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(244, 30);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // pB_Info
            // 
            this.pB_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pB_Info.Location = new System.Drawing.Point(199, 3);
            this.pB_Info.Name = "pB_Info";
            this.pB_Info.Size = new System.Drawing.Size(26, 24);
            this.pB_Info.TabIndex = 0;
            this.pB_Info.TabStop = false;
            // 
            // tB_ChennalName
            // 
            this.tB_ChennalName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_ChennalName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tB_ChennalName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_ChennalName.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.tB_ChennalName.Location = new System.Drawing.Point(15, 5);
            this.tB_ChennalName.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.tB_ChennalName.Name = "tB_ChennalName";
            this.tB_ChennalName.Size = new System.Drawing.Size(178, 19);
            this.tB_ChennalName.TabIndex = 1;
            this.tB_ChennalName.Text = "数据采集-CH01";
            // 
            // tB_DateTime
            // 
            this.tB_DateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_DateTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tB_DateTime.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_DateTime.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.tB_DateTime.Location = new System.Drawing.Point(15, 123);
            this.tB_DateTime.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.tB_DateTime.Name = "tB_DateTime";
            this.tB_DateTime.Size = new System.Drawing.Size(232, 19);
            this.tB_DateTime.TabIndex = 1;
            this.tB_DateTime.Text = "2020-09-22 10:45:55.328";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.tB_Unit, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tB_Value, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 39);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.97183F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.02817F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(244, 74);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // tB_Unit
            // 
            this.tB_Unit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_Unit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tB_Unit.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_Unit.Location = new System.Drawing.Point(15, 48);
            this.tB_Unit.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.tB_Unit.Name = "tB_Unit";
            this.tB_Unit.Size = new System.Drawing.Size(226, 26);
            this.tB_Unit.TabIndex = 0;
            this.tB_Unit.Text = "℃";
            // 
            // tB_Value
            // 
            this.tB_Value.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_Value.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tB_Value.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tB_Value.Location = new System.Drawing.Point(15, 3);
            this.tB_Value.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.tB_Value.Name = "tB_Value";
            this.tB_Value.Size = new System.Drawing.Size(226, 43);
            this.tB_Value.TabIndex = 1;
            this.tB_Value.Text = "2.0000";
            // 
            // ValueBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(250, 150);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ValueBox";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pB_Info)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox pB_Info;
        private System.Windows.Forms.TextBox tB_ChennalName;
        private System.Windows.Forms.TextBox tB_DateTime;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox tB_Unit;
        private System.Windows.Forms.TextBox tB_Value;
    }
}
