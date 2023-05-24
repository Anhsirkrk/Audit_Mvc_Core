using Audit_Mvc_Core.Repository;
using Audit_Mvc_Core.Models;
using Audit_Mvc_Core.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components.Forms;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AuditContext>(options=>options.UseMySQL(builder.Configuration.GetConnectionString("Auditconnection")));
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<ICompanyRepository,CompanyRepository>();
builder.Services.AddScoped<IAdminRepository,AdminRepository>();
 

builder.Services.AddControllersWithViews();

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
app.UseEndpoints(endpoints =>
{
endpoints.MapControllerRoute(
    name : "default",
    pattern:"{ controller = Home}/{ Action = Index}/{ Id ?}");
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Admin}/{action=AdminTaskAssign}/{id?}");

app.Run();
