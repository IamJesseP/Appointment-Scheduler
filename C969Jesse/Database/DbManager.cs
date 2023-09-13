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

        public void SaveData(Dictionary<string, string> customerData, bool isUpdate)
        {
            try
            {
                DbConnection.StartConnection();
                var conn = DbConnection.conn;
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        int countryId = SaveCountryData(customerData, conn, isUpdate);
                        int cityId = SaveCityData(customerData, conn, countryId, isUpdate);
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

        private int SaveCountryData(Dictionary<string, string> customerData, MySqlConnection conn, bool isUpdate)
        {
            int countryId;
            string query;

            if (isUpdate) 
            { 
                countryId = int.Parse(customerData["CountryId"]);
                query = Queries.CountryUpdateQuery;
            }
            else 
            { 
                using (var countryIndexCmd = new MySqlCommand(Queries.CountryIdxQuery, conn))
                {
                    countryId = Convert.ToInt32(countryIndexCmd.ExecuteScalar()) + 1;
                    query = Queries.CountryInsertQuery;
                }
            }

            using (var countryInsertCMD = new MySqlCommand(query, conn))
            {
                countryInsertCMD.Parameters.AddWithValue("@CountryId", countryId);
                countryInsertCMD.Parameters.AddWithValue("@Country", customerData["CustomerCountry"]);
                countryInsertCMD.Parameters.AddWithValue("@CreatedBy", UserSession.CurrentUserName);
                countryInsertCMD.Parameters.AddWithValue("@LastUpdateBy", UserSession.CurrentUserName);

                countryInsertCMD.Prepare();
                countryInsertCMD.ExecuteNonQuery();
            }

            return countryId;
        }
        private int SaveCityData(Dictionary<string, string> customerData, MySqlConnection conn, int latestCountryId, bool isUpdate)
        {
            int cityId;
            string query;

            if (isUpdate)
            {
                cityId = int.Parse(customerData["CityId"]);
                query = Queries.CountryUpdateQuery;
            }
            else
            {
                using (var cityIndexCmd = new MySqlCommand(Queries.CityIdxQuery, conn))
                {
                    cityId = Convert.ToInt32(cityIndexCmd.ExecuteScalar()) + 1;
                }
            }
            // TODO: Populate fields method, access all Ids', refactor rest of dbmanager
            using (var cityInsertCMD = new MySqlCommand(Queries.CityInsertQuery, conn))
            {
                cityInsertCMD.Parameters.AddWithValue("@CityId", cityId);
                cityInsertCMD.Parameters.AddWithValue("@City", customerData["CustomerCity"]);
                cityInsertCMD.Parameters.AddWithValue("@CountryId", latestCountryId);
                cityInsertCMD.Parameters.AddWithValue("@CreatedBy", UserSession.CurrentUserName);
                cityInsertCMD.Parameters.AddWithValue("@LastUpdateBy", UserSession.CurrentUserName);

                cityInsertCMD.Prepare();
                cityInsertCMD.ExecuteNonQuery();
            }

            return cityId;
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
