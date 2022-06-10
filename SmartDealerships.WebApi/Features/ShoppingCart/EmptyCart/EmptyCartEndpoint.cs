using FastEndpoints;
using MediatR;
using SmartDealerships.Infrastructure.Commands;

namespace SmartDealerships.WebApi.Features.ShoppingCart.EmptyCart;

public class EmptyCartEndpoint : Endpoint<EmptyCartRequest, EmptyCartResponse>
{
    public IMediator Mediator { get; set; }

    public override void Configure()
    {
        Verbs(Http.PUT);
        Routes("cart/empty");
        Roles("admin", "user");
    }

    public override async Task HandleAsync(EmptyCartRequest req, CancellationToken ct)
    {
        var res = Mediator.Send(new EmptyCartCommand(req.UserToken));
        
        if (!string.IsNullOrEmpty(res.Result))
        {
            await SendOkAsync(new EmptyCartResponse("success"), ct);
        }
        else
        {
            await SendNotFoundAsync(ct);
        }
    }
}