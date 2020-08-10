using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTU_TP1608.Entiry
{
    class Device
    {
        //设备类型
        public string deviceType { get; set; }
        //设备名称
        public string deviceName { get; set; }
        //设备地址
        public string deviceAddress { get; set; }
        //设备ID
        public string deviceID { get; set; }
        //设备通道数
        public int chennalNum { get; set; }
        //起始通道
        public int startChennal { get; set; }
        //保存间隔
        public float storeInterval { get; set; }
        //采集间隔
        public float collectInterval { get; set; }
        //掉线延时
        public float dropTimeDelay { get; set; }
        //COM口
        public string port { get; set; }
        //波特率
        public string baudRate { get; set; }
    }
}
