using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modbus.Device;
using System.Net.Sockets;
using System.Threading;
using System.IO.Ports;
using System.Security.Cryptography;
using ModbusRTU_TP1608.Utils;

namespace ModbusRTU_TP1608
{
    public partial class Form1 : Form
    {
        //获得master
        private static IModbusMaster master;
        //串口参数（波特率、。。。。。。）
        private static SerialPort port;
        //写线圈或写寄存器数组
        private bool[] coilsBuffer;
        private ushort[] registerBuffer;
        //功能码
        private string functionCode;
        //参数(分别为站号,起始地址,长度)
        private byte slaveAddress;
        private ushort startAddress;
        private ushort numberOfPoints;
        //串口参数
        //串口名，如：COM1
        private string portName;
        //波特率
        private int baudRate;
        //校验标志，无校验、奇或偶校验
        private Parity parity;
        //数据位
        private int dataBits;
        //停止位
        private StopBits stopBits;

        public Form1()
        {
            //初始化窗体组件
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cmb_portname.SelectedIndex = 0;//窗口里的-串口名
            cmb_baud.SelectedIndex = 5;//窗口里的-波特率
            cmb_parity.SelectedIndex = 2;//窗口里的-校验
            cmb_databBits.SelectedIndex = 1;//窗口里的-数据为
            cmb_stopBits.SelectedIndex = 0;//窗口里的-停止位
        }
        private SerialPort InitSerialPortParameter()
        {
            if (cmb_portname.SelectedIndex < 0 || cmb_baud.SelectedIndex < 0 || cmb_parity.SelectedIndex < 0 || cmb_databBits.SelectedIndex < 0 || cmb_stopBits.SelectedIndex < 0)
            {
                MessageBox.Show("请选择串口参数");
                return null;
            }
            else
            {
                //获取窗口数据
                portName = cmb_portname.SelectedItem.ToString();
                baudRate = int.Parse(cmb_baud.SelectedItem.ToString());
                switch (cmb_parity.SelectedItem.ToString())
                {
                    case "奇":
                        parity = Parity.Odd;
                        break;
                    case "偶":
                        parity = Parity.Even;
                        break;
                    case "无":
                        parity = Parity.None;
                        break;
                    default:
                        break;
                }
                dataBits = int.Parse(cmb_databBits.SelectedItem.ToString());
                switch (cmb_stopBits.SelectedItem.ToString())
                {
                    case "1":
                        stopBits = StopBits.One;
                        break;
                    case "2":
                        stopBits = StopBits.Two;
                        break;
                    default:
                        break;
                }
                port = new SerialPort(portName, baudRate, parity, dataBits, stopBits);
                return port;
            }
        }
        /// <summary>
        /// 读/写
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //初始化串口参数
                InitSerialPortParameter();

                master = ModbusSerialMaster.CreateRtu(port);

