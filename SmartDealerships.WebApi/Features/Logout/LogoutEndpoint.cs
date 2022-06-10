using FastEndpoints;
using MediatR;
using SmartDealerships.Infrastructure.Commands;

namespace SmartDealerships.WebApi.Features.Logout;

public class LogoutEndpoint : EndpointWithoutRequest<LogoutResponse>
{
    public IMediator mediator { get; set; }
        
    public IHttpContextAccessor _httpContextAccessor { get; set; }
    
    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("account/logout");
        Roles("user", "admin");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        string authorizationHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
        
        if (string.IsNullOrEmpty(authorizationHeader))
        {
            await SendErrorsAsync(StatusCodes.Status401Unauthorized);
        }
        
        string  token = authorizationHeader.Substring(7);
        
        var res = mediator.Send(new LogoutCommand(token), ct);
        
        if (res.Result)
            await SendOkAsync(new LogoutResponse {Message = "Successful"}, ct);
        else
            await SendErrorsAsync(404, ct);
    }
}