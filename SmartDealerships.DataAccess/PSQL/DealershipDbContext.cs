using Microsoft.EntityFrameworkCore;
using SmartDealerships.Infrastructure.Models;

namespace SmartDealerships.DataAccess.PSQL;

public class DealershipDbContext : DbContext
{
    public DealershipDbContext(DbContextOptions<DealershipDbContext> options): base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseSerialColumns();
    }
    
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
}