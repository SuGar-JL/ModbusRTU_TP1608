using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace ModbusRTU_TP1608.Utils
{
	class MySqlConnect
	{
		public static string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
		MySqlConnection Conn;
		public MySqlConnect()
		{
			this.Conn = new MySqlConnection(constr);
			this.Conn.Open();
		}

		MySqlCommand cmd = new MySqlCommand();
		public int RunNotQuery(string SQL)
		{
			int result;

			this.cmd.CommandText = SQL;
			this.cmd.Connection = this.Conn;
			result = this.cmd.ExecuteNonQuery();
			this.Conn.Close();

			return result;
		}



		public DataSet RunQuery(string SQL)
		{
			MySqlDataAdapter dataDB = new MySqlDataAdapter(SQL, this.Conn);
			DataSet data = new DataSet();
			dataDB.Fill(data);
			this.Conn.Close();
			for (int i = 0; i < data.Tables.Count; i++)
			{
				for (int j = 0; j < data.Tables[i].Rows.Count; j++)
				{
					for (int k = 0; k < data.Tables[i].Columns.Count; k++)
					{
						Console.Write(data.Tables[i].Rows[j][k] + "\t");
					}
					Console.WriteLine();
				}
				Console.WriteLine();
			}
			return data;
		}

	}
}
