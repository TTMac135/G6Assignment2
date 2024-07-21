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
        private FlightManager flightManager = new FlightManager();

        public ReservationManager()
        {
            LoadReservations();
        }

        public List<Reservation> ReservationObjects
        {
            get { return reservationObjects; }
        }

        //Loads reservations from the Json file
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

        public void SaveReservations()
        {
            string reservationsString = JsonSerializer.Serialize(reservationObjects);

            File.WriteAllText(filePath, reservationsString);
        }
        
        public Reservation? MakeReservation(Flight flight, string name, string citizenship)
        {
            //Creates the JSON file if it doesnt exist already
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
            //Throws exceptions if one of the fields is null
            if (flight == null || flight.Seats == 0)
            {
                throw new InvalidReservation(flight);
            }
            else if (name == null || citizenship == null)
            {
                throw new InvalidReservation(name);
            }
            else //creates the reservation and saves it otherwise
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

                flight.Seats--;

                SaveReservations();

            }
            return reservation;
        }

        //Generates a reservation code based on the format "LDDDD" L being letter, d being digit
        private string GenerateReservationCode()
        {
            string code = "";
            List<string> chars = new List<string>() { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m",
                "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"};

            Random rnd = new Random();

            while (true)
            {
                //creates code
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

                //checks that it doesnt match with another code generated prior
                bool match = false;
                foreach(Reservation rev in  reservationObjects) 
                {
                    if(rev.ReservationCode == code) 
                    {  
                        match = true;
                    }
                }
                if(!match)
                {
                    break;
                }
            }

            return code;
        }

        //Iterates through the flight objects until it finds the user input reservationcode, airline, or name
        //Will only add objects to list if at least one input matches an objects reservationcode, airline, or name and the other input(s) are "Any"
        //Returns list of matching objects
        public List<Reservation> FindReservation(string reserveCode, string airline, string name)
        {
            LoadReservations();
            List<Reservation> matchingReservations = new List<Reservation>();

            foreach (Reservation reservation in reservationObjects)
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

        public void UpdateReservation(Reservation updatedReservation) 
        {
            
            foreach(Reservation reservation in reservationObjects) 
            {
                if(reservation.ReservationCode == updatedReservation.ReservationCode) 
                {
                    reservation.Name = updatedReservation.Name; 
                    reservation.Citizenship = updatedReservation.Citizenship;
                    reservation.Status = updatedReservation.Status;
                    
                }
            }

            SaveReservations();
            
        }
    }
}
