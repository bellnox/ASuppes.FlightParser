namespace ASuppes.FlightParser.Models
{
    public class SearchResultModel
    {
        public decimal TotalSum { get; set; }
        public string Currency { get; set; }
        public string DetailsLink { get; set; }
        public ResultRouteModel[] Routes { get; set; }
    }
}