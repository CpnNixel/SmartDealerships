using FastEndpoints;
using MediatR;
using SmartDealerships.Infrastructure.DTO;
using SmartDealerships.Infrastructure.Queries;

namespace SmartDealerships.WebApi.Features.Users;

public class UsersResponse
{
    public List<UserDTO> Users { get; set; }
}

public class GetAllUsersEndpoint : EndpointWithoutRequest<UsersResponse>
{
    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("getallusers");
        AllowAnonymous();
    }

    public IMediator mediator { get; set; }
    
    public override async Task HandleAsync(CancellationToken ct)
    {
        var users = mediator.Send(new GetUsersByNothing(), ct);
        
        if (!users.Result.Any())
            await SendNotFoundAsync(ct);
        else
        {
            await SendOkAsync(new UsersResponse{Users = users.Result}, ct);
        }
    }
}