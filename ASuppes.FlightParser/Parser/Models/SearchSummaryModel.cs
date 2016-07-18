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

        public SearchResultModel FindBestOption()
        {
            SearchResultModel resModel = new SearchResultModel();
            var sortedOffers = Offers.Where(offer => offer.TotalPriceEUR > 0)
                                     .OrderBy(offer => offer.TotalPriceEUR);
            if (sortedOffers.Any())
            {
                OfferModel bestOffer = sortedOffers.First();
                resModel.TotalSum = bestOffer.TotalPrice;
                resModel.Currency = bestOffer.Currency;
                resModel.DetailsLink = bestOffer.Deeplink;
                var flight = Flights[bestOffer.FlightIndex];
                resModel.Routes = GetRoutes(flight);
            }
            return resModel;
        }

        private string DisplayDateTimeString(DateTime dateTime)
        {
            return dateTime.ToShortDateString() + " " + dateTime.ToShortTimeString();
        }

        private ResultFlightModel GetFlight(LegModel leg, int orderNumber)
        {
            AirlineModel airline = Airlines[leg.AirlineIndex];
            AirportModel origAirport = Airports[leg.OriginIndex];
            AirportModel destAirport = Airports[leg.DestinationIndex];
            return new ResultFlightModel
            {
                AirlineImageUrl = string.Format("https://cdn1.momondo.net/logos/airlines/{0}.png", airline.Iata.ToLower()),
                AirlineName = airline.Name,
                FlightNumber = airline.Iata + leg.FlightNumber,
                DepartureCityName = origAirport.MainCityName,
                DepartureAirport = origAirport.DisplayName,
                DepartureTime = DisplayDateTimeString(leg.Departure),
                ArrivalCityName = destAirport.MainCityName,
                ArrivalAirport = destAirport.DisplayName,
                ArrivalTime = DisplayDateTimeString(leg.Arrival),
                OrderNumber = orderNumber
            };
        }

        private ResultFlightModel[] GetFlights(SegmentModel segment)
        {
            var flights = new List<FlightParser.Models.ResultFlightModel>();
            int ind = 0;
            foreach (int legInd in segment.LegIndexes)
            {
                ind++;
                flights.Add(GetFlight(Legs[legInd], ind));
            }
            return flights.ToArray();
        }

        private ResultRouteModel GetRoute(SegmentModel segment, bool isReturn)
        {
            ResultFlightModel[] flights = GetFlights(segment);
            return new ResultRouteModel
            {
                DepartureCityName = flights.First().DepartureCityName,
                DestinationCityName = flights.Last().ArrivalCityName,
                Flights = flights,
                IsReturn = isReturn
            };
        }

        private ResultRouteModel[] GetRoutes(FlightModel flight)
        {
            var routes = new List<ResultRouteModel>();
            bool isFirst = true;
            foreach (int segInd in flight.SegmentIndexes)
            {
                routes.Add(GetRoute(Segments[segInd], !isFirst));
                isFirst = false;
            }
            return routes.ToArray();
        }
    }
}