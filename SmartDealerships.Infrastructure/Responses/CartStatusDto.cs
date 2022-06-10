namespace SmartDealerships.Infrastructure.Responses;

public class CartStatusDto
{
    public decimal Total { get; set; }
    
    public IEnumerable<CartItemDto> Items { get; set; }
}