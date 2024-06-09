using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MiniBooker.Flights.Models.Sabre;
using MiniBooker.Flights.Models.Sabre.Flight;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;


namespace MiniBooker.Flights
{
    public class FlightService
    {
        private readonly ILogger<FlightService> _logger;
        private readonly SabreApiOptions _sabreApiSettings;
        private const string FlightUrl = "/v1/shop/flights";
        private const string CityPairsLookupUrl = "/v1/lists/supported/shop/flights/origins-destinations";
        private readonly Dictionary<HttpStatusCode, Action> _responses = new Dictionary<HttpStatusCode, Action>
        {
            { HttpStatusCode.NotFound, () => Console.WriteLine("No flights found. Please try again.") },
            { HttpStatusCode.Unauthorized, () => Console.WriteLine("Invalid Api key. Please try again.") }
        };

        public FlightService(ILogger<FlightService> logger, IOptions<SabreApiOptions> settings)
        {
            _logger = logger;
            _sabreApiSettings = settings.Value;
        }


        public async Task<List<FlightResponse>> Search(SabreFlightRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var _httpClient = new HttpClient();
                _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_sabreApiSettings.ApiKey}");
                var uri = new Uri($"{_sabreApiSettings.ApiUrl}{FlightUrl}{request.GetQuery()}", UriKind.RelativeOrAbsolute);
                var response = await _httpClient.GetAsync(uri);
                if (_responses.TryGetValue(response.StatusCode, out Action handleResponse))
                {
                    handleResponse();
                    return null;

                }

                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();
                var flightResponse = JsonConvert.DeserializeObject<SabreFlightResponse>(responseBody);

                return ConvertToFlightResponseList(flightResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid request. Please try again.");
                return null;
            }
        }

        private List<FlightResponse> ConvertToFlightResponseList(SabreFlightResponse rootObject)
        {
            List<FlightResponse> flightResponses = new List<FlightResponse>();

            foreach (var itinerary in rootObject.PricedItineraries)
            {
                foreach (var item in itinerary.AirItinerary.OriginDestinationOptions.OriginDestinationOption)
                {
                    var flightResponse = new FlightResponse();
                    foreach (var segment in item.FlightSegment)
                    {
                        flightResponse.Flights.Add(new FlightSection
                        {
                            ArrivalDateTime = segment.ArrivalDateTime,
                            DepartureDateTime = segment.DepartureDateTime,
                            DestinationLocation = segment.ArrivalAirport.LocationCode,
                            OriginLocation = segment.DepartureAirport.LocationCode,
                            Airline = segment.OperatingAirline.Code,
                            FlightNumber = segment.OperatingAirline.FlightNumber
                        });
                    }
                    flightResponse.TotalPrice = (decimal)itinerary.AirItineraryPricingInfo.ItinTotalFare.TotalFare.Amount;
                    flightResponse.CurrencyCode = itinerary.AirItineraryPricingInfo.ItinTotalFare.TotalFare.CurrencyCode;
                    flightResponses.Add(flightResponse);
                }
            }

            return flightResponses;
        }
    }
}
