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
                //Create reservation
                reservation = new Reservation();
                //add to binary file
            }
            return reservation;
        }



    }
}
