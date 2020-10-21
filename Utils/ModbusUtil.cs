using Modbus.Device;
using ModbusRTU_TP1608.Entiry;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
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
        public static  Dictionary<SerialPort, Dictionary<string, RTUDevice>> RTUdevices = new Dictionary<SerialPort, Dictionary<string, RTUDevice>>();
        public static  Dictionary<SerialPort, Dictionary<string, TCPDevice>> TCPdevices = new Dictionary<SerialPort, Dictionary<string, TCPDevice>>();
        public static  Dictionary<SerialPort, Thread> RTUThreads = new Dictionary<SerialPort, Thread>();
    }

}
