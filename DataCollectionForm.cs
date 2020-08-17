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
        public int num_MouseClicks = 0; //记录鼠标在myTreeView控件上按下的次数
        public static DataCollectionForm dataCollectionForm;
        public static string deviceName;
        public static string deviceName_Open;
        public static string chennalName;
        public Dictionary<string, ShowDataForm> showDataForms = new Dictionary<string, ShowDataForm>();
        public Dictionary<string, Thread> threads = new Dictionary<string, Thread>();
        public Dictionary<string, IModbusMaster> masters = new Dictionary<string, IModbusMaster>();

        //获得master
        private static IModbusMaster master;
        //串口
        private static SerialPort port;
        //参数(分别为站号,起始地址,长度)
        private byte slaveAddress;
        private ushort startAddress;
        private ushort numberOfPoints;
        //用于存储采集到的ushort数据
        private ushort[] registerBuffer;

        //定义回调
        private delegate void setTextValueCallBack(int i, string value);
        //声明回调
        private setTextValueCallBack setCallBack;
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

        /// <summary>
        /// 关闭软件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataCollectionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //将目前打开的所有设备关闭
            new DeviceManage().CloseAllOpendingDivice();
            toolStripButton2.Image = Properties.Resources.start1;//不亮
            toolStripButton3.Image = Properties.Resources.stop1;//不亮

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
                            showDataForms.Add(key: deviceName_Open, value: showDataForm);
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
                showDataForms.Add(key: deviceName_Open, value: showDataForm);
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

        /// <summary>
        /// 开始采集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //获得当前的设备配置
            Device device = new DeviceManage().GetByName(deviceName_Open);
            //当开始采集的按钮是亮的，即，设备状态为：打开
            if (device.status == 1)
            {
                //开始采集
                //1.初始化串口(COM名称, 波特率, 校验位（无、奇、偶）, 数据位, 停止位（0、1、2）)

                port = new SerialPort(device.port, int.Parse(device.baudRate), Parity.None, 8, StopBits.One);
                //2.实例化MobusMaster
                master = ModbusSerialMaster.CreateRtu(port);
                masters.Add(device.deviceName,master);
                //3.采集(开启一个线程)
                //设置读的参数
                slaveAddress = byte.Parse(device.deviceAddress);//设备地址
                startAddress = ushort.Parse((device.startChennal * 2 - 2) + "");//起始地址
                numberOfPoints = ushort.Parse((device.chennalNum * 2) + "");//读几个
                //实例化回调
                setCallBack = new setTextValueCallBack(SetValue);
                Thread thread = new Thread(new ParameterizedThreadStart(Collection));
                thread.Name = deviceName_Open;
                //thread.IsBackground = true;
                //把线程存在字典里
                threads.Add(key: device.deviceName, value: thread);
                thread.Start(device);

                //设置设备为采集状态（status字段变为2）
                new DeviceManage().UpdateStatusByName(device.deviceName, 2);
                //设置开始采集和停止采集按钮的图片
                toolStripButton2.Image = Properties.Resources.start1;//不亮
                toolStripButton3.Image = Properties.Resources.stop2;//亮


            }
        }
        /// <summary>
        /// 采集方法
        /// </summary>
        /// <param name="obj"></param>
        private async void Collection(Object obj)
        {
            Device device = (Device)obj;
            while (true)
            {
                try
                {
                    Thread td = Thread.CurrentThread;
                    ThreadState state = td.ThreadState;
                    string strMsg = string.Format("当前执行的线程：{0}，状态：{1}\n 端口：{2}, 地址：{3}", td.Name, state, port.PortName, slaveAddress);
                    SetMsg(strMsg);
                    SetMsg("\r\n");

                    //每次操作是要开启串口 操作完成后需要关闭串口
                    //目的是为了slave更换连接时不报错
                    if (port.IsOpen == false)
                    {
                        port.Open();
                    }
                    //返回的数据为unshort型，要转为float型
                    registerBuffer = master.ReadHoldingRegisters(slaveAddress, startAddress, numberOfPoints);
                    //ushort[]=>float[]
                    float[] result = DataTypeConvert.GetReal(registerBuffer, 0);//得到8个32位浮点数
                    Chennal chennal;
                    for (int i = device.startChennal - 1; i < device.startChennal + device.chennalNum - 1; i++)
                    {
                        chennal = new ChennalManage().GetByDeviceIdAndId(device.id, i + 1);
                        if (chennal.sensorID != null)
                        {
                            Sensor sensor = new SensorManage().GetByTableNameAndId(chennal.sensorTableName, chennal.sensorID);
                            sensor.sensorValue = result[i].ToString();
                            sensor.updateBy = "设备：" + device.deviceName;
                            sensor.updateTime = DateTime.Now;
                            //将采集的数据存入对应的传感器表
                            new SensorManage().UpdateByTableNameAndId(chennal.sensorTableName, chennal.sensorID, sensor);
                            //设置ShowDataForm的显示
                            showDataForms[device.deviceName].Invoke(setCallBack, i, result[i].ToString());
                        }
                    }
                    //关闭串口
                    port.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                //会由间隔4秒的时候，为啥呢？？？？？？？？？？？？？
                //Thread.CurrentThread.Join(3000);//方法间隔3s执行一次(阻止调用线程，直到某个线程终止时为止)
                Thread.Sleep(3000);//线程休眠3s
            }

        }
        /// <summary>
        /// 停止采集
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

        public void SetValue(int i, string value)
        {
            ShowDataForm.showDataForm.SetValue(i, value);
        }

        public void SetMsg(string msg)
        {
            richTextBox1.Invoke(new Action(() => { richTextBox1.AppendText(msg); }));
        }
    }


}
