namespace SmartDealerships.DataAccess.Models;

public class Product
{
    public int Id { get; set; }
    
    public string? Name { get; set; }
    
    public string? Description { get; set; }
    
    public string? Sku { get; set; }
    
    public string? Category { get; set; }
    
    public decimal Price { get; set; }
    
    public virtual ICollection<OrderDetails> Orders { get; set; }
    
    public int CompanyId { get; set; }
    
    public Company SellingCompany { get; set; }
}