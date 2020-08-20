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
                    this.textBox1.Text = value;
                    break;
                case 2:
                    this.textBox2.Text = value;
                    break;
                case 3:
                    this.textBox3.Text = value;
                    break;
                case 4:
                    this.textBox4.Text = value;
                    break;
                case 5:
                    this.textBox5.Text = value;
                    break;
                case 6:
                    this.textBox6.Text = value;
                    break;
                case 7:
                    this.textBox7.Text = value;
                    break;
                case 8:
                    this.textBox8.Text = value;
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
