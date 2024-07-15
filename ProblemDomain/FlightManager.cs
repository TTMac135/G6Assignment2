using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G6Assignment2.ProblemDomain
{
    //Parent Superclass of Flight and Reservation
    internal abstract class FlightManager
    {
        private string _flightCode;
        private string _airline;
        private string _day;
        private string _seats;
        private int _cost;

        public FlightManager(string flightCode, string airline, string day, string seats, int cost)
        {
            _flightCode = flightCode;
            _airline = airline;
            _day = day;
            _seats = seats;
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

        public string Seats
        {
            get { return _seats; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _seats = value;
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
            return $"{_flightCode}, {_airline}, {_day}, {_seats}, {_cost}";
        }



    }
}
