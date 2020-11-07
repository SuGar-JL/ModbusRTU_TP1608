using ModbusRTU_TP1608.Entiry;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTU_TP1608.Utils
{
    class SensorManage : DbContext<Sensor>
    {

        
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
        public int UpdateByTableNameAndSensorId(string tableName,Sensor sensor)
        {
            return Db.Updateable(sensor).AS(tableName).Where(it => it.sensorId == sensor.sensorId).ExecuteCommand();
        }

        /// <summary>
        /// 通过表名称和id查询
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Sensor GetByTableNameAndSensorId(string tableName, string sensorId)
        {
            return Db.Queryable<Sensor>().AS(tableName).Where(it => it.sensorId == sensorId).First();
        }

        public int DeleteByTableNameAndId(string tableName, string id)
        {
            return Db.Deleteable<Sensor>().AS(tableName).Where(it => it.sensorId == id).ExecuteCommand();
        }
        /// <summary>
        /// 查询最大的传感器id
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public string GetMaxSensorIdByTableName(string tableName)
        {
            return Db.Queryable<Sensor>().AS(tableName).Max(it => it.sensorId);
        }
    }
}
