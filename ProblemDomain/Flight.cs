using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G6Assignment2.ProblemDomain
{
    internal class Flight : FlightManager
    {

        private string _origin;
        private string _destination;
        
        public Flight(string flightCode, string airline, string origin, string destination, string day, string time, int seats, int cost) 
                      : base (flightCode, airline, day, time, seats, cost)
        {
            _origin = origin;
            _destination = destination;
        }

        public string Origin
        {
            get { return _origin; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _origin = value;
                }
            }
        }

        public string Destination
        {
            get { return _destination; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _destination = value;
                }
            }
        }

        public override string ToString()
        {
            return $"{FlightCode}, {Airline}, {Origin}, {Destination}, {Day}, {Time}, {Seats}, {Cost}";
        }
    }
}
