using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTU_TP1608.Entiry.Bluetooth_Gateway
{
    [SugarTable("t_area_people_num", TableDescription = "蓝牙探针")]//数据库表名称
    class Area_People_Num : Base
    {
        public Area_People_Num()
        {
            this.id = System.Guid.NewGuid().ToString("N");
        }
        [SugarColumn(ColumnName = "gateway", IsNullable = true, ColumnDescription = "网关名称")]
        public string Gateway { get; set; }

        [SugarColumn(ColumnName = "node_id", IsNullable = true, ColumnDescription = "节点id")]
        public string NodeId { get; set; }

        [SugarColumn(ColumnName = "system_id", IsNullable = true, ColumnDescription = "系统id")]
        public string SystemId { get; set; }

        [SugarColumn(ColumnName = "type", IsNullable = true, ColumnDescription = "类型")]
        public string Type { get; set; }

        [SugarColumn(ColumnName = "num_people", IsNullable = true, ColumnDescription = "人数")]
        public int? Num_people { get; set; }

        [SugarColumn(ColumnName = "del_flag", IsNullable = true, ColumnDescription = "删除标志")]
        public string del_flag { get; set; }

    }
}
