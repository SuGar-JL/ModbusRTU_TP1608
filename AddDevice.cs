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
    public partial class AddDevice : Form
    {
        public AddDevice()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //点击确定，检查表单是否有空值
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkForm(comboBox1.Text, textBox1.Text,textBox2.Text,comboBox2.Text,comboBox3.Text))
            {
                string deviceType = comboBox1.Text;
                string deviceName = textBox1.Text;
                string deviceAddress = textBox2.Text;
                int chennalNum = 0;
                int startChennalId = 0;
                switch (comboBox2.Text)
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
                switch (comboBox3.Text)
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

                DeviceManage.deviceManage.treeView1_addNodes(deviceName, chennalNum, startChennalId);
                this.Close();
            }
        }

        private bool checkForm(string deviceType, string deviceName, string deviceAddress, string chennalNum, string startChennalId)
        {
            if (deviceType == "")
            {
                MessageBox.Show("请选择设备类型！", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (deviceName == "")
            {
                MessageBox.Show("请输入设备名称！", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (deviceAddress == "")
            {
                MessageBox.Show("请输入设备地址！", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (chennalNum == "")
            {
                MessageBox.Show("请选择通道数量！", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (startChennalId == "")
            {
                MessageBox.Show("请选择起始通道！", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
