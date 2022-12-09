using CompanyEmployeeManagement.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyEmployeeManagement.Web.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public ApplicationDbContext()
        {

        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connStr = "Server=DESKTOP-7CORDPF;Database=CompEmpManagementSYS1;Trusted_Connection=True;";
                optionsBuilder.UseSqlServer(connStr, opt =>
                {
                    opt.EnableRetryOnFailure();
                });
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("companies");

                entity.Property(i => i.Id).HasColumnName("id").HasColumnType("int").UseIdentityColumn().IsRequired();
                entity.Property(i => i.CompanyName).HasColumnName("company_name").HasColumnType("nvarchar").HasMaxLength(100);
                entity.Property(i => i.TaxNumber).HasColumnName("tax_number").HasColumnType("nvarchar").HasMaxLength(10);
                entity.Property(i => i.TaxOffice).HasColumnName("tax_office").HasColumnType("nvarchar").HasMaxLength(100);
                entity.Property(i => i.Adresses).HasColumnName("adresses").HasColumnType("nvarchar").HasMaxLength(1000);

                entity.HasMany(i => i.Employees)
                      .WithOne(i => i.Company)
                      .HasForeignKey(i => i.CompanyId)
                      .HasConstraintName("company_employee_id_fk");
            });

            base.OnModelCreating(modelBuilder);

        }

        //public override int SaveChanges()
        //{
        //    OnBeforeSave();
        //    return base.SaveChanges();
        //}

        //public override int SaveChanges(bool acceptAllChangesOnSuccess)
        //{
        //    OnBeforeSave();
        //    return base.SaveChanges(acceptAllChangesOnSuccess);
        //}

        //public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        //{
        //    OnBeforeSave();
        //    return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        //}

        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    OnBeforeSave();
        //    return base.SaveChangesAsync(cancellationToken);
        //}

        //private void OnBeforeSave()
        //{
        //    var addedEntities = ChangeTracker.Entries()
        //                            .Where(i => i.State == EntityState.Added)
        //                            .Select(i => (BaseEntity)i.Entity);
        //    PrepareAddedEntities(addedEntities);
        //}

        //private void PrepareAddedEntities(IEnumerable<BaseEntity> entities)
        //{
        //    foreach (var entity in entities)
        //    {
        //        if (entity.CreateDate == DateTime.MinValue)
        //            entity.CreateDate = DateTime.Now;
        //    }
        //}
    }
 
}
