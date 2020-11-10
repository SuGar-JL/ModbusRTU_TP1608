namespace ModbusRTU_TP1608
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.MainContainer = new Sunny.UI.UITabControl();
            this.Aside = new Sunny.UI.UINavMenu();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.通信协议ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.实时采集ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.试图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAddDevice1 = new ModbusRTU_TP1608.UCBtnAddDevice();
            this.label1 = new System.Windows.Forms.Label();
            this.MainContainer.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(0, 40);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(450, 230);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1000, 610);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // MainContainer
            // 
            this.MainContainer.Controls.Add(this.tabPage1);
            this.MainContainer.Controls.Add(this.tabPage2);
            this.MainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainContainer.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.MainContainer.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.MainContainer.ItemSize = new System.Drawing.Size(0, 1);
            this.MainContainer.Location = new System.Drawing.Point(220, 60);
            this.MainContainer.Margin = new System.Windows.Forms.Padding(0);
            this.MainContainer.Name = "MainContainer";
            this.tableLayoutPanel1.SetRowSpan(this.MainContainer, 2);
            this.MainContainer.SelectedIndex = 0;
            this.MainContainer.Size = new System.Drawing.Size(1000, 610);
            this.MainContainer.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.MainContainer.Style = Sunny.UI.UIStyle.Custom;
            this.MainContainer.TabIndex = 0;
            this.MainContainer.TabVisible = false;
            // 
            // Aside
            // 
            this.Aside.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(19)))), ((int)(((byte)(36)))));
            this.Aside.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableLayoutPanel1.SetColumnSpan(this.Aside, 2);
            this.Aside.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Aside.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.Aside.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(19)))), ((int)(((byte)(36)))));
            this.Aside.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Aside.FullRowSelect = true;
            this.Aside.ItemHeight = 36;
            this.Aside.Location = new System.Drawing.Point(0, 60);
            this.Aside.Margin = new System.Windows.Forms.Padding(0);
            this.Aside.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.Aside.Name = "Aside";
            this.Aside.ShowLines = false;
            this.Aside.Size = new System.Drawing.Size(220, 560);
            this.Aside.Style = Sunny.UI.UIStyle.Custom;
            this.Aside.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(19)))), ((int)(((byte)(36)))));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.menuStrip1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.MainContainer, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.Aside, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAddDevice1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 35);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1220, 670);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.设置ToolStripMenuItem,
            this.查询ToolStripMenuItem,
            this.操作ToolStripMenuItem,
            this.实时采集ToolStripMenuItem,
            this.试图ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(220, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1000, 60);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(102)))), ((int)(((byte)(104)))));
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(51, 54);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.通信协议ToolStripMenuItem});
            this.设置ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(102)))), ((int)(((byte)(104)))));
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(51, 54);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // 通信协议ToolStripMenuItem
            // 
            this.通信协议ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(102)))), ((int)(((byte)(104)))));
            this.通信协议ToolStripMenuItem.Image = global::ModbusRTU_TP1608.Properties.Resources.protocol4;
            this.通信协议ToolStripMenuItem.Name = "通信协议ToolStripMenuItem";
            this.通信协议ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.通信协议ToolStripMenuItem.Text = "通信协议";
            this.通信协议ToolStripMenuItem.Click += new System.EventHandler(this.通信协议ToolStripMenuItem_Click);
            // 
            // 查询ToolStripMenuItem
            // 
            this.查询ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(102)))), ((int)(((byte)(104)))));
            this.查询ToolStripMenuItem.Name = "查询ToolStripMenuItem";
            this.查询ToolStripMenuItem.Size = new System.Drawing.Size(51, 54);
            this.查询ToolStripMenuItem.Text = "查询";
            // 
            // 操作ToolStripMenuItem
            // 
            this.操作ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(102)))), ((int)(((byte)(104)))));
            this.操作ToolStripMenuItem.Name = "操作ToolStripMenuItem";
            this.操作ToolStripMenuItem.Size = new System.Drawing.Size(51, 54);
            this.操作ToolStripMenuItem.Text = "操作";
            // 
            // 实时采集ToolStripMenuItem
            // 
            this.实时采集ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(102)))), ((int)(((byte)(104)))));
            this.实时采集ToolStripMenuItem.Name = "实时采集ToolStripMenuItem";
            this.实时采集ToolStripMenuItem.Size = new System.Drawing.Size(81, 54);
            this.实时采集ToolStripMenuItem.Text = "实时采集";
            // 
            // 试图ToolStripMenuItem
            // 
            this.试图ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(102)))), ((int)(((byte)(104)))));
            this.试图ToolStripMenuItem.Name = "试图ToolStripMenuItem";
            this.试图ToolStripMenuItem.Size = new System.Drawing.Size(51, 54);
            this.试图ToolStripMenuItem.Text = "视图";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(102)))), ((int)(((byte)(104)))));
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(51, 54);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // btnAddDevice1
            // 
            this.btnAddDevice1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(19)))), ((int)(((byte)(36)))));
            this.tableLayoutPanel1.SetColumnSpan(this.btnAddDevice1, 2);
            this.btnAddDevice1.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAddDevice1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddDevice1.Image = ((System.Drawing.Image)(resources.GetObject("btnAddDevice1.Image")));
            this.btnAddDevice1.Location = new System.Drawing.Point(0, 620);
            this.btnAddDevice1.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddDevice1.Name = "btnAddDevice1";
            this.btnAddDevice1.Size = new System.Drawing.Size(220, 50);
            this.btnAddDevice1.TabIndex = 8;
            this.btnAddDevice1.Text = "添加设备";
            this.btnAddDevice1.AddDevice += new System.EventHandler(this.btnAddDevice1_AddDevice);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(60, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.label1.Size = new System.Drawing.Size(160, 60);
            this.label1.TabIndex = 9;
            this.label1.Text = "智慧消防数据采集";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1220, 705);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(220)))));
            this.ShowIcon = true;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MainContainer.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UINavMenu Aside;
        private Sunny.UI.UITabControl MainContainer;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 实时采集ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 试图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private UCBtnAddDevice btnAddDevice1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem 通信协议ToolStripMenuItem;
    }
}