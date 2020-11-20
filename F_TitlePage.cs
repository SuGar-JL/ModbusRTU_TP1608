using Modbus.Device;
using ModbusRTU_TP1608.Entiry;
using ModbusRTU_TP1608.Utils;
using ModbusTCP_TP1608.Entiry;
using NModbus;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Media.TextFormatting;
using System.Xml;

namespace ModbusRTU_TP1608
{
    public partial class F_TitlePage : UIPage
    {
        #region 属性
        /// <summary>
        /// 通道id，时间/数据值
        /// </summary>
        public Dictionary<int, List<DateTime>> Xs = new Dictionary<int, List<DateTime>>();
        public Dictionary<int, List<double>> Ys = new Dictionary<int, List<double>>();
        public int selectedChannelID;
        /// <summary>
        /// 日志
        /// </summary>
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(typeof(F_TitlePage));
        /// <summary>
        /// 设备的状态
        /// </summary>
        private int deviceStatus = (int)Common.DeviceStatus.STOP;
        #endregion

        #region 构造方法
        public F_TitlePage()
        {
            InitializeComponent();
            //只要自定义了textBox的背景色与前景色后，设置Enabled = false就不会吧背景色和前景色变为默认的了
            //tB_ChannelName1.Enabled = false;
            //tB_ChannelName1.BackColor = Color.White;
            #region 大小自适应
            w1 = this.Width;//窗口最开始的宽
            h1 = this.Height;//窗口最开始的高
            this.setTag(this);
            #endregion
            //默认显示第一通道的曲线
            this.selectedChannelID = 1;
            InitChart();

        }
        #endregion

        #region 初始化Chart
        private void InitChart()
        {
            for (int i = 1; i <= 8; i++)
            {
                List<DateTime> x = new List<DateTime>();
                List<double> y = new List<double>();
                this.Xs.Add(i, x);
                this.Ys.Add(i, y);
            }
            //网格设置
            this.chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;//隐藏竖线
            this.chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.FromArgb(100, 200, 200, 200);//横线颜色
            //X轴设置
            this.chart1.ChartAreas[0].AxisX.TitleAlignment = StringAlignment.Far;//轴标题对齐方式
            this.chart1.ChartAreas[0].AxisX.TitleFont = new Font("微软雅黑", 8);//图表标题字体
            this.chart1.ChartAreas[0].AxisX.TitleForeColor = Color.Black;//轴标题颜色
            this.chart1.ChartAreas[0].AxisX.ArrowStyle = AxisArrowStyle.Triangle;//轴箭头
            this.chart1.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";//时间格式
            this.chart1.ChartAreas[0].AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Milliseconds;//时间间隔度量单位
            this.chart1.ChartAreas[0].AxisX.Interval = DateTime.Parse("00:00:05").Millisecond;//间隔为5秒钟
            //Y轴
            this.chart1.ChartAreas[0].AxisY.TitleAlignment = StringAlignment.Far;//轴标题对齐方式
            this.chart1.ChartAreas[0].AxisY.TextOrientation = TextOrientation.Horizontal;//标题水平
            this.chart1.ChartAreas[0].AxisY.TitleFont = new Font("微软雅黑", 8);//标题字体
            this.chart1.ChartAreas[0].AxisY.TitleForeColor = Color.Black;//轴标题颜色
            this.chart1.ChartAreas[0].AxisY.ArrowStyle = AxisArrowStyle.Triangle;//轴箭头
            this.chart1.ChartAreas[0].AxisY.MajorTickMark.Size = 0.5F;//刻度线长度
            //提示信息
            this.chart1.Series[0].ToolTip = "数据：#VAL\n最大值：#MAX\n最小值：#MIN\n日期：#VALX";
            //先在这初始化绑定值，才能使得之后x轴显示时间标签
            List<DateTime> x1 = new List<DateTime>() { DateTime.Now };
            List<double> y1 = new List<double>() { 0 };
            this.chart1.Series[0].MarkerStyle = MarkerStyle.None;
            this.chart1.Series[0].Points.DataBindXY(x1, y1);
        }
        #endregion

        #region 控件大小随窗体大小等比例缩放
        private float w1;
        private float h1;

        /// <summary>
        /// 获取窗口或父控件中的控件的属性（位置和尺寸），每个控件都有一个tag属性，而且是空的，这里可以拿来用
        /// </summary>
        /// <param name="cons">窗体</param>
        private void setTag(Control cons)
        {
            //遍历子控件
            foreach (Control con in cons.Controls)
            {
                //将子控件的宽、高、左边坐标、顶部坐标以及字号存在控件的tag属性中
                con.Tag = con.Width + ";" + con.Height + ";" + con.Left + ";" + con.Top + ";" + con.Font.Size;
                if (con.Controls.Count > 0)
                {
                    setTag(con);
                }
            }
        }

        /// <summary>
        /// 用于在窗体大小变化后设置控件的位置即大小
        /// </summary>
        /// <param name="scaleX">窗体新的宽</param>
        /// <param name="scaley">窗体新的高</param>
        /// <param name="cons">窗体</param>
        private void setControls(float scaleX, float scaley, Control cons)
        {
            //遍历窗体中的控件，重新设置控件的值
            foreach (Control con in cons.Controls)
            {
                //获取控件的Tag属性值，并分割后存储字符串数组
                if (con.Tag != null)
                {
                    try
                    {
                        //取出控件的tag属性中的宽、高、左边坐标、顶部坐标以及字号
                        string[] mytag = con.Tag.ToString().Split(new char[] { ';' });
                        //根据窗体缩放的比例确定控件的值
                        con.Width = Convert.ToInt32(System.Convert.ToSingle(mytag[0]) * scaleX);//宽度
                        con.Height = Convert.ToInt32(System.Convert.ToSingle(mytag[1]) * scaley);//高度
                        con.Left = Convert.ToInt32(System.Convert.ToSingle(mytag[2]) * scaleX);//左边距
                        con.Top = Convert.ToInt32(System.Convert.ToSingle(mytag[3]) * scaley);//顶边距
                        Single currentSize = System.Convert.ToSingle(mytag[4]) * scaley;//字体大小
                        con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                        if (con.Controls.Count > 0)
                        {
                            setControls(scaleX, scaley, con);
                        }
                    }
                    catch (Exception)
                    {
                        //最小化时会报异常，在此处理
                        ;
                    }
                }
            }
        }

        /// <summary>
        /// 窗体大小改变事件
        /// </summary>
        private void F_TitlePage_SizeChanged(object sender, EventArgs e)
        {
            float scaleX = (this.Width) / w1;
            float scaleY = (this.Height) / h1;
            setControls(scaleX, scaleY, this);
        }
        #endregion

