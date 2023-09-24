using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using SimWars.Server.Data;
using SimWars.Server.Models;
using SimWars.Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>
  (options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<SimWarsContext>
  (options => options.UseSqlServer(connectionString));

builder.Services.AddTransient<IPlayerService, PlayerService>();
builder.Services.AddTransient<IStoreItemService, StoreItemService>();
builder.Services.AddTransient<IStoreItemPrizeService, StoreItemPrizeService>();
builder.Services.AddTransient<IUserTeamService, UserTeamService>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddIdentityServer()
    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

builder.Services.AddAuthentication()
    .AddIdentityServerJwt();

builder.Services.ConfigureApplicationCookie(options => {
  options.ExpireTimeSpan = TimeSpan.FromHours(24*365);
  options.SlidingExpiration = true;
});

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
  app.UseMigrationsEndPoint();
  app.UseWebAssemblyDebugging();
} else {
  app.UseExceptionHandler("/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseIdentityServer();
app.UseAuthorization();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
