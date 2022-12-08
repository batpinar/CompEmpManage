using CompanyEmployeeManagement.Web.Context;
using CompanyEmployeeManagement.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyEmployeeManagement.Web.EntityConfigurations
{
    public class EmployeeEntityConfiguration : BaseEntityConfiguration<Employee>
    {
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {
            base.Configure(builder);

            builder.ToTable("employee", ApplicationDbContext.DEFAULT_SCHEMA);

            builder.HasOne(i => i.Company);
        }
    }
}
