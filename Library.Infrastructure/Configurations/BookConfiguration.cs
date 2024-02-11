using Library.Domain.Authors;
using Library.Domain.Books;
using Library.Domain.Departments;
using Library.Domain.Locations;
using Library.Domain.Publishers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Configurations;
internal sealed class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(book => book.Id);

        builder.HasMany<Author>()
            .WithMany();

        builder.HasOne<Location>()
            .WithMany()
            .HasForeignKey(book => book.LocationId);

        builder.HasOne<Publisher>()
            .WithMany()
            .HasForeignKey(book => book.PublisherId);

        builder.HasOne<Department>()
            .WithMany()
            .HasForeignKey(book => book.DepartmentId);
    }
}
