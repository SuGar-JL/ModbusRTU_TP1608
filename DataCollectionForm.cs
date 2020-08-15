using ModbusRTU_TP1608.Utils;
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
    public partial class DataCollectionForm : Form
    {
        bool flag = false;
        public DataCollectionForm()
        {
            InitializeComponent();
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void DataCollection_Load(object sender, EventArgs e)
        {
            //创建数据库表：设备的和通道的2个表
            DeviceManage deviceManage = new DeviceManage();
            ChennalManage chennalManage = new ChennalManage();
            DeviceManageForm f = new DeviceManageForm();
            f.MdiParent = this;
            f.Show();
            //初始化设备管理页的设备和通道配置树
            DeviceManageForm.deviceManageForm.treeView1_InitFromDB();
        }

        private void 添加设备ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeviceManageForm f = new DeviceManageForm();
            f.MdiParent = this;
            f.Show();
        }

        private void 设备管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeviceManageForm f = new DeviceManageForm();
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
            DeviceManageForm f = new DeviceManageForm();
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