        #region 用双缓冲绘制窗口的所有子控件(让控件太多时加载快些)
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // 用双缓冲绘制窗口的所有子控件
                return cp;
            }
        }
        #endregion

        #region 窗体加载
        private void F_TitlePage_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region 设置通道数据显示页面的通道名称
        public void SetChannelName(int index, string ChannelName)
        {
            switch (index)
            {
                case 1:
                    this.ucChannel1.uiChannelName.Text = ChannelName;
                    break;
                case 2:
                    this.ucChannel2.uiChannelName.Text = ChannelName;
                    break;
                case 3:
                    this.ucChannel3.uiChannelName.Text = ChannelName;
                    break;
                case 4:
                    this.ucChannel4.uiChannelName.Text = ChannelName;
                    break;
                case 5:
                    this.ucChannel5.uiChannelName.Text = ChannelName;
                    break;
                case 6:
                    this.ucChannel6.uiChannelName.Text = ChannelName;
                    break;
                case 7:
                    this.ucChannel7.uiChannelName.Text = ChannelName;
                    break;
                case 8:
                    this.ucChannel8.uiChannelName.Text = ChannelName;
                    break;
            }
        }

        #endregion

        #region 配置设备
        private void onEdit_Click(object sender, EventArgs ea)
        {
            try
            {
                Logger.Info("修改设备配置");
                Sys sys = new SysManage().GetSysInfo()[0];
                if (sys.protocol == (int)Common.Protocol.NONE)
                {
                    return;
                }
                else if (sys.protocol == (int)Common.Protocol.RTU)
                {
                    var device = new RTUDeviceManage().GetByName(this.tB_DeviceName.Text.Trim())[0];
                    //打开配置对话框
                    var f_DeviceCofigRTU = new F_DeviceCofigRTU();
                    if (device.status == (int)Common.DeviceStatus.START)
                    {
                        f_DeviceCofigRTU.deviceType.Enabled = false;
                        f_DeviceCofigRTU.deviceName.Enabled = false;
                        f_DeviceCofigRTU.deviceAddress.Enabled = false;
                        f_DeviceCofigRTU.deviceChannelNum.Enabled = false;
                        f_DeviceCofigRTU.deviceStartChannel.Enabled = false;
                        f_DeviceCofigRTU.deviceSerialPort.Enabled = false;
                        f_DeviceCofigRTU.deviceBaudRate.Enabled = false;
                    }
                    f_DeviceCofigRTU.device = device;
                    f_DeviceCofigRTU.deviceType.Items.AddRange(Common.DeviceType.ToArray());
                    f_DeviceCofigRTU.deviceType.SelectedIndex = Common.DeviceType.IndexOf(device.deviceType);
                    f_DeviceCofigRTU.deviceName.Text = device.deviceName;
                    f_DeviceCofigRTU.deviceAddress.Text = device.deviceAddress;
                    f_DeviceCofigRTU.deviceChannelNum.Items.AddRange(Common.DeviceChannelNum.ToArray());
                    f_DeviceCofigRTU.deviceChannelNum.SelectedIndex = device.ChannelNum - 1;
                    f_DeviceCofigRTU.deviceStartChannel.Items.AddRange(Common.DeviceStartChannel.ToArray());
                    f_DeviceCofigRTU.deviceStartChannel.SelectedIndex = device.startChannel - 1;
                    List<string> serialPorts = System.IO.Ports.SerialPort.GetPortNames().ToList();
                    serialPorts.Sort();
                    f_DeviceCofigRTU.deviceSerialPort.Items.AddRange(serialPorts.ToArray());
                    if (serialPorts.ToList().Contains(device.serialPort))
                    {
                        f_DeviceCofigRTU.deviceSerialPort.SelectedIndex = serialPorts.ToList().IndexOf(device.serialPort);
                    }
                    else
                    {
                        f_DeviceCofigRTU.deviceSerialPort.Text = device.serialPort;
                    }
                    f_DeviceCofigRTU.deviceBaudRate.Items.AddRange(Common.BaudRate.ToArray());
                    f_DeviceCofigRTU.deviceBaudRate.SelectedIndex = Common.BaudRate.IndexOf(device.baudRate);
                    f_DeviceCofigRTU.devicePosition.Text = device.position;
                    f_DeviceCofigRTU.ShowDialog();
                    //表单检查通过
                    if (f_DeviceCofigRTU.IsOK)
                    {
                        bool f = false;
                        device.deviceType = f_DeviceCofigRTU.deviceType.Text.Trim();
                        device.deviceName = f_DeviceCofigRTU.deviceName.Text.Trim();
                        device.deviceAddress = f_DeviceCofigRTU.deviceAddress.Text.Trim();
                        if (device.ChannelNum != f_DeviceCofigRTU.deviceChannelNum.SelectedIndex + 1 || device.startChannel != f_DeviceCofigRTU.deviceStartChannel.SelectedIndex + 1)
                        {
                            f = !f;
                        }
                        device.ChannelNum = f_DeviceCofigRTU.deviceChannelNum.SelectedIndex + 1;//SelectedIndex是从0开始的
                        device.startChannel = f_DeviceCofigRTU.deviceStartChannel.SelectedIndex + 1;
                        device.serialPort = f_DeviceCofigRTU.deviceSerialPort.Text.Trim();//设置串口
                        device.baudRate = f_DeviceCofigRTU.deviceBaudRate.Text.Trim();//设置波特率
                        device.position = f_DeviceCofigRTU.devicePosition.Text.Trim();//设备安装位置
                        device.updateTime = DateTime.Now;
                        device.updateBy = "管理员";
                        //将device存入数据库
                        new RTUDeviceManage().UpdateByEntity(device);
                        //设置本页面的标题与设备名称一致
                        this.tB_DeviceName.Text = device.deviceName;
                        //修改设备列表当前选中的设备的名称并改变通道数量（如果变了的化）
                        if (f)
                        {
                            //四种情况
                            var Channels = new RTUChannelManage().GetByDeviceId(device.id);
                            if (Channels[0].ChannelID >= device.startChannel && Channels[Channels.Count - 1].ChannelID >= (device.startChannel + device.ChannelNum - 1))
                            {
                                //补前(第一个=满足时，补前不进行)
                                for (int i = device.startChannel; i < Channels[0].ChannelID; i++)
                                {
                                    RTUChannel Channel = new RTUChannel();
                                    Channel.deviceID = device.id;//设备id
                                    Channel.ChannelName = device.deviceName + "-CH0" + i;//通道名称
                                    Channel.ChannelID = i;//通道id
                                    Channel.createBy = "管理员";
                                    Channel.createTime = DateTime.Now;
                                    new RTUChannelManage().Insert(Channel);
                                }
                                //删后(第二个=满足时，删后不进行)
                                if (Channels[Channels.Count - 1].ChannelID > (device.startChannel + device.ChannelNum - 1))
                                {
                                    List<string> ChannelIds = new List<string>();
                                    foreach (var Channel in Channels)
                                    {
                                        ChannelIds.Add(Channel.id);
                                    }
                                    ChannelIds.RemoveRange(0, device.startChannel + device.ChannelNum - 1 - (int)Channels[0].ChannelID);
                                    ChannelIds.RemoveAt(0);
                                    //根据id批量删除
                                    new RTUChannelManage().DeleteByIds(ChannelIds.ToArray());
                                }
                            }
                            else if (Channels[0].ChannelID <= device.startChannel && Channels[Channels.Count - 1].ChannelID <= (device.startChannel + device.ChannelNum - 1))
                            {
                                //补后(第二个=满足时，补后不进行)
                                for (int i = (int)Channels[Channels.Count - 1].ChannelID + 1; i <= device.startChannel + device.ChannelNum - 1; i++)
                                {
                                    RTUChannel Channel = new RTUChannel();
                                    Channel.deviceID = device.id;//设备id
                                    Channel.ChannelName = device.deviceName + "-CH0" + i;//通道名称
                                    Channel.ChannelID = i;//通道id
                                    Channel.createBy = "管理员";
                                    Channel.createTime = DateTime.Now;
                                    new RTUChannelManage().Insert(Channel);
                                }
                                //删前(第一个=满足时，删前不进行)
                                if (Channels[0].ChannelID < device.startChannel)
                                {
                                    List<string> ChannelIds = new List<string>();
                                    foreach (var Channel in Channels)
                                    {
                                        ChannelIds.Add(Channel.id);
                                    }
                                    ChannelIds.RemoveRange(device.startChannel - 1, (int)Channels[Channels.Count - 1].ChannelID - device.startChannel + 1);
                                    //根据id批量删除
                                    new RTUChannelManage().DeleteByIds(ChannelIds.ToArray());
                                }
                            }
                            else if (Channels[0].ChannelID < device.startChannel && Channels[Channels.Count - 1].ChannelID > (device.startChannel + device.ChannelNum - 1))
                            {
                                //删前后
                                List<string> ChannelIds = new List<string>();
                                foreach (var Channel in Channels)
                                {
                                    ChannelIds.Add(Channel.id);
                                }
                                ChannelIds.RemoveRange(device.startChannel - 1, device.ChannelNum);
                                //根据id批量删除
                                new RTUChannelManage().DeleteByIds(ChannelIds.ToArray());

                            }
                            else if (Channels[0].ChannelID >= device.startChannel && Channels[Channels.Count - 1].ChannelID <= (device.startChannel + device.ChannelNum - 1))
                            {

                                //补前(第一个=满足时，补前不进行)
                                for (int i = device.startChannel; i < Channels[0].ChannelID; i++)
                                {
                                    RTUChannel Channel = new RTUChannel();
                                    Channel.deviceID = device.id;//设备id
                                    Channel.ChannelName = device.deviceName + "-CH0" + i;//通道名称
                                    Channel.ChannelID = i;//通道id
                                    Channel.createBy = "管理员";
                                    Channel.createTime = DateTime.Now;
                                    new RTUChannelManage().Insert(Channel);
                                }
                                //补后（第二个=满足时，补后不进行）
                                for (int i = (int)Channels[Channels.Count - 1].ChannelID + 1; i <= device.startChannel + device.ChannelNum - 1; i++)
                                {
                                    RTUChannel Channel = new RTUChannel();
                                    Channel.deviceID = device.id;//设备id
                                    Channel.ChannelName = device.deviceName + "-CH0" + i;//通道名称
                                    Channel.ChannelID = i;//通道id
                                    Channel.createBy = "管理员";
                                    Channel.createTime = DateTime.Now;
                                    new RTUChannelManage().Insert(Channel);
                                }
                            }
                        }
                        Form1.Instance.SetAsideNode(device.deviceName, device.id, (int)device.pageIndex, f);
                        Logger.Info("修改已保存");
                        this.ShowSuccessTip("修改已保存");
                    }
                }
                else if (sys.protocol == (int)Common.Protocol.TCP)
                {
                    var device = new TCPDeviceManage().GetByName(this.tB_DeviceName.Text.Trim())[0];
                    //打开配置对话框
                    var f_DeviceCofigTCP = new F_DeviceCofigTCP();
                    if (device.status == (int)Common.DeviceStatus.START)
                    {
                        f_DeviceCofigTCP.deviceType.Enabled = false;
                        f_DeviceCofigTCP.deviceName.Enabled = false;
                        f_DeviceCofigTCP.deviceAddress.Enabled = false;
                        f_DeviceCofigTCP.deviceChannelNum.Enabled = false;
                        f_DeviceCofigTCP.deviceStartChannel.Enabled = false;
                        f_DeviceCofigTCP.deviceHostName.Enabled = false;
                        f_DeviceCofigTCP.devicePort.Enabled = false;
                    }
                    f_DeviceCofigTCP.device = device;
                    f_DeviceCofigTCP.deviceType.Items.AddRange(Common.DeviceType.ToArray());
                    f_DeviceCofigTCP.deviceType.SelectedIndex = Common.DeviceType.IndexOf(device.deviceType);
                    f_DeviceCofigTCP.deviceName.Text = device.deviceName;
                    f_DeviceCofigTCP.deviceAddress.Text = device.deviceAddress;
                    f_DeviceCofigTCP.deviceChannelNum.Items.AddRange(Common.DeviceChannelNum.ToArray());
                    f_DeviceCofigTCP.deviceChannelNum.SelectedIndex = device.ChannelNum - 1;
                    f_DeviceCofigTCP.deviceStartChannel.Items.AddRange(Common.DeviceStartChannel.ToArray());
                    f_DeviceCofigTCP.deviceStartChannel.SelectedIndex = device.startChannel - 1;
                    f_DeviceCofigTCP.deviceHostName.Text = device.hostName;
                    f_DeviceCofigTCP.devicePort.Text = device.port;
                    f_DeviceCofigTCP.devicePosition.Text = device.position;
                    f_DeviceCofigTCP.ShowDialog();
                    if (f_DeviceCofigTCP.IsOK)
                    {
                        bool f = false;
                        device.deviceType = f_DeviceCofigTCP.deviceType.Text.Trim();
                        device.deviceName = f_DeviceCofigTCP.deviceName.Text.Trim();
                        device.deviceAddress = f_DeviceCofigTCP.deviceAddress.Text.Trim();
                        if (device.ChannelNum != f_DeviceCofigTCP.deviceChannelNum.SelectedIndex + 1 || device.startChannel != f_DeviceCofigTCP.deviceStartChannel.SelectedIndex + 1)
                        {
                            f = !f;
                        }
                        device.ChannelNum = f_DeviceCofigTCP.deviceChannelNum.SelectedIndex + 1;//SelectedIndex是从0开始的
                        device.startChannel = f_DeviceCofigTCP.deviceStartChannel.SelectedIndex + 1;
                        device.hostName = f_DeviceCofigTCP.deviceHostName.Text.Trim();//设置串口
                        device.port = f_DeviceCofigTCP.devicePort.Text.Trim();//设置波特率
                        device.position = f_DeviceCofigTCP.devicePosition.Text.Trim();//设备安装位置
                        device.updateTime = DateTime.Now;
                        device.updateBy = "管理员";
                        //将device存入数据库
                        new TCPDeviceManage().UpdateByEntity(device);
                        //设置本页面的标题与设备名称一致
                        this.tB_DeviceName.Text = device.deviceName;
                        //修改设备列表当前选中的设备的名称并改变通道数量（如果变了的化）
                        if (f)
                        {
                            //四种情况
                            var Channels = new TCPChannelManage().GetByDeviceId(device.id);
                            if (Channels[0].ChannelID >= device.startChannel && Channels[Channels.Count - 1].ChannelID >= (device.startChannel + device.ChannelNum - 1))
                            {
                                //补前(第一个=满足时，补前不进行)
                                for (int i = device.startChannel; i < Channels[0].ChannelID; i++)
                                {
                                    TCPChannel Channel = new TCPChannel();
                                    Channel.deviceID = device.id;//设备id
                                    Channel.ChannelName = device.deviceName + "-CH0" + i;//通道名称
                                    Channel.ChannelID = i;//通道id
                                    Channel.createBy = "管理员";
                                    Channel.createTime = DateTime.Now;
                                    new TCPChannelManage().Insert(Channel);
                                }
                                //删后(第二个=满足时，删后不进行)
                                if (Channels[Channels.Count - 1].ChannelID > (device.startChannel + device.ChannelNum - 1))
                                {
                                    List<string> ChannelIds = new List<string>();
                                    foreach (var Channel in Channels)
                                    {
                                        ChannelIds.Add(Channel.id);
                                    }
                                    ChannelIds.RemoveRange(0, device.startChannel + device.ChannelNum - 1 - (int)Channels[0].ChannelID);
                                    ChannelIds.RemoveAt(0);
                                    //根据id批量删除
                                    new TCPChannelManage().DeleteByIds(ChannelIds.ToArray());
                                }
                            }
                            else if (Channels[0].ChannelID <= device.startChannel && Channels[Channels.Count - 1].ChannelID <= (device.startChannel + device.ChannelNum - 1))
                            {
                                //补后(第二个=满足时，补后不进行)
                                for (int i = (int)Channels[Channels.Count - 1].ChannelID + 1; i <= device.startChannel + device.ChannelNum - 1; i++)
                                {
                                    TCPChannel Channel = new TCPChannel();
                                    Channel.deviceID = device.id;//设备id
                                    Channel.ChannelName = device.deviceName + "-CH0" + i;//通道名称
                                    Channel.ChannelID = i;//通道id
                                    Channel.createBy = "管理员";
                                    Channel.createTime = DateTime.Now;
                                    new TCPChannelManage().Insert(Channel);
                                }
                                //删前(第一个=满足时，删前不进行)
                                if (Channels[0].ChannelID < device.startChannel)
                                {
                                    List<string> ChannelIds = new List<string>();
                                    foreach (var Channel in Channels)
                                    {
                                        ChannelIds.Add(Channel.id);
                                    }
                                    ChannelIds.RemoveRange(device.startChannel - 1, (int)Channels[Channels.Count - 1].ChannelID - device.startChannel + 1);
                                    //根据id批量删除
                                    new TCPChannelManage().DeleteByIds(ChannelIds.ToArray());
                                }
                            }
                            else if (Channels[0].ChannelID < device.startChannel && Channels[Channels.Count - 1].ChannelID > (device.startChannel + device.ChannelNum - 1))
                            {
                                //删前后
                                List<string> ChannelIds = new List<string>();
                                foreach (var Channel in Channels)
                                {
                                    ChannelIds.Add(Channel.id);
                                }
                                ChannelIds.RemoveRange(device.startChannel - 1, device.ChannelNum);
                                //根据id批量删除
                                new TCPChannelManage().DeleteByIds(ChannelIds.ToArray());

                            }
                            else if (Channels[0].ChannelID >= device.startChannel && Channels[Channels.Count - 1].ChannelID <= (device.startChannel + device.ChannelNum - 1))
                            {

                                //补前(第一个=满足时，补前不进行)
                                for (int i = device.startChannel; i < Channels[0].ChannelID; i++)
                                {
                                    TCPChannel Channel = new TCPChannel();
                                    Channel.deviceID = device.id;//设备id
                                    Channel.ChannelName = device.deviceName + "-CH0" + i;//通道名称
                                    Channel.ChannelID = i;//通道id
                                    Channel.createBy = "管理员";
                                    Channel.createTime = DateTime.Now;
                                    new TCPChannelManage().Insert(Channel);
                                }
                                //补后（第二个=满足时，补后不进行）
                                for (int i = (int)Channels[Channels.Count - 1].ChannelID + 1; i <= device.startChannel + device.ChannelNum - 1; i++)
                                {
                                    TCPChannel Channel = new TCPChannel();
                                    Channel.deviceID = device.id;//设备id
                                    Channel.ChannelName = device.deviceName + "-CH0" + i;//通道名称
                                    Channel.ChannelID = i;//通道id
                                    Channel.createBy = "管理员";
                                    Channel.createTime = DateTime.Now;
                                    new TCPChannelManage().Insert(Channel);
                                }
                            }

                        }
                        Form1.Instance.SetAsideNode(device.deviceName, device.id, (int)device.pageIndex, f);
                        Logger.Info("修改已保存");
                        this.ShowSuccessTip("修改已保存");
                    }
                }
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                this.ShowErrorDialog(e.Message);
                return;
            }
        }
        #endregion

        #region 删除设备
        private void onDelete_Click(object sender, EventArgs ea)
        {
            try
            {
                Logger.Info("删除设备");
                Sys sys = new SysManage().GetSysInfo()[0];
                if (sys.protocol == (int)Common.Protocol.RTU)
                {
                    //1.设备正在采集时是不能删除的
                    var device = new RTUDeviceManage().GetByName(this.tB_DeviceName.Text.Trim())[0];
                    if (device.status == (int)Common.DeviceStatus.START)
                    {
                        Logger.Warn("设备正在采集数据，不能删除！");
                        this.ShowWarningDialog("设备正在采集数据，不能删除！");
                        return;
                    }
                    //其它状态时可删除，得询问
                    bool OK = this.ShowAskDialog("确定要删除该设备吗？");
                    if (OK)
                    {
                        List<RTUDevice> devices = new RTUDeviceManage().GetAllOrderByPageIndex();
                        //点击确认按钮
                        new RTUChannelManage().DeleteByDeviceId(device.id);//是批量吗？
                        new RTUDeviceManage().DeleteById(device.id);
                        Form1.Instance.DeleteAsideNode((int)device.pageIndex);
                        //对数据库中的所有设备重新编号devices.Count = devices[devices.Count - 1].PageIndex
                        if (device.pageIndex != devices.Count)
                        {
                            for (int i = (int)device.pageIndex; i < devices.Count; i++)
                            {
                                devices[i].pageIndex = devices[i].pageIndex - 1;
                                new RTUDeviceManage().UpdateByEntity(devices[i]);
                            }
                        }
                        Logger.Info(string.Format("删除设备成功：id:{0}、name:{1}",device.id, device.deviceName));
                        this.ShowSuccessTip("删除设备成功");
                    }
                    else
                    {
                        Logger.Info("取消删除");
                        //点击取消按钮
                        this.ShowSuccessTip("取消删除");
                    }
                }
                else if (sys.protocol == (int)Common.Protocol.TCP)
                {
                    //1.设备正在采集时是不能删除的
                    var device = new TCPDeviceManage().GetByName(this.tB_DeviceName.Text.Trim())[0];
                    if (device.status == (int)Common.DeviceStatus.START)
                    {
                        Logger.Warn("设备正在采集数据，不能删除！");
                        this.ShowWarningDialog("设备正在采集数据，不能删除！");
                        return;
                    }
                    //其它状态时可删除，得询问
                    bool OK = this.ShowAskDialog("确定要删除该设备吗？");
                    if (OK)
                    {
                        List<TCPDevice> devices = new TCPDeviceManage().GetAllOrderByPageIndex();
                        //点击确认按钮
                        new TCPChannelManage().DeleteByDeviceId(device.id);//是批量吗？
                        new TCPDeviceManage().DeleteById(device.id);
                        Form1.Instance.DeleteAsideNode((int)device.pageIndex);
                        //对数据库中的所有设备重新编号devices.Count = devices[devices.Count - 1].PageIndex
                        if (device.pageIndex != devices.Count)
                        {
                            for (int i = (int)device.pageIndex; i < devices.Count; i++)
                            {
                                devices[i].pageIndex = devices[i].pageIndex - 1;
                                new TCPDeviceManage().UpdateByEntity(devices[i]);
                            }
                        }
                        Logger.Info(string.Format("删除设备成功：id:{0}、name:{1}", device.id, device.deviceName));
                        this.ShowSuccessTip("删除设备成功");
                    }
                    else
                    {
                        Logger.Info("取消删除");
                        //点击取消按钮
                        this.ShowSuccessTip("取消删除");
                    }
                }
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                this.ShowErrorDialog(e.Message);
                return;
            }
            
        }

        #endregion

        #region 配置通道
        //点击ucChannel(通道)的圈i
        //做到了代码的封闭性（多个控件使用一个点击事件）
        private void ucChannel_ShowInfo_Click(object sender, EventArgs ea)
        {
            try
            {
                //通过点击事件可以获得ucChannel上子控件的信息
                UCChannel ucChannel = (UCChannel)sender;
                Logger.Info(string.Format("配置通道：name:{0}、device:{1}", ucChannel.uiChannelName.Text.Trim(), this.tB_DeviceName.Text.Trim()));
                Sys sys = new SysManage().GetSysInfo()[0];
                if (sys.protocol == (int)Common.Protocol.RTU)
                {
                    var device = new RTUDeviceManage().GetByName(this.tB_DeviceName.Text.Trim())[0];
                    var Channel = new RTUChannelManage().GetByDeviceIdAndName(device.id, ucChannel.uiChannelName.Text.Trim());
                    string ChannelOldName = Channel.ChannelName;
                    var sensorIds = new RTUChannelManage().GetSensorIds();
                    var f_ChannelInfo = new F_ChannelInfo();
                    f_ChannelInfo.rTUChannel = Channel;
                    f_ChannelInfo.ChannelName.Text = Channel.ChannelName;
                    f_ChannelInfo.ChannelID.Text = Channel.ChannelID.ToString();
                    f_ChannelInfo.ChannelLabel.Text = Channel.ChannelLabel;
                    f_ChannelInfo.ChannelUnit.Text = Channel.ChannelUnit;
                    f_ChannelInfo.ChannelSensorType.SelectedIndex = Channel.sensorType == null ? -1 : (int)Channel.sensorType - 1;
                    f_ChannelInfo.ChannelSensorName.Text = Channel.sensorName;
                    //将数据库现以配置有的传感器id填充到传感器id的下拉框
                    if (sensorIds != null)
                    {
                        f_ChannelInfo.ChannelSensorId.Items.AddRange(sensorIds.ToArray());
                    }
                    f_ChannelInfo.ChannelSensorId.Text = Channel.sensorID;
                    if (Channel.isWaring == 1)
                    {
                        f_ChannelInfo.isWraning.Checked = true;
                    }
                    else
                    {
                        f_ChannelInfo.isWraning.Checked = false;
                    }
                    f_ChannelInfo.ChannelDecimalPlaces.Text = Channel.decimalPlaces == null ? "4" : Channel.decimalPlaces.ToString();//小数位默认选择4
                    f_ChannelInfo.ChannelSensorRangeL.Text = Channel.sensorRangeL == null ? "0.00" : Channel.sensorRangeL.ToString();
                    f_ChannelInfo.ChannelSensorRangeH.Text = Channel.sensorRangeH == null ? "0.00" : Channel.sensorRangeH.ToString();
                    f_ChannelInfo.ChannelWarning1L.Text = Channel.warning1L == null ? "0.00" : Channel.warning1L.ToString();
                    f_ChannelInfo.ChannelWarning1H.Text = Channel.warning1H == null ? "0.00" : Channel.warning1H.ToString();
                    f_ChannelInfo.ChannelWarning2L.Text = Channel.warning2L == null ? "0.00" : Channel.warning2L.ToString();
                    f_ChannelInfo.ChannelWarning2H.Text = Channel.warning2H == null ? "0.00" : Channel.warning2H.ToString();
                    f_ChannelInfo.ChannelWarning3L.Text = Channel.warning3L == null ? "0.00" : Channel.warning3L.ToString();
                    f_ChannelInfo.ChannelWarning3H.Text = Channel.warning3H == null ? "0.00" : Channel.warning3H.ToString();
                    if (Channel.ChannelType == null)
                    {
                        f_ChannelInfo.ChannelType.SelectedIndex = 4;//默认选择4~20mA
                    }
                    else
                    {
                        f_ChannelInfo.ChannelType.Text = Channel.ChannelType;
                    }
                    f_ChannelInfo.ShowDialog();
                    if (f_ChannelInfo.IsOK)
                    {
                        Channel.ChannelName = f_ChannelInfo.ChannelName.Text.Trim();
                        ucChannel.uiChannelName.Text = f_ChannelInfo.ChannelName.Text.Trim();
                        Channel.ChannelLabel = f_ChannelInfo.ChannelLabel.Text.Trim();
                        Channel.ChannelUnit = f_ChannelInfo.ChannelUnit.Text.Trim();
                        Channel.sensorType = f_ChannelInfo.ChannelSensorType.SelectedIndex + 1;//传感器类型不取0
                        Channel.sensorName = f_ChannelInfo.ChannelSensorName.Text.Trim();
                        Channel.sensorRangeL = double.Parse(f_ChannelInfo.ChannelSensorRangeL.Text.Trim());
                        Channel.sensorRangeH = double.Parse(f_ChannelInfo.ChannelSensorRangeH.Text.Trim());
                        if (f_ChannelInfo.isWraning.Checked)
                        {
                            Channel.isWaring = 1;
                        }
                        else
                        {
                            Channel.isWaring = 0;
                        }
                        Channel.decimalPlaces = int.Parse(f_ChannelInfo.ChannelDecimalPlaces.Text.Trim());
                        Channel.warning1L = double.Parse(f_ChannelInfo.ChannelWarning1L.Text.Trim());
                        Channel.warning1H = double.Parse(f_ChannelInfo.ChannelWarning1H.Text.Trim());
                        Channel.warning2L = double.Parse(f_ChannelInfo.ChannelWarning2L.Text.Trim());
                        Channel.warning2H = double.Parse(f_ChannelInfo.ChannelWarning2H.Text.Trim());
                        Channel.warning3L = double.Parse(f_ChannelInfo.ChannelWarning3L.Text.Trim());
                        Channel.warning3H = double.Parse(f_ChannelInfo.ChannelWarning3H.Text.Trim());
                        Channel.ChannelType = f_ChannelInfo.ChannelType.Text.Trim();
                        Channel.updateBy = "管理员";
                        Channel.updateTime = DateTime.Now;
                        //给通道配置传感器id与传感器表
                        Channel.sensorID = f_ChannelInfo.ChannelSensorId.Text.Trim();
                        Channel.sensorTableName = Common.SensorTable[f_ChannelInfo.ChannelSensorType.SelectedIndex + 1];
                        Form1.Instance.UpdateChildNodeName(ChannelOldName, Channel.ChannelName);
                        new RTUChannelManage().UpdateByEntity(Channel);
                        Logger.Info(string.Format("配置通道成功：newName{0}、device:{1}", Channel.ChannelName, this.tB_DeviceName.Text.Trim()));
                        this.ShowInfoTip("配置通道成功");
                    }
                }
                else if (sys.protocol == (int)Common.Protocol.TCP)
                {
                    var device = new TCPDeviceManage().GetByName(this.tB_DeviceName.Text.Trim())[0];
                    var Channel = new TCPChannelManage().GetByDeviceIdAndName(device.id, ucChannel.uiChannelName.Text.Trim());
                    string ChannelOldName = Channel.ChannelName;
                    var sensorIds = new TCPChannelManage().GetSensorIds();
                    var f_ChannelInfo = new F_ChannelInfo();
                    f_ChannelInfo.tCPChannel = Channel;
                    f_ChannelInfo.ChannelName.Text = Channel.ChannelName;
                    f_ChannelInfo.ChannelID.Text = Channel.ChannelID.ToString();
                    f_ChannelInfo.ChannelLabel.Text = Channel.ChannelLabel;
                    f_ChannelInfo.ChannelUnit.Text = Channel.ChannelUnit;
                    f_ChannelInfo.ChannelSensorType.SelectedIndex = Channel.sensorType == null ? -1 : (int)Channel.sensorType - 1;
                    f_ChannelInfo.ChannelSensorName.Text = Channel.sensorName;
                    //将数据库现以配置有的传感器id填充到传感器id的下拉框
                    if (sensorIds != null)
                    {
                        f_ChannelInfo.ChannelSensorId.Items.AddRange(sensorIds.ToArray());
                    }
                    f_ChannelInfo.ChannelSensorId.Text = Channel.sensorID;
                    if (Channel.isWaring == 1)
                    {
                        f_ChannelInfo.isWraning.Checked = true;
                    }
                    else
                    {
                        f_ChannelInfo.isWraning.Checked = false;
                    }
                    f_ChannelInfo.ChannelDecimalPlaces.Text = Channel.decimalPlaces == null ? "4" : Channel.decimalPlaces.ToString();//小数位默认选择4
                    f_ChannelInfo.ChannelSensorRangeL.Text = Channel.sensorRangeL == null ? "0.00" : Channel.sensorRangeL.ToString();
                    f_ChannelInfo.ChannelSensorRangeH.Text = Channel.sensorRangeH == null ? "0.00" : Channel.sensorRangeH.ToString();
                    f_ChannelInfo.ChannelWarning1L.Text = Channel.warning1L == null ? "0.00" : Channel.warning1L.ToString();
                    f_ChannelInfo.ChannelWarning1H.Text = Channel.warning1H == null ? "0.00" : Channel.warning1H.ToString();
                    f_ChannelInfo.ChannelWarning2L.Text = Channel.warning2L == null ? "0.00" : Channel.warning2L.ToString();
                    f_ChannelInfo.ChannelWarning2H.Text = Channel.warning2H == null ? "0.00" : Channel.warning2H.ToString();
                    f_ChannelInfo.ChannelWarning3L.Text = Channel.warning3L == null ? "0.00" : Channel.warning3L.ToString();
                    f_ChannelInfo.ChannelWarning3H.Text = Channel.warning3H == null ? "0.00" : Channel.warning3H.ToString();
                    if (Channel.ChannelType == null)
                    {
                        f_ChannelInfo.ChannelType.SelectedIndex = 4;//默认选择4~20mA
                    }
                    else
                    {
                        f_ChannelInfo.ChannelType.Text = Channel.ChannelType;
                    }

                    f_ChannelInfo.ShowDialog();
                    if (f_ChannelInfo.IsOK)
                    {
                        Channel.ChannelName = f_ChannelInfo.ChannelName.Text.Trim();
                        ucChannel.uiChannelName.Text = f_ChannelInfo.ChannelName.Text.Trim();
                        Channel.ChannelLabel = f_ChannelInfo.ChannelLabel.Text.Trim();
                        Channel.ChannelUnit = f_ChannelInfo.ChannelUnit.Text.Trim();
                        Channel.sensorType = f_ChannelInfo.ChannelSensorType.SelectedIndex + 1;//传感器类型不取0
                        Channel.sensorName = f_ChannelInfo.ChannelSensorName.Text.Trim();
                        Channel.sensorRangeL = double.Parse(f_ChannelInfo.ChannelSensorRangeL.Text.Trim());
                        Channel.sensorRangeH = double.Parse(f_ChannelInfo.ChannelSensorRangeH.Text.Trim());
                        if (f_ChannelInfo.isWraning.Checked)
                        {
                            Channel.isWaring = 1;
                        }
                        else
                        {
                            Channel.isWaring = 0;
                        }
                        Channel.decimalPlaces = int.Parse(f_ChannelInfo.ChannelDecimalPlaces.Text.Trim());
                        Channel.warning1L = double.Parse(f_ChannelInfo.ChannelWarning1L.Text.Trim());
                        Channel.warning1H = double.Parse(f_ChannelInfo.ChannelWarning1H.Text.Trim());
                        Channel.warning2L = double.Parse(f_ChannelInfo.ChannelWarning2L.Text.Trim());
                        Channel.warning2H = double.Parse(f_ChannelInfo.ChannelWarning2H.Text.Trim());
                        Channel.warning3L = double.Parse(f_ChannelInfo.ChannelWarning3L.Text.Trim());
                        Channel.warning3H = double.Parse(f_ChannelInfo.ChannelWarning3H.Text.Trim());
                        Channel.ChannelType = f_ChannelInfo.ChannelType.Text.Trim();
                        Channel.updateBy = "管理员";
                        Channel.updateTime = DateTime.Now;
                        //给通道配置传感器id与传感器表
                        Channel.sensorID = f_ChannelInfo.ChannelSensorId.Text.Trim();
                        Channel.sensorTableName = Common.SensorTable[f_ChannelInfo.ChannelSensorType.SelectedIndex + 1];
                        Form1.Instance.UpdateChildNodeName(ChannelOldName, Channel.ChannelName);
                        new TCPChannelManage().UpdateByEntity(Channel);
                        Logger.Info(string.Format("配置通道成功：newName{0}、device:{1}", Channel.ChannelName, this.tB_DeviceName.Text.Trim()));
                        this.ShowInfoTip("配置通道成功");
                    }
                }
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                this.ShowErrorDialog(e.Message);
                return;
            }

        }
        #endregion

        #region 开始采集
        private void BtnStart_Click(object sender, EventArgs ea)
        {
            try
            {
                if (this.deviceStatus == (int)Common.DeviceStatus.START)
                {
                    return;
                }
                Logger.Info(string.Format("设备{0}开始采集", this.tB_DeviceName.Text.Trim()));
                int protocol = new SysManage().GetSysInfo()[0].protocol;
                /////////////////////////////RTU协议下的采集///////////////////////////////
                if (protocol == (int)Common.Protocol.RTU)
                {
                    RTUDevice rTUDevice = new RTUDeviceManage().GetByName(this.tB_DeviceName.Text.Trim())[0];
                    if (rTUDevice.status == (int)Common.DeviceStatus.START)
                    {
                        return;
                    }

                    if (rTUDevice == null)
                    {
                        Logger.Error(string.Format("设备{0}不存在", this.tB_DeviceName.Text.Trim()));
                        this.ShowErrorDialog(string.Format("设备{0}不存在", this.tB_DeviceName.Text.Trim()));
                        return;
                    }
                    //检查设备串口是否插在电脑上
                    //获取可用串口
                    List<string> serialPorts = System.IO.Ports.SerialPort.GetPortNames().ToList();
                    if (rTUDevice.serialPort == null || rTUDevice.serialPort.Length == 0)
                    {
                        Logger.Info(string.Format("设备{0}未配置串口", this.tB_DeviceName.Text.Trim()));
                        this.ShowErrorDialog(string.Format("设备{0}未配置串口", this.tB_DeviceName.Text.Trim()));
                        return;
                    }
                    if (!serialPorts.Contains(rTUDevice.serialPort))
                    {
                        Logger.Info(string.Format("串口{0}不存在", rTUDevice.serialPort));
                        this.ShowWarningDialog(string.Format("串口{0}不存在", rTUDevice.serialPort));
                        return;
                    }
                    //以上判断通过方可进行采集
                    //TP1608要求数据位为8，无奇偶校验，停止位为1
                    SerialPort serialPort = new SerialPort(rTUDevice.serialPort, int.Parse(rTUDevice.baudRate), Parity.None, 8, StopBits.One);
                    //将串口实例与设备实例成对存下来
                    bool f = false;
                    foreach (var key in ModbusUtil.RTUdevices.Keys)
                    {
                        if (key.PortName.Equals(serialPort.PortName))
                        {
                            //串口已经在采集，那么不用创建新的线程，只需在串口的设备列表增加设备（设备地址可复用：一个地址对应多个F_TitlePage）
                            if (ModbusUtil.RTUdevices[key].Keys.Contains(rTUDevice.deviceAddress))
                            {
                                ModbusUtil.RTUdevices[key][rTUDevice.deviceAddress].Add(rTUDevice);
                            }
                            else
                            {
                                List<RTUDevice> rTUDevices = new List<RTUDevice>();
                                rTUDevices.Add(rTUDevice);
                                ModbusUtil.RTUdevices[key].Add(rTUDevice.deviceAddress, rTUDevices);
                            }
                            //把当前窗体存下来（设备地址可复用：一个地址对应多个F_TitlePage）
                            if (ModbusUtil.F_TitlePages.Keys.Contains(rTUDevice.deviceAddress))
                            {
                                ModbusUtil.F_TitlePages[rTUDevice.deviceAddress].Add(this);
                            }
                            else
                            {
                                List<F_TitlePage> f_TitlePages = new List<F_TitlePage>();
                                f_TitlePages.Add(this);
                                ModbusUtil.F_TitlePages.Add(rTUDevice.deviceAddress, f_TitlePages);
                            }
                            f = true;
                            break;
                        }
                    }
                    //串口没有在采集，那么要创建新的线程，为串口新建设备列表，并增加当前设备
                    if (!f)
                    {
                        var devices = new Dictionary<string, List<RTUDevice>>();
                        List<RTUDevice> rTUDevices = new List<RTUDevice>();
                        rTUDevices.Add(rTUDevice);
                        devices.Add(rTUDevice.deviceAddress, rTUDevices);

                        ModbusUtil.RTUdevices.Add(serialPort, devices);
                        //把当前窗体存下来（设备地址可复用：一个地址对应多个F_TitlePage）
                        if (ModbusUtil.F_TitlePages.Keys.Contains(rTUDevice.deviceAddress))
                        {
                            ModbusUtil.F_TitlePages[rTUDevice.deviceAddress].Add(this);
                        }
                        else
                        {
                            List<F_TitlePage> f_TitlePages = new List<F_TitlePage>();
                            f_TitlePages.Add(this);
                            ModbusUtil.F_TitlePages.Add(rTUDevice.deviceAddress, f_TitlePages);
                        }
                        //设置信号灯，当创建线程没有设备在创建时设为true，以停止采集线程
                        bool signal_STOP = false;
                        ModbusUtil.RTUSignals.Add(serialPort, signal_STOP);
                        //打开串口
                        try
                        {
                            if (!serialPort.IsOpen)
                            {
                                serialPort.Open();
                            }
                        }
                        catch (Exception)
                        {
                            Logger.Error(string.Format("串口{0}打开失败！", serialPort.PortName));
                            this.ShowErrorDialog(string.Format("串口{0}打开失败！", serialPort.PortName));
                        }
                        //新建一个采集线程
                        Thread thread = new Thread(new ParameterizedThreadStart(this.RTUDataCollect));//调用方法，需要提供参数：串口（用于实例化master）
                        thread.Name = serialPort.PortName + "的采集线程";
                        thread.IsBackground = true;//后台线程，关闭程序时，线程也会停止
                        thread.Start(serialPort);
                        //存下线程，在串口串口的采集设备列表为空时，要停止线程（通过跳出所调用的采集方法中的while循环）
                        ModbusUtil.RTUThreads.Add(serialPort, thread);
                    }
                    //设置开始采集和停止采集按钮的图片
                    this.BtnStart.Image = Properties.Resources.start1;//开始采集熄灭
                    this.BtnStop.Image = Properties.Resources.stop2;//停止采集亮
                    this.deviceStatus = (int)Common.DeviceStatus.START;
                    //设置设备为采集状态（status字段变为1）
                    new RTUDeviceManage().UpdateStatusByName(rTUDevice.deviceName, (int)Common.DeviceStatus.START);
                }
                /////////////////////////////TCP协议下的采集///////////////////////////////
                else if (protocol == (int)Common.Protocol.TCP)
                {
                    TCPDevice tCPDevice = new TCPDeviceManage().GetByName(this.tB_DeviceName.Text.Trim())[0];
                    if (tCPDevice.status == (int)Common.DeviceStatus.START)
                    {
                        return;
                    }
                    if (tCPDevice == null)
                    {
                        Logger.Error(string.Format("设备{0}不存在", this.tB_DeviceName.Text.Trim()));
                        this.ShowErrorDialog(string.Format("设备{0}不存在", this.tB_DeviceName.Text.Trim()));
                        return;
                    }
                    if (tCPDevice.hostName == null || tCPDevice.hostName.Length == 0)
                    {
                        Logger.Error(string.Format("设备{0}未配置从站IP", this.tB_DeviceName.Text.Trim()));
                        this.ShowErrorDialog(string.Format("设备{0}未配置从站IP", this.tB_DeviceName.Text.Trim()));
                        return;
                    }
                    if (tCPDevice.port == null || tCPDevice.port.Length == 0)
                    {
                        Logger.Error(string.Format("设备{0}未配置从站端口号", this.tB_DeviceName.Text.Trim()));
                        this.ShowErrorDialog(string.Format("设备{0}未配置从站端口号", this.tB_DeviceName.Text.Trim()));
                        return;
                    }

                    //创建TCP客户端
                    try
                    {
                        //将TCP客户端实例tcpClient与设备实例tCPDevice存下来
                        bool f = false;
                        foreach (var key in ModbusUtil.TCPdevices.Keys)
                        {
                            if (key.Equals(tCPDevice.hostName))
                            {
                                //TCP客户端实例tcpClient已经在采集，那么不用创建新的线程，只需在串口的设备列表增加设备（设备地址可复用：一个地址对应多个F_TitlePage）
                                if (ModbusUtil.TCPdevices[key].Keys.Contains(tCPDevice.deviceAddress))
                                {
                                    ModbusUtil.TCPdevices[key][tCPDevice.deviceAddress].Add(tCPDevice);
                                }
                                else
                                {
                                    List<TCPDevice> tCPDevices = new List<TCPDevice>();
                                    tCPDevices.Add(tCPDevice);
                                    ModbusUtil.TCPdevices[key].Add(tCPDevice.deviceAddress, tCPDevices);
                                }
                                //把当前窗体存下来（设备地址可复用：一个地址对应多个F_TitlePage）
                                if (ModbusUtil.F_TitlePages.Keys.Contains(tCPDevice.deviceAddress))
                                {
                                    ModbusUtil.F_TitlePages[tCPDevice.deviceAddress].Add(this);
                                }
                                else
                                {
                                    List<F_TitlePage> f_TitlePages = new List<F_TitlePage>();
                                    f_TitlePages.Add(this);
                                    ModbusUtil.F_TitlePages.Add(tCPDevice.deviceAddress, f_TitlePages);
                                }
                                f = true;
                                break;
                            }
                        }
                        //tcpClient没有在采集，那么要创建新的线程，为tcpClient新建设备列表，并增加当前设备
                        if (!f)
                        {
                            var devices = new Dictionary<string, List<TCPDevice>>();
                            List<TCPDevice> tCPDevices = new List<TCPDevice>();
                            tCPDevices.Add(tCPDevice);
                            devices.Add(tCPDevice.deviceAddress, tCPDevices);
                            ModbusUtil.TCPdevices.Add(tCPDevice.hostName, devices);
                            //把当前窗体存下来（设备地址可复用：一个地址对应多个F_TitlePage）
                            if (ModbusUtil.F_TitlePages.Keys.Contains(tCPDevice.deviceAddress))
                            {
                                ModbusUtil.F_TitlePages[tCPDevice.deviceAddress].Add(this);
                            }
                            else
                            {
                                List<F_TitlePage> f_TitlePages = new List<F_TitlePage>();
                                f_TitlePages.Add(this);
                                ModbusUtil.F_TitlePages.Add(tCPDevice.deviceAddress, f_TitlePages);
                            }
                            //设置信号灯，当创建线程没有设备在创建时设为true，以停止采集线程
                            bool signal_STOP = false;
                            ModbusUtil.TCPSignals.Add(tCPDevice.hostName, signal_STOP);
                            //新建一个采集线程
                            Thread thread = new Thread(new ParameterizedThreadStart(this.TCPDataCollect));//调用方法，需要提供参数：串口（用于实例化master）
                            thread.Name = tCPDevice.hostName + "的采集线程";
                            thread.IsBackground = true;//后台线程，关闭程序时，线程也会停止
                            thread.Start(tCPDevice.hostName);
                            //存下线程，在串口串口的采集设备列表为空时，要停止线程（通过跳出所调用的采集方法中的while循环）
                            ModbusUtil.TCPThreads.Add(tCPDevice.hostName, thread);
                        }
                        //设置开始采集和停止采集按钮的图片
                        this.BtnStart.Image = Properties.Resources.start1;//开始采集熄灭
                        this.BtnStop.Image = Properties.Resources.stop2;//停止采集亮
                        this.deviceStatus = (int)Common.DeviceStatus.START;
                        //设置设备为采集状态（status字段变为1）
                        new TCPDeviceManage().UpdateStatusByName(tCPDevice.deviceName, (int)Common.DeviceStatus.START);

                    }
                    catch (Exception e)
                    {
                        Logger.Error(e.Message);
                        this.ShowErrorDialog(e.Message);
                    }
                }
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                this.ShowErrorDialog(e.Message);
                return;
            }

        }
        #endregion

        #region RTU协议下的采集方法
        public void RTUDataCollect(object serialPort)
        {
            //新建一个master
            Modbus.Device.IModbusMaster RTUMaster = ModbusSerialMaster.CreateRtu((SerialPort)serialPort);
            RTUMaster.Transport.ReadTimeout = 5000;
            RTUMaster.Transport.Retries = 8000;
            ThreadPool.SetMaxThreads(8, 8);//使用线程池来写数据库，异步来提高速度
            while (!ModbusUtil.RTUSignals[(SerialPort)serialPort])
            {
                List<List<RTUDevice>> devices = ModbusUtil.RTUdevices[(SerialPort)serialPort].Values.ToList();
                List<RTUDevice> rTUDevices = new List<RTUDevice>();
                for (int i = 0; i < devices.Count; i++)
                {
                    rTUDevices.AddRange(devices[i]);
                }

                for (int i = 0; i < rTUDevices.Count; i++)
                {
                    try
                    {
                        //读取设备的寄存器数据（8个通道，一个通道2个寄存器），参数：设备地址，起始地址，寄存器数
                        ushort[] registerBuffer = RTUMaster.ReadHoldingRegisters(byte.Parse(rTUDevices[i].deviceAddress), 0, 16);
                        //ushort[]=>float[]
                        float[] result = DataTypeConvert.GetReal(registerBuffer, 0);//得到8个32位浮点数
                        List<RTUChannel> rTUChannels = new RTUChannelManage().GetByDeviceId(rTUDevices[i].id);
                        foreach (RTUChannel rTUChannel in rTUChannels)
                        {
                            if (rTUChannel.sensorID != null && rTUChannel.sensorID.Length != 0)
                            {
                                Sensor sensor = new Sensor();
                                sensor.sensorId = rTUChannel.sensorID;
                                sensor.sensorName = rTUChannel.sensorName;
                                sensor.sensorType = rTUChannel.sensorType.ToString();/////这是int,要改
                                sensor.sensorLabel = rTUChannel.ChannelLabel;
                                double value = (result[(int)rTUChannel.ChannelID - 1] - 4.0F) / (20.0F - 4.0F) * ((double)rTUChannel.sensorRangeH - (double)rTUChannel.sensorRangeL);
                                value = double.Parse((value + (double)rTUChannel.sensorRangeL).ToString("F" + rTUChannel.decimalPlaces));
                                sensor.sensorValue = value.ToString();
                                sensor.sensorUnit = rTUChannel.ChannelUnit;
                                sensor.createBy = "传感器" + sensor.sensorId;
                                sensor.createTime = DateTime.Now;
                                sensor.tableName = rTUChannel.sensorTableName;
                                //数据入库
                                ThreadPool.QueueUserWorkItem(new WaitCallback(WriteSensorData2DB), sensor);
                                //接下来做显示
                                //找出当前（看到的）设备对应的F_TitlePage
                                try
                                {
                                    List<F_TitlePage> f_TitlePages = ModbusUtil.F_TitlePages[rTUDevices[i].deviceAddress];
                                    foreach (var f in f_TitlePages)
                                    {
                                        if (f.tB_DeviceName.Text.Equals(rTUDevices[i].deviceName))
                                        {
                                            if (f.Xs[(int)rTUChannel.ChannelID].Count < 30)
                                            {
                                                f.Xs[(int)rTUChannel.ChannelID].Add((DateTime)sensor.createTime);
                                                f.Ys[(int)rTUChannel.ChannelID].Add(value);
                                            }
                                            else
                                            {
                                                f.Xs[(int)rTUChannel.ChannelID].Add((DateTime)sensor.createTime);
                                                f.Ys[(int)rTUChannel.ChannelID].Add(value);
                                                f.Xs[(int)rTUChannel.ChannelID].RemoveAt(0);
                                                f.Ys[(int)rTUChannel.ChannelID].RemoveAt(0);
                                            }
                                            this.SetUcChannelValue(rTUChannel.ChannelID, sensor.sensorValue, sensor.sensorUnit, sensor.createTime.ToString(), f);
                                            break;
                                        }
                                    }
                                }
                                catch (Exception)
                                {
                                    continue;
                                }

                            }
                        }
                    }
                    catch (Exception e)
                    {
                        this.ShowErrorDialog("采集中发生错误:\r\n" + e.Message);
                    }

                }
                Thread.Sleep(1000);//采集线程睡眠1s
            }
            //while循环停止则说明将会停止采集线程，但在采集线程停止前，要确保线程池的任务结束
            int availableThreads = 0;
            int maxWorkerThreads = 0;
            int completionPortThreads = 0;
            System.Threading.ThreadPool.GetAvailableThreads(out availableThreads, out completionPortThreads);
            System.Threading.ThreadPool.GetMaxThreads(out maxWorkerThreads, out completionPortThreads);
            //当线程池的可用线程数与最大线程数不等时说明还没结束，则阻塞父线程进行等待
            while (availableThreads != maxWorkerThreads)
            {
                Thread.Sleep(50);
                System.Threading.ThreadPool.GetAvailableThreads(out availableThreads, out completionPortThreads);
                System.Threading.ThreadPool.GetMaxThreads(out maxWorkerThreads, out completionPortThreads);
            }
            //采集线程停止后
            //1、把信号灯移除
            ModbusUtil.RTUSignals.Remove((SerialPort)serialPort);
            //2、从采集的串口列表移除串口
            ModbusUtil.RTUdevices.Remove(((SerialPort)serialPort));
            //3、关闭串口
            try
            {
                if (((SerialPort)serialPort).IsOpen)
                {
                    ((SerialPort)serialPort).Close();
                }
            }
            catch (Exception)
            {
                this.ShowErrorDialog(string.Format("关闭串口{0}失败！", ((SerialPort)serialPort).PortName));
            }
        }
        #endregion

        #region TCP协议下的采集方法
        private void TCPDataCollect(object obj)
        {
            NModbus.IModbusMaster TCPMaster;
            ThreadPool.SetMaxThreads(8, 8);//使用线程池来写数据库，异步来提高速度
            int ReTryTimes = 0;//记录重连次数
            while (!ModbusUtil.TCPSignals[(string)obj])
            {
                try
                {
                    /*
                     * 将所有采集设备整理到一个List中
                     */
                    List<List<TCPDevice>> devices = ModbusUtil.TCPdevices[(string)obj].Values.ToList();
                    List<TCPDevice> tCPDevices = new List<TCPDevice>();
                    for (int i = 0; i < devices.Count; i++)
                    {
                        tCPDevices.AddRange(devices[i]);
                    }
                    /*
                     * 轮询每一个设备
                     */
                    for (int i = 0; i < tCPDevices.Count; i++)
                    {
                        try
                        {
                            TCPMaster = new ModbusFactory().CreateMaster(new TcpClient((string)obj, 502));
                            TCPMaster.Transport.ReadTimeout = 5000;//读取超时时间
                            TCPMaster.Transport.Retries = 10;//重连次数
                            TCPMaster.Transport.WaitToRetryMilliseconds = 250;//重试间隔
                            ushort[] registerBuffer = TCPMaster.ReadHoldingRegisters(byte.Parse(tCPDevices[i].deviceAddress), 0, 16);//读取设备的寄存器数据（8个通道，一个通道2个寄存器），参数：设备地址，起始地址，寄存器数
                            ReTryTimes = 0;
                            /*
                             * ushort[]转float[]
                             */
                            float[] result = DataTypeConvert.GetReal(registerBuffer, 0);//得到8个32位浮点数
                            /*
                             * 将采集到的数据放到传感器对象，然后存到数据库
                             */
                            List<TCPChannel> tCPChannels = new TCPChannelManage().GetByDeviceId(tCPDevices[i].id);
                            foreach (TCPChannel tCPChannel in tCPChannels)
                            {
                                if (tCPChannel.sensorID != null && tCPChannel.sensorID.Length != 0)
                                {
                                    Sensor sensor = new Sensor();
                                    sensor.sensorId = tCPChannel.sensorID;
                                    sensor.sensorName = tCPChannel.sensorName;
                                    sensor.sensorType = tCPChannel.sensorType.ToString();
                                    sensor.sensorLabel = tCPChannel.ChannelLabel;
                                    double value = (result[(int)tCPChannel.ChannelID - 1] - 4.0F) / (20.0F - 4.0F) * ((double)tCPChannel.sensorRangeH - (double)tCPChannel.sensorRangeL);
                                    value = double.Parse((value + (double)tCPChannel.sensorRangeL).ToString("F" + tCPChannel.decimalPlaces));
                                    sensor.sensorValue = value.ToString();
                                    sensor.sensorUnit = tCPChannel.ChannelUnit;
                                    sensor.createBy = "传感器" + sensor.sensorId;
                                    sensor.createTime = DateTime.Now;
                                    sensor.tableName = tCPChannel.sensorTableName;
                                    //sensor.tableName = "sensor";
                                    //数据入库
                                    ThreadPool.QueueUserWorkItem(new WaitCallback(WriteSensorData2DB), sensor);
                                    //接下来做显示
                                    //找出当前（看到的）设备对应的F_TitlePage
                                    try
                                    {
                                        List<F_TitlePage> f_TitlePages = ModbusUtil.F_TitlePages[tCPDevices[i].deviceAddress];
                                        for (int fi = 0; fi < f_TitlePages.Count; fi++)
                                        {
                                            if (f_TitlePages[fi].tB_DeviceName.Text.Trim().Equals(tCPDevices[i].deviceName))
                                            {
                                                if (f_TitlePages[fi].Xs[(int)tCPChannel.ChannelID].Count < 30)
                                                {
                                                    f_TitlePages[fi].Xs[(int)tCPChannel.ChannelID].Add((DateTime)sensor.createTime);
                                                    f_TitlePages[fi].Ys[(int)tCPChannel.ChannelID].Add(value);
                                                }
                                                else
                                                {
                                                    for (int j = 0; j < f_TitlePages[fi].Xs[(int)tCPChannel.ChannelID].Count - 1; j++)
                                                    {
                                                        f_TitlePages[fi].Xs[(int)tCPChannel.ChannelID][j] = f_TitlePages[fi].Xs[(int)tCPChannel.ChannelID][j + 1];
                                                        f_TitlePages[fi].Ys[(int)tCPChannel.ChannelID][j] = f_TitlePages[fi].Ys[(int)tCPChannel.ChannelID][j + 1];
                                                    }
                                                    f_TitlePages[fi].Xs[(int)tCPChannel.ChannelID][f_TitlePages[fi].Xs[(int)tCPChannel.ChannelID].Count - 1] = (DateTime)sensor.createTime;
                                                    f_TitlePages[fi].Ys[(int)tCPChannel.ChannelID][f_TitlePages[fi].Xs[(int)tCPChannel.ChannelID].Count - 1] = value;
                                                }
                                                this.SetUcChannelValue(tCPChannel.ChannelID, sensor.sensorValue, sensor.sensorUnit, sensor.createTime.ToString(), f_TitlePages[fi]);
                                                break;
                                            }
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        Logger.Error(e.Message);
                                        continue;
                                    }
                                }
                            }
                            TCPMaster.Dispose();
                            Thread.Sleep(50);//每个设备之间采集间隔
                        }
                        catch (IOException ie)
                        {
                            ReTryTimes++;
                            Logger.Error(string.Format("{0}: {1}-{2}({3})", ie.GetType().Name, ie.Message, DateTime.Now, ReTryTimes));
                            if (ReTryTimes > 10)
                            {
                                i--;
                                continue;
                            }
                        }
                        catch (TimeoutException te)
                        {
                            ReTryTimes++;
                            Logger.Error(string.Format("{0}: {1}-{2}({3})", te.GetType().Name, te.Message, DateTime.Now, ReTryTimes));
                            if (ReTryTimes > 10)
                            {
                                i--;
                                continue;
                            }
                        }
                        catch (SocketException se)
                        {
                            ReTryTimes++;
                            Logger.Error(string.Format("{0}: {1}-{2}({3})", se.GetType().Name, se.Message, DateTime.Now, ReTryTimes));
                            if (ReTryTimes > 10)
                            {
                                i--;
                                continue;
                            }
                        }
                        catch (Exception e)
                        {
                            Logger.Error(string.Format("{0}: {1}-{2}", e.GetType().Name,DateTime.Now.ToString(),e.Message));
                            this.ShowErrorDialog(string.Format("{0}: {1}-{2}", e.GetType().Name, DateTime.Now.ToString(), e.Message));
                            List<string> deviceAddress = ModbusUtil.F_TitlePages.Keys.ToList();
                            int countj = deviceAddress.Count;
                            for (int j = 0; j < countj; j++)
                            {
                                List<F_TitlePage> f_TitlePages = ModbusUtil.F_TitlePages[deviceAddress[j]];
                                int countk = f_TitlePages.Count;
                                for (int k = 0; k < countk; k++)
                                {
                                    ModbusUtil.F_TitlePages[deviceAddress[j]][0].BtnStop_Click(this, new EventArgs());
                                }
                            }
                        }
                    }
                    Thread.Sleep(500);//采集线程睡眠1s
                }
                catch (Exception e)
                {
                    Logger.Error(string.Format("{0}: {1}-{2}", e.GetType().Name, DateTime.Now.ToString(), e.Message));
                    this.ShowErrorDialog(string.Format("{0}: {1}-{2}", e.GetType().Name, DateTime.Now.ToString(), e.Message));
                    List<string> deviceAddress = ModbusUtil.F_TitlePages.Keys.ToList();
                    int countj = deviceAddress.Count;
                    for (int j = 0; j < countj; j++)
                    {
                        List<F_TitlePage> f_TitlePages = ModbusUtil.F_TitlePages[deviceAddress[j]];
                        int countk = f_TitlePages.Count;
                        for (int k = 0; k < countk; k++)
                        {
                            ModbusUtil.F_TitlePages[deviceAddress[j]][0].BtnStop_Click(this, new EventArgs());
                        }
                    }
                }
            }
            //while循环停止则说明将会停止采集线程，但在采集线程停止前，要确保线程池的任务结束
            int availableThreads = 0;
            int maxWorkerThreads = 0;
            int completionPortThreads = 0;
            System.Threading.ThreadPool.GetAvailableThreads(out availableThreads, out completionPortThreads);
            System.Threading.ThreadPool.GetMaxThreads(out maxWorkerThreads, out completionPortThreads);
            //当线程池的可用线程数与最大线程数不等时说明还没结束，则阻塞父线程进行等待
            while (availableThreads != maxWorkerThreads)
            {
                Thread.Sleep(50);
                System.Threading.ThreadPool.GetAvailableThreads(out availableThreads, out completionPortThreads);
                System.Threading.ThreadPool.GetMaxThreads(out maxWorkerThreads, out completionPortThreads);
            }
            //采集线程停止后
            //1、把信号灯移除
            ModbusUtil.TCPSignals.Remove((string)obj);
            //2、从采集的IP列表移除IP
            ModbusUtil.TCPdevices.Remove(((string)obj));
        }
        #endregion

        #region 通道控件显示数据
        private void SetUcChannelValue(int? ChannelID, string sensorValue, string sensorUnit, string createTime, F_TitlePage f_TitlePage)
        {
            //值显示
            switch (ChannelID)
            {
                case 1:
                    if (f_TitlePage.ucChannel1.InvokeRequired)
                    {
                        Action<string, string, string> actionDelegate = (value, unit, time) =>
                        {
                            f_TitlePage.ucChannel1.uiChannelData.Text = value.ToString();
                            f_TitlePage.ucChannel1.uiChannelUnit.Text = unit.ToString();
                            f_TitlePage.ucChannel1.uiChannelTime.Text = time.ToString();
                        };
                        // 或者
                        // Action<string> actionDelegate = delegate(string txt) { this.ucChannel1.uiChannelData.Text = x.ToString(); };
                        f_TitlePage.ucChannel1.Invoke(actionDelegate, sensorValue, sensorUnit, createTime);
                    }
                    break;
                case 2:
                    if (f_TitlePage.ucChannel2.InvokeRequired)
                    {
                        Action<string, string, string> actionDelegate = (value, unit, time) =>
                        {
                            f_TitlePage.ucChannel2.uiChannelData.Text = value.ToString();
                            f_TitlePage.ucChannel2.uiChannelUnit.Text = unit.ToString();
                            f_TitlePage.ucChannel2.uiChannelTime.Text = time.ToString();
                        };
                        f_TitlePage.ucChannel2.Invoke(actionDelegate, sensorValue, sensorUnit, createTime);
                    }
                    break;
                case 3:
                    if (f_TitlePage.ucChannel3.InvokeRequired)
                    {
                        Action<string, string, string> actionDelegate = (value, unit, time) =>
                        {
                            f_TitlePage.ucChannel3.uiChannelData.Text = value.ToString();
                            f_TitlePage.ucChannel3.uiChannelUnit.Text = unit.ToString();
                            f_TitlePage.ucChannel3.uiChannelTime.Text = time.ToString();
                        };
                        f_TitlePage.ucChannel3.Invoke(actionDelegate, sensorValue, sensorUnit, createTime);
                    }
                    break;
                case 4:
                    if (f_TitlePage.ucChannel4.InvokeRequired)
                    {
                        Action<string, string, string> actionDelegate = (value, unit, time) =>
                        {
                            f_TitlePage.ucChannel4.uiChannelData.Text = value.ToString();
                            f_TitlePage.ucChannel4.uiChannelUnit.Text = unit.ToString();
                            f_TitlePage.ucChannel4.uiChannelTime.Text = time.ToString();
                        };
                        f_TitlePage.ucChannel4.Invoke(actionDelegate, sensorValue, sensorUnit, createTime);
                    }
                    break;
                case 5:
                    if (f_TitlePage.ucChannel5.InvokeRequired)
                    {
                        Action<string, string, string> actionDelegate = (value, unit, time) =>
                        {
                            f_TitlePage.ucChannel5.uiChannelData.Text = value.ToString();
                            f_TitlePage.ucChannel5.uiChannelUnit.Text = unit.ToString();
                            f_TitlePage.ucChannel5.uiChannelTime.Text = time.ToString();
                        };
                        f_TitlePage.ucChannel5.Invoke(actionDelegate, sensorValue, sensorUnit, createTime);
                    }
                    break;
                case 6:
                    if (f_TitlePage.ucChannel6.InvokeRequired)
                    {
                        Action<string, string, string> actionDelegate = (value, unit, time) =>
                        {
                            f_TitlePage.ucChannel6.uiChannelData.Text = value.ToString();
                            f_TitlePage.ucChannel6.uiChannelUnit.Text = unit.ToString();
                            f_TitlePage.ucChannel6.uiChannelTime.Text = time.ToString();
                        };
                        f_TitlePage.ucChannel6.Invoke(actionDelegate, sensorValue, sensorUnit, createTime);
                    }
                    break;
                case 7:
                    if (f_TitlePage.ucChannel7.InvokeRequired)
                    {
                        Action<string, string, string> actionDelegate = (value, unit, time) =>
                        {
                            f_TitlePage.ucChannel7.uiChannelData.Text = value.ToString();
                            f_TitlePage.ucChannel7.uiChannelUnit.Text = unit.ToString();
                            f_TitlePage.ucChannel7.uiChannelTime.Text = time.ToString();
                        };
                        f_TitlePage.ucChannel7.Invoke(actionDelegate, sensorValue, sensorUnit, createTime);
                    }
                    break;
                case 8:
                    if (f_TitlePage.ucChannel8.InvokeRequired)
                    {
                        Action<string, string, string> actionDelegate = (value, unit, time) =>
                        {
                            f_TitlePage.ucChannel8.uiChannelData.Text = value.ToString();
                            f_TitlePage.ucChannel8.uiChannelUnit.Text = unit.ToString();
                            f_TitlePage.ucChannel8.uiChannelTime.Text = time.ToString();
                        };
                        f_TitlePage.ucChannel8.Invoke(actionDelegate, sensorValue, sensorUnit, createTime);
                    }
                    break;

            }
            //曲线图
            if (f_TitlePage.chart1.InvokeRequired)
            {
                Action<List<DateTime>, List<double>/*, double*/> actionDelegate = (x, y/*, y_Min*/) =>
                {
                    switch (f_TitlePage.selectedChannelID)
                    {
                        case 1:
                            f_TitlePage.chart1.Titles[0].Text = f_TitlePage.ucChannel1.uiChannelName.Text.Trim();
                            break;
                        case 2:
                            f_TitlePage.chart1.Titles[0].Text = f_TitlePage.ucChannel2.uiChannelName.Text.Trim();
                            break;
                        case 3:
                            f_TitlePage.chart1.Titles[0].Text = f_TitlePage.ucChannel3.uiChannelName.Text.Trim();
                            break;
                        case 4:
                            f_TitlePage.chart1.Titles[0].Text = f_TitlePage.ucChannel4.uiChannelName.Text.Trim();
                            break;
                        case 5:
                            f_TitlePage.chart1.Titles[0].Text = f_TitlePage.ucChannel5.uiChannelName.Text.Trim();
                            break;
                        case 6:
                            f_TitlePage.chart1.Titles[0].Text = f_TitlePage.ucChannel6.uiChannelName.Text.Trim();
                            break;
                        case 7:
                            f_TitlePage.chart1.Titles[0].Text = f_TitlePage.ucChannel7.uiChannelName.Text.Trim();
                            break;
                        case 8:
                            f_TitlePage.chart1.Titles[0].Text = f_TitlePage.ucChannel8.uiChannelName.Text.Trim();
                            break;

                    }
                    f_TitlePage.chart1.Series[0].MarkerStyle = MarkerStyle.Circle;
                    if (x.Count != 0)
                    {
                        f_TitlePage.chart1.ChartAreas[0].AxisX.Minimum = x[0].ToOADate();
                    }
                    f_TitlePage.chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Milliseconds;//如果是时间类型的数据，间隔方式可以是秒、分、时
                    f_TitlePage.chart1.Series[0].Points.DataBindXY(x, y);

                    //f_TitlePage.chart1.ChartAreas[0].AxisY.Minimum = y_Min;
                };
                //List<double> y_Sorted = f_TitlePage.Ys[f_TitlePage.selectedChannelID];
                //y_Sorted.Sort();
                
                f_TitlePage.chart1.Invoke(actionDelegate, f_TitlePage.Xs[f_TitlePage.selectedChannelID], f_TitlePage.Ys[f_TitlePage.selectedChannelID]/*, y_Sorted[0]*/);

            }
            else
            {
                f_TitlePage.chart1.Series[0].Points.DataBindXY(f_TitlePage.Xs[f_TitlePage.selectedChannelID], f_TitlePage.Ys[f_TitlePage.selectedChannelID]);
            }

        }
        #endregion

        #region 数据入库
        private static void WriteSensorData2DB(object obj)
        {
            Sensor sensor = (Sensor)obj;
            new SensorManage().InsertByTableName(sensor.tableName, sensor);
            //把最新值存到snesor表
            Sensor sensor1 = new SensorManage().GetByTableNameAndSensorId("sensor", sensor.sensorId);
            if (sensor1 == null)
            {
                new SensorManage().InsertByTableName("sensor", sensor);
            }
            else
            {
                new SensorManage().UpdateByTableNameAndSensorId("sensor", sensor);
            }
        }
        #endregion

        #region 停止采集
        public void BtnStop_Click(object sender, EventArgs e)
        {
            int protocol = new SysManage().GetSysInfo()[0].protocol;
            /////////////////////////////RTU协议下的停止采集///////////////////////////////
            if (protocol == (int)Common.Protocol.RTU)
            {
                RTUDevice rTUDevice = new RTUDeviceManage().GetByName(this.tB_DeviceName.Text.Trim())[0];
                //当设备是停止状态时，点击不响应
                if (rTUDevice.status == (int)Common.DeviceStatus.STOP)
                {
                    return;
                }
                //1、将当前设备从串口的采集设备列表删除（根据设备地址）
                foreach (var key in ModbusUtil.RTUdevices.Keys)
                {
                    if (key.PortName.Equals(rTUDevice.serialPort))
                    {
                        var devices = ModbusUtil.RTUdevices[key][rTUDevice.deviceAddress];
                        foreach (var device in devices)
                        {
                            if (device.deviceName.Equals(rTUDevice.deviceName))
                            {
                                Logger.Info(string.Format("设备{0}停止采集", device.deviceName));
                                ModbusUtil.RTUdevices[key][rTUDevice.deviceAddress].Remove(device);
                                if (ModbusUtil.RTUdevices[key][rTUDevice.deviceAddress].Count == 0)
                                {
                                    ModbusUtil.RTUdevices[key].Remove(rTUDevice.deviceAddress);
                                }
                                break;
                            }
                        }
                        break;
                    }
                }
                foreach (var f in ModbusUtil.F_TitlePages[rTUDevice.deviceAddress])
                {
                    if (f.tB_DeviceName.Text.Equals(rTUDevice.deviceName))
                    {
                        f.deviceStatus = (int)Common.DeviceStatus.STOP;
                        ModbusUtil.F_TitlePages[rTUDevice.deviceAddress].Remove(f);
                        break;
                    }
                }
                if (ModbusUtil.F_TitlePages[rTUDevice.deviceAddress].Count == 0)
                {
                    ModbusUtil.F_TitlePages.Remove(rTUDevice.deviceAddress);
                }
                //2、将设备的状态改为停止（status=0）
                new RTUDeviceManage().UpdateStatusByName(rTUDevice.deviceName, (int)Common.DeviceStatus.STOP);
                //3、设置开始采集和停止采集按钮的图片
                this.BtnStart.Image = Properties.Resources.start2;//开始采集熄灭
                this.BtnStop.Image = Properties.Resources.stop1;//停止采集亮
                                                                //4、检查当前设备在使用的串口还有没有设备在采集
                                                                //若有，不做任何操作，若无，则停止采集线程
                foreach (var key in ModbusUtil.RTUdevices.Keys)
                {
                    if (key.PortName.Equals(rTUDevice.serialPort))
                    {
                        if (ModbusUtil.RTUdevices[key].Count == 0)
                        {
                            ModbusUtil.RTUSignals[key] = true;//停止采集线程
                        }
                    }
                }
            }
            else if (protocol == (int)Common.Protocol.TCP)
            {
                TCPDevice tCPDevice = new TCPDeviceManage().GetByName(this.tB_DeviceName.Text.Trim())[0];
                //当设备是停止状态时，点击不响应
                if (tCPDevice.status == (int)Common.DeviceStatus.STOP)
                {
                    return;
                }
                //1、将当前设备从tcpClient的采集设备列表删除（根据设备地址）
                foreach (var key in ModbusUtil.TCPdevices.Keys)
                {
                    if (key.Equals(tCPDevice.hostName))
                    {
                        var devices = ModbusUtil.TCPdevices[key][tCPDevice.deviceAddress];
                        foreach (var device in devices)
                        {
                            if (device.deviceName.Equals(tCPDevice.deviceName))
                            {
                                Logger.Info(string.Format("设备{0}停止采集", device.deviceName));
                                ModbusUtil.TCPdevices[key][tCPDevice.deviceAddress].Remove(device);
                                if (ModbusUtil.TCPdevices[key][tCPDevice.deviceAddress].Count == 0)
                                {
                                    ModbusUtil.TCPdevices[key].Remove(tCPDevice.deviceAddress);
                                }
                                break;
                            }
                        }

                        break;
                    }
                }
                foreach (var f in ModbusUtil.F_TitlePages[tCPDevice.deviceAddress])
                {
                    if (f.tB_DeviceName.Text.Equals(tCPDevice.deviceName))
                    {
                        f.deviceStatus = (int)Common.DeviceStatus.STOP;
                        ModbusUtil.F_TitlePages[tCPDevice.deviceAddress].Remove(f);
                        break;
                    }
                }
                if (ModbusUtil.F_TitlePages[tCPDevice.deviceAddress].Count == 0)
                {
                    ModbusUtil.F_TitlePages.Remove(tCPDevice.deviceAddress);
                }
                //2、将设备的状态改为停止（status=0）
                new TCPDeviceManage().UpdateStatusByName(tCPDevice.deviceName, (int)Common.DeviceStatus.STOP);
                //3、设置开始采集和停止采集按钮的图片
                this.BtnStart.Image = Properties.Resources.start2;//开始采集熄灭
                this.BtnStop.Image = Properties.Resources.stop1;//停止采集亮
                                                                //4、检查当前设备在使用的串口还有没有设备在采集
                                                                //若有，不做任何操作，若无，则停止采集线程
                foreach (var key in ModbusUtil.TCPdevices.Keys)
                {
                    if (key.Equals(tCPDevice.hostName))
                    {
                        if (ModbusUtil.TCPdevices[key].Count == 0)
                        {
                            ModbusUtil.TCPSignals[key] = true;//停止采集线程
                        }
                    }
                }
            }

        }
        #endregion

        #region 点击通道对应的框
        private void ucChannel_ControlClick(object sender, EventArgs e)
        {
            //通过点击事件可以获得ucChannel上子控件的信息
            UCChannel ucChannel = (UCChannel)sender;
            switch (ucChannel.Name.Trim())
            {
                case "ucChannel1":
                    this.selectedChannelID = 1;
                    break;
                case "ucChannel2":
                    this.selectedChannelID = 2;
                    break;
                case "ucChannel3":
                    this.selectedChannelID = 3;
                    break;
                case "ucChannel4":
                    this.selectedChannelID = 4;
                    break;
                case "ucChannel5":
                    this.selectedChannelID = 5;
                    break;
                case "ucChannel6":
                    this.selectedChannelID = 6;
                    break;
                case "ucChannel7":
                    this.selectedChannelID = 7;
                    break;
                case "ucChannel8":
                    this.selectedChannelID = 8;
                    break;
            }
        }
        #endregion
    }
}