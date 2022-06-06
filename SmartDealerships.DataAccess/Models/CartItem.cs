using System.ComponentModel.DataAnnotations;

namespace SmartDealerships.Infrastructure.Models;

public class CartItem
{
    public int Id { get; set; }

    public int? ShoppingSessionId { get; set; }

    public ShoppingSession ShoppingSession { get; set; }
    
    [Required]
    public int Qty { get; set; }

    public decimal Total { get; set; }
    
    public DateTime CreatedAt {get; set; }
    
    public DateTime ModifiedAt {get; set; }
}