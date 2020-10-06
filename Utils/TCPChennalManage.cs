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
    class TCPChennalManage : DbContext<TCPChennal>
    {
        /// <summary>
        /// 用构造方法创建数据库表
        /// </summary>
        public void CreateTable()
        {
            Db.CodeFirst.InitTables(typeof(TCPChennal));
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TCPChennal GetById(int id)
        {
            return CurrentDb.GetById(id);
        }

        public TCPChennal GetByName(string chennalName)
        {
            return CurrentDb.GetSingle(it => it.chennalName == chennalName);
        }
        /// <summary>
        /// 根据设备ID查询对应的通道
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public List<TCPChennal> GetByDeviceId(string deviceId)
        {
            return Db.Queryable<TCPChennal>().Where(it => it.deviceID == deviceId).OrderBy(it => it.chennalID).ToList();
        }

        /// <summary>
        /// 根据设备id和通道名称获取通道
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="chennalName"></param>
        /// <returns></returns>
        public TCPChennal GetByDeviceIdAndName(string deviceId, string chennalName)
        {
            return CurrentDb.GetSingle(it => it.deviceID == deviceId && it.chennalName == chennalName);
        }
        /// <summary>
        /// 根据id批量删除
        /// </summary>
        public int DeleteByIds(string[] ids)
        {
            return Db.Deleteable<TCPChennal>().In(ids).ExecuteCommand();
        }
        public List<string> GetSensorIds()
        {
            List<TCPChennal> chennals = Db.Queryable<TCPChennal>().Where(it => it.sensorID != null).ToList();
            List<string> sensorIds = new List<string>();
            for (int i = 0; i < chennals.Count; i++)
            {
                sensorIds.Append(chennals[i].sensorID);
            }
            sensorIds.Sort();
            return sensorIds;
        }

        public TCPChennal GetByDeviceIdAndId(string deviceId, int id)
        {
            return CurrentDb.GetSingle(it => it.deviceID == deviceId && it.chennalID == id);
        }

        public int UpdateByEntity(TCPChennal chennal)
        {
            return Db.Updateable(chennal).ExecuteCommand();
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
            List<TCPChennal> chennals = CurrentDb.GetList();
            int maxId = 0;
            foreach (TCPChennal chennal in chennals)
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
