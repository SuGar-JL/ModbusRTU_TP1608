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
    public partial class ShowDataForm : Form
    {
        public static ShowDataForm showDataForm;
        public ShowDataForm()
        {
            InitializeComponent();
            showDataForm = this;
        }
        public void SetValue(int i, string value)
        {
            switch (i)
            {
                case 1:
                    textBox1.Text = value;
                    break;
                case 2:
                    textBox1.Text = value;
                    break;
                case 3:
                    textBox3.Text = value;
                    break;
                case 4:
                    textBox4.Text = value;
                    break;
                case 5:
                    textBox5.Text = value;
                    break;
                case 6:
                    textBox6.Text = value;
                    break;
                case 7:
                    textBox7.Text = value;
                    break;
                case 8:
                    textBox8.Text = value;
                    break;
            }
        }


        public void SetAllTextBoxText(string value)
        {
            textBox1.Text = value;
            textBox2.Text = value;
            textBox3.Text = value;
            textBox4.Text = value;
            textBox5.Text = value;
            textBox6.Text = value;
            textBox7.Text = value;
            textBox8.Text = value;
        }
    }
}
