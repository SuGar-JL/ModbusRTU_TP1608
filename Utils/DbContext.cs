using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTU_TP1608.Utils
{
    class DbContext<T> where T : class, new()
    {
        public DbContext()
        {
            Db = new SqlSugarClient(new ConnectionConfig()
            {
                //ConnectionString = "server=.;uid=root;pwd=root;database=sensordb",
                ConnectionString = "user id=root;password=root;database=xboot;server=192.168.1.211;port=3306;charset=utf8",
                DbType = DbType.MySql,
                InitKeyType = InitKeyType.Attribute,//从特性读取主键和自增列信息
                IsAutoCloseConnection = true,//开启自动释放模式和EF原理一样我就不多解释了

            });
            //调式代码 用来打印SQL 
            Db.Aop.OnLogExecuting = (sql, pars) =>
            {
                Console.WriteLine(sql + "\r\n" +
                    Db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                Console.WriteLine();
            };

        }
        //注意：不能写成静态的
        public SqlSugarClient Db;//用来处理事务多表查询和复杂的操作
        public SimpleClient<T> CurrentDb { get { return new SimpleClient<T>(Db); } }//用来处理T表的常用操作


        public virtual T GetById(int id)
        {
            return CurrentDb.GetById(id);
        }
        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        public virtual List<T> GetList()
        {
            return CurrentDb.GetList();
        }

        /// <summary>
        /// 根据主键删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool Delete(dynamic id)
        {
            return CurrentDb.Delete(id);
        }
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public virtual bool Insert(T obj)
        {
            return CurrentDb.Insert(obj);
        }

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="objs"></param>
        /// <returns></returns>
        public virtual bool InsertRange(T[] objs)
        {
            return CurrentDb.InsertRange(objs);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool Update(T obj)
        {
            return CurrentDb.Update(obj);
        }

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool UpdateRange(T[] objs)
        {
            return CurrentDb.UpdateRange(objs);
        }
    }
}
