using CloudHRMS.DAO;
using CloudHRMS.Services;
using CloudHRMS.UnitOfWorks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var config = builder.Configuration;

builder.Services.AddRazorPages();
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<HRMSDbContext>(); 

builder.Services.AddDbContext<HRMSDbContext>(o => o.UseSqlServer(config.GetConnectionString("CloudHRMSConnectionString")));



//adding the connection to the PostgreSQL database
//builder.Services.AddDbContext<HRMSDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
//add Iunit work to access database operation process
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IPositionService, PositionService>();
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<IDepartmentService, DepartmentService>();
builder.Services.AddTransient<IShiftService, ShiftService>();
builder.Services.AddTransient<IShiftAssignService, ShiftAssignService>();
builder.Services.AddTransient<IAttendancePolicyServices, AttendancePolicyServices>();
builder.Services.AddTransient<IDailyAttendanceService, DailyAttendanceService>();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseStatusCodePages(async context =>
{
    if (context.HttpContext.Response.StatusCode == 404)
    {
        context.HttpContext.Response.Redirect("/Home/AccessDenied");
    }
});
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();

