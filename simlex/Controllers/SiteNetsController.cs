using simlex.ViewModels.Vk;
using SX.WebCore.MvcControllers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Linq;
using System;
using simlex.ViewModels;
using SX.WebCore.DbModels;
using System.Collections.Generic;
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
            if(viewModel!=null) return PartialView("_Accordion", viewModel);

            viewModel = new VMNetAccordion();
            var nets = SX.WebCore.MvcApplication.SxMvcApplication.SiteNetsProvider.All;
            viewModel.Nets = nets.Select(Mapper.Map<SxSiteNet, SxVMSiteNet>).ToArray();
            if (viewModel.Nets.Any())
            {
                SxVMSiteNet item;
                for (int i = 0; i < viewModel.Nets.Length; i++)
                {
                    item = viewModel.Nets[i];
                    switch(item.Net.Code)
                    {
                        case "vk":
                            var list = getVkUsers(1, 13);
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
            var accessToken = "e3223f3e185d32e33f83d8fc357d106237a7ffb40e9b919d76a93547c0ff9a0623cb7c9fbe2b619f08a47";

            var request = new SX.VkApi.Request(accessToken);
            var response = request.Users.Search(new SX.VkApi.Parameters.Users.ParametersSearch() {
                Q= "Vasya Babich",
                Fields=new SX.VkApi.Parameters.Users.ParametersSearch.UserSearchFields[] {
                    SX.VkApi.Parameters.Users.ParametersSearch.UserSearchFields.city,
                    SX.VkApi.Parameters.Users.ParametersSearch.UserSearchFields.has_photo,
                    SX.VkApi.Parameters.Users.ParametersSearch.UserSearchFields.photo_50
                }
            });

            return response.Items;
        }
    }
}