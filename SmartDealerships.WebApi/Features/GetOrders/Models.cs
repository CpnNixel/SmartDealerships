using SmartDealerships.Infrastructure.Responses;

namespace SmartDealerships.WebApi.Features.GetOrders;

public class GetOrdersResponse
{

    public GetOrdersResponse(List<OrderListDto>? orders, bool isSuccessful, string messsage)
    {
        Orders = orders;
        IsSuccessful = isSuccessful;
        Message = messsage;
    }

    public GetOrdersResponse()
    {
    }

    public List<OrderListDto>? Orders { get; set; }

    public bool IsSuccessful { get; set; }

    public string Message { get; set; }

}


public record Order(int OrderId, decimal total, List<OrderItem> OrderItems);

public record OrderItem(int Id, string Name, string SKU, decimal price, string Description, string CategoryName, string dateCreated);