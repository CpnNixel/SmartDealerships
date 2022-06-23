using FastEndpoints;
using MediatR;
using SmartDealerships.Infrastructure.Queries;

namespace SmartDealerships.WebApi.Features.Companies
{
    public class GetUserCompanyEndpoint : EndpointWithoutRequest<UserCompanyResponse>
    {
        public IMediator Mediator { get; set; }

        public IHttpContextAccessor _httpContextAccessor { get; set; }

        public override void Configure()
        {
            Verbs(Http.GET);
            Routes("api/companies/");
            Roles("user", "admin");
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            string authorizationHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];

            if (string.IsNullOrEmpty(authorizationHeader))
            {
                await SendErrorsAsync(StatusCodes.Status401Unauthorized, ct);
            }

            string token = authorizationHeader.Substring(7);

            var response = Mediator.Send(new GetUserCompanyQuery(token), ct);

            if (response != null)
            {
                await response.Result.Match(
                    async res =>
                    {
                        await SendOkAsync(
                            new UserCompanyResponse(res, true, "success", DateTime.Now.ToString("yyyy-MM-dd")), ct);
                    },
                    async ex =>
                    {
                        await SendOkAsync(
                            new UserCompanyResponse(false, ex.Message), ct);
                    });
            }
            else
            {
                await SendNotFoundAsync(ct);
            }
        }
    }
}

