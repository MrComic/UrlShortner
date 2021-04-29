using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortner.Framework.Domain.Data;

namespace UrlShortner.Infra.Data.SqlServer
{
    public class ApplicationUnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext applicationDbContext;

        public ApplicationUnitOfWork(ApplicationDbContext advertismentDbContext)
        {
            this.applicationDbContext = advertismentDbContext;
        }
        public int Commit()
        {
            var entityForSave = GetEntityForSave();
            int result = applicationDbContext.SaveChanges();
            return result;
        }

        private List<EntityEntry> GetEntityForSave()
        {
            return applicationDbContext.ChangeTracker
              .Entries()
              .Where(x => x.State == EntityState.Modified || x.State == EntityState.Added || x.State == EntityState.Deleted)
              .ToList();
        }
    }
}
