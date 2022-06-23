using FastEndpoints;
using MediatR;
using SmartDealerships.Infrastructure.Queries;
using SmartDealerships.WebApi.Features.CategoriesAndProducts;

namespace SmartDealerships.WebApi.Features.ProductSearch;

public class ProductSearchEndpoint : Endpoint<ProductSearchRequest, CategoriesAndProductsResponse>
{
    public IMediator Mediator { get; set; }

    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("api/products/search/{SearchString}");
        Roles("admin, user");
    }

    public override async Task HandleAsync(ProductSearchRequest req, CancellationToken ct)
    {
        var response = Mediator.Send(new FindProductByNameQuery(req.SearchString), ct);

        if (response != null)
        {
            await response.Result.Match(
                async res =>
                {
                    await SendOkAsync(new CategoriesAndProductsResponse(res.Select(p =>
                    new ProductResponseDto(p.Id, p.Name, p.Description, p.Sku, p.Price, p.CategoryName, p.CompanyName))
                        .ToList(), "success", true), ct);
                },
                async ex =>
                {
                    await SendOkAsync(new CategoriesAndProductsResponse("No products with entered name were found", false), ct);

                });
        }
        else
        {
            await SendNotFoundAsync(ct);
        }
    }

}
