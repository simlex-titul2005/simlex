using simlex.ViewModels;
using SX.WebCore.DbModels.Abstract;
using SX.WebCore.MvcControllers;

namespace simlex.Controllers.Abstract
{
    public abstract class MaterialsController<TModel, TViewModel> : SxMaterialsController<TModel, TViewModel>
        where TModel : SxMaterial, new()
        where TViewModel : VMMaterial, new()
    {
        public MaterialsController(byte mct) : base(mct) { }
    }
}