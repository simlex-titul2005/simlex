using simlex.ViewModels;
using SX.WebCore.DbModels.Abstract;

namespace simlex.Infrastructure.Repositories.Abstract
{
    public abstract class RepoMaterial<TModel, TViewModel> : SX.WebCore.SxRepositories.RepoMaterial<TModel, TViewModel>
        where TModel : SxMaterial
        where TViewModel : VMMaterial
    {
        protected RepoMaterial(byte mct) : base(mct) { }
    }
}