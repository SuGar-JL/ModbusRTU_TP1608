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
        private List<F_TitlePage> f_TitlePages = new List<F_TitlePage>();
        public test()
        {
            InitializeComponent();

            //获取窗体的宽和高

            //设置关联
            Aside.TabControl = MainTabControl;

            //增加页面到Main
            var page1 = new F_TitlePage();
            page1.tB_DeviceName.Text = "数据采集1";
            AddPage(page1, 1001);
            //设置Header节点索引
            Aside.CreateNode(page1.tB_DeviceName.Text, 1001);
            f_TitlePages.Add(page1);

            //增加页面到Main
            var page2 = new F_TitlePage();
            page2.tB_DeviceName.Text = "数据采集2";
            AddPage(page2, 1002);
            //设置Header节点索引
            Aside.CreateNode(page2.tB_DeviceName.Text, 1002);
            f_TitlePages.Add(page2);

            //增加页面到Main
            var page3 = new F_TitlePage();
            page3.tB_DeviceName.Text = "数据采集3";
            AddPage(page3, 1003);
            //设置Header节点索引
            Aside.CreateNode(page3.tB_DeviceName.Text, 1003);
            f_TitlePages.Add(page3);

            //显示默认界面(第一个)
            Aside.SelectFirst();
        }
        
    }
}
