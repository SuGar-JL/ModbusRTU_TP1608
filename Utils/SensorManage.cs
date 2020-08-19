using ModbusRTU_TP1608.Entiry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTU_TP1608.Utils
{
    class SensorManage : DbContext<Sensor>
    {

        public SensorManage()
        {
            Db.CodeFirst.InitTables(typeof(Sensor));
        }
        /// <summary>
        /// 通过数据库表名称插入
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="sensor"></param>
        /// <returns></returns>
        public Sensor InsertByTableName(string tableName, Sensor sensor)
        {
            return Db.Insertable(sensor).AS(tableName).ExecuteReturnEntity();
        }

        /// <summary>
        /// 查询某个表的所有
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public List<Sensor> GetListFromTable(string tableName)
        {
            return Db.Queryable<Sensor>().AS(tableName).ToList();
        }

        /// <summary>
        /// 根据表名称和id更新
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="id"></param>
        /// <param name="sensor"></param>
        /// <returns></returns>
        public int UpdateByTableNameAndId(string tableName, string id, Sensor sensor)
        {
            return Db.Updateable(sensor).AS(tableName).Where(it => it.id == int.Parse(id)).ExecuteCommand();
        }

        /// <summary>
        /// 通过表名称和id查询
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Sensor GetByTableNameAndId(string tableName, string id)
        {
            return Db.Queryable<Sensor>().AS(tableName).Where(it => it.id == int.Parse(id)).Single();
        }

        public int DeleteByTableNameAndId(string tableName, string id)
        {
            return Db.Deleteable<Sensor>().AS(tableName).Where(it => it.id == int.Parse(id)).ExecuteCommand();
        }
        /// <summary>
        /// 通过类型和名称查询
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public Sensor GetByTypeAndName(int type, string name)
        {
            return CurrentDb.GetSingle(it => it.sensorType == type && it.sensorName == name);
        }
    }
}
