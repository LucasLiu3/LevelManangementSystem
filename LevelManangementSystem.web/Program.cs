using System.Reflection;
using LevelManangementSystem.web.Data;
using LevelManangementSystem.web.Services.LeaveAllocations;
using LevelManangementSystem.web.Services.LeaveRequests;
using LevelManangementSystem.web.Services.LeaveTypes;
using LevelManangementSystem.web.Services.Periods;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//??????automapper??,?????????????
//?????????profile?class??
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());   //add mapper
builder.Services.AddScoped<ILeaveTypeService,LeaveTypeService>(); //add service
builder.Services.AddScoped<ILeaveAllocationsService, LeaveAllocationsService>(); //add service
builder.Services.AddScoped<ILeaveRequestService, LeaveRequestService>();
builder.Services.AddScoped<IPeriodsService, PeriodsService>();
//builder.Services.AddTransient<IEmailSender, EmailSender>(); //add email sender server

builder.Services.AddHttpContextAccessor();  


builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
