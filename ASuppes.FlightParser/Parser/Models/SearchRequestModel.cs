namespace ASuppes.FlightParser.Parser.Models
{
    public class SearchRequestModel
    {
        public int AdultCount { get; set; }
        public int[] ChildAges { get; set; }
        public string Culture { get; set; }
        public bool DirectOnly { get; set; }
        public bool IncludeNearby { get; set; }
        public string Market { get; set; }
        public string Mix { get; set; }
        public SearchRequestSegmentModel[] Segments { get; set; }
        public string TicketClass { get; set; }
    }
}