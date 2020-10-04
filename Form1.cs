using ModbusRTU_TP1608.Entiry;
using ModbusRTU_TP1608.Utils;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModbusRTU_TP1608
{
    public partial class Form1 : UIForm
    {
        #region 属性
        public static Form1 Instance = new Form1();
        /// <summary>
        /// 使用的通信协议，0：没有选择，1：RTU，2：TCP
        /// </summary>
        private int protocol;
        /// <summary>
        /// 通信协议选择窗口
        /// </summary>
        private F_SelectProtocol f_SelectProtocol = new F_SelectProtocol();
        /// <summary>
        /// 系统对象
        /// </summary>
        private Sys sys = new Sys();
        private Dictionary<int, F_TitlePage> D_f_TitlePages = new Dictionary<int, F_TitlePage>();
        /// <summary>
        /// 这句还不知道为啥这样写
        /// </summary>
        protected UITabControl MainTabControl => MainContainer;
        private F_Home home = new F_Home();
        #endregion
        #region 主窗体构造方法
        public Form1()
        {
            InitializeComponent();
            MainContainer.BringToFront();
            //Controls.SetChildIndex(MainTabControl, 0);
            //Aside.Parent = this;
            //MainTabControl.Parent = this;
            //Aside.BringToFront();
            //MainTabControl.BringToFront();
            Aside.TabControl = MainTabControl;

            //做一个欢迎页

            //增加首页到Main
            this.home.PageIndex = 1111;
            MainContainer.AddPage(home);
            Aside.CreateNode("首页", 1111);

            //显示默认界面(第一个)
            Aside.SelectFirst();
            Instance = this;
        }
        #endregion
        #region 主窗体加载
        private void Form1_Load(object sender, EventArgs e)
        {
            //整个程序加载时创建数据库表（若数据库中没有这个表）
            //系统信息表，并插入一条记录
            new SysManage().CreateTable();
            //从数据库获取系统信息
            this.sys = new SysManage().GetSysInfo()[0];
            //根据通信协议创建数据库表
            this.CreateTable(this.sys.protocol);
            //从数据库加载设备到左侧菜单
            this.LoadDeviceCofigFDB(this.sys.protocol);
        }
        #endregion
        #region 创建数据库表
        private void CreateTable(int protocol)
        {
            if (protocol == (int)Common.Protocol.NONE)
            {
                return;
            }
            else if (protocol == (int)Common.Protocol.RTU)
            {
                //RTU设备信息表rtudevice
                new RTUDeviceManage().CreateTable();
                //RCP设备通道信息表rtuchennal
                new RTUChennalManage().CreateTable();
            }
            else if (protocol == (int)Common.Protocol.TCP)
            {
                //TTU设备信息表tcpdevice
                new TCPDeviceManage().CreateTable();
                //TCP设备通道信息表tcpchennal
                new TCPChennalManage().CreateTable();
            }
        }
        #endregion
        #region 设置->通信协议
        private void 通信协议ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            f_SelectProtocol.ShowDialog();
            if (f_SelectProtocol.IsOK)
            {
                if (f_SelectProtocol.RTU.Checked)
                {
                    this.protocol = (int)Common.Protocol.RTU;
                }
                else if (f_SelectProtocol.TCP.Checked)
                {
                    this.protocol = (int)Common.Protocol.TCP;
                }
                else
                {
                    this.protocol = (int)Common.Protocol.NONE;
                }
                if (sys.protocol != this.protocol)
                {
                    //更新系统信息
                    this.sys.protocol = this.protocol;
                    this.sys.updateBy = "管理员";
                    this.sys.updateTime = DateTime.Now;
                    new SysManage().UpdateSysInfo(sys);
                    //创建数据库表（若没创建过）
                    this.CreateTable(this.sys.protocol);
                    //加载设备列表
                    Aside.Nodes.Clear();
                    //增加首页到Main
                    MainContainer.AddPage(home);
                    Aside.CreateNode("首页", this.home.PageIndex);
                    //从数据库加载设备到左侧菜单
                    this.LoadDeviceCofigFDB(this.sys.protocol);
                    //显示默认界面(第一个)
                    Aside.SelectFirst();
                }
            }
        }
        #endregion
        #region 添加设备 点击添加设备：文字或“+”号
        private void btnAddDevice1_AddDevice(object sender, EventArgs e)
        {
            //只有选择了RTU、TCP中的一个协议才能添加设备
            if (sys.protocol == (int)Common.Protocol.NONE)
            {
                this.ShowWarningDialog("未选择通信协议！\r\n\n操作步骤：设置->通信协议");
                //退出该方法
                return;
            }
            else if (sys.protocol == (int)Common.Protocol.RTU)
            {
                F_AddDeviceRTU f_AddDeviceRTU = new F_AddDeviceRTU();
                f_AddDeviceRTU.ShowDialog();
                //IsOK的值来自F_AddDeviceRTU的CheckData方法
                if (f_AddDeviceRTU.IsOK)
                {
                    //将设备和通道配置信息写入数据库
                    //设置设备的配置信息（初始化设备配置）
                    RTUDevice device = new RTUDevice();
                    //device.id = "" + (new DeviceManage().GetMaxId() + 1);
                    device.status = (int)Common.DeviceStatus.STOP;//设备默认为停止状态
                    device.deviceType = f_AddDeviceRTU.deviceType.Text.Trim();
                    device.deviceName = f_AddDeviceRTU.deviceName.Text.Trim();
                    device.deviceAddress = f_AddDeviceRTU.deviceAddress.Text.Trim();
                    device.chennalNum = f_AddDeviceRTU.deviceChennalNum.SelectedIndex + 1;//SelectedIndex是从0开始的
                    device.startChennal = f_AddDeviceRTU.deviceStartChennal.SelectedIndex + 1;

                    //device.storeInterval = 6.0F;//设置保存间隔默认值为6.0s
                    //device.collectInterval = 3.0F;//设置采集间隔默认值为3.0s
                    //device.dropTimeDelay = 900F;//设置掉线延时默认值为900s

                    //device.host = f_AddDevice.deviceStartChennal.SelectedIndex + 1;

                    device.serialPort = f_AddDeviceRTU.deviceSerialPort.Text.Trim();//设置串口
                    device.baudRate = f_AddDeviceRTU.deviceBaudRate.Text.Trim();//设置波特率默认值为9600
                    device.position = f_AddDeviceRTU.devicePosition.Text.Trim();//设备安装位置
                    device.pageIndex = new RTUDeviceManage().GetPageIndexs();//设备对应pageId

                    device.createTime = DateTime.Now;
                    device.createBy = "管理员";
                    //update可以为空
                    //device.updateTime = null;
                    //device.updateBy = null;

                    //将device存入数据库
                    new RTUDeviceManage().Insert(device);

                    //将设备加入左侧设备管理菜单
                    var page = new F_TitlePage();//新建一个供显示数据用的页面
                    page.tB_DeviceName.Text = device.deviceName;//页面名称
                    page.PageIndex = (int)device.pageIndex;//页面id
                    MainContainer.AddPage(page);//将页面关联到MainContainer（在其中显示）
                    //创建设备管理菜单父节点（设备）
                    //参数：节点名称，图标，图标尺寸，关联的页面id
                    TreeNode parent = Aside.CreateNode(page.tB_DeviceName.Text, 61451, 24, page.PageIndex);
                    //存通道配置
                    for (int i = device.startChennal; i <= device.chennalNum; i++)
                    {
                        RTUChennal chennal = new RTUChennal();
                        chennal.deviceID = device.id;//设备id
                        chennal.chennalName = device.deviceName + "-CH0" + i;//通道名称
                        chennal.chennalID = i;//通道id
                        chennal.createBy = "管理员";
                        chennal.createTime = DateTime.Now;
                        new RTUChennalManage().Insert(chennal);
                        page.SetChennalName(chennal.chennalID, chennal.chennalName);
                        //创建设备管理菜单子节点（设备下的通道）
                        //参数：父节点，节点名称，图标，图标尺寸，节点名称，关联的页面id
                        Aside.CreateChildNode(parent, chennal.chennalName, page.PageIndex);
                    }
                    //将关联的页面存入字典，已备他用
                    D_f_TitlePages.Add(page.PageIndex, page);
                }
                f_AddDeviceRTU.Dispose();
            }
            else if (sys.protocol == (int)Common.Protocol.TCP)
            {
                F_AddDeviceTCP f_AddDeviceTCP = new F_AddDeviceTCP();
                f_AddDeviceTCP.ShowDialog();
                //IsOK的值来自F_AddDeviceRTU的CheckData方法
                if (f_AddDeviceTCP.IsOK)
                {
                    //将设备和通道配置信息写入数据库
                    //设置设备的配置信息（初始化设备配置）
                    TCPDevice device = new TCPDevice();
                    //device.id = "" + (new DeviceManage().GetMaxId() + 1);
                    device.status = (int)Common.DeviceStatus.STOP;//设备默认为停止状态
                    device.deviceType = f_AddDeviceTCP.deviceType.Text.Trim();
                    device.deviceName = f_AddDeviceTCP.deviceName.Text.Trim();
                    device.deviceAddress = f_AddDeviceTCP.deviceAddress.Text.Trim();
                    device.chennalNum = f_AddDeviceTCP.deviceChennalNum.SelectedIndex + 1;//SelectedIndex是从0开始的
                    device.startChennal = f_AddDeviceTCP.deviceStartChennal.SelectedIndex + 1;

                    //device.storeInterval = 6.0F;//设置保存间隔默认值为6.0s
                    //device.collectInterval = 3.0F;//设置采集间隔默认值为3.0s
                    //device.dropTimeDelay = 900F;//设置掉线延时默认值为900s

                    //device.host = f_AddDevice.deviceStartChennal.SelectedIndex + 1;

                    device.hostName = f_AddDeviceTCP.deviceHostName.Text.Trim();//设置主机名
                    device.port = f_AddDeviceTCP.devicePort.Text.Trim();//设置端口号
                    device.position = f_AddDeviceTCP.devicePosition.Text.Trim();//设备安装位置
                    device.pageIndex = new RTUDeviceManage().GetPageIndexs();//设备对应pageId

                    device.createTime = DateTime.Now;
                    device.createBy = "管理员";
                    //update可以为空
                    //device.updateTime = null;
                    //device.updateBy = null;

                    //将device存入数据库
                    new TCPDeviceManage().Insert(device);

                    //将设备加入左侧设备管理菜单
                    var page = new F_TitlePage();//新建一个供显示数据用的页面
                    page.tB_DeviceName.Text = device.deviceName;//页面名称
                    page.PageIndex = (int)device.pageIndex;//页面id
                    MainContainer.AddPage(page);//将页面关联到MainContainer（在其中显示）
                    //创建设备管理菜单父节点（设备）
                    //参数：节点名称，图标，图标尺寸，关联的页面id
                    TreeNode parent = Aside.CreateNode(page.tB_DeviceName.Text, 61451, 24, page.PageIndex);
                    //存通道配置
                    for (int i = device.startChennal; i <= device.chennalNum; i++)
                    {
                        TCPChennal chennal = new TCPChennal();
                        chennal.deviceID = device.id;//设备id
                        chennal.chennalName = device.deviceName + "-CH0" + i;//通道名称
                        chennal.chennalID = i;//通道id
                        chennal.createBy = "管理员";
                        chennal.createTime = DateTime.Now;
                        new TCPChennalManage().Insert(chennal);
                        page.SetChennalName(chennal.chennalID, chennal.chennalName);
                        //创建设备管理菜单子节点（设备下的通道）
                        //参数：父节点，节点名称，图标，图标尺寸，节点名称，关联的页面id
                        Aside.CreateChildNode(parent, chennal.chennalName, page.PageIndex);
                    }
                    //将关联的页面存入字典，已备他用
                    D_f_TitlePages.Add(page.PageIndex, page);
                }
                f_AddDeviceTCP.Dispose();
            }

        }
        #endregion
        #region 从数据库加载设备菜单到左边栏
        public void LoadDeviceCofigFDB(int protocol)
        {
            if (protocol == (int)Common.Protocol.NONE)
            {
                return;
            }
            else if (protocol == (int)Common.Protocol.RTU)
            {
                List<RTUDevice> devices = new RTUDeviceManage().GetAllOrderByCreateTime();
                foreach (var device in devices)
                {
                    //将设备加入左侧设备管理菜单
                    var page = new F_TitlePage();//新建一个供显示数据用的页面
                    page.tB_DeviceName.Text = device.deviceName;//页面名称
                    page.PageIndex = (int)device.pageIndex;//页面id
                    MainContainer.AddPage(page);//将页面关联到MainContainer（在其中显示）
                    //创建设备管理菜单父节点（设备）
                    //参数：节点名称，图标，图标尺寸，关联的页面id
                    TreeNode parent = Aside.CreateNode(page.tB_DeviceName.Text, 61451, 24, page.PageIndex);
                    List<RTUChennal> chennals = new RTUChennalManage().GetByDeviceId(device.id);//按chennalId排序的
                    foreach (var chennal in chennals)
                    {
                        //设置page上的通道对应的名称
                        page.SetChennalName(chennal.chennalID, chennal.chennalName);
                        Aside.CreateChildNode(parent, chennal.chennalName, page.PageIndex);
                    }
                }
            }
            else if (protocol == (int)Common.Protocol.TCP)
            {
                List<TCPDevice> devices = new TCPDeviceManage().GetAllOrderByCreateTime();
                foreach (var device in devices)
                {
                    //将设备加入左侧设备管理菜单
                    var page = new F_TitlePage();//新建一个供显示数据用的页面
                    page.tB_DeviceName.Text = device.deviceName;//页面名称
                    page.PageIndex = (int)device.pageIndex;//页面id
                    MainContainer.AddPage(page);//将页面关联到MainContainer（在其中显示）
                    //创建设备管理菜单父节点（设备）
                    //参数：节点名称，图标，图标尺寸，关联的页面id
                    TreeNode parent = Aside.CreateNode(page.tB_DeviceName.Text, 61451, 24, page.PageIndex);
                    List<TCPChennal> chennals = new TCPChennalManage().GetByDeviceId(device.id);//按chennalId排序的
                    foreach (var chennal in chennals)
                    {
                        //设置page上的通道对应的名称
                        page.SetChennalName(chennal.chennalID, chennal.chennalName);
                        Aside.CreateChildNode(parent, chennal.chennalName, page.PageIndex);
                    }
                }
            }
        }
        #endregion
        #region 修改Aside的Node（）设备名称及通道数
        public void SetAsideNode(string deviceName, string deviceId, int pageIndex, int chennalNum, int startChennal, bool f)
        {
            TreeNode node = Aside.SelectedNode;
            if (this.sys.protocol == (int)Common.Protocol.RTU)
            {
                var chennals = new List<RTUChennal>();
                //只有修改了子节点才来做修改操作
                if (f)
                {
                    chennals = new RTUChennalManage().GetByDeviceId(deviceId);
                }
                if (node.Parent == null)
                {
                    node.Text = deviceName;
                    if (f)
                    {
                        node.Nodes.Clear();
                        foreach (var chennal in chennals)
                        {
                            Aside.CreateChildNode(node, chennal.chennalName, pageIndex);
                        }
                    }
                }
                else
                {
                    node.Parent.Text = deviceName;
                    if (f)
                    {
                        TreeNode node1 = node.Parent;
                        node1.Nodes.Clear();
                        foreach (var chennal in chennals)
                        {
                            Aside.CreateChildNode(node1, chennal.chennalName, pageIndex);
                        }
                    }
                }
            }
            else if (this.sys.protocol == (int)Common.Protocol.TCP)
            {
                var chennals = new List<TCPChennal>();
                //只有修改了子节点才来做修改操作
                if (f)
                {
                    chennals = new TCPChennalManage().GetByDeviceId(deviceId);
                }
                if (node.Parent == null)
                {
                    node.Text = deviceName;
                    if (f)
                    {
                        node.Nodes.Clear();
                        foreach (var chennal in chennals)
                        {
                            Aside.CreateChildNode(node, chennal.chennalName, pageIndex);
                        }
                    }
                }
                else
                {
                    node.Parent.Text = deviceName;
                    if (f)
                    {
                        TreeNode node1 = node.Parent;
                        node1.Nodes.Clear();
                        foreach (var chennal in chennals)
                        {
                            Aside.CreateChildNode(node1, chennal.chennalName, pageIndex);
                        }
                    }
                }
            }


        }
        #endregion

    }
}
