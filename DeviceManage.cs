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
    public partial class DeviceManage : Form
    {
        public static DeviceManage deviceManage;
        public DeviceManage()
        {
            InitializeComponent();
            deviceManage = this;
        }

        private void contextMenuStrip1_MouseClick(object sender, MouseEventArgs e)
        {
            AddDevice addDevice = new AddDevice();
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

        //右击节点弹出菜单，根节点与子节点不同
        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                Point ClickPoint = new Point(e.X, e.Y);
                TreeNode CurrentNode = treeView1.GetNodeAt(ClickPoint);
                //点击的是节点，且是节点所在区域
                if (CurrentNode !=null && CurrentNode.Bounds.Contains(e.X, e.Y))
                {
                    //如果不是子节点，即是根节点
                    if (CurrentNode.FirstNode != null)
                    {
                        treeView1.ContextMenuStrip = contextMenuStrip2;
                    }
                    //是子节点
                    else if (CurrentNode.Parent != null)
                    {
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

        private void 设备设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetDevice setDevice = new SetDevice();
            setDevice.ShowDialog();
        }

        private void 通道设置ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SetChennal setChennal = new SetChennal();
            setChennal.ShowDialog();
        }
    }
}
