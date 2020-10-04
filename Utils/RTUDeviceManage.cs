using ModbusRTU_TP1608.Entiry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTU_TP1608.Utils
{
    class RTUDeviceManage : DbContext<RTUDevice>
    {
        
        public void CreateTable()
        {
            //创建设备信息表
            Db.CodeFirst.InitTables(typeof(RTUDevice));
        }
        /// <summary>
        /// 通过设备ID查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RTUDevice GetById(string id)
        {
            //return CurrentDb.GetSingle(it => it.id == id);
            return Db.Queryable<RTUDevice>().Where(it => it.id == id).First();

        }
        /// <summary>
        /// 通过设备名称查询
        /// </summary>
        /// <param name="deviceName"></param>
        /// <returns></returns>
        public RTUDevice GetByName(string deviceName)
        {
            //return CurrentDb.GetSingle(it => it.deviceName == deviceName);
            return Db.Queryable<RTUDevice>().Where(it => it.deviceName == deviceName).First();
        }
        /// <summary>
        /// 通过设备地址查询
        /// </summary>
        /// <param name="deviceAddress"></param>
        /// <returns></returns>
        public RTUDevice GetByAddress(string deviceAddress)
        {
            //return CurrentDb.GetSingle(it => it.deviceAddress == deviceAddress);
            return Db.Queryable<RTUDevice>().Where(it => it.deviceAddress == deviceAddress).First();
        }

        public int GetPageIndexs()
        {
            List<RTUDevice> devices = Db.Queryable<RTUDevice>().OrderBy(it => it.pageIndex).ToList();
            //当没有设备时，用1作为pageIndex
            if (devices.Count == 0)
            {
                return 1;
            }
            List<int> indexs = new List<int>();
            foreach (var item in devices)
            {
                indexs.Add((int)item.pageIndex);
            }
            //一下操作是为了在有删除设备的情景下，indexs中的值（pageIndex）不是连续的，在新建设备时，可取被跳过的数作为pageIndex
            int index = -1;
            for (int i = 1; i < indexs.Max(); i++)
            {
                if (!indexs.Contains(i))
                {
                    index = i;
                    //找到一个就停止
                    break;
                }
            }
            //当indexs中的值（pageIndex）是连续的时，用最大值+1作为pageIndex
            if (index == -1)
            {
                index = indexs.Max() + 1;
            }
            return index;
        }
        public List<RTUDevice> GetAllOrderByCreateTime()
        {
            return Db.Queryable<RTUDevice>().OrderBy(it => it.createTime).ToList();
        }
        /// <summary>
        /// 根据设备ID更新设备配置
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public RTUDevice UpdateById(RTUDevice device)
        {
            //return CurrentDb.Update(it => device, it => it.deviceName == device.deviceName);//返回值为bool类型
            return (RTUDevice)CurrentDb.AsUpdateable(device).Where(it => it.id == device.id);
        }

        /// <summary>
        /// 根据设备ID更新设备配置（只更新属性设置页的字段）
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public bool UpdateConfigById(string deviceId, string deviceName, double storeInterval, double collectInterval, double dropTimeDelay, string port, string baudRate, string updateBy, DateTime updateTime)
        {
            return CurrentDb.Update(it => new RTUDevice() { deviceName = deviceName, /*storeInterval = storeInterval, collectInterval = collectInterval, dropTimeDelay = dropTimeDelay,*/ serialPort = port, baudRate = baudRate, updateBy = updateBy, updateTime = updateTime}, it => it.id == deviceId);
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
            return CurrentDb.Update(it => new RTUDevice() { status = status, updateBy = "打开设备", updateTime = DateTime.Now }, it => it.deviceName == deviceName);
        }
        /// <summary>
        /// 关闭软件，将所有设备的状态设为0，即关闭状态
        /// </summary>
        /// <returns></returns>
        public bool CloseAllOpendingDivice()
        {
            return CurrentDb.Update(it => new RTUDevice() { status = 0, updateBy = "关闭软件=>关闭设备", updateTime = DateTime.Now }, it => it.status != 0);
        }

        /// <summary>
        /// 获取表的最大id
        /// </summary>
        /// <returns></returns>
        public int GetMaxId()
        {
            List<RTUDevice> devices = CurrentDb.GetList();
            int maxId = 0;
            foreach (RTUDevice device in devices)
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
