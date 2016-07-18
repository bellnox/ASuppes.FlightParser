using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ASuppes.FlightParser.Startup))]

namespace ASuppes.FlightParser
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
