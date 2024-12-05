using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LevelManangementSystem.web.Data.Configuration
{
    public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {

        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
            {
                Id = "ed1b69bc-4aed-4616-9181-0beb1731b9c9",
                Name = "Employee",
                NormalizedName = "EMPLOYEE",
            },
                new IdentityRole
                {
                    Id = "37057c2a-51d0-4f19-8851-1e09d756b579",
                    Name = "Supervisor",
                    NormalizedName = "SUPERVISOR",
                },
                new IdentityRole
                {
                    Id = "b15f564c-202a-451c-babb-a0efb93289db",
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                });
        }
    }
}
