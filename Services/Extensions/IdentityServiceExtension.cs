using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VEMS.API.Data;
using VEMS.API.Models.Identity;

namespace VEMS.API.Services.Extensions
{
    public static class IdentityServiceExtension
    {
        public static void AddIdentityConfiguration(this IServiceCollection services)
        {

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}
