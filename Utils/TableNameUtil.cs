using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTU_TP1608.Utils
{
    class TableNameUtil
    {
        public static string GetTableNameByType(int type)
        {
            switch (type)
            {
                case 0:
                    return "co2_sensor";
                case 1:
                    return "pm10_sensor";
                default:
                    return "";
            }
        }
    }
}
