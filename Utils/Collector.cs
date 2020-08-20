using Modbus.Device;
using ModbusRTU_TP1608.Entiry;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTU_TP1608.Utils
{
    public class Collector
    {
        public SerialPort port;
        private IModbusMaster master;
        public byte slaveAddress;//从站地址
        public ushort startAddress;//起始地址
        public ushort numOfRegisters;//寄存器数量
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="port"></param>
        public Collector(SerialPort port, byte slaveAddress, ushort startAddress, ushort numOfRegisters)
        {
            this.port = port;
            this.slaveAddress = slaveAddress;
            this.startAddress = startAddress;
            this.numOfRegisters = numOfRegisters;
            this.master = ModbusSerialMaster.CreateRtu(this.port);
        }
        /// <summary>
        /// 采集方法
        /// </summary>
        public void Collect(Object obj)
        {
            Device device = (Device)obj;
            lock (this.port)
            {
                try
                {
                    this.OpenPort();
                    ushort[] ushortBuffer = master.ReadHoldingRegisters(this.slaveAddress, this.startAddress, this.numOfRegisters);
                    float[] floatBuffer = DataTypeConvert.GetReal(ushortBuffer, 0);//得到32位浮点数组
                    Chennal chennal;
                    for (int i = device.startChennal - 1; i < device.startChennal + device.chennalNum - 1; i++)
                    {
                        chennal = new ChennalManage().GetByDeviceIdAndId(device.id.ToString(), i + 1);
                        if (chennal.sensorID != null)
                        {
                            Sensor sensor = new Sensor();
                            sensor.sensorId = chennal.sensorID;
                            sensor.sensorName = chennal.sensorName;
                            sensor.sensorType = chennal.sensorType;
                            sensor.sensorLabel = chennal.chennalLabel;
                            sensor.sensorValue = floatBuffer[i].ToString();
                            sensor.sensorUnit = chennal.chennalUnit;
                            sensor.createBy = "设备：" + device.deviceName;
                            sensor.createTime = DateTime.Now;
                            sensor.updateBy = "设备：" + device.deviceName;
                            sensor.updateTime = DateTime.Now;
                            new SensorManage().InsertByTableName(chennal.sensorTableName, sensor);
                        }
                    }
                    this.ClosePort();
                }
                catch (Exception ex)
                {

                }
            }
        }
        /// <summary>
        /// 打开串口
        /// </summary>
        private void OpenPort()
        {
            this.port.Close();
            if (!this.port.IsOpen)
            {
                this.port.Open();
            }
        }
        /// <summary>
        /// 关闭串口
        /// </summary>
        private void ClosePort()
        {
            this.port.Close();
        }

    }
}
