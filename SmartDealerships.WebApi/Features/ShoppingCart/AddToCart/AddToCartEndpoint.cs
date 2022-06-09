using FastEndpoints;
using MediatR;
using SmartDealerships.Infrastructure.Commands;

namespace SmartDealerships.WebApi.Features.ShoppingCart.AddToCart;

public class AddToCartEndpoint : Endpoint<AddToCartRequest, AddToCartResponse>
{
    public IMediator mediator { get; set; }
    
    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("add-to-cart");
        Roles("user", "admin");
    }

    public override async Task HandleAsync(AddToCartRequest req, CancellationToken ct)
    {
        var res = mediator.Send(new AddToCartCommand(req.UserId,
            req.ProductIdAndQty.Select(p => new CartItemDto(p.ProductId, p.ProductQty)).ToList()));

        if (res.Result.Any())
        {
            await SendOkAsync(new AddToCartResponse("success"), ct);
        }
        else
        {
            await SendNotFoundAsync(ct);
        }
    }
}