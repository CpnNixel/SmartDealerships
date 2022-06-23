namespace SmartDealerships.WebApi.Features.ShoppingCart.AddToCart;

public class AddToCartRequest
{
    public AddToCartRequest(int productId, int productQty)
    {
        ProductId = productId;
        ProductQty = productQty;
    }

    public AddToCartRequest()
    {
    }

    public int ProductQty { get; set; }
    public int ProductId { get; set; }
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

