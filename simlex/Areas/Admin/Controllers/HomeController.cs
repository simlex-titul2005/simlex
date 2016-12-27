using simlex.Areas.Admin.Controllers.Abstract;
using System.Web.Mvc;

namespace simlex.Areas.Admin.Controllers
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