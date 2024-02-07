using Library.Domain.Employees;
using Library.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Configurations;
internal sealed class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(employee => employee.Id);

        builder.Property(employee => employee.FirstName)
            .HasConversion(name => name.Value, value => FirstName.Create(value));

        builder.Property(employee => employee.LastName)
            .HasConversion(name => name.Value, value => LastName.Create(value));

        builder.Property(employee => employee.Email)
            .HasConversion(email => email.Value, value => Email.Create(value));
    }
}
