using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModbusRTU_TP1608
{
    public partial class test : UIHeaderAsideMainFrame
    {
        public test()
        {
            InitializeComponent();

            //设置关联
            Aside.TabControl = MainTabControl;

            //增加页面到Main
            AddPage(new F_TitlePage(), 1001);
            AddPage(new F_TitlePage(), 1002);
            AddPage(new F_TitlePage(), 1003);

            //设置Header节点索引
            Aside.CreateNode("Page1", 1001);
            Aside.CreateNode("Page2", 1002);
            Aside.CreateNode("Page3", 1003);

            //显示默认界面
            Aside.SelectFirst();
        }
    }
}
