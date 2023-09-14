using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969Jesse.Model
{
    internal class Customer : BaseClass
    {
        public int CustomerID { get; set; }

        public string CustomerName { get; set; }

        public Address Address { get; set; }

        public bool ActiveStatus { get; set; }
    }
}
