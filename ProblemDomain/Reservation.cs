using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G6Assignment2.ProblemDomain
{
    class Reservation : FlightManager
    {
        private string _reservationCode;
        private string _name;
        private string _citizenship;
        private bool _status;

        public Reservation(string reservationCode, string flightCode, string airline, string day, string time, int cost, string name, string citizenship, bool status)
                          : base(flightCode, airline, day, time, cost)
        {
            _reservationCode = reservationCode;
            _name = name;
            _citizenship = citizenship;
            _status = status;
        }

        public string ReservationCode //Generate new reservation code based on LDDDD
        {
            get { return _reservationCode; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _reservationCode = value;
                }
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _name = value;
                }
            }
        }

        public string Citizenship
        {
            get { return _citizenship; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _citizenship = value;
                }
            }
        }

        public bool Status
        {
            get { return _status; }
            set
            {
                if (value == true || value == false)
                    _status = value;
            }
        }
    }
}
