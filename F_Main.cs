using Modbus.Device;
using ModbusRTU_TP1608.Entiry;
using ModbusRTU_TP1608.Utils;
using Org.BouncyCastle.Asn1.Tsp;
using Sunny.UI;
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
    public partial class F_Main : Form
    {
        private F_DeviceManage f_DeviceManage;
        bool flag = false;
        //记录鼠标在myTreeView控件上按下的次数
        public int num_MouseClicks = 0;
        public static F_Main f_Main;
        //设置设备（右击设备节点）时记下设备名称
        public static string currRightDownDevice;
        //打开设备（双击设备节点或选择打开设备项）时记下设备名称
        public static string currOpenDevice;
        //设置通道（右击通带节点）时记下通道名称
        public static string currRightDownChennal;
        //
        public Dictionary<string, ShowDataForm> showDataForms = new Dictionary<string, ShowDataForm>();
        //保存进行采集的设备的串口与使用的Collector(master+地址)
        private Dictionary<SerialPort, Collector> collectors = new Dictionary<SerialPort, Collector>();
        private Dictionary<string, SerialPort> ports = new Dictionary<string, SerialPort>();
        
        public Dictionary<string, Thread> threads = new Dictionary<string, Thread>();

        //定义回调（委托）
        public delegate void setTextValueCallBack(int i, string value);
        //声明委托
        public setTextValueCallBack setCallBack;
        /// <summary>
        /// 构造方法
        /// </summary>
        public F_Main()
        {
            InitializeComponent();
            f_Main = this;
        }
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataCollection_Load(object sender, EventArgs e)
        {
            //显示设备管理页
            f_DeviceManage = new F_DeviceManage();
            f_DeviceManage.Show(dockPanel1);
            f_DeviceManage.DockTo(dockPanel1, DockStyle.Left);//让Form2显示在dockPanel1左边
            
            //创建数据库表：设备的和通道的2个表
            try
            {
                new DeviceManage();
                new ChennalManage();
            }
            catch (Exception ex)
            {
                MessageBox.Show("异常！" + ex.Message, "异常！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //初始化设备管理页的设备和通道配置树
            //treeView1_InitFromDB();

            //调试窗口
            Debug debug = new Debug();
            debug.Show();

            ShowDataForm showDataForm = new ShowDataForm();
            showDataForm.Text = currOpenDevice;
            showDataForm.TopLevel = false;
            showDataForm.WindowState = FormWindowState.Maximized;
            //showDataForm.Parent = this.splitContainer1.Panel2;
            showDataForm.SetAllTextBoxText("0.00");
            showDataForm.Show();
        }
        /// <summary>
        /// 右击空白处点击添加设备
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 添加设备ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_AddDevice f = new F_AddDevice();
            f.ShowDialog();
        }
        /// <summary>
        /// 菜单栏的视图-》设备管理选项（该方法目前没用）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 设备管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_DeviceManage f = new F_DeviceManage();
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
            F_AddDevice addDevice = new F_AddDevice();
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
        private bool flag1 = false;
        /// <summary>
        /// 工具栏第一个按钮：设备管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tSB_设备管理_Click(object sender, EventArgs e)
        {  
            //若设备管理窗口没有实例化或已经被释放（关闭了）
            if (f_DeviceManage == null || f_DeviceManage.IsDisposed == true)
            {
                f_DeviceManage = new F_DeviceManage();
                f_DeviceManage.Show(dockPanel1);
                f_DeviceManage.DockTo(dockPanel1, DockStyle.Left);
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
            Dictionary<string, Thread>.KeyCollection keys = threads.Keys;
            foreach (string key in keys)
            {
                threads[key].Abort();
            }
            toolStripButton2.Image = Properties.Resources.start1;//不亮
            stopCollectButton.Image = Properties.Resources.stop1;//不亮

        }

        /// <summary>
        /// 设备树的点击节点事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void treeView1_MouseDown(object sender, MouseEventArgs e)
        //{
        //    //右击节点弹出菜单，根节点与子节点不同
        //    if (e.Button == MouseButtons.Right)
        //    {
        //        Point ClickPoint = new Point(e.X, e.Y);
        //        TreeNode CurrentNode = treeView1.GetNodeAt(ClickPoint);
        //        //点击的是节点，且是节点所在区域
        //        if (CurrentNode != null && CurrentNode.Bounds.Contains(e.X, e.Y))
        //        {
        //            //如果不是子节点，即是根节点
        //            if (CurrentNode.FirstNode != null)
        //            {
        //                currRightDownDevice = CurrentNode.Text;
        //                treeView1.ContextMenuStrip = contextMenuStrip_setDevice;
        //            }
        //            //是子节点
        //            else if (CurrentNode.Parent != null)
        //            {
        //                currRightDownChennal = CurrentNode.Text;
        //                treeView1.ContextMenuStrip = contextMenuStrip_setChennalAndSensor;
        //            }

        //        }
        //        //点击的不是节点（空白处）
        //        else
        //        {
        //            treeView1.ContextMenuStrip = contextMenuStrip_addDevice;
        //        }
        //    }
        //    //为了我不让双击时展开节点，而是做其他操作，winform默认双击左键会展开节点
        //    //左键点击
        //    else if (e.Button == MouseButtons.Left)
        //    {
        //        num_MouseClicks = e.Clicks;//记录左键按下次数
        //    }
        //}
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
        //private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        Point ClickPoint = new Point(e.X, e.Y);
        //        TreeNode CurrentNode = treeView1.GetNodeAt(ClickPoint);
        //        //点击的是节点，且是节点所在区域
        //        if (CurrentNode != null && CurrentNode.Bounds.Contains(e.X, e.Y))
        //        {
        //            //如果不是子节点，即是根节点（设备）
        //            if (CurrentNode.FirstNode != null)
        //            {
        //                currOpenDevice = CurrentNode.Text;
        //                Device device = new DeviceManage().GetByName(currOpenDevice);
        //                //1.设备没有打开
        //                if (device.status == 0)
        //                {
        //                    //设置设备为打开状态（status字段变为1）
        //                    new DeviceManage().UpdateStatusByName(device.deviceName, 1);
        //                    //设置开始采集按钮和停止采集按钮的图片
        //                    toolStripButton2.Image = Properties.Resources.start2;//亮
        //                    stopCollectButton.Image = Properties.Resources.stop1;//不亮
        //                    //新建并打开数据采集页
        //                    ShowDataForm showDataForm = new ShowDataForm();
        //                    showDataForm.Text = currOpenDevice;
        //                    showDataForm.TopLevel = false;
        //                    showDataForm.WindowState = FormWindowState.Maximized;
        //                    showDataForm.Parent = this.splitContainer1.Panel2;
        //                    showDataForm.SetAllTextBoxText("0.00");
        //                    //showDataForm.Show();
        //                    //将此页加入字典showDataForms中
        //                    showDataForms.Add(key: currOpenDevice, value: showDataForm);
        //                    //showDataForms[currOpenDevice].Show();
        //                }
        //                //2.设备是打开的
        //                else if (device.status == 1)
        //                {
        //                    //设置开始采集按钮和停止采集按钮的图片
        //                    toolStripButton2.Image = Properties.Resources.start2;//亮
        //                    stopCollectButton.Image = Properties.Resources.stop1;//不亮
        //                    //打开数据采集页
        //                    //关闭，删除，重新建
        //                    //showDataForms[deviceName_Open].Close();
        //                    //showDataForms.Remove(deviceName_Open);

        //                    //ShowDataForm showDataForm = new ShowDataForm();
        //                    //showDataForm.Text = deviceName_Open;
        //                    //showDataForm.TopLevel = false;
        //                    //showDataForm.WindowState = FormWindowState.Maximized;
        //                    //showDataForm.Parent = this.splitContainer1.Panel2;
        //                    //showDataForm.Show();
        //                    ////将此页加入字典showDataForms中
        //                    //showDataForms.Add(key: deviceName_Open, value: showDataForm);
        //                }
        //                //3.设备在采集
        //                else if (device.status == 2)
        //                {
        //                    //设置开始采集按钮和停止采集按钮的图片
        //                    toolStripButton2.Image = Properties.Resources.start1;//不亮
        //                    stopCollectButton.Image = Properties.Resources.stop2;//亮
        //                    //打开数据采集页
        //                    //关闭，删除，重新建
        //                    //showDataForms[deviceName_Open].Close();
        //                    //showDataForms.Remove(deviceName_Open);

        //                    //ShowDataForm showDataForm = new ShowDataForm();
        //                    //showDataForm.Text = deviceName_Open;
        //                    //showDataForm.TopLevel = false;
        //                    //showDataForm.WindowState = FormWindowState.Maximized;
        //                    //showDataForm.Parent = this.splitContainer1.Panel2;
        //                    //showDataForm.Show();
        //                    ////将此页加入字典showDataForms中
        //                    //showDataForms.Add(key: deviceName_Open, value: showDataForm);
        //                }
        //            }
        //        }
        //    }
        //}
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
            //treeView1.Nodes.Add(root);
            //展开所有节点
            //treeView1.ExpandAll();
        }
        /// <summary>
        /// 获取树控件的根节点数（本来用于设置设备的id，但这样不可取，不用了）
        /// </summary>
        /// <returns></returns>
        //public int treeView1_rootNodeNum()
        //{
        //    return treeView1.GetNodeCount(false);//不包含子节点
        //}

        /// <summary>
        /// 用于每次打开软件，自动从数据库读取之前设置的配置信息
        /// </summary>
        //public void treeView1_InitFromDB()
        //{
        //    treeView1.Nodes.Clear();
        //    DeviceManage deviceManage = new DeviceManage();
        //    ChennalManage chennalManage = new ChennalManage();
        //    List<Device> devices = deviceManage.GetAllOrderById();
        //    foreach (Device device in devices)
        //    {
        //        TreeNode root = new TreeNode();
        //        root.Text = device.deviceName;
        //        List<Chennal> chennals = chennalManage.GetByDeviceId(device.id);
        //        foreach (Chennal chennal in chennals)
        //        {
        //            TreeNode chennalNode = new TreeNode();
        //            chennalNode.Text = chennal.chennalName;
        //            root.Nodes.Add(chennalNode);
        //        }
        //        treeView1.Nodes.Add(root);
        //    }
        //}
        private void 打开设备ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currOpenDevice = currRightDownDevice;
            Device device = new DeviceManage().GetByName(currOpenDevice);
            //1.设备没有打开
            if (device.status == 0)
            {
                //设置设备为打开状态（status字段变为1）
                new DeviceManage().UpdateStatusByName(device.deviceName, 1);
                //设置开始采集按钮和停止采集按钮的图片
                toolStripButton2.Image = Properties.Resources.start2;//亮
                stopCollectButton.Image = Properties.Resources.stop1;//不亮
                //新建并打开数据采集页
                ShowDataForm showDataForm = new ShowDataForm();
                showDataForm.Text = currOpenDevice;
                showDataForm.TopLevel = false;
                showDataForm.WindowState = FormWindowState.Maximized;
                //showDataForm.Parent = this.splitContainer1.Panel2;
                showDataForm.SetAllTextBoxText("0.000");
                //showDataForm.Show();
                //将此页加入字典showDataForms中
                showDataForms.Add(key: showDataForm.Text, value: showDataForm);
            }
            //2.设备是打开的
            else if (device.status == 1)
            {
                //设置开始采集按钮和停止采集按钮的图片
                toolStripButton2.Image = Properties.Resources.start2;//亮
                stopCollectButton.Image = Properties.Resources.stop1;//不亮
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
                stopCollectButton.Image = Properties.Resources.stop2;//亮
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
                Device device = new DeviceManage().GetByName(currRightDownDevice);
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
                //treeView1_InitFromDB();
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
            //获得当前的设备配置信息
            Device device = new DeviceManage().GetByName(currOpenDevice);
            //当开始采集的按钮是亮的，即，设备状态为：打开，且串口已经配置
            if (device != null && device.status == 1 && CheckPort(device.port))
            {
                SerialPort port = new SerialPort(device.port, int.Parse(device.baudRate), Parity.None, 8, StopBits.One);
                //若串口已经存在（其他采集中的设备在使用）
                if (ports.ContainsKey(device.port))
                {
                    //根据port名称将设备地址接入到相应的collector中
                    if (collectors[ports[device.port]].AddDevice(device))
                    {
                        MessageBox.Show("操作成功，设备开始采集！","提示！",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                //若串口不存在（其他采集中的设备没使用过，新来的）
                else
                {
                    //new一个新的Collector对象，传入设备用的串口对象port，创建collector中的master
                    Collector collector = new Collector(port);
                    //将设备的地址加入到collector的地址列表
                    
                    if (collector.AddDevice(device))
                    {
                        MessageBox.Show("操作成功，设备开始采集！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    //将串口与collector保存下来
                    collectors.Add(port,collector);
                    ports.Add(device.port, port);
                    //打开串口
                    if (!port.IsOpen)
                    {
                        port.Open();
                    }
                    //开启一个新线程，轮询当前串口的所有设备
                    Thread thread = new Thread(new ParameterizedThreadStart(Collection));
                    //线程存入collector中
                    collector.SetThread(thread);
                    thread.Name = device.deviceName;
                    thread.Start(collector);
                    //MessageBox.Show("开启线程，设备开始采集！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                new DeviceManage().UpdateStatusByName(device.deviceName, 2);//设置设备为采集状态（status字段变为2）
                /*设置开始采集和停止采集按钮的图片*/
                toolStripButton2.Image = Properties.Resources.start1;//不亮
                stopCollectButton.Image = Properties.Resources.stop2;//亮
            }
        }
        /// <summary>
        /// 线程调用的采集方法
        /// </summary>
        /// <param name="obj"></param>
        private void Collection(Object obj)
        {
            Collector collector = (Collector)obj;
            Thread td = Thread.CurrentThread;
            ThreadState state = td.ThreadState;
            while (true)
            {
                Dictionary<string, Device> devices = collector.GetDevices();//获取当前串口所有设备
                lock (devices)
                {
                    string strMsg = string.Format("********************开始采集（轮询）【{0}】********************\n", DateTime.Now);
                    Debug.debug.SetMsg(strMsg);
                    //轮询串口上的所有设备
                    foreach (string deviceAddress in devices.Keys)
                    {
                        try
                        {
                            strMsg = string.Format("线程：{0}==>状态：{1}==>端口：{2}==>地址：{3}==>时间：{4}\n", td.Name, state, devices[deviceAddress].port, deviceAddress, DateTime.Now);
                            Debug.debug.SetMsg(strMsg);
                            ushort[] registerBuffer = collector.GetMaster().ReadHoldingRegisters(byte.Parse(deviceAddress), 0, 16);
                            if (registerBuffer.Length == 0)
                            {
                                DialogResult dr = MessageBox.Show("没有采集到数据，检查设备连接！", "异常！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                if (dr == DialogResult.OK)
                                {
                                    //设置设备为打开状态（status字段变为1）
                                    new DeviceManage().UpdateStatusByName(devices[deviceAddress].deviceName, 1);
                                    //设置开始采集按钮和停止采集按钮的图片
                                    toolStripButton2.Image = Properties.Resources.start2;//亮
                                    stopCollectButton.Image = Properties.Resources.stop1;//不亮
                                    Thread.CurrentThread.Abort();
                                }
                                    
                            }
                            //ushort[]=>float[]
                            float[] result = DataTypeConvert.GetReal(registerBuffer, 0);//得到8个32位浮点数
                            strMsg = string.Format("{0} {1} {2} {3} {4} {5} {6} {7}\n", result[0].ToString(), result[1].ToString(), result[2].ToString(), result[3].ToString(), result[4].ToString(), result[5].ToString(), result[6].ToString(), result[7].ToString());
                            Debug.debug.SetMsg(strMsg);
                            List<Chennal> chennals = new ChennalManage().GetByDeviceId(devices[deviceAddress].id);
                            int i = 0;//遍历result的索引
                            foreach (Chennal chennal in chennals)
                            {
                                if (chennal.sensorID != null)
                                {
                                    Sensor sensor = new Sensor();
                                    sensor.sensorId = chennal.sensorID;
                                    sensor.sensorName = chennal.sensorName;
                                    sensor.sensorType = chennal.sensorType;
                                    sensor.sensorLabel = chennal.chennalLabel;
                                    sensor.sensorValue = result[i].ToString();
                                    sensor.sensorUnit = chennal.chennalUnit;
                                    sensor.createBy = "设备：" + devices[deviceAddress].deviceName;
                                    sensor.createTime = DateTime.Now;
                                    sensor.updateBy = "设备：" + devices[deviceAddress].deviceName;
                                    sensor.updateTime = DateTime.Now;
                                    //将传感器数据入库
                                    new SensorManage().InsertByTableName(chennal.sensorTableName, sensor);
                                    strMsg = string.Format("线程：{0}==>传感器{1}数据【{2}】已存入数据库==>时间：{3}\n", td.Name, sensor.sensorName, result[i], DateTime.Now);
                                    Debug.debug.SetMsg(strMsg);

                                    //显示
                                    switch (i + 1)
                                    {
                                        case 1:
                                            ShowDataForm.showDataForm.SetTextBox1(result[i].ToString());
                                            break;
                                        case 2:
                                            ShowDataForm.showDataForm.SetTextBox2(result[i].ToString());
                                            break;
                                        case 3:
                                            ShowDataForm.showDataForm.SetTextBox3(result[i].ToString());
                                            break;
                                        case 4:
                                            ShowDataForm.showDataForm.SetTextBox4(result[i].ToString());
                                            break;
                                        case 5:
                                            ShowDataForm.showDataForm.SetTextBox5(result[i].ToString());
                                            break;
                                        case 6:
                                            ShowDataForm.showDataForm.SetTextBox6(result[i].ToString());
                                            break;
                                        case 7:
                                            ShowDataForm.showDataForm.SetTextBox7(result[i].ToString());
                                            break;
                                        case 8:
                                            ShowDataForm.showDataForm.SetTextBox8(result[i].ToString());
                                            break;
                                    }
                                    ShowDataForm.showDataForm.SetTextBox_time(sensor.createTime.ToString());
                                }
                                i++;
                            }
                        }
                        catch (Exception ex)
                        {
                            DialogResult dr = MessageBox.Show("采集中发生异常：" + ex.Message, "异常！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            if (dr == DialogResult.OK)
                            {
                                //设置设备为打开状态（status字段变为1）
                                if (devices.ContainsKey(deviceAddress))
                                {
                                    if (devices[deviceAddress].status == 2)
                                    {
                                        new DeviceManage().UpdateStatusByName(devices[deviceAddress].deviceName, 1);
                                    }
                                }
                                //设置开始采集按钮和停止采集按钮的图片
                                toolStripButton2.Image = Properties.Resources.start2;//亮
                                stopCollectButton.Image = Properties.Resources.stop1;//不亮
                                td.Abort();
                                this.Close();
                            }
                        }
                    }
                    strMsg = string.Format("********************该次轮询结束【{0}】********************\n\n", DateTime.Now);
                    Debug.debug.SetMsg(strMsg);
                    Thread.Sleep(3000);//线程休眠3s
                }
            }

        }

        /// <summary>
        /// 检查当前设备的串口号是否为空，为空时不能进行采集，弹出提示
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public bool CheckPort(string port)
        {
            if (port == null)
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
        private void stopCollectButton_Click(object sender, EventArgs e)
        {
            //获得当前的设备配置
            Device device = new DeviceManage().GetByName(currOpenDevice);
            //当停止采集的按钮是亮的，即，设备状态为：采集
            if (device.status == 2)
            {
                //将设备从相应的collector的设备集合中删除
                //1.找到设备用的串口号
                foreach (SerialPort port in collectors.Keys)
                {
                    if (port.PortName.Equals(device.port))
                    {
                        //2.删除
                        collectors[port].DelDevice(device);
                        //若设备停止采集后，该串口下没有设备在采集了，就停止采集，关闭串口和线程
                        if (collectors[port].GetDevices().Count == 0)
                        {
                            port.Close();
                            //关闭线程在Collector中做了
                        }
                    }
                }
                //设置设备为打开状态（status字段变为1）
                new DeviceManage().UpdateStatusByName(device.deviceName, 1);
                //设置开始采集和停止采集按钮的图片
                toolStripButton2.Image = Properties.Resources.start2;//亮
                stopCollectButton.Image = Properties.Resources.stop1;//不亮
            }
        }
    }


}
