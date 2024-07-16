using G6Assignment2.ProblemDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G6Assignment2
{
    class FlightManager
    {
        private List<Flight> flightObjects = new List<Flight>();
        private List<Airport> airportObjects = new List<Airport>();
        string[] flightArray = Resources.flights.Split('\n');
        string[] airportsArray = Resources.airports.Split('\n');

        public List<Flight> FlightObjects 
        {
            get { return flightObjects; }
        }
        public List<Airport> AirportObjects
        {
            get { return airportObjects; }
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
                    int seats = Convert.ToInt32(flightInfo[6]);
                    int cost = int.Parse(flightInfo[7]);

                    Flight currentFlight = new Flight(flightCode, airline, origin, destination, day, time, seats, cost);
                    flightObjects.Add(currentFlight);
                }
            }
        }

        public void CreateAirports()
        {
            foreach (string airport in airportsArray) 
            {
                string[] airportInfo = airport.Split(",");
                if (airportInfo.Length > 1)
                {
                    string airportName = airportInfo[1];
                    string airportId = airportInfo[0];

                    Airport currentAirport = new Airport(airportId, airportName);
                    AirportObjects.Add(currentAirport);
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

                if (origin != "Any" && flight.Origin != origin)
                {
                    matches = false;
                }
                if (destination != "Any" && flight.Destination != destination)
                {
                    matches = false;
                }
                if (day != "Any" && flight.Day != day)
                {
                    matches = false;
                }
                if (origin == null || destination == null || day == null)
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
