using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModbusRTU_TP1608.Entiry.Bluetooth_Gateway
{
    class TCP_Communication_Func
    {
        #region 全局变量

        #region TCP服务端使用的全局变量
        public TcpListener TCP_Server;          //TCP服务端
        public TcpClient TCP_Client_Access;     //接入服务端的TCP客户端
        NetworkStream TCP_Server_NWS;           //TCP服务端网络数据流
        #endregion

        #endregion

        #region TCP服务端接收消息

        public void TCP_Server_RevMessage_Func(string Local_ServerIP, int Local_ServerPort, bool Enable_Flag)
        {

            TCP_Server = new TcpListener(new IPEndPoint(IPAddress.Parse(Local_ServerIP), Local_ServerPort));
            TCP_Server.Start(); //开始监听客户端请求
            Byte[] Rev_DataStream_Buf = new Byte[8192];
            string Rev_Data_Buf = string.Empty;
            string RevData_Output = string.Empty;
            int RevDataByte_Cnt = 0;
            bool Rev_Data_Format = true;
            try
            {
                TCP_Client_Access = TCP_Server.AcceptTcpClient();

                TCP_Server_NWS = TCP_Client_Access.GetStream();

                RevData_Output = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "]" + "接收" + "来自"
                            + (TCP_Client_Access.Client.RemoteEndPoint as IPEndPoint).Address.ToString() + ":" +
                            (TCP_Client_Access.Client.RemoteEndPoint as IPEndPoint).Port.ToString() + ">"
                            + "有客户端请求连接，连接已建立！" + "\n" + "\n";
                RevData_Output = string.Empty;
                while (Enable_Flag)
                {
                    Thread.Sleep(1000); // 在死循环中一定要然线程休眠，不然电脑CPU占用率很高，会造成电脑系统卡死
                    if (RevData_Output == string.Empty)
                    {
                        int Rev_Byte_Cnt = 0;
                        Rev_Byte_Cnt = TCP_Server_NWS.Read(Rev_DataStream_Buf, 0, Rev_DataStream_Buf.Length);
                        if (Rev_Byte_Cnt == 0)  //当收到服务端断开时推出循环体
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
                            BluetoothGateway BGs = JsonConvert.DeserializeObject<BluetoothGateway>(Rev_Data_Buf);

                            //for (int i = 0; i < BGs.Length; i++)
                            //{
                            List<string> addrs = new List<string>();
                            for (int j = 0; j < BGs.online.Length; j++)
                            {
                                addrs.Add(BGs.online[j].addr);
                            }
                            //去重
                            //List<string> temp = new List<string>();
                            //for (int j = 0; j < addrs.Count; j++)
                            //{
                            //    if (temp.Contains(addrs[j]))
                            //    {
                            //        continue;
                            //    }
                            //    temp.Add(addrs[j]);
                            //}
                            string[] temp = addrs.Distinct().ToArray();
                            Area_People_Num area_People_Num = new Area_People_Num();
                            area_People_Num.Gateway = BGs.Gateway;
                            area_People_Num.NodeId = BGs.NodeId;
                            area_People_Num.SystemId = BGs.SystemId;
                            area_People_Num.Type = BGs.Type;
                            area_People_Num.Num_people = temp.Length;
                            new GatewayManager().InsertOrUpdate(area_People_Num);
                            //}
                        }
                    }

                }

                TCP_Client_Access.Close();
                TCP_Server.Stop();
                TCP_Server_NWS.Close();
            }
            catch (Exception e)
            {
                if (TCP_Client_Access != null)
                {
                    TCP_Client_Access.Close();
                }
                TCP_Server.Stop();
                if (TCP_Server_NWS != null)
                {
                    TCP_Server_NWS.Close();
                }
            }

        }

        #endregion

        #region TCP服务端发送消息

        public void TCP_Server_SendMessage_Func(string Send_Data,           //发送的数据
                                                    ref string Send_Data_Output,//发送的数据输出
                                                    ref int SendDataSucceed_Cnt,//发送成功字节数
                                                    bool Send_Data_Format       //发送数据格式
                                               )
        {
            if (Send_Data_Output == string.Empty)
            {
                Byte[] Send_Data_Buf;
                string Message_Format = "";
                if (Send_Data_Format)   //Send_Data_Format -> true:为ASCII码；false:为十六进制码
                {

                    Send_Data_Buf = this.GB2312ToChar(Send_Data);
                    Message_Format = "ASCII码";
                }
                else
                {
                    Send_Data_Buf = this.HexStringToChar(Send_Data);
                    Message_Format = "十六进制码";
                }


                TCP_Server_NWS.Write(Send_Data_Buf, 0, Send_Data_Buf.Length);

                Send_Data_Output = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "]" + "发送" + Message_Format + "去往"
                        + (TCP_Client_Access.Client.RemoteEndPoint as IPEndPoint).Address.ToString()
                        + ":" + (TCP_Client_Access.Client.RemoteEndPoint as IPEndPoint).Port.ToString() + ">\n"
                        + Send_Data + "\n" + "\n";
                SendDataSucceed_Cnt = SendDataSucceed_Cnt + Send_Data_Buf.Length;

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
    }
}
