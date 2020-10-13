using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ModbusRTU_TP1608
{
    public partial class UCChennal : UserControl
    {
        public UCChennal()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 自定义事件：点击圈i事件
        /// </summary>
        [Category("点击圈i显示通道信息")]
        public event EventHandler ShowInfo;
        private void uiInfo_Click(object sender, EventArgs e)
        {
            ShowInfo?.Invoke(this, e);
        }
    }
}
