using SmartDealerships.Infrastructure.Responses;
namespace SmartDealerships.WebApi.Features.ShoppingCart.GetCartStatus;

public class GetCartStatusRequest 
{
    public GetCartStatusRequest(string userToken)
    {
        UserToken = userToken;
    }

    public GetCartStatusRequest()
    {
    }

    public string UserToken { get; set; }
}

public class GetCartStatusResponse
{
    public GetCartStatusResponse(string message)
    {
        Message = message;
    }

    public GetCartStatusResponse()
    {
    }
    public string Message { get; set; }
    public decimal Total { get; set; }
    
    public IEnumerable<CartItemDto> Items { get; set; }
}