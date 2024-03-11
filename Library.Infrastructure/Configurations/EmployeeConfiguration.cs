using Library.Domain.Employees;
using Library.Domain.Locations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Configurations;
internal sealed class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(employee => employee.Id);

        builder.ComplexProperty(employee => employee.FirstName)
            .Property(name => name.Value)
            .HasColumnName("FirstName");

        builder.ComplexProperty(employee => employee.LastName)
            .Property(name => name.Value)
            .HasColumnName("LastName");

        builder.ComplexProperty(employee => employee.Email)
            .Property(email => email.Value)
            .HasColumnName("Email");

        builder.ComplexProperty(employee => employee.Password)
            .Property(password => password.Value)
            .HasColumnName("Password");

        builder.HasOne<Location>()
            .WithMany()
            .HasForeignKey(employee => employee.LocationId);
    }
}
