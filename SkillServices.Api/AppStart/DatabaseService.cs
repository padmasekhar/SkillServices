using Ps.EfCoreRepository.SqlServer.DependencyInjection;
using SkillServices.Data.Database;

namespace SkillServices.Api.AppStart
{
    public static class DatabaseService
    {
        public static WebApplicationBuilder AddDatabase(this WebApplicationBuilder builder)
        {
            builder.Services.AddDatabase(builder.Configuration);
            return builder;
        }
    }
}
