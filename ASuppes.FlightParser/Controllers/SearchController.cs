using ASuppes.FlightParser.Models;
using ASuppes.FlightParser.Parser;
using ASuppes.FlightParser.Properties;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace ASuppes.FlightParser.Controllers
{
    public class SearchController : ApiController
    {
        IFlightParser parser;

        public SearchController(IFlightParser parser)
        {
            this.parser = parser;
        }

        public async Task<IHttpActionResult> Post(SearchRequestBindingModel model)
        {
            if (model == null)
            {
                return Content(HttpStatusCode.BadRequest, Resources.SearchRequestEmptyRequestError);
            }
            if (string.IsNullOrEmpty(model.DeparturePlace))
            {
                return Content(HttpStatusCode.BadRequest, Resources.SearchRequestEmptyDeparturePlaceError);
            }
            if (string.IsNullOrEmpty(model.DestinationPlace))
            {
                return Content(HttpStatusCode.BadRequest, Resources.SearchRequestEmptyDestinationPlaceError);
            }
            if (!model.DepartureDate.HasValue || !model.DepartureLocalTime.HasValue)
            {
                return Content(HttpStatusCode.BadRequest, Resources.SearchRequestEmptyDepartureDateError);
            }
            if (!model.ReturnDate.HasValue || !model.ReturnLocalTime.HasValue)
            {
                return Content(HttpStatusCode.BadRequest, Resources.SearchRequestEmptyReturnDateError);
            }
            if (model.ReturnDate.Value <= model.DepartureDate.Value)
            {
                return Content(HttpStatusCode.BadRequest, Resources.SearchRequestReturnBeforeDepartureError);
            }
            return Content(HttpStatusCode.OK, await parser.GetSearchStatus(model));
        }
    }
}
