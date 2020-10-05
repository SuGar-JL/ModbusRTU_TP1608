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
    public partial class F_ChennalInfo : UIEditForm
    {
        public F_ChennalInfo()
        {
            InitializeComponent();
        }

        private void chennalUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.chennalSensorRangeUnit.Text = this.chennalUnit.Text.Trim();
            this.chennalWarning1Unit.Text = this.chennalUnit.Text.Trim();
            this.chennalWarning2Unit.Text = this.chennalUnit.Text.Trim();
            this.chennalWarning3Unit.Text = this.chennalUnit.Text.Trim();
        }
    }
}
