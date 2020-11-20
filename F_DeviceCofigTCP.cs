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
        /// <summary>
        /// 获取一个日志记录器
        /// </summary>
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(typeof(F_DeviceCofigTCP));
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
                   && CheckEmpty(deviceChannelNum, "请选择通道数量")
                   && CheckEmpty(deviceStartChannel, "请选择起始通道")
                   && CheckChannelNumAndStartChannel(deviceChannelNum, deviceStartChannel, "通道数量与起始通道不匹配，需满足：\r\n\t8 - 起始通道 >= 通道数量")
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
        /// <param name="deviceChannelNum"></param>
        /// <param name="deviceStartChannel"></param>
        /// <param name="desc"></param>
        /// <returns></returns>
        private bool CheckChannelNumAndStartChannel(UIComboBox deviceChannelNum, UIComboBox deviceStartChannel, string desc)
        {
            if (deviceStartChannel.SelectedIndex + 1 == this.device.startChannel && deviceChannelNum.SelectedIndex + 1 == this.device.ChannelNum)
            {
                return true;
            }
            bool result = (8 - (deviceStartChannel.SelectedIndex + 1) + 1) >= (deviceChannelNum.SelectedIndex + 1);
            if (!result)
            {
                this.ShowWarningDialog(desc);
                deviceChannelNum.Focus();
            }
            return result;
        }

        private void F_DeviceCofigTCP_FormClosed(object sender, FormClosedEventArgs e)
        {
            Logger.Info("取消修改");
        }
    }
}
