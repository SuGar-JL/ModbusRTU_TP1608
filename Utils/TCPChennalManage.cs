using ModbusRTU_TP1608.Entiry;
using ModbusTCP_TP1608.Entiry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTU_TP1608.Utils
{
    class TCPChannelManage : DbContext<TCPChannel>
    {
        /// <summary>
        /// 用构造方法创建数据库表
        /// </summary>
        public void CreateTable()
        {
            Db.CodeFirst.InitTables(typeof(TCPChannel));
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TCPChannel GetById(int id)
        {
            return CurrentDb.GetById(id);
        }

        public TCPChannel GetByName(string ChannelName)
        {
            return CurrentDb.GetSingle(it => it.ChannelName == ChannelName);
        }
        /// <summary>
        /// 根据设备ID查询对应的通道
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public List<TCPChannel> GetByDeviceId(string deviceId)
        {
            return Db.Queryable<TCPChannel>().Where(it => it.deviceID == deviceId).OrderBy(it => it.ChannelID).ToList();
        }

        /// <summary>
        /// 根据设备id和通道名称获取通道
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="ChannelName"></param>
        /// <returns></returns>
        public TCPChannel GetByDeviceIdAndName(string deviceId, string ChannelName)
        {
            return CurrentDb.GetSingle(it => it.deviceID == deviceId && it.ChannelName == ChannelName);
        }
        /// <summary>
        /// 根据id批量删除
        /// </summary>
        public int DeleteByIds(string[] ids)
        {
            return Db.Deleteable<TCPChannel>().In(ids).ExecuteCommand();
        }
        public List<string> GetSensorIds()
        {
            List<TCPChannel> Channels = Db.Queryable<TCPChannel>().Where(it => it.sensorID != null).ToList();
            List<string> sensorIds = new List<string>();
            foreach (var Channel in Channels)
            {
                sensorIds.Add(Channel.sensorID);
            }
            sensorIds.Sort();
            return sensorIds;
        }

        public TCPChannel GetByDeviceIdAndId(string deviceId, int id)
        {
            return CurrentDb.GetSingle(it => it.deviceID == deviceId && it.ChannelID == id);
        }

        public int UpdateByEntity(TCPChannel Channel)
        {
            return Db.Updateable(Channel).ExecuteCommand();
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
            List<TCPChannel> Channels = CurrentDb.GetList();
            int maxId = 0;
            foreach (TCPChannel Channel in Channels)
            {
                if (int.Parse(Channel.id) > maxId)
                {
                    maxId = int.Parse(Channel.id);
                }
            }
            return maxId;
        }

        public List<TCPChannel> GetBySensorId(string sensorId)
        {
            return Db.Queryable<TCPChannel>().Where(it => it.sensorID == sensorId).ToList();
        }
    }
}
