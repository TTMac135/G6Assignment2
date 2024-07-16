using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G6Assignment2.ProblemDomain
{
    class Reservation : FlightManager
    {
        // When a travel agent selects a flight from the list, the text fields are populated with the selected
        // flight code, airline, day, time and cos
        private string _reservationCode;
        private string _name;
        private string _citizenship;
        private bool _status;

        public Reservation(string reservationCode, string flightCode, string airline, string day, string time, int seats, int cost, string name, string citizenship, bool status)
                          : base(flightCode, airline, day, time, seats, cost)
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

        public override string ToString()
        {
            return $"{ReservationCode}, {FlightCode}, {Airline}, {Day}, {Cost}, {Time}, {Name}, {Citizenship}, {Status}";
        }

        public class InvalidReservation : Exception 
        {
            public InvalidReservation(Flight? flight)
            {
                if (flight == null)
                {
                    //"Flight Object cannot be of value 'null'."
                }
                else 
                {
                    if (flight.Seats == 0 )
                    {
                        //Console.WriteLine("Flight has not available seats");
                    }
                }
            }

            public InvalidReservation(string? str) 
            {
                //Console.WriteLine("Client name/citizenship cannot be of value 'null'");
            }
        }

        /*
        public Reservation? MakeReservation(Flight flight, string name, string citizenship)
        {
            Reservation? reservation = null;
            if(flight == null || flight.Seats == 0) 
            {
                throw new InvalidReservation(flight);
            }
            else if(name == null || citizenship == null)
            {
                throw new InvalidReservation(name);
            }
            else
            {
                //Create reservation
                reservation = new Reservation();
                //add to binary file
            }
            return reservation;
        }
        */
    }
}
