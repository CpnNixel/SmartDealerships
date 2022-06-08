using Microsoft.EntityFrameworkCore;
using SmartDealerships.DataAccess.Extensions;
using SmartDealerships.DataAccess.Interfaces;
using SmartDealerships.DataAccess.Models;

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
        
        modelBuilder.Entity<Role>()
            .HasData(
                new Role
                {
                    Id = 1,
                    RoleName = "User"
                },
                new Role
                {
                    Id = 2,
                    RoleName = "Admin"
                });
        
        modelBuilder.Entity<User>()
            .HasData(
                new User
                {
                    Id = 1,
                    RoleId = 1,
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
                    RoleId = 2,
                    FirstName = "Mykyta",
                    LastName = "Kysil",
                    Email = "mykyta.kysil@nure.ua",
                    PasswordHash = "MTIwOTE5OTM=",
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
    
    public DbSet<Role> Roles { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken ct = default) => base.SaveChangesAsync(ct);

}