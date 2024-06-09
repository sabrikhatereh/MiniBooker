using Microsoft.AspNetCore.Http.Extensions;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MiniBooker.Flights.Models.Sabre
{
    public sealed class SabreFlightRequest
    {
        [Required, NotNull]
        public string Origin { get; private set; }
        [Required, NotNull]
        public DateOnly DepartureDate { get; private set; }
        [Required, NotNull]
        public DateOnly ReturnDate { get; private set; }
        [Required, NotNull]
        public string Destination { get; private set; }

        public SabreFlightRequest(string origin, DateOnly departureDate, DateOnly returnDate, string destination)
        {
            Origin = origin;
            DepartureDate = departureDate;
            ReturnDate = returnDate;
            Destination = destination;
        }

        public SabreFlightRequest(string origin, string destination)
        {
            Origin = origin;
            Destination = destination;
        }

        public static bool IsValidDate(string dateInput, out DateOnly parsedDate)
        {
            if (DateOnly.TryParse(dateInput, out parsedDate))
            {
                if (parsedDate >= DateOnly.Parse(DateTime.UtcNow.ToShortDateString()))
                    return true;

                Console.WriteLine("Date must be today or later. Please enter a valid date.");
                return false;
            }
            else
            {
                Console.WriteLine("Invalid date format. Please use YYYY-MM-DD.");
                return false;
            }
        }

        public static bool IsReturnDateValid(string departureDate, string returnDate)
        {
            DateTime depDate = DateTime.Parse(departureDate);
            DateTime retDate = DateTime.Parse(returnDate);

            if (retDate >= depDate)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Return date must be after departure date.");
                return false;
            }
        }
        public static bool IsValidLocation(string location)
        {
            if (string.IsNullOrWhiteSpace(location))
            {
                Console.WriteLine("Location cannot be empty.");
                return false;
            }
            return true;
        }

        public QueryBuilder GetQuery()
        {
            var query = new QueryBuilder();
            query.Add("origin", Origin.ToUpper());
            query.Add("destination", Destination.ToUpper());
            query.Add("departuredate", $"{DepartureDate:yyyy-MM-dd}");
            query.Add("returndate", $"{ReturnDate:yyyy-MM-dd}");
            return query;
        }
     

    }
}
