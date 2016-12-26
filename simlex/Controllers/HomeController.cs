using simlex.Controllers.Abstract;
using System.Web.Mvc;

namespace simlex.Controllers
{
    public sealed class HomeController : BaseController
    {

#if !DEBUG
        [OutputCache(Duration = 3600)]
#endif
        public PartialViewResult Statistic()
        {
            var viewModel = new ViewModels.MaterialsStatisticBlock()
            {
                Materials = new ArticlesController().Repo.Read(new SX.WebCore.SxFilter(1, 10)),
                Comments = CommentsController.Repo.Read(new SX.WebCore.SxFilter(1, 10)),
                Tags = MaterialTagsController.Repo.GetCloud(new SX.WebCore.SxFilter(1, 10))
            };

            return PartialView("_Statistic", viewModel);
        }
    }
}