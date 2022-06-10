namespace SmartDealerships.WebApi.Features.ShoppingCart.AddToCart;

public class AddToCartRequest
{
    public AddToCartRequest(List<CartItem> productIdAndQty)
    {
        ProductIdAndQty = productIdAndQty;
    }
    
    public AddToCartRequest()
    {
    }

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

