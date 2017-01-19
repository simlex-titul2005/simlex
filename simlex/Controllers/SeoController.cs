using simlex.ViewModels;
using SX.WebCore.MvcControllers;
using SX.WebCore.ViewModels;
using System;
using System.Collections.Generic;
using SX.WebCore;

namespace simlex.Controllers
{
    public sealed class SeoController : SxSeoController
    {
        protected override Action<HashSet<SxVMSiteMapUrl>> BeforeGenerateAction => (items) => {
            items.Add(new SxVMSiteMapUrl(Url.ContentAbsUrl(Url.Action("List", "Articles"))));
        };

        protected override Func<dynamic, string> SeoItemUrlFunc => (model) =>
        {
            var data = (SxVMMaterial)model;
            if (data == null) return string.Empty;

            var item = Mapper.Map<SxVMMaterial, VMMaterial>(data);
            return item.GetUrl(Url);
        };
    }
}