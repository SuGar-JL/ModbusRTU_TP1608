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

    public partial class SetDeviceForm : Form
    {
        //public static SetDeviceForm setDeviceForm;
        public Device device;
        public SetDeviceForm()
        {
            InitializeComponent();
            textBox1.Text = DeviceManageForm.deviceName;
            device = new DeviceManage().GetByName(textBox1.Text.Trim());
            textBox2.Text = device.id.ToString(); ;
            textBox3.Text = device.storeInterval.ToString();
            textBox4.Text = device.collectInterval.ToString();
            textBox5.Text = device.deviceAddress;
            textBox6.Text = device.deviceType;
            textBox7.Text = device.startChennal.ToString();
            textBox8.Text = device.dropTimeDelay.ToString();
            comboBox1.Text = device.port;
            comboBox2.Text = device.baudRate;

            //初始化可用的串口号
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkForm(textBox1.Text.Trim(), textBox3.Text.Trim(), textBox4.Text.Trim(), textBox8.Text.Trim()))//填写无误，且改了名称不重复
            {
                if (textBox1.Text.Trim().Equals(device.deviceName)&&textBox3.Text.Trim().Equals(device.storeInterval.ToString())&& textBox4.Text.Trim().Equals(device.collectInterval.ToString())&& textBox8.Text.Trim().Equals(device.dropTimeDelay.ToString())&& comboBox1.Text.Trim().Equals(device.port)&&comboBox2.Text.Trim().Equals(device.baudRate))
                {
                    //没做任何更改，直接关闭即可（还有COM口没判断，之后添加）
                    this.Close();
                }
                else
                {
                    double num;
                    string deviceName = textBox1.Text.Trim();//设备名称
                    //字符串转double
                    double.TryParse(textBox3.Text.Trim(), System.Globalization.NumberStyles.Float, System.Globalization.NumberFormatInfo.InvariantInfo, out num);
                    double storeInterval = num;//保存间隔
                    double.TryParse(textBox4.Text.Trim(), System.Globalization.NumberStyles.Float, System.Globalization.NumberFormatInfo.InvariantInfo, out num);
                    double collectInterval = num;//采集间隔
                    double.TryParse(textBox8.Text.Trim(), System.Globalization.NumberStyles.Float, System.Globalization.NumberFormatInfo.InvariantInfo, out num);
                    double dropTimeDelay = num;//掉线时延
                    string port = comboBox1.Text.Trim();
                    string baudRate = comboBox2.Text.Trim();
                    string updateBy = "SuGar";
                    DateTime updateTime = DateTime.Now;
                    //更新设备以上字段
                    new DeviceManage().UpdateConfigById(device.id, deviceName, storeInterval, collectInterval, dropTimeDelay, port, baudRate, updateBy, updateTime);
                    //更新设备配置树treeView1的相应节点（这方法相当于从数据库获取刷新一遍）
                    DeviceManageForm.deviceManageForm.treeView1_InitFromDB();
                    this.Close();
                }
            }
            //之后该有COM口不可用的情况

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool checkForm(string deviceName, string storeInterval, string collectInterval, string dropTimeDelay)
        {
            double num;
            if (deviceName == "")
            {
                MessageBox.Show("请输入设备名称！", "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (storeInterval == "" || double.TryParse(storeInterval, System.Globalization.NumberStyles.Float, System.Globalization.NumberFormatInfo.InvariantInfo, out num) == false)//没输入或输入不是数字
            {
                MessageBox.Show("保存间隔输入有误！", "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (collectInterval == "" || double.TryParse(collectInterval, System.Globalization.NumberStyles.Float, System.Globalization.NumberFormatInfo.InvariantInfo, out num) == false)//没输入或输入不是数字
            {
                MessageBox.Show("采集间隔输入有误！", "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (dropTimeDelay == "" || double.TryParse(dropTimeDelay, System.Globalization.NumberStyles.Float, System.Globalization.NumberFormatInfo.InvariantInfo, out num) == false)//没输入或输入不是数字
            {
                MessageBox.Show("掉线延时输入有误！", "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!device.deviceName.Equals(textBox1.Text.Trim()) && new DeviceManage().GetByName(textBox1.Text.Trim()) != null)
            {
                MessageBox.Show("设备名称已被使用！", "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
