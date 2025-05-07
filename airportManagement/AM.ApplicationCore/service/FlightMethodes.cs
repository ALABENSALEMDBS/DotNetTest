using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.domain;
using AM.ApplicationCore.interfaces;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;

namespace AM.ApplicationCore.service
{
    public class FlightMethodes : Service<Flight>,  IFlightMethods
    {
        public List<Flight>  Flights= new List<Flight> ();

        public FlightMethodes(IUnitOfWork unitOfWork) : base(unitOfWork)
        {   
        }


        public IEnumerable<Flight> SortFlights()
        {
            return GetAll().OrderByDescending(f => f.FlightDate);
        }


        public IList<DateTime> GetflightDates(string destination)
        {
            List<DateTime> dates = new List<DateTime> ();

            //*******************  foreach
            //foreach (Flight f in Flights) { 
            //     if (f.Destination  == destination) {
            //        dates.Add (f.FlightDate); 
            //     } 
            //}
            //return dates;

            //******************* LINK 
            //var query = from f in Flights
            //            where f.Destination == destination
            //            select f.FlightDate;
            //return query.ToList();

            //****************** LAMDA
            return Flights.Where(f=>f.Destination == destination).Select(d=>d.FlightDate).ToList();

            throw new NotImplementedException();
        }

        



        public IList<Flight> GetFlights(string filterType, string filterValue)
        {
            List<Flight> filteredFlights = new List<Flight>();

            switch (filterType)
            {
                case "Destination":
                    Console.WriteLine($"la valeur de {filterType} est égale {filterValue}. ");
                    foreach (var flight in Flights)
                    {
                        if (flight.Destination.Equals(filterValue))
                        {
                            filteredFlights.Add(flight);
                        }
                    }
                    break;

                case "FlightDate":
                    Console.WriteLine($"la valeur de {filterType} est égale {filterValue}. ");
                    DateTime flightDate;
                    if (DateTime.TryParse(filterValue, out flightDate))
                    {
                        foreach (var flight in Flights)
                        {
                            if (flight.FlightDate.Date == flightDate.Date)
                            {
                                filteredFlights.Add(flight);
                            }
                        }
                    }
                    break;

                case "EffectiveArrival":
                    Console.WriteLine($"la valeur de {filterType} est égale {filterValue}. ");
                    DateTime flightDateE;
                    if (DateTime.TryParse(filterValue, out flightDateE))
                    {
                        foreach (var flight in Flights)
                        {
                            if (flight.FlightDate.Date == flightDateE.Date)
                            {
                                filteredFlights.Add(flight);
                            }
                        }
                    }
                    break;


                case "EstimatedDuration":
                    Console.WriteLine($"la valeur de {filterType} est égale {filterValue}. ");
                    int estimatedDuration;
                    if (int.TryParse(filterValue, out estimatedDuration))
                    {
                        foreach (var flight in Flights)
                        {
                            if (flight.EstimatedDuration == estimatedDuration)
                            {
                                filteredFlights.Add(flight);
                            }
                        }
                    }
                    break;

                case "Plane":
                    Console.WriteLine($"la valeur de {filterType} est égale {filterValue}. ");
                    PlaneType planeType;
                    if (Enum.TryParse(filterValue, out planeType))
                    {
                        foreach (var flight in Flights)
                        {
                            if (flight.Plane.PlaneType == planeType)
                            {
                                filteredFlights.Add(flight);
                            }
                        }
                    }
                    break;


                default:
                    Console.WriteLine("Filtre non valide.");
                    return filteredFlights;
            }

            return filteredFlights;


            throw new NotImplementedException();
        }

       

        public void ShowFlightDetails(Plane plane)
        {
            //*************** LINK
            //var query = from f in Flights where f.Plane == plane 
            //            select new { f.Destination, f.FlightDate };

            //************** LAMDA
            var La = Flights.Where(a => a.Plane == plane)
                .Select(f => new { f.Destination, f.FlightDate });
            foreach (var q in La) { 
                  Console.WriteLine("Destination: "+ q.Destination + "fLIGHT date: "+q.FlightDate);
            }

        }


        public int ProgrammedFlightNumber(DateTime startDate)
        {
            //var query = from f in Flights
            //            where DateTime.Compare(startDate, f.FlightDate) <= 0
            //            && (f.FlightDate - startDate).TotalDays < 8
            //            select f;

            //************** LAMDA
            var lam = Flights.Where(f => DateTime.Compare(startDate, f.FlightDate) <= 0 
            && (f.FlightDate - startDate).TotalDays < 8).Select(a => a);
                        
            return lam.Count();
           
        }



        public double DurationAverage(string destination)
        {
            //var query = from f in Flights
            //            where f.Destination == destination
            //            select f.EstimatedDuration;

            //************** LAMDA
            var lam = Flights.Where(f=>f.Destination == destination).Select(a => a.EstimatedDuration);
            return lam.Average();

            throw new NotImplementedException();
        }



        public IEnumerable<Flight> OrderedDurationFlights()
        {
            //var query = from f in Flights
            //            orderby f.EstimatedDuration descending
            //            select f;

            //************** LAMDA
            var lam = Flights.OrderByDescending(f=>f.EstimatedDuration).ToList();
            return lam;
            throw new NotImplementedException();
        }



        public IEnumerable<Traveller> SeniorTravellers(Flight flight)
        {
            //var query = from t in flight.Passengers.OfType<Traveller>()
            //            orderby t.BirthDate
            //            select t;

            //************** LAMDA
            var lam = flight.Passengers.OfType<Traveller>().OrderBy(t => t.BirthDate);
            return lam.Take(3);


            throw new NotImplementedException();
        }


        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {
            //var query = from f in Flights
            //            group f by f.Destination;

            //************** LAMDA
            var lam = Flights.GroupBy(f => f.Destination);

            foreach (var gr in lam)
            {
                Console.WriteLine("Destination: " + gr.Key);
                foreach (var f in gr)
                    Console.WriteLine("Décollage: "+f.FlightDate);
            }
            return lam;
            throw new NotImplementedException();
        }
    }
}
