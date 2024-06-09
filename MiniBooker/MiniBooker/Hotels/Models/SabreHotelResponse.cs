namespace MiniBooker.Hotels.Models.Sabre
{

    public sealed class SabreHotelResponse
    {
        public GetHotelAvailRS GetHotelAvailRS { get; set; }
    }

    public sealed class GetHotelAvailRS
    {
        public ApplicationResults ApplicationResults { get; set; }
        public HotelAvailInfos HotelAvailInfos { get; set; }
    }

    public sealed class ApplicationResults
    {
        public string Status { get; set; }
        public List<Success> Success { get; set; }
        public List<Warning> Warning { get; set; }
    }

    public sealed class Success
    {
        public DateTime TimeStamp { get; set; }
    }

    public sealed class Warning
    {
        public string Type { get; set; }
        public DateTime TimeStamp { get; set; }
        public List<SystemSpecificResults> SystemSpecificResults { get; set; }
    }

    public sealed class SystemSpecificResults
    {
        public List<Message> Message { get; set; }
    }

    public sealed class Message
    {
        public string Code { get; set; }
        public string Value { get; set; }
    }

    public sealed class HotelAvailInfos
    {
        public int OffSet { get; set; }
        public int MaxSearchResults { get; set; }
        public string ShopKey { get; set; }
        public double SearchLatitude { get; set; }
        public double SearchLongitude { get; set; }
        public List<HotelAvailInfo> HotelAvailInfo { get; set; }
    }

    public sealed class HotelAvailInfo
    {
        public HotelInfo HotelInfo { get; set; }
        public HotelRateInfo HotelRateInfo { get; set; }
    }

    public sealed class HotelInfo
    {
        public string HotelCode { get; set; }
        public string CodeContext { get; set; }
        public string HotelName { get; set; }
        public string ChainCode { get; set; }
        public string ChainName { get; set; }
        public string BrandCode { get; set; }
        public string BrandName { get; set; }
        public double Distance { get; set; }
        public string Direction { get; set; }
        public string UOM { get; set; }
        public double SabreRating { get; set; }
        public int Ordinal { get; set; }
        public string SabreHotelCode { get; set; }
        public bool CanReturnRequestedNegotiatedRate { get; set; }
        public LocationInfo LocationInfo { get; set; }
        public List<Amenity> Amenities { get; set; }
        public List<SecurityFeature> SecurityFeatures { get; set; }
        public List<PropertyQuality> PropertyQualityInfo { get; set; }
    }

    public sealed class LocationInfo
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Address Address { get; set; }
        public Contact Contact { get; set; }
    }

    public sealed class Address
    {
        public string AddressLine1 { get; set; }
        public CityName CityName { get; set; }
        public StateProv StateProv { get; set; }
        public string PostalCode { get; set; }
        public CountryName CountryName { get; set; }
    }

    public sealed class CityName
    {
        public string CityCode { get; set; }
        public string Value { get; set; }
    }

    public sealed class StateProv
    {
        public string StateCode { get; set; }
        public string Value { get; set; }
    }

    public sealed class CountryName
    {
        public string Code { get; set; }
        public string Value { get; set; }
    }

    public sealed class Contact
    {
        public string Phone { get; set; }
        public string Fax { get; set; }
    }

    public sealed class Amenity
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public bool? ComplimentaryInd { get; set; }
    }

    public sealed class SecurityFeature
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
    }

    public sealed class PropertyQuality
    {
        public int Code { get; set; }
        public string Description { get; set; }
    }

    public sealed class HotelRateInfo
    {
        public List<RateInfo> RateInfos { get; set; }
        public List<Room> Rooms { get; set; }
    }

    public sealed class RateInfo
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal AmountBeforeTax { get; set; }
        public decimal AmountAfterTax { get; set; }
        public decimal AverageNightlyRate { get; set; }
        public decimal AverageNightlyRateBeforeTax { get; set; }
        public decimal HighestNightlyRate { get; set; }
        public decimal ApproxTotalPrice { get; set; }
        public string CurrencyCode { get; set; }
        public bool AdditionalFeesInclusive { get; set; }
        public bool TaxInclusive { get; set; }
    }

    public sealed class Room
    {
        public int RoomIndex { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public BedTypeOptions BedTypeOptions { get; set; }
        public RoomDescription RoomDescription { get; set; }
        public List<RatePlan> RatePlans { get; set; }
    }

    public sealed class BedTypeOptions
    {
        public List<BedType> BedTypes { get; set; }
    }

    public sealed class BedType
    {
        public int Code { get; set; }
        public string Description { get; set; }
    }

    public sealed class RoomDescription
    {
        public string Name { get; set; }
        public List<string> Text { get; set; }
    }

    public sealed class RatePlan
    {
        public string RatePlanName { get; set; }
        public string RatePlanType { get; set; }
        public string RatePlanTypeDescription { get; set; }
        public bool PrepaidIndicator { get; set; }
        public int AvailableQuantity { get; set; }
        public string RateSource { get; set; }
        public string RateKey { get; set; }
        public bool LoyaltyPoints { get; set; }
        public RatePlanDescription RatePlanDescription { get; set; }
        public ConvertedRateInfo ConvertedRateInfo { get; set; }
    }

    public sealed class RatePlanDescription
    {
        public List<string> Text { get; set; }
    }

    public sealed class ConvertedRateInfo
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal AmountBeforeTax { get; set; }
        public decimal AmountAfterTax { get; set; }
        public decimal AverageNightlyRate { get; set; }
        public decimal AverageNightlyRateBeforeTax { get; set; }
        public decimal HighestNightlyRate { get; set; }
        public decimal ApproxTotalPrice { get; set; }
        public string CurrencyCode { get; set; }
        public bool AdditionalFeesInclusive { get; set; }
        public bool TaxInclusive { get; set; }
        public List<Tax> Taxes { get; set; }
        public List<CancelPenalty> CancelPenalties { get; set; }
        public Guarantee Guarantee { get; set; }
    }

    public sealed class Tax
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public List<TaxGroup> TaxGroups { get; set; }
    }

    public sealed class TaxGroup
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public TaxDescription TaxDescription { get; set; }
    }

    public sealed class TaxDescription
    {
        public List<string> Text { get; set; }
    }

    public sealed class CancelPenalty
    {
        public bool Refundable { get; set; }
        public PenaltyDescription PenaltyDescription { get; set; }
    }

    public sealed class PenaltyDescription
    {
        public List<string> Text { get; set; }
    }

    public sealed class Guarantee
    {
        public string GuaranteeType { get; set; }
        public GuaranteesAccepted GuaranteesAccepted { get; set; }
    }

    public sealed class GuaranteesAccepted
    {
        public List<GuaranteeAccepted> GuaranteeAccepted { get; set; }
    }

    public sealed class GuaranteeAccepted
    {
        public int GuaranteeTypeCode { get; set; }
        public string GuaranteeTypeDescription { get; set; }
    }

}

