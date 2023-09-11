using C969Jesse.Database;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Windows.Forms;
using System;
using System.Data.Common;

namespace C969Jesse.DataAccess
{
    public class CustomerDataAccess
    {
        public DataTable GetData()
        {
            DataTable dataTable = new DataTable();

           
            {
                try
                {
                    DBConnection.StartConnection();
                    string query = "SELECT " +
                                   "c.customerId, c.customerName, " +
                                   "a.addressId, a.address, a.phone, " +
                                   "ci.cityId AS city_cityId, ci.city, " +
                                   "co.countryId AS country_countryId, co.country " +
                                   "FROM customer c " +
                                   "JOIN address a ON c.addressId = a.addressId " +
                                   "JOIN city ci ON a.cityId = ci.cityId " +
                                   "JOIN country co ON ci.countryId = co.countryId";

                    using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn))
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    DBConnection.CloseConnection();
                }
            }

            return dataTable;
        }
    }
}
