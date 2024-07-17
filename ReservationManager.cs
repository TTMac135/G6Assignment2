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
                int seats = flight.Seats;
                bool status = true;

                reservation = new Reservation(reserveCode, flightCode, airline, day, time, seats, cost, name, citizenship, status);
                //add to binary file
            }
            return reservation;
        }

        private string GenerateReservationCode()
        {
            string code = "";
            List<string> chars = new List<string>() { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m",
                "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"};

            Random rnd = new Random();

            for (int i = 1; i < 6; i++)
            {
                if (i == 1)
                {
                    code += chars[rnd.Next(chars.Count)].ToUpper();
                }
                else
                {
                    code += Convert.ToString(rnd.Next(0, 9));
                }
            }

            return code;
        }

    }
}
