using Modbus.Device;
using ModbusRTU_TP1608.Entiry;
using ModbusRTU_TP1608.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModbusRTU_TP1608
{
    public partial class DataCollectionForm : Form
    {
        bool flag = false;
        //记录鼠标在myTreeView控件上按下的次数
        public int num_MouseClicks = 0;
        public static DataCollectionForm dataCollectionForm;
        //设置设备（右击设备节点）时记下设备名称
        public static string deviceName;
        //打开设备（双击设备节点或选择打开设备项）时记下设备名称
        public static string deviceName_Open;
        //设置通道（右击通带节点）时记下通道名称
        public static string chennalName;
        //
        public Dictionary<string, ShowDataForm> showDataForms = new Dictionary<string, ShowDataForm>();
        public Dictionary<string, Thread> threads = new Dictionary<string, Thread>();
        public Dictionary<string, IModbusMaster> masters = new Dictionary<string, IModbusMaster>();

        //用于存储采集到的ushort数据
        private ushort[] registerBuffer;

        //定义回调（委托）
        public delegate void setTextValueCallBack(int i, string value);
        //声明委托
        public setTextValueCallBack setCallBack;
        /// <summary>
        /// 构造方法
        /// </summary>
        public DataCollectionForm()
        {
            InitializeComponent();
            dataCollectionForm = this;
        }
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataCollection_Load(object sender, EventArgs e)
        {
            //创建数据库表：设备的和通道的2个表
            new DeviceManage();
            new ChennalManage();
            //初始化设备管理页的设备和通道配置树
            treeView1_InitFromDB();

            //调试窗口
            Debug debug = new Debug();
            debug.Show();
        }
        /// <summary>
        /// 右击空白处点击添加设备
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 添加设备ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddDeviceForm f = new AddDeviceForm();
            f.ShowDialog();
        }
        /// <summary>
        /// 菜单栏的视图-》设备管理选项（该方法目前没用）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 设备管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeviceManageForm f = new DeviceManageForm();
            f.MdiParent = this;
            f.Show();
        }
        /// <summary>
        /// 菜单栏的文件-》添加设备
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 添加设备ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddDeviceForm addDevice = new AddDeviceForm();
            addDevice.ShowDialog();
        }
        /// <summary>
        /// 菜单栏的文件-》退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 菜单栏的视图-》工具栏选项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// 菜单栏的视图-》状态栏选项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        public bool flag1 = false;
        /// <summary>
        /// 工具栏第一个按钮：设备管理（目前没用）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// 关闭软件X按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataCollectionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //将目前打开的所有设备状态字段status设为0（关闭）
            new DeviceManage().CloseAllOpendingDivice();
            //关闭所有线程

            toolStripButton2.Image = Properties.Resources.start1;//不亮
            toolStripButton3.Image = Properties.Resources.stop1;//不亮

        }

        /// <summary>
        /// 设备树的点击节点事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            else if (e.Button == MouseButtons.Left)
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
        /// 双击节点（不展开或不折叠节点）
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
                    //如果不是子节点，即是根节点（设备）
                    if (CurrentNode.FirstNode != null)
                    {
                        deviceName_Open = CurrentNode.Text;
                        Device device = new DeviceManage().GetByName(deviceName_Open);
                        //1.设备没有打开
                        if (device.status == 0)
                        {
                            //设置设备为打开状态（status字段变为1）
                            new DeviceManage().UpdateStatusByName(device.deviceName, 1);
                            //设置开始采集按钮和停止采集按钮的图片
                            toolStripButton2.Image = Properties.Resources.start2;//亮
                            toolStripButton3.Image = Properties.Resources.stop1;//不亮
                            //新建并打开数据采集页
                            ShowDataForm showDataForm = new ShowDataForm();
                            showDataForm.Text = deviceName_Open;
                            showDataForm.TopLevel = false;
                            showDataForm.WindowState = FormWindowState.Maximized;
                            showDataForm.Parent = this.splitContainer1.Panel2;
                            showDataForm.SetAllTextBoxText("0.000");
                            showDataForm.Show();
                            //将此页加入字典showDataForms中
                            showDataForms.Add(key: showDataForm.Text, value: showDataForm);
                        }
                        //2.设备是打开的
                        else if (device.status == 1)
                        {
                            //设置开始采集按钮和停止采集按钮的图片
                            toolStripButton2.Image = Properties.Resources.start2;//亮
                            toolStripButton3.Image = Properties.Resources.stop1;//不亮
                            //打开数据采集页
                            //关闭，删除，重新建
                            //showDataForms[deviceName_Open].Close();
                            //showDataForms.Remove(deviceName_Open);

                            //ShowDataForm showDataForm = new ShowDataForm();
                            //showDataForm.Text = deviceName_Open;
                            //showDataForm.TopLevel = false;
                            //showDataForm.WindowState = FormWindowState.Maximized;
                            //showDataForm.Parent = this.splitContainer1.Panel2;
                            //showDataForm.Show();
                            ////将此页加入字典showDataForms中
                            //showDataForms.Add(key: deviceName_Open, value: showDataForm);
                        }
                        //3.设备在采集
                        else if (device.status == 2)
                        {
                            //设置开始采集按钮和停止采集按钮的图片
                            toolStripButton2.Image = Properties.Resources.start1;//不亮
                            toolStripButton3.Image = Properties.Resources.stop2;//亮
                            //打开数据采集页
                            //关闭，删除，重新建
                            //showDataForms[deviceName_Open].Close();
                            //showDataForms.Remove(deviceName_Open);

                            //ShowDataForm showDataForm = new ShowDataForm();
                            //showDataForm.Text = deviceName_Open;
                            //showDataForm.TopLevel = false;
                            //showDataForm.WindowState = FormWindowState.Maximized;
                            //showDataForm.Parent = this.splitContainer1.Panel2;
                            //showDataForm.Show();
                            ////将此页加入字典showDataForms中
                            //showDataForms.Add(key: deviceName_Open, value: showDataForm);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 新建设备方法，添加treeView1节点，在addDeviceForm窗体点击确定按钮调用此方法
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
        /// 获取树控件的根节点数（本来用于设置设备的id，但这样不可取，不用了）
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
            devices.Sort();//排序（按时间）
            foreach (Device device in devices)
            {
                TreeNode root = new TreeNode();
                root.Text = device.deviceName;
                List<Chennal> chennals = chennalManage.GetByDeviceId(device.id);
                chennals.Sort();//排序（按id）
                foreach (Chennal chennal in chennals)
                {
                    TreeNode chennalNode = new TreeNode();
                    chennalNode.Text = chennal.chennalName;
                    root.Nodes.Add(chennalNode);
                }
                treeView1.Nodes.Add(root);
            }
        }
        private void 打开设备ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deviceName_Open = deviceName;
            Device device = new DeviceManage().GetByName(deviceName_Open);
            //1.设备没有打开
            if (device.status == 0)
            {
                //设置设备为打开状态（status字段变为1）
                new DeviceManage().UpdateStatusByName(device.deviceName, 1);
                //设置开始采集按钮和停止采集按钮的图片
                toolStripButton2.Image = Properties.Resources.start2;//亮
                toolStripButton3.Image = Properties.Resources.stop1;//不亮
                //新建并打开数据采集页
                ShowDataForm showDataForm = new ShowDataForm();
                showDataForm.Text = deviceName_Open;
                showDataForm.TopLevel = false;
                showDataForm.WindowState = FormWindowState.Maximized;
                showDataForm.Parent = this.splitContainer1.Panel2;
                showDataForm.SetAllTextBoxText("0.000");
                showDataForm.Show();
                //将此页加入字典showDataForms中
                showDataForms.Add(key: showDataForm.Text, value: showDataForm);
            }
            //2.设备是打开的
            else if (device.status == 1)
            {
                //设置开始采集按钮和停止采集按钮的图片
                toolStripButton2.Image = Properties.Resources.start2;//亮
                toolStripButton3.Image = Properties.Resources.stop1;//不亮
                //打开数据采集页
                //关闭，删除，重新建
                //showDataForms[deviceName_Open].Close();
                //showDataForms.Remove(deviceName_Open);

                //ShowDataForm showDataForm = new ShowDataForm();
                //showDataForm.Text = deviceName_Open;
                //showDataForm.TopLevel = false;
                //showDataForm.WindowState = FormWindowState.Maximized;
                //showDataForm.Parent = this.splitContainer1.Panel2;
                //showDataForm.Show();
                ////将此页加入字典showDataForms中
                //showDataForms.Add(key: deviceName_Open, value: showDataForm);
            }
            //3.设备在采集
            else if (device.status == 2)
            {
                //设置开始采集按钮和停止采集按钮的图片
                toolStripButton2.Image = Properties.Resources.start1;//不亮
                toolStripButton3.Image = Properties.Resources.stop2;//亮
                //打开数据采集页
                //关闭，删除，重新建
                //showDataForms[deviceName_Open].Close();
                //showDataForms.Remove(deviceName_Open);

                //ShowDataForm showDataForm = new ShowDataForm();
                //showDataForm.Text = deviceName_Open;
                //showDataForm.TopLevel = false;
                //showDataForm.WindowState = FormWindowState.Maximized;
                //showDataForm.Parent = this.splitContainer1.Panel2;
                //showDataForm.Show();
                ////将此页加入字典showDataForms中
                //showDataForms.Add(key: deviceName_Open, value: showDataForm);
            }
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
                List<Chennal> chennals = new ChennalManage().GetByDeviceId(device.id.ToString());
                //删除每个通道绑定的传感器
                foreach (Chennal chennal in chennals)
                {
                    if (chennal.sensorID != null)
                    {
                        new SensorManage().DeleteByTableNameAndId(chennal.sensorTableName, chennal.sensorID);
                    }
                }
                //删除通道
                new ChennalManage().DeleteByDeviceId(device.id.ToString());
                //删除设备
                new DeviceManage().DeleteById(device.id.ToString());
                treeView1_InitFromDB();
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

        /// <summary>
        /// 开始采集按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //获得当前的设备配置
            Device device = new DeviceManage().GetByName(deviceName_Open);
            //当开始采集的按钮是亮的，即，设备状态为：打开
            if (device != null && device.status == 1 && CheckPort(device))
            {
                //C#多线程和java里的用Runable实现多线程很像
                Thread thread = new Thread(new ParameterizedThreadStart(Collection));
                thread.Name = deviceName_Open;
                //thread.IsBackground = true;//后台线程
                //把线程存在字典里
                threads.Add(key: device.deviceName, value: thread);
                //开启线程
                thread.Start(device);

                //设置设备为采集状态（status字段变为2）
                new DeviceManage().UpdateStatusByName(device.deviceName, 2);
                //设置开始采集和停止采集按钮的图片
                toolStripButton2.Image = Properties.Resources.start1;//不亮
                toolStripButton3.Image = Properties.Resources.stop2;//亮
            }
        }
        /// <summary>
        /// 线程调用的采集方法
        /// </summary>
        /// <param name="obj"></param>
        private void Collection(Object obj)
        {
            Device device = (Device)obj;
            while (true)
            {
                lock (device)
                {
                    SerialPort port = new SerialPort(device.port, int.Parse(device.baudRate), Parity.None, 8, StopBits.One);
                    IModbusMaster master = ModbusSerialMaster.CreateRtu(port);
                    //参数(分别为站号,起始地址,长度)
                    byte slaveAddress = byte.Parse(device.deviceAddress);//设备地址
                                                                         //ushort startAddress = ushort.Parse((device.startChennal * 2 - 2) + "");//起始地址
                    ushort startAddress = 0;//起始地址
                                            //ushort numberOfPoints = ushort.Parse((device.chennalNum * 2) + "");//读几个
                    ushort numberOfPoints = 16;//读几个
                    Thread td = Thread.CurrentThread;
                    ThreadState state = td.ThreadState;
                    string strMsg = string.Format("========开始采集========线程：{0}---- 时间：{1}\n", td.Name, DateTime.Now);
                    Debug.debug.SetMsg(strMsg);
                    strMsg = string.Format("线程：{0}-- 状态：{1}-- 端口：{2}-- 地址：{3}-- 时间：{4}\n", td.Name, state, port.PortName, slaveAddress, DateTime.Now);
                    Debug.debug.SetMsg(strMsg);
                    try
                    {
                        //每次操作是要开启串口 操作完成后需要关闭串口
                        if (port.IsOpen == false)
                        {
                            port.Open();
                            strMsg = string.Format("线程：{0}--打开串口：{1}-- 时间：{2}\n", td.Name, port.PortName, DateTime.Now);
                            Debug.debug.SetMsg(strMsg);
                        }
                        //返回的数据为unshort型，要转为float型
                        registerBuffer = master.ReadHoldingRegisters(slaveAddress, startAddress, numberOfPoints);
                        //ushort[]=>float[]
                        float[] result = DataTypeConvert.GetReal(registerBuffer, 0);//得到8个32位浮点数
                        Chennal chennal;
                        for (int i = device.startChennal - 1; i < device.startChennal + device.chennalNum - 1; i++)
                        {
                            chennal = new ChennalManage().GetByDeviceIdAndId(device.id.ToString(), i + 1);
                            if (chennal.sensorID != null)
                            {
                                Sensor sensor = new Sensor();
                                sensor.sensorId = chennal.sensorID;
                                sensor.sensorName = chennal.sensorName;
                                sensor.sensorType = chennal.sensorType;
                                sensor.sensorLabel = chennal.chennalLabel;
                                sensor.sensorValue = result[i].ToString();
                                sensor.sensorUnit = chennal.chennalUnit;
                                sensor.createBy = "设备：" + device.deviceName;
                                sensor.createTime = DateTime.Now;
                                sensor.updateBy = "设备：" + device.deviceName;
                                sensor.updateTime = DateTime.Now;
                                new SensorManage().InsertByTableName(chennal.sensorTableName,sensor);
                                strMsg = string.Format("线程：{0}--数据{1}存入数据库完成-- 时间：{2}\n", td.Name, result[i], DateTime.Now);
                                Debug.debug.SetMsg(strMsg);
                                //设置ShowDataForm的显示
                                if (setCallBack != null)
                                {
                                    setCallBack(i, result[i].ToString());
                                }
                            }
                        }
                        strMsg = string.Format("线程：{0}--串口{1}状态：IsOpen = {2}-- 时间：{3}\n", td.Name, port.PortName, port.IsOpen, DateTime.Now);
                        Debug.debug.SetMsg(strMsg);
                        //关闭串口
                        port.Close();
                        strMsg = string.Format("线程：{0}--串口{1}状态：IsOpen = {2}-- 时间：{3}\n", td.Name, port.PortName, port.IsOpen, DateTime.Now);
                        Debug.debug.SetMsg(strMsg);
                        strMsg = string.Format("========本轮采集轮结束========线程：{0}---- 时间：{1}\n", td.Name, DateTime.Now);
                        Debug.debug.SetMsg(strMsg);
                        Thread.Sleep(3000);//线程休眠3s
                        
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("采集中发生异常：" + ex.Message, "异常！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    finally
                    {
                        if (port.IsOpen == true)
                        {
                            port.Close();//无论如何，关闭串口
                        }
                    }
                }
            }

        }

        /// <summary>
        /// 检查当前设备的串口号是否为空，为空时不能进行采集，弹出提示
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public bool CheckPort(Device device)
        {
            if (device.port == null)
            {
                MessageBox.Show("设备的串口号不能为空，请配置！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        /// <summary>
        /// 停止采集按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton3_Click(object sender, EventArgs e)
        {

            //获得当前的设备配置
            Device device = new DeviceManage().GetByName(deviceName_Open);
            //当停止采集的按钮是亮的，即，设备状态为：采集
            if (device.status == 2)
            {
                //终止线程
                threads[deviceName_Open].Abort();
                ThreadState state = threads[deviceName_Open].ThreadState;
                MessageBox.Show("终止了设备：" + deviceName_Open + "的采集，线程的状态：" + state.ToString());
                //删除字典里的线程
                threads.Remove(deviceName_Open);
                //设置设备为打开状态（status字段变为1）
                new DeviceManage().UpdateStatusByName(device.deviceName, 1);
                //设置开始采集和停止采集按钮的图片
                toolStripButton2.Image = Properties.Resources.start2;//亮
                toolStripButton3.Image = Properties.Resources.stop1;//不亮
            }
        }

    }


}
