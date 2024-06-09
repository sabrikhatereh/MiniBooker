using Microsoft.Extensions.DependencyInjection;
using MiniBooker.Flights;
using MiniBooker.Flights.Models.Sabre;
using MiniBooker.Hotels;
using MiniBooker.Hotels.Models;

namespace MiniBooker.Utility
{
    public static class ConsoleHelper
    {
        public static async Task FlightLookup(IServiceProvider services)
        {
            var flightService = services.GetRequiredService<FlightService>();
            //var request = new SabreFlightRequest("mow",  DateOnly.Parse("2024-08-08"), DateOnly.Parse("2024-08-08"), "lon");
            //var result = await flightService.Search(request, default);
            Console.WriteLine("You've chosen to book a flight.");
            Console.WriteLine("Please enter the following details:");
            string origin, destination;

            do
            {
                Console.Write("Origin Location: ");
                origin = Console.ReadLine();
            } while (!SabreFlightRequest.IsValidLocation(origin));

            do
            {
                Console.Write("Destination Location: ");
                destination = Console.ReadLine();
            } while (!SabreFlightRequest.IsValidLocation(destination));


            string departureDate;
            DateOnly _departureDate;
            do
            {
                Console.Write("Departure Date (YYYY-MM-DD): ");
                departureDate = Console.ReadLine();
            } while (!SabreFlightRequest.IsValidDate(departureDate, out _departureDate));

            string returnDate;
            DateOnly _returnDate;
            do
            {
                Console.Write("Return Date (YYYY-MM-DD): ");
                returnDate = Console.ReadLine();
            } while (!SabreFlightRequest.IsValidDate(returnDate, out _returnDate) || !SabreFlightRequest.IsReturnDateValid(departureDate, returnDate));


            Console.WriteLine($"Booking flight from {origin} to {destination}, departing on {departureDate} and returning on {returnDate}.");
            Console.WriteLine(new string('.', 60));
            var request = new SabreFlightRequest(origin, _departureDate, _returnDate, destination);
            var result = await flightService.Search(request, default);
            if (result != null)
                ReportHelper.PrintFlightResult(result);

            MainMenu(services);
        }

        public static async Task HotelLookup(IServiceProvider services)
        {
            var hotelService = services.GetRequiredService<HotelService>();
            //var request = new HotelAvailabilityRequest("LON", DateTime.Parse("2024-08-08"), DateTime.Parse("2024-08-08"));
            //var result = await hotelService.Search(request, default);

            string city;
            do
            {
                Console.Write("Enter City Code (e.g., 'LON' for London):");
                city = Console.ReadLine();
            } while (!HotelAvailabilityRequest.IsValidLocation(city));

            string checkInDate;
            DateTime _checkInDate;

            do
            {
                Console.Write("Checkin Date (YYYY-MM-DD): ");
                checkInDate = Console.ReadLine();
            } while (!HotelAvailabilityRequest.IsValidDate(checkInDate, out _checkInDate));

            string checkOutDate;
            DateTime _checkOutDate;
            do
            {
                Console.Write("Checkout Date (YYYY-MM-DD): ");
                checkOutDate = Console.ReadLine();
            } while (!HotelAvailabilityRequest.IsValidDate(checkOutDate, out _checkOutDate) ||
                     !HotelAvailabilityRequest.IsReturnDateValid(checkInDate, checkOutDate));

            var request = new HotelAvailabilityRequest(city, _checkInDate, _checkOutDate);
            var result = await hotelService.Search(request, default);

            if (result != null)
                ReportHelper.PrintFlightResult(result);

            MainMenu(services);

        }

        public static void MainMenu(IServiceProvider services)
        {
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1: Book a Flight");
            Console.WriteLine("2: Book a Hotel");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    FlightLookup(services).Wait();
                    break;
                case "2":
                    HotelLookup(services).Wait();
                    break;
                default:
                    Console.WriteLine("Invalid option. Please restart and select either 1 or 2.");
                    break;
            }
        }
    }
}










