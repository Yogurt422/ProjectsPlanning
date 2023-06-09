using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectsPlanning.Chernetsov;
using ProjectsPlanning.Chernetsov.Data;
using ProjectsPlanning.Chernetsov.Entities;
using ProjectsPlanning.Chernetsov.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();

builder.Services.AddScoped<IProjectsService, ProjectsService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ITeamService, TeamService>();

var configuration = builder.Configuration;

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(configuration.GetConnectionString("BloggingDatabase")));


builder.Services.AddDefaultIdentity<User>()
               .AddRoles<IdentityRole<int>>()
               .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped<UserManager<User>>();
builder.Services.AddScoped<RoleManager<IdentityRole<int>>>();


var app = builder.Build();

using var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();

await SeedData.EnsureSeedData(scope.ServiceProvider);

await SeedDataCategory.EnsureSeedData(scope.ServiceProvider);

await SeedDataTaskType.EnsureSeedData(scope.ServiceProvider);

await SeedDataPost.EnsureSeedData(scope.ServiceProvider);

await SeedDataStatus.EnsureSeedData(scope.ServiceProvider);

await SeedDataPriority.EnsureSeedData(scope.ServiceProvider);

await SeedDataTeam.EnsureSeedData(scope.ServiceProvider);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
