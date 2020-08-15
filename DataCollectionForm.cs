using ModbusRTU_TP1608.Entiry;
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
        public int num_MouseClicks = 0; //记录鼠标在myTreeView控件上按下的次数
        public static DataCollectionForm dataCollectionForm;
        public static string deviceName;
        public static string chennalName;
        public DataCollectionForm()
        {
            InitializeComponent();
            dataCollectionForm = this;
        }

        private void DataCollection_Load(object sender, EventArgs e)
        {
            //创建数据库表：设备的和通道的2个表
            DeviceManage deviceManage = new DeviceManage();
            ChennalManage chennalManage = new ChennalManage();
            //初始化设备管理页的设备和通道配置树
            treeView1_InitFromDB();
        }

        private void 添加设备ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddDeviceForm f = new AddDeviceForm();
            f.ShowDialog();
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

        public bool flag1 = false;
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (flag1)
            {
                DeviceManageForm f = new DeviceManageForm();
                f.MdiParent = this;
                f.Show();
                flag1 = false;
            }
            else
            {
                DeviceManageForm.deviceManageForm.Close();
                flag1 = true;
            }
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

        private void DataCollectionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //将目前打开的所有设备关闭
            new DeviceManage().CloseAllOpendingDivice();
            toolStripButton2.Image = Properties.Resources.start1;//调用Resources.resx中的图片

        }

        public void SetStartBottonEnabel(Device device, string deviceName)
        {
            if (device.status == 1)
            {
                toolStripButton2.Image = Properties.Resources.start2;
                //打开数据采集页面
                ShowDataForm showDataForm = new ShowDataForm();
                showDataForm.Text = deviceName;
                showDataForm.MdiParent = this;
                showDataForm.Show();
            }
            else
            {
                toolStripButton2.Image = Properties.Resources.start1;
            }
        }

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            //右击节点弹出菜单，根节点与子节点不同
            if (e.Button == MouseButtons.Right)
            {
                Point ClickPoint = new Point(e.X, e.Y);
                TreeNode CurrentNode = treeView1.GetNodeAt(ClickPoint);
                //点击的是节点，且是节点所在区域
                if (CurrentNode != null && CurrentNode.Bounds.Contains(e.X, e.Y))
                {
                    //如果不是子节点，即是根节点
                    if (CurrentNode.FirstNode != null)
                    {
                        deviceName = CurrentNode.Text;
                        treeView1.ContextMenuStrip = contextMenuStrip_setDevice;
                    }
                    //是子节点
                    else if (CurrentNode.Parent != null)
                    {
                        chennalName = CurrentNode.Text;
                        treeView1.ContextMenuStrip = contextMenuStrip_setChennalAndSensor;
                    }

                }
                //点击的不是节点（空白处）
                else
                {
                    treeView1.ContextMenuStrip = contextMenuStrip_addDevice;
                }
            }
            //为了我不让双击时展开节点，而是做其他操作，winform默认双击左键会展开节点
            //左键点击
            else if(e.Button == MouseButtons.Left)
            {
                num_MouseClicks = e.Clicks;//记录左键按下次数
            }
        }
        /// <summary>
        /// 展开节点前判断
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (this.num_MouseClicks > 1)
            {
                //如果是鼠标双击则禁止结点展开
                e.Cancel = true;
            }
            else
            {
                //如果是鼠标单击则允许结点展开
                e.Cancel = false;
            }
        }
        /// <summary>
        /// 折叠节点前判断
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            if (this.num_MouseClicks > 1)
            {
                //如果是鼠标双击则禁止结点折叠
                e.Cancel = true;
            }
            else
            {
                //如果是鼠标单击则允许结点折叠
                e.Cancel = false;
            }
        }
        /// <summary>
        /// 双击节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point ClickPoint = new Point(e.X, e.Y);
                TreeNode CurrentNode = treeView1.GetNodeAt(ClickPoint);
                //点击的是节点，且是节点所在区域
                if (CurrentNode != null && CurrentNode.Bounds.Contains(e.X, e.Y))
                {
                    //如果不是子节点，即是根节点
                    if (CurrentNode.FirstNode != null)
                    {
                        MessageBox.Show("双击节点");
                    }
                }
            }
        }
        /// <summary>
        /// 打开添加设备界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 添加设备ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddDeviceForm addDevice = new AddDeviceForm();
            addDevice.ShowDialog();
        }

        /// <summary>
        /// 新建设备，添加treeView1节点
        /// </summary>
        /// <param name="deviceName">设备名称</param>
        /// <param name="chennalNum">通道数量</param>
        /// <param name="startChennalId">起始通道</param>
        public void treeView1_addNodes(string deviceName, int chennalNum, int startChennalId)
        {
            TreeNode root = new TreeNode();
            //root.Name = deviceName;
            root.Text = deviceName;
            for (int i = startChennalId; i <= chennalNum; i++)
            {
                TreeNode node = new TreeNode();
                //node.Name = deviceName + "-CH0" + i;
                node.Text = deviceName + "-CH0" + i;
                root.Nodes.Add(node);
            }
            treeView1.Nodes.Add(root);
            //展开所有节点
            //treeView1.ExpandAll();
        }

        /// <summary>
        /// 获取树控件的根节点数
        /// </summary>
        /// <returns></returns>
        public int treeView1_rootNodeNum()
        {
            return treeView1.GetNodeCount(false);//不包含子节点
        }

        /// <summary>
        /// 用于每次打开软件，自动从数据库读取之前设置的配置信息
        /// </summary>
        public void treeView1_InitFromDB()
        {
            treeView1.Nodes.Clear();
            DeviceManage deviceManage = new DeviceManage();
            ChennalManage chennalManage = new ChennalManage();
            List<Device> devices = deviceManage.GetAllOrderById();
            foreach (Device device in devices)
            {
                TreeNode root = new TreeNode();
                root.Text = device.deviceName;
                List<Chennal> chennals = chennalManage.GetByDeviceId(device.id);
                foreach (Chennal chennal in chennals)
                {
                    TreeNode chennalNode = new TreeNode();
                    chennalNode.Text = chennal.chennalName;
                    root.Nodes.Add(chennalNode);
                }
                treeView1.Nodes.Add(root);
            }
        }

        private void 配置设备ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetDeviceForm setDevice = new SetDeviceForm();
            setDevice.ShowDialog();
        }

        private void 通道设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetChennalForm setChennal = new SetChennalForm();
            setChennal.ShowDialog();
        }

        private void 配置传感器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetSensorForm setSensorForm = new SetSensorForm();
            setSensorForm.ShowDialog();
        }

        private void 打开设备ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //设置设备为打开状态（isOpen字段变为1）
            //一旦打开，不可关闭，除非关闭软件或删除设备
            new DeviceManage().UpdateStatusByName(deviceName);
            //设置开始采集按钮的图标为可用状态
            toolStripButton2.Image = Properties.Resources.start2;
            //打开数据采集页面
            ShowDataForm showDataForm = new ShowDataForm();
            showDataForm.Text = deviceName;
            showDataForm.TopLevel = false;
            showDataForm.WindowState = FormWindowState.Maximized;
            showDataForm.Parent = this.splitContainer1.Panel2;
            showDataForm.Show();
        }

        private void 删除设备ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("所有数据都将会删除，确定要删除设备吗！", "警告！", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            if (dr == DialogResult.OK)
            {
                //删除于设备相关联的一切
                //1.删除传感器
                //查询当前设备的id
                Device device = new DeviceManage().GetByName(deviceName);
                //查询设备的所有通道
                List<Chennal> chennals = new ChennalManage().GetByDeviceId(device.id);
                //删除每个通道绑定的传感器
                foreach (Chennal chennal in chennals)
                {
                    if (chennal.sensorID != null)
                    {
                        new SensorManage().DeleteByTableNameAndId(chennal.sensorTableName, chennal.sensorID);
                    }
                }
                //删除通道
                new ChennalManage().DeleteByDeviceId(device.id);
                //删除设备
                new DeviceManage().DeleteById(device.id);
                DeviceManageForm.deviceManageForm.treeView1_InitFromDB();
            }
        }
    }
}
