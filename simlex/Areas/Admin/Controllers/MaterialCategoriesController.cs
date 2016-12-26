using System.Web.Mvc;
using SX.WebCore.DbModels;
using SX.WebCore.MvcControllers;
using SX.WebCore.ViewModels;
using SX.WebCore;

namespace simlex.Areas.Admin.Controllers
{
    public sealed class MaterialCategoriesController : SxMaterialCategoriesController<SxMaterialCategory, SxVMMaterialCategory>
    {
        public override ActionResult Index(byte? mct, int page = 1)
        {
            ViewBag.PageTitle = getTitle(mct);
            return base.Index(mct, page);
        }

        private static string getTitle(byte? mct)
        {
            switch(mct)
            {
                default: return null;
                case (byte)Enums.ModelCoreType.Article:
                    return "Категории статей";
            }
        } 
    }
}