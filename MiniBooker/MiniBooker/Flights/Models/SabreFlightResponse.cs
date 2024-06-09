using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBooker.Flights.Models.Sabre.Flight
{
    public sealed class SabreFlightResponse
    {
        public List<PricedItinerary> PricedItineraries { get; set; }
        public DateTime ReturnDateTime { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public string DestinationLocation { get; set; }
        public string OriginLocation { get; set; }
        public Page Page { get; set; }
        public List<Link> Links { get; set; }
    }

    public sealed class PricedItinerary
    {
        public AirItinerary AirItinerary { get; set; }
        public TpaExtensions TpaExtensions { get; set; }
        public int SequenceNumber { get; set; }
        public AirItineraryPricingInfo AirItineraryPricingInfo { get; set; }
        public TicketingInfo TicketingInfo { get; set; }
    }

    public sealed class AirItinerary
    {
        public OriginDestinationOptions OriginDestinationOptions { get; set; }
        public string DirectionInd { get; set; }
    }

    public sealed class OriginDestinationOptions
    {
        public List<OriginDestinationOption> OriginDestinationOption { get; set; }
    }

    public sealed class OriginDestinationOption
    {
        public List<FlightSegment> FlightSegment { get; set; }
        public int ElapsedTime { get; set; }
    }

    public sealed class FlightSegment
    {
        public Airport DepartureAirport { get; set; }
        public Airport ArrivalAirport { get; set; }
        public Airline MarketingAirline { get; set; }
        public Airline OperatingAirline { get; set; }
        public TimeZoneInfo DepartureTimeZone { get; set; }
        public TimeZoneInfo ArrivalTimeZone { get; set; }
        public TpaExtensions TpaExtensions { get; set; }
        public int StopQuantity { get; set; }
        public int ElapsedTime { get; set; }
        public string ResBookDesigCode { get; set; }
        public string MarriageGrp { get; set; }
        public Equipment Equipment { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public int FlightNumber { get; set; }
    }

    public sealed class Airport
    {
        public string LocationCode { get; set; }
    }

    public sealed class Airline
    {
        public string Code { get; set; }
        public int FlightNumber { get; set; }
    }

    public sealed class TimeZoneInfo
    {
        public int GMTOffset { get; set; }
    }

    public sealed class TpaExtensions
    {
        public ETicket eTicket { get; set; }
        public ValidatingCarrier ValidatingCarrier { get; set; }
        public DivideInParty DivideInParty { get; set; }
        public List<FareInfo> FareInfo { get; set; }
        public CabinInfo Cabin { get; set; }
        public Meal Meal { get; set; }
        public SeatsRemaining SeatsRemaining { get; set; }
    }

    public sealed class ETicket
    {
        public bool Ind { get; set; }
    }

    public sealed class ValidatingCarrier
    {
        public string Code { get; set; }
    }

    public sealed class DivideInParty
    {
        public bool Indicator { get; set; }
    }

    public sealed class FareInfo
    {
        public string FareReference { get; set; }
        public TpaExtensions TpaExtensions { get; set; }
    }

    public sealed class CabinInfo
    {
        public string Cabin { get; set; }
    }

    public sealed class Meal
    {
        public string Code { get; set; }
    }

    public sealed class SeatsRemaining
    {
        public bool BelowMin { get; set; }
        public int Number { get; set; }
    }

    public sealed class Equipment
    {
        public string AirEquipType { get; set; }
    }

    public sealed class AirItineraryPricingInfo
    {
        public DateTime LastTicketDate { get; set; }
        public PtcFareBreakdowns PtcFareBreakdowns { get; set; }
        public ItinTotalFare ItinTotalFare { get; set; }
        public FareInfos FareInfos { get; set; }
    }

    public sealed class PtcFareBreakdowns
    {
        public PtcFareBreakdown PtcFareBreakdown { get; set; }
    }

    public sealed class PtcFareBreakdown
    {
        public FareBasisCodes FareBasisCodes { get; set; }
        public PassengerTypeQuantity PassengerTypeQuantity { get; set; }
        public PassengerFare PassengerFare { get; set; }
        public Endorsements Endorsements { get; set; }
    }

    public sealed class FareBasisCodes
    {
        public List<FareBasisCode> FareBasisCode { get; set; }
    }

    public sealed class FareBasisCode
    {
        public string BookingCode { get; set; }
        public string DepartureAirportCode { get; set; }
        public string ArrivalAirportCode { get; set; }
        public string Content { get; set; }
        public bool? AvailabilityBreak { get; set; }
    }

    public sealed class PassengerTypeQuantity
    {
        public int Quantity { get; set; }
        public string Code { get; set; }
    }

    public sealed class PassengerFare
    {
        public FareConstruction FareConstruction { get; set; }
        public TotalFare TotalFare { get; set; }
        public Taxes Taxes { get; set; }
        public BaseFare BaseFare { get; set; }
        public EquivFare EquivFare { get; set; }
    }

    public sealed class FareConstruction
    {
        public string CurrencyCode { get; set; }
        public int DecimalPlaces { get; set; }
        public double Amount { get; set; }
    }

    public sealed class TotalFare
    {
        public string CurrencyCode { get; set; }
        public double Amount { get; set; }
    }

    public sealed class Taxes
    {
        public TotalTax TotalTax { get; set; }
        public List<Tax> Tax { get; set; }
    }

    public sealed class TotalTax
    {
        public string CurrencyCode { get; set; }
        public int DecimalPlaces { get; set; }
        public double Amount { get; set; }
    }

    public sealed class Tax
    {
        public string CurrencyCode { get; set; }
        public int DecimalPlaces { get; set; }
        public string TaxCode { get; set; }
        public double Amount { get; set; }
    }

    public sealed class BaseFare
    {
        public string CurrencyCode { get; set; }
        public double Amount { get; set; }
    }

    public sealed class EquivFare
    {
        public string CurrencyCode { get; set; }
        public int DecimalPlaces { get; set; }
        public double Amount { get; set; }
    }

    public sealed class Endorsements
    {
        public bool NonRefundableIndicator { get; set; }
    }

    public sealed class FareInfos
    {
        public List<FareInfo> FareInfo { get; set; }
    }

    public sealed class ItinTotalFare
    {
        public FareConstruction FareConstruction { get; set; }
        public TotalFare TotalFare { get; set; }
        public Taxes Taxes { get; set; }
        public BaseFare BaseFare { get; set; }
        public EquivFare EquivFare { get; set; }
    }

    public sealed class TicketingInfo
    {
        public string ValidInterline { get; set; }
        public string TicketType { get; set; }
    }

    public sealed class Page
    {
        public int Size { get; set; }
        public int TotalTags { get; set; }
        public int Offset { get; set; }
    }

    public sealed class Link
    {
        public string Rel { get; set; }
        public string Href { get; set; }
    }
}


