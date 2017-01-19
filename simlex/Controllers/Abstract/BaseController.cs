using SX.WebCore.MvcControllers.Abstract;
using SX.WebCore.ViewModels;
using System;
using System.Collections.Generic;

namespace simlex.Controllers.Abstract
{
    public abstract class BaseController : SxBaseController
    {
        protected override Action<SxBaseController, HashSet<SxVMBreadcrumb>> FillBreadcrumbs
            => Infrastructure.BreadcrumbsProvider.FillBreadcrumbs;
    }
}