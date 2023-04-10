using Microsoft.EntityFrameworkCore;
namespace portfolio_API.Models;
public class PostContext : DbContext
{
    public PostContext(DbContextOptions<PostContext> options)
        : base(options)
    {
    }

    public DbSet<PostItem> PostItems { get; set; } = null!;
}
