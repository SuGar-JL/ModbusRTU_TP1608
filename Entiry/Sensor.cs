using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTU_TP1608.Entiry
{
    //[SugarTable("History_Data")]//数据库表名称
    public class Sensor : Base
    {
        [SugarColumn(ColumnName = "sensor_id", IsNullable = false, ColumnDescription = "传感器名称")]
        public string sensorId { get; set; }
        [SugarColumn(ColumnName = "name", IsNullable = false, ColumnDescription = "传感器名称")]
        public string sensorName { get; set; }
        [SugarColumn(ColumnName = "type", IsNullable = false, ColumnDescription = "传感器类型")]
        public int sensorType { get; set; }
        [SugarColumn(ColumnName = "label", IsNullable = false, ColumnDescription = "监测项")]
        public string sensorLabel { get; set; }
        [SugarColumn(ColumnName = "value", IsNullable = false, ColumnDescription = "监测值")]
        public string sensorValue { get; set; }
        [SugarColumn(ColumnName = "unit", IsNullable = false, ColumnDescription = "监测单位")]
        public string sensorUnit { get; set; }
        [SugarColumn(ColumnName = "is_external", ColumnDescription = "外部构件标志")]
        public int sensorExternal { get; set; }
        [SugarColumn(ColumnName = "px", IsNullable = true, ColumnDescription = "传感器坐标x")]
        public string sensorPx { get; set; }
        [SugarColumn(ColumnName = "py", IsNullable = true, ColumnDescription = "传感器坐标y")]
        public string sensorPy { get; set; }
        [SugarColumn(ColumnName = "pz", IsNullable = true, ColumnDescription = "传感器坐标z")]
        public string sensorPz { get; set; }
    }
}
