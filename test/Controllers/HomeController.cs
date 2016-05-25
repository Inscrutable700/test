using System.Web.Mvc;
using System.Web.UI;

namespace test.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [OutputCache(Duration = 5000, Location = OutputCacheLocation.Any, VaryByParam = "id")]
        public ActionResult CacheTest(int id)
        {
            ViewBag.Date = id;
            return View();
        }
    }
}