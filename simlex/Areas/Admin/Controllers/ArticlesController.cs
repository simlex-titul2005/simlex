using simlex.Controllers.Abstract;
using simlex.Models;
using simlex.ViewModels;
using SX.WebCore.SxRepositories;
using simlex.Infrastructure.Repositories;
using SX.WebCore;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace simlex.Areas.Admin.Controllers
{
    public sealed class ArticlesController : MaterialsController<Article, VMArticle>
    {
        public ArticlesController() : base((byte)Enums.ModelCoreType.Article) { }

        private static RepoArticle _repo = new RepoArticle();
        public override RepoMaterial<Article, VMArticle> Repo
        {
            get
            {
                return _repo;
            }
        }

        public override async Task<ActionResult> Index(int page = 1)
        {
            ViewBag.Title = "Статьи";
            return await base.Index(page);
        }
    }
}