namespace SmartDealerships.WebApi.Features.ShoppingCart.Checkout;

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
