using FastEndpoints;
using MediatR;

namespace SmartDealerships.WebApi.Features.CategoriesAndProducts;

public class GetCategoriesAndProductsEndpoint : EndpointWithoutRequest<CategoriesAndProductsResponse>
{
    public IMediator Mediator { get; set; }
    
    public override void Configure()
    {
        base.Configure();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var res = Mediator.Send(new ());
        
        
    }
}