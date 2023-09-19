using C969Jesse.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969Jesse.Controller.Utils
{
    public class UserController
    {
        public Dictionary<int, string> GetUserNames()
        {
            Dictionary<int, string> userNames = new Dictionary<int, string>();

            try
            {
                DbConnection.StartConnection();

                using (var cmd = new MySqlCommand(Queries.GetUsersQuery, DbConnection.conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        userNames.Add(reader.GetInt32("userId"), reader.GetString("userName"));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DbConnection.CloseConnection();
            }

            return userNames;
        }
        
        //Requirement I: Each consultant schedule
        public DataTable GetConsultantSchedule(string userName, string userId)
        {
            DataTable dataTable = new DataTable();
            try
            {
                DbConnection.StartConnection();
                using (MySqlCommand consultantCMD = new MySqlCommand(Queries.GetUserScheduleQuery, DbConnection.conn))
                {
                    consultantCMD.Parameters.AddWithValue("@UserName", userName);
                    consultantCMD.Parameters.AddWithValue("@UserId", userId);
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(consultantCMD))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Error ID: 12121");
            }
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["start"] is DateTime startUtc)
                {
                    row["start"] = TimeZoneInfo.ConvertTimeFromUtc(startUtc, TimeZoneInfo.Local);
                }

                if (row["end"] is DateTime endUtc)
                {
                    row["end"] = TimeZoneInfo.ConvertTimeFromUtc(endUtc, TimeZoneInfo.Local);
                }
            }
            return dataTable;
        }
    }
}
