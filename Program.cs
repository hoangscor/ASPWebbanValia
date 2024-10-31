using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Thuchanhwebmvc.Data;
using Thuchanhwebmvc.Models;
using Thuchanhwebmvc.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("QlbanVaLiContext");

builder.Services.AddDbContext<QlbanVaLiContext>(x=>x.UseSqlServer(connectionString));

builder.Services.AddScoped<ILoaiSpRepository,LoaiSpRepository>();
    
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<QlbanVaLiContext>();



builder.Services.AddRazorPages().AddRazorRuntimeCompilation();  

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
