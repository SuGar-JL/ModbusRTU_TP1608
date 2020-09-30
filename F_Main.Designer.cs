namespace ModbusRTU_TP1608
{
    partial class F_Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_Main));
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加设备ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.试图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设备管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具栏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.状态栏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于DataCllectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tSB_设备管理 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.stopCollectButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip_addDevice = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加设备ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_setDevice = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.打开设备ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除设备ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.配置设备ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_setChennalAndSensor = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.通道设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.valueBox21 = new ModbusRTU_TP1608.ValueBox2();
            this.menuStrip2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip_addDevice.SuspendLayout();
            this.contextMenuStrip_setDevice.SuspendLayout();
            this.contextMenuStrip_setChennalAndSensor.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.试图ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip2.Size = new System.Drawing.Size(1102, 24);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加设备ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 添加设备ToolStripMenuItem
            // 
            this.添加设备ToolStripMenuItem.Name = "添加设备ToolStripMenuItem";
            this.添加设备ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.添加设备ToolStripMenuItem.Text = "添加设备";
            this.添加设备ToolStripMenuItem.Click += new System.EventHandler(this.添加设备ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 试图ToolStripMenuItem
            // 
            this.试图ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设备管理ToolStripMenuItem,
            this.工具栏ToolStripMenuItem,
            this.状态栏ToolStripMenuItem});
            this.试图ToolStripMenuItem.Name = "试图ToolStripMenuItem";
            this.试图ToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.试图ToolStripMenuItem.Text = "视图";
            // 
            // 设备管理ToolStripMenuItem
            // 
            this.设备管理ToolStripMenuItem.Name = "设备管理ToolStripMenuItem";
            this.设备管理ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.设备管理ToolStripMenuItem.Text = "设备管理";
            this.设备管理ToolStripMenuItem.Click += new System.EventHandler(this.设备管理ToolStripMenuItem_Click);
            // 
            // 工具栏ToolStripMenuItem
            // 
            this.工具栏ToolStripMenuItem.Name = "工具栏ToolStripMenuItem";
            this.工具栏ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.工具栏ToolStripMenuItem.Text = "工具栏";
            this.工具栏ToolStripMenuItem.Click += new System.EventHandler(this.工具栏ToolStripMenuItem_Click);
            // 
            // 状态栏ToolStripMenuItem
            // 
            this.状态栏ToolStripMenuItem.Name = "状态栏ToolStripMenuItem";
            this.状态栏ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.状态栏ToolStripMenuItem.Text = "状态栏";
            this.状态栏ToolStripMenuItem.Click += new System.EventHandler(this.状态栏ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于DataCllectionToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 关于DataCllectionToolStripMenuItem
            // 
            this.关于DataCllectionToolStripMenuItem.Name = "关于DataCllectionToolStripMenuItem";
            this.关于DataCllectionToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.关于DataCllectionToolStripMenuItem.Text = "关于DataCllection";
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(45, 45);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSB_设备管理,
            this.toolStripButton2,
            this.stopCollectButton,
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripButton7,
            this.toolStripButton8});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1102, 50);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tSB_设备管理
            // 
            this.tSB_设备管理.AutoSize = false;
            this.tSB_设备管理.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSB_设备管理.Image = ((System.Drawing.Image)(resources.GetObject("tSB_设备管理.Image")));
            this.tSB_设备管理.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSB_设备管理.Name = "tSB_设备管理";
            this.tSB_设备管理.Size = new System.Drawing.Size(45, 45);
            this.tSB_设备管理.Text = "toolStripButton1";
            this.tSB_设备管理.ToolTipText = "设备管理";
            this.tSB_设备管理.Click += new System.EventHandler(this.tSB_设备管理_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(49, 47);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.ToolTipText = "开始采集";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // stopCollectButton
            // 
            this.stopCollectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stopCollectButton.Image = global::ModbusRTU_TP1608.Properties.Resources.stop1;
            this.stopCollectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopCollectButton.Name = "stopCollectButton";
            this.stopCollectButton.Size = new System.Drawing.Size(49, 47);
            this.stopCollectButton.Text = "toolStripButton3";
            this.stopCollectButton.ToolTipText = "停止采集";
            this.stopCollectButton.Click += new System.EventHandler(this.stopCollectButton_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(49, 47);
            this.toolStripButton4.Text = "toolStripButton4";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(49, 47);
            this.toolStripButton5.Text = "toolStripButton5";
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(49, 47);
            this.toolStripButton6.Text = "toolStripButton6";
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(49, 47);
            this.toolStripButton7.Text = "toolStripButton7";
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(49, 47);
            this.toolStripButton8.Text = "toolStripButton8";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 558);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 8, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1102, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(32, 17);
            this.toolStripStatusLabel1.Text = "就绪";
            // 
            // contextMenuStrip_addDevice
            // 
            this.contextMenuStrip_addDevice.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加设备ToolStripMenuItem1});
            this.contextMenuStrip_addDevice.Name = "contextMenuStrip_addDevice";
            this.contextMenuStrip_addDevice.Size = new System.Drawing.Size(125, 26);
            // 
            // 添加设备ToolStripMenuItem1
            // 
            this.添加设备ToolStripMenuItem1.Name = "添加设备ToolStripMenuItem1";
            this.添加设备ToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.添加设备ToolStripMenuItem1.Text = "添加设备";
            this.添加设备ToolStripMenuItem1.Click += new System.EventHandler(this.添加设备ToolStripMenuItem1_Click);
            // 
            // contextMenuStrip_setDevice
            // 
            this.contextMenuStrip_setDevice.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开设备ToolStripMenuItem,
            this.删除设备ToolStripMenuItem,
            this.配置设备ToolStripMenuItem});
            this.contextMenuStrip_setDevice.Name = "contextMenuStrip_setDevice";
            this.contextMenuStrip_setDevice.Size = new System.Drawing.Size(125, 70);
            // 
            // 打开设备ToolStripMenuItem
            // 
            this.打开设备ToolStripMenuItem.Name = "打开设备ToolStripMenuItem";
            this.打开设备ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.打开设备ToolStripMenuItem.Text = "打开设备";
            this.打开设备ToolStripMenuItem.Click += new System.EventHandler(this.打开设备ToolStripMenuItem_Click);
            // 
            // 删除设备ToolStripMenuItem
            // 
            this.删除设备ToolStripMenuItem.Name = "删除设备ToolStripMenuItem";
            this.删除设备ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.删除设备ToolStripMenuItem.Text = "删除设备";
            this.删除设备ToolStripMenuItem.Click += new System.EventHandler(this.删除设备ToolStripMenuItem_Click);
            // 
            // 配置设备ToolStripMenuItem
            // 
            this.配置设备ToolStripMenuItem.Name = "配置设备ToolStripMenuItem";
            this.配置设备ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.配置设备ToolStripMenuItem.Text = "配置设备";
            this.配置设备ToolStripMenuItem.Click += new System.EventHandler(this.配置设备ToolStripMenuItem_Click);
            // 
            // contextMenuStrip_setChennalAndSensor
            // 
            this.contextMenuStrip_setChennalAndSensor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.通道设置ToolStripMenuItem});
            this.contextMenuStrip_setChennalAndSensor.Name = "contextMenuStrip_setChennalAndSensor";
            this.contextMenuStrip_setChennalAndSensor.Size = new System.Drawing.Size(125, 26);
            // 
            // 通道设置ToolStripMenuItem
            // 
            this.通道设置ToolStripMenuItem.Name = "通道设置ToolStripMenuItem";
            this.通道设置ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.通道设置ToolStripMenuItem.Text = "通道设置";
            this.通道设置ToolStripMenuItem.Click += new System.EventHandler(this.通道设置ToolStripMenuItem_Click);
            // 
            // dockPanel1
            // 
            this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Size = new System.Drawing.Size(1102, 580);
            this.dockPanel1.TabIndex = 8;
            // 
            // valueBox21
            // 
            this.valueBox21.BackColor = System.Drawing.Color.White;
            this.valueBox21.Location = new System.Drawing.Point(208, 173);
            this.valueBox21.Name = "valueBox21";
            this.valueBox21.Size = new System.Drawing.Size(310, 200);
            this.valueBox21.TabIndex = 15;
            // 
            // F_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 580);
            this.Controls.Add(this.valueBox21);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.dockPanel1);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(621, 321);
            this.Name = "F_Main";
            this.Text = "DataCollection";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DataCollectionForm_FormClosed);
            this.Load += new System.EventHandler(this.DataCollection_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip_addDevice.ResumeLayout(false);
            this.contextMenuStrip_setDevice.ResumeLayout(false);
            this.contextMenuStrip_setChennalAndSensor.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加设备ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 试图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设备管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工具栏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 状态栏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于DataCllectionToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tSB_设备管理;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton stopCollectButton;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_addDevice;
        private System.Windows.Forms.ToolStripMenuItem 添加设备ToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_setDevice;
        private System.Windows.Forms.ToolStripMenuItem 打开设备ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除设备ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 配置设备ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_setChennalAndSensor;
        private System.Windows.Forms.ToolStripMenuItem 通道设置ToolStripMenuItem;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
        private System.IO.Ports.SerialPort serialPort1;
        private ValueBox2 valueBox21;
    }
}