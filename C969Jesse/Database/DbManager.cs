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

        public void SaveData(Dictionary<string, string> customerData)
        {
            try
            {
                DbConnection.StartConnection();
                var conn = DbConnection.conn;
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        int countryId = SaveCountryData(customerData, conn);
                        int cityId = SaveCityData(customerData, conn, countryId);
                        int addressId = SaveAddressData(customerData, conn, cityId);
                        SaveCustomerData(customerData, conn, addressId);

                        transaction.Commit(); // Success? Commit
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
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
        }

        private int SaveCountryData(Dictionary<string, string> customerData, MySqlConnection conn)
        {
            int latestCountryId;
            using (var countryIndexCmd = new MySqlCommand(Queries.CountryIdxQuery, conn))
            {
                latestCountryId = Convert.ToInt32(countryIndexCmd.ExecuteScalar()) + 1;
            }
            using (var countryInsertCMD = new MySqlCommand(Queries.CountryInsertQuery, conn))
            {
                countryInsertCMD.Parameters.AddWithValue("@CountryId", latestCountryId);
                countryInsertCMD.Parameters.AddWithValue("@Country", customerData["CustomerCountry"]);
                countryInsertCMD.Parameters.AddWithValue("@CreatedBy", UserSession.CurrentUserName);
                countryInsertCMD.Parameters.AddWithValue("@LastUpdateBy", UserSession.CurrentUserName);

                countryInsertCMD.Prepare();
                countryInsertCMD.ExecuteNonQuery();
            }

            return latestCountryId;
        }
        private int SaveCityData(Dictionary<string, string> customerData, MySqlConnection conn, int latestCountryId)
        {
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
                cityInsertCMD.Parameters.AddWithValue("@CreatedBy", UserSession.CurrentUserName);
                cityInsertCMD.Parameters.AddWithValue("@LastUpdateBy", UserSession.CurrentUserName);

                cityInsertCMD.Prepare();
                cityInsertCMD.ExecuteNonQuery();
            }

            return latestCityId;
        }
        private int SaveAddressData(Dictionary<string, string> customerData, MySqlConnection conn, int latestCityId)
        {
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
                addressInsertCommand.Parameters.AddWithValue("@CreatedBy", UserSession.CurrentUserName);
                addressInsertCommand.Parameters.AddWithValue("@LastUpdateBy", UserSession.CurrentUserName);

                addressInsertCommand.Prepare();
                addressInsertCommand.ExecuteNonQuery();
            }

            return latestAddressId;
        }
        private void SaveCustomerData(Dictionary<string, string> customerData, MySqlConnection conn, int latestAddressId)
        {
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
                customerInsertCommand.Parameters.AddWithValue("@CreatedBy", UserSession.CurrentUserName);
                customerInsertCommand.Parameters.AddWithValue("@LastUpdateBy", UserSession.CurrentUserName);

                customerInsertCommand.Prepare();
                customerInsertCommand.ExecuteNonQuery();
            }
        }
    }
}
