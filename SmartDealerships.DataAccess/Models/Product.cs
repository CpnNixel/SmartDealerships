namespace SmartDealerships.DataAccess.Models;

public class Product
{
    public int Id { get; set; }
    
    public string? Name { get; set; }
    
    public string? Description { get; set; }
    
    public string? Sku { get; set; }
    
    public decimal Price { get; set; }

    public int? CategoryId { get; set; }
    
    public Category? Category { get; set; }
    
    public virtual ICollection<OrderDetails> Orders { get; set; }
    
    public int CompanyId { get; set; }
    
    public Company Company { get; set; }
}