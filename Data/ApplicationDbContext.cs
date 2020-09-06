using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VEMS.API.Data.Extensions;
using VEMS.API.Models.Identity;

namespace VEMS.API.Data
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser, ApplicationRole, Guid, ApplicationUserClaim, ApplicationUserRole, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
            :base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyIdentityTableConfiguration();
            builder.ApplyDbTableConfiguration();

            builder.SeedDB();
        }
    }
}
