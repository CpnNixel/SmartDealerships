using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore;
using SmartDealerships.Infrastructure.Models;

public interface IDealershipsDbContext
{
	DbSet<Product> Products {get;set;}
	DbSet<User> Users { get; set; }
}
