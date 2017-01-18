using System.Threading.Tasks;
using System.Web.Mvc;
using SX.WebCore.MvcControllers;
using SX.WebCore.ViewModels;

namespace simlex.Controllers
{
    public sealed class AccountController : SxAccountController
    {
        public override Task<ActionResult> Login(SxVMLogin model, string returnUrl)
        {
            return base.Login(model, Url.Action("List", "Articles"));
        }

        public override ActionResult LogOff(string url = null)
        {
            url = Url.Action("List", "Articles");
            return base.LogOff(url);
        }
    }
}