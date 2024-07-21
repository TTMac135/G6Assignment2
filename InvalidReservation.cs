using G6Assignment2.ProblemDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G6Assignment2
{
    internal class InvalidReservation : Exception
    {
        private string? errorCode;

        public string? ErrorCode { get { return errorCode; } }
        public InvalidReservation(Flight? flight)
        {
            if (flight == null)
            {
                errorCode = "Flight Object cannot be of value 'null'.";
            }
            else
            {
                if (flight.Seats == 0)
                {
                    errorCode = "Flight has not available seats";
                }
            }
        }

        public InvalidReservation(string? str)
        {
            errorCode = "Client name/citizenship cannot be of value 'null'";
        }


        

    }
}
