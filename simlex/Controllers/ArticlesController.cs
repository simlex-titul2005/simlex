using simlex.Models;
using simlex.ViewModels;
using SX.WebCore.SxRepositories;
using simlex.Infrastructure.Repositories;
using simlex.Controllers.Abstract;

namespace simlex.Controllers
{
    public sealed class ArticlesController : MaterialsController<Article, VMArticle>
    {
        public ArticlesController() : base(ModelCoreTypeProvider[nameof(Article)]) { }

        private static readonly RepoArticle _repo = new RepoArticle();
        public override RepoMaterial<Article, VMArticle> Repo
        {
            get
            {
                return _repo;
            }
        }
    }
}