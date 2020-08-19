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
    public partial class AddDeviceForm : Form
    {
        public AddDeviceForm()
        {
            InitializeComponent();

        }

        private void AddDeviceForm_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //点击取消按钮
            this.Close();
        }

        //点击确定，检查表单是否有空值
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkForm(comboBox1.Text.Trim(), textBox1.Text.Trim(), textBox2.Text.Trim(), comboBox2.Text.Trim(), comboBox3.Text.Trim()))
            {
                string deviceType = comboBox1.Text.Trim();
                string deviceName = textBox1.Text.Trim();
                string deviceAddress = textBox2.Text.Trim();
                int chennalNum = 0;
                int startChennalId = 0;
                switch (comboBox2.Text.Trim())
                {
                    case "1 通道":
                        chennalNum = 1;
                        break;
                    case "2 通道":
                        chennalNum = 2;
                        break;
                    case "3 通道":
                        chennalNum = 3;
                        break;
                    case "4 通道":
                        chennalNum = 4;
                        break;
                    case "5 通道":
                        chennalNum = 5;
                        break;
                    case "6 通道":
                        chennalNum = 6;
                        break;
                    case "7 通道":
                        chennalNum = 7;
                        break;
                    case "8 通道":
                        chennalNum = 8;
                        break;
                }
                switch (comboBox3.Text.Trim())
                {
                    case "第 1 通道":
                        startChennalId = 1;
                        break;
                    case "第 2 通道":
                        startChennalId = 2;
                        break;
                    case "第 3 通道":
                        startChennalId = 3;
                        break;
                    case "第 4 通道":
                        startChennalId = 4;
                        break;
                    case "第 5 通道":
                        startChennalId = 5;
                        break;
                    case "第 6 通道":
                        startChennalId = 6;
                        break;
                    case "第 7 通道":
                        startChennalId = 7;
                        break;
                    case "第 8 通道":
                        startChennalId = 8;
                        break;
                }
                //将设备和通道配置信息写入数据库
                //1.设置设备的配置信息（初始化设备配置）
                Device device = new Device();
                //device.id = "" + (new DeviceManage().GetMaxId() + 1);
                device.status = 0;//设备默认为关闭状态
                device.deviceType = deviceType;
                device.deviceName = deviceName;
                device.deviceAddress = deviceAddress;
                device.chennalNum = chennalNum;
                device.startChennal = startChennalId;
                device.storeInterval = 6.0F;//设置保存间隔默认值为6.0s
                device.collectInterval = 3.0F;//设置采集间隔默认值为3.0s
                device.dropTimeDelay = 900F;//设置掉线延时默认值为900s
                device.port = null;//设置COM口默认值为空
                device.baudRate = "9600";//设置波特率默认值为9600
                device.createTime = DateTime.Now;
                device.createBy = "管理员";
                device.updateTime = null;
                device.updateBy = null;

                //3.将device和chennal存入数据库
                if (new DeviceManage().GetById(device.id) == null && new DeviceManage().GetByName(device.deviceName) == null)
                {
                    //存设备配置
                    new DeviceManage().Insert(device);
                    Device device1 = new DeviceManage().GetByName(device.deviceName);
                    //存通道配置
                    for (int i = startChennalId; i <= chennalNum; i++)
                    {
                        Chennal chennal = new Chennal();
                        chennal.deviceID = device1.id;//设备id
                        chennal.sensorID = null;//传感器id默认为空
                        chennal.sensorName = null;//传感器id默认为空
                        chennal.sensorType = null;//传感器类型默认为空
                        chennal.sensorTableName = null;//传感器对应数据库表默认为空
                        chennal.chennalName = device.deviceName + "-CH0" + i;//通道名称
                        chennal.chennalID = i;//通道id
                        chennal.stopWaring = "否";//设置禁止报警标志默认值为否
                        chennal.chennalLabel = null;//设置通道监测项默认值为空
                        chennal.chennalUnit = null;//设置通道单位默认为空
                        chennal.decimalPlaces = 1;//设置通道默认小数位为1位
                        chennal.chennalType = "K";//通道类型默认位K
                        chennal.adjustment = 0F;//设置通道调整默认值位0.0
                        chennal.lowerLimit = 0F;//下限默认0
                        chennal.upperLimit = 100F;//上限默认100
                        chennal.lLowerLimit = -1F;//下下限默认-1
                        chennal.uUpperLimit = 101F;//上上限默认101
                        chennal.smallRange = 0F;//小量程默认0
                        chennal.largeRange = 100F;//大量程默认100
                        chennal.R_WFlag = 0;//读写标志默认0
                        chennal.createBy = "管理员";
                        chennal.createTime = DateTime.Now;
                        chennal.updateBy = null;
                        chennal.updateTime = null;

                        new ChennalManage().Insert(chennal);
                    }
                    //在treeView1中显示
                    DataCollectionForm.dataCollectionForm.treeView1_addNodes(deviceName, chennalNum, startChennalId);
                    this.Close();
                }
                else
                {
                    if (new DeviceManage().GetByName(device.deviceName) != null)
                    {
                        MessageBox.Show("设备名称已被使用！", "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("设备ID已被使用！", "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }
        }

        private bool checkForm(string deviceType, string deviceName, string deviceAddress, string chennalNum, string startChennalId)
        {
            if (deviceType == "")
            {
                MessageBox.Show("请选择设备类型！", "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (deviceName == "")
            {
                MessageBox.Show("请输入设备名称！", "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (deviceAddress == "")
            {
                MessageBox.Show("请输入设备地址！", "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (chennalNum == "")
            {
                MessageBox.Show("请选择通道数量！", "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (startChennalId == "")
            {
                MessageBox.Show("请选择起始通道！", "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //起始通道与通道数之间的关系
            if (chennalNum != "" && startChennalId != "")
            {
                int chennalNum1 = 0;
                int startChennalId1 = 0;
                switch (comboBox2.Text)
                {
                    case "1 通道":
                        chennalNum1 = 1;
                        break;
                    case "2 通道":
                        chennalNum1 = 2;
                        break;
                    case "3 通道":
                        chennalNum1 = 3;
                        break;
                    case "4 通道":
                        chennalNum1 = 4;
                        break;
                    case "5 通道":
                        chennalNum1 = 5;
                        break;
                    case "6 通道":
                        chennalNum1 = 6;
                        break;
                    case "7 通道":
                        chennalNum1 = 7;
                        break;
                    case "8 通道":
                        chennalNum1 = 8;
                        break;
                }
                switch (comboBox3.Text)
                {
                    case "第 1 通道":
                        startChennalId1 = 1;
                        break;
                    case "第 2 通道":
                        startChennalId1 = 2;
                        break;
                    case "第 3 通道":
                        startChennalId1 = 3;
                        break;
                    case "第 4 通道":
                        startChennalId1 = 4;
                        break;
                    case "第 5 通道":
                        startChennalId1 = 5;
                        break;
                    case "第 6 通道":
                        startChennalId1 = 6;
                        break;
                    case "第 7 通道":
                        startChennalId1 = 7;
                        break;
                    case "第 8 通道":
                        startChennalId1 = 8;
                        break;
                }
                if ((8 - startChennalId1 + 1) < chennalNum1)
                {
                    MessageBox.Show("起始通道选择有误！", "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }


    }
}
