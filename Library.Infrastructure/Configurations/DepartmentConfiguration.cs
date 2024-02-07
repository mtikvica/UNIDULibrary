using Library.Domain.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Configurations;
internal sealed class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(department => department.Id);

        builder.HasMany(department => department.Students)
            .WithOne()
            .HasForeignKey(student => student.DepartmentId);
    }
}
