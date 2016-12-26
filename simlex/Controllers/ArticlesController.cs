using simlex.Models;
using simlex.ViewModels;
using SX.WebCore.SxRepositories;
using simlex.Infrastructure.Repositories;
using simlex.Controllers.Abstract;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace simlex.Controllers
{
    public sealed class ArticlesController : MaterialsController<Article, VMArticle>
    {
        public ArticlesController() : base(ModelCoreTypeProvider[nameof(Article)]) { }

        private static readonly RepoArticle _repo = new RepoArticle();
        public override SxRepoMaterial<Article, VMArticle> Repo
        {
            get
            {
                return _repo;
            }
        }

        [HttpGet]
        public async Task<ActionResult> Details(int year, string month, string day, string titleUrl)
        {
            var viewModel = await Repo.GetByTitleUrlAsync(year, month, day, titleUrl);
            if (viewModel == null) return new HttpNotFoundResult();
            return View(model: viewModel);
        }
    }
}