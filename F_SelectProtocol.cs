using ModbusRTU_TP1608.Entiry;
using ModbusRTU_TP1608.Utils;
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
    public partial class F_SelectProtocol : UIEditForm
    {
        public F_SelectProtocol()
        {
            InitializeComponent();
        }

        private void F_SelectProtocol_Load(object sender, EventArgs e)
        {
            Sys sys = new SysManage().GetSysInfo()[0];
            if (sys.protocol == 0)
            {
                this.RTU.Checked = false;
                this.TCP.Checked = false;
            }
            else if (sys.protocol == 1)
            {
                this.RTU.Checked = true;
                this.TCP.Checked = false;
            }
            else if (sys.protocol == 2)
            {
                this.RTU.Checked = false;
                this.TCP.Checked = true;
            }
        }
        protected override bool CheckData()
        {
            if (this.RTU.Checked == false && this.TCP.Checked == false)
            {
                this.ShowWarningDialog("需选择一个通信协议才能使用系统");
                return false;
            }
            return true;
        }
    }
}
