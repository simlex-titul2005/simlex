using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace simlex
{
    public class RouteConfig
    {
        private static readonly string[] _defNamespases = new string[] { "simlex.Controllers" };
        public static Action<RouteCollection> PreRouteAction = routes =>
        {
            routes.MapRoute(name: null, url: "Users/About/{nikname}", defaults: new { controller = "Users", action = "About" }, namespaces: _defNamespases);

            routes.MapRoute(name: null, url: "Projects/{titleUrl}", defaults: new { controller = "Projects", action = "Details" }, namespaces: _defNamespases);
        };

        public static Action<RouteCollection> PostRouteAction = routes =>
        {
            routes.MapRoute(name: null, url: "{controller}/{action}/{id}", defaults: new { controller = "Articles", action = "List", id = UrlParameter.Optional }, namespaces: _defNamespases);
        };
    }
}
