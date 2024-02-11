using Library.Domain.Departments;
using Library.Domain.Shared;
using Library.Domain.Students;
using Library.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Configurations;
internal sealed class StudentConfiguraiton : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(student => student.Id);

        builder.Property(student => student.FirstName)
            .HasConversion(name => name.Value, value => Name.Create(value));

        builder.Property(student => student.LastName)
            .HasConversion(name => name.Value, value => Name.Create(value));

        builder.Property(student => student.Email)
            .HasConversion(email => email.Value, value => Email.Create(value));

        builder.Property(student => student.Password)
            .HasConversion(password => password.Value, value => Password.Create(value));

        builder.Property(student => student.AcademicYear)
            .HasConversion(academicYear => academicYear.Value, value => AcademicYear.Create(value));

        builder.HasOne<Department>()
            .WithMany()
            .HasForeignKey(student => student.DepartmentId);

        builder.HasIndex(student => student.Email).IsUnique();
    }
}
