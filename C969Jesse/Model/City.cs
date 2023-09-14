using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969Jesse.Model
{
    internal class City : BaseClass
    {
        public int CityID { get; set; }

        public string CityName { get; set; }

        public Country Country { get; set; }
    }
}
