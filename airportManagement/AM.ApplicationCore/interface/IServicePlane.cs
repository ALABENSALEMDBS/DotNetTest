using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.domain;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore.interfaces
{
    public interface IServicePlane : IService<Plane>
    {


       IEnumerable<Passenger> GetPassengers(Plane p);

        public IEnumerable<Flight> GetFlightsOrderedByManufactureDate(int n);
        public bool Reserve(Flight flight, int n);

        public void DeletePlanes();
        public IEnumerable<Staff> GetStaffByFlight(int flightId);
        public IEnumerable<Traveller> GetTrByPlAndDate(Plane plane, DateTime date);
        public void ShowTravellerCounts(DateTime startDate, DateTime endDate);
    }
}
