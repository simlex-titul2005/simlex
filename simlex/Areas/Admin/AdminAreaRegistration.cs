﻿using System.Web.Mvc;

namespace simlex.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                null,
                "Admin",
                new { action = "Index", controller = "Home", area = "Admin" }
            );

            context.MapRoute(null, "UserContacts/{userId}", new { action = "Index", controller = "UserContacts", area = "Admin" });
            context.MapRoute(null, "UserContacts/Edit/{userId}", new { action = "Edit", controller = "UserContacts", area = "Admin" });

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}