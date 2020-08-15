using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTU_TP1608.Entiry
{
    [SugarTable("SensorType")]//数据库表名称
    class SensorType : Base
    {
        [SugarColumn(ColumnName = "type_name", IsNullable = false, ColumnDescription = "传感器类型名称")]
        public string sensorTypeName { get; set; }

        [SugarColumn(ColumnName = "table_name", IsNullable = false, ColumnDescription = "传感器类型对应数据库表名称")]
        public string dbTableName { get; set; }

    }
}
