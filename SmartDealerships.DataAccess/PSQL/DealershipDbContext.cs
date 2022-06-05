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

        // // modelBuilder
        // //     .Entity<Company>()
        // //     .HasMany<Product>(p => p.Products)
        // //     .WithMany(p => p.Companies);
        // //
        // modelBuilder.Entity<Product>()
        //     .HasMany<Company>(x => x.Companies)
        //     .WithMany(x => x.Products);

    }
    
    public DbSet<User> Users { get; set; }
    
    public DbSet<Product> Products { get; set; }               
    
    public DbSet<OrderDetails> OrderDetails { get; set; }
    
    public DbSet<ShoppingSession> ShoppingSessions { get; set; }
    
    public DbSet<CartItem> CartItems { get; set; }
    
    public DbSet<Company> Companies { get; set; }

}