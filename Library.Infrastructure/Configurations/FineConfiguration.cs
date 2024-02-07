using Library.Domain.Fines;
using Library.Domain.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Configurations;
internal class FineConfiguration : IEntityTypeConfiguration<Fine>
{
    public void Configure(EntityTypeBuilder<Fine> builder)
    {
        builder.HasKey(fine => fine.Id);

        builder.HasOne<Loan>()
            .WithOne()
            .HasForeignKey<Fine>(fine => fine.LoanId);
    }
}
