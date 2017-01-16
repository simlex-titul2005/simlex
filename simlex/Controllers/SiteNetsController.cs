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

        private static HashSet<VMVkUser> getVkUsers(int group_id, int count = 10)
        {
            var data = new HashSet<VMVkUser>();
            var accessToken = "4d32a78e4a22d41f61ca617954c69e7c2e3109cd6886f55b91a3e7b27d10289f0d191992beb0eb3d8794f";
            using (var webClient = new WebClient())
            {
                var json = webClient.DownloadString($"https://api.vk.com/method/users.search?group_id={group_id}&has_photo=1&fields=photo&count={count}&access_token={accessToken}&v=5.62");
                var array = ((Newtonsoft.Json.Linq.JArray)Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(json).response.items).ToArray();

                Newtonsoft.Json.Linq.JToken item;
                for (int i = 0; i < array.Length; i++)
                {
                    item = array[i];
                    data.Add(new VMVkUser()
                    {
                        Id = Convert.ToInt32(item["uid"]),
                        FirstName = (string)item["first_name"],
                        LastName = (string)item["last_name"],
                        Photo = (string)item["photo"]
                    });
                }
            }

            return data;
        }
    }
}