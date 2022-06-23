using FastEndpoints;
using MediatR;
using SmartDealerships.Infrastructure.Commands;

namespace SmartDealerships.WebApi.Features.Registration;

public class RegistrationEndpoint : Endpoint<RegistrationRequest, RegistrationResponse>
{
    public IMediator mediator { get; set; }


    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("api/account/register");
        AllowAnonymous();
    }

    public override async Task HandleAsync(RegistrationRequest req, CancellationToken ct)
    {
        var res = mediator.Send(new RegisterCommand(
            req.Email,
            req.FirstName,
            req.LastName,
            req.Password,
            req.PhoneNumber
        ));

        if (res.Result.IsSuccessful)
        {
            await SendOkAsync(new RegistrationResponse { token = res.Result.Token, isSuccessful = true }, ct);
        }
        else
        {
            await SendNotFoundAsync(ct);
        }
    }
}