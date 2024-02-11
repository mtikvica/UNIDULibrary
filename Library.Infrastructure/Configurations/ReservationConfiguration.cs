using Library.Domain.BookCopies;
using Library.Domain.Reservations;
using Library.Domain.Students;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Configurations;
internal sealed class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.HasKey(reservation => reservation.Id);

        builder.ComplexProperty(reservation => reservation.DateRange, dateRange =>
        {
            dateRange.Property(dateRange => dateRange.StartDate).HasColumnName("StartDate");
            dateRange.Property(dateRange => dateRange.EndDate).HasColumnName("EndDate");
        });

        builder.HasOne<Student>()
            .WithMany()
            .HasForeignKey(reservation => reservation.StudentId);

        builder.HasOne<BookCopy>()
            .WithMany()
            .HasForeignKey(reservation => reservation.BookCopyId);
    }
}
