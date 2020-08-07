using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ModbusRTU_TP1608.Utils
{
	class MySqlConnect
	{
		public string user, password, database, host, port, charset;
		MySqlConnection Conn;
		public MySqlConnect(
			string user = "",
			string password = "",
			string database = "",
			string host = "localhost",
			string port = "3306",
			string charset = "utf8"
		)
		{
			this.user = user;
			this.password = password;
			this.database = database;
			this.host = host;
			this.port = port;
			this.charset = charset;
			//使用了占位符{}
			this.Conn = new MySqlConnection(
				string.Format("user id={0};password={1};database={2};server={3};port={4};charset={5}",
				this.user, this.password, this.database, this.host, this.port, this.charset)
			);
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
