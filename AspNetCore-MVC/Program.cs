using Infrastructure.Contexts;
using Infrastructure.Entites;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Sqlserver")));


//builder.Services.AddIdentity<UserEntity, IdentityRole>(x =>
//{

//    x.User.RequireUniqueEmail = true;
//    x.SignIn.RequireConfirmedAccount = false;
//    x.Password.RequiredLength = 8;

//})
//.AddEntityFrameworkStores<AppDbContext>();



builder.Services.AddDefaultIdentity<UserEntity>(x =>
{
    x.User.RequireUniqueEmail = true;
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequiredLength = 8;

})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();


builder.Services.AddScoped<AddressService>();
builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/signin";
    x.AccessDeniedPath = "/denied";
    x.Cookie.HttpOnly = true;
    x.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    x.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    x.SlidingExpiration = true;
});


builder.Services.AddAuthorization(async x =>
{
    x.AddPolicy("SuperAdmin", policy => policy.RequireRole( "SuperAdmin"));
    x.AddPolicy("CIO", policy => policy.RequireRole( "SuperAdmin" ,"CIO"));
    x.AddPolicy("Admins", policy => policy.RequireRole("Admin", "SuperAdmin"));
    x.AddPolicy("Manegar", policy => policy.RequireRole("SuperAdmin", "CIO", "Admin","Manegar", "User"));
    x.AddPolicy("AuthenticatedUsers", policy => policy.RequireRole( "SuperAdmin" , "CIO","Admin","User"));

});



var app = builder.Build();
app.UseHsts(); 
app.UseStatusCodePagesWithReExecute("/error", "?statusCode={0}");

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();




using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService < RoleManager < IdentityRole >>();
    string[] roles = ["SuperAdmin", "CIO","Admin", "Manegar", "User"];
    foreach(var role in roles)
        if(!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
}





app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
