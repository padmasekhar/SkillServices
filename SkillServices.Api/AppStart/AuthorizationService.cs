﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using SkillServices.Api.Auth;
using SkillServices.Api.Constants;

namespace SkillServices.Api.AppStart
{
    public static class AuthorizationService
    {
        public static IServiceCollection AddAppAuthorization(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(AppConstants.APP_POLICY, policy =>
                {
                    policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
                    policy.RequireAuthenticatedUser();
                    policy.Requirements.Add(new AppAuthorizationRequirement());
                });
            });
            return services;
        }
    }
}
