using System;
using System.Collections.Generic;

namespace simlex
{
    public class MvcApplication : SX.WebCore.MvcApplication.SxMvcApplication
    {
        private static readonly Dictionary<string, byte> _customModelCoreTypes = new Dictionary<string, byte>()
        {

        };


        private static string _getModelCoreTypeNames(byte mct)
        {
            return mct.ToString();
        }

        private static readonly SX.WebCore.MvcApplication.SxApplicationEventArgs _eventArgs = new SX.WebCore.MvcApplication.SxApplicationEventArgs(
                defaultSiteName: "simlex",
                getDbContextInstance: () => new Infrastructure.DbContext(),
                customModelCoreTypes: _customModelCoreTypes,
                getModelCoreTypeName: _getModelCoreTypeNames
            )
        {
            DefaultControllerNamespaces = new string[] { "simlex.Controllers" },
            MapperConfigurationExpression = AutoMapperConfig.Register,
            PreRouteAction=RouteConfig.PreRouteAction
        };

        protected override void Application_Start(object sender, EventArgs e)
        {
            base.Application_Start(sender, _eventArgs);
        }
    }
}
