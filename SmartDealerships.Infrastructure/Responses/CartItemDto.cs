namespace SmartDealerships.Infrastructure.Responses;

public class CartItemDto
{
    public int Id { get; set; }
    
    public string Name { get; set; }

    public decimal Price { get; set; }
    
    public int Quantity { get; set; }

    public string SKU { get; set; }

    public string Description { get; set; }

    public string CategoryName { get; set; }
}