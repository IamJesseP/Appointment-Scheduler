using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969Jesse.Model
{
    internal class Address : BaseClass
    {
        public int AddressID { get; set; }

        public string AddressName { get; set; }

        public City City { get; set; }

        public string PostalCode { get; set; }

        public string PhoneNumber { get; set; }
    }
}
