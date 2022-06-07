namespace SmartDealerships.DataAccess.Models;

public class OrderDetails
{
    public int Id { get; set; }
    
    public int? UserId { get; set; }
    
    public User User { get; set; }
    
    public int? CompanyId { get; set; }
    
    public Company SellingCompany { get; set; } 
    public virtual ICollection<Product> Products { get; set; }
    
    public decimal Total { get; set; }
    
    public DateTime CreatedAt {get; set; }
    
    public DateTime ModifiedAt {get; set; }
}