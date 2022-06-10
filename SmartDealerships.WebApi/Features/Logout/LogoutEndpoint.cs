using FastEndpoints;
using MediatR;
using SmartDealerships.Infrastructure.Commands;

namespace SmartDealerships.WebApi.Features.Logout;

public class LogoutEndpoint : Endpoint<LogoutRequest, LogoutResponse>
{
    public IMediator mediator { get; set; }
        

    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("account/logout");
        AllowAnonymous();
    }

    public override async Task HandleAsync(LogoutRequest req, CancellationToken ct)
    {
        var res = mediator.Send(new LogoutCommand(req.UserToken), ct);
        
        if (res.Result)
            await SendOkAsync(new LogoutResponse {Message = "Successful"}, ct);
        else
            await SendErrorsAsync(400, ct);
    }
}