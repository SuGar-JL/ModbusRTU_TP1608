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
    public partial class F_DeviceCofigTCP : UIEditForm
    {
        /// <summary>
        /// 正在修改的设备
        /// </summary>
        public TCPDevice device = new TCPDevice();
        public F_DeviceCofigTCP()
        {
            InitializeComponent();
        }


        protected override bool CheckData()
        {
            return CheckEmpty(deviceType, "请选择设备类型")
                   && CheckEmpty(deviceName, "请输入设备名称")
                   && CheckDeviceNameRepeat(deviceName, "设备名称已被占用")
                   && CheckEmpty(deviceAddress, "请输入设备地址")
                   //&& CheckDeviceAddressRepeat(deviceAddress, "设备地址已被占用")
                   && CheckEmpty(deviceChennalNum, "请选择通道数量")
                   && CheckEmpty(deviceStartChennal, "请选择起始通道")
                   && CheckChennalNumAndStartChennal(deviceChennalNum, deviceStartChennal, "通道数量与起始通道不匹配，需满足：\r\n\t8 - 起始通道 >= 通道数量")
                   && CheckEmpty(deviceHostName, "请输入主机名")
                   && CheckEmpty(devicePort, "请输入端口号")
                   && CheckEmpty(devicePosition, "请简单描述设备安装位置");
        }
        /// <summary>
        /// 检查设备名称是否重复
        /// </summary>
        /// <param name="deviceName"></param>
        /// <param name="desc"></param>
        /// <returns></returns>
        private bool CheckDeviceNameRepeat(UITextBox deviceName, string desc)
        {
            if (deviceName.Text.Trim().Equals(this.device.deviceName))
            {
                return true;
            }
            bool result = new TCPDeviceManage().GetByName(deviceName.Text.Trim()).Count == 0;
            if (!result)
            {
                this.ShowWarningDialog(desc);
                deviceName.Focus();
            }
            return result;
        }
        /// <summary>
        /// 检查设备地址是否重复
        /// </summary>
        /// <param name="deviceAddress"></param>
        /// <param name="desc"></param>
        /// <returns></returns>
        private bool CheckDeviceAddressRepeat(UITextBox deviceAddress, string desc)
        {
            if (deviceAddress.Text.Trim().Equals(this.device.deviceAddress))
            {
                return true;
            }
            bool result = new TCPDeviceManage().GetByAddress(deviceAddress.Text.Trim()).Count == 0;
            if (!result)
            {
                this.ShowWarningDialog(desc);
                deviceAddress.Focus();
            }
            return result;
        }
        /// <summary>
        /// 检查通道数量与其实通道是否匹配
        /// </summary>
        /// <param name="deviceChennalNum"></param>
        /// <param name="deviceStartChennal"></param>
        /// <param name="desc"></param>
        /// <returns></returns>
        private bool CheckChennalNumAndStartChennal(UIComboBox deviceChennalNum, UIComboBox deviceStartChennal, string desc)
        {
            if (deviceStartChennal.SelectedIndex + 1 == this.device.startChennal && deviceChennalNum.SelectedIndex + 1 == this.device.chennalNum)
            {
                return true;
            }
            bool result = (8 - (deviceStartChennal.SelectedIndex + 1) + 1) >= (deviceChennalNum.SelectedIndex + 1);
            if (!result)
            {
                this.ShowWarningDialog(desc);
                deviceChennalNum.Focus();
            }
            return result;
        }
    }
}
