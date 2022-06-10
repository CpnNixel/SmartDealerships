namespace SmartDealerships.WebApi.Features.ShoppingCart.EmptyCart;

public class EmptyCartRequest
{
    public EmptyCartRequest(string userToken)
    {
        UserToken = userToken;
    }

    public EmptyCartRequest()
    {
    }

    public string UserToken { get; set; }
}

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