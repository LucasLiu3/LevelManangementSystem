using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LevelManangementSystem.web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //现在Data文件夹下创建要用的table，里面创建字段， 然后在这里告诉数据库，连接想要的表，然后给表起的名
        //然后在package manager console里面进行migration，输入 add-migration 表名
        //然后会在Migrations的文件夹下创建你的table，最后在console 输入update-database
        public DbSet<LeaveType> LeaveTypes { get; set; }
    }
}
