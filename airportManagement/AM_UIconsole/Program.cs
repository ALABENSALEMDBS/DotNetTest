// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.service;
using AM.infrastructure;
using AM.Infrastructure;

Console.WriteLine("Hello, World!");

//Flight flight = new Flight();
//flight.Departure = "tunis";
//flight.Destination = "nabeul";

//Flight flight1 = new Flight("Departure","Destination", new DateTime(22,01,2025), 2 ,new DateTime(23,01,2025), 1);
//Console.WriteLine(flight1.ToString());



// Initialiseur d objet
Flight f2 = new Flight { Departure = "tunissssss", Destination = "nabeul" };
Console.WriteLine(f2.ToString());

Passenger passenger = new Passenger { FullName = new FullName { FirstName = "ala", LastName = "salem" }, EmailAddress="@esprit" };

Console.WriteLine("************** test check ************");
Console.WriteLine(passenger.CheckProfile("ala","salem"));
Console.WriteLine(passenger.CheckProfile("ala", "salem", "@esprit"));

//************** overiding****************

Traveller tr = new Traveller();
tr.PassengerType();

Staff staff = new Staff();
staff.PassengerType();



//*************** GetFlightMethode *****************
var context = new AMContext();
IUnitOfWork ux = new UnitOfWork(context, typeof(UnitOfWork));

FlightMethodes f = new FlightMethodes(ux);
f.Flights = TestData.listFlights;


foreach (var item in f.GetflightDates("Paris"))
{
    Console.WriteLine(item);
}

//Console.WriteLine("**************************** GetFlight ***************************");


foreach (var item in f.GetFlights("Destination", "Paris"))
{
    Console.WriteLine(item);
    Console.WriteLine("--------------------------------");

}

//Console.WriteLine("**************************** Question 10 ***************************");
f.ShowFlightDetails(TestData.BoingPlane);

//Console.WriteLine("**************************** Question 11 ***************************");
Console.WriteLine(f.ProgrammedFlightNumber(new DateTime(2022, 01, 01)));

//Console.WriteLine("**************************** Question 12 ***************************");
Console.WriteLine(f.DurationAverage("Madrid"));

//Console.WriteLine("**************************** Question 13 ***************************");
foreach (var item in f.OrderedDurationFlights())
{
    Console.WriteLine(item.EstimatedDuration);
    Console.WriteLine("--------------------------------");

}

//Console.WriteLine("**************************** Question 14 ***************************");
foreach (var item in f.SeniorTravellers(TestData.flight1))
{
    Console.WriteLine(item.BirthDate);
    Console.WriteLine("--------------------------------");

}

//Console.WriteLine("**************************** Question 15 ***************************");
f.DestinationGroupedFlights();


Console.WriteLine("****************************  Les méthodes d’extension ***************************");
passenger.UpperFullName();
Console.WriteLine("first: "+ passenger.FullName.FirstName + " last: "+passenger.FullName.LastName);


//*****************************************************************************************************
Console.WriteLine("**************************** maipulation BDD ***************************");

AMContext aMContext = new AMContext();

//aMContext.planes.Add(TestData.Airbusplane);
//aMContext.Flights.Add(TestData.flight6);
//aMContext.SaveChanges();
//Console.WriteLine("**************************** ajouter avec succées ***************************");
foreach(var item in aMContext.Flights) {
    Console.WriteLine(item.Destination  + " " + item.Plane.Capacity); 
}