                ExecuteFunction();
            }
            catch (Exception)
            {
                MessageBox.Show("初始化异常");
            }
        }

        private async void ExecuteFunction()
        {
            try
            {
                //每次操作是要开启串口 操作完成后需要关闭串口
                //目的是为了slave更换连接是不报错
                if (port.IsOpen == false)
                {
                    port.Open();
                }
                //根据功能码写操作方法
                if (functionCode != null)
                {
                    switch (functionCode)
                    {
                        case "01 Read Coils"://读取单个线圈
                            SetReadParameters();
                            coilsBuffer = master.ReadCoils(slaveAddress, startAddress, numberOfPoints);

                            for (int i = 0; i < coilsBuffer.Length; i++)
                            {
                                SetMsg(coilsBuffer[i] + " ");
                            }
                            SetMsg("\r\n");
                            break;
                        case "02 Read DisCrete Inputs"://读取输入线圈/离散量线圈
                            SetReadParameters();

                            coilsBuffer = master.ReadInputs(slaveAddress, startAddress, numberOfPoints);
                            for (int i = 0; i < coilsBuffer.Length; i++)
                            {
                                SetMsg(coilsBuffer[i] + " ");
                            }
                            SetMsg("\r\n");
                            break;
                        case "03 Read Holding Registers"://读取保持寄存器
                            SetReadParameters();
                            //返回的数据为unshort型，要转为float型
                            registerBuffer = master.ReadHoldingRegisters(slaveAddress, startAddress, numberOfPoints);
                            //原始整数
                            SetMsg("原始整数：\r\n");
                            for (int i = 0; i < registerBuffer.Length; i++)
                            {
                                SetMsg(registerBuffer[i].ToString() + " ");
                            }
                            SetMsg("\r\n");
                            SetMsg("转换为32位Float：\r\n");
                            //ushort[]=>float[]
                            float[] result = DataTypeConvert.GetReal(registerBuffer,0);
                            for (int i = 0; i < result.Length; i++)
                            {
                                SetMsg(result[i].ToString() + " ");
                            }
                            SetMsg("\r\n");
                            SetMsg("连接MySQl测试：\r\n");
                            //测试读数据库
                            MySqlConnect mySqlConnect = new MySqlConnect("root", "root", "car");
                            string SQL = "select * from mycar";
                            DataSet data = mySqlConnect.RunQuery(SQL);
                            for (int i = 0; i < data.Tables.Count; i++)
                            {
                                for (int j = 0; j < data.Tables[i].Rows.Count; j++)
                                {
                                    for (int k = 0; k < data.Tables[i].Columns.Count; k++)
                                    {
                                        Console.Write(data.Tables[i].Rows[j][k] + "\t");
                                        SetMsg(data.Tables[i].Rows[j][k] + "\t");
                                    }
                                    Console.WriteLine();
                                }
                                Console.WriteLine();
                            }
                            SetMsg("\r\n");
                            break;
                        case "04 Read Input Registers"://读取输入寄存器
                            SetReadParameters();
                            registerBuffer = master.ReadInputRegisters(slaveAddress, startAddress, numberOfPoints);
                            for (int i = 0; i < registerBuffer.Length; i++)
                            {
                                SetMsg(registerBuffer[i] + " ");
                            }
                            SetMsg("\r\n");
                            break;
                        case "05 Write Single Coil"://写单个线圈
                            SetWriteParametes();
                            await master.WriteSingleCoilAsync(slaveAddress, startAddress, coilsBuffer[0]);
                            break;
                        case "06 Write Single Registers"://写单个输入线圈/离散量线圈
                            SetWriteParametes();
                            await master.WriteSingleRegisterAsync(slaveAddress, startAddress, registerBuffer[0]);
                            break;
                        case "0F Write Multiple Coils"://写一组线圈
                            SetWriteParametes();
                            await master.WriteMultipleCoilsAsync(slaveAddress, startAddress, coilsBuffer);
                            break;
                        case "10 Write Multiple Registers"://写一组保持寄存器
                            SetWriteParametes();
                            await master.WriteMultipleRegistersAsync(slaveAddress, startAddress, registerBuffer);
                            break;
                        default:
                            break;
                    }

                }
                else
                {
                    MessageBox.Show("请选择功能码!");
                }
                //关闭串口
                port.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 4)
            {
                groupBox2.Enabled = true;
                groupBox1.Enabled = false;
            }
            else
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = false;
            }
            comboBox1.Invoke(new Action(() => { functionCode = comboBox1.SelectedItem.ToString(); }));
        }

        /// <summary>
        /// 初始化读参数
        /// </summary>
        private void SetReadParameters()
        {
            if (txt_startAddr1.Text == "" || txt_slave1.Text == "" || txt_length.Text == "")
            {
                MessageBox.Show("请填写读参数!");
            }
            else
            {
                slaveAddress = byte.Parse(txt_slave1.Text);
                startAddress = ushort.Parse(txt_startAddr1.Text);
                numberOfPoints = ushort.Parse(txt_length.Text);
            }
        }
        /// <summary>
        /// 初始化写参数
        /// </summary>
        private void SetWriteParametes()
        {
            if (txt_startAddr2.Text == "" || txt_slave2.Text == "" || txt_data.Text == "")
            {
                MessageBox.Show("请填写写参数!");
            }
            else
            {
                slaveAddress = byte.Parse(txt_slave2.Text);
                startAddress = ushort.Parse(txt_startAddr2.Text);
                //判断是否写线圈
                if (comboBox1.SelectedIndex == 4 || comboBox1.SelectedIndex == 6)
                {
                    string[] strarr = txt_data.Text.Split(' ');
                    coilsBuffer = new bool[strarr.Length];
                    //转化为bool数组
                    for (int i = 0; i < strarr.Length; i++)
                    {
                        // strarr[i] == "0" ? coilsBuffer[i] = true : coilsBuffer[i] = false;
                        if (strarr[i] == "0")
                        {
                            coilsBuffer[i] = false;
                        }
                        else
                        {
                            coilsBuffer[i] = true;
                        }
                    }
                }
                else
                {
                    //转化ushort数组
                    string[] strarr = txt_data.Text.Split(' ');
                    registerBuffer = new ushort[strarr.Length];
                    for (int i = 0; i < strarr.Length; i++)
                    {
                        registerBuffer[i] = ushort.Parse(strarr[i]);
                    }
                }
            }
        }

        /// <summary>
        /// 清除文本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
        /// <summary>
        /// SetMessage
        /// </summary>
        /// <param name="msg"></param>
        public void SetMsg(string msg)
        {
            richTextBox1.Invoke(new Action(() => { richTextBox1.AppendText(msg); }));
        }

    }
}
