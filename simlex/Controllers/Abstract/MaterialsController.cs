using System;
using System.Collections.Generic;
using simlex.ViewModels;
using SX.WebCore.DbModels.Abstract;
using SX.WebCore.MvcControllers;
using SX.WebCore.MvcControllers.Abstract;
using SX.WebCore.ViewModels;

namespace simlex.Controllers.Abstract
{
    public abstract class MaterialsController<TModel, TViewModel> : SxMaterialsController<TModel, TViewModel>
        where TModel : SxMaterial, new()
        where TViewModel : VMMaterial, new()
    {
        public MaterialsController(byte mct) : base(mct) { }
        protected override Action<SxBaseController, HashSet<SxVMBreadcrumb>> FillBreadcrumbs => Infrastructure.BreadcrumbsProvider.FillBreadcrumbs;
    }
}