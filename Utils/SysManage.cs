using ModbusRTU_TP1608.Entiry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ModbusRTU_TP1608.Utils
{
    class SysManage: DbContext<Sys>
    {
        public void CreateTable()
        {
            //创建设备信息表
           
            Db.CodeFirst.InitTables(typeof(Sys));
            
            //如果sys表是空的插入一条记录（初始化系统信息）
            if (this.GetSysInfo().Count == 0)
            {
                Sys sys = new Sys();
                sys.createBy = "管理员";
                sys.createTime = DateTime.Now;
                //默认没有使用任何通信协议
                sys.protocol = 0;
                this.Insert(sys);
            }
        }
        /// <summary>
        /// 获取全部系统信息（其实只有一条）
        /// </summary>
        /// <returns></returns>
        public List<Sys> GetSysInfo()
        {
            return CurrentDb.GetList();
        }
        /// <summary>
        /// 更新系统信息
        /// </summary>
        /// <param name="protocol"></param>
        /// <returns></returns>
        public bool UpdateSysInfo(Sys sys)
        {
            return CurrentDb.Update(it => new Sys() { protocol = sys.protocol, updateBy = sys.updateBy, updateTime = sys.updateTime}, it => it.id == sys.id);
        }

    }
}
