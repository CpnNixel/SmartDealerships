namespace SmartDealerships.WebApi.Features.GetOrders;

public class GetOrdersResponse
{
    public List<Order> Type { get; set; }
    
}

public record Order(int OrderId, decimal total, List<OrderItem> OrderItems);

public record OrderItem(int Id, string Name, string SKU, decimal price, string Description, string CategoryName);