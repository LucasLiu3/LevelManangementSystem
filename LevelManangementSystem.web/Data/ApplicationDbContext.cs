using System.Reflection;
using LevelManangementSystem.web.Data.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace LevelManangementSystem.web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        //对一开始自带的数据库进行数据插入
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<IdentityRole>().HasData(
            //    new IdentityRole 
            //    {
            //        Id = "ed1b69bc-4aed-4616-9181-0beb1731b9c9",
            //        Name="Employee",
            //        NormalizedName ="EMPLOYEE",
            //    },
            //    new IdentityRole 
            //    {
            //        Id = "37057c2a-51d0-4f19-8851-1e09d756b579",
            //        Name = "Supervisor",
            //        NormalizedName = "SUPERVISOR",
            //    }, 
            //    new IdentityRole 
            //    {
            //        Id = "b15f564c-202a-451c-babb-a0efb93289db",
            //        Name = "Admin",
            //        NormalizedName = "ADMIN",
            //    });

            //var haser = new PasswordHasher<ApplicationUser>();
            //builder.Entity<ApplicationUser>().HasData(
            //    new ApplicationUser
            //    {
            //        Id = "0039b7c5-faa7-47b3-b042-d2f3c3d2f3df",
            //        Email = "admin@localhost.com",
            //        NormalizedEmail = "ADMIN@LOCALHOST.COM",
            //        NormalizedUserName = "ADMIN@LOCALHOST.COM",
            //        UserName = "admin@localhost.com",
            //        PasswordHash = haser.HashPassword(null, "8630146haohao"),
            //        EmailConfirmed =true,
            //        FirstName ="Default",
            //        LastName ="Admin",
            //        DateOfBirth = new DateOnly(1987,03,01)

            //    });

            //builder.Entity<IdentityUserRole<string>>().HasData(
            // new IdentityUserRole<string>
            // {
            //     RoleId = "b15f564c-202a-451c-babb-a0efb93289db",
            //     UserId = "0039b7c5-faa7-47b3-b042-d2f3c3d2f3df"
            // }
            //    );


            //这是另外一种插入数据的方式，创建一个configuration的class，写入数据，然后这里apply
            //builder.ApplyConfiguration(new IdentityUserRoleConfiguration());
            //builder.ApplyConfiguration(new ApplicationUserConfiguration());
            //builder.ApplyConfiguration(new IdentityRoleConfiguration());
            //builder.ApplyConfiguration(new LeaveRequestStatusConfiguration());

            //上面这么多又可以写成一句话
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }



        //现在Data文件夹下创建要用的table，里面创建字段， 然后在这里告诉数据库，连接想要的表，然后给表起的名
        //然后在package manager console里面进行migration，输入 add-migration 表名
        //然后会在Migrations的文件夹下创建你的table，最后在console 输入update-database
        public DbSet<LeaveType> LeaveTypes { get; set; }

        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }

        public DbSet<Period> Periods { get; set; }  

        public DbSet<LeaveRequestStatus> leaveRequestStatuses {  get; set; } 

        public DbSet<LeaveRequest> leaveRequests { get; set; }

      
    }
}
