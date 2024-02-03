using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIISTECHLTD.SharedKernel.Entities;

namespace PIISTECHLTD.Data.Persistence.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
       builder.ToTable(nameof(Order));
       builder.HasKey(x => x.Id);
        builder.HasOne(x => x.User).WithMany(x => x.Orders).HasForeignKey(x => x.UserId);
    }
}
