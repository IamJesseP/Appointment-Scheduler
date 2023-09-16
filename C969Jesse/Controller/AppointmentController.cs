using C969Jesse.Database;
using C969Jesse.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969Jesse.Controller
{
    // Requirement F
    public class AppointmentController
    {
        private DbManager dbManager = new DbManager();
        
        public List<string> GetAvailableSlots(DateTime date)
        {
            var allSlots = GenerateAllSlots(date);
            var bookedSlots = dbManager.GetBookedSlots(date);
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
        private bool IsSlotBooked(Tuple<DateTime, DateTime> slot, List<Tuple<DateTime, DateTime>> bookedSlots)
        {
            // Streamline the filtering calculation
            return bookedSlots.Any(bookedSlot => bookedSlot.Item1 < slot.Item2 && bookedSlot.Item2 > slot.Item1);
        }
        public void CheckUpcomingAppointment()
        {
            bool result;
            try
            {
                DbConnection.StartConnection();
                
                using (var upcomingAppointmentCMD = new MySqlCommand(Queries.upcomingAppointmentQuery, DbConnection.conn))
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
    }
}
