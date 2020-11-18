using ModbusRTU_TP1608.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModbusRTU_TP1608
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //读取log4net配置信息
            log4net.Config.XmlConfigurator.Configure();
            Application.EnableVisualStyles();//将操作系统样式应用于您的应用程序
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new test());
            Application.Run(new Form1());
        }
    }
}
