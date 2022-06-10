using FastEndpoints;
using MediatR;
using SmartDealerships.Infrastructure.Queries;
using Microsoft.Net.Http.Headers;

namespace SmartDealerships.WebApi.Features.Users;

public class GetAllUsersEndpoint : EndpointWithoutRequest<UsersResponse>
{
    public IMediator mediator { get; set; }
    
    public IHttpContextAccessor _httpContextAccessor { get; set; }
    
    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("users/all");
        Roles("admin");
    }
    
    public override async Task HandleAsync(CancellationToken ct)
    {
        var users = mediator.Send(new GetAllUsersQuery(), ct);
        
        // var token = Request.Headers[HeaderNames.Authorization];
        var token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];

        if (!users.Result.Any())
            await SendNotFoundAsync(ct);
        else
        {
            await SendOkAsync(new UsersResponse{Users = users.Result, Token = token}, ct);
        }
    }
}