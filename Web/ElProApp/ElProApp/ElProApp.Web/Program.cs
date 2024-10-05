using ElProApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string identityConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
string businessConnectionString = builder.Configuration.GetConnectionString("BusinessConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(identityConnectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services
    .AddDefaultIdentity<IdentityUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = true;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services
    .AddDbContext<ElProAppDbContext>(options =>
    {
        options.UseSqlServer(businessConnectionString);
    });

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
