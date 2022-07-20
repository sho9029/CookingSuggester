using Microsoft.EntityFrameworkCore;

namespace CookingSuggester.Shared;

public class CookingDbContext : DbContext
{
    public CookingDbContext(DbContextOptions options)
        : base(options)
    { 
    }

    public DbSet<Cooking> cookings { get; set; }
    public DbSet<Materials> materials { get; set; }
}
