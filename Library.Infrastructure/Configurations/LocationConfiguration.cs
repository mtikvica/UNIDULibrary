using Library.Domain.Locations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Configurations;
internal sealed class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.HasKey(location => location.Id);

        builder.ComplexProperty(location => location.Address, address =>
        {
            address.Property(address => address.Street).HasColumnName("Street");
            address.Property(address => address.City).HasColumnName("City");
            address.Property(address => address.ZipCode).HasColumnName("ZipCode");
            address.Property(address => address.Country).HasColumnName("Country");
        });
    }
}
