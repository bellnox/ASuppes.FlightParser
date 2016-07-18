namespace ASuppes.FlightParser.Parser.Models
{
    public class SegmentModel
    {
        public int Duration { get; set; }
        public string Key { get; set; }
        public int[] LegIndexes { get; set; }
    }
}