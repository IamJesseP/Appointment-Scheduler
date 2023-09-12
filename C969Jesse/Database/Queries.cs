using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969Jesse.Database
{
    public static class Queries
    {
        public static string CustomerQuery => "SELECT " +
                 "c.customerId, c.customerName, " +
                 "a.address, a.phone, " +
                 "ci.city, " +
                 "co.country " +
                 "FROM customer c " +
                 "JOIN address a ON c.addressId = a.addressId " +
                 "JOIN city ci ON a.cityId = ci.cityId " +
                 "JOIN country co ON ci.countryId = co.countryId";

        public static string AppointmentQuery => "SELECT " +
                 "ap.appointmentId, ap.title, ap.description, ap.start, ap.end, ap.type, " +
                 "c.customerName, c.customerId, a.phone AS customerPhone " +
                 "FROM appointment ap " +
                 "JOIN customer c ON ap.customerId = c.customerId " +
                 "JOIN address a ON c.addressId = a.addressId " +
                 "JOIN user u ON ap.userId = u.userId " +
                 "ORDER BY ap.start";
    }
}

