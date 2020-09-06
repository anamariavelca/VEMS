using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace VEMS.API.Services.Extensions
{
    public static class AuthorizationServiceExtension
    {
        public static void AddAuthorizationConfiguration(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Policy.TeacherRole", builder => 
                        builder.RequireClaim(ClaimTypes.Role, "Teacher"));
            });

            services.AddCors(options =>
            {
                options.AddPolicy("APIPolicy", builder =>
                {
                    builder
                    .WithOrigins("https://localhost:44385")
                    .AllowCredentials()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .SetIsOriginAllowedToAllowWildcardSubdomains();
                });

            });
        }
    }
}
