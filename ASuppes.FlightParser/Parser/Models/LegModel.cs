using System;

namespace ASuppes.FlightParser.Parser.Models
{
    public class LegModel
    {
        public int AirlineIndex { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime Departure { get; set; }
        public int DestinationIndex { get; set; }
        public int Duration { get; set; }
        public string FlightNumber { get; set; }
        public string Key { get; set; }
        public int OriginIndex { get; set; }
    }
}