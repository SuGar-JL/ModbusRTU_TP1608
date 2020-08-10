using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModbusRTU_TP1608
{
    public partial class DataCollection : Form
    {
        bool flag = false;
        public DataCollection()
        {
            InitializeComponent();
            DeviceManage f = new DeviceManage();
            f.MdiParent = this;
            f.Show();
        }

        private void DataCollection_Load(object sender, EventArgs e)
        {

        }

        private void 添加设备ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeviceManage f = new DeviceManage();
            f.MdiParent = this;
            f.Show();
        }

        private void 设备管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeviceManage f = new DeviceManage();
            f.MdiParent = this;
            f.Show();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 工具栏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                toolStrip1.Show();
                flag = false;
            }
            else
            {
                toolStrip1.Hide();
                flag = true;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DeviceManage f = new DeviceManage();
            f.MdiParent = this;
            f.Show();
        }

        private void 状态栏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                if (flag)
            {
                statusStrip1.Show();
                flag = false;
            }
            else
            {
                statusStrip1.Hide();
                flag = true;
            }
        }
    }
}
