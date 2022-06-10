using MediatR;

namespace SmartDealerships.Infrastructure.Commands;

public class AddToCartCommand : IRequest<string>
{
    public AddToCartCommand(string userToken, List<CartItemMini> cartItems)
    {
        UserToken = userToken;
        CartItems = cartItems;
    }
    
    public string UserToken{ get; init; }
    
    public List<CartItemMini> CartItems { get; init; }
}

public record CartItemMini (int ProductId, int Quantity);