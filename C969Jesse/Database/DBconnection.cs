using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace C969Jesse.Database
{
	public class DBConnection
	{
		public static MySqlConnection conn { get; set; }

		public static void StartConnection()
		{
			string conStr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
			//make connection
			try
			{
				conn = new MySqlConnection(conStr);
				conn.Open();
			}
			catch (MySqlException ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		public static void CloseConnection()
		{
			try
			{
				if (conn != null)
				{
					conn.Close();
				}
				conn = null;
			}
			catch (MySqlException ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
