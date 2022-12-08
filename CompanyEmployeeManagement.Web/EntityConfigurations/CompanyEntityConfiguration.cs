using CompanyEmployeeManagement.Web.Context;
using CompanyEmployeeManagement.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyEmployeeManagement.Web.EntityConfigurations;

public class CompanyEntityConfiguration : BaseEntityConfiguration<Company>
{
    public override void Configure(EntityTypeBuilder<Company> builder)
    {
        base.Configure(builder);

        builder.ToTable("company", ApplicationDbContext.DEFAULT_SCHEMA);

    }
}
