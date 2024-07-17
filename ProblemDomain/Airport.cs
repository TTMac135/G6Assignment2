using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G6Assignment2.ProblemDomain
{
    internal class Airport
    {
        private string _airportName;
        private string _airportId;

        public Airport(string airportId, string airportName)
        {
            _airportName = airportName;
            _airportId = airportId;
        }

        public string AirportName
        {
            get { return _airportName; }
        }
        public string AirportId
        {
            get { return _airportId; }
        }

        public override string ToString()
        {
            return $"{_airportName}, {_airportId}";
        }
    }
}
