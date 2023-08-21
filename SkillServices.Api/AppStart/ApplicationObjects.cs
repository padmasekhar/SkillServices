using Microsoft.AspNetCore.Authorization;
using SkillServices.Api.Auth;
using SkillServices.Api.Constants;
using SkillServices.Api.Services;
using SkillServices.Api.Services.Definitions;

namespace SkillServices.Api.AppStart
{
    public static class ApplicationObjects
    {
        public static IServiceCollection AddApplicationObjects(this IServiceCollection services, IConfiguration config)
        {
            services.AddServiceDependencies();
            services.AddCors(config);
            services.AddOthes();
            return services;
        }

        private static void AddServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<ISkillService, SkillService>();
        }
        private static void AddCors(this IServiceCollection services, IConfiguration config)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy(name: AppConstants.SKILL_CENTRAL_CORE_POLICY,
                      policy =>
                      {
                          policy.WithOrigins("*")
                                .WithHeaders("*")
                                .WithMethods("*");
                      });
            });
        }
        private static void AddOthes(this IServiceCollection services)
        {
            services.AddScoped<IAuthorizationHandler, AppAuthorizationHandler>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
