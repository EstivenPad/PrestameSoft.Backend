using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "d6e3e7a2-a63f-4300-a4df-4d2e85e55a91",
                    UserId = "3e0899b4-961c-4a67-90e8-53aedac5c370"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "9e9f6d16-c496-4c79-a334-a84acfe6b750",
                    UserId = "9cb7dbdd-ebbd-4501-9c2e-67e5cffc3d73"
                }
                );
        }
    }
}
