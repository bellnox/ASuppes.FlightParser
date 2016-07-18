namespace ASuppes.FlightParser.Parser.Models
{
    public class SearchPartialModel
    {
	    public bool Done { get; set; }
	    public bool Error { get; set; }
	    public string ErrorMessage { get; set; }
	    public int ResultNumber { get; set; }
        public AirportModel[] Airports { get; set; }
	    public AirlineModel[] Airlines { get; set; }
	    public FlightModel[] Flights { get; set; }
	    public LegModel[] Legs { get; set; }
	    public OfferModel[] Offers { get; set; }
	    public SegmentModel[] Segments { get; set; }
    }
}