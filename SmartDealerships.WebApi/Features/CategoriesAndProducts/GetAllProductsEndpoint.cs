using FastEndpoints;
using MediatR;
using SmartDealerships.Infrastructure.Queries;

namespace SmartDealerships.WebApi.Features.CategoriesAndProducts;

public class GetAllProductsEndpoint : EndpointWithoutRequest<CategoriesAndProductsResponse>
{
    public IMediator Mediator { get; set; }

    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("api/products/all");
        Roles("admin, user");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var products = Mediator.Send(new GetAllProductsQuery(), ct);

        if (products.Result.Any())
        {
            var res = products.Result.Select(p =>
                new ProductResponseDto(p.Id, p.Name, p.Description, p.Sku, p.Price, p.CategoryName, p.CompanyName));

            await SendOkAsync(new CategoriesAndProductsResponse(res.ToList(), "success", true), ct);
        }
        else
        {
            await SendNotFoundAsync(ct);
        }

    }
}