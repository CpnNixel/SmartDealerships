using FastEndpoints;
using MediatR;
using SmartDealerships.Infrastructure.Commands;

namespace SmartDealerships.WebApi.Features.Companies
{
    public class CreateCompanyEndpoint : Endpoint<CreateCompanyRequest, CreateCompanyResponse>
    {
        public IMediator Mediator { get; set; }

        public IHttpContextAccessor _httpContextAccessor { get; set; }

        public override void Configure()
        {
            Verbs(Http.POST);
            Routes("api/companies/create");
            Roles("admin, user");
        }

        public override async Task HandleAsync(CreateCompanyRequest req, CancellationToken ct)
        {

            string authorizationHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];

            if (string.IsNullOrEmpty(authorizationHeader))
            {
                await SendErrorsAsync(StatusCodes.Status401Unauthorized, ct);
            }

            string token = authorizationHeader.Substring(7);

            var response = Mediator.Send(new CreateCompanyCommand(token, req.Name, req.Description, req.Logo), ct);

            if (response != null)
            {
                await response.Result.Match(
                    async res =>
                    {
                        await SendOkAsync(
                            new CreateCompanyResponse("success", true), ct);
                    },
                    async ex =>
                    {
                        await SendOkAsync(
                            new CreateCompanyResponse(ex.Message, false), ct);
                    });
            }
            else
            {
                await SendNotFoundAsync(ct);
            }
        }

    }
}
