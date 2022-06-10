using FastEndpoints;
using MediatR;
using SmartDealerships.Infrastructure.Commands;

namespace SmartDealerships.WebApi.Features.ShoppingCart.AddToCart;

public class AddToCartEndpoint : Endpoint<AddToCartRequest, AddToCartResponse>
{
    public IMediator mediator { get; set; }
    
    public IHttpContextAccessor _httpContextAccessor { get; set; }

    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("cart/add");
        Roles("user", "admin");
    }

    public override async Task HandleAsync(AddToCartRequest req, CancellationToken ct)
    {
        string authorizationHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
        
        if (string.IsNullOrEmpty(authorizationHeader))
        {
            await SendErrorsAsync(StatusCodes.Status401Unauthorized, ct);
        }
        
        string  token = authorizationHeader.Substring(7);
        
        var res = mediator.Send(new AddToCartCommand(token,
            req.ProductIdAndQty.Select(p => new CartItemMini(p.ProductId, p.ProductQty)).ToList()));

        if (res.Result.Any())
        {
            await SendOkAsync(new AddToCartResponse("success"), ct);
        }
        else
        {
            await SendNotFoundAsync(ct);
        }
    }
}