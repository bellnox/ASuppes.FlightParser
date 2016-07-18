namespace ASuppes.FlightParser.Models
{
    public class ResultRouteModel
    {
        public string DepartureCityName { get; set; }
        public string DestinationCityName { get; set; }
        public ResultFlightModel[] Flights { get; set; }
        public bool IsReturn { get; set; }
    }
}