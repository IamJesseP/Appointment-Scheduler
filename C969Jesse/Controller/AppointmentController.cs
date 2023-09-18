using C969Jesse.Database;
using C969Jesse.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace C969Jesse.Controller
{
    public class AppointmentController
    {
        // Requirement C
        #region Add/Update/Delete Appointment

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
                            query = Queries.appointmentUpdateQuery;
                        }
                        else
                        {
                            using (var countryIndexCmd = new MySqlCommand(Queries.CountryIdxQuery, conn))
                            {
                                appointmentId = GetNewId(Queries.AppointmentIdxQuery, conn);
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
        private void SaveAppointmentData(Dictionary<string, string> appointmentData, Dictionary<string, DateTime> startEndTime, bool isUpdate, MySqlConnection conn, int appointmentId, string query)
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
        public void DeleteAppointment(int appointmentId)
        {
            try
            {
                DbConnection.StartConnection();
                var conn = DbConnection.conn;
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        using (var deleteAppointmentCMD = new MySqlCommand(Queries.DeleteAppointmentQuery, DbConnection.conn))
                        {
                            deleteAppointmentCMD.Parameters.AddWithValue("@AppointmentId", appointmentId);
                            deleteAppointmentCMD.Prepare();
                            deleteAppointmentCMD.ExecuteNonQuery();
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
        public void CheckUpcomingAppointment()
        {
            bool result;
            try
            {
                DbConnection.StartConnection();
                
                using (var upcomingAppointmentCMD = new MySqlCommand(Queries.UpcomingAppointmentQuery, DbConnection.conn))
                {
                    var currentTime = DateTime.UtcNow;
                    upcomingAppointmentCMD.Parameters.AddWithValue("@userId", UserSession.CurrentUserId);
                    upcomingAppointmentCMD.Parameters.AddWithValue("@currentTime", currentTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    int upcomingAppointmentCount = Convert.ToInt32(upcomingAppointmentCMD.ExecuteScalar());

                    result = upcomingAppointmentCount > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DbConnection.CloseConnection();
            }
    
            if (result)
            {
                MessageBox.Show("You have an upcoming appointment.");
            }
        }
        public Dictionary<string, DateTime> ConvertStringToDateTime(DateTime selectedDate, string selectedTimeStr)
        {
            // Split string and Parse
            string[] times = selectedTimeStr.Split(new[] { " - " }, StringSplitOptions.None);
            DateTime startTime = DateTime.ParseExact(times[0], "HH:mm", null);
            DateTime endTime = DateTime.ParseExact(times[1], "HH:mm", null);

            // Combine the date string from selectedDate and the time strings from startTime and endTime
            DateTime startDateTime = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, startTime.Hour, startTime.Minute, 0);
            DateTime endDateTime = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, endTime.Hour, endTime.Minute, 0);

            // Requirement E: Convert to UTC for database saving/updating
            DateTime startDateTimeUTC = startDateTime.ToUniversalTime();
            DateTime endDateTimeUTC = endDateTime.ToUniversalTime();

            return new Dictionary<string, DateTime> { { "StartTime", startDateTimeUTC }, {"EndTime", endDateTimeUTC } };
        }
        private List<string> ConvertSlotsToString(List<Tuple<DateTime, DateTime>> availableSlots)
        {
            TimeZoneInfo localZone = TimeZoneInfo.Local;

            // Requirement E: Convert UTC slots to user's local time zone and then to string for display in Add/Update form
            return availableSlots.Select(slot =>
            $"{TimeZoneInfo.ConvertTimeFromUtc(slot.Item1, localZone):HH:mm} - {TimeZoneInfo.ConvertTimeFromUtc(slot.Item2, localZone):HH:mm}")
            .ToList();
            
        }
        private List<Tuple<DateTime, DateTime>> GenerateAllSlots(DateTime date)
        {
            TimeZoneInfo pstZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
            // Requirement F: Time slots will be from business hours 9-5 PST
            var allSlots = new List<Tuple<DateTime, DateTime>>();

            // Create date with PST time zone
            DateTime startHourPST = TimeZoneInfo.ConvertTime(new DateTime(date.Year, date.Month, date.Day, 9, 0, 0), pstZone);
            DateTime endHourPST = TimeZoneInfo.ConvertTime(new DateTime(date.Year, date.Month, date.Day, 17, 0, 0), pstZone);

            // Convert PST time slots to UTC for use in available slot calculations
            DateTime startHour = TimeZoneInfo.ConvertTimeToUtc(startHourPST, pstZone);
            DateTime endHour = TimeZoneInfo.ConvertTimeToUtc(endHourPST, pstZone);

            while (startHour < endHour)
            {
                allSlots.Add(new Tuple<DateTime, DateTime>(startHour, startHour.AddMinutes(30)));
                startHour = startHour.AddMinutes(30);
            }

            return allSlots;
        }

        // Requirement G: lambda expression to simplify code for readability
        private int GetNewId(string query, MySqlConnection conn) => Convert.ToInt32(new MySqlCommand(query, conn).ExecuteScalar()) + 1;
        private bool IsSlotBooked(Tuple<DateTime, DateTime> slot, List<Tuple<DateTime, DateTime>> bookedSlots)
        {
            // Streamline the filtering calculation
            return bookedSlots.Any(bookedSlot => bookedSlot.Item1 < slot.Item2 && bookedSlot.Item2 > slot.Item1);
        }

        #endregion

        #region Data Getters

        public DataTable GetAppointmentTypesByMonthReport(int month, int year)
        {
            DbConnection.StartConnection();

            DataTable dataTable = new DataTable();

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(Queries.AppointmentTypeByMonthQuery, DbConnection.conn))
                {
                     cmd.Parameters.AddWithValue("@month", month);
                     cmd.Parameters.AddWithValue("@year", year);

                     using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                     {
                         adapter.Fill(dataTable);
                     }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { DbConnection.CloseConnection(); }
            return dataTable;
        }
        public DataTable GetAppointmentCountByLocation()
        {
            DbConnection.StartConnection();

            DataTable dataTable = new DataTable();

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(Queries.AppointmentCountByLocationQuery, DbConnection.conn))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DbConnection.CloseConnection();
            }

            return dataTable;
        }

        public List<string> GetAvailableSlots(DateTime date)
        {
            var allSlots = GenerateAllSlots(date);
            var bookedSlots = GetBookedSlots(date);
            if (bookedSlots == null)
            {
                // Create an empty list instead of null, if all appointment times are open
                bookedSlots = new List<Tuple<DateTime, DateTime>>(); 
            }
            // Requirement G: using lambda expressions here to streamline the filtering and
            // transformation of the available slots list
            var availableSlots = allSlots.Where(slot => !IsSlotBooked(slot, bookedSlots)).ToList();
            var availableSlotsString = ConvertSlotsToString(availableSlots);

            return availableSlotsString;
        }
        public DataTable GetAppointments(string filter)
        {
            DataTable dataTable = new DataTable();
            try
            {
                DateTime today = DateTime.Now;
                DateTime startDate = DateTime.MinValue;
                DateTime endDate = DateTime.MaxValue;

                DbConnection.StartConnection();
                var conn = DbConnection.conn;

                if (filter == "Weekly")
                {
                    // Get current weekly date
                    int delta = DayOfWeek.Monday - today.DayOfWeek;
                    startDate = today.AddDays(delta).Date;
                    endDate = startDate.AddDays(6).AddHours(23).AddMinutes(59).AddSeconds(59);
                }
                else if (filter == "Monthly")
                {
                    // Get current monthly date
                    startDate = new DateTime(today.Year, today.Month, 1);
                    endDate = startDate.AddMonths(1).AddDays(-1).AddHours(23).AddMinutes(59).AddSeconds(59);
                }

                // Requirement D: Get filtered appointments
                if (filter == "All")
                {
                    using (MySqlCommand cmd = new MySqlCommand(Queries.GetAppointmentTableQuery, DbConnection.conn))
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
                else
                {
                    using (MySqlCommand cmd = new MySqlCommand(Queries.GetFilteredAppointmentsQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@StartDate", startDate.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@EndDate", endDate.ToString("yyyy-MM-dd HH:mm:ss"));

                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        adapter.Fill(dataTable);
                    }
                }
                // Requirement E: Convert start and end columns to local time
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
    }
}
