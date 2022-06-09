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

        #region SeedingData
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

        modelBuilder.Entity<Company>()
            .HasData(
                new Company
                {
                    Id = 1,
                    Name = "Truck shop",
                    Description = string.Empty
                }
            );

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
                    ModifiedAt = DateTime.Now.SetKindUtc(),
                    CompanyId = 1
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
                    ModifiedAt = DateTime.Now.SetKindUtc(),
                    CompanyId = 1
                });

        modelBuilder.Entity<Category>()
            .HasData(
                new Category
                {
                    Id = 1,
                    Name = "Spare parts"
                },
                new Category
                {
                    Id = 2,
                    Name = "Fuel filtes"
                },
                new Category
                {
                    Id = 3,
                    Name = "Battery"
                },
                new Category
                {
                    Id = 4,
                    Name = "Brake pads"
                },
                new Category
                {
                    Id = 5,
                    Name = "Brake rotor"
                }
            );

        modelBuilder.Entity<Product>()
            .HasData(
                new Product
                {
                    Id = 1,
                    Name = "Duralast Ceramic Brake Pads",
                    Description = "Brakes squealing? Are you experiencing longer stopping distances? Get reliable, everyday performance for regular driving needs from Duralast brake pads, designed to meet your vehicles original equipment for form, fit, and function. Available only at AutoZone, Duralast brake pads use platform-specific, semi-metallic friction materials tailored to your vehicle. Replace rotors and hardware when replacing brake pads for better performance and less noise.",
                    Sku = "MKD503",
                    Price = 300.5m,
                    CategoryId = 4,
                    CompanyId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "Duralast Ceramic Brake Pads D924",
                    Description = "Brakes squealing? Are you experiencing longer stopping distances? Get reliable, everyday performance for regular driving needs from Duralast brake pads, designed to meet your vehicles original equipment for form, fit, and function. Available only at AutoZone, Duralast brake pads use platform-specific, semi-metallic friction materials tailored to your vehicle. Replace rotors and hardware when replacing brake pads for better performance and less noise.",
                    Sku = "D924",
                    Price = 36.99m,
                    CategoryId = 4,
                    CompanyId = 1
                },
                new Product
                {
                    Id = 3,
                    Name = "Duralast Ceramic Brake Pads D1339",
                    Description = "Brakes squealing? Are you experiencing longer stopping distances? Get reliable, everyday performance for regular driving needs from Duralast brake pads, designed to meet your vehicles original equipment for form, fit, and function. Available only at AutoZone, Duralast brake pads use platform-specific, semi-metallic friction materials tailored to your vehicle. Replace rotors and hardware when replacing brake pads for better performance and less noise.",
                    Sku = "D1339",
                    Price = 44.49m,
                    CategoryId = 4,
                    CompanyId = 1
                },
                new Product
                {
                    Id = 4,
                    Name = "Duralast Brake Rotor 31069",
                    Description = "Engineered to properly remove heat from the brake system,OE compliance for equal or better rotor performance, reduced pulsation, and noise.",
                    Sku = "31069",
                    Price = 59.99m,
                    CategoryId = 5,
                    CompanyId = 1
                },
                new Product
                {
                    Id = 5,
                    Name = "Duralast Brake Rotor 55097",
                    Description = "Engineered to properly remove heat from the brake system,OE compliance for equal or better rotor performance, reduced pulsation, and noise.",
                    Sku = "55097",
                    Price = 89.99m,
                    CategoryId = 5,
                    CompanyId = 1
                },          
                new Product
                {
                    Id = 6,
                    Name = "Duralast Brake Rotor 55072DL",
                    Description = "Engineered to properly remove heat from the brake system,OE compliance for equal or better rotor performance, reduced pulsation, and noise.",
                    Sku = "55072DL",
                    Price = 79.99m,
                    CategoryId = 5,
                    CompanyId = 1
                },             
                new Product{
                    Id = 7,
                    Name = "Duralast Brake Rotor 5333",
                    Description = "Duralast® brand disc brake rotors are designed and engineered to match J431 and your vehicles original equipment performance. Our Duralast® rotors can replace your OE parts with no change in performance and safety. So when you need a part you can trust at a price you can afford.",
                    Sku = "55072DL",
                    Price = 97.99m,
                    CategoryId = 5,
                    CompanyId = 1
                }
            );
        #endregion
    }
    
    public DbSet<User> Users { get; set; }
    
    public DbSet<Product> Products { get; set; }               
    
    public DbSet<OrderDetails> OrderDetails { get; set; }
    
    public DbSet<Category> Categories { get; set; }

    public DbSet<ShoppingSession> ShoppingSessions { get; set; }
    
    public DbSet<CartItem> CartItems { get; set; }
    
    public DbSet<Company> Companies { get; set; }
    
    public DbSet<Role> Roles { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken ct = default) => base.SaveChangesAsync(ct);

}