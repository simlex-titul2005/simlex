using AutoMapper;
using simlex.Models;
using simlex.ViewModels;
using SX.WebCore.ViewModels;

namespace simlex
{
    public class AutoMapperConfig
    {
        public static void Register(IMapperConfigurationExpression cfg)
        {
            // article
            cfg.CreateMap<Article, VMArticle>();
            cfg.CreateMap<VMArticle, Article>();

            // VMMaterial
            cfg.CreateMap<SxVMMaterial, VMMaterial>();

            // project
            cfg.CreateMap<Project, VMProject>();
            cfg.CreateMap<VMProject, Project>();
        }
    }
}