using SmartDealerships.WebApi.Common;

namespace SmartDealerships.WebApi.Features.ShoppingCart.EmptyCart;

public class EmptyCartRequest : BaseRequest
{
    public EmptyCartRequest(string userToken)
        : base(userToken)
    {
    }

    public EmptyCartRequest()
        : base()
    {
    }
}

public class EmptyCartResponse : BaseResponse
{
    public EmptyCartResponse(string message) 
        : base(message)
    {
    }

    public EmptyCartResponse()
        : base()
    {
    }

}