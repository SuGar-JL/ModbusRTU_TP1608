using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTU_TP1608.Utils
{
    class test
    {
        public void Main(string[] args)
        {
            MySqlConnect mySqlConnect = new MySqlConnect("root", "root", "car");
            string SQL = "select * from myCar";
            mySqlConnect.RunQuery(SQL);
        }
    }
}
