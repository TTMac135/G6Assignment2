using G6Assignment2.ProblemDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;


namespace G6Assignment2
{
    //Allows for making reservations, editting them, and searching for them
    //BinaryFormatter is obsolete and impossible to use here. Using JSON instead.

    internal class ReservationManager
    {

        private string filePath = @"C:\Other\reservations.json";
        private List<Reservation> reservationObjects = new List<Reservation>();

        public ReservationManager()
        {
            LoadReservations();
        }

        public List<Reservation> ReservationObjects
        {
            get { return reservationObjects; }
        }

        public void LoadReservations()
        {
            if (File.Exists(filePath))
            {
                string reservationsString = File.ReadAllText(filePath);
                reservationObjects = JsonSerializer.Deserialize<List<Reservation>>(reservationsString);
            }
            else
            {
                reservationObjects = new List<Reservation>();
            }
        }

        public Reservation? MakeReservation(Flight flight, string name, string citizenship)
        {
            
            if (!File.Exists(filePath))
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    // Creating an empty JSON File
                    byte[] emptyJsonArray = Encoding.UTF8.GetBytes("[]");
                    fs.Write(emptyJsonArray, 0, emptyJsonArray.Length);
                }
            }


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

                reservationObjects.Add(reservation);

                string reservationsString = JsonSerializer.Serialize(reservationObjects);

                File.WriteAllText(filePath, reservationsString);
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

        public List<Reservation> FindReservation(string reserveCode, string airline, string name)
        {
            LoadReservations();
            List<Reservation> matchingReservations = new List<Reservation>();

            foreach (var reservation in reservationObjects)
            {
                bool matches = true;

                if (reserveCode != "Any" && reservation.ReservationCode != reserveCode)
                {
                    matches = false;
                }
                if (airline != "Any" && reservation.Airline != airline)
                {
                    matches = false;
                }
                if (name != "Any" && reservation.Name != name)
                {
                    matches = false;
                }

                if (matches)
                {
                    matchingReservations.Add(reservation);
                }
            }

            return matchingReservations;
        }

    }
}
