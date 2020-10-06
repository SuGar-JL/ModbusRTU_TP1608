using ModbusRTU_TP1608.Entiry;
using ModbusRTU_TP1608.Utils;
using ModbusTCP_TP1608.Entiry;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.TextFormatting;

namespace ModbusRTU_TP1608
{
    public partial class F_TitlePage : UIPage
    {
        public F_TitlePage()
        {
            InitializeComponent();
            //只要自定义了textBox的背景色与前景色后，设置Readonly = true就不会吧背景色和前景色变为默认的了
            //tB_ChennalName1.ReadOnly = true;
            //tB_ChennalName1.BackColor = Color.White;
            w1 = this.Width;//窗口最开始的宽
            h1 = this.Height;//窗口最开始的高
            setTag(this);
            textBox1.Text = String.Format("({0},{1})", this.Width, this.Height);
        }

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
            textBox1.Text = String.Format("({0},{1})", this.Width, this.Height);
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
                var sensorIds = new RTUChennalManage().GetSensorIds();
                var f_ChennalInfo = new F_ChennalInfo();
                f_ChennalInfo.chennalName.Text = chennal.chennalName;
                f_ChennalInfo.chennalID.Text = chennal.chennalID.ToString();
                f_ChennalInfo.chennalLabel.Text = chennal.chennalLabel;
                f_ChennalInfo.chennalUnit.Text = chennal.chennalUnit;
                f_ChennalInfo.chennalSensorType.Text = chennal.sensorType == null ? "" : chennal.sensorType.ToString();
                f_ChennalInfo.chennalSensorName.Text = chennal.sensorName;
                f_ChennalInfo.chennalSensorId.Text = chennal.sensorID;
                //将数据库现以配置有的传感器id填充到传感器id的下拉框
                if (sensorIds != null)
                {
                    f_ChennalInfo.chennalSensorId.Items.AddRange(sensorIds.ToArray());
                }
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
                    chennal.decimalPlaces = f_ChennalInfo.chennalDecimalPlaces.SelectedIndex + 1;
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
                    chennal.sensorTableName = Common.SensorTable[f_ChennalInfo.chennalSensorType.Text.Trim()];
                    new RTUChennalManage().UpdateByEntity(chennal);
                    
                }
            }
            else if (sys.protocol == (int)Common.Protocol.TCP)
            {
                var device = new TCPDeviceManage().GetByName(this.tB_DeviceName.Text.Trim())[0];
                var chennal = new TCPChennalManage().GetByDeviceIdAndName(device.id, ucChennal.uiChennalName.Text.Trim());
                var sensorIds = new TCPChennalManage().GetSensorIds();
                var f_ChennalInfo = new F_ChennalInfo();
                f_ChennalInfo.chennalName.Text = chennal.chennalName;
                f_ChennalInfo.chennalID.Text = chennal.chennalID.ToString();
                f_ChennalInfo.chennalLabel.Text = chennal.chennalLabel;
                f_ChennalInfo.chennalUnit.Text = chennal.chennalUnit;
                f_ChennalInfo.chennalSensorType.Text = chennal.sensorType == null ? "" : chennal.sensorType.ToString();
                f_ChennalInfo.chennalSensorName.Text = chennal.sensorName;
                f_ChennalInfo.chennalSensorId.Text = chennal.sensorID;
                //将数据库现以配置有的传感器id填充到传感器id的下拉框
                if (sensorIds != null)
                {
                    f_ChennalInfo.chennalSensorId.Items.AddRange(sensorIds.ToArray());
                }
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
                    chennal.decimalPlaces = f_ChennalInfo.chennalDecimalPlaces.SelectedIndex + 1;
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
                    chennal.sensorTableName = Common.SensorTable[f_ChennalInfo.chennalSensorType.Text.Trim()];
                    new TCPChennalManage().UpdateByEntity(chennal);
                    
                }
            }

        }
    }
}