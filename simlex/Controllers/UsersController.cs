using SX.WebCore.MvcControllers;
using SX.WebCore.MvcControllers.Abstract;
using SX.WebCore.ViewModels;
using System;
using System.Collections.Generic;

namespace simlex.Controllers
{
    public sealed class UsersController : SxUsersController
    {
        protected override Action<SxBaseController, HashSet<SxVMBreadcrumb>> FillBreadcrumbs => Infrastructure.BreadcrumbsProvider.FillBreadcrumbs;
    }
}