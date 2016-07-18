namespace ASuppes.FlightParser.Models
{
    public class ResultFlightModel
    {
        public string AirlineImageUrl { get; set; }
        public string AirlineName { get; set; }
        public string FlightNumber { get; set; }
        public string DepartureCityName { get; set; }
        public string DepartureAirport { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalCityName { get; set; }
        public string ArrivalAirport { get; set; }
        public string ArrivalTime { get; set; }
        public int OrderNumber { get; set; }
    }
}