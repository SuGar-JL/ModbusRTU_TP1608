using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTU_TP1608
{
    class Common
    {
        /// <summary>
        /// 可用的通信协议
        /// </summary>
        public enum Protocol { NONE, RTU, TCP };
        /// <summary>
        /// 设备状态
        /// </summary>
        public enum DeviceStatus { START, STOP }
        /// <summary>
        /// 设备类型
        /// </summary>
        public static List<string> DeviceType = new List<string>() { "TP1608P-AI-A" };
        /// <summary>
        /// 设备通道数量
        /// </summary>
        public static List<string> DeviceChennalNum = new List<string>() { "1 通道", "2 通道", "3 通道", "4 通道", "5 通道", "6 通道", "7 通道", "8 通道", };
        /// <summary>
        /// 设备起始通道
        /// </summary>
        public static List<string> DeviceStartChennal = new List<string>() { "第 1 通道", "第 2 通道", "第 3 通道", "第 4 通道", "第 5 通道", "第 6 通道", "第 7 通道", "第 8 通道", };
        /// <summary>
        /// 波特率
        /// </summary>
        public static List<string> BaudRate = new List<string>() { "75", "110", "134", "150", "300", "600", "1200", "2400", "4800", "7200", "9600", "14400", "19200", "38400", "57600", "115200", "128000" };
        /// <summary>
        /// 传感器类型与传感器数据所存数据库表的对应关系
        /// </summary>
        public static Dictionary<string, string> SensorTable = new Dictionary<string, string>()
        {
            { "CO","sensor_co"},
            { "CO2","sensor_co2"},
            { "温度","sensor_temp"},

        };
    }
}
