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
	public class DBconnection
	{
		public static MySqlConnection conn { get; set; }

		public static void startConnection()
		{
			string conStr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
			//make connection
			MySqlConnection conn = null;
			try
			{
				conn = new MySqlConnection(conStr);
				conn.Open();
				MessageBox.Show("Connection is open");
			}
			catch (MySqlException ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		public static void closeConnection()
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
