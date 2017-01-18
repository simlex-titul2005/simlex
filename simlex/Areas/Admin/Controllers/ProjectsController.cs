using System.Threading.Tasks;
using System.Web.Mvc;
using simlex.Controllers.Abstract;
using simlex.Infrastructure.Repositories;
using simlex.Models;
using simlex.ViewModels;
using SX.WebCore.MvcApplication;
using SX.WebCore.SxRepositories;

namespace simlex.Areas.Admin.Controllers
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

        public override Task<ActionResult> Index(int page = 1)
        {
            var mct = SxMvcApplication.ModelCoreTypeProvider[nameof(Project)];
            ViewBag.Title = SxMvcApplication.ModelCoreTypeProvider.ModelCoreTypeNames[mct];
            return base.Index(page);
        }

        public override async Task<ActionResult> Edit(int? id = default(int?))
        {
            ViewBag.Title = $"{(id.HasValue ? "Редактировать" : "Добавить")} проект";
            return await base.Edit(id);
        }
    }
}