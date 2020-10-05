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
    public partial class F_Verify : UIEditForm
    {
        public F_Verify()
        {
            InitializeComponent();
        }

        private string desc
        {
            get
            {
                return this.desc;
            }
            set
            {
                this.desc = value;
            }
        }
    }
}
