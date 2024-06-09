using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MiniBooker.Hotels.Models;
using MiniBooker.Hotels.Models.Sabre;
using Newtonsoft.Json;
using System.Net;
using System.Text;


namespace MiniBooker.Hotels
{
    public class HotelService
    {
        private readonly ILogger<HotelService> _logger;
        private readonly SabreApiOptions _sabreApiSettings;
        private const string HotelUrl = "/v3.0.0/get/hotelavail";
        private readonly Dictionary<HttpStatusCode, Action> _responses = new Dictionary<HttpStatusCode, Action>
        {
            { HttpStatusCode.NotFound, () => Console.WriteLine("No flights found. Please try again.") },
            { HttpStatusCode.Unauthorized, () => Console.WriteLine("Invalid Api key. Please try again.") }
        };
        public HotelService(ILogger<HotelService> logger, IOptions<SabreApiOptions> settings)
        {
            _logger = logger;
            _sabreApiSettings = settings.Value;
        }

        public async Task<List<HotelResponse>> Search(HotelAvailabilityRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var _httpClient = new HttpClient();
                _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_sabreApiSettings.ApiKey}");
                var uri = new Uri($"{_sabreApiSettings.ApiUrl}{HotelUrl}", UriKind.RelativeOrAbsolute);
                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(uri, content);

                if (_responses.TryGetValue(response.StatusCode, out Action handleResponse))
                {
                    handleResponse();
                    return null;
                }
                var jsonResponse = await response.Content.ReadAsStringAsync();
                // Deserialize the JSON response into GetHotelAvailRS object
                var hotelAvailRS = JsonConvert.DeserializeObject<SabreHotelResponse>(jsonResponse);
                if (hotelAvailRS.GetHotelAvailRS.ApplicationResults.Status.ToLower() == "unknown")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error during processing, please retry later.");
                    Console.ForegroundColor = ConsoleColor.White;
                    return null;
                }

                return ConvertToHotelResponseList(hotelAvailRS.GetHotelAvailRS);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid request. Please try again.");
                Console.ForegroundColor = ConsoleColor.White;
                return null;
            }
        }
        private List<HotelResponse> ConvertToHotelResponseList(GetHotelAvailRS hotelAvailRS)
        {
            List<HotelResponse> hotelResponses = new List<HotelResponse>();

            foreach (var item in hotelAvailRS.HotelAvailInfos.HotelAvailInfo)
            {
                var result = new HotelResponse
                {
                    Hotel = item.HotelInfo.HotelName,
                    Rate = item.HotelRateInfo.RateInfos.Count,
                    City = item.HotelInfo?.LocationInfo.Address?.CityName?.Value ?? "",

                };
                item.HotelRateInfo.RateInfos.ForEach(r =>
               {
                   result.HotelRates.Add(new HotelRate { Amount = r.AmountAfterTax, Currency = r.CurrencyCode });
               });
            }
            return hotelResponses;
        }

    }
}
