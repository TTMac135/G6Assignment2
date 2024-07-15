using G6Assignment2.ProblemDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G6Assignment2
{
    class FlightFinder
    {
        private List<Flight> flightObjects = new List<Flight>();
        string[] flightArray = Resources.flights.Split('\n');

        public List<Flight> FlightObjects
        {
            get { return flightObjects; }
        }

        //Creates flight objects & appends them to flight list
        public void CreateFlights()
        {
            foreach (string flight in flightArray) 
            {
                string[] flightInfo = flight.Split(',');

                if (flightInfo.Length > 1 ) {
                    string flightCode = flightInfo[0];
                    string airline = flightInfo[1];
                    string origin = flightInfo[2];
                    string destination = flightInfo[3];
                    string day = flightInfo[4];
                    string time = flightInfo[5];
                    int cost = int.Parse(flightInfo[6]);

                    Flight currentFlight = new Flight(flightCode, airline, origin, destination, day, time, cost);
                    flightObjects.Add(currentFlight);
                }
            }
        }

        //Iterates through the flight objects until it finds the user input origin, destination, and or day
        //Will only add objects to list if at least one input matches an objects origin, destination or day and the other input(s) are null
        //Returns list of matching objects
        public List<Flight> findFlights(string origin, string destination, string day)
        {
            List<Flight> matchingFlights = new List<Flight>();

            foreach (Flight flight in flightObjects)
            {
                bool matches = true;

                if (origin != null && flight.Origin != origin)
                {
                    matches = false;
                }
                if (destination != null && flight.Destination != destination)
                {
                    matches = false;
                }
                if (day != null && flight.Day != day)
                {
                    matches = false;
                }
                if (origin == null && destination == null && day == null)
                {
                    matches = false;
                }

                if (matches)
                {
                    matchingFlights.Add(flight);
                }
            }
            return matchingFlights;
        }
    }
}
