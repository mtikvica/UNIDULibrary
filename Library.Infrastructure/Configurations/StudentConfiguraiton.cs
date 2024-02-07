using Library.Domain.Departments;
using Library.Domain.Loans;
using Library.Domain.Reservations;
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
            .HasConversion(name => name.Value, value => FirstName.Create(value));

        builder.Property(student => student.LastName)
            .HasConversion(name => name.Value, value => LastName.Create(value));

        builder.Property(student => student.Email)
            .HasConversion(email => email.Value, value => Email.Create(value));

        builder.Property(student => student.AcademicYear)
            .HasConversion(academicYear => academicYear.Value, value => AcademicYear.Create(value));

        builder.HasMany<Reservation>()
            .WithOne()
            .HasForeignKey(reservation => reservation.StudentId);

        builder.HasMany<Loan>()
            .WithOne()
            .HasForeignKey(loan => loan.StudentId);

        builder.HasOne<Department>()
            .WithMany()
            .HasForeignKey(student => student.DepartmentId);

        builder.HasIndex(student => student.Email).IsUnique();
    }
}
