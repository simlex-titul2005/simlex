using System.Web.Mvc;

namespace simlex.Controllers
{
    public sealed class HomeController : BaseController
    {
        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }
    }
}