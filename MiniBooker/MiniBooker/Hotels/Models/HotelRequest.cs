using System;
using System.Collections.Generic;

namespace MiniBooker.Hotels.Models
{
    public class HotelAvailabilityRequest
    {
        public GetHotelAvailRQ GetHotelAvailRQ { get; set; } = new GetHotelAvailRQ();
        public HotelAvailabilityRequest(string airportCode, DateTime checkInDate, DateTime checkOutDate)
        {
            GetHotelAvailRQ.SearchCriteria = new SearchCriteria();
            GetHotelAvailRQ.SearchCriteria.GeoSearch = new GeoSearch
            {
                GeoRef = new GeoRef
                {
                    RefPoint = new RefPoint() { Value = airportCode },
                }
            };
            GetHotelAvailRQ.SearchCriteria.RateInfoRef = new RateInfoRef
            {
                StayDateRange = new StayDateRange()
                {
                    StartDate = checkInDate,
                    EndDate = checkOutDate
                }
            };
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

        public static bool IsValidDate(string checkInDate, out DateTime parsedDate)
        {
            if (DateTime.TryParse(checkInDate, out parsedDate))
            {
                if (parsedDate >= DateTime.UtcNow)
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
        public static bool IsReturnDateValid(string checkInDate, string checkOutDate)
        {
            DateTime depDate = DateTime.Parse(checkInDate);
            DateTime retDate = DateTime.Parse(checkOutDate);

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
    }

    public class GetHotelAvailRQ
    {
        public SearchCriteria SearchCriteria { get; set; } = new SearchCriteria();
    }

    public class SearchCriteria
    {
        public int OffSet { get; set; } = 1;
        public string SortBy { get; set; } = "TotalRate";
        public string SortOrder { get; set; } = "DESC";
        public int PageSize { get; set; } = 20;
        public bool TierLabels { get; set; } = false;
        public GeoSearch GeoSearch { get; set; } = new GeoSearch();
        public RateInfoRef RateInfoRef { get; set; } = new RateInfoRef();
        public HotelPref HotelPref { get; set; } = new HotelPref();
    }

    public class GeoSearch
    {
        public GeoRef GeoRef { get; set; } = new GeoRef();
    }

    public class GeoRef
    {
        public int Radius { get; set; } = 50;
        public string UOM { get; set; } = "MI";
        public RefPoint RefPoint { get; set; } = new RefPoint();
    }

    public class RefPoint
    {
        public string Value { get; set; } = "LON";
        public string ValueContext { get; set; } = "CODE";
        public string RefPointType { get; set; } = "6";
    }

    public class RateInfoRef
    {
        public bool ConvertedRateInfoOnly { get; set; } = false;
        public string CurrencyCode { get; set; } = "USD";
        public string BestOnly { get; set; } = "2";
        public string PrepaidQualifier { get; set; } = "IncludePrepaid";
        public StayDateRange StayDateRange { get; set; } = new StayDateRange();
        public Rooms Rooms { get; set; } = new Rooms();
        public string InfoSource { get; set; } = "100,110,112,113";
    }

    public class StayDateRange
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class Rooms
    {
        public Room[] Room { get; set; } = new Room[] { new Room() };
    }

    public class Room
    {
        public int Index { get; set; } = 1;
        public int Adults { get; set; } = 1;
        public int Children { get; set; } = 0;
    }

    public class HotelPref
    {
        public SabreRating SabreRating { get; set; } = new SabreRating();
    }

    public class SabreRating
    {
        public string Min { get; set; } = "3";
        public string Max { get; set; } = "5";
    }

}