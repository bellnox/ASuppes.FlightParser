using ASuppes.FlightParser.Models;
using ASuppes.FlightParser.Parser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASuppes.FlightParser.Parser.Utilities
{
    public class BestOfferFinder
    {
        private SearchSummaryModel searchResults;

        public BestOfferFinder(SearchSummaryModel searchResults)
        {
            this.searchResults = searchResults;
        }

        public SearchResultModel GetBestOffer()
        {
            SearchResultModel resModel = new SearchResultModel();
            var sortedOffers = searchResults.Offers.Where(offer => offer.TotalPriceEUR > 0)
                                            .OrderBy(offer => offer.TotalPriceEUR);
            if (sortedOffers.Any())
            {
                OfferModel bestOffer = sortedOffers.First();
                resModel.TotalSum = bestOffer.TotalPrice;
                resModel.Currency = bestOffer.Currency;
                resModel.DetailsLink = bestOffer.Deeplink;
                var flight = searchResults.Flights[bestOffer.FlightIndex];
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
            AirlineModel airline = searchResults.Airlines[leg.AirlineIndex];
            AirportModel origAirport = searchResults.Airports[leg.OriginIndex];
            AirportModel destAirport = searchResults.Airports[leg.DestinationIndex];
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
                flights.Add(GetFlight(searchResults.Legs[legInd], ind));
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
                routes.Add(GetRoute(searchResults.Segments[segInd], !isFirst));
                isFirst = false;
            }
            return routes.ToArray();
        }
    }
}