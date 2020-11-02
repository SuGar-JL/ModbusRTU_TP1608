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

namespace ModbusRTU_TP1608
{
    public partial class F_TitlePage : UIPage
    {
        public F_TitlePage()
        {
            InitializeComponent();
            //只要自定义了textBox的背景色与前景色后，设置Enabled = false就不会吧背景色和前景色变为默认的了
            //tB_ChennalName1.Enabled = false;
            //tB_ChennalName1.BackColor = Color.White;
            w1 = this.Width;//窗口最开始的宽
            h1 = this.Height;//窗口最开始的高
            setTag(this);
            ucChartLine1.chart1.Series.Clear();
            ChartHelper.AddSeries(ucChartLine1.chart1, "曲线图", SeriesChartType.SplineRange, Color.FromArgb(100, 46, 199, 201), Color.Red, true);
            ChartHelper.SetTitle(ucChartLine1.chart1, "曲线图", new Font("微软雅黑", 10), Docking.Top, Color.Black);
            ucChartLine1.chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;//隐藏竖线。
            ucChartLine1.chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.FromArgb(100, 225, 225, 225);
            ucChartLine1.chart1.ChartAreas[0].AxisX.LabelStyle.Format = "MM-dd\nHH:mm:ss";//时间格式。
            ucChartLine1.chart1.ChartAreas[0].AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Milliseconds;
            //List<DateTime> x1 = new List<DateTime>() { DateTime.Now, DateTime.Now.AddMinutes(1), DateTime.Now.AddMinutes(2), DateTime.Now.AddMinutes(3) };
            //List<double> y1 = new List<double>() { 3, 1.12, 1.11, 1.2 };
            //ucChartLine1.chart1.ChartAreas[0].AxisX.Minimum = x1[0].ToOADate();
            //ucChartLine1.chart1.ChartAreas[0].AxisX.Maximum = x1[0].AddMinutes(5).ToOADate();

            ucChartLine1.chart1.Series[0].Points.DataBindXY(Xs[1], Ys[1]);
        }
        #region 属性
        /// <summary>
        /// 通道id，时间/数据值
        /// </summary>
        public Dictionary<int, List<DateTime>> Xs = new Dictionary<int, List<DateTime>>();
        public Dictionary<int, List<double>> Ys = new Dictionary<int, List<double>>();

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

        #region 用双缓冲绘制窗口的所有子控件
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
        public void SetChennalName(int index, string chennalName)
        {
            switch (index)
            {
                case 1:
                    this.ucChennal1.uiChennalName.Text = chennalName;
                    break;
                case 2:
                    this.ucChennal2.uiChennalName.Text = chennalName;
                    break;
                case 3:
                    this.ucChennal3.uiChennalName.Text = chennalName;
                    break;
                case 4:
                    this.ucChennal4.uiChennalName.Text = chennalName;
                    break;
                case 5:
                    this.ucChennal5.uiChennalName.Text = chennalName;
                    break;
                case 6:
                    this.ucChennal6.uiChennalName.Text = chennalName;
                    break;
                case 7:
                    this.ucChennal7.uiChennalName.Text = chennalName;
                    break;
                case 8:
                    this.ucChennal8.uiChennalName.Text = chennalName;
                    break;
            }
        }

        #endregion

