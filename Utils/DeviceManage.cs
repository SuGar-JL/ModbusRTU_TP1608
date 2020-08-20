using ModbusRTU_TP1608.Entiry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTU_TP1608.Utils
{
    class DeviceManage : DbContext<Device>
    {
        /// <summary>
        /// 用构造方法创建数据库表
        /// </summary>
        public DeviceManage()
        {
            Db.CodeFirst.InitTables(typeof(Device));
        }

        /// <summary>
        /// 通过设备ID查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Device GetById(string id)
        {
            return CurrentDb.GetSingle(it => it.id == id);

        }
        /// <summary>
        /// 通过设备名称查询
        /// </summary>
        /// <param name="deviceName"></param>
        /// <returns></returns>
        public Device GetByName(string deviceName)
        {
            return CurrentDb.GetSingle(it => it.deviceName == deviceName);
        }

        public List<Device> GetAllOrderById()
        {
            return Db.Queryable<Device>().OrderBy(it => it.createTime).ToList();
        }
        /// <summary>
        /// 根据设备ID更新设备配置
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public Device UpdateById(Device device)
        {
            //return CurrentDb.Update(it => device, it => it.deviceName == device.deviceName);//返回值为bool类型
            return (Device)CurrentDb.AsUpdateable(device).Where(it => it.id == device.id);
        }

        /// <summary>
        /// 根据设备ID更新设备配置（只更新属性设置页的字段）
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public bool UpdateConfigById(string deviceId, string deviceName, double storeInterval, double collectInterval, double dropTimeDelay, string port, string baudRate, string updateBy, DateTime updateTime)
        {
            return CurrentDb.Update(it => new Device() { deviceName = deviceName, storeInterval = storeInterval, collectInterval = collectInterval, dropTimeDelay = dropTimeDelay, port = port, baudRate = baudRate, updateBy = updateBy, updateTime = updateTime}, it => it.id == deviceId);
        }
        /// <summary>
        /// 根据设备id删除设备配置
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public bool DeleteById(string deviceId)
        {
            return CurrentDb.Delete(it => it.id == deviceId);
        }

        public bool UpdateStatusByName(string deviceName, int status)
        {
            return CurrentDb.Update(it => new Device() { status = status, updateBy = "打开设备", updateTime = DateTime.Now }, it => it.deviceName == deviceName);
        }
        /// <summary>
        /// 关闭软件，将所有设备的状态设为0，即关闭状态
        /// </summary>
        /// <returns></returns>
        public bool CloseAllOpendingDivice()
        {
            return CurrentDb.Update(it => new Device() { status = 0, updateBy = "关闭软件=>关闭设备", updateTime = DateTime.Now }, it => it.status != 0);
        }

        /// <summary>
        /// 获取表的最大id
        /// </summary>
        /// <returns></returns>
        public int GetMaxId()
        {
            List<Device> devices = CurrentDb.GetList();
            int maxId = 0;
            foreach (Device device in devices)
            {
                if (int.Parse(device.id) > maxId)
                {
                    maxId = int.Parse(device.id);
                }
            }
            return maxId;
        }
    }
}
