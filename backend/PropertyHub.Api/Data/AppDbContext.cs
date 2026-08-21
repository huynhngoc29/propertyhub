using Microsoft.EntityFrameworkCore;
using PropertyHub.Api.Entities;

namespace PropertyHub.Api.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)  : base(options)
    {
        
    }
    public DbSet<Property> Properties { get; set; }
    public DbSet<Unit> Units { get; set; }
}