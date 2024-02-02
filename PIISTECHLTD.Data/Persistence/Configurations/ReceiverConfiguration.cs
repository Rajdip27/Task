using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIISTECHLTD.SharedKernel.Entities;

namespace PIISTECHLTD.Data.Persistence.Configurations;

public class ReceiverConfiguration : IEntityTypeConfiguration<Receiver>
{
    public void Configure(EntityTypeBuilder<Receiver> builder)
    {
       builder.ToTable(nameof(Receiver));
        builder.HasKey(x => x.Id);
        builder.Property(x=>x.ReceiverAddress).HasMaxLength(200).IsRequired();
        builder.Property(x=>x.ReceiverName).HasMaxLength(200).IsRequired();
        builder.Property(x=>x.ReceiverPhoneNumber).HasMaxLength(200).IsRequired();
    }
}
