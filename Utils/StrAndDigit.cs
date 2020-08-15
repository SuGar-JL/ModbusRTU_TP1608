using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTU_TP1608.Utils
{
    class StrAndDigit
    {
        /// <summary>
        /// 判断字符串是不是小数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool isDigit(string str)
        {
            char[] chars = str.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                //不是数字或数字加.组合
                if ((chars[i] < '0' || chars[i] > '9') && chars[i] != '.')
                {
                    return false;
                }
            }
            return true;
        }

        //public static float toFloat(string str)
        //{
        //    char[] chars = str.ToCharArray();
        //    if (str.Contains('.'))
        //    {
        //        int idx = str.IndexOf('.');
        //        //先处理整数部分
        //        for (int i = 0; i < idx; i++)
        //        {

        //        }
        //    }
        //}
    }
}
