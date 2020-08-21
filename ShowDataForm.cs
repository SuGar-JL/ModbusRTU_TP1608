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

        public void SetTextBox1(string value)
        {
            this.textBox1.Invoke(new Action(() => { this.textBox1.Text = value; }));
        }
        public void SetTextBox2(string value)
        {
            this.textBox2.Invoke(new Action(() => { this.textBox2.Text = value; }));
        }
        public void SetTextBox3(string value)
        {
            this.textBox3.Invoke(new Action(() => { this.textBox3.Text = value; }));
        }
        public void SetTextBox4(string value)
        {
            this.textBox4.Invoke(new Action(() => { this.textBox4.Text = value; }));
        }
        public void SetTextBox5(string value)
        {
            this.textBox5.Invoke(new Action(() => { this.textBox5.Text = value; }));
        }
        public void SetTextBox6(string value)
        {
            this.textBox6.Invoke(new Action(() => { this.textBox6.Text = value; }));
        }
        public void SetTextBox7(string value)
        {
            this.textBox7.Invoke(new Action(() => { this.textBox7.Text = value; }));
        }
        public void SetTextBox8(string value)
        {
            this.textBox8.Invoke(new Action(() => { this.textBox8.Text = value; }));
        }

        public void SetTextBox_time(string value)
        {
            this.textBox_time.Invoke(new Action(() => { this.textBox_time.Text = value; }));
        }
    }
}
