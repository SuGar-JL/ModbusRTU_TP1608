using ModbusRTU_TP1608.Entiry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTU_TP1608.Utils
{
    class RTUChannelManage : DbContext<RTUChannel>
    {
        /// <summary>
        /// 创建数据库表
        /// </summary>
        public void CreateTable()
        {
            Db.CodeFirst.InitTables(typeof(RTUChannel));
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RTUChannel GetById(int id)
        {
            return CurrentDb.GetById(id);
        }

        public RTUChannel GetByName(string ChannelName)
        {
            return CurrentDb.GetSingle(it => it.ChannelName == ChannelName);
        }
        /// <summary>
        /// 根据设备ID查询对应的通道
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public List<RTUChannel> GetByDeviceId(string deviceId)
        {
            return Db.Queryable<RTUChannel>().Where(it => it.deviceID == deviceId).OrderBy(it => it.ChannelID).ToList();
        }

        /// <summary>
        /// 根据设备id和通道名称获取通道
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="ChannelName"></param>
        /// <returns></returns>
        public RTUChannel GetByDeviceIdAndName(string deviceId, string ChannelName)
        {
            return CurrentDb.GetSingle(it => it.deviceID == deviceId && it.ChannelName == ChannelName);
        }
        /// <summary>
        /// 根据id批量删除
        /// </summary>
        public int DeleteByIds(string[] ids)
        {
            return Db.Deleteable<RTUChannel>().In(ids).ExecuteCommand();
        }

        public List<string> GetSensorIds()
        {
            List<RTUChannel> Channels = Db.Queryable<RTUChannel>().Where(it => it.sensorID != null).ToList();
            List<string> sensorIds = new List<string>();
            foreach (var Channel in Channels)
            {
                sensorIds.Add(Channel.sensorID);
            }
            sensorIds.Sort();
            return sensorIds;
        }
        public RTUChannel GetByDeviceIdAndId(string deviceId, int id)
        {
            return CurrentDb.GetSingle(it => it.deviceID == deviceId && it.ChannelID == id);
        }
        
        public int UpdateByEntity(RTUChannel Channel)
        {
            return Db.Updateable(Channel).ExecuteCommand();
        }
        /// <summary>
        /// 根据设备ID和通道ID更新通道传感器id和传感器数据库表名称
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public bool UpdateSensorIdAndTableNameByDeviceIdAndChannelId(string deviceId, int ChannelId, string sensorId, string tableName, string updateBy, DateTime updateTime)
        {
            return CurrentDb.Update(it => new RTUChannel() { sensorID = sensorId, sensorTableName = tableName, updateBy = updateBy, updateTime = updateTime }, it => it.deviceID == deviceId && it.ChannelID == ChannelId);
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
            List<RTUChannel> Channels = CurrentDb.GetList();
            int maxId = 0;
            foreach (RTUChannel Channel in Channels)
            {
                if (int.Parse(Channel.id) > maxId)
                {
                    maxId = int.Parse(Channel.id);
                }
            }
            return maxId;
        }
        public List<RTUChannel> GetBySensorId(string sensorId)
        {
            return Db.Queryable<RTUChannel>().Where(it => it.sensorID == sensorId).ToList();
        }
    }
}
