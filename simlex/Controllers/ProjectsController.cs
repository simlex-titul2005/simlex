using simlex.Controllers.Abstract;
using simlex.Infrastructure.Repositories;
using simlex.Models;
using simlex.ViewModels;
using SX.WebCore.MvcApplication;
using SX.WebCore.MvcControllers;
using SX.WebCore.SxRepositories;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace simlex.Controllers
{
    public sealed class ProjectsController : MaterialsController<Project, VMProject>
    {
        private static readonly RepoProject _repo = new RepoProject();
        public override SxRepoMaterial<Project, VMProject> Repo
        {
            get
            {
                return _repo;
            }
        }
        public ProjectsController() : base(SxMvcApplication.ModelCoreTypeProvider[nameof(Project)]) { }

#if !DEBUG
        [OutputCache(Duration = 3600, VaryByParam = "titleUrl")]
#endif
        [HttpGet]
        public async Task<ActionResult> Details(string titleUrl)
        {
            var viewModel = await Repo.GetByTitleUrlAsync(null, null, null, titleUrl);
            if (viewModel == null) return new HttpNotFoundResult();

            viewModel.Comments = await SxCommentsController.Repo.ReadAsync(new SX.WebCore.SxFilter(1, 10)
            {
                MaterialId = viewModel.Id,
                ModelCoreType = viewModel.ModelCoreType
            });

            return View(model: viewModel);
        }
    }
}