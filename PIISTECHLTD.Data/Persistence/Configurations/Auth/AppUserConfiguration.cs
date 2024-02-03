using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIISTECHLTD.SharedKernel.Entities.Auth;

namespace PIISTECHLTD.Data.Persistence.Configurations.Auth;

internal class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        var hasher = new PasswordHasher<AppUser>();
        builder.HasKey(x => x.Id);
       
        builder.HasData(new AppUser
        {
            Id = "1",
            Email = "admin@localhost.com",
            NormalizedEmail = "ADMIN@LOCALHOST.COM",
            UserName = "admin@localhost.com",
            NormalizedUserName = "ADMIN@LOCALHOST.COM",
            PasswordHash = hasher.HashPassword(null, "P@ssword1"),
            EmailConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString()
          
        }, new AppUser
        {
            Id = "2",
            Email = "employee@localhost.com",
            NormalizedEmail = "EMPLOYEE@LOCALHOST.COM",
            UserName = "employee@localhost.com",
            NormalizedUserName = "EMPLOYEE@LOCALHOST.COM",
            PasswordHash = hasher.HashPassword(null, "P@ssword1"),
            EmailConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString(),
           
        });
    }
}
