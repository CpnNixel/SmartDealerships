using FastEndpoints;
using MediatR;
using SmartDealerships.Infrastructure.Queries;

namespace SmartDealerships.WebApi.Features.ShoppingCart.GetCartStatus;

public class GetCartStatusEndpoint : EndpointWithoutRequest<GetCartStatusResponse>
{
    public IMediator Mediator { get; set; }

    public IHttpContextAccessor _httpContextAccessor { get; set; }
    
    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("cart/status");
        Roles("admin", "user");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        string authorizationHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
        
        if (string.IsNullOrEmpty(authorizationHeader))
        {
            await SendErrorsAsync(StatusCodes.Status401Unauthorized);
        }
        
        string  token = authorizationHeader.Substring(7);
        
        var res = Mediator.Send(new GetCartStatusQuery(token));
        
        if (res.Result.Items != null && res.Result.Items.Any())
        {
            await SendOkAsync(new GetCartStatusResponse
            {
                Total = res.Result.Total,
                Items = res.Result.Items
            }, ct);
        }
        else if (res.Result.Total == 0)
        {
            await SendOkAsync(new GetCartStatusResponse("cart is empty"), ct);
        }
        else
        {
            await SendErrorsAsync(404, ct);
        }
    }
}