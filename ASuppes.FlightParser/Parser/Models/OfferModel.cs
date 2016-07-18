namespace ASuppes.FlightParser.Parser.Models
{
    public class OfferModel
    {
        public string Currency { get; set; }
        public string Deeplink { get; set; }
        public int FlightIndex { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalPriceEUR { get; set; }
    }
}