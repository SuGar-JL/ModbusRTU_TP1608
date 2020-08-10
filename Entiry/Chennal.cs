using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTU_TP1608.Entiry
{
    class Chennal
    {
        //附属于设备的id
        public int deviceID { get; set; }
        //通道名称
        public string chennalName { get; set; }
        //通道ID
        public string chennalID { get; set; }
        //禁止报警
        public int stopWaring { get; set; }
        //颜色
        public string chennalColor { get; set; }
        //单位
        public string chennalUnit { get; set; }
        //小数位
        public int decimalPlaces { get; set; }
        //类型
        public string chennalType { get; set; }
        //调整
        public string adjustment { get; set; }
        //下限
        public string lowerLimit { get; set; }
        //上限
        public string upperLimit { get; set; }
        //下下限
        public string lLowerLimit { get; set; }
        //上上限
        public string uUpperLimit { get; set; }
        //小量程
        public string smallRange { get; set; }
        //大量程
        public string largeRange { get; set; }
        //读或写
        public string R_WFlag { get; set; }


    }
}
