using Modbus.Device;
using ModbusRTU_TP1608.Entiry;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModbusRTU_TP1608.Utils
{
    /// <summary>
    /// 对应一个串口，用于设备进行采集时，记下要用的master和地址，以便轮询
    /// </summary>
    public class ModbusUtil
    {
        public static  Dictionary<SerialPort, Dictionary<string, List<RTUDevice>>> RTUdevices = new Dictionary<SerialPort, Dictionary<string, List<RTUDevice>>>();
        public static Dictionary<SerialPort, Thread> RTUThreads = new Dictionary<SerialPort, Thread>();
        //信号等，用于停止采集时，停止采集线程
        public static Dictionary<SerialPort, bool> RTUSignals = new Dictionary<SerialPort, bool>();




        public static  Dictionary<TcpClient, Dictionary<string, List<TCPDevice>>> TCPdevices = new Dictionary<TcpClient, Dictionary<string, List<TCPDevice>>>();
        public static Dictionary<TcpClient, Thread> TCPThreads = new Dictionary<TcpClient, Thread>();
        public static Dictionary<string, List<F_TitlePage>> F_TitlePages = new Dictionary<string, List<F_TitlePage>>();
        //信号等，用于停止采集时，停止采集线程
        public static Dictionary<TcpClient, bool> TCPSignals = new Dictionary<TcpClient, bool>();



    }

}
