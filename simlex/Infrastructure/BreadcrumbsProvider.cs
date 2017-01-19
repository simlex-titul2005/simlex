using simlex.ViewModels;
using SX.WebCore.MvcControllers.Abstract;
using SX.WebCore.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace simlex.Infrastructure
{
    public static class BreadcrumbsProvider
    {
        public static void FillBreadcrumbs(SxBaseController controller, HashSet<SxVMBreadcrumb> list)
        {
            list.Add(new SxVMBreadcrumb() { Title = "Главная", Url = controller.Url.Action("List", "Articles") });

            switch (controller.SxControllerName)
            {
                // account
                case "account":
                    if(controller.SxActionName=="login")
                        list.Add(new SxVMBreadcrumb() { Title = "Вход в аккаунт", Url = controller.Url.Action("Login", "Account") });
                    break;

                // articles
                case "articles":
                    if (controller.SxActionName == "list")
                    {
                        var category = (SxVMMaterialCategory)controller.ViewBag.Category;

                        if (category != null)
                            list.Add(new SxVMBreadcrumb() { Title = category.Title, Url = controller.Url.Action("List", "Articles", new { category = category.Id }) });
                    }

                    if (controller.SxActionName == "details")
                    {
                        var model = (VMArticle)controller.SxModel;

                        if (model.Category != null)
                            list.Add(new SxVMBreadcrumb() { Title = model.Category.Title, Url = controller.Url.Action("List", "Articles", new { category = model.Category.Id }) });

                        list.Add(new SxVMBreadcrumb() { Url = model.GetUrl(controller.Url), Title = model.Title });
                    }
                    break;

                // projects
                case "projects":
                    list.Add(new SxVMBreadcrumb() { Title = "Проекты", Url = controller.Url.Action("List", "Projects") });
                    if (controller.SxActionName == "list")
                    {
                        var category = (SxVMMaterialCategory)controller.ViewBag.Category;

                        if (category != null)
                            list.Add(new SxVMBreadcrumb() { Title = category.Title, Url = controller.Url.Action("List", "Projects", new { category = category.Id }) });
                    }

                    if (controller.SxActionName == "details")
                    {
                        var model = (VMProject)controller.SxModel;

                        if (model.Category != null)
                            list.Add(new SxVMBreadcrumb() { Title = model.Category.Title, Url = controller.Url.Action("List", "Projects", new { category = model.Category.Id }) });

                        list.Add(new SxVMBreadcrumb() { Url = model.GetUrl(controller.Url), Title = model.Title });
                    }
                    break;

                // users
                case "users":
                    list.Add(new SxVMBreadcrumb() { Title = "Пользователи", Url = "#" });
                    if (controller.SxActionName == "about")
                    {
                        var model = (SxVMUserInfo)controller.SxModel;

                        list.Add(new SxVMBreadcrumb() { Url = controller.Url.Action("About", "Users", new { nikname=model.User.NikName }), Title = model.User.NikName });
                    }
                    break;
            }

            controller.ViewBag.Breadcrumbs = list.ToArray();
        }
    }
}