using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTU_TP1608.Entiry
{
    [SugarTable("Sys", TableDescription = "系统信息")]//数据库表名称
    class Sys : Base
    {
        [SugarColumn(ColumnName = "protocol", IsNullable = false, ColumnDescription = "通信协议：0、无，1、RTU，2、TCP")]
        public int protocol { get; set; }

        public Sys()
        {
            this.id = System.Guid.NewGuid().ToString("N");
        }
    }
}
