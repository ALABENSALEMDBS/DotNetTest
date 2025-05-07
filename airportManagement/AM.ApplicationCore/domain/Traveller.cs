using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AM.ApplicationCore.domain
{
    public class Traveller : Passenger
    {
        public String HealthInformation { get; set; }
        public String Nationality { get; set; }


        public override string ToString()
        {
            return "Nationality: " + Nationality + "\nHealthInformation: " + HealthInformation;
        }

        public override void PassengerType()
        {
            base.PassengerType();
            Console.WriteLine("i m travller");
        }
    }
}
