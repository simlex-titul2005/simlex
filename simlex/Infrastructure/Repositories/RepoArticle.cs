using System;
using System.Data.SqlClient;
using simlex.Infrastructure.Repositories.Abstract;
using simlex.Models;
using simlex.ViewModels;
using SX.WebCore;
using Dapper;

namespace simlex.Infrastructure.Repositories
{
    public sealed class RepoArticle : RepoMaterial<Article, VMArticle>
    {
        public RepoArticle() : base((byte)Enums.ModelCoreType.Article) { }

        protected override Action<int, SqlConnection> BeforeDeleteAction
        {
            get
            {
                return (id, connection) =>
                {
                    var query = "DELETE FROM D_ARTICLE WHERE Id=@id";
                    connection.Execute(query, new { id });
                };
            }
        }
    }
}