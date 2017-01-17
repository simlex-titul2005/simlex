using SX.WebCore.MvcControllers;
using System.Web.Mvc;
using System.Linq;
using simlex.ViewModels;
using SX.WebCore.DbModels;
using SX.WebCore.ViewModels;
using System.Net;

namespace simlex.Controllers
{
    public sealed class SiteNetsController : SxSiteNetsController
    {

        //#if !DEBUG
        //        [OutputCache(Duration = 3600)]
        //#endif
        [AllowAnonymous, ChildActionOnly]
        public PartialViewResult Accordion()
        {
            var viewModel = SX.WebCore.MvcApplication.SxMvcApplication.CacheProvider.Get<VMNetAccordion>("CACHE_NETS_ACCORDION");
            if (viewModel != null) return PartialView("_Accordion", viewModel);

            viewModel = new VMNetAccordion();
            var nets = SX.WebCore.MvcApplication.SxMvcApplication.SiteNetsProvider.All;
            viewModel.Nets = nets.Select(Mapper.Map<SxSiteNet, SxVMSiteNet>).ToArray();
            if (viewModel.Nets.Any())
            {
                SxVMSiteNet item;
                for (int i = 0; i < viewModel.Nets.Length; i++)
                {
                    item = viewModel.Nets[i];
                    switch (item.Net.Code)
                    {
                        case "vk":
                            var list = getVkUsers(1, 12);
                            viewModel.Items.Add(item.Net.Code, list);
                            break;
                    }
                }
            }

            SX.WebCore.MvcApplication.SxMvcApplication.CacheProvider.Set("CACHE_NETS_ACCORDION", viewModel, 60);
            return PartialView("_Accordion", viewModel);
        }

        private static SX.VkApi.Models.User[] getVkUsers(int group_id, int count = 10)
        {
            var access_token = SxApiParametersController.Repo.GetApiParameter("VK", "access_token");
            var request = new SX.VkApi.Request(access_token.Value);
            var response = request.Users.Search(new SX.VkApi.Parameters.Users.ParametersSearch()
            {
                Count = count,
                Fields = new SX.VkApi.Parameters.Users.ParametersSearch.UserSearchFields[] {
                    SX.VkApi.Parameters.Users.ParametersSearch.UserSearchFields.has_photo,
                    SX.VkApi.Parameters.Users.ParametersSearch.UserSearchFields.photo_50,
                    SX.VkApi.Parameters.Users.ParametersSearch.UserSearchFields.domain
                }
            });

            return response.Items;
        }
    }
}