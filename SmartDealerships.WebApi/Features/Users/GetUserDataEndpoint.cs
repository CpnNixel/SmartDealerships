using FastEndpoints;
using MediatR;
using SmartDealerships.Infrastructure.Queries;
using SmartDealerships.Infrastructure.Responses;

namespace SmartDealerships.WebApi.Features.Users
{
    public class GetUserDataEndpoint : Endpoint<UserDataRequest, UserDto>
    {
        public IMediator mediator { get; set; }

        public IHttpContextAccessor _httpContextAccessor { get; set; }

        public override void Configure()
        {
            Verbs(Http.POST);
            Routes("api/account/get");
            Roles("user", "admin");
        }

        public override async Task HandleAsync(UserDataRequest req, CancellationToken ct)
        {
            var result = mediator.Send(new GetUserDataQuery(req.token));

            if (result is null)
            {
                await SendErrorsAsync(404, ct);
                return;
            }

            await SendOkAsync(result.Result, ct);
        }
    }
}
