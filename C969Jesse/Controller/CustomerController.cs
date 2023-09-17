using C969Jesse.Database;
using C969Jesse.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969Jesse.Controller
{
    public class CustomerController
    {

        // Requirement B
        #region Add/Update/Delete Customer

        public void SaveCustomer(Dictionary<string, string> customerData, bool isUpdate)
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
                        int addressId = SaveAddressData(customerData, conn, cityId, isUpdate);
                        SaveCustomerNameData(customerData, conn, addressId, isUpdate);

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
                MessageBox.Show(ex.Message + "test");
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
                    countryId = GetNewId(Queries.CountryIdxQuery, conn);
                    query = Queries.CountryInsertQuery;
                }
            }

            using (var countryInsertCMD = new MySqlCommand(query, conn))
            {
                countryInsertCMD.Parameters.AddWithValue("@CountryId", countryId);
                countryInsertCMD.Parameters.AddWithValue("@Country", customerData["CustomerCountry"]);
                countryInsertCMD.Parameters.AddWithValue("@LastUpdateBy", UserSession.CurrentUserName);
                if (!isUpdate) { countryInsertCMD.Parameters.AddWithValue("@CreatedBy", UserSession.CurrentUserName); }

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
                query = Queries.CityUpdateQuery;
            }
            else
            {
                using (var cityIndexCmd = new MySqlCommand(Queries.CityIdxQuery, conn))
                {
                    cityId = GetNewId(Queries.CityIdxQuery, conn);
                    query = Queries.CityInsertQuery;
                }
            }
            using (var cityInsertCMD = new MySqlCommand(query, conn))
            {
                cityInsertCMD.Parameters.AddWithValue("@CityId", cityId);
                cityInsertCMD.Parameters.AddWithValue("@City", customerData["CustomerCity"]);
                cityInsertCMD.Parameters.AddWithValue("@CountryId", latestCountryId);
                cityInsertCMD.Parameters.AddWithValue("@LastUpdateBy", UserSession.CurrentUserName);

                if (!isUpdate) { cityInsertCMD.Parameters.AddWithValue("@CreatedBy", UserSession.CurrentUserName); }

                cityInsertCMD.Prepare();
                cityInsertCMD.ExecuteNonQuery();
            }

            return cityId;
        }
        private int SaveAddressData(Dictionary<string, string> customerData, MySqlConnection conn, int latestCityId, bool isUpdate)
        {
            int addressId;
            string query;

            if (isUpdate)
            {
                addressId = int.Parse(customerData["AddressId"]);
                query = Queries.AddressUpdateQuery;
            }
            else
            {
                using (var addressIndexCmd = new MySqlCommand(Queries.AddressIdxQuery, conn))
                {
                    addressId = GetNewId(Queries.AddressIdxQuery, conn);
                    query = Queries.AddressInsertQuery;
                }
            }
            using (var addressInsertCommand = new MySqlCommand(query, conn))
            {
                addressInsertCommand.Parameters.AddWithValue("@AddressId", addressId);
                addressInsertCommand.Parameters.AddWithValue("@Address", customerData["CustomerAddress"]);
                addressInsertCommand.Parameters.AddWithValue("@PostalCode", customerData["CustomerPostal"]);
                addressInsertCommand.Parameters.AddWithValue("@PhoneNumber", customerData["CustomerPhone"]);
                addressInsertCommand.Parameters.AddWithValue("@CityId", latestCityId);
                addressInsertCommand.Parameters.AddWithValue("@LastUpdateBy", UserSession.CurrentUserName);
                if (!isUpdate) { addressInsertCommand.Parameters.AddWithValue("@CreatedBy", UserSession.CurrentUserName); };

                addressInsertCommand.Prepare();
                addressInsertCommand.ExecuteNonQuery();
            }

            return addressId;
        }
        private void SaveCustomerNameData(Dictionary<string, string> customerData, MySqlConnection conn, int latestAddressId, bool isUpdate)
        {
            int customerId;
            string query;

            if (isUpdate)
            {
                customerId = int.Parse(customerData["CustomerId"]);
                query = Queries.CustomerUpdateQuery;
            }
            else
            {
                using (var customerIndexCmd = new MySqlCommand(Queries.CustomerIdxQuery, conn))
                {
                    customerId = GetNewId(Queries.CountryIdxQuery, conn);
                    query = Queries.CustomerInsertQuery;
                }
            }
            using (var customerInsertCommand = new MySqlCommand(query, conn))
            {
                customerInsertCommand.Parameters.AddWithValue("@CustomerId", customerId);
                customerInsertCommand.Parameters.AddWithValue("@CustomerName", customerData["CustomerName"]);
                customerInsertCommand.Parameters.AddWithValue("@AddressId", latestAddressId);
                customerInsertCommand.Parameters.AddWithValue("@Active", 1);
                customerInsertCommand.Parameters.AddWithValue("@LastUpdateBy", UserSession.CurrentUserName);
                if (!isUpdate) { customerInsertCommand.Parameters.AddWithValue("@CreatedBy", UserSession.CurrentUserName); };

                customerInsertCommand.Prepare();
                customerInsertCommand.ExecuteNonQuery();
            }
        }
        public void DeleteCustomer(int customerId)
        {
            try
            {
                DbConnection.StartConnection();
                var conn = DbConnection.conn;
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        using (var deleteAppointmentsCMD = new MySqlCommand(Queries.DeleteCustomerAppointmentsQuery, conn))
                        {
                            deleteAppointmentsCMD.Parameters.AddWithValue("@CustomerId", customerId);
                            deleteAppointmentsCMD.ExecuteNonQuery();
                        }

                        using (var deleteCustomerCMD = new MySqlCommand(Queries.DeleteCustomerQuery, DbConnection.conn))
                        {
                            deleteCustomerCMD.Parameters.AddWithValue("@CustomerId", customerId);
                            deleteCustomerCMD.Prepare();
                            deleteCustomerCMD.ExecuteNonQuery();
                        }
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

        #endregion

        #region Helper Methods
        // Requirement G: lambda expression to simplify code for readability
        private int GetNewId(string query, MySqlConnection conn) => Convert.ToInt32(new MySqlCommand(query, conn).ExecuteScalar()) + 1;

        #endregion

        #region Data Getters
        public DataTable GetCustomers(string query)
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
        public Dictionary<int, string> GetCustomerNames()
        {
            Dictionary<int, string> customerNames = new Dictionary<int, string>();
            try
            {
                DbConnection.StartConnection();
                using (MySqlCommand cmd = new MySqlCommand(Queries.GetCustomersQuery, DbConnection.conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customerNames.Add(reader.GetInt32("customerId"), reader.GetString("customerName"));
                        }
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
            return customerNames;
        }
        #endregion
    }
}
