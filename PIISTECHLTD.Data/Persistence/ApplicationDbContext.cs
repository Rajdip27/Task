using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PIISTECHLTD.SharedKernel.Entities.Auth;

namespace PIISTECHLTD.Data.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<AppUser>(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys()).ToList().ForEach(x => x.DeleteBehavior = DeleteBehavior.Restrict);

        // Configure primary key for IdentityUserRole
        modelBuilder.Entity<IdentityUserRole<string>>(b =>
        {
            b.HasKey(ur => new { ur.UserId, ur.RoleId });
        });
    }
}
