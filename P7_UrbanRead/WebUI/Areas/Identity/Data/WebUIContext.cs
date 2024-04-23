using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebUI.Areas.Identity.Data;
using P7_UrbanRead;


namespace WebUI.Data;

public class WebUIContext : IdentityDbContext<WebUIUser>
{
    public WebUIContext(DbContextOptions<WebUIContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<WebUI.Areas.Identity.Data.WebUIUser> WebUIUser { get; set; } = default!;
    public DbSet<Person> Person { get; set; } = default!;
}