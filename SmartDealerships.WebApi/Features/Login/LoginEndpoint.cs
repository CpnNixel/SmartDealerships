using FastEndpoints;
using MediatR;
using SmartDealerships.Infrastructure.Queries;

namespace SmartDealerships.WebApi.Features.Login;

public class LoginEndpoint : Endpoint<LoginRequest, LoginResponse>
{
    public IMediator mediator { get; set; }

    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("api/account/login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(LoginRequest? req, CancellationToken ct)
    {
        if (req == null)
        {
            await SendNotFoundAsync(ct);
        }

        var res = mediator.Send(new LoginUserQuery(req.email, req.password), ct).Result;

        if (res.IsSuccessful)
        {
            await SendOkAsync(new LoginResponse { user = res.User, token = res.Token, isSuccessful = true }, ct);
        }
        else
        {
            await SendNotFoundAsync(ct);
        }
    }
}