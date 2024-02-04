using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIISTECHLTD.SharedKernel.Entities;

namespace PIISTECHLTD.Data.Persistence.Configurations;

public class ShipperConfiguration : IEntityTypeConfiguration<Shipper>
{
    public void Configure(EntityTypeBuilder<Shipper> builder)
    {
       builder.ToTable(nameof(Shipper));
        builder.HasKey(x => x.Id);
        builder.Property(x=>x.ShipperName).HasMaxLength(70).IsRequired();
        builder.Property(x=>x.ShipperAddress).HasMaxLength(200).IsRequired();
        builder.Property(x=>x.ShipperPhoneNumber).HasMaxLength(20).IsRequired();
        builder.HasData(new Shipper
        {
            Id = 1,
            ShipperName = "AbC.Ltd",
            ShipperAddress = "Dhaka",
            ShipperPhoneNumber = "01701734627"

        }) ;
    }
}
