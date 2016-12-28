using SX.WebCore.MvcControllers;
using System.Web.Mvc;

namespace simlex.Controllers
{
    public sealed class SiteNetsController : SxSiteNetsController
    {

#if !DEBUG
        [OutputCache(Duration = 3600)]
#endif
        [AllowAnonymous, ChildActionOnly]
        public PartialViewResult Accordion()
        {
            var viewModel = SX.WebCore.MvcApplication.SxMvcApplication.SiteNetsProvider.SiteNets;
            return PartialView("_Accordion", viewModel);
        }
    }
}