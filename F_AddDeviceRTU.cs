﻿using ModbusRTU_TP1608.Entiry;
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
    public partial class F_AddDeviceRTU : UIEditForm
    {
        public F_AddDeviceRTU()
        {
            InitializeComponent();
        }

        private void F_AddDeviceRTU_Load(object sender, EventArgs e)
        {
            this.deviceType.Items.AddRange(Common.DeviceType.ToArray());
            this.deviceChennalNum.Items.AddRange(Common.DeviceChennalNum.ToArray());
            this.deviceStartChennal.Items.AddRange(Common.DeviceStartChennal.ToArray());
            //获取可用串口
            List<string> serialPorts = System.IO.Ports.SerialPort.GetPortNames().ToList();
            serialPorts.Sort();
            this.deviceSerialPort.Items.AddRange(serialPorts.ToArray());
            this.deviceBaudRate.Items.AddRange(Common.BaudRate.ToArray());
            //设备类型默认选择第一个
            this.deviceType.SelectedIndex = 0;
            //波特率默认选择9600
            this.deviceBaudRate.SelectedIndex = 10;

        }
        protected override bool CheckData()
        {
            return CheckEmpty(deviceType, "请选择设备类型")
                   && CheckEmpty(deviceName, "请输入设备名称")
                   && CheckDeviceNameRepeat(deviceName, "设备名称已被占用")
                   && CheckEmpty(deviceAddress, "请输入设备地址")
                   && CheckDeviceAddressRepeat(deviceAddress, "设备地址已被占用")
                   && CheckEmpty(deviceChennalNum, "请选择通道数量")
                   && CheckEmpty(deviceStartChennal, "请选择起始通道")
                   && CheckChennalNumAndStartChennal(deviceChennalNum, deviceStartChennal, "通道数量与起始通道不匹配，需满足：\r\n\t8 - 起始通道 >= 通道数量")
                   && CheckEmpty(deviceSerialPort, "请选择串口")
                   && CheckEmpty(deviceBaudRate, "请选择波特率")
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
            bool result = new RTUDeviceManage().GetByName(deviceName.Text.Trim()).Count == 0;
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
            bool result = new RTUDeviceManage().GetByAddress(deviceAddress.Text.Trim()).Count == 0;
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
            bool result = (8 - (deviceStartChennal.SelectedIndex + 1) + 1) >= (deviceChennalNum.SelectedIndex + 1);
            if (!result)
            {
                this.ShowWarningDialog(desc);
                deviceChennalNum.Focus();
            }
            return result;
        }

        private void deviceType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
