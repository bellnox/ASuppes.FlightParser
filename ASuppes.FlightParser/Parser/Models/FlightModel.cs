namespace ASuppes.FlightParser.Parser.Models
{
    public class FlightModel
    {
        public int DirectAirlineIndex { get; set; }
        public string Key { get; set; }
        public int[] SegmentIndexes { get; set; }
    }
}