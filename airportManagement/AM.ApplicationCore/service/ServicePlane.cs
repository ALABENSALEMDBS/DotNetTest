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
    public class ServicePlane : Service<Plane>, IServicePlane
    {
        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<Passenger> GetPassengers(Plane p)
        {
            return p.Flights.SelectMany(p=>p.Passengers);
        }

        public IEnumerable<Flight> GetFlightsOrderedByManufactureDate(int n)
        {
            return GetAll()
                .OrderByDescending(pl => pl.ManufactureDate)
                .Take(n)
                .SelectMany(pl => pl.Flights)
                .OrderBy(f => f.FlightDate);
        }

        public bool Reserve(Flight flight, int n)
        {
            var planeCapacity = flight.Plane.Capacity;
            var reservedSeats = flight.Passengers.Count();
            return (planeCapacity - reservedSeats) >= n;
        }

        public void DeletePlanes()
        {
            var fabDate = DateTime.Now.AddYears(-10);
            var uglyPlanes = GetAll().Where(p => p.ManufactureDate < fabDate);
            foreach (var plane in uglyPlanes)
            {
                Delete(plane);
            }
        }


        public IEnumerable<Staff> GetStaffByFlight(int flightId)
        {
            return GetAll()
                .SelectMany(p => p.Flights)
                .Where(f => f.FlightId == flightId)
                .SelectMany(f => f.Passengers.OfType<Staff>());
        }

        public IEnumerable<Traveller> GetTrByPlAndDate(Plane plane, DateTime date)
        {
            return plane.Flights
                .Where(f => f.FlightDate.Date == date.Date)
                .SelectMany(f => f.Passengers.OfType<Traveller>());
        }

      
        public void ShowTravellerCounts(DateTime startDate, DateTime endDate)
        {
            var flights = GetAll()
                .SelectMany(p => p.Flights)
                .Where(f => f.FlightDate.Date >= startDate.Date && f.FlightDate.Date <= endDate.Date)
                .GroupBy(f => f.FlightDate.Date);

            foreach (var group in flights)
            {
                int count = group.SelectMany(f => f.Passengers).OfType<Traveller>().Count();
                Console.WriteLine(group.Key.ToShortDateString() + " ====> " + count + " voyageurs");
            }
        }

    }
}
