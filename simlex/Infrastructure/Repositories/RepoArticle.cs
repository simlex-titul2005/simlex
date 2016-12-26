using simlex.Infrastructure.Repositories.Abstract;
using simlex.Models;
using simlex.ViewModels;
using SX.WebCore;

namespace simlex.Infrastructure.Repositories
{
    public sealed class RepoArticle : RepoMaterial<Article, VMArticle>
    {
        public RepoArticle() : base((byte)Enums.ModelCoreType.Article) { }
    }
}