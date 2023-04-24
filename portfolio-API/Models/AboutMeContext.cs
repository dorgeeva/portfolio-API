using Microsoft.EntityFrameworkCore;
namespace portfolio_API.Models;
public class AboutMeContext : DbContext
{
    public AboutMeContext(DbContextOptions<AboutMeContext> options)
        : base(options)
    {
    }

    public DbSet<AboutMeItem> AboutMeItems { get; set; } = null!;
}
