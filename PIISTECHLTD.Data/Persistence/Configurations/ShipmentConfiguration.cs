using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIISTECHLTD.SharedKernel.Entities;

namespace PIISTECHLTD.Data.Persistence.Configurations;

public class ShipmentConfiguration : IEntityTypeConfiguration<Shipment>
{
    public void Configure(EntityTypeBuilder<Shipment> builder)
    {
        builder.ToTable(nameof(Shipment));
        builder.HasKey(x => x.Id);
        builder.Property(x=>x.ConsignmentNumber).HasMaxLength(20).IsRequired();
        builder.HasOne(t=>t.Shipper).WithMany(x=>x.Shipment).HasForeignKey(x=>x.ShipperId).IsRequired();
        builder.HasOne(t=>t.Receiver).WithMany(x=>x.Shipment).HasForeignKey(x=>x.ReceiverId).IsRequired();
    }
}
