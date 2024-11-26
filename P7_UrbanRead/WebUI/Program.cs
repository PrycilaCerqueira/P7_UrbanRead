using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using WebUI.Areas.Identity;
using WebUI.Areas.Identity.Data;
using WebUI.Data;

namespace WebUI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<WebUIContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            builder.Services.AddDefaultIdentity<WebUIUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<WebUIContext>();
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddQuickGridEntityFrameworkAdapter();
            builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<WebUIUser>>();
            builder.Services.AddSingleton<MainDataService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
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

            app.MapControllers();
            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");


            //Creating the roles during the first time the program runs 
            using (var _Scope = app.Services.CreateScope())
            {
                var _RoleManager = _Scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                var _Roles = new[] { "Admin", "Member" };

                foreach (var _Role in _Roles)
                {
                    if(!await _RoleManager.RoleExistsAsync(_Role))
                    {
                        await _RoleManager.CreateAsync(new IdentityRole(_Role));
                    }
                }

            }

            //Creating a default admin user account during the first time the program runs
            using (var _Scope = app.Services.CreateScope())
            {
                var _UserManager = _Scope.ServiceProvider.GetRequiredService<UserManager<WebUIUser>>();

                string _Email = "admin@urban.com";
                string _Password = "adminUrban,1!";

                if(await _UserManager.FindByEmailAsync(_Email) == null)
                {
                    var _User = new WebUIUser();
                    _User.UserName = _Email;
                    _User.Email = _Email;
                    _User.EmailConfirmed = true;

                    await _UserManager.CreateAsync(_User, _Password);
                    
                    await _UserManager.AddToRoleAsync(_User, "Admin");
                }

            }

                app.Run();
        }
    }
}