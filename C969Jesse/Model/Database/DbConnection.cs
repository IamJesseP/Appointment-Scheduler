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
	public class DbConnection
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

        public static bool InitializeDatabase()
        {
			bool isNewDb = false;
            try
            {
				StartConnection();

				MySqlCommand tableCMD = new MySqlCommand(Queries.CheckTablesExistQuery, conn);
                int tableCount = Convert.ToInt32(tableCMD.ExecuteScalar());

                MySqlCommand userCMD = new MySqlCommand(Queries.GetUserCount, conn);
                int userCount = Convert.ToInt32(userCMD.ExecuteScalar());
                if (tableCount < 6 || userCount == 0)  // If not all tables exist and no users exist, initialize the database
                {
                    MySqlCommand initCmd = new MySqlCommand(Queries.InitializeDatabaseQuery, conn);
                    initCmd.ExecuteNonQuery();
					isNewDb = true;
                }
				Console.WriteLine("Db exists");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
			return isNewDb;
        }
    }


}
