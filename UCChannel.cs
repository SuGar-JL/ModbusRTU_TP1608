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
    public partial class UCChannel : UserControl
    {
        public UCChannel()
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

        /// <summary>
        /// 自定义事件：点击除了圈i的地方
        /// </summary>
        [Category("点击除了圈i的地方")]
        public event EventHandler ControlClick;
        private void uiChannelName_Click(object sender, EventArgs e)
        {
            ControlClick?.Invoke(this, e);
        }

        private void uiChannelData_Click(object sender, EventArgs e)
        {
            ControlClick?.Invoke(this, e);
        }

        private void uiChannelUnit_Click(object sender, EventArgs e)
        {
            ControlClick?.Invoke(this, e);
        }

        private void uiChannelTime_Click(object sender, EventArgs e)
        {
            ControlClick?.Invoke(this, e);
        }

        private void uiPanel_Click(object sender, EventArgs e)
        {
            ControlClick?.Invoke(this, e);
        }
    }
}
