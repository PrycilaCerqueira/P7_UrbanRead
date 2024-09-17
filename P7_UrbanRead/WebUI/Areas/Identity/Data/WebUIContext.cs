using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebUI.Areas.Identity.Data;
using P7_UrbanRead;
using System.Reflection.Emit;


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


        builder.Entity<WebUIUser>()
           .Property(cc => cc._ConcurencyCheck).IsConcurrencyToken();
    }

    public DbSet<WebUIUser> UsersIdentity { get; set; } = default!;


}