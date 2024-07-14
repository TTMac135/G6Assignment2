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

        //Iterates through the flight objects until it finds the user input origin, destination, and day
        //Returns list of matching objects
        public List<Flight> findFlights(string origin, string destination, string day)
        {
            List<Flight> matchingFlights = new List<Flight>();

            foreach (Flight flight in flightObjects)
            {
                if (flight.Origin == origin && flight.Destination == destination && flight.Day == day)
                    matchingFlights.Add(flight);
            }
            return matchingFlights;
        }
    }
}
