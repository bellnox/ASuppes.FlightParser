using ASuppes.FlightParser.Models;
using System.Threading.Tasks;

namespace ASuppes.FlightParser.Parser
{
    public interface IFlightParser
    {
        Task<SearchResultModel> GetSearchStatus(SearchRequestBindingModel searchRequest);
    }
}
