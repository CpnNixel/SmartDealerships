using FastEndpoints;
using MediatR;
using SmartDealerships.Infrastructure.Commands;
using SmartDealerships.WebApi.Features.Login;

namespace SmartDealerships.WebApi.Features.Registration;

public class RegistrationEndpoint : Endpoint<RegistrationRequest, RegistrationResponse>
{
    public IMediator mediator { get; set; }
        

    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("account/register");
        AllowAnonymous();
    }

    public override async Task HandleAsync(RegistrationRequest req, CancellationToken ct)
    {
        var res = mediator.Send(new RegisterCommand(
            req.Email,
            req.FirstName,
            req.LastName,
            req.Password,
            req.Address,
            req.Telephone
        ));
        
        if (res.Result.IsSuccessful)
        {
            await SendOkAsync(new RegistrationResponse{Token = res.Result.Token}, ct);
        }
        else
        {
            await SendNotFoundAsync(ct);
        }
    }
}