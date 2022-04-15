using Microsoft.EntityFrameworkCore;
using StudentApp;
using StudentApp.Services;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
var services = builder.Services;
var connectionString = builder.Configuration.GetConnectionString("Default");

var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));


services.AddDbContext<DataContext>(
            dbContextOptions => dbContextOptions
                .UseMySql(connectionString, serverVersion)
        );


services.AddScoped<IStudentServices, StudentServices>();
services.AddScoped<IDepartmentService, DepartmentService>();
services.AddScoped<IRankService, RankService>();

services.AddControllersWithViews();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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
    pattern: "{controller=Student}/{action=Index}/{id?}");
app.Run();