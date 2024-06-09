using MiniBooker.Flights.Models.Sabre;
using MiniBooker.Hotels.Models;

public static class ReportHelper
{
    public static void PrintFlightResult(List<FlightResponse> flightResponses)
    {
        foreach (var flightResponse in flightResponses)
        {
            foreach (var flight in flightResponse.Flights)
            {
                flight.PrintFlightSection();
            }
            Console.WriteLine($"Total Price: {flightResponse.TotalPrice} {flightResponse.CurrencyCode}");
            Console.WriteLine(new string('-', 70));
        }
    }
    public static void PrintFlightResult(List<HotelResponse> hotelResponses)
    {
        foreach (var hotel in hotelResponses)
        {
            Console.WriteLine(new string('-', 70));
            hotel.Print();
        }
    }

    
}