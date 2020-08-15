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
    public partial class DeviceManageForm : Form
    {
        public static DeviceManageForm deviceManageForm;
        public static string deviceName = "";
        public static string deviceNameLeft = "";
        public static string chennalName = "";
        
        public DeviceManageForm()
        {
            InitializeComponent();
            deviceManageForm = this;

        }
        private void DeviceManageForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0,0);
            //初始化设备管理页的设备和通道配置树
            treeView1_InitFromDB();
        }
        private void contextMenuStrip1_MouseClick(object sender, MouseEventArgs e)
        {
            AddDeviceForm addDevice = new AddDeviceForm();
            addDevice.ShowDialog();
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
        //点击节点
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
                        DeviceManageForm.deviceName = CurrentNode.Text;
                        treeView1.ContextMenuStrip = contextMenuStrip2;
                    }
                    //是子节点
                    else if (CurrentNode.Parent != null)
                    {
                        DeviceManageForm.chennalName = CurrentNode.Text;
                        treeView1.ContextMenuStrip = contextMenuStrip3;
                    }

                }
                //点击的不是节点（空白处）
                else
                {
                    treeView1.ContextMenuStrip = contextMenuStrip1;
                }
            }

        }

        private void 打开设备ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //设置设备为打开状态（isOpen字段变为1）
            //一旦打开，不可关闭，除非关闭软件或删除设备
            new DeviceManage().UpdateStatusByName(deviceName);
            Device device = new DeviceManage().GetByName(deviceName);
            //设置开始采集按钮的图标为可用状态
            DataCollectionForm.dataCollectionForm.SetStartBottonEnabel(device, deviceName);
            
        }

        private void 删除设备ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr= MessageBox.Show("所有数据都将会删除，确定要删除设备吗！", "警告！", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
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
        private void 设备设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetDeviceForm setDevice = new SetDeviceForm();
            setDevice.ShowDialog();
        }

        private void 通道设置ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SetChennalForm setChennal = new SetChennalForm();
            setChennal.ShowDialog();
        }

        private void 传感器设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetSensorForm setSensorForm = new SetSensorForm();
            setSensorForm.ShowDialog();
        }

        
    }
}
