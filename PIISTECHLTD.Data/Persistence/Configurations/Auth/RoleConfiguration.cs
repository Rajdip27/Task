using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIISTECHLTD.SharedKernel.Entities.Auth;
using System.Data;

namespace PIISTECHLTD.Data.Persistence.Configurations.Auth;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(new IdentityRole
        {
            Id = "1",
            Name = "Administrator",
            NormalizedName = "ADMINISTRATOR",

        }, new IdentityRole
        {
            Id = "2",
            Name = "Employee",
            NormalizedName = "EMPLOYEE",
        });
    }
}
