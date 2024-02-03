﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIISTECHLTD.SharedKernel.Entities.Auth;

namespace PIISTECHLTD.Data.Persistence.Configurations.Auth;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasData(new UserRole
        {
            RoleId = "1",
            UserId = "1",
        }, new UserRole
        {
            RoleId = "2",
            UserId = "2",
        });
    }
}
