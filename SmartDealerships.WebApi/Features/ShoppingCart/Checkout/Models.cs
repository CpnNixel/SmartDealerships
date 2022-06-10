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

public class CheckoutResponse
{
    public CheckoutResponse(string message)
    {
        Message = message;
    }

    public CheckoutResponse()
    {
    }
    
    public string Message { get; set; }
}
