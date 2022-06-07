using Microsoft.EntityFrameworkCore;
using SmartDealerships.DataAccess.Interfaces;
using SmartDealerships.Infrastructure.Extensions;
using SmartDealerships.Infrastructure.Models;

namespace SmartDealerships.DataAccess.PSQL;

public sealed class DealershipDbContext : DbContext, IDealershipDbContext
{
    public DealershipDbContext(DbContextOptions<DealershipDbContext> options): base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // modelBuilder.UseSerialColumns();
        modelBuilder.UseIdentityByDefaultColumns();
        modelBuilder.Entity<OrderDetails>()
            .HasMany<Product>(s => s.Products)
            .WithMany(c => c.Orders);

        modelBuilder.Entity<User>()
            .HasData(
                new User
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@gmail.com",
                    PasswordHash = "am9obmRvZTI0MTAK",
                    Address = "Kharkiv city, Buchmy 50",
                    Telephone = "380662016",
                    CreatedAt = DateTime.Now.SetKindUtc(),
                    ModifiedAt = DateTime.Now.SetKindUtc()
                },
                
                new User
                {
                    Id = 2,
                    FirstName = "Mykyta",
                    LastName = "Kysil",
                    Email = "mykyta.kysil@nure.ua",
                    PasswordHash = "MTIwOTE5OTMK",
                    Address = "Pervomaiskiy",
                    Telephone = "0662016521",
                    CreatedAt = DateTime.Now.SetKindUtc(),
                    ModifiedAt = DateTime.Now.SetKindUtc()
                });
    }
    
    public DbSet<User> Users { get; set; }
    
    public DbSet<Product> Products { get; set; }               
    
    public DbSet<OrderDetails> OrderDetails { get; set; }
    
    public DbSet<ShoppingSession> ShoppingSessions { get; set; }
    
    public DbSet<CartItem> CartItems { get; set; }
    
    public DbSet<Company> Companies { get; set; }

}