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
    public partial class F_ChennalInfo : UIEditForm
    {
        //获取系统当前的协议
        private int protocol = new SysManage().GetSysInfo()[0].protocol;
        public RTUChennal rTUChennal = new RTUChennal();
        public TCPChennal tCPChennal = new TCPChennal();
        public F_ChennalInfo()
        {
            InitializeComponent();
        }

        protected override bool CheckData()
        {
            return CheckEmpty(chennalName, "请输入通道名称")
                   && CheckChennalName(chennalName, "通道名称重复")
                   && CheckEmpty(chennalLabel, "请输入监测项")
                   && CheckEmpty(chennalUnit, "请选择监测单位")
                   && CheckEmpty(chennalSensorType, "请选择传感器类型")
                   && CheckEmpty(chennalSensorName, "请输入传感器名称")
                   && CheckEmpty(chennalSensorId, "请输入传感器id")
                   && CheckSensorId(chennalSensorId, "传感器id重复")
                   && CheckEmpty(chennalDecimalPlaces, "请选择小数位")
                   && CheckEmpty(chennalSensorRangeL, "传感器量程需填完整")
                   && CheckEmpty(chennalSensorRangeH, "传感器量程需填完整")
                   && CheckSensorRange(chennalSensorRangeL, chennalSensorRangeH, "传感器量程不合理")
                   && CheckWarning(isWraning, chennalWarning1L, chennalWarning1H, chennalWarning2L, chennalWarning2H, chennalWarning3L, chennalWarning3H)
                   && CheckEmpty(chennalType, "请选择通道类型");
        }

        private bool CheckChennalName(UITextBox chennalName, string desc)
        {
            bool result = false;
            if (protocol == (int)Common.Protocol.RTU)
            {
                if (chennalName.Text.Trim().Equals(this.rTUChennal.chennalName))
                {
                    return true;
                }
                result = new RTUChennalManage().GetByName(chennalName.Text.Trim()) == null;
                if (!result)
                {
                    this.ShowWarningDialog(desc);
                    this.chennalName.Focus();
                }
            }
            else if (protocol == (int)Common.Protocol.TCP)
            {
                if (chennalName.Text.Trim().Equals(this.tCPChennal.chennalName))
                {
                    return true;
                }
                result = new TCPChennalManage().GetByName(chennalName.Text.Trim()) == null;
                if (!result)
                {
                    this.ShowWarningDialog(desc);
                    this.chennalName.Focus();
                }
            }
            return result;
        }

        private bool CheckSensorId(UIComboBox chennalSensorId, string desc)
        {
            bool result = false;
            if (protocol == (int)Common.Protocol.RTU)
            {
                if (chennalSensorId.Text.Trim().Equals(this.rTUChennal.sensorID))
                {
                    return true;
                }
                result = new RTUChennalManage().GetBySensorId(chennalSensorId.Text.Trim()).Count == 0;
                if (!result)
                {
                    this.ShowWarningDialog(desc);
                    this.chennalSensorId.Focus();
                }
            }
            else if (protocol == (int)Common.Protocol.TCP)
            {
                if (chennalSensorId.Text.Trim().Equals(this.tCPChennal.sensorID))
                {
                    return true;
                }
                result = new TCPChennalManage().GetBySensorId(chennalSensorId.Text.Trim()).Count == 0;
                if (!result)
                {
                    this.ShowWarningDialog(desc);
                    this.chennalSensorId.Focus();
                }
            }
            return result;
        }
        private bool CheckSensorRange(UITextBox chennalSensorRangeL, UITextBox chennalSensorRangeH, string desc)
        {
            double rl = double.Parse(chennalSensorRangeL.Text.Trim());
            double rh = double.Parse(chennalSensorRangeH.Text.Trim());
            bool result = rl < rh;
            if (!result)
            {
                this.ShowWarningDialog(desc);
                this.chennalSensorRangeL.Focus();
            }
            return result;
        }
        /// <summary>
        /// 检查报警配置是否正确
        /// </summary>
        /// <param name="deviceName"></param>
        /// <param name="desc"></param>
        /// <returns></returns>
        private bool CheckWarning(UICheckBox isWraning, UITextBox chennalWarning1L, UITextBox chennalWarning1H, UITextBox chennalWarning2L, UITextBox chennalWarning2H, UITextBox chennalWarning3L, UITextBox chennalWarning3H)
        {
            double w1l = double.Parse(chennalWarning1L.Text.Trim());
            double w1h = double.Parse(chennalWarning1H.Text.Trim());
            double w2l = double.Parse(chennalWarning2L.Text.Trim());
            double w2h = double.Parse(chennalWarning2H.Text.Trim());
            double w3l = double.Parse(chennalWarning3L.Text.Trim());
            double w3h = double.Parse(chennalWarning3H.Text.Trim());
            if (!isWraning.Checked)
            {
                //如果报警没有勾选，那么所有的阈值必须全空或全填且合理
                if (double.Parse(chennalWarning1L.Text.Trim()) == 0 && double.Parse(chennalWarning1H.Text.Trim()) == 0 && double.Parse(chennalWarning2L.Text.Trim()) == 0 && double.Parse(chennalWarning2H.Text.Trim()) == 0 && double.Parse(chennalWarning3L.Text.Trim()) == 0 && double.Parse(chennalWarning3H.Text.Trim()) == 0)
                {
                    return true;
                }
                return CheckWarningEmpty1(chennalWarning1L, chennalWarning1H, chennalWarning2L, chennalWarning2H, chennalWarning3L, chennalWarning3H) && CheckWarningRange(w1l, w1h, w2l, w2h, w3l, w3h);
            }
            else
            {
                return CheckWarningEmpty2(chennalWarning1L, chennalWarning1H, chennalWarning2L, chennalWarning2H, chennalWarning3L, chennalWarning3H) && CheckWarningRange(w1l, w1h, w2l, w2h, w3l, w3h);
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
        private bool CheckWarningEmpty1(UITextBox chennalWarning1L, UITextBox chennalWarning1H, UITextBox chennalWarning2L, UITextBox chennalWarning2H, UITextBox chennalWarning3L, UITextBox chennalWarning3H)
        {
            return CheckEmpty(chennalWarning1L, "没有勾选报警，则只可以全空或全填且合理")
                && CheckEmpty(chennalWarning1H, "没有勾选报警，则只可以全空或全填且合理")
                && CheckEmpty(chennalWarning2L, "没有勾选报警，则只可以全空或全填且合理")
                && CheckEmpty(chennalWarning2H, "没有勾选报警，则只可以全空或全填且合理")
                && CheckEmpty(chennalWarning3L, "没有勾选报警，则只可以全空或全填且合理")
                && CheckEmpty(chennalWarning3H, "没有勾选报警，则只可以全空或全填且合理");
        }
        private bool CheckWarningEmpty2(UITextBox chennalWarning1L, UITextBox chennalWarning1H, UITextBox chennalWarning2L, UITextBox chennalWarning2H, UITextBox chennalWarning3L, UITextBox chennalWarning3H)
        {
            return CheckEmpty(chennalWarning1L, "勾选了报警，则报警阈值范围不能有空值")
                && CheckEmpty(chennalWarning1H, "勾选了报警，则报警阈值范围不能有空值")
                && CheckEmpty(chennalWarning2L, "勾选了报警，则报警阈值范围不能有空值")
                && CheckEmpty(chennalWarning2H, "勾选了报警，则报警阈值范围不能有空值")
                && CheckEmpty(chennalWarning3L, "勾选了报警，则报警阈值范围不能有空值")
                && CheckEmpty(chennalWarning3H, "勾选了报警，则报警阈值范围不能有空值");
        }
        /// <summary>
        /// 读取通道的类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chennalTypeRead_Click(object sender, EventArgs e)
        {
            if (protocol == (int)Common.Protocol.RTU)
            {
                RTUDevice rTUDevice = new RTUDeviceManage().GetById(this.rTUChennal.deviceID);

            }
            else if (protocol == (int)Common.Protocol.TCP)
            {

            }
        }

    }
}
