using MediatR;

namespace SmartDealerships.Infrastructure.Commands;

public class AddToCartCommand : IRequest<string>
{
    public AddToCartCommand(string userToken, int productId, int productQty)
    {
        UserToken = userToken;
        ProductId = productId;
        ProductQty = productQty;
    }

    public string UserToken { get; init; }

    public int ProductQty { get; set; }
    public int ProductId { get; set; }
}

public record CartItemMini(int ProductId, int Quantity);