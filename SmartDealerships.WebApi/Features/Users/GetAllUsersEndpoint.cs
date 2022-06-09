using FastEndpoints;
using MediatR;
using SmartDealerships.Infrastructure.Queries;

namespace SmartDealerships.WebApi.Features.Users;

public class GetAllUsersEndpoint : EndpointWithoutRequest<UsersResponse>
{
    public IMediator mediator { get; set; }

    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("get-all-users");
        Roles("admin");
    }
    
    public override async Task HandleAsync(CancellationToken ct)
    {
        var users = mediator.Send(new GetAllUsersQuery(), ct);
        
        if (!users.Result.Any())
            await SendNotFoundAsync(ct);
        else
        {
            await SendOkAsync(new UsersResponse{Users = users.Result}, ct);
        }
    }
}