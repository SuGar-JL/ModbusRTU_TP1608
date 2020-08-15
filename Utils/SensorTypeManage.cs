using ModbusRTU_TP1608.Entiry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTU_TP1608.Utils
{
    class SensorTypeManage : DbContext<SensorType>
    {
        /// <summary>
        /// 通过类型名称查询
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public SensorType GetByTypeName(string typeName)
        {
            return CurrentDb.GetSingle(it => it.sensorTypeName == typeName);
        }

        /// <summary>
        /// 通过数据库表名称查询
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public SensorType GetByDbTableName(string tableName)
        {
            return CurrentDb.GetSingle(it => it.dbTableName == tableName);
        }
    }
}
