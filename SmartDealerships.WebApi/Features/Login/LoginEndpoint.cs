using FastEndpoints;
using MediatR;
using SmartDealerships.Infrastructure.Queries;

namespace SmartDealerships.WebApi.Features.Login;

public class LoginEndpoint  : Endpoint<LoginRequest, LoginResponse>
{
    public IMediator mediator { get; set; }
    
    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("login");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync (LoginRequest? req, CancellationToken ct)
    {
        if (req == null)
        {
            await SendNotFoundAsync(ct);
        }

        var res = mediator.Send(new LoginUserQuery(req.Email, req.Password), ct).Result;
        
        if (res.IsSuccessful)
        {
            await SendOkAsync(new LoginResponse {Token = res.Token}, ct);
        }
        else
        {
            await SendNotFoundAsync(ct);
        }
    }
}