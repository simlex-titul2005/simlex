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

#if !DEBUG
        [OutputCache(Duration = 3600)]
#endif
        [HttpGet]
        public async Task<ActionResult> Details(int year, string month, string day, string titleUrl)
        {
            var viewModel = await Repo.GetByTitleUrlAsync(year, month, day, titleUrl);
            if (viewModel == null) return new HttpNotFoundResult();
            viewModel.RelatedMaterials = await Repo.GetRelatedAsync<VMMaterial>(new SX.WebCore.SxFilter(1, 5) {
                MaterialId=viewModel.Id
            });
            viewModel.Comments = await CommentsController.Repo.ReadAsync(new SX.WebCore.SxFilter(1, 10)
            {
                MaterialId=viewModel.Id,
                ModelCoreType=viewModel.ModelCoreType
            });
            return View(model: viewModel);
        }

#if !DEBUG
        [OutputCache(Duration = 3600)]
#endif
        public PartialViewResult Statistic()
        {
            var viewModel = new VMMaterialsStatisticBlock()
            {
                Materials = Repo.Read(new SX.WebCore.SxFilter(1, 10)),
                CommentedMaterials = Repo.LastCommented<VMMaterial>(new SX.WebCore.SxFilter(1, 10) { ModelCoreType=1 }),
                Tags = MaterialTagsController.Repo.GetCloud(new SX.WebCore.SxFilter(1, 10))
            };

            return PartialView("_Statistic", viewModel);
        }
    }
}