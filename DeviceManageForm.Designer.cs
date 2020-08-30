namespace ModbusRTU_TP1608
{
    partial class DeviceManageForm
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
            this.tV_advice = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.啊实打实的ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.打开设备ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除设备ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设备设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.通道设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.通道设置ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.传感器设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.contextMenuStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tV_advice
            // 
            this.tV_advice.ContextMenuStrip = this.contextMenuStrip1;
            this.tV_advice.Cursor = System.Windows.Forms.Cursors.Default;
            this.tV_advice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tV_advice.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tV_advice.HotTracking = true;
            this.tV_advice.Location = new System.Drawing.Point(0, 0);
            this.tV_advice.Name = "tV_advice";
            this.tV_advice.Size = new System.Drawing.Size(249, 600);
            this.tV_advice.TabIndex = 0;
            this.tV_advice.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.啊实打实的ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 26);
            this.contextMenuStrip1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.contextMenuStrip1_MouseClick);
            // 
            // 啊实打实的ToolStripMenuItem
            // 
            this.啊实打实的ToolStripMenuItem.Name = "啊实打实的ToolStripMenuItem";
            this.啊实打实的ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.啊实打实的ToolStripMenuItem.Text = "添加设备";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开设备ToolStripMenuItem,
            this.删除设备ToolStripMenuItem,
            this.设备设置ToolStripMenuItem,
            this.通道设置ToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(125, 92);
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
            // 设备设置ToolStripMenuItem
            // 
            this.设备设置ToolStripMenuItem.Name = "设备设置ToolStripMenuItem";
            this.设备设置ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.设备设置ToolStripMenuItem.Text = "设备设置";
            this.设备设置ToolStripMenuItem.Click += new System.EventHandler(this.设备设置ToolStripMenuItem_Click);
            // 
            // 通道设置ToolStripMenuItem
            // 
            this.通道设置ToolStripMenuItem.Name = "通道设置ToolStripMenuItem";
            this.通道设置ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.通道设置ToolStripMenuItem.Text = "通道设置";
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.通道设置ToolStripMenuItem1,
            this.传感器设置ToolStripMenuItem});
            this.contextMenuStrip3.Name = "contextMenuStrip3";
            this.contextMenuStrip3.Size = new System.Drawing.Size(137, 48);
            // 
            // 通道设置ToolStripMenuItem1
            // 
            this.通道设置ToolStripMenuItem1.Name = "通道设置ToolStripMenuItem1";
            this.通道设置ToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.通道设置ToolStripMenuItem1.Text = "通道设置";
            this.通道设置ToolStripMenuItem1.Click += new System.EventHandler(this.通道设置ToolStripMenuItem1_Click);
            // 
            // 传感器设置ToolStripMenuItem
            // 
            this.传感器设置ToolStripMenuItem.Name = "传感器设置ToolStripMenuItem";
            this.传感器设置ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.传感器设置ToolStripMenuItem.Text = "传感器设置";
            this.传感器设置ToolStripMenuItem.Click += new System.EventHandler(this.传感器设置ToolStripMenuItem_Click);
            // 
            // DeviceManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(249, 600);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.tV_advice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeviceManageForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "设备管理";
            this.Load += new System.EventHandler(this.DeviceManageForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.contextMenuStrip3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tV_advice;
        private System.Windows.Forms.ToolStripMenuItem 啊实打实的ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 打开设备ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除设备ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设备设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 通道设置ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip3;
        private System.Windows.Forms.ToolStripMenuItem 通道设置ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 传感器设置ToolStripMenuItem;
    }
}