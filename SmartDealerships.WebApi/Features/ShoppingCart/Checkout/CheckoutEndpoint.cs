using FastEndpoints;
using MediatR;
using SmartDealerships.Infrastructure.Commands;

namespace SmartDealerships.WebApi.Features.ShoppingCart.Checkout;

public class CheckoutEndpoint : EndpointWithoutRequest<CheckoutResponse>
{
    public IMediator Mediator { get; set; }

    public IHttpContextAccessor _httpContextAccessor { get; set; }

    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("api/cart/checkout");
        Roles("admin", "user");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        string authorizationHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];

        if (string.IsNullOrEmpty(authorizationHeader))
        {
            await SendErrorsAsync(StatusCodes.Status401Unauthorized, ct);
        }

        string token = authorizationHeader.Substring(7);

        var res = Mediator.Send(new CheckoutCommand(token));

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