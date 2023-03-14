using Microsoft.EntityFrameworkCore;
using MyWebApp.Data;
using MyWebApp.Repositories;
using MyWebApp.Service.Impl;
using MyWebApp.Services;
using NyWebApp.Repositories.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connHost = Environment.GetEnvironmentVariable("DB_HOST");
var connPort = Environment.GetEnvironmentVariable("DB_PORT");
var connUser = Environment.GetEnvironmentVariable("DB_USER");
var connPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
var connectionString = $"Server={connHost}; Database=MusicDB; Port={connPort}; UserId={connUser}; Password={connPassword};";
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString)
);

// Add Injection References 
builder.Services.AddScoped<IMusicService,MusicService>();
builder.Services.AddScoped<IMusicRepo,MusicRepo>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
