using Library.Domain.BookCopies;
using Library.Domain.Loans;
using Library.Domain.Students;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Configurations;
internal sealed class LoanConfiguration : IEntityTypeConfiguration<Loan>
{
    public void Configure(EntityTypeBuilder<Loan> builder)
    {
        builder.HasKey(loan => loan.Id);

        builder.OwnsOne(loan => loan.DateRange, dateRange =>
        {
            dateRange.Property(dateRange => dateRange.StartDate).HasColumnName("StartDate");
            dateRange.Property(dateRange => dateRange.EndDate).HasColumnName("EndDate");
        });

        builder.HasOne<Student>()
            .WithMany()
            .HasForeignKey(loan => loan.StudentId);

        builder.HasOne<BookCopy>()
            .WithMany()
            .HasForeignKey(loan => loan.BookCopyId);
    }
}
