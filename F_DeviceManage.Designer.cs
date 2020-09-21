namespace ModbusRTU_TP1608
{
    partial class F_DeviceManage
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
            this.cMS_添加设备 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSMI_添加设备 = new System.Windows.Forms.ToolStripMenuItem();
            this.cMS_设备右键菜单 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSMI_打开设备 = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_删除设备 = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_设备设置 = new System.Windows.Forms.ToolStripMenuItem();
            this.cMS_通道右键菜单 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSMI_通道设置 = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_传感器设置 = new System.Windows.Forms.ToolStripMenuItem();
            this.cMS_添加设备.SuspendLayout();
            this.cMS_设备右键菜单.SuspendLayout();
            this.cMS_通道右键菜单.SuspendLayout();
            this.SuspendLayout();
            // 
            // tV_advice
            // 
            this.tV_advice.ContextMenuStrip = this.cMS_添加设备;
            this.tV_advice.Cursor = System.Windows.Forms.Cursors.Default;
            this.tV_advice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tV_advice.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tV_advice.HotTracking = true;
            this.tV_advice.Location = new System.Drawing.Point(0, 0);
            this.tV_advice.Name = "tV_advice";
            this.tV_advice.Size = new System.Drawing.Size(249, 600);
            this.tV_advice.TabIndex = 0;
            this.tV_advice.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tV_advice_MouseDown);
            // 
            // cMS_添加设备
            // 
            this.cMS_添加设备.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_添加设备});
            this.cMS_添加设备.Name = "contextMenuStrip1";
            this.cMS_添加设备.Size = new System.Drawing.Size(125, 26);
            // 
            // TSMI_添加设备
            // 
            this.TSMI_添加设备.Name = "TSMI_添加设备";
            this.TSMI_添加设备.Size = new System.Drawing.Size(124, 22);
            this.TSMI_添加设备.Text = "添加设备";
            this.TSMI_添加设备.Click += new System.EventHandler(this.TSMI_添加设备_Click);
            // 
            // cMS_设备右键菜单
            // 
            this.cMS_设备右键菜单.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_打开设备,
            this.TSMI_删除设备,
            this.TSMI_设备设置});
            this.cMS_设备右键菜单.Name = "contextMenuStrip2";
            this.cMS_设备右键菜单.Size = new System.Drawing.Size(125, 70);
            // 
            // TSMI_打开设备
            // 
            this.TSMI_打开设备.Name = "TSMI_打开设备";
            this.TSMI_打开设备.Size = new System.Drawing.Size(124, 22);
            this.TSMI_打开设备.Text = "打开设备";
            this.TSMI_打开设备.Click += new System.EventHandler(this.TSMI_打开设备_Click);
            // 
            // TSMI_删除设备
            // 
            this.TSMI_删除设备.Name = "TSMI_删除设备";
            this.TSMI_删除设备.Size = new System.Drawing.Size(124, 22);
            this.TSMI_删除设备.Text = "删除设备";
            this.TSMI_删除设备.Click += new System.EventHandler(this.TSMI_删除设备_Click);
            // 
            // TSMI_设备设置
            // 
            this.TSMI_设备设置.Name = "TSMI_设备设置";
            this.TSMI_设备设置.Size = new System.Drawing.Size(124, 22);
            this.TSMI_设备设置.Text = "设备设置";
            this.TSMI_设备设置.Click += new System.EventHandler(this.TSMI_设备设置_Click);
            // 
            // cMS_通道右键菜单
            // 
            this.cMS_通道右键菜单.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_通道设置,
            this.TSMI_传感器设置});
            this.cMS_通道右键菜单.Name = "contextMenuStrip3";
            this.cMS_通道右键菜单.Size = new System.Drawing.Size(137, 48);
            // 
            // TSMI_通道设置
            // 
            this.TSMI_通道设置.Name = "TSMI_通道设置";
            this.TSMI_通道设置.Size = new System.Drawing.Size(136, 22);
            this.TSMI_通道设置.Text = "通道设置";
            this.TSMI_通道设置.Click += new System.EventHandler(this.TSMI_通道设置_Click);
            // 
            // TSMI_传感器设置
            // 
            this.TSMI_传感器设置.Name = "TSMI_传感器设置";
            this.TSMI_传感器设置.Size = new System.Drawing.Size(136, 22);
            this.TSMI_传感器设置.Text = "传感器设置";
            this.TSMI_传感器设置.Click += new System.EventHandler(this.TSMI_传感器设置_Click);
            // 
            // DeviceManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(249, 600);
            this.ContextMenuStrip = this.cMS_添加设备;
            this.Controls.Add(this.tV_advice);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeviceManageForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "设备管理";
            this.Load += new System.EventHandler(this.DeviceManageForm_Load);
            this.cMS_添加设备.ResumeLayout(false);
            this.cMS_设备右键菜单.ResumeLayout(false);
            this.cMS_通道右键菜单.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tV_advice;
        private System.Windows.Forms.ToolStripMenuItem TSMI_添加设备;
        private System.Windows.Forms.ContextMenuStrip cMS_添加设备;
        private System.Windows.Forms.ContextMenuStrip cMS_设备右键菜单;
        private System.Windows.Forms.ToolStripMenuItem TSMI_打开设备;
        private System.Windows.Forms.ToolStripMenuItem TSMI_删除设备;
        private System.Windows.Forms.ToolStripMenuItem TSMI_设备设置;
        private System.Windows.Forms.ContextMenuStrip cMS_通道右键菜单;
        private System.Windows.Forms.ToolStripMenuItem TSMI_通道设置;
        private System.Windows.Forms.ToolStripMenuItem TSMI_传感器设置;
    }
}