using SmartDealerships.Infrastructure.Responses;
using SmartDealerships.WebApi.Common;

namespace SmartDealerships.WebApi.Features.ShoppingCart.GetCartStatus;

public class GetCartStatusRequest : BaseRequest
{
    public GetCartStatusRequest(string userToken) : base(userToken)
    {
    }
    
    public GetCartStatusRequest() : base()
    {
    }
}

public class GetCartStatusResponse : BaseResponse
{
    public GetCartStatusResponse(string message) : base(message)
    {
    }

    public GetCartStatusResponse() : base()
    {
    }
    
    public decimal Total { get; set; }
    
    public IEnumerable<CartItemDto> Items { get; set; }
}