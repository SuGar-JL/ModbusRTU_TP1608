using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTU_TP1608.Entiry
{
    [SugarTable("Device")]//数据库表名称
    public class Device : Base, IComparable<Device>
    {
        [SugarColumn(ColumnName = "status", IsNullable = false, ColumnDescription = "设备状态：0、关闭，1、打开，2、采集")]
        public int status { get; set; }
        [SugarColumn(ColumnName = "device_type", IsNullable = false, ColumnDescription = "设备类型")]
        public string deviceType { get; set; }

        [SugarColumn(ColumnName = "device_name", IsNullable = false, ColumnDescription = "设备名称")]
        public string deviceName { get; set; }

        [SugarColumn(ColumnName = "device_address", IsNullable = false, ColumnDescription = "设备地址")]
        public string deviceAddress { get; set; }

        //用Base类的id代替
        //[SugarColumn(ColumnName = "device_id", IsNullable = false, ColumnDescription = "设备ID")]
        //public string deviceID { get; set; }

        [SugarColumn(ColumnName = "chennal_num", IsNullable = false, ColumnDescription = "设备通道数")]
        public int chennalNum { get; set; }

        [SugarColumn(ColumnName = "start_chennal", IsNullable = false, ColumnDescription = "起始通道")]
        public int startChennal { get; set; }

        [SugarColumn(ColumnName = "store_interval", IsNullable = false, ColumnDescription = "保存间隔")]
        public double storeInterval { get; set; }

        [SugarColumn(ColumnName = "collect_interval", IsNullable = false, ColumnDescription = "采集间隔")]
        public double collectInterval { get; set; }

        [SugarColumn(ColumnName = "drop_time_delay", IsNullable = false, ColumnDescription = "掉线延时")]
        public double dropTimeDelay { get; set; }

        [SugarColumn(ColumnName = "port", IsNullable = true, ColumnDescription = "COM口")]
        public string port { get; set; }

        [SugarColumn(ColumnName = "baud_rate", IsNullable = false, ColumnDescription = "波特率")]
        public string baudRate { get; set; }
        
        public Device()
        {
            this.id = System.Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Device other)
        {
            return DateTime.Compare((DateTime)this.createTime , (DateTime)other.createTime);
        }
    }
}
