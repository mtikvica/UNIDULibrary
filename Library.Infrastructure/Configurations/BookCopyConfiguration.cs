using Library.Domain.BookCopies;
using Library.Domain.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Configurations;
internal sealed class BookCopyConfiguration : IEntityTypeConfiguration<BookCopy>
{
    public void Configure(EntityTypeBuilder<BookCopy> builder)
    {
        builder.HasKey(bookCopy => bookCopy.Id);

        builder.HasOne<Book>()
            .WithMany()
            .HasForeignKey(bookCopy => bookCopy.BookId);
    }
}
