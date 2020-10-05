using ModbusRTU_TP1608.Entiry;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusTCP_TP1608.Entiry
{
    [SugarTable("TCPChennal")]//数据库表名称
    public class TCPChennal : Base, IComparable<TCPChennal>
    {
        public TCPChennal()
        {
            this.id = System.Guid.NewGuid().ToString("N");
        }
        [SugarColumn(ColumnName = "device_id", IsNullable = false, ColumnDescription = "附属于设备的id")]
        public string deviceID { get; set; }

        [SugarColumn(ColumnName = "sensor_id", IsNullable = true, ColumnDescription = "传感器id")]
        public string sensorID { get; set; }

        [SugarColumn(ColumnName = "sensor_name", IsNullable = true, ColumnDescription = "传感器名称")]
        public string sensorName { get; set; }

        [SugarColumn(ColumnName = "sensor_type", IsNullable = true, ColumnDescription = "传感器类型")]
        public string sensorType { get; set; }

        [SugarColumn(ColumnName = "sensor_tableName", IsNullable = true, ColumnDescription = "传感器对应数据库表名称")]
        public string sensorTableName { get; set; }

        [SugarColumn(ColumnName = "chennal_name", IsNullable = false, ColumnDescription = "通道名称")]
        public string chennalName { get; set; }

        //不能用Base类的id代替，因为要重复
        [SugarColumn(ColumnName = "chennal_id", ColumnDescription = "通道ID")]
        public int chennalID { get; set; }

        [SugarColumn(ColumnName = "chennal_label", IsNullable = true, ColumnDescription = "监测项")]
        public string chennalLabel { get; set; }

        [SugarColumn(ColumnName = "chennal_unit", IsNullable = true, ColumnDescription = "单位")]
        public string chennalUnit { get; set; }

        [SugarColumn(ColumnName = "decimal_places", IsNullable = true, ColumnDescription = "小数位")]
        public int decimalPlaces { get; set; }

        [SugarColumn(ColumnName = "chennal_type", IsNullable = true, ColumnDescription = "通道类型")]
        public string chennalType { get; set; }

        [SugarColumn(ColumnName = "range_l", IsNullable = true, ColumnDescription = "量程下限")]
        public double RangeL { get; set; }

        [SugarColumn(ColumnName = "range_h", IsNullable = true, ColumnDescription = "量程上限")]
        public double RangeH { get; set; }

        [SugarColumn(ColumnName = "warning1_l", IsNullable = true, ColumnDescription = "一级报警下限")]
        public double Warning1L { get; set; }

        [SugarColumn(ColumnName = "warning1_h", IsNullable = true, ColumnDescription = "一级报警上限")]
        public double Warning1H { get; set; }

        [SugarColumn(ColumnName = "warning2_l", IsNullable = true, ColumnDescription = "二级报警下限")]
        public double Warning2L { get; set; }

        [SugarColumn(ColumnName = "warning2_h", IsNullable = true, ColumnDescription = "二级报警上限")]
        public double Warning2H { get; set; }

        [SugarColumn(ColumnName = "warning3_l", IsNullable = true, ColumnDescription = "三级报警下限")]
        public double Warning3L { get; set; }

        [SugarColumn(ColumnName = "warning3_h", IsNullable = true, ColumnDescription = "三级报警上限")]
        public double Warning3H { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(TCPChennal other)
        {
            return this.chennalID.CompareTo(other.chennalID);
        }
    }
}
