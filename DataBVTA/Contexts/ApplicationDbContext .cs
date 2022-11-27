using DataBVTA.Models;
using DataBVTA.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBVTA.Contexts
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<UserMenuPermission> RoleMenuPermission { get; set; }

        public DbSet<NavigationMenu> NavigationMenu { get; set; }

        public IDbConnection Connection => Database.GetDbConnection();

        protected override void OnModelCreating(ModelBuilder builder)
        {


            base.OnModelCreating(builder);
        }
    }
}
