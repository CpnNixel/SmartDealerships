using Microsoft.EntityFrameworkCore;
using SmartDealerships.Infrastructure.Models;

namespace SmartDealerships.DataAccess.PSQL;

public class DealershipDbContext : IDealershipsDbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
}