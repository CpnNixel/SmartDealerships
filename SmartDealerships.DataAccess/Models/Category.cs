namespace SmartDealerships.DataAccess.Models;

public class Category
{
    public int Id { get; set; }

    public string Name { get; set; }
    
    public virtual ICollection<Product> Products { get; set; }
}