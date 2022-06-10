namespace SmartDealerships.WebApi.Features.ShoppingCart.AddToCart;

public class AddToCartRequest
{
    public AddToCartRequest(string userToken, List<CartItem> productIdAndQty)
    {
        UserToken = userToken;
        ProductIdAndQty = productIdAndQty;
    }
    
    public AddToCartRequest()
    {
    }
    
    public string UserToken { get; init; }
    
    public List<CartItem> ProductIdAndQty { get; init; }
}

public struct CartItem
{
    public int ProductId { get; set; }
    public int ProductQty { get; set; }
}


public class AddToCartResponse
{
    public AddToCartResponse(string message)
    {
        Message = message;
    }

    public AddToCartResponse()
    {
    }

    public string Message { get; set; }
}

