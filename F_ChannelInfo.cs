using ModbusRTU_TP1608.Entiry;
using ModbusRTU_TP1608.Utils;
using ModbusTCP_TP1608.Entiry;
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
    public partial class F_ChannelInfo : UIEditForm
    {
        //获取系统当前的协议
        private int protocol = new SysManage().GetSysInfo()[0].protocol;
        public RTUChannel rTUChannel = new RTUChannel();
        public TCPChannel tCPChannel = new TCPChannel();
        public F_ChannelInfo()
        {
            InitializeComponent();
        }

        protected override bool CheckData()
        {
            return CheckEmpty(ChannelName, "请输入通道名称")
                   && CheckChannelName(ChannelName, "通道名称重复")
                   && CheckEmpty(ChannelLabel, "请输入监测项")
                   && CheckEmpty(ChannelUnit, "请选择监测单位")
                   && CheckEmpty(ChannelSensorType, "请选择传感器类型")
                   && CheckEmpty(ChannelSensorName, "请输入传感器名称")
                   //&& CheckEmpty(ChannelSensorId, "请输入传感器id")
                   && CheckSensorId(ChannelSensorId, "传感器id重复")
                   && CheckEmpty(ChannelDecimalPlaces, "请选择小数位")
                   && CheckEmpty(ChannelSensorRangeL, "传感器量程需填完整")
                   && CheckEmpty(ChannelSensorRangeH, "传感器量程需填完整")
                   && CheckSensorRange(ChannelSensorRangeL, ChannelSensorRangeH, "传感器量程不合理")
                   && CheckEmpty(ChannelSaveInterval, "请输入保存间隔")
                   && CheckWarning(isWraning, ChannelWarning1L, ChannelWarning1H, ChannelWarning2L, ChannelWarning2H, ChannelWarning3L, ChannelWarning3H)
                   && CheckEmpty(ChannelType, "请选择通道类型");
        }

        private bool CheckChannelName(UITextBox ChannelName, string desc)
        {
            bool result = false;
            if (protocol == (int)Common.Protocol.RTU)
            {
                if (ChannelName.Text.Trim().Equals(this.rTUChannel.ChannelName))
                {
                    return true;
                }
                result = new RTUChannelManage().GetByName(ChannelName.Text.Trim()) == null;
                if (!result)
                {
                    this.ShowWarningDialog(desc);
                    this.ChannelName.Focus();
                }
            }
            else if (protocol == (int)Common.Protocol.TCP)
            {
                if (ChannelName.Text.Trim().Equals(this.tCPChannel.ChannelName))
                {
                    return true;
                }
                result = new TCPChannelManage().GetByName(ChannelName.Text.Trim()) == null;
                if (!result)
                {
                    this.ShowWarningDialog(desc);
                    this.ChannelName.Focus();
                }
            }
            return result;
        }

        private bool CheckSensorId(UIComboBox ChannelSensorId, string desc)
        {
            bool result = false;
            if (protocol == (int)Common.Protocol.RTU)
            {
                if (ChannelSensorId.Text.Trim().Equals(this.rTUChannel.sensorID) || ChannelSensorId.Text.Trim().Length == 0)
                {
                    return true;
                }
                result = new RTUChannelManage().GetBySensorId(ChannelSensorId.Text.Trim()).Count == 0;
                if (!result)
                {
                    this.ShowWarningDialog(desc);
                    this.ChannelSensorId.Focus();
                }
            }
            else if (protocol == (int)Common.Protocol.TCP)
            {
                if (ChannelSensorId.Text.Trim().Equals(this.tCPChannel.sensorID) || ChannelSensorId.Text.Trim().Length == 0)
                {
                    return true;
                }
                result = new TCPChannelManage().GetBySensorId(ChannelSensorId.Text.Trim()).Count == 0;
                if (!result)
                {
                    this.ShowWarningDialog(desc);
                    this.ChannelSensorId.Focus();
                }
            }
            return result;
        }
        private bool CheckSensorRange(UITextBox ChannelSensorRangeL, UITextBox ChannelSensorRangeH, string desc)
        {
            double rl = double.Parse(ChannelSensorRangeL.Text.Trim());
            double rh = double.Parse(ChannelSensorRangeH.Text.Trim());
            bool result = rl < rh;
            if (!result)
            {
                this.ShowWarningDialog(desc);
                this.ChannelSensorRangeL.Focus();
            }
            return result;
        }
        /// <summary>
        /// 检查报警配置是否正确
        /// </summary>
        /// <param name="deviceName"></param>
        /// <param name="desc"></param>
        /// <returns></returns>
        private bool CheckWarning(UICheckBox isWraning, UITextBox ChannelWarning1L, UITextBox ChannelWarning1H, UITextBox ChannelWarning2L, UITextBox ChannelWarning2H, UITextBox ChannelWarning3L, UITextBox ChannelWarning3H)
        {
            double w1l = double.Parse(ChannelWarning1L.Text.Trim());
            double w1h = double.Parse(ChannelWarning1H.Text.Trim());
            double w2l = double.Parse(ChannelWarning2L.Text.Trim());
            double w2h = double.Parse(ChannelWarning2H.Text.Trim());
            double w3l = double.Parse(ChannelWarning3L.Text.Trim());
            double w3h = double.Parse(ChannelWarning3H.Text.Trim());
            if (!isWraning.Checked)
            {
                //如果报警没有勾选，那么所有的阈值必须全空或全填且合理
                if (double.Parse(ChannelWarning1L.Text.Trim()) == 0 && double.Parse(ChannelWarning1H.Text.Trim()) == 0 && double.Parse(ChannelWarning2L.Text.Trim()) == 0 && double.Parse(ChannelWarning2H.Text.Trim()) == 0 && double.Parse(ChannelWarning3L.Text.Trim()) == 0 && double.Parse(ChannelWarning3H.Text.Trim()) == 0)
                {
                    return true;
                }
                return CheckWarningEmpty1(ChannelWarning1L, ChannelWarning1H, ChannelWarning2L, ChannelWarning2H, ChannelWarning3L, ChannelWarning3H) && CheckWarningRange(w1l, w1h, w2l, w2h, w3l, w3h);
            }
            else
            {
                return CheckWarningEmpty2(ChannelWarning1L, ChannelWarning1H, ChannelWarning2L, ChannelWarning2H, ChannelWarning3L, ChannelWarning3H) && CheckWarningRange(w1l, w1h, w2l, w2h, w3l, w3h);
            }
        }
        private bool CheckWarningRange(double w1l, double w1h, double w2l, double w2h, double w3l, double w3h)
        {
            //两个方向的（例如CO浓度为不能过高，而水位不能太低）
            if ((w1l < w1h && w1h <= w2l && w2l < w2h && w2h <= w3l && w3l < w3h) || (w1l < w1h && w1l >= w2h && w2l < w2h && w2l > w3h && w3l < w3h))
            {
                return true;
            }
            this.ShowWarningDialog("报警阈值范围不合理，请检查\r\n规则：\r\n1、每级报警的阈值范围需左边为小值\r\n2、一级到三级的阈值应该是递增或递减的\r\n3、不能有交集");
            return false;
        }
        private bool CheckWarningEmpty1(UITextBox ChannelWarning1L, UITextBox ChannelWarning1H, UITextBox ChannelWarning2L, UITextBox ChannelWarning2H, UITextBox ChannelWarning3L, UITextBox ChannelWarning3H)
        {
            return CheckEmpty(ChannelWarning1L, "没有勾选报警，则只可以全空或全填且合理")
                && CheckEmpty(ChannelWarning1H, "没有勾选报警，则只可以全空或全填且合理")
                && CheckEmpty(ChannelWarning2L, "没有勾选报警，则只可以全空或全填且合理")
                && CheckEmpty(ChannelWarning2H, "没有勾选报警，则只可以全空或全填且合理")
                && CheckEmpty(ChannelWarning3L, "没有勾选报警，则只可以全空或全填且合理")
                && CheckEmpty(ChannelWarning3H, "没有勾选报警，则只可以全空或全填且合理");
        }
        private bool CheckWarningEmpty2(UITextBox ChannelWarning1L, UITextBox ChannelWarning1H, UITextBox ChannelWarning2L, UITextBox ChannelWarning2H, UITextBox ChannelWarning3L, UITextBox ChannelWarning3H)
        {
            return CheckEmpty(ChannelWarning1L, "勾选了报警，则报警阈值范围不能有空值")
                && CheckEmpty(ChannelWarning1H, "勾选了报警，则报警阈值范围不能有空值")
                && CheckEmpty(ChannelWarning2L, "勾选了报警，则报警阈值范围不能有空值")
                && CheckEmpty(ChannelWarning2H, "勾选了报警，则报警阈值范围不能有空值")
                && CheckEmpty(ChannelWarning3L, "勾选了报警，则报警阈值范围不能有空值")
                && CheckEmpty(ChannelWarning3H, "勾选了报警，则报警阈值范围不能有空值");
        }
        /// <summary>
        /// 读取通道的类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChannelTypeRead_Click(object sender, EventArgs e)
        {
            if (protocol == (int)Common.Protocol.RTU)
            {
                RTUDevice rTUDevice = new RTUDeviceManage().GetById(this.rTUChannel.deviceID);

            }
            else if (protocol == (int)Common.Protocol.TCP)
            {

            }
        }

    }
}
