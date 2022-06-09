namespace SmartDealerships.WebApi.Features.ShoppingCart.AddToCart;

public class AddToCartRequest
{
    public AddToCartRequest(int userId, List<CartItem> productIdAndQty)
    {
        UserId = userId;
        ProductIdAndQty = productIdAndQty;
    }
    
    public AddToCartRequest()
    {
    }
    
    public int UserId { get; init; }
    
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

    public string Message { get; init; }
}

