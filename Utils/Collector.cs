using Modbus.Device;
using ModbusRTU_TP1608.Entiry;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModbusRTU_TP1608.Utils
{
    /// <summary>
    /// 对应一个串口，用于设备进行采集时，记下要用的master和地址，以便轮询
    /// </summary>
    public class Collector
    {
        private IModbusMaster master;
        private Dictionary<string, Device> devices = new Dictionary<string, Device>();
        private Thread thread;

        /// <summary>
        /// 使用新的串口时，要创建一个新的master
        /// </summary>
        /// <param name="port"></param>
        public Collector(SerialPort port)
        {
            this.master = ModbusSerialMaster.CreateRtu(port);
        }
        /// <summary>
        /// 新增设备时，添加地址到地址目录
        /// </summary>
        /// <param name="deviceAddress"></param>
        public bool AddDevice(Device device)
        {
            //若设备目录不存在该设备地址，则可以添加
            if (!this.devices.ContainsKey(device.deviceAddress))
            {
                this.devices.Add(device.deviceAddress,device);
                return true;
            }
            //否则不能添加，提示冲突
            else
            {
                MessageBox.Show("设备地址冲突，请换个地址！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        /// <summary>
        /// 设备停止采集时，要删除设备集合里对应的设备
        /// </summary>
        /// <returns></returns>
        public bool DelDevice(Device device)
        {
            //若地址列表存在地址，则可以删除
            if (this.devices.ContainsKey(device.deviceAddress))
            {
                this.devices.Remove(device.deviceAddress);
                //判断当前地址列表还有多少地址，即在采集中的设备数，若没有采集中的设备了，就终止止线程(还要删除相应的Collector对象，在点击停止采集按钮处实现)
                if (this.devices.Count == 0)
                {
                    this.thread.Abort();
                }
                return true;
            }
            else
            {
                //MessageBox.Show("设备地址不存在，可能设备没有进行采集过！", "提示！", MessageBoxButton.OK, MessageBoxImage.Warning);
                //不可能不存在，不存在怎么采集！！
                return false;
            }
        }
        /// <summary>
        /// 获取设备集合
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, Device> GetDevices()
        {
            return this.devices;
        }
        /// <summary>
        /// 获取master
        /// </summary>
        /// <returns></returns>
        public IModbusMaster GetMaster()
        {
            return this.master;
        }
        /// <summary>
        /// 设置线程
        /// </summary>
        /// <param name="thread"></param>
        public void SetThread(Thread thread)
        {
            this.thread = thread;
        }

    }

}
