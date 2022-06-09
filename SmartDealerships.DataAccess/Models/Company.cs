namespace SmartDealerships.DataAccess.Models;

public class Company
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public byte[]? LogoImage { get; set; }

    public virtual ICollection<User> Owners { get; set; }
    
    public virtual ICollection<Product> Products { get; set; }
}