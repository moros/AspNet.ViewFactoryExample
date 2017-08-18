using System.Web.Mvc;

namespace ViewFactoryExample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}