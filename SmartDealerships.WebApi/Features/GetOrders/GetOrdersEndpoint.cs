using FastEndpoints;
using MediatR;
using SmartDealerships.Infrastructure.Queries;

namespace SmartDealerships.WebApi.Features.GetOrders;

public class GetOrdersEndpoint : EndpointWithoutRequest<GetOrdersResponse>
{
    public IMediator mediator { get; set; }

    public IHttpContextAccessor _httpContextAccessor { get; set; }

    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("api/companies/orders");
        Roles("user", "admin", "sc");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        string authorizationHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];

        if (string.IsNullOrEmpty(authorizationHeader))
        {
            await SendErrorsAsync(StatusCodes.Status401Unauthorized, ct);
        }

        var response = mediator.Send(new GetCompanyOrdersQuery { UserToken = authorizationHeader[7..] });

        if (response != null)
        {
            await response.Result.Match(
                async res =>
                {
                    await SendOkAsync(
                        new GetOrdersResponse(res, true, "success"), ct);
                },
                async ex =>
                {
                    await SendOkAsync(
                        new GetOrdersResponse(null, false, ex.Message), ct);
                });
        }
        else
        {
            await SendNotFoundAsync(ct);
        }

    }
}