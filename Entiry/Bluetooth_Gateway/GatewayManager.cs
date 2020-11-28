using ModbusRTU_TP1608.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTU_TP1608.Entiry.Bluetooth_Gateway
{
    class GatewayManager : DbContext<Area_People_Num>
    {
        public void InsertOrUpdate(Area_People_Num area_People_Num)
        {
            var temp = Db.Queryable<Area_People_Num>().Where(it => it.Gateway == area_People_Num.Gateway).First();
            if (temp == null)
            {
                area_People_Num.createTime = DateTime.Now;
                area_People_Num.createBy = area_People_Num.Gateway;
                CurrentDb.Insert(area_People_Num);
                return;
            }
            CurrentDb.Update(it => new Area_People_Num() { Num_people = area_People_Num.Num_people, updateBy = area_People_Num.Gateway, updateTime = DateTime.Now }, it => it.Gateway == area_People_Num.Gateway);
        }
    }
}
