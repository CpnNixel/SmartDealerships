using Microsoft.EntityFrameworkCore;
using SmartDealerships.Infrastructure.Models;

namespace SmartDealerships.DataAccess.Interfaces;

public interface IDealershipDbContext
{
    DbSet<User> Users { get; set; }
    DbSet<Product> Products { get; set; }
    DbSet<OrderDetails> OrderDetails { get; set; }
    DbSet<ShoppingSession> ShoppingSessions { get; set; }
    DbSet<CartItem> CartItems { get; set; }
    DbSet<Company> Companies { get; set; }

    int SaveChanges();
}