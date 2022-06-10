using FastEndpoints;
using MediatR;
using SmartDealerships.Infrastructure.Commands;

namespace SmartDealerships.WebApi.Features.ShoppingCart.Checkout;

public class CheckoutEndpoint : Endpoint<CheckoutRequest, CheckoutResponse>
{
    public IMediator Mediator { get; set; }

    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("cart/checkout");
        Roles("admin", "user");
    }

    public override async Task HandleAsync(CheckoutRequest req, CancellationToken ct)
    {
        var res = Mediator.Send(new CheckoutCommand(req.UserToken));
        
        if (!string.IsNullOrEmpty(res.Result))
        {
            await SendOkAsync(new CheckoutResponse("success"), ct);
        }
        else
        {
            await SendErrorsAsync(404, ct);
        }
    }
}