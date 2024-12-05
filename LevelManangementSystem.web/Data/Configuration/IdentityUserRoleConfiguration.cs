using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LevelManangementSystem.web.Data.Configuration
{
    public class IdentityUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {


            builder.HasData(new IdentityUserRole<string>
            {
                RoleId = "b15f564c-202a-451c-babb-a0efb93289db",
                UserId = "0039b7c5-faa7-47b3-b042-d2f3c3d2f3df"
            });
        }

    }
}
