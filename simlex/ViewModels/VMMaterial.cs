using System.Web.Mvc;
using SX.WebCore.ViewModels;

namespace simlex.ViewModels
{
    public class VMMaterial : SxVMMaterial
    {
        public VMMaterial()
        {
            RelatedMaterials = new VMMaterial[0];
        }

        public VMMaterial[] RelatedMaterials { get; set; }

        public sealed override string GetUrl(UrlHelper urlHelper)
        {
            switch (ModelCoreType)
            {
                default: return base.GetUrl(urlHelper);
                case 1: return urlHelper.Action("Details", "Articles", new { year = DateCreate.Year, month = DateCreate.Month.ToString("00"), day = DateCreate.Day.ToString("00"), titleUrl = TitleUrl });
            }
        }
    }
}