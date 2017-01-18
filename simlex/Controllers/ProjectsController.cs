using simlex.Controllers.Abstract;
using simlex.Infrastructure.Repositories;
using simlex.Models;
using simlex.ViewModels;
using SX.WebCore.MvcApplication;
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

        [HttpGet]
        public async Task<ActionResult> Details(string titleUrl)
        {
            var viewModel = await Repo.GetByTitleUrlAsync(null, null, null, titleUrl);
            if (viewModel == null) return new HttpNotFoundResult();

            return View(viewModel);
        }
    }
}