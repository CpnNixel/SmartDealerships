using System.ComponentModel.DataAnnotations;

namespace SmartDealerships.DataAccess.Models;

public class CartItem
{
    public int Id { get; set; }

    public int? ShoppingSessionId { get; set; }

    public ShoppingSession? ShoppingSession { get; set; }
    
    public int? ProductId { get; set; }

    public Product Product { get; set; }
    
    [Required]
    public int Qty { get; set; }
    
    public decimal Price { get; set; }
    
    public DateTime CreatedAt {get; set; }
    
    public DateTime ModifiedAt {get; set; }
}