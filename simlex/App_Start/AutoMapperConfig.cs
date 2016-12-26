using AutoMapper;
using simlex.Models;
using simlex.ViewModels;

namespace simlex
{
    public class AutoMapperConfig
    {
        public static void Register(IMapperConfigurationExpression cfg)
        {
            //article
            cfg.CreateMap<Article, VMArticle>();
            cfg.CreateMap<VMArticle, Article>();
        }
    }
}