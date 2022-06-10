using System.Net;
using FastEndpoints;
using MediatR;
using SmartDealerships.Infrastructure.Queries;

namespace SmartDealerships.WebApi.Features.ShoppingCart.GetCartStatus;

public class GetCartStatusEndpoint : Endpoint<GetCartStatusRequest, GetCartStatusResponse>
{
    public IMediator Mediator { get; set; }

    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("get-cart-status");
        Roles("admin", "user");
    }

    public override async Task HandleAsync(GetCartStatusRequest req, CancellationToken ct)
    {
        var res = Mediator.Send(new GetCartStatusQuery(req.UserToken));
        
        if (res.Result.Items.Any())
        {
            await SendOkAsync(new GetCartStatusResponse
            {
                Total = res.Result.Total,
                Items = res.Result.Items
            }, ct);
        }
        else if (res.Result.Total == 0)
        {
            await SendOkAsync(new GetCartStatusResponse("cart is empty"), ct);
        }
        else
        {
            await SendErrorsAsync(404, ct);
        }
    }
}