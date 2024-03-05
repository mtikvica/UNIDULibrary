using Library.Domain.AuthorBooks;
using Library.Domain.Authors;
using Library.Domain.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Configurations;
public class AuthorBookConfiguration : IEntityTypeConfiguration<AuthorBook>
{
    public void Configure(EntityTypeBuilder<AuthorBook> builder)
    {
        builder.HasKey(e => new { e.BookId, e.AuthorId });

        builder.HasOne<Author>()
            .WithMany()
            .HasForeignKey(authorBook => authorBook.AuthorId);

        builder.HasOne<Book>()
            .WithMany()
            .HasForeignKey(authorBook => authorBook.BookId);
    }
}
