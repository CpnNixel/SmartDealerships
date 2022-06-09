using MediatR;

namespace SmartDealerships.Infrastructure.Commands;

public class AddToCartCommand : IRequest<string>
{
    public AddToCartCommand(int userId, List<CartItemDto> cartItems)
    {
        UserId = userId;
        CartItems = cartItems;
    }
    
    public int UserId { get; init; }
    
    public List<CartItemDto> CartItems { get; init; }
}

public record CartItemDto (int ProductId, int Quantity);