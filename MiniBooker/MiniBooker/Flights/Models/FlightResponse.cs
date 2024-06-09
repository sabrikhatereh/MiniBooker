namespace MiniBooker.Flights.Models.Sabre
{

    public sealed class FlightResponse
    {
        public List<FlightSection> Flights { get; set; }= new List<FlightSection>();
        public decimal TotalPrice { get; set; }
        public string CurrencyCode { get; set; }
    }
    public sealed class FlightSection
    {
        public DateTime ArrivalDateTime { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public string DestinationLocation { get; set; }
        public string OriginLocation { get; set; }
        public string Airline { get; set; }
        public int FlightNumber { get; set; }

        public void PrintFlightSection()
        {
            Console.WriteLine($"  Airline: {Airline}  Flight Number: {FlightNumber}  From: {OriginLocation}  To: {DestinationLocation}");
            Console.WriteLine($"  Departure: {DepartureDateTime}  Arrival: {ArrivalDateTime}");
        }
    }
}


