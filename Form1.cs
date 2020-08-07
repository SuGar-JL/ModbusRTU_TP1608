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
        #region 属性
        //获得master
        private static IModbusMaster master;
        //串口
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
        

        #endregion
        public Form1()
        {
            //初始化窗体组件
            InitializeComponent();
        }

        //窗体刚打开时的状态
        private void Form1_Load(object sender, EventArgs e)
        {
            cmb_portname.SelectedIndex = 0;//窗口里的-串口选择框
            cmb_baud.SelectedIndex = 5;//窗口里的-波特率选择框
            cmb_parity.SelectedIndex = 2;//窗口里的-校验选择框
            cmb_databBits.SelectedIndex = 1;//窗口里的-数据位选择框
            cmb_stopBits.SelectedIndex = 0;//窗口里的-停止位选择框
        }
        //点击read/write按钮
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //初始化串口参数
                InitSerialPortParameter();
                //master实例化
                master = ModbusSerialMaster.CreateRtu(port);
                //根据功能号执行(多线程)
                Thread thread = new Thread(new ThreadStart(ExecuteFunction));
                thread.Start(); //无参和返回值的多线程 
            }
            catch (Exception)
            {
                MessageBox.Show("初始化异常");
            }

        }


        //初始化串口参数的方法
        private SerialPort InitSerialPortParameter()
        {
            if (cmb_portname.SelectedIndex < 0 || cmb_baud.SelectedIndex < 0 || cmb_parity.SelectedIndex < 0 || cmb_databBits.SelectedIndex < 0 || cmb_stopBits.SelectedIndex < 0)
            {
                MessageBox.Show("请选择串口参数");
                return null;
            }
            else
            {
                //获取窗口串口参数
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
                //这个是属性里的那个
                port = new SerialPort(portName, baudRate, parity, dataBits, stopBits);
                return port;
            }
        }

        //对应每个功能号进行操作
        private async void ExecuteFunction()
        {
            while (true)
            {
                try
                {
                    //每次操作是要开启串口 操作完成后需要关闭串口
                    //目的是为了slave更换连接时不报错
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
                                //创建MySQL连接对象
                                MySqlConnect mySqlConnect = new MySqlConnect();
                                SetReadParameters();
                                //返回的数据为unshort型，要转为float型
                                registerBuffer = master.ReadHoldingRegisters(slaveAddress, startAddress, numberOfPoints);
                                SetMsg("时间：" + DateTime.Now.ToString() + "\r\n");
                                //原始整数
                                SetMsg("原始整数：\r\n");
                                for (int i = 0; i < registerBuffer.Length; i++)
                                {
                                    SetMsg(registerBuffer[i].ToString() + " ");
                                }
                                SetMsg("\r\n");
                                SetMsg("转换为32位Float：\r\n");
                                //ushort[]=>float[]
                                float[] result = DataTypeConvert.GetReal(registerBuffer, 0);
                                for (int i = 0; i < result.Length; i++)
                                {
                                    SetMsg(result[i].ToString() + " ");
                                }
                                SetMsg("\r\n");
                                #region 将数据存入数据库
                                //DateTime created_time;
                                //string created_by = "苏金领";
                                //DateTime updated_time;
                                //string updated_by = "苏金领";
                                /*string SQL = "insert into test2 (ch1,ch2,ch3,ch4,ch5,ch6,ch7,ch8) values (" +
                                    result[0].ToString() + "," + result[1].ToString() + "," +
                                    result[2].ToString() + "," + result[3].ToString() + "," +
                                    result[4].ToString() + "," + result[5].ToString() + "," +
                                    result[6].ToString() + "," + result[7].ToString() + ")";*/
                                string SQL = "update test2 set ch1 = " + result[0].ToString() + ", ch2 = " + result[1].ToString() +
                                    ", ch3 = " + result[2].ToString() + ", ch4 = " + result[3].ToString() + ", ch5 = " + result[4].ToString() + 
                                    ", ch6 = " + result[5].ToString() + ", ch7 = " + result[6].ToString() + ", ch8 = " + result[7].ToString() + 
                                    "where id = 1";
                                int status = mySqlConnect.RunNotQuery(SQL);
                                SetMsg("存储成功否？：" + status + "\r\n");
                                #endregion
                                #region MySQL连接测试（读数据库）
                                SetMsg("连接MySQl测试：\r\n");
                                //测试读数据库

                                string SQL1 = "select * from test2";
                                DataSet data = mySqlConnect.RunQuery(SQL1);
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
                                #endregion
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
                //会由间隔4秒的时候，为啥呢？？？？？？？？？？？？？
                //Thread.CurrentThread.Join(3000);//方法间隔3s执行一次(阻止调用线程，直到某个线程终止时为止)
                Thread.Sleep(3000);//线程休眠3s
            }

        }
        //
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


        //初始化读参数
        private void SetReadParameters()
        {
            if (txt_startAddr1.Text == "" || txt_slave1.Text == "" || txt_length.Text == "")
            {
                MessageBox.Show("请填写读参数!");//一个弹窗
            }
            else
            {
                slaveAddress = byte.Parse(txt_slave1.Text);
                startAddress = ushort.Parse(txt_startAddr1.Text);
                numberOfPoints = ushort.Parse(txt_length.Text);
            }
        }

        //初始化写参数
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

        //清除文本
        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        //SetMessage
        public void SetMsg(string msg)
        {
            richTextBox1.Invoke(new Action(() => { richTextBox1.AppendText(msg); }));
        }

    }
}
