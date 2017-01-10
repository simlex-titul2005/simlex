using System;
using System.Collections.Generic;
using SX.WebCore.MvcControllers;
using SX.WebCore.ViewModels;
using SX.WebCore;

namespace simlex.Controllers
{
    public sealed class SeoController : SxSeoController
    {
        protected override Action<HashSet<SxVMSiteMapUrl>> BeforeGenerateAction => (data) => {
            var item = new SxVMSiteMapUrl(Url.ContentAbsUrl(Url.Action("List", "Articles")));
            data.Add(item);
        };

        protected override Func<dynamic, string> SeoItemUrlFunc => (model) =>
        {
            var url = string.Empty;
            var m = model as SxVMMaterial;
            if (m != null)
            {
                switch (m.ModelCoreType)
                {
                    case 1:
                        url= Url.Action("Details", "Articles", new { year = m.DateCreate.Year, month = m.DateCreate.Month.ToString("00"), day = m.DateCreate.Day.ToString("00"), titleUrl = m.TitleUrl });
                        break;
                }
            }

            return url;
        };

        protected override Action<HashSet<SxVMSiteMapUrl>> AfterGenerateAction => (data) => {
            
        };
    }
}