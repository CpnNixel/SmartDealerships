namespace SmartDealerships.WebApi.Features.ShoppingCart.EmptyCart;

public class EmptyCartResponse 
{
    public EmptyCartResponse(string message)
    {
        Message = message;
    }

    public EmptyCartResponse()
    {
    }

    public string Message { get; set; }
}