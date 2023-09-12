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
                    "a.address, a.addressId, a.phone, " +
                    "ci.city, ci.cityId, " +
                    "co.country, co.countryId " +
                    "FROM customer c " +
                    "JOIN address a ON c.addressId = a.addressId " +
                    "JOIN city ci ON a.cityId = ci.cityId " +
                    "JOIN country co ON ci.countryId = co.countryId";


        public static string AppointmentQuery => "SELECT " +
                    "ap.appointmentId, ap.title, ap.description, ap.start, ap.end, ap.type, " +
                    "c.customerName, c.customerId, c.addressId, " +
                    "a.phone AS customerPhone, a.cityId, " +
                    "ci.countryId " +
                    "FROM appointment ap " +
                    "JOIN customer c ON ap.customerId = c.customerId " +
                    "JOIN address a ON c.addressId = a.addressId " +
                    "JOIN city ci ON a.cityId = ci.cityId " +
                    "JOIN country co ON ci.countryId = co.countryId " +
                    "JOIN user u ON ap.userId = u.userId " +
                    "ORDER BY ap.start";

        public static string CountryIdxQuery => "SELECT " + 
                 "countryId FROM country " + 
                 "ORDER BY countryId DESC LIMIT 1";

        public static string CountryInsertQuery => "INSERT INTO country " + 
                 "(countryId, country, createDate, createdBy, lastUpdate, lastUpdateBy) " + 
                 "VALUES (@CountryId, @Country, NOW(), @CreatedBy, NOW(), @LastUpdateBy)";

        public static string CityIdxQuery => "SELECT " +
                 "cityId FROM city " +
                 "ORDER BY cityId DESC LIMIT 1";

        public static string CityInsertQuery => "INSERT INTO city " +
                 "(cityId, city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                 "VALUES (@CityId, @City, @CountryId, NOW(), @CreatedBy, NOW(), @LastUpdateBy)";

        public static string AddressIdxQuery => "SELECT " +
                 "addressId FROM address " +
                 "ORDER BY addressId DESC LIMIT 1";

        public static string AddressInsertQuery => "INSERT INTO address " +
                 "(addressId, address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                 "VALUES (@AddressId, @Address, '', @CityId, @PostalCode, @PhoneNumber, NOW(), @CreatedBy, NOW(), @LastUpdateBy)";

        public static string CustomerIdxQuery => "SELECT " +
                 "customerId FROM customer " +
                 "ORDER BY customerId DESC LIMIT 1";

        public static string CustomerInsertQuery => "INSERT INTO customer " +
                 "(customerId, customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                 "VALUES (@CustomerId, @CustomerName, @AddressId, @Active, NOW(), @CreatedBy, NOW(), @LastUpdateBy)";

        public static string CountryUpdateQuery => "UPDATE country SET " +
                 "country = @Country, " +
                 "lastUpdate = NOW(), " +
                 "lastUpdateBy = @LastUpdateBy " +
                 "WHERE countryId = @CountryId";


    }
}

