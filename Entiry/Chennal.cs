using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTU_TP1608.Entiry
{
    [SugarTable("Chennal")]//数据库表名称
    public class Chennal : Base
    {
        [SugarColumn(ColumnName = "device_id", IsNullable = false, ColumnDescription = "附属于设备的id")]
        public string deviceID { get; set; }

        [SugarColumn(ColumnName = "sensor_id", IsNullable = true, ColumnDescription = "传感器id")]
        public string sensorID { get; set; }

        [SugarColumn(ColumnName = "sensor_tableName", IsNullable = true, ColumnDescription = "传感器对应数据库表名称")]
        public string sensorTableName { get; set; }

        [SugarColumn(ColumnName = "chennal_name", IsNullable = false, ColumnDescription = "通道名称")]
        public string chennalName { get; set; }

        //不能用Base类的id代替，因为要重复
        [SugarColumn(ColumnName = "chennal_id", ColumnDescription = "通道ID")]
        public int chennalID { get; set; }

        [SugarColumn(ColumnName = "stop_waring", ColumnDescription = "禁止报警")]
        public string stopWaring { get; set; }

        [SugarColumn(ColumnName = "chennal_color", IsNullable = true, ColumnDescription = "通道颜色")]
        public string chennalColor { get; set; }

        [SugarColumn(ColumnName = "chennal_unit", IsNullable = true, ColumnDescription = "通道单位")]
        public string chennalUnit { get; set; }

        [SugarColumn(ColumnName = "decimal_places", ColumnDescription = "小数位")]
        public int decimalPlaces { get; set; }

        [SugarColumn(ColumnName = "chennal_type", IsNullable = false, ColumnDescription = "通道类型")]
        public string chennalType { get; set; }

        [SugarColumn(ColumnName = "adjustment", ColumnDescription = "调整")]
        public double adjustment { get; set; }

        [SugarColumn(ColumnName = "lower_limit", ColumnDescription = "下限")]
        public double lowerLimit { get; set; }

        [SugarColumn(ColumnName = "upper_limit", ColumnDescription = "上限")]
        public double upperLimit { get; set; }

        [SugarColumn(ColumnName = "l_lower_limit", ColumnDescription = "下下限")]
        public double lLowerLimit { get; set; }

        [SugarColumn(ColumnName = "u_upper_limit", ColumnDescription = "上上限")]
        public double uUpperLimit { get; set; }

        [SugarColumn(ColumnName = "small_range", ColumnDescription = "小量程")]
        public double smallRange { get; set; }

        [SugarColumn(ColumnName = "large_range", ColumnDescription = "大量程")]
        public double largeRange { get; set; }

        [SugarColumn(ColumnName = "read_write", ColumnDescription = "读或写标志")]
        public int R_WFlag { get; set; }

    }
}
