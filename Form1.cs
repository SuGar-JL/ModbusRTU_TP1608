﻿using ModbusRTU_TP1608.Entiry;
using ModbusRTU_TP1608.Entiry.Bluetooth_Gateway;
using ModbusRTU_TP1608.Forms.Bluetooth_Gateway;
using ModbusRTU_TP1608.Utils;
using ModbusTCP_TP1608.Entiry;
using SqlSugar;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
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
        /// <summary>
        /// 这句还不知道为啥这样写
        /// </summary>
        protected UITabControl MainTabControl => MainContainer;
        /// <summary>
        /// 首页
        /// </summary>
        private F_Home home = new F_Home();

        private F_BluetoothGateway f_BluetoothGateway = new F_BluetoothGateway();
        /// <summary>
        /// 获取一个日志记录器
        /// </summary>
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(typeof(Form1));

        //蓝牙探针相关
        private Thread My_NET_RevThread;//数据接收线程
        //创建TCP通讯类实例
        TCP_Communication_Func TCP_Communication_Example = new TCP_Communication_Func();
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

            //增加首页到Main
            this.home.PageIndex = 1111;
            MainContainer.AddPage(home);
            Aside.CreateNode("首页", 57460, 27, this.home.PageIndex);

            this.f_BluetoothGateway.PageIndex = 2222;
            MainContainer.AddPage(f_BluetoothGateway);
            Aside.CreateNode("蓝牙探针", 57364, 24, this.f_BluetoothGateway.PageIndex);

            //显示默认界面(第一个)
            Aside.SelectFirst();
            Instance = this;
        }
        #endregion

        #region 主窗体加载
        private void Form1_Load(object sender, EventArgs e)
        {
            Logger.Info("【系统启动】");
            //整个程序加载时创建数据库表（若数据库中没有这个表）
            //系统信息表，并插入一条记录
            try
            {
                Logger.Info("创建系统信息表");
                new SysManage().CreateTable();
                Logger.Info("从数据库获取系统信息");
                this.sys = new SysManage().GetSysInfo()[0];
                Logger.Info("根据通信协议创建数据库表");
                this.CreateTable(this.sys.protocol);
                Logger.Info("从数据库加载设备到左侧菜单");
                this.LoadDeviceCofigFDB(this.sys.protocol);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                this.ShowErrorDialog("创建数据库表时出错：\r\n" + ex.Message);
            }
            Logger.Info("【系统启动成功】");
            //让TabControl的选项卡显示否
            MainContainer.TabVisible = false;

            //Enable_Flag = true;
            //My_NET_RevThread = new Thread(new ThreadStart(Communication_Rev_Thread));
            //My_NET_RevThread.IsBackground = true;               //设置为后台线程
            //My_NET_RevThread.Start();
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
                try
                {
                    Logger.Info("RTU设备信息表rtudevice");
                    new RTUDeviceManage().CreateTable();
                    Logger.Info("RCP设备通道信息表rtuChannel");
                    new RTUChannelManage().CreateTable();
                }
                catch (Exception e)
                {
                    Logger.Error(e.Message);
                    this.ShowErrorDialog("创建RTU相关数据库表出错：\r\n" + e.Message);
                }
            }
            else if (protocol == (int)Common.Protocol.TCP)
            {
                try
                {
                    Logger.Info("TCP设备信息表tcpdevice");
                    new TCPDeviceManage().CreateTable();
                    Logger.Info("TCP设备通道信息表tcpChannel");
                    new TCPChannelManage().CreateTable();
                }
                catch (Exception e)
                {
                    Logger.Error(e.Message);
                    this.ShowErrorDialog("创建TCP相关数据库表出错：\r\n" + e.Message);

                }
            }
        }
        #endregion

        #region 设置->通信协议
        private void 通信协议ToolStripMenuItem_Click(object sender, EventArgs ea)
        {
            Logger.Info("选择通信协议");
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
                    try
                    {
                        Logger.Info("更新系统信息");
                        this.sys.protocol = this.protocol;
                        this.sys.updateBy = "管理员";
                        this.sys.updateTime = DateTime.Now;
                        new SysManage().UpdateSysInfo(sys);
                        //创建数据库表（若没创建过）
                        this.CreateTable(this.sys.protocol);
                        //加载设备列表
                        //清空左边栏
                        Aside.Nodes.Clear();
                        //清空MainContainer的page，MainContainer实质为TabControl
                        MainContainer.TabPages.Clear();
                        //增加首页到Main
                        MainContainer.AddPage(home);
                        Aside.CreateNode("首页", 57460, 27, this.home.PageIndex);
                        //从数据库加载设备到左侧菜单
                        this.LoadDeviceCofigFDB(this.sys.protocol);
                        //显示默认界面(第一个)
                        Aside.SelectFirst();
                        this.ShowSuccessTip("协议切换成功");
                    }
                    catch (Exception e)
                    {
                        Logger.Error(e.Message);
                        this.ShowErrorDialog("选择通信协议时出错：\r\n" + e.Message);
                    }
                }
            }
            if (this.protocol == (int)Common.Protocol.TCP)
            {
                Logger.Info("通信协议为：TCP");
            }
            else if (this.protocol == (int)Common.Protocol.RTU)
            {
                Logger.Info("通信协议为：RTU");
            }
        }
        #endregion

        #region 添加设备 点击添加设备：文字或“+”号
        private void btnAddDevice1_AddDevice(object sender, EventArgs ea)
        {
            Logger.Info("添加设备");
            //只有选择了RTU、TCP中的一个协议才能添加设备
            if (sys.protocol == (int)Common.Protocol.NONE)
            {
                this.ShowWarningDialog("未选择通信协议！\r\n\n操作步骤：设置->通信协议");
                Logger.Info("未选择通信协议！");
                //退出该方法
                return;
            }
            else if (sys.protocol == (int)Common.Protocol.RTU)
            {
                F_AddDeviceRTU f_AddDeviceRTU = new F_AddDeviceRTU();
                //IsOK的值来自F_AddDeviceRTU的CheckData方法
                if (f_AddDeviceRTU.IsOK)
                {
                    //将设备和通道配置信息写入数据库
                    //设置设备的配置信息（初始化设备配置）
                    RTUDevice device = new RTUDevice();
                    device.status = (int)Common.DeviceStatus.STOP;//设备默认为停止状态
                    device.deviceType = f_AddDeviceRTU.deviceType.Text.Trim();
                    device.deviceName = f_AddDeviceRTU.deviceName.Text.Trim();
                    device.deviceAddress = f_AddDeviceRTU.deviceAddress.Text.Trim();
                    device.ChannelNum = f_AddDeviceRTU.deviceChannelNum.SelectedIndex + 1;//SelectedIndex是从0开始的
                    device.startChannel = f_AddDeviceRTU.deviceStartChannel.SelectedIndex + 1;
                    device.serialPort = f_AddDeviceRTU.deviceSerialPort.Text.Trim();//设置串口
                    device.baudRate = f_AddDeviceRTU.deviceBaudRate.Text.Trim();//设置波特率
                    device.position = f_AddDeviceRTU.devicePosition.Text.Trim();//设备安装位置
                    device.pageIndex = new RTUDeviceManage().GetPageIndexs();//设备对应pageId
                    device.createTime = DateTime.Now;//创建时间
                    device.createBy = "管理员";//创建者
                    try
                    {
                        //将device存入数据库
                        new RTUDeviceManage().Insert(device);
                        //将设备加入左侧设备管理菜单
                        var page = new F_TitlePage();//新建一个供显示数据用的页面
                        page.tB_DeviceName.Text = device.deviceName;//页面名称
                        page.PageIndex = (int)device.pageIndex;//页面id
                        page.Text = string.Format("{0}({1})", device.deviceName, device.pageIndex);
                        MainContainer.AddPage(page);//将页面关联到MainContainer（在其中显示）
                                                    //创建设备管理菜单父节点（设备）
                                                    //参数：节点名称，图标，图标尺寸，关联的页面id
                        TreeNode parent = Aside.CreateNode(page.tB_DeviceName.Text, 57567, 24, page.PageIndex);
                        //存通道配置
                        for (int i = device.startChannel; i <= device.ChannelNum; i++)
                        {
                            RTUChannel Channel = new RTUChannel();
                            Channel.deviceID = device.id;//设备id
                            Channel.ChannelName = device.deviceName + "-CH0" + i;//通道名称
                            Channel.ChannelID = i;//通道id
                            Channel.createBy = "管理员";
                            Channel.createTime = DateTime.Now;
                            new RTUChannelManage().Insert(Channel);
                            page.SetChannelName((int)Channel.ChannelID, Channel.ChannelName);
                            //创建设备管理菜单子节点（设备下的通道）
                            //参数：父节点，节点名称，图标，图标尺寸，节点名称，关联的页面id
                            Aside.CreateChildNode(parent, 57364, 24, Channel.ChannelName, page.PageIndex);
                        }
                        Logger.Info(string.Format("添加设备成功：id:{0}、name:{1}", device.id, device.deviceName));
                        this.ShowSuccessTip("添加设备成功");
                    }
                    catch (Exception e)
                    {
                        Logger.Error(e.Message);
                        this.ShowErrorDialog("添加设备时出错：\r\n" + e.Message);
                    }
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
                    device.ChannelNum = f_AddDeviceTCP.deviceChannelNum.SelectedIndex + 1;//SelectedIndex是从0开始的
                    device.startChannel = f_AddDeviceTCP.deviceStartChannel.SelectedIndex + 1;
                    device.hostName = f_AddDeviceTCP.deviceHostName.Text.Trim();//设置主机名
                    device.port = f_AddDeviceTCP.devicePort.Text.Trim();//设置端口号
                    device.position = f_AddDeviceTCP.devicePosition.Text.Trim();//设备安装位置
                    device.pageIndex = new TCPDeviceManage().GetPageIndexs();//设备对应pageId
                    device.createTime = DateTime.Now;
                    device.createBy = "管理员";

                    try
                    {
                        //将device存入数据库
                        new TCPDeviceManage().Insert(device);
                        //将设备加入左侧设备管理菜单
                        var page = new F_TitlePage();//新建一个供显示数据用的页面
                        page.tB_DeviceName.Text = device.deviceName;//页面名称
                        page.PageIndex = (int)device.pageIndex;//页面id
                        page.Text = string.Format("{0}({1})", device.deviceName, device.pageIndex);
                        MainContainer.AddPage(page);//将页面关联到MainContainer（在其中显示）
                                                    //创建设备管理菜单父节点（设备）
                                                    //参数：节点名称，图标，图标尺寸，关联的页面id
                        TreeNode parent = Aside.CreateNode(page.tB_DeviceName.Text, 57567, 24, page.PageIndex);
                        //存通道配置
                        for (int i = device.startChannel; i <= device.ChannelNum; i++)
                        {
                            TCPChannel Channel = new TCPChannel();
                            Channel.deviceID = device.id;//设备id
                            Channel.ChannelName = device.deviceName + "-CH0" + i;//通道名称
                            Channel.ChannelID = i;//通道id
                            Channel.createBy = "管理员";
                            Channel.createTime = DateTime.Now;
                            new TCPChannelManage().Insert(Channel);
                            page.SetChannelName((int)Channel.ChannelID, Channel.ChannelName);
                            //创建设备管理菜单子节点（设备下的通道）
                            //参数：父节点，节点名称，图标，图标尺寸，节点名称，关联的页面id
                            Aside.CreateChildNode(parent, 57364, 24, Channel.ChannelName, page.PageIndex);
                        }
                        Logger.Info(string.Format("添加设备成功：id:{0}、name:{1}", device.id, device.deviceName));
                        this.ShowSuccessTip("添加设备成功");
                    }
                    catch (Exception e)
                    {
                        Logger.Error(e.Message);
                        this.ShowErrorDialog("添加设备时出错：\r\n" + e.Message);
                    }
                }
                f_AddDeviceTCP.Dispose();
            }
        }
        #endregion

        #region 从数据库加载设备菜单到左侧菜单栏
        public void LoadDeviceCofigFDB(int protocol)
        {
            if (protocol == (int)Common.Protocol.NONE)
            {
                Logger.Info("未选择通信协议（系统未初始化）");
                return;
            }
            else if (protocol == (int)Common.Protocol.RTU)
            {
                try
                {
                    List<RTUDevice> devices = new RTUDeviceManage().GetAllOrderByCreateTime();
                    if (devices.Count == 0)
                    {
                        return;
                    }
                    foreach (var device in devices)
                    {
                        //将设备加入左侧设备管理菜单
                        var page = new F_TitlePage();//新建一个供显示数据用的页面
                        page.tB_DeviceName.Text = device.deviceName;//页面名称
                        page.PageIndex = (int)device.pageIndex;//页面id
                        page.Text = string.Format("{0}({1})", device.deviceName, device.pageIndex);
                        MainContainer.AddPage(page);//将页面关联到MainContainer（在其中显示）
                                                    //创建设备管理菜单父节点（设备）
                                                    //参数：节点名称，图标，图标尺寸，关联的页面id
                        TreeNode parent = Aside.CreateNode(page.tB_DeviceName.Text, 57567, 24, page.PageIndex);
                        List<RTUChannel> Channels = new RTUChannelManage().GetByDeviceId(device.id);//按ChannelId排序的
                        foreach (var Channel in Channels)
                        {
                            //设置page上的通道对应的名称
                            page.SetChannelName((int)Channel.ChannelID, Channel.ChannelName);
                            Aside.CreateChildNode(parent, 57364, 24, Channel.ChannelName, page.PageIndex);
                        }
                    }
                }
                catch (Exception e)
                {
                    Logger.Error(e.Message);
                    this.ShowErrorDialog("加载失败：\r\n" + e.Message);
                }
            }
            else if (protocol == (int)Common.Protocol.TCP)
            {
                try
                {
                    List<TCPDevice> devices = new TCPDeviceManage().GetAllOrderByCreateTime();
                    if (devices.Count == 0)
                    {
                        return;
                    }
                    foreach (var device in devices)
                    {
                        //将设备加入左侧设备管理菜单
                        var page = new F_TitlePage();//新建一个供显示数据用的页面
                        page.tB_DeviceName.Text = device.deviceName;//页面名称
                        page.PageIndex = (int)device.pageIndex;//页面id
                        page.Text = string.Format("{0}({1})", device.deviceName, device.pageIndex);
                        MainContainer.AddPage(page);//将页面关联到MainContainer（在其中显示）
                                                    //创建设备管理菜单父节点（设备）
                                                    //参数：节点名称，图标，图标尺寸，关联的页面id
                        TreeNode parent = Aside.CreateNode(page.tB_DeviceName.Text, 57567, 24, page.PageIndex);
                        List<TCPChannel> Channels = new TCPChannelManage().GetByDeviceId(device.id);//按ChannelId排序的
                        foreach (var Channel in Channels)
                        {
                            //设置page上的通道对应的名称
                            page.SetChannelName((int)Channel.ChannelID, Channel.ChannelName);
                            Aside.CreateChildNode(parent, 57364, 24, Channel.ChannelName, page.PageIndex);
                        }
                    }
                }
                catch (Exception e)
                {
                    Logger.Error(e.Message);
                    this.ShowErrorDialog("加载失败：\r\n" + e.Message);
                }
            }
        }
        #endregion

        #region 设置设备 修改Aside的Node(设备名称及通道数)
        public void SetAsideNode(string deviceName, string deviceId, int pageIndex, bool f)
        {
            TreeNode node = Aside.SelectedNode;
            if (this.sys.protocol == (int)Common.Protocol.RTU)
            {
                var Channels = new List<RTUChannel>();
                //只有修改了子节点才来做修改操作
                if (f)
                {
                    try
                    {
                        Channels = new RTUChannelManage().GetByDeviceId(deviceId);

                    }
                    catch (Exception e)
                    {
                        Logger.Error(e.Message);
                        this.ShowErrorDialog(e.Message);
                    }
                }
                if (node.Parent == null)
                {
                    node.Text = deviceName;
                    if (f)
                    {
                        node.Nodes.Clear();
                        foreach (var Channel in Channels)
                        {
                            Aside.CreateChildNode(node, Channel.ChannelName, pageIndex);
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
                        foreach (var Channel in Channels)
                        {
                            Aside.CreateChildNode(node1, Channel.ChannelName, pageIndex);
                        }
                    }
                }
            }
            else if (this.sys.protocol == (int)Common.Protocol.TCP)
            {
                var Channels = new List<TCPChannel>();
                //只有修改了子节点才来做修改操作
                if (f)
                {
                    try
                    {
                        Channels = new TCPChannelManage().GetByDeviceId(deviceId);

                    }
                    catch (Exception e)
                    {
                        Logger.Error(e.Message);
                        this.ShowErrorDialog(e.Message);
                    }
                }
                if (node.Parent == null)
                {
                    node.Text = deviceName;
                    if (f)
                    {
                        node.Nodes.Clear();
                        foreach (var Channel in Channels)
                        {
                            Aside.CreateChildNode(node, Channel.ChannelName, pageIndex);
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
                        foreach (var Channel in Channels)
                        {
                            Aside.CreateChildNode(node1, Channel.ChannelName, pageIndex);
                        }
                    }
                }
            }


        }
        #endregion

        #region 删除设备 删除Aside的节以及MainContainer中的页面
        internal void DeleteAsideNode(int index)
        {
            TreeNode node = Aside.SelectedNode;
            if (node.Parent == null)
            {
                Aside.Nodes.Remove(node);
                try
                {
                    MainContainer.TabPages.RemoveAt(index);
                }
                catch (Exception)
                {
                    this.ShowErrorDialog(string.Format("删除失败，页面id={0}", index));
                }
            }
            else
            {
                Aside.Nodes.Remove(node.Parent);
                try
                {
                    MainContainer.TabPages.RemoveAt(index);
                }
                catch (Exception)
                {
                    this.ShowErrorDialog(string.Format("删除失败，页面id={0}", index));
                }
            }

        }
        #endregion

        #region 更改子节点的名称
        public void UpdateChildNodeName(string oldName, string newName)
        {
            TreeNode parentNode = Aside.SelectedNode.Parent == null ? Aside.SelectedNode : Aside.SelectedNode.Parent;
            foreach (TreeNode node in parentNode.Nodes)
            {
                if (node.Text.Equals(oldName))
                {
                    node.Text = newName;
                }
            }
        }

        #endregion

        #region 蓝牙网关
        public bool Enable_Flag = false;
        private void Communication_Rev_Thread()
        {
            while (true)
            {
                //在死循环中一定要让线程休眠，不然电脑CPU占用率很高，会造成卡顿甚至死机
                try
                {
                    #region TCP服务端监听消息
                    TCP_Communication_Example.TCP_Server_RevMessage_Func("127.0.0.1", 10025, Enable_Flag);
                    #endregion
                    Thread.Sleep(10);
                }
                catch (Exception ex1)
                {
                    //MessageBox.Show(ex1.Message);
                    ;
                }

            }
        }
        #endregion

        #region 关闭系统
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //所有设备停止采集，再关闭系统
            Enable_Flag = false;
            List<string> deviceAddress = ModbusUtil.F_TitlePages.Keys.ToList();
            int counti = deviceAddress.Count;
            for (int i = 0; i < counti; i++)
            {
                List<F_TitlePage> f_TitlePages = ModbusUtil.F_TitlePages[deviceAddress[i]];
                int countj = f_TitlePages.Count;
                for (int j = 0; j < countj; j++)
                {
                    ModbusUtil.F_TitlePages[deviceAddress[i]][0].BtnStop_Click(this, new EventArgs());
                }
            }
            
            Logger.Info("【系统关闭】");
        }
        #endregion

    }
}
