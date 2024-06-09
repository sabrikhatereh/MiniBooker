namespace MiniBooker.Hotels.Models
{
    public sealed class HotelResponse
    {
        public string Hotel { get; set; }
        public string City { get; set; }
        public int Rate { get; set; }
        public List<HotelRate> HotelRates { get; set; } = new List<HotelRate>();

        public void Print()
        {

            Console.WriteLine($"Hotel: {Hotel}    City: {City}");
            Console.WriteLine($"Rate: {new string('*', Rate)} ");
            Console.WriteLine("Cost:");
            foreach (var rate in HotelRates)
            {
                Console.WriteLine($" - Amount: {rate.Amount:C}, Currency: {rate.Currency}");
            }
        }
    }

    public class HotelRate
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }
}


