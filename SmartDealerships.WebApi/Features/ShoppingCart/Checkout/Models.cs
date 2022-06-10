using SmartDealerships.WebApi.Common;

namespace SmartDealerships.WebApi.Features.ShoppingCart.Checkout;

public class CheckoutRequest
{
    public CheckoutRequest(string userToken)
    {
        UserToken = userToken;
    }

    public CheckoutRequest()
    {
    }
    
    public string UserToken { get; set; }
}

public class CheckoutResponse : BaseResponse
{
    public CheckoutResponse(string message) : base(message)
    {
    }

    public CheckoutResponse() : base()
    {
    }
}
