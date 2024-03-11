using Library.Domain.Authors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Configurations;
internal sealed class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasKey(author => author.Id);

        builder.ComplexProperty(author => author.FirstName, name =>
        {
            name.Property(name => name.Value).HasColumnName("FirstName");
        });

        builder.ComplexProperty(author => author.LastName, name =>
        {
            name.Property(name => name.Value).HasColumnName("LastName");
        });

        builder.OwnsOne(author => author.MiddleName, name =>
        {
            name.Property(name => name.Value).HasColumnName("MiddleName");
        });

        builder.HasIndex(author => author.OpenLibraryAuthorCode).IsUnique();
    }
}
