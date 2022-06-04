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
        modelBuilder.Entity<OrderDetails>()
            .HasMany<Product>(s => s.Products)
            .WithMany(c => c.Orders);
        
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }                                                            
    public DbSet<OrderDetails> OrderDetails { get; set; }
    // public DbSet<OrderItems> OrderItems { get; set; }

}