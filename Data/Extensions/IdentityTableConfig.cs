using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VEMS.API.Models.Identity;

namespace VEMS.API.Data.Extensions
{
    public static class IdentityTableConfig
    {
        public static void ApplyIdentityTableConfiguration(this ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("User").HasKey(u => u.Id);
            builder.Entity<ApplicationRole>().ToTable("Role").HasKey(r => r.Id);
            builder.Entity<ApplicationUserClaim>().ToTable("UserClaim").HasKey(uc => uc.Id);
            builder.Entity<ApplicationUserRole>().ToTable("UserRole");
            builder.Entity<IdentityUserToken<Guid>>().ToTable("UserToken");
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogin");
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaim");
        }
    }
}
