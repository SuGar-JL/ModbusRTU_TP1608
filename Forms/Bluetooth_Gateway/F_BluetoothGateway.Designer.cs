namespace ModbusRTU_TP1608.Forms.Bluetooth_Gateway
{
    partial class F_BluetoothGateway
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tB_DeviceName = new System.Windows.Forms.TextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiTB_ip = new Sunny.UI.UITextBox();
            this.uiTB_port = new Sunny.UI.UITextBox();
            this.uiBtn_ON_OFF = new Sunny.UI.UIButton();
            this.uiLight1 = new Sunny.UI.UILight();
            this.uiPagination1 = new Sunny.UI.UIPagination();
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.uiDataGridView1 = new Sunny.UI.UIDataGridView();
            this.uiLine5 = new Sunny.UI.UILine();
            this.uiPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView1)).BeginInit();
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
            this.tB_DeviceName.TabIndex = 26;
            this.tB_DeviceName.Text = "蓝牙探针";
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(278, 27);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(100, 23);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 28;
            this.uiLabel1.Text = "主机地址：";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel2.Location = new System.Drawing.Point(515, 27);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(100, 23);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 29;
            this.uiLabel2.Text = "主机端口：";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiTB_ip
            // 
            this.uiTB_ip.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTB_ip.FillColor = System.Drawing.Color.White;
            this.uiTB_ip.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiTB_ip.Location = new System.Drawing.Point(360, 26);
            this.uiTB_ip.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTB_ip.Maximum = 2147483647D;
            this.uiTB_ip.Minimum = -2147483648D;
            this.uiTB_ip.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTB_ip.Name = "uiTB_ip";
            this.uiTB_ip.Padding = new System.Windows.Forms.Padding(5);
            this.uiTB_ip.Size = new System.Drawing.Size(150, 29);
            this.uiTB_ip.Style = Sunny.UI.UIStyle.Custom;
            this.uiTB_ip.TabIndex = 30;
            this.uiTB_ip.Text = "127.0.0.1";
            // 
            // uiTB_port
            // 
            this.uiTB_port.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTB_port.DoubleValue = 10025D;
            this.uiTB_port.FillColor = System.Drawing.Color.White;
            this.uiTB_port.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiTB_port.IntValue = 10025;
            this.uiTB_port.Location = new System.Drawing.Point(597, 27);
            this.uiTB_port.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTB_port.Maximum = 2147483647D;
            this.uiTB_port.Minimum = -2147483648D;
            this.uiTB_port.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTB_port.Name = "uiTB_port";
            this.uiTB_port.Padding = new System.Windows.Forms.Padding(5);
            this.uiTB_port.Size = new System.Drawing.Size(150, 29);
            this.uiTB_port.Style = Sunny.UI.UIStyle.Custom;
            this.uiTB_port.TabIndex = 31;
            this.uiTB_port.Text = "10025";
            // 
            // uiBtn_ON_OFF
            // 
            this.uiBtn_ON_OFF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiBtn_ON_OFF.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiBtn_ON_OFF.Location = new System.Drawing.Point(785, 26);
            this.uiBtn_ON_OFF.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiBtn_ON_OFF.Name = "uiBtn_ON_OFF";
            this.uiBtn_ON_OFF.Size = new System.Drawing.Size(50, 30);
            this.uiBtn_ON_OFF.Style = Sunny.UI.UIStyle.Custom;
            this.uiBtn_ON_OFF.TabIndex = 32;
            this.uiBtn_ON_OFF.Text = "打开";
            this.uiBtn_ON_OFF.Click += new System.EventHandler(this.uiBtn_ON_OFF_Click);
            // 
            // uiLight1
            // 
            this.uiLight1.CenterColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(248)))), ((int)(((byte)(232)))));
            this.uiLight1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLight1.Location = new System.Drawing.Point(187, 22);
            this.uiLight1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLight1.Name = "uiLight1";
            this.uiLight1.Radius = 35;
            this.uiLight1.ShowLightLine = false;
            this.uiLight1.Size = new System.Drawing.Size(30, 30);
            this.uiLight1.State = Sunny.UI.UILightState.Off;
            this.uiLight1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLight1.TabIndex = 33;
            this.uiLight1.Text = "uiLight1";
            // 
            // uiPagination1
            // 
            this.uiPagination1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uiPagination1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiPagination1.Location = new System.Drawing.Point(0, 464);
            this.uiPagination1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPagination1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPagination1.Name = "uiPagination1";
            this.uiPagination1.PagerCount = 9;
            this.uiPagination1.PageSize = 10;
            this.uiPagination1.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiPagination1.Size = new System.Drawing.Size(898, 35);
            this.uiPagination1.Style = Sunny.UI.UIStyle.Custom;
            this.uiPagination1.TabIndex = 35;
            this.uiPagination1.Text = "uiPagination1";
            this.uiPagination1.PageChanged += new Sunny.UI.UIPagination.OnPageChangeEventHandler(this.uiPagination1_PageChanged);
            // 
            // uiPanel1
            // 
            this.uiPanel1.Controls.Add(this.uiDataGridView1);
            this.uiPanel1.Controls.Add(this.uiPagination1);
            this.uiPanel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiPanel1.Location = new System.Drawing.Point(50, 97);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Size = new System.Drawing.Size(898, 499);
            this.uiPanel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiPanel1.TabIndex = 36;
            this.uiPanel1.Text = "uiPanel1";
            // 
            // uiDataGridView1
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.uiDataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.uiDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.uiDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.uiDataGridView1.ColumnHeadersHeight = 32;
            this.uiDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.uiDataGridView1.DefaultCellStyle = dataGridViewCellStyle7;
            this.uiDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiDataGridView1.EnableHeadersVisualStyles = false;
            this.uiDataGridView1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiDataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.uiDataGridView1.Name = "uiDataGridView1";
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            this.uiDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.uiDataGridView1.RowTemplate.Height = 29;
            this.uiDataGridView1.SelectedIndex = -1;
            this.uiDataGridView1.ShowGridLine = true;
            this.uiDataGridView1.ShowRect = false;
            this.uiDataGridView1.Size = new System.Drawing.Size(898, 464);
            this.uiDataGridView1.Style = Sunny.UI.UIStyle.Custom;
            this.uiDataGridView1.TabIndex = 34;
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
            this.uiLine5.TabIndex = 27;
            // 
            // F_BluetoothGateway
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(1000, 610);
            this.Controls.Add(this.uiPanel1);
            this.Controls.Add(this.uiLight1);
            this.Controls.Add(this.uiBtn_ON_OFF);
            this.Controls.Add(this.uiTB_port);
            this.Controls.Add(this.uiTB_ip);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.tB_DeviceName);
            this.Controls.Add(this.uiLine5);
            this.Name = "F_BluetoothGateway";
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "F_BluetoothGateway";
            this.uiPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox tB_DeviceName;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UITextBox uiTB_ip;
        private Sunny.UI.UITextBox uiTB_port;
        private Sunny.UI.UIButton uiBtn_ON_OFF;
        private Sunny.UI.UILight uiLight1;
        private Sunny.UI.UIPagination uiPagination1;
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UIDataGridView uiDataGridView1;
        private Sunny.UI.UILine uiLine5;
    }
}