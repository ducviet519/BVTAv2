using DataBVTA.Models;
using DataBVTA.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataBVTA.Contexts
{
    public interface IApplicationDbContext
    {
        public IDbConnection Connection { get; }
        DatabaseFacade Database { get; }
        public DbSet<UserMenuPermission> RoleMenuPermission { get; set; }
        public DbSet<NavigationMenu> NavigationMenu { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
