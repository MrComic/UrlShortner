using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using UrlShortner.Core.Domain.ShortenedUrls.Entities;

namespace UrlShortner.Infra.Data.SqlServer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
         


        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            beforeSaveTriggers();
            ChangeTracker.AutoDetectChangesEnabled = false;
            var result = base.SaveChanges();
            ChangeTracker.AutoDetectChangesEnabled = true;
            return result;
        }

        private void beforeSaveTriggers()
        {
            var modifiedEntries = ChangeTracker.Entries<IAuditable>()
                                               .Where(x => x.State == EntityState.Modified);
            foreach (var modifiedEntry in modifiedEntries)
            {
                modifiedEntry.Property("ModifiedDateTime").CurrentValue = DateTime.Now;
            }

            var addedEntries = ChangeTracker.Entries<IAuditable>()
                                            .Where(x => x.State == EntityState.Added);
            foreach (var addedEntry in addedEntries)
            {
                addedEntry.Property("CreatedDateTime").CurrentValue = DateTime.Now;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            foreach (var entityType in modelBuilder.Model
                                      .GetEntityTypes()
                                      .Where(e => typeof(IAuditable).IsAssignableFrom(e.ClrType)))
            {
                modelBuilder.Entity(entityType.ClrType)
                   .Property<DateTime?>("CreatedDateTime");
                modelBuilder.Entity(entityType.ClrType)
                            .Property<DateTime?>("ModifiedDateTime");
            }
      

        }

        public DbSet<ShortenedUrl> ShortenedUrls { get; set; }
    }
}
