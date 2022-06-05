namespace SmartDealerships.Infrastructure.Models;

public class Company
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public string Logo { get; set; }
    
    public virtual ICollection<User> Users { get; set; }
    
    public virtual ICollection<Product> Products { get; set; }
}