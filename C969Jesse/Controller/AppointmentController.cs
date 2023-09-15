using C969Jesse.Database;
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
        private List<Tuple<DateTime, DateTime>> GenerateAllSlots(DateTime date)
        {   
            // Time slots will be from business hours 9-5
            var allSlots = new List<Tuple<DateTime, DateTime>>();
            DateTime startHour = new DateTime(date.Year, date.Month, date.Day, 9, 0, 0);
            DateTime endHour = new DateTime(date.Year, date.Month, date.Day, 17, 0, 0);

            while (startHour < endHour)
            {
                allSlots.Add(new Tuple<DateTime, DateTime>(startHour, startHour.AddMinutes(30)));
                startHour = startHour.AddMinutes(30);
            }

            return allSlots;
        }

        #region Helper functions
        private bool IsSlotBooked(Tuple<DateTime, DateTime> slot, List<Tuple<DateTime, DateTime>> bookedSlots)
        {
            // Streamline the filtering 
            return bookedSlots.Any(bookedSlot => bookedSlot.Item1 < slot.Item2 && bookedSlot.Item2 > slot.Item1);
        }
        private List<string> ConvertSlotsToString(List<Tuple<DateTime, DateTime>> availableSlots)
        {
            // Streamline string transformation
            return availableSlots.Select(slot => $"{slot.Item1:HH:mm} - {slot.Item2:HH:mm}").ToList();
        }
        #endregion

        public Dictionary<string, DateTime> ConvertStringToDateTime(DateTime selectedDate, string selectedTimeStr)
        {
            // Split string and Parse
            string[] times = selectedTimeStr.Split(new[] { " - " }, StringSplitOptions.None);
            DateTime startTime = DateTime.ParseExact(times[0], "HH:mm", null);
            DateTime endTime = DateTime.ParseExact(times[1], "HH:mm", null);

            // Combine the date part from selectedDate and the time part from startTime and endTime
            DateTime startDateTime = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, startTime.Hour, startTime.Minute, 0);
            DateTime endDateTime = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, endTime.Hour, endTime.Minute, 0);

            return new Dictionary<string, DateTime> { { "StartTime", startDateTime }, {"EndTime", endDateTime } };
        }
    }
}
