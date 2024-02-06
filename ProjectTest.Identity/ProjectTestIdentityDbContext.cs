using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectTest.Identity.Models;
using ProjectTest.Identity.Seedings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.Identity
{
    public class ProjectTestIdentityDbContext: IdentityDbContext<ApplicationUser>
    {
        public ProjectTestIdentityDbContext(DbContextOptions<ProjectTestIdentityDbContext> options): base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleSeeding());
            builder.ApplyConfiguration(new UserSeeding());
            builder.ApplyConfiguration(new UserRoleSeeding());
        }
    }
}
