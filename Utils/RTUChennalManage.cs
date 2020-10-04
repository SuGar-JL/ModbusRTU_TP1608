using ModbusRTU_TP1608.Entiry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTU_TP1608.Utils
{
    class RTUChennalManage : DbContext<RTUChennal>
    {
        /// <summary>
        /// 创建数据库表
        /// </summary>
        public void CreateTable()
        {
            Db.CodeFirst.InitTables(typeof(RTUChennal));
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RTUChennal GetById(int id)
        {
            return CurrentDb.GetById(id);
        }

        public RTUChennal GetByName(string chennalName)
        {
            return CurrentDb.GetSingle(it => it.chennalName == chennalName);
        }
        /// <summary>
        /// 根据设备ID查询对应的通道
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public List<RTUChennal> GetByDeviceId(string deviceId)
        {
            return Db.Queryable<RTUChennal>().Where(it => it.deviceID == deviceId).OrderBy(it => it.chennalID).ToList();
        }

        /// <summary>
        /// 根据设备id和通道名称获取通道
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="chennalName"></param>
        /// <returns></returns>
        public RTUChennal GetByDeviceIdAndName(string deviceId, string chennalName)
        {
            return CurrentDb.GetSingle(it => it.deviceID == deviceId && it.chennalName == chennalName);
        }

        public RTUChennal GetByDeviceIdAndId(string deviceId, int id)
        {
            return CurrentDb.GetSingle(it => it.deviceID == deviceId && it.chennalID == id);
        }
        /// <summary>
        /// 根据设备ID和通道ID更新通道配置
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public bool UpdateByDeviceIdAndChennalId(string deviceId, int chennalId, string chennalName, string stopWaring, string chennalLabel, string chennalUnit, int decimalPlaces, string chennalType, double adjustment, double lowerLimit, double upperLimit, double lLowerLimit, double uUpperLimit, double smallRange, double largeRange, string sensorId, string sensorType, string sensorName, string sensorTableName, string updateBy, DateTime updateTime)
        {
            return CurrentDb.Update(it => new RTUChennal() { chennalName = chennalName, stopWaring = stopWaring, chennalLabel = chennalLabel, chennalUnit = chennalUnit, decimalPlaces = decimalPlaces, chennalType = chennalType, adjustment = adjustment, lowerLimit = lowerLimit, upperLimit = upperLimit, lLowerLimit = lLowerLimit, uUpperLimit = uUpperLimit, smallRange = smallRange, largeRange = largeRange, sensorID = sensorId, sensorType = sensorType, sensorName = sensorName, sensorTableName = sensorTableName, updateBy = updateBy, updateTime = updateTime }, it => it.deviceID == deviceId && it.chennalID == chennalId);
        }

        /// <summary>
        /// 根据设备ID和通道ID更新通道传感器id和传感器数据库表名称
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public bool UpdateSensorIdAndTableNameByDeviceIdAndChennalId(string deviceId, int chennalId, string sensorId, string tableName, string updateBy, DateTime updateTime)
        {
            return CurrentDb.Update(it => new RTUChennal() { sensorID = sensorId, sensorTableName = tableName, updateBy = updateBy, updateTime = updateTime }, it => it.deviceID == deviceId && it.chennalID == chennalId);
        }

        //根据设备ID删除通道配置
        public bool DeleteByDeviceId(string deviceId)
        {
            return CurrentDb.Delete(it => it.deviceID == deviceId);
        }

        /// <summary>
        /// 获取表的最大id
        /// </summary>
        /// <returns></returns>
        public int GetMaxId()
        {
            List<RTUChennal> chennals = CurrentDb.GetList();
            int maxId = 0;
            foreach (RTUChennal chennal in chennals)
            {
                if (int.Parse(chennal.id) > maxId)
                {
                    maxId = int.Parse(chennal.id);
                }
            }
            return maxId;
        }
    }
}
