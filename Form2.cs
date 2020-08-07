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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            // 最右边
            Form3 f3 = new Form3();
            f3.TopLevel = false;
            splitContainer1.Panel2.Controls.Add(f3);
            f3.Show();
            f3.Dock = DockStyle.Fill;

            // 左上
            Form4 f4 = new Form4();
            f4.TopLevel = false;
            splitContainer2.Panel1.Controls.Add(f4);
            f4.Show();
            f4.Dock = DockStyle.Fill;

            // 左下    
            Form5 f5 = new Form5();
            f5.TopLevel = false;
            splitContainer2.Panel2.Controls.Add(f5);
            f5.Show();
            f5.Dock = DockStyle.Fill;
        }
    }
}
