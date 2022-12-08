using CompanyEmployeeManagement.Web.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CompanyEmployeeManagement.Web.Context
{
    public class ApplicationDbContext : DbContext
    {
        public const string DEFAULT_SCHEMA = "dbo";
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        var connStr = "Server=DESKTOP-7CORDPF;Database=CompEmpManagementV3;Trusted_Connection=True;";
        //        optionsBuilder.UseSqlServer(connStr, opt =>
        //        {
        //            opt.EnableRetryOnFailure();
        //        });
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override int SaveChanges()
        {
            OnBeforeSave();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSave();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSave();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSave();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void OnBeforeSave()
        {
            var addedEntities = ChangeTracker.Entries()
                                    .Where(i => i.State == EntityState.Added)
                                    .Select(i => (BaseEntity)i.Entity);
            PrepareAddedEntities(addedEntities);
        }

        private void PrepareAddedEntities(IEnumerable<BaseEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (entity.CreateDate == DateTime.MinValue)
                    entity.CreateDate = DateTime.Now;
            }
        }
    }
 
}
