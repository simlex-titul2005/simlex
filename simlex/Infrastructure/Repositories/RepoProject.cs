using Dapper;
using simlex.Infrastructure.Repositories.Abstract;
using simlex.Models;
using simlex.ViewModels;
using SX.WebCore.MvcApplication;
using System;
using System.Data.SqlClient;

namespace simlex.Infrastructure.Repositories
{
    public sealed class RepoProject : RepoMaterial<Project, VMProject>
    {
        public RepoProject() : base(SxMvcApplication.ModelCoreTypeProvider[nameof(Project)]) { }

        protected override Action<int, SqlConnection> BeforeDeleteAction
        {
            get
            {
                return (id, connection) =>
                {
                    var query = "DELETE FROM D_PROJECT WHERE Id=@id";
                    connection.Execute(query, new { id });
                };
            }
        }
    }
}