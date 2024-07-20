using G6Assignment2.ProblemDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.IO;


namespace G6Assignment2
{
    //Allows for making reservations, editting them, and searching for them
    internal class ReservationManager
    {
        public ReservationManager() { }

        public Reservation? MakeReservation(Flight flight, string name, string citizenship)
        {
            List<Reservation> reservations = new List<Reservation>();
            string filePath = @"C:\Users\luism\Desktop\other\reservations.json";
            if (!File.Exists(filePath))
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    //create file if it doesnt exist
                }
                
            }
            
            else 
            {
                string reservationsString = File.ReadAllText(filePath);

                reservations = JsonConvert.DeserializeObject<List<Reservation>>(reservationsString);
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

                reservations.Add(reservation);

                string reservationsString = JsonConvert.SerializeObject(reservations, Formatting.Indented);

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

    }
}
