using FastEndpoints;
using MediatR;

namespace SmartDealerships.WebApi.Features.ShoppingCart.AddToCart;

public class AddToCartEndpoint : Endpoint<AddToCartRequest, AddToCartResponse>
{
    public IMediator mediator { get; set; }
    
    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("add-to-cart");
        Roles("user", "admin");
    }

    public override async Task HandleAsync(AddToCartRequest req, CancellationToken ct)
    {
        //items, create command
        //send command to mediator
        //get result
    }
}