using ModbusRTU_TP1608.Entiry.Bluetooth_Gateway;
using Newtonsoft.Json;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModbusRTU_TP1608.Forms.Bluetooth_Gateway
{
    public partial class F_BluetoothGateway : UIPage
    {
        public F_BluetoothGateway()
        {
            InitializeComponent();

            uiDataGridView1.AddColumn("id", "id");
            uiDataGridView1.AddColumn("网关", "网关");
            uiDataGridView1.AddColumn("人数", "人数");
            uiDataGridView1.AddColumn("更新时间", "更新时间");
            uiDataGridView1.ReadOnly = true;
            uiDataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        //蓝牙探针相关
        private Thread My_NET_RevThread;//数据接收线程
        //创建TCP通讯类实例
        TCP_Communication_Func TCP_Communication = new TCP_Communication_Func();

        public class Data
        {
            public int id { get; set; }

            public string 网关 { get; set; }

            public int 人数 { get; set; }

            public DateTime 更新时间 { get; set; }

            public override string ToString()
            {
                return string.Format("{0} {1} {2} {3}", id, 网关, 人数, 更新时间);
            }
        }

        private void uiBtn_ON_OFF_Click(object sender, EventArgs e)
        {
            if ("打开".Equals(this.uiBtn_ON_OFF.Text))
            {
                if (this.uiTB_ip.Text.Trim().Length == 0 || this.uiTB_port.Text.Trim().Length == 0)
                {
                    this.ShowWarningDialog("主机地址和端口请填写完整！");
                    return;
                }
                this.uiTB_ip.Enabled = false;
                this.uiTB_port.Enabled = false;
                this.uiBtn_ON_OFF.Text = "关闭";
                this.uiLight1.State = UILightState.Blink;
                Enable_Flag = true;
                My_NET_RevThread = new Thread(new ThreadStart(Communication_Rev_Thread));
                My_NET_RevThread.IsBackground = true;               //设置为后台线程
                My_NET_RevThread.Start();
            }
            else if("关闭".Equals(this.uiBtn_ON_OFF.Text))
            {
                Enable_Flag = false;
                this.uiLight1.State = UILightState.Off;
                this.uiTB_ip.Enabled = true;
                this.uiTB_port.Enabled = true;
            }

        }

        #region 蓝牙网关
        public bool Enable_Flag = false;
        #region TCP服务端使用的全局变量
        public TcpListener TCP_Server;          //TCP服务端
        public TcpClient TCP_Client_Access;     //接入服务端的TCP客户端
        NetworkStream TCP_Server_NS;           //TCP服务端网络数据流
        #endregion
        private void Communication_Rev_Thread()
        {
            try
            {
                TCP_Server = new TcpListener(new IPEndPoint(IPAddress.Parse(this.uiTB_ip.Text.Trim()), int.Parse(this.uiTB_port.Text.Trim())));
                TCP_Server.Start(); //开始监听客户端请求
                Byte[] Rev_DataStream_Buf = new Byte[8192];
                string Rev_Data_Buf = string.Empty;
                string RevData_Output = string.Empty;
                int RevDataByte_Cnt = 0;
                bool Rev_Data_Format = true;
                TCP_Client_Access = TCP_Server.AcceptTcpClient();
                TCP_Server_NS = TCP_Client_Access.GetStream();
                RevData_Output = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "]" + "接收" + "来自"
                            + (TCP_Client_Access.Client.RemoteEndPoint as IPEndPoint).Address.ToString() + ":" +
                            (TCP_Client_Access.Client.RemoteEndPoint as IPEndPoint).Port.ToString() + ">"
                            + "有客户端请求连接，连接已建立！" + "\n" + "\n";
                RevData_Output = string.Empty;
                while (Enable_Flag)
                {
                    Thread.Sleep(10); // 在死循环中一定要然线程休眠，不然电脑CPU占用率很高，会造成电脑系统卡死
                    if (RevData_Output == string.Empty)
                    {
                        int Rev_Byte_Cnt = 0;
                        Rev_Byte_Cnt = TCP_Server_NS.Read(Rev_DataStream_Buf, 0, Rev_DataStream_Buf.Length);
                        if (Rev_Byte_Cnt == 0)  //当收到服务端断开时退出循环体
                        {
                            RevData_Output = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "]" + "接收" + "来自"
                            + (TCP_Client_Access.Client.RemoteEndPoint as IPEndPoint).Address.ToString() + ":" +
                            (TCP_Client_Access.Client.RemoteEndPoint as IPEndPoint).Port.ToString() + ">"
                            + "客户端已退出连接！" + "\n" + "\n";
                            RevData_Output = string.Empty;

                            break;
                        }
                        RevDataByte_Cnt = RevDataByte_Cnt + Rev_Byte_Cnt;
                        string Message_Format = "";
                        if (Rev_Data_Format)
                        {
                            Rev_Data_Buf = this.CharToGB2312(Rev_DataStream_Buf, 0, Rev_Byte_Cnt);
                            Message_Format = "ASCII码";
                        }
                        else
                        {
                            Rev_Data_Buf = this.CharToHexString(Rev_DataStream_Buf, Rev_Byte_Cnt);
                            Message_Format = "十六进制码";
                        }

                        RevData_Output = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "]" + "接收" + Message_Format + "来自"
                        + (TCP_Client_Access.Client.RemoteEndPoint as IPEndPoint).Address.ToString() + ":" +
                        (TCP_Client_Access.Client.RemoteEndPoint as IPEndPoint).Port.ToString() + ">\n"
                        + Rev_Data_Buf + "\n";
                        RevData_Output = string.Empty;
                        if (Rev_Data_Buf.Contains("Gateway") && !Rev_Data_Buf.Contains("restart"))
                        {
                            BluetoothGateway JsonOut = JsonConvert.DeserializeObject<BluetoothGateway>(Rev_Data_Buf);
                            List<string> addrs = new List<string>();
                            for (int i = 0; i < JsonOut.online.Length; i++)
                            {
                                addrs.Add(JsonOut.online[i].addr);
                            }
                            string[] temp = addrs.Distinct().ToArray();
                            List<Data> datas = new List<Data>();
                            Data data = new Data();
                            data.id = 1;
                            data.网关 = JsonOut.Gateway;
                            data.人数 = temp.Length;
                            data.更新时间 = DateTime.Now;
                            datas.Add(data);
                            if (this.uiPagination1.InvokeRequired)
                            {
                                Action<List<Data>> actionDelegate = (arg_datas) =>
                                {
                                    this.uiPagination1.DataSource = arg_datas;
                                    this.uiPagination1.ActivePage = 1;
                                    uiDataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                                };
                                this.uiPagination1.Invoke(actionDelegate, datas);
                            }
                            Area_People_Num area_People_Num = new Area_People_Num();
                            area_People_Num.Gateway = JsonOut.Gateway;
                            area_People_Num.NodeId = JsonOut.NodeId;
                            area_People_Num.SystemId = JsonOut.SystemId;
                            area_People_Num.Type = JsonOut.Type;
                            area_People_Num.Num_people = temp.Length;
                            new GatewayManager().InsertOrUpdate(area_People_Num);
                        }
                    }

                }

                TCP_Client_Access.Close();
                TCP_Server.Stop();
                TCP_Server_NS.Close();
            }
            catch (Exception e)
            {

                if (TCP_Client_Access != null)
                {
                    TCP_Client_Access.Close();
                }
                TCP_Server.Stop();
                if (TCP_Server_NS != null)
                {
                    TCP_Server_NS.Close();
                }
            }
        }
        #endregion


        #region 数据格式转换方法
        public string CharToGB2312(byte[] Target_DataBuf, int First_Index, int Target_ByteCnt)
        {
            string Resule_Data = "";
            Resule_Data = Encoding.GetEncoding("gb2312").GetString(Target_DataBuf, First_Index, Target_ByteCnt);
            return Resule_Data;
        }

        public string CharToHexString(byte[] Target_Bytes, int Target_ByteCnt)
        {
            string Resule_Data = "";
            for (int i = 0; i < Target_ByteCnt; i++)
            {
                Resule_Data = Resule_Data + String.Format("{0:X2} ", Target_Bytes[i]);
            }
            return Resule_Data;
        }

        public byte[] GB2312ToChar(string Target_String)
        {
            byte[] Result_Byte_Stream = Encoding.GetEncoding("gb2312").GetBytes(Target_String);

            return Result_Byte_Stream;
        }

        public byte[] HexStringToChar(string Target_HexString)
        {
            string Target_HexString_Buf = Target_HexString.Replace(" ", "");
            string Target_HexString_Buf_Even = "";

            if ((Target_HexString_Buf.Length % 2) > 0)
            {
                Target_HexString_Buf_Even = Target_HexString_Buf.Insert(Target_HexString_Buf.Length - 1, "0");
            }
            else
            {

                Target_HexString_Buf_Even = Target_HexString_Buf;
            }


            byte[] Byte_Stream_Buf = new byte[(int)Target_HexString_Buf_Even.Length / 2];
            for (int i = 0, j = 0; j <= Target_HexString_Buf_Even.Length - 2; j = j + 2, i++)
            {
                Byte_Stream_Buf[i] = Convert.ToByte(Target_HexString_Buf_Even.Substring(j, 2), 16);

            }
            return Byte_Stream_Buf;
        }
        #endregion

        private void uiPagination1_PageChanged(object sender, object pagingSource, int pageIndex, int count)
        {
            this.uiDataGridView1.DataSource = pagingSource;
        }
    }
}
