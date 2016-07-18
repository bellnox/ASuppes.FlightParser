using ASuppes.FlightParser.Properties;
using System.Web.Mvc;

namespace ASuppes.FlightParser.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = Resources.AppTitle;
            return View();
        }
    }
}
