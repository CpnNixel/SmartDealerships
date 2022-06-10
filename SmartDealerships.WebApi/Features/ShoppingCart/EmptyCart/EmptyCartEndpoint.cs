using FastEndpoints;
using MediatR;
using SmartDealerships.Infrastructure.Commands;

namespace SmartDealerships.WebApi.Features.ShoppingCart.EmptyCart;

public class EmptyCartEndpoint : EndpointWithoutRequest<EmptyCartResponse>
{
    public IMediator Mediator { get; set; }

    public IHttpContextAccessor _httpContextAccessor { get; set; }
    
    public override void Configure()
    {
        Verbs(Http.PUT);
        Routes("cart/empty");
        Roles("admin", "user");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        string authorizationHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
        
        if (string.IsNullOrEmpty(authorizationHeader))
        {
            await SendErrorsAsync(StatusCodes.Status401Unauthorized, ct);
        }
        
        string  token = authorizationHeader.Substring(7);
        
        var res = Mediator.Send(new EmptyCartCommand(token));
        
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