using C969Jesse.Database;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Windows.Forms;
using System;
using System.Data.Common;
using System.Xml.Linq;
using C969Jesse.Utils;
using System.Collections.Generic;

namespace C969Jesse.Database
{
    public class DbManager
    {
        public DataTable GetData(string query)
        {
            DataTable dataTable = new DataTable();

            try
            {
                DbConnection.StartConnection();

                using (MySqlCommand cmd = new MySqlCommand(query, DbConnection.conn))
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
                DbConnection.CloseConnection();
            }

            return dataTable;
        }

        public void SaveCustomerData(Dictionary<string, string> customerData)
        {
            try
            {
                DbConnection.StartConnection();
                var conn = DbConnection.conn;
                var currentUser = UserSession.CurrentUserName;

                //Country Queries
                int latestCountryId;
                using (var countryIndexCmd = new MySqlCommand(Queries.CountryIdxQuery, conn))
                {
                   latestCountryId = Convert.ToInt32(countryIndexCmd.ExecuteScalar()) + 1;
                }
                using (var countryInsertCMD = new MySqlCommand(Queries.CountryInsertQuery, conn))
                {
                    countryInsertCMD.Parameters.AddWithValue("@CountryId", latestCountryId);
                    countryInsertCMD.Parameters.AddWithValue("@Country", customerData["CustomerCountry"]);
                    countryInsertCMD.Parameters.AddWithValue("@CreatedBy", currentUser);
                    countryInsertCMD.Parameters.AddWithValue("@LastUpdateBy", currentUser);

                    countryInsertCMD.Prepare();
                    countryInsertCMD.ExecuteNonQuery();
                }
                // City Queries
                int latestCityId;
                using (var cityIndexCmd = new MySqlCommand(Queries.CityIdxQuery, conn))
                {
                    latestCityId = Convert.ToInt32(cityIndexCmd.ExecuteScalar()) + 1;
                }
                using (var cityInsertCMD = new MySqlCommand(Queries.CityInsertQuery, conn))
                {
                    cityInsertCMD.Parameters.AddWithValue("@CityId", latestCityId);
                    cityInsertCMD.Parameters.AddWithValue("@City", customerData["CustomerCity"]);
                    cityInsertCMD.Parameters.AddWithValue("@CountryId", latestCountryId);
                    cityInsertCMD.Parameters.AddWithValue("@CreatedBy", currentUser);
                    cityInsertCMD.Parameters.AddWithValue("@LastUpdateBy", currentUser);

                    cityInsertCMD.Prepare();
                    cityInsertCMD.ExecuteNonQuery();
                }
                // Address Queries
                int latestAddressId;
                using (var addressIndexCmd = new MySqlCommand(Queries.AddressIdxQuery, conn))
                {
                    latestAddressId = Convert.ToInt32(addressIndexCmd.ExecuteScalar()) + 1;
                }
                using (var addressInsertCommand = new MySqlCommand(Queries.AddressInsertQuery, conn))
                {
                    addressInsertCommand.Parameters.AddWithValue("@AddressId", latestAddressId);
                    addressInsertCommand.Parameters.AddWithValue("@Address", customerData["CustomerAddress"]);
                    addressInsertCommand.Parameters.AddWithValue("@PostalCode", customerData["CustomerPostal"]);
                    addressInsertCommand.Parameters.AddWithValue("@PhoneNumber", customerData["CustomerPhone"]); 
                    addressInsertCommand.Parameters.AddWithValue("@CityId", latestCityId);
                    addressInsertCommand.Parameters.AddWithValue("@CreatedBy", currentUser);
                    addressInsertCommand.Parameters.AddWithValue("@LastUpdateBy", currentUser);

                    addressInsertCommand.Prepare();
                    addressInsertCommand.ExecuteNonQuery();
                }
                // Customer Queries
                int latestCustomerId;
                using (var customerIndexCmd = new MySqlCommand(Queries.CustomerIdxQuery, conn))
                {
                    latestCustomerId = Convert.ToInt32(customerIndexCmd.ExecuteScalar()) + 1;
                }
                using (var customerInsertCommand = new MySqlCommand(Queries.CustomerInsertQuery, conn))
                {
                    customerInsertCommand.Parameters.AddWithValue("@CustomerId", latestCustomerId);
                    customerInsertCommand.Parameters.AddWithValue("@CustomerName", customerData["CustomerName"]);
                    customerInsertCommand.Parameters.AddWithValue("@AddressId", latestAddressId);
                    customerInsertCommand.Parameters.AddWithValue("@Active", 1);
                    customerInsertCommand.Parameters.AddWithValue("@CreatedBy", currentUser);
                    customerInsertCommand.Parameters.AddWithValue("@LastUpdateBy", currentUser);

                    customerInsertCommand.Prepare();
                    customerInsertCommand.ExecuteNonQuery();
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
        }
    }
}
