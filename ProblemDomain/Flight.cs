using HealthKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G6Assignment2.ProblemDomain
{
    internal class Flight
    {
        private string _flightCode;
        private string _airline;
        private string _origin;
        private string _destination;
        private string _day;
        private string _time;
        private int _cost;
        
        public Flight(string flightCode, string airline, string origin, string destination, string day, string time, int cost)
        {
            _flightCode = flightCode;
            _airline = airline;
            _origin = origin;
            _destination = destination;
            _day = day;
            _time = time;
            _cost = cost;
        }

        public string FlightCode
        {
            get { return _flightCode; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _flightCode = value;
                }
            }
        }
        public string Airline
        {
            get { return _airline; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _airline = value;
                }
            }
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

        public string Day
        {
            get { return _day; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _day = value;
                }
            }
        }

        public string Time
        {
            get { return _time; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _time = value;
                }
            }
        }

        public int Cost
        {
            get { return _cost; }
            set
            {
                if (value >= 0)
                {
                    _cost = value;
                }
            }
        }

        public override string ToString()
        {
            return $"{_flightCode}, {_airline}, {_origin}, {_destination}, {_day}, {_time}, {_cost}";
        }
    }
}
