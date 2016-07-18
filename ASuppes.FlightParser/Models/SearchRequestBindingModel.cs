using System;

namespace ASuppes.FlightParser.Models
{
    public class SearchRequestBindingModel
    {
        public string DeparturePlace { get; set; }
        public string DestinationPlace { get; set; }
        public DateTime? DepartureDate { get; set; }
        public DateTime? DepartureLocalTime { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime? ReturnLocalTime { get; set; }
    }
}