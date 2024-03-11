using Library.Domain.Departments;
using Library.Domain.Locations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Configurations;
internal sealed class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(department => department.Id);

        builder.Property(department => department.Name)
            .HasColumnName("Name");

        builder.HasOne<Location>()
            .WithMany()
            .HasForeignKey(department => department.LocationId);
    }
}
