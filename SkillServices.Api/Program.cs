using SkillServices.Api.AppStart;

namespace SkillServices.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.AddDatabase()
                    .AddLogging()
                    .AddAppServices()
                    .Build()
                    .AddMiddlewares(builder.Configuration);
        }
    }
}