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
        public DataCollectionForm dataCollectionForm = new DataCollectionForm();
        public ShowDataForm()
        {
            InitializeComponent();
            dataCollectionForm.setCallBack = new DataCollectionForm.setTextValueCallBack(SetValue);
        }
        public void SetValue(int i, string value)
        {
            switch (i)
            {
                case 1:
                    this.textBox1.Invoke(new Action(() => { textBox1.Text = value; }));
                    break;
                case 2:
                    this.textBox2.Invoke(new Action(() => { textBox2.Text = value; }));
                    break;
                case 3:
                    this.textBox3.Invoke(new Action(() => { textBox3.Text = value; }));
                    break;
                case 4:
                    this.textBox4.Invoke(new Action(() => { textBox4.Text = value; }));
                    break;
                case 5:
                    this.textBox5.Invoke(new Action(() => { textBox5.Text = value; }));
                    break;
                case 6:
                    this.textBox6.Invoke(new Action(() => { textBox6.Text = value; }));
                    break;
                case 7:
                    this.textBox7.Invoke(new Action(() => { textBox7.Text = value; }));
                    break;
                case 8:
                    this.textBox8.Invoke(new Action(() => { textBox8.Text = value; }));
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
