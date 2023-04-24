using Microsoft.EntityFrameworkCore;
namespace portfolio_API.Models;
public class WorksContext : DbContext
{
    public WorksContext(DbContextOptions<WorksContext> options)
        : base(options)
    {
    }

    public DbSet<WorksItem> WorksItems { get; set; } = null!;
}