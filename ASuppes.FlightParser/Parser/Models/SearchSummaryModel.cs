using ASuppes.FlightParser.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASuppes.FlightParser.Parser.Models
{
    public class SearchSummaryModel
    {
        public List<AirportModel> Airports { get; private set; }
        public List<AirlineModel> Airlines { get; private set; }
        public List<FlightModel> Flights { get; private set; }
        public List<LegModel> Legs { get; private set; }
        public List<OfferModel> Offers { get; private set; }
        public List<SegmentModel> Segments { get; private set; }

        public SearchSummaryModel()
        {
            Airports = new List<AirportModel>();
            Airlines = new List<AirlineModel>();
            Flights = new List<FlightModel>();
            Legs = new List<LegModel>();
            Offers = new List<OfferModel>();
            Segments = new List<SegmentModel>();
        }

        public void AddPart(SearchPartialModel data)
        {
            Airports.AddRange(data.Airports ?? new AirportModel[0]);
            Airlines.AddRange(data.Airlines ?? new AirlineModel[0]);
            Flights.AddRange(data.Flights ?? new FlightModel[0]);
            Legs.AddRange(data.Legs ?? new LegModel[0]);
            Offers.AddRange(data.Offers ?? new OfferModel[0]);
            Segments.AddRange(data.Segments ?? new SegmentModel[0]);
        }
    }
}