        #region 配置设备
        private void onEdit_Click(object sender, EventArgs e)
        {
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
                    f_DeviceCofigRTU.deviceChennalNum.Enabled = false;
                    f_DeviceCofigRTU.deviceStartChennal.Enabled = false;
                    f_DeviceCofigRTU.deviceSerialPort.Enabled = false;
                    f_DeviceCofigRTU.deviceBaudRate.Enabled = false;
                }
                f_DeviceCofigRTU.device = device;
                f_DeviceCofigRTU.deviceType.Items.AddRange(Common.DeviceType.ToArray());
                f_DeviceCofigRTU.deviceType.SelectedIndex = Common.DeviceType.IndexOf(device.deviceType);
                f_DeviceCofigRTU.deviceName.Text = device.deviceName;
                f_DeviceCofigRTU.deviceAddress.Text = device.deviceAddress;
                f_DeviceCofigRTU.deviceChennalNum.Items.AddRange(Common.DeviceChennalNum.ToArray());
                f_DeviceCofigRTU.deviceChennalNum.SelectedIndex = device.chennalNum - 1;
                f_DeviceCofigRTU.deviceStartChennal.Items.AddRange(Common.DeviceStartChennal.ToArray());
                f_DeviceCofigRTU.deviceStartChennal.SelectedIndex = device.startChennal - 1;
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
                if (f_DeviceCofigRTU.IsOK)
                {
                    bool f = false;
                    device.deviceType = f_DeviceCofigRTU.deviceType.Text.Trim();
                    device.deviceName = f_DeviceCofigRTU.deviceName.Text.Trim();
                    device.deviceAddress = f_DeviceCofigRTU.deviceAddress.Text.Trim();
                    if (device.chennalNum != f_DeviceCofigRTU.deviceChennalNum.SelectedIndex + 1 || device.startChennal != f_DeviceCofigRTU.deviceStartChennal.SelectedIndex + 1)
                    {
                        f = !f;
                    }
                    device.chennalNum = f_DeviceCofigRTU.deviceChennalNum.SelectedIndex + 1;//SelectedIndex是从0开始的
                    device.startChennal = f_DeviceCofigRTU.deviceStartChennal.SelectedIndex + 1;
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
                        var chennals = new RTUChennalManage().GetByDeviceId(device.id);
                        if (chennals[0].chennalID >= device.startChennal && chennals[chennals.Count - 1].chennalID >= (device.startChennal + device.chennalNum - 1))
                        {
                            //补前(第一个=满足时，补前不进行)
                            for (int i = device.startChennal; i < chennals[0].chennalID; i++)
                            {
                                RTUChennal chennal = new RTUChennal();
                                chennal.deviceID = device.id;//设备id
                                chennal.chennalName = device.deviceName + "-CH0" + i;//通道名称
                                chennal.chennalID = i;//通道id
                                chennal.createBy = "管理员";
                                chennal.createTime = DateTime.Now;
                                new RTUChennalManage().Insert(chennal);
                            }
                            //删后(第二个=满足时，删后不进行)
                            if (chennals[chennals.Count - 1].chennalID > (device.startChennal + device.chennalNum - 1))
                            {
                                List<string> chennalIds = new List<string>();
                                foreach (var chennal in chennals)
                                {
                                    chennalIds.Add(chennal.id);
                                }
                                chennalIds.RemoveRange(0, device.startChennal + device.chennalNum - 1 - (int)chennals[0].chennalID);
                                chennalIds.RemoveAt(0);
                                //根据id批量删除
                                new RTUChennalManage().DeleteByIds(chennalIds.ToArray());
                            }
                        }
                        else if (chennals[0].chennalID <= device.startChennal && chennals[chennals.Count - 1].chennalID <= (device.startChennal + device.chennalNum - 1))
                        {
                            //补后(第二个=满足时，补后不进行)
                            for (int i = (int)chennals[chennals.Count - 1].chennalID + 1; i <= device.startChennal + device.chennalNum - 1; i++)
                            {
                                RTUChennal chennal = new RTUChennal();
                                chennal.deviceID = device.id;//设备id
                                chennal.chennalName = device.deviceName + "-CH0" + i;//通道名称
                                chennal.chennalID = i;//通道id
                                chennal.createBy = "管理员";
                                chennal.createTime = DateTime.Now;
                                new RTUChennalManage().Insert(chennal);
                            }
                            //删前(第一个=满足时，删前不进行)
                            if (chennals[0].chennalID < device.startChennal)
                            {
                                List<string> chennalIds = new List<string>();
                                foreach (var chennal in chennals)
                                {
                                    chennalIds.Add(chennal.id);
                                }
                                chennalIds.RemoveRange(device.startChennal - 1, (int)chennals[chennals.Count - 1].chennalID - device.startChennal + 1);
                                //根据id批量删除
                                new RTUChennalManage().DeleteByIds(chennalIds.ToArray());
                            }
                        }
                        else if (chennals[0].chennalID < device.startChennal && chennals[chennals.Count - 1].chennalID > (device.startChennal + device.chennalNum - 1))
                        {
                            //删前后
                            List<string> chennalIds = new List<string>();
                            foreach (var chennal in chennals)
                            {
                                chennalIds.Add(chennal.id);
                            }
                            chennalIds.RemoveRange(device.startChennal - 1, device.chennalNum);
                            //根据id批量删除
                            new RTUChennalManage().DeleteByIds(chennalIds.ToArray());

                        }
                        else if (chennals[0].chennalID >= device.startChennal && chennals[chennals.Count - 1].chennalID <= (device.startChennal + device.chennalNum - 1))
                        {

                            //补前(第一个=满足时，补前不进行)
                            for (int i = device.startChennal; i < chennals[0].chennalID; i++)
                            {
                                RTUChennal chennal = new RTUChennal();
                                chennal.deviceID = device.id;//设备id
                                chennal.chennalName = device.deviceName + "-CH0" + i;//通道名称
                                chennal.chennalID = i;//通道id
                                chennal.createBy = "管理员";
                                chennal.createTime = DateTime.Now;
                                new RTUChennalManage().Insert(chennal);
                            }
                            //补后（第二个=满足时，补后不进行）
                            for (int i = (int)chennals[chennals.Count - 1].chennalID + 1; i <= device.startChennal + device.chennalNum - 1; i++)
                            {
                                RTUChennal chennal = new RTUChennal();
                                chennal.deviceID = device.id;//设备id
                                chennal.chennalName = device.deviceName + "-CH0" + i;//通道名称
                                chennal.chennalID = i;//通道id
                                chennal.createBy = "管理员";
                                chennal.createTime = DateTime.Now;
                                new RTUChennalManage().Insert(chennal);
                            }
                        }
                    }
                    Form1.Instance.SetAsideNode(device.deviceName, device.id, (int)device.pageIndex, f);
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
                    f_DeviceCofigTCP.deviceChennalNum.Enabled = false;
                    f_DeviceCofigTCP.deviceStartChennal.Enabled = false;
                    f_DeviceCofigTCP.deviceHostName.Enabled = false;
                    f_DeviceCofigTCP.devicePort.Enabled = false;
                }
                f_DeviceCofigTCP.device = device;
                f_DeviceCofigTCP.deviceType.Items.AddRange(Common.DeviceType.ToArray());
                f_DeviceCofigTCP.deviceType.SelectedIndex = Common.DeviceType.IndexOf(device.deviceType);
                f_DeviceCofigTCP.deviceName.Text = device.deviceName;
                f_DeviceCofigTCP.deviceAddress.Text = device.deviceAddress;
                f_DeviceCofigTCP.deviceChennalNum.Items.AddRange(Common.DeviceChennalNum.ToArray());
                f_DeviceCofigTCP.deviceChennalNum.SelectedIndex = device.chennalNum - 1;
                f_DeviceCofigTCP.deviceStartChennal.Items.AddRange(Common.DeviceStartChennal.ToArray());
                f_DeviceCofigTCP.deviceStartChennal.SelectedIndex = device.startChennal - 1;
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
                    if (device.chennalNum != f_DeviceCofigTCP.deviceChennalNum.SelectedIndex + 1 || device.startChennal != f_DeviceCofigTCP.deviceStartChennal.SelectedIndex + 1)
                    {
                        f = !f;
                    }
                    device.chennalNum = f_DeviceCofigTCP.deviceChennalNum.SelectedIndex + 1;//SelectedIndex是从0开始的
                    device.startChennal = f_DeviceCofigTCP.deviceStartChennal.SelectedIndex + 1;
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
                        var chennals = new TCPChennalManage().GetByDeviceId(device.id);
                        if (chennals[0].chennalID >= device.startChennal && chennals[chennals.Count - 1].chennalID >= (device.startChennal + device.chennalNum - 1))
                        {
                            //补前(第一个=满足时，补前不进行)
                            for (int i = device.startChennal; i < chennals[0].chennalID; i++)
                            {
                                TCPChennal chennal = new TCPChennal();
                                chennal.deviceID = device.id;//设备id
                                chennal.chennalName = device.deviceName + "-CH0" + i;//通道名称
                                chennal.chennalID = i;//通道id
                                chennal.createBy = "管理员";
                                chennal.createTime = DateTime.Now;
                                new TCPChennalManage().Insert(chennal);
                            }
                            //删后(第二个=满足时，删后不进行)
                            if (chennals[chennals.Count - 1].chennalID > (device.startChennal + device.chennalNum - 1))
                            {
                                List<string> chennalIds = new List<string>();
                                foreach (var chennal in chennals)
                                {
                                    chennalIds.Add(chennal.id);
                                }
                                chennalIds.RemoveRange(0, device.startChennal + device.chennalNum - 1 - (int)chennals[0].chennalID);
                                chennalIds.RemoveAt(0);
                                //根据id批量删除
                                new TCPChennalManage().DeleteByIds(chennalIds.ToArray());
                            }
                        }
                        else if (chennals[0].chennalID <= device.startChennal && chennals[chennals.Count - 1].chennalID <= (device.startChennal + device.chennalNum - 1))
                        {
                            //补后(第二个=满足时，补后不进行)
                            for (int i = (int)chennals[chennals.Count - 1].chennalID + 1; i <= device.startChennal + device.chennalNum - 1; i++)
                            {
                                TCPChennal chennal = new TCPChennal();
                                chennal.deviceID = device.id;//设备id
                                chennal.chennalName = device.deviceName + "-CH0" + i;//通道名称
                                chennal.chennalID = i;//通道id
                                chennal.createBy = "管理员";
                                chennal.createTime = DateTime.Now;
                                new TCPChennalManage().Insert(chennal);
                            }
                            //删前(第一个=满足时，删前不进行)
                            if (chennals[0].chennalID < device.startChennal)
                            {
                                List<string> chennalIds = new List<string>();
                                foreach (var chennal in chennals)
                                {
                                    chennalIds.Add(chennal.id);
                                }
                                chennalIds.RemoveRange(device.startChennal - 1, (int)chennals[chennals.Count - 1].chennalID - device.startChennal + 1);
                                //根据id批量删除
                                new TCPChennalManage().DeleteByIds(chennalIds.ToArray());
                            }
                        }
                        else if (chennals[0].chennalID < device.startChennal && chennals[chennals.Count - 1].chennalID > (device.startChennal + device.chennalNum - 1))
                        {
                            //删前后
                            List<string> chennalIds = new List<string>();
                            foreach (var chennal in chennals)
                            {
                                chennalIds.Add(chennal.id);
                            }
                            chennalIds.RemoveRange(device.startChennal - 1, device.chennalNum);
                            //根据id批量删除
                            new TCPChennalManage().DeleteByIds(chennalIds.ToArray());

                        }
                        else if (chennals[0].chennalID >= device.startChennal && chennals[chennals.Count - 1].chennalID <= (device.startChennal + device.chennalNum - 1))
                        {

                            //补前(第一个=满足时，补前不进行)
                            for (int i = device.startChennal; i < chennals[0].chennalID; i++)
                            {
                                TCPChennal chennal = new TCPChennal();
                                chennal.deviceID = device.id;//设备id
                                chennal.chennalName = device.deviceName + "-CH0" + i;//通道名称
                                chennal.chennalID = i;//通道id
                                chennal.createBy = "管理员";
                                chennal.createTime = DateTime.Now;
                                new TCPChennalManage().Insert(chennal);
                            }
                            //补后（第二个=满足时，补后不进行）
                            for (int i = (int)chennals[chennals.Count - 1].chennalID + 1; i <= device.startChennal + device.chennalNum - 1; i++)
                            {
                                TCPChennal chennal = new TCPChennal();
                                chennal.deviceID = device.id;//设备id
                                chennal.chennalName = device.deviceName + "-CH0" + i;//通道名称
                                chennal.chennalID = i;//通道id
                                chennal.createBy = "管理员";
                                chennal.createTime = DateTime.Now;
                                new TCPChennalManage().Insert(chennal);
                            }
                        }

                    }
                    Form1.Instance.SetAsideNode(device.deviceName, device.id, (int)device.pageIndex, f);
                    this.ShowSuccessTip("修改已保存");
                }
            }
        }
        #endregion

        #region 删除设备
        private void onDelete_Click(object sender, EventArgs e)
        {
            Sys sys = new SysManage().GetSysInfo()[0];
            if (sys.protocol == (int)Common.Protocol.RTU)
            {
                //1.设备正在采集时是不能删除的
                var device = new RTUDeviceManage().GetByName(this.tB_DeviceName.Text.Trim())[0];
                if (device.status == (int)Common.DeviceStatus.START)
                {
                    this.ShowWarningDialog("设备正在采集数据，不能删除！");
                    return;
                }
                //其它状态时可删除，得询问
                bool OK = this.ShowAskDialog("确定要删除该设备吗？\r\n警告：将会删除已采集的数据！");
                if (OK)
                {
                    //点击确认按钮
                    new RTUChennalManage().DeleteByDeviceId(device.id);//是批量吗？
                    new RTUDeviceManage().DeleteById(device.id);
                    Form1.Instance.DeleteAsideNode((int)device.pageIndex);
                    this.ShowSuccessTip("删除设备成功");
                }
                else
                {
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
                    this.ShowWarningDialog("设备正在采集数据，不能删除！");
                    return;
                }
                //其它状态时可删除，得询问
                bool OK = this.ShowAskDialog("确定要删除该设备吗？\r\n警告：将会删除已采集的数据！");
                if (OK)
                {
                    //点击确认按钮
                    new TCPChennalManage().DeleteByDeviceId(device.id);//是批量吗？
                    new TCPDeviceManage().DeleteById(device.id);
                    Form1.Instance.DeleteAsideNode((int)device.pageIndex);
                    this.ShowSuccessTip("删除设备成功");
                }
                else
                {
                    //点击取消按钮
                    this.ShowSuccessTip("取消删除");
                }
            }
        }

        #endregion

        #region 配置通道
        //点击ucChennal(通道)的圈i
        //做到了代码的封闭性（多个控件使用一个点击事件）
        private void ucChennal_ShowInfo_Click(object sender, EventArgs e)
        {
            //通过点击事件可以获得ucChennal上子控件的信息
            UCChennal ucChennal = (UCChennal)sender;
            Sys sys = new SysManage().GetSysInfo()[0];
            if (sys.protocol == (int)Common.Protocol.RTU)
            {
                var device = new RTUDeviceManage().GetByName(this.tB_DeviceName.Text.Trim())[0];
                var chennal = new RTUChennalManage().GetByDeviceIdAndName(device.id, ucChennal.uiChennalName.Text.Trim());
                string chennalOldName = chennal.chennalName;
                var sensorIds = new RTUChennalManage().GetSensorIds();
                var f_ChennalInfo = new F_ChennalInfo();
                if (device.status == (int)Common.DeviceStatus.START)
                {
                    f_ChennalInfo.chennalSensorType.Enabled = false;
                    f_ChennalInfo.chennalSensorId.Enabled = false;
                    f_ChennalInfo.chennalType.Enabled = false;
                }
                f_ChennalInfo.rTUChennal = chennal;
                f_ChennalInfo.chennalName.Text = chennal.chennalName;
                f_ChennalInfo.chennalID.Text = chennal.chennalID.ToString();
                f_ChennalInfo.chennalLabel.Text = chennal.chennalLabel;
                f_ChennalInfo.chennalUnit.Text = chennal.chennalUnit;
                f_ChennalInfo.chennalSensorType.SelectedIndex = chennal.sensorType == null ? -1 : (int)chennal.sensorType - 1;
                f_ChennalInfo.chennalSensorName.Text = chennal.sensorName;
                //将数据库现以配置有的传感器id填充到传感器id的下拉框
                if (sensorIds != null)
                {
                    f_ChennalInfo.chennalSensorId.Items.AddRange(sensorIds.ToArray());
                }
                f_ChennalInfo.chennalSensorId.Text = chennal.sensorID;
                if (chennal.isWaring == 1)
                {
                    f_ChennalInfo.isWraning.Checked = true;
                }
                else
                {
                    f_ChennalInfo.isWraning.Checked = false;
                }
                f_ChennalInfo.chennalDecimalPlaces.Text = chennal.decimalPlaces == null ? "4" : chennal.decimalPlaces.ToString();//小数位默认选择4
                f_ChennalInfo.chennalSensorRangeL.Text = chennal.sensorRangeL == null ? "0.00" : chennal.sensorRangeL.ToString();
                f_ChennalInfo.chennalSensorRangeH.Text = chennal.sensorRangeH == null ? "0.00" : chennal.sensorRangeH.ToString();
                f_ChennalInfo.chennalWarning1L.Text = chennal.warning1L == null ? "0.00" : chennal.warning1L.ToString();
                f_ChennalInfo.chennalWarning1H.Text = chennal.warning1H == null ? "0.00" : chennal.warning1H.ToString();
                f_ChennalInfo.chennalWarning2L.Text = chennal.warning2L == null ? "0.00" : chennal.warning2L.ToString();
                f_ChennalInfo.chennalWarning2H.Text = chennal.warning2H == null ? "0.00" : chennal.warning2H.ToString();
                f_ChennalInfo.chennalWarning3L.Text = chennal.warning3L == null ? "0.00" : chennal.warning3L.ToString();
                f_ChennalInfo.chennalWarning3H.Text = chennal.warning3H == null ? "0.00" : chennal.warning3H.ToString();
                f_ChennalInfo.chennalType.Text = chennal.chennalType;
                f_ChennalInfo.ShowDialog();
                if (f_ChennalInfo.IsOK)
                {
                    chennal.chennalName = f_ChennalInfo.chennalName.Text.Trim();
                    ucChennal.uiChennalName.Text = f_ChennalInfo.chennalName.Text.Trim();
                    chennal.chennalLabel = f_ChennalInfo.chennalLabel.Text.Trim();
                    chennal.chennalUnit = f_ChennalInfo.chennalUnit.Text.Trim();
                    chennal.sensorType = f_ChennalInfo.chennalSensorType.SelectedIndex + 1;//传感器类型不取0
                    chennal.sensorName = f_ChennalInfo.chennalSensorName.Text.Trim();
                    chennal.sensorRangeL = double.Parse(f_ChennalInfo.chennalSensorRangeL.Text.Trim());
                    chennal.sensorRangeH = double.Parse(f_ChennalInfo.chennalSensorRangeH.Text.Trim());
                    if (f_ChennalInfo.isWraning.Checked)
                    {
                        chennal.isWaring = 1;
                    }
                    else
                    {
                        chennal.isWaring = 0;
                    }
                    chennal.decimalPlaces = int.Parse(f_ChennalInfo.chennalDecimalPlaces.Text.Trim());
                    chennal.warning1L = double.Parse(f_ChennalInfo.chennalWarning1L.Text.Trim());
                    chennal.warning1H = double.Parse(f_ChennalInfo.chennalWarning1H.Text.Trim());
                    chennal.warning2L = double.Parse(f_ChennalInfo.chennalWarning2L.Text.Trim());
                    chennal.warning2H = double.Parse(f_ChennalInfo.chennalWarning2H.Text.Trim());
                    chennal.warning3L = double.Parse(f_ChennalInfo.chennalWarning3L.Text.Trim());
                    chennal.warning3H = double.Parse(f_ChennalInfo.chennalWarning3H.Text.Trim());
                    chennal.chennalType = f_ChennalInfo.chennalType.Text.Trim();
                    chennal.updateBy = "管理员";
                    chennal.updateTime = DateTime.Now;
                    //给通道配置传感器id与传感器表
                    chennal.sensorID = f_ChennalInfo.chennalSensorId.Text.Trim();
                    chennal.sensorTableName = Common.SensorTable[f_ChennalInfo.chennalSensorType.SelectedIndex + 1];
                    Form1.Instance.UpdateChildNodeName(chennalOldName, chennal.chennalName);
                    new RTUChennalManage().UpdateByEntity(chennal);

                }
            }
            else if (sys.protocol == (int)Common.Protocol.TCP)
            {
                var device = new TCPDeviceManage().GetByName(this.tB_DeviceName.Text.Trim())[0];
                var chennal = new TCPChennalManage().GetByDeviceIdAndName(device.id, ucChennal.uiChennalName.Text.Trim());
                string chennalOldName = chennal.chennalName;
                var sensorIds = new TCPChennalManage().GetSensorIds();
                var f_ChennalInfo = new F_ChennalInfo();
                if (device.status == (int)Common.DeviceStatus.START)
                {
                    f_ChennalInfo.chennalSensorType.Enabled = false;
                    f_ChennalInfo.chennalSensorId.Enabled = false;
                    f_ChennalInfo.chennalType.Enabled = false;
                }
                f_ChennalInfo.tCPChennal = chennal;
                f_ChennalInfo.chennalName.Text = chennal.chennalName;
                f_ChennalInfo.chennalID.Text = chennal.chennalID.ToString();
                f_ChennalInfo.chennalLabel.Text = chennal.chennalLabel;
                f_ChennalInfo.chennalUnit.Text = chennal.chennalUnit;
                f_ChennalInfo.chennalSensorType.SelectedIndex = chennal.sensorType == null ? -1 : (int)chennal.sensorType - 1;
                f_ChennalInfo.chennalSensorName.Text = chennal.sensorName;
                //将数据库现以配置有的传感器id填充到传感器id的下拉框
                if (sensorIds != null)
                {
                    f_ChennalInfo.chennalSensorId.Items.AddRange(sensorIds.ToArray());
                }
                f_ChennalInfo.chennalSensorId.Text = chennal.sensorID;
                if (chennal.isWaring == 1)
                {
                    f_ChennalInfo.isWraning.Checked = true;
                }
                else
                {
                    f_ChennalInfo.isWraning.Checked = false;
                }
                f_ChennalInfo.chennalDecimalPlaces.Text = chennal.decimalPlaces == null ? "4" : chennal.decimalPlaces.ToString();//小数位默认选择4
                f_ChennalInfo.chennalSensorRangeL.Text = chennal.sensorRangeL == null ? "0.00" : chennal.sensorRangeL.ToString();
                f_ChennalInfo.chennalSensorRangeH.Text = chennal.sensorRangeH == null ? "0.00" : chennal.sensorRangeH.ToString();
                f_ChennalInfo.chennalWarning1L.Text = chennal.warning1L == null ? "0.00" : chennal.warning1L.ToString();
                f_ChennalInfo.chennalWarning1H.Text = chennal.warning1H == null ? "0.00" : chennal.warning1H.ToString();
                f_ChennalInfo.chennalWarning2L.Text = chennal.warning2L == null ? "0.00" : chennal.warning2L.ToString();
                f_ChennalInfo.chennalWarning2H.Text = chennal.warning2H == null ? "0.00" : chennal.warning2H.ToString();
                f_ChennalInfo.chennalWarning3L.Text = chennal.warning3L == null ? "0.00" : chennal.warning3L.ToString();
                f_ChennalInfo.chennalWarning3H.Text = chennal.warning3H == null ? "0.00" : chennal.warning3H.ToString();
                f_ChennalInfo.chennalType.Text = chennal.chennalType;
                f_ChennalInfo.ShowDialog();
                if (f_ChennalInfo.IsOK)
                {
                    chennal.chennalName = f_ChennalInfo.chennalName.Text.Trim();
                    ucChennal.uiChennalName.Text = f_ChennalInfo.chennalName.Text.Trim();
                    chennal.chennalLabel = f_ChennalInfo.chennalLabel.Text.Trim();
                    chennal.chennalUnit = f_ChennalInfo.chennalUnit.Text.Trim();
                    chennal.sensorType = f_ChennalInfo.chennalSensorType.SelectedIndex + 1;//传感器类型不取0
                    chennal.sensorName = f_ChennalInfo.chennalSensorName.Text.Trim();
                    chennal.sensorRangeL = double.Parse(f_ChennalInfo.chennalSensorRangeL.Text.Trim());
                    chennal.sensorRangeH = double.Parse(f_ChennalInfo.chennalSensorRangeH.Text.Trim());
                    if (f_ChennalInfo.isWraning.Checked)
                    {
                        chennal.isWaring = 1;
                    }
                    else
                    {
                        chennal.isWaring = 0;
                    }
                    chennal.decimalPlaces = int.Parse(f_ChennalInfo.chennalDecimalPlaces.Text.Trim());
                    chennal.warning1L = double.Parse(f_ChennalInfo.chennalWarning1L.Text.Trim());
                    chennal.warning1H = double.Parse(f_ChennalInfo.chennalWarning1H.Text.Trim());
                    chennal.warning2L = double.Parse(f_ChennalInfo.chennalWarning2L.Text.Trim());
                    chennal.warning2H = double.Parse(f_ChennalInfo.chennalWarning2H.Text.Trim());
                    chennal.warning3L = double.Parse(f_ChennalInfo.chennalWarning3L.Text.Trim());
                    chennal.warning3H = double.Parse(f_ChennalInfo.chennalWarning3H.Text.Trim());
                    chennal.chennalType = f_ChennalInfo.chennalType.Text.Trim();
                    chennal.updateBy = "管理员";
                    chennal.updateTime = DateTime.Now;
                    //给通道配置传感器id与传感器表
                    chennal.sensorID = f_ChennalInfo.chennalSensorId.Text.Trim();
                    chennal.sensorTableName = Common.SensorTable[f_ChennalInfo.chennalSensorType.SelectedIndex + 1];
                    Form1.Instance.UpdateChildNodeName(chennalOldName, chennal.chennalName);
                    new TCPChennalManage().UpdateByEntity(chennal);

                }
            }

        }
        #endregion

        #region 开始采集
        private void BtnStart_Click(object sender, EventArgs e)
        {
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
                    this.ShowWarningDialog("设备不存在");
                    return;
                }
                //检查设备串口是否插在电脑上
                //获取可用串口
                List<string> serialPorts = System.IO.Ports.SerialPort.GetPortNames().ToList();
                if (rTUDevice.serialPort == null || rTUDevice.serialPort.Length == 0)
                {
                    this.ShowWarningDialog("请为设备配置串口");
                    return;
                }
                if (!serialPorts.Contains(rTUDevice.serialPort))
                {
                    this.ShowWarningDialog(string.Format("串口{0}不存在", rTUDevice.serialPort));
                    return;
                }
                //以上判断通过方可进行采集
                //TP1608要求数据位为8，无奇偶校验，停止位为1
                SerialPort serialPort = new SerialPort(rTUDevice.serialPort, int.Parse(rTUDevice.baudRate), Parity.None, 8, StopBits.One);
                //将串口实例与设备实例存下来
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
                //设置设备为采集状态（status字段变为1）
                new RTUDeviceManage().UpdateStatusByName(rTUDevice.deviceName, (int)Common.DeviceStatus.START);

                //设置开始采集和停止采集按钮的图片
                this.BtnStart.Image = Properties.Resources.start1;//开始采集熄灭
                this.BtnStop.Image = Properties.Resources.stop2;//停止采集亮
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
                    this.ShowWarningDialog("设备不存在");
                    return;
                }
                if (tCPDevice.hostName == null || tCPDevice.hostName.Length == 0)
                {
                    this.ShowWarningDialog("请为设备配置从机IP");
                    return;
                }
                if (tCPDevice.port == null || tCPDevice.port.Length == 0 || !tCPDevice.port.Equals("502"))
                {
                    this.ShowWarningDialog("请为设备配置从机端口号为502");
                    return;
                }
                
                //创建TCP客户端
                try
                {
                    TcpClient tcpClient = new TcpClient(tCPDevice.hostName, int.Parse(tCPDevice.port));
                    //将TCP客户端实例tcpClient与设备实例tCPDevice存下来
                    bool f = false;
                    foreach (var key in ModbusUtil.TCPdevices.Keys)
                    {
                        if (key.Client.RemoteEndPoint.ToString().Split(':')[0].Equals(tcpClient.Client.RemoteEndPoint.ToString().Split(':')[0]))
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
                        ModbusUtil.TCPdevices.Add(tcpClient, devices);
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
                        ModbusUtil.TCPSignals.Add(tcpClient, signal_STOP);
                        //新建一个采集线程
                        Thread thread = new Thread(new ParameterizedThreadStart(this.TCPDataCollect));//调用方法，需要提供参数：串口（用于实例化master）
                        thread.Name = tcpClient.Client.RemoteEndPoint.ToString() + "的采集线程";
                        thread.IsBackground = true;//后台线程，关闭程序时，线程也会停止
                        thread.Start(tcpClient);
                        //存下线程，在串口串口的采集设备列表为空时，要停止线程（通过跳出所调用的采集方法中的while循环）
                        ModbusUtil.TCPThreads.Add(tcpClient, thread);
                    }
                    //设置设备为采集状态（status字段变为1）
                    new TCPDeviceManage().UpdateStatusByName(tCPDevice.deviceName, (int)Common.DeviceStatus.START);

                    //设置开始采集和停止采集按钮的图片
                    this.BtnStart.Image = Properties.Resources.start1;//开始采集熄灭
                    this.BtnStop.Image = Properties.Resources.stop2;//停止采集亮
                }
                catch (Exception exception)
                {
                    this.ShowErrorDialog(exception.Message);
                }
            }

        }

        #region RTU协议下的采集方法
        public void RTUDataCollect(object serialPort)
        {
            //新建一个master
            Modbus.Device.IModbusMaster RTUMaster = ModbusSerialMaster.CreateRtu((SerialPort)serialPort);
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
                        List<RTUChennal> rTUChennals = new RTUChennalManage().GetByDeviceId(rTUDevices[i].id);
                        foreach (RTUChennal rTUChennal in rTUChennals)
                        {
                            if (rTUChennal.sensorID != null && rTUChennal.sensorID.Length != 0)
                            {
                                Sensor sensor = new Sensor();
                                sensor.sensorId = rTUChennal.sensorID;
                                sensor.sensorName = rTUChennal.sensorName;
                                sensor.sensorType = rTUChennal.sensorType.ToString();/////这是int,要改
                                sensor.sensorLabel = rTUChennal.chennalLabel;
                                double value = (result[(int)rTUChennal.chennalID - 1] - 4.0F) / (20.0F - 4.0F) * ((double)rTUChennal.sensorRangeH - (double)rTUChennal.sensorRangeL);
                                value = double.Parse((value + (double)rTUChennal.sensorRangeL).ToString("F" + rTUChennal.decimalPlaces));
                                sensor.sensorValue = value.ToString();
                                sensor.sensorUnit = rTUChennal.chennalUnit;
                                sensor.createBy = "传感器" + sensor.sensorId;
                                sensor.createTime = DateTime.Now;
                                sensor.updateBy = "传感器" + sensor.sensorId;
                                sensor.updateTime = DateTime.Now;
                                sensor.tableName = rTUChennal.sensorTableName;
                                //sensor.tableName = "sensor";
                                //this.Xs[(int)rTUChennal.chennalID].Add(((DateTime)sensor.createTime).ToLongTimeString());
                                //this.Xs[(int)rTUChennal.chennalID].RemoveAt(0);
                                //this.Ys[(int)rTUChennal.chennalID].Add(value);
                                //this.Ys[(int)rTUChennal.chennalID].RemoveAt(0);
                                //接下来做显示
                                //找出当前（看到的）设备对应的F_TitlePage
                                try
                                {
                                    List<F_TitlePage> f_TitlePages = ModbusUtil.F_TitlePages[rTUDevices[i].deviceAddress];
                                    foreach (var f in f_TitlePages)
                                    {
                                        if (f.tB_DeviceName.Text.Equals(rTUDevices[i].deviceName))
                                        {
                                            this.SetUcChennalValue(rTUChennal.chennalID, sensor.sensorValue, sensor.sensorUnit, sensor.createTime.ToString(), f);
                                            break;
                                        }
                                    }
                                }
                                catch (Exception)
                                {
                                    continue;
                                }
                                //数据入库
                                ThreadPool.QueueUserWorkItem(new WaitCallback(WriteSensorData2DB), sensor);
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
            //新建一个master
            NModbus.IModbusMaster TCPMaster = new ModbusFactory().CreateMaster((TcpClient)obj);
            //设置读取超时时间
            TCPMaster.Transport.ReadTimeout = 5000;
            TCPMaster.Transport.Retries = 8000;
            ThreadPool.SetMaxThreads(8, 8);//使用线程池来写数据库，异步来提高速度
            while (!ModbusUtil.TCPSignals[(TcpClient)obj])
            {
                List<List<TCPDevice>> devices = ModbusUtil.TCPdevices[(TcpClient)obj].Values.ToList();
                List<TCPDevice> tCPDevices = new List<TCPDevice>();
                for (int i = 0; i < devices.Count; i++)
                {
                    tCPDevices.AddRange(devices[i]);
                }
                for (int i = 0; i < tCPDevices.Count; i++)
                {
                    try
                    {
                        TCPMaster = new ModbusFactory().CreateMaster((TcpClient)obj);
                        //设置读取超时时间
                        TCPMaster.Transport.ReadTimeout = 5000;
                        TCPMaster.Transport.Retries = 8000;
                        //读取设备的寄存器数据（8个通道，一个通道2个寄存器），参数：设备地址，起始地址，寄存器数
                        ushort[] registerBuffer = TCPMaster.ReadHoldingRegisters(byte.Parse(tCPDevices[i].deviceAddress), 0, 16);
                        //ushort[]=>float[]
                        float[] result = DataTypeConvert.GetReal(registerBuffer, 0);//得到8个32位浮点数
                        List<TCPChennal> tCPChennals = new TCPChennalManage().GetByDeviceId(tCPDevices[i].id);
                        foreach (TCPChennal tCPChennal in tCPChennals)
                        {
                            if (tCPChennal.sensorID != null && tCPChennal.sensorID.Length != 0)
                            {
                                Sensor sensor = new Sensor();
                                sensor.sensorId = tCPChennal.sensorID;
                                sensor.sensorName = tCPChennal.sensorName;
                                sensor.sensorType = tCPChennal.sensorType.ToString();/////这是int,要改
                                sensor.sensorLabel = tCPChennal.chennalLabel;
                                double value = (result[(int)tCPChennal.chennalID - 1] - 4.0F) / (20.0F - 4.0F) * ((double)tCPChennal.sensorRangeH - (double)tCPChennal.sensorRangeL);
                                value = double.Parse((value + (double)tCPChennal.sensorRangeL).ToString("F" + tCPChennal.decimalPlaces));
                                sensor.sensorValue = value.ToString();
                                sensor.sensorUnit = tCPChennal.chennalUnit;
                                sensor.createBy = "传感器" + sensor.sensorId;
                                sensor.createTime = DateTime.Now;
                                sensor.updateBy = "传感器" + sensor.sensorId;
                                sensor.updateTime = DateTime.Now;
                                sensor.tableName = tCPChennal.sensorTableName;
                                //sensor.tableName = "sensor";
                                if (this.Xs[(int)tCPChennal.chennalID].Count < 60)
                                {
                                    this.Xs[(int)tCPChennal.chennalID].Add((DateTime)sensor.createTime);
                                    this.Ys[(int)tCPChennal.chennalID].Add(value);
                                }
                                else
                                {
                                    this.Xs[(int)tCPChennal.chennalID].Add((DateTime)sensor.createTime);
                                    this.Ys[(int)tCPChennal.chennalID].Add(value);
                                    this.Xs[(int)tCPChennal.chennalID].RemoveAt(0);
                                    this.Ys[(int)tCPChennal.chennalID].RemoveAt(0);
                                }
                                //接下来做显示
                                //找出当前（看到的）设备对应的F_TitlePage
                                try
                                {
                                    List<F_TitlePage> f_TitlePages = ModbusUtil.F_TitlePages[tCPDevices[i].deviceAddress];
                                    foreach (var f in f_TitlePages)
                                    {
                                        if (f.tB_DeviceName.Text.Equals(tCPDevices[i].deviceName))
                                        {
                                            this.SetUcChennalValue(tCPChennal.chennalID, sensor.sensorValue, sensor.sensorUnit, sensor.createTime.ToString(), f);
                                            break;
                                        }
                                    }
                                }
                                catch (Exception)
                                {
                                    continue;
                                }
                                //数据入库
                                ThreadPool.QueueUserWorkItem(new WaitCallback(WriteSensorData2DB), sensor);
                            }
                        }
                    }
                    catch (TimeoutException)
                    {
                        continue;
                    }
                    catch (IOException)
                    {
                        continue;
                    }
                    catch (Exception e)
                    {
                        this.ShowErrorDialog("采集中发生错误:\r\n" + e.GetType().Name + "\r\n" + e.Message);
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
            ModbusUtil.TCPSignals.Remove((TcpClient)obj);
            //2、从采集的串口列表移除串口
            ModbusUtil.TCPdevices.Remove(((TcpClient)obj));
        }
        #endregion

        #region 通道控件显示数据
        private void SetUcChennalValue(int? chennalID, string sensorValue, string sensorUnit, string createTime, F_TitlePage f_TitlePage)
        {
            switch (chennalID)
            {
                case 1:
                    if (f_TitlePage.ucChennal1.InvokeRequired)
                    {
                        Action<string, string, string> actionDelegate = (value, unit, time) =>
                        {
                            f_TitlePage.ucChennal1.uiChennalData.Text = value.ToString();
                            f_TitlePage.ucChennal1.uiChennalUnit.Text = unit.ToString();
                            f_TitlePage.ucChennal1.uiChennalTime.Text = time.ToString();
                        };
                        // 或者
                        // Action<string> actionDelegate = delegate(string txt) { this.ucChennal1.uiChennalData.Text = x.ToString(); };
                        f_TitlePage.ucChennal1.Invoke(actionDelegate, sensorValue, sensorUnit, createTime);
                    }
                    break;
                case 2:
                    if (f_TitlePage.ucChennal2.InvokeRequired)
                    {
                        Action<string, string, string> actionDelegate = (value, unit, time) =>
                        {
                            f_TitlePage.ucChennal2.uiChennalData.Text = value.ToString();
                            f_TitlePage.ucChennal2.uiChennalUnit.Text = unit.ToString();
                            f_TitlePage.ucChennal2.uiChennalTime.Text = time.ToString();
                        };
                        f_TitlePage.ucChennal2.Invoke(actionDelegate, sensorValue, sensorUnit, createTime);
                    }
                    break;
                case 3:
                    if (f_TitlePage.ucChennal3.InvokeRequired)
                    {
                        Action<string, string, string> actionDelegate = (value, unit, time) =>
                        {
                            f_TitlePage.ucChennal3.uiChennalData.Text = value.ToString();
                            f_TitlePage.ucChennal3.uiChennalUnit.Text = unit.ToString();
                            f_TitlePage.ucChennal3.uiChennalTime.Text = time.ToString();
                        };
                        f_TitlePage.ucChennal3.Invoke(actionDelegate, sensorValue, sensorUnit, createTime);
                    }
                    break;
                case 4:
                    if (f_TitlePage.ucChennal4.InvokeRequired)
                    {
                        Action<string, string, string> actionDelegate = (value, unit, time) =>
                        {
                            f_TitlePage.ucChennal4.uiChennalData.Text = value.ToString();
                            f_TitlePage.ucChennal4.uiChennalUnit.Text = unit.ToString();
                            f_TitlePage.ucChennal4.uiChennalTime.Text = time.ToString();
                        };
                        f_TitlePage.ucChennal4.Invoke(actionDelegate, sensorValue, sensorUnit, createTime);
                    }
                    break;
                case 5:
                    if (f_TitlePage.ucChennal5.InvokeRequired)
                    {
                        Action<string, string, string> actionDelegate = (value, unit, time) =>
                        {
                            f_TitlePage.ucChennal5.uiChennalData.Text = value.ToString();
                            f_TitlePage.ucChennal5.uiChennalUnit.Text = unit.ToString();
                            f_TitlePage.ucChennal5.uiChennalTime.Text = time.ToString();
                        };
                        f_TitlePage.ucChennal5.Invoke(actionDelegate, sensorValue, sensorUnit, createTime);
                    }
                    break;
                case 6:
                    if (f_TitlePage.ucChennal6.InvokeRequired)
                    {
                        Action<string, string, string> actionDelegate = (value, unit, time) =>
                        {
                            f_TitlePage.ucChennal6.uiChennalData.Text = value.ToString();
                            f_TitlePage.ucChennal6.uiChennalUnit.Text = unit.ToString();
                            f_TitlePage.ucChennal6.uiChennalTime.Text = time.ToString();
                        };
                        f_TitlePage.ucChennal6.Invoke(actionDelegate, sensorValue, sensorUnit, createTime);
                    }
                    break;
                case 7:
                    if (f_TitlePage.ucChennal7.InvokeRequired)
                    {
                        Action<string, string, string> actionDelegate = (value, unit, time) =>
                        {
                            f_TitlePage.ucChennal7.uiChennalData.Text = value.ToString();
                            f_TitlePage.ucChennal7.uiChennalUnit.Text = unit.ToString();
                            f_TitlePage.ucChennal7.uiChennalTime.Text = time.ToString();
                        };
                        f_TitlePage.ucChennal7.Invoke(actionDelegate, sensorValue, sensorUnit, createTime);
                    }
                    break;
                case 8:
                    if (f_TitlePage.ucChennal8.InvokeRequired)
                    {
                        Action<string, string, string> actionDelegate = (value, unit, time) =>
                        {
                            f_TitlePage.ucChennal8.uiChennalData.Text = value.ToString();
                            f_TitlePage.ucChennal8.uiChennalUnit.Text = unit.ToString();
                            f_TitlePage.ucChennal8.uiChennalTime.Text = time.ToString();
                        };
                        f_TitlePage.ucChennal8.Invoke(actionDelegate, sensorValue, sensorUnit, createTime);
                    }
                    break;

            }
        }
        #endregion

        #region 数据入库
        private static void WriteSensorData2DB(object obj)
        {
            Sensor sensor = (Sensor)obj;
            new SensorManage().InsertByTableName(sensor.tableName, sensor);
        }
        #endregion
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
                    if (key.Client.RemoteEndPoint.ToString().Split(':')[0].Equals(tCPDevice.hostName))
                    {
                        var devices = ModbusUtil.TCPdevices[key][tCPDevice.deviceAddress];
                        foreach (var device in devices)
                        {
                            if (device.deviceName.Equals(tCPDevice.deviceName))
                            {
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
                    if (key.Client.RemoteEndPoint.ToString().Split(':')[0].Equals(tCPDevice.hostName))
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


        public void RefreshData()
        {
            List<int> x1 = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            List<int> y1 = new List<int>();
            Random ra = new Random();
            y1 = new List<int>() {
                ra.Next(1, 10),
                ra.Next(1, 10),
                ra.Next(1, 10),
                ra.Next(1, 10),
                ra.Next(1, 10),
                ra.Next(1, 10),
                ra.Next(1, 10),
                ra.Next(1, 10),
                ra.Next(1, 10),
                ra.Next(1, 10),
                ra.Next(1, 10),
                ra.Next(1, 10)
            };
            RefreshChart(x1, y1, "chart1");
        }

        public delegate void RefreshChartDelegate(List<int> x, List<int> y, string type);
        public void RefreshChart(List<int> x, List<int> y, string type)
        {
            if (type == "chart1")
            {
                if (this.ucChartLine1.chart1.InvokeRequired)
                {
                    RefreshChartDelegate stcb = new RefreshChartDelegate(RefreshChart);
                    this.Invoke(stcb, new object[] { x, y, type });
                }
                else
                {
                    ucChartLine1.chart1.Series[0].Points.DataBindXY(x, y);
                }
            }
        }


    }
}