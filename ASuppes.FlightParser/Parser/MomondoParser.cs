using ASuppes.FlightParser.Models;
using ASuppes.FlightParser.Parser.Models;
using ASuppes.FlightParser.Parser.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ASuppes.FlightParser.Parser
{
    public class MomondoParser : IFlightParser
    {
        private string commonContentType = "application/json;charset=UTF-8";
        private Dictionary<string, string> commonHeaders;
        private IHttpClient httpClient;
        private IJsonParser jsonParser;

        public MomondoParser(IHttpClient httpClient, IJsonParser jsonParser)
        {
            this.httpClient = httpClient;
            this.jsonParser = jsonParser;
            this.commonHeaders = new Dictionary<string, string>
            {
                { "X-Distil-Ajax", "ayrvvdbuzqbdfzxt" },
                { "X-Requested-With", "XMLHttpRequest" }
            };
        }

        public Task<SearchResultModel> GetSearchStatus(SearchRequestBindingModel searchRequest)
        {
            return Task<SearchResultModel>.Run(() => {
                string searchId = LoadSearchData(searchRequest);
                SearchSummaryModel searchResult = LoadTicketsData(searchId);
                BestOfferFinder offerFinder = new BestOfferFinder(searchResult);
                return offerFinder.GetBestOffer();
            });
        }

        private string FormatDateString(DateTime date)
        {
            return date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        }

        private string FormatDateTimeString(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture);
        }

        private SearchRequestModel CreateServiceRequest(SearchRequestBindingModel searchRequest)
        {
            DateTime departureDate = searchRequest.DepartureDate.Value;
            DateTime departurelocalTime = searchRequest.DepartureLocalTime.Value;
            DateTime returnDate = searchRequest.ReturnDate.Value;
            DateTime returnLocalTime = searchRequest.ReturnLocalTime.Value;
            return new SearchRequestModel
            {
                AdultCount = 1,
                ChildAges = new int[0],
                Culture = "ru-RU",
                DirectOnly = false,
                IncludeNearby = false,
                Market = string.Empty,
                Mix = "None",
                Segments = new SearchRequestSegmentModel[] 
                {
                    new SearchRequestSegmentModel
                    {
                        Origin = searchRequest.DeparturePlace,
                        Destination = searchRequest.DestinationPlace,
                        Depart = FormatDateTimeString(departurelocalTime),
                        Departure = FormatDateString(departureDate)
                    },
                    new SearchRequestSegmentModel
                    {
                        Origin = searchRequest.DestinationPlace,
                        Destination = searchRequest.DeparturePlace,
                        Depart = FormatDateTimeString(returnLocalTime),
                        Departure = FormatDateString(returnDate)
                    }
                },
                TicketClass = "ECO"
            };
        }

        private string LoadSearchData(SearchRequestBindingModel searchRequest)
        {
            HttpRequestData request = new HttpRequestData(
                "http://www.momondo.ru/api/3.0/FlightSearch",
                commonContentType,
                jsonParser.SerializeObject(CreateServiceRequest(searchRequest)),
                commonHeaders.ToArray());
            var response = httpClient.Post(request);
            SearchRequestResultModel responseModel = 
                string.IsNullOrEmpty(response.Content)
                    ? null
                    : jsonParser.DeserializeObject<SearchRequestResultModel>(response.Content);
            return responseModel == null ? null : responseModel.SearchId;
        }

        private SearchSummaryModel LoadTicketsData(string searchId)
        {
            List<SearchPartialModel> tickets = new List<SearchPartialModel>();
            while (true)
            {
                HttpRequestData request = new HttpRequestData(
                    string.Format("http://www.momondo.ru/api/3.0/FlightSearch/{0}/0/true", searchId),
                    commonContentType,
                    commonHeaders.ToArray());
                var response = httpClient.Get(request);
                if (response == null || string.IsNullOrEmpty(response.Content))
                {
                    break;
                }
                SearchPartialModel res = jsonParser.DeserializeObject<SearchPartialModel>(response.Content);
                if (res != null)
                {
                    tickets.Add(res);
                }
                if (res == null || res.Done)
                {
                    break;
                }
            }

            SearchSummaryModel result = new SearchSummaryModel();
            foreach (SearchPartialModel data in tickets.OrderBy(t => t.ResultNumber))
            {
                result.AddPart(data);
            }
            return result;
        }
    }
}