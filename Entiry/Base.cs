using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTU_TP1608.Entiry
{
    public class Base
    {
        //SqlSugar的用法
        [SugarColumn(IsNullable =false, IsPrimaryKey = true, IsIdentity = false,  ColumnDescription = "主键id")]//不能为空，是主键，不自增长
        public string id { get; set; }

        [SugarColumn(IsNullable = true, ColumnName = "created_by", ColumnDescription = "创建者")]
        public string createBy { get; set; }

        [SugarColumn(IsNullable = true, ColumnName = "created_time", ColumnDescription = "创建时间")]
        public DateTime? createTime { get; set; }

        [SugarColumn(IsNullable = true, ColumnName = "updated_by", ColumnDescription = "更新者")]
        public string updateBy { get; set; }

        [SugarColumn(IsNullable = true, ColumnName = "updated_time", ColumnDescription = "更新时间")]
        public DateTime? updateTime { get; set; }
    }
}
