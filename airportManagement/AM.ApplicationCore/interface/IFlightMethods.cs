using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.domain;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore.interfaces
{
    public interface IFlightMethods :IService<Flight>
    {
        IList<DateTime> GetflightDates(String Destination);
        IList<Flight> GetFlights(string filterType, string filterValue);
        void ShowFlightDetails(Plane plane);

        int ProgrammedFlightNumber(DateTime startDate);
        Double DurationAverage(string destination);

        IEnumerable<Flight> OrderedDurationFlights();


        IEnumerable<Traveller> SeniorTravellers(Flight flight);

        IEnumerable <IGrouping<string, Flight>> DestinationGroupedFlights();

        public IEnumerable<Flight> SortFlights();




    }
}
