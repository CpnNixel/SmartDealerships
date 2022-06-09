namespace SmartDealerships.DataAccess.Models;

public class ShoppingSession
{
    public int Id { get; set; }
    
    public int UserId { get; set; }
    
    public User User { get; set; }
    
    public string Token { get; set; }
    
    public decimal Total { get; set; }
    
    public virtual ICollection<CartItem> CartItems { get; set; }
        
    public DateTime CreatedAt {get; set; }
    
    public DateTime ModifiedAt {get; set; }
}