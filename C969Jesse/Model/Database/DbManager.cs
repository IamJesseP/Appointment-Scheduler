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
using System.Runtime.InteropServices;

namespace C969Jesse.Database
{
    public class DbManager
    {
        // Requirement G: lambda expression to simplify code for readability
        private int GetNewId(string query, MySqlConnection conn) => Convert.ToInt32(new MySqlCommand(query, conn).ExecuteScalar()) + 1;

        #region Data Getters
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
        public List<Tuple<DateTime, DateTime>> GetBookedSlots(DateTime date)
        {
            var bookedSlots = new List<Tuple<DateTime, DateTime>>();
            try
            {
                DbConnection.StartConnection();
                using (var cmd = new MySqlCommand(Queries.GetAppointmentStartEndQuery, DbConnection.conn))
                {
                    cmd.Parameters.AddWithValue("@Date", date.Date);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var start = reader.GetDateTime("start");
                            var end = reader.GetDateTime("end");
                            bookedSlots.Add(new Tuple<DateTime, DateTime>(start, end));
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

            return bookedSlots;
        }
        #endregion
        #region Add/Update/Delete Customer
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
                        using (var deleteCustomerCMD = new MySqlCommand(Queries.deleteCustomerQuery, DbConnection.conn))
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
        #endregion
        public void SaveAppointment(Dictionary<string, string> appointmentData, Dictionary<string, DateTime> startEndTime, bool isUpdate)
        {
            try
            {
                DbConnection.StartConnection();
                var conn = DbConnection.conn;
                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            int appointmentId;
                            string query;
                            if (isUpdate)
                            {
                                appointmentId = int.Parse(appointmentData["AppointmentId"]);
                                query = Queries.appointmentInsertQuery;
                            }
                            else
                            {
                                using (var countryIndexCmd = new MySqlCommand(Queries.CountryIdxQuery, conn))
                                {
                                    appointmentId = GetNewId(Queries.appointmentIdxQuery, conn);
                                    query = Queries.appointmentInsertQuery;
                                }
                            }
                                SaveAppointmentData(appointmentData, startEndTime, isUpdate, conn, appointmentId, query);
                                transaction.Commit();
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
        private static void SaveAppointmentData(Dictionary<string, string> appointmentData, Dictionary<string, DateTime> startEndTime, bool isUpdate, MySqlConnection conn, int appointmentId, string query)
        {
            using (var appointmentInsertCMD = new MySqlCommand(query, conn))
            {
                appointmentInsertCMD.Parameters.AddWithValue("@AppointmentId", appointmentId);
                appointmentInsertCMD.Parameters.AddWithValue("@CustomerId", appointmentData["CustomerId"]);
                appointmentInsertCMD.Parameters.AddWithValue("@UserId", appointmentData["UserId"]);
                appointmentInsertCMD.Parameters.AddWithValue("@Title", "not needed");
                appointmentInsertCMD.Parameters.AddWithValue("@Description", appointmentData["Description"]);
                appointmentInsertCMD.Parameters.AddWithValue("@Location", appointmentData["Location"]);
                appointmentInsertCMD.Parameters.AddWithValue("@Contact", appointmentData["ConsultantName"]);
                appointmentInsertCMD.Parameters.AddWithValue("@Type", appointmentData["VisitType"]);
                appointmentInsertCMD.Parameters.AddWithValue("@URL", "not needed");
                appointmentInsertCMD.Parameters.AddWithValue("@Start", startEndTime["StartTime"]);
                appointmentInsertCMD.Parameters.AddWithValue("@End", startEndTime["EndTime"]);
                appointmentInsertCMD.Parameters.AddWithValue("@LastUpdateBy", UserSession.CurrentUserName);

                if (!isUpdate) { appointmentInsertCMD.Parameters.AddWithValue("@CreatedBy", UserSession.CurrentUserName); }

                appointmentInsertCMD.Prepare();
                appointmentInsertCMD.ExecuteNonQuery();
            }
        }
    }
}
