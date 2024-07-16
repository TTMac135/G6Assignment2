using G6Assignment2.ProblemDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G6Assignment2
{
    //Allows for making reservations, editting them, and searching for them
    internal class ReservationManager
    {
        public ReservationManager() { }

        public Reservation? MakeReservation(Flight flight, string name, string citizenship)
        {
            string reservationCode = GenerateReservationCode();
            Reservation? reservation = null;
            if (flight == null || flight.Seats == 0)
            {
                throw new InvalidReservation(flight);
            }
            else if (name == null || citizenship == null)
            {
                throw new InvalidReservation(name);
            }
            else
            {
                string reserveCode = GenerateReservationCode();
                string flightCode = flight.FlightCode;
                string airline = flight.Airline;
                string day = flight.Day;
                int cost = flight.Cost;
                string time = flight.Time;
                bool status;

                //Reservation reservation = new Reservation(reserveCode, flightCode, airline, day, cost, time, name, citizenship, status)
                //add to binary file
            }
            return reservation;
        }

        private string GenerateReservationCode() // PLACEHOLDER
        {
            return ""; // PLACEHOLDER!!!!
        }

    }
}
