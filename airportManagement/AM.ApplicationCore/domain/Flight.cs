using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.domain
{
    public class Flight
    {
        //public Flight(string departure, string destination, DateTime effectiveArrival, int estimatedDuration, DateTime flightDate, int flightId)
        //{
        //    Departure = departure;
        //    Destination = destination;
        //    EffectiveArrival = effectiveArrival;
        //    EstimatedDuration = estimatedDuration;
        //    FlightDate = flightDate;
        //    FlightId = flightId;
        //}

        public String Departure { get; set; }
        public String Destination { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public int EstimatedDuration { get; set; }
        public DateTime FlightDate { get; set; }
        public int FlightId { get; set; }


        public String Pilot { get; set; }

        // [ForeignKey(nameof(Plane))]
        public int PlaneFK { get; set; }

        public virtual Plane Plane { get; set; }

        public virtual ICollection<Passenger> Passengers { get; set; }

        public override string ToString()
        {
            return "FlightDate: " + FlightDate + "\nDestination: " + Destination + "\nEstimatedDuration: " + EstimatedDuration + "\nPlane: " + Plane;
        }

    }
}
