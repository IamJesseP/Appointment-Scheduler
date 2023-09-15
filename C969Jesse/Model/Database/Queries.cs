using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969Jesse.Database
{
    public static class Queries
    {
        #region Customer Queries
        #region Get Table Queries
        public static string GetCustomerTableQuery => "SELECT " +
                    "c.customerId, c.customerName, " +
                    "a.address, a.addressId, a.postalCode, a.phone, " +
                    "ci.city, ci.cityId, " +
                    "co.country, co.countryId " +
                    "FROM customer c " +
                    "JOIN address a ON c.addressId = a.addressId " +
                    "JOIN city ci ON a.cityId = ci.cityId " +
                    "JOIN country co ON ci.countryId = co.countryId";
        #endregion
        #region Delete Row Queries
        public static string deleteCustomerQuery => "DELETE FROM customer WHERE customerId = @CustomerId";
        #endregion
        #region Country Queries
        public static string CountryIdxQuery => "SELECT " + 
                 "countryId FROM country " + 
                 "ORDER BY countryId DESC LIMIT 1";
        public static string CountryInsertQuery => "INSERT INTO country " + 
                 "(countryId, country, createDate, createdBy, lastUpdate, lastUpdateBy) " + 
                 "VALUES (@CountryId, @Country, NOW(), @CreatedBy, NOW(), @LastUpdateBy)";

        public static string CountryUpdateQuery => "UPDATE country SET " +
                 "country = @Country, " +
                 "lastUpdate = NOW(), " +
                 "lastUpdateBy = @LastUpdateBy " +
                 "WHERE countryId = @CountryId";


        #endregion
        #region City Queries
        public static string CityIdxQuery => "SELECT " +
                 "cityId FROM city " +
                 "ORDER BY cityId DESC LIMIT 1";
        public static string CityInsertQuery => "INSERT INTO city " +
                 "(cityId, city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                 "VALUES (@CityId, @City, @CountryId, NOW(), @CreatedBy, NOW(), @LastUpdateBy)";
        public static string CityUpdateQuery => "UPDATE city SET " +
                "city = @City, " +
                "countryId = @CountryId, " +
                "lastUpdate = NOW(), " +
                "lastUpdateBy = @LastUpdateBy " +
                "WHERE cityId = @CityId";

        #endregion
        #region Address Queries
        public static string AddressIdxQuery => "SELECT " +
                "addressId FROM address " +
                "ORDER BY addressId DESC LIMIT 1";
        public static string AddressInsertQuery => "INSERT INTO address " +
                "(addressId, address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                "VALUES (@AddressId, @Address, '', @CityId, @PostalCode, @PhoneNumber, NOW(), @CreatedBy, NOW(), @LastUpdateBy)";
        public static string AddressUpdateQuery => "UPDATE address SET " +
                "address = @Address, " +
                "address2 = '', " +
                "cityId = @CityId, " +
                "postalCode = @PostalCode, " +
                "phone = @PhoneNumber, " +
                "lastUpdate = NOW(), " +
                "lastUpdateBy = @LastUpdateBy " +
                "WHERE addressId = @AddressId";
        #endregion
        #region Customer Queries
        public static string CustomerIdxQuery => "SELECT " +
                 "customerId FROM customer " +
                 "ORDER BY customerId DESC LIMIT 1";
        public static string CustomerInsertQuery => "INSERT INTO customer " +
                 "(customerId, customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                 "VALUES (@CustomerId, @CustomerName, @AddressId, @Active, NOW(), @CreatedBy, NOW(), @LastUpdateBy)";
        public static string CustomerUpdateQuery => "UPDATE customer SET " +
                "customerName = @CustomerName, " +
                "addressId = @AddressId, " +
                "active = @Active, " +
                "lastUpdate = NOW(), " +
                "lastUpdateBy = @LastUpdateBy " +
                "WHERE customerId = @CustomerId";
        #endregion
        #endregion

        #region Appointment Queries
        public static string appointmentInsertQuery = "INSERT INTO appointment " + "" +
            "(appointmentId, customerId, userId, title, description, location, contact, type, url, " +
            "start, end, createDate, createdBy, lastUpdate, lastUpdateBy) " +
            "VALUES (@AppointmentId, @CustomerId, @UserId, @Title, @Description, @Location, @Contact, " +
            "@Type, @URL, @Start, @End, NOW(), @CreatedBy, NOW(), @LastUpdateBy)";
        public static string appointmentUpdateQuery = "UPDATE appointment SET " +
            "customerId = @CustomerId, " +
            "userId = @UserId, title = @Title, " +
            "description = @Description, location = @Location, contact = @Contact, type = @Type, " +
            "url = @URL, start = @Start, end = @End, " +
            "lastUpdate = NOW(), lastUpdateBy = @LastUpdateBy " +
            "WHERE appointmentId = @AppointmentId;";
        public static string GetAppointmentTableQuery =>
            "SELECT ap.appointmentId, ap.customerId, ap.userId, ap.description, ap.location, " + 
            "ap.type, ap.url, ap.start, ap.end, u.userName, " +
            "c.customerName, a.phone, a.addressId, a.cityId, ci.countryId " +
            "FROM appointment ap " +
            "JOIN customer c ON ap.customerId = c.customerId " +
            "JOIN address a ON c.addressId = a.addressId " +
            "JOIN city ci ON a.cityId = ci.cityId " +
            "JOIN country co ON ci.countryId = co.countryId " +
            "JOIN user u ON ap.userId = u.userId " +
            "ORDER BY ap.start";
        public static string GetAppointmentStartEndQuery => 
            "SELECT start, end FROM appointment WHERE DATE(start) = @Date";
        public static string appointmentIdxQuery => "SELECT appointmentId FROM appointment ORDER BY appointmentId DESC LIMIT 1";
        public static string deleteAppointmentQuery => "DELETE FROM appointment WHERE appointmentId = @AppointmentId";


        #endregion

        public static string GetUsersQuery => "SELECT userId, userName FROM user";
        public static string GetCustomersQuery => "SELECT customerId, customerName FROM customer";
    }
}

