using FastEndpoints;
using MediatR;
using SmartDealerships.Infrastructure.Queries;

namespace SmartDealerships.WebApi.Features.GetOrders;

public class GetOrdersEndpoint : EndpointWithoutRequest<GetOrdersResponse>
{
    public IMediator mediator { get; set; }
        
    public IHttpContextAccessor _httpContextAccessor { get; set; }
    
    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("company/orders");
        Roles("user", "admin", "sc");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        string authorizationHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
        
        if (string.IsNullOrEmpty(authorizationHeader))
        {
            await SendErrorsAsync(StatusCodes.Status401Unauthorized, ct);
        }
        
        string  token = authorizationHeader.Substring(7);

        var res = mediator.Send(new GetCompanyOrdersQuery {UserToken = token});
        
        
    }
}