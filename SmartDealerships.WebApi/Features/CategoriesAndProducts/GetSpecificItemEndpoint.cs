using FastEndpoints;
using MediatR;
using SmartDealerships.Infrastructure.Queries;

namespace SmartDealerships.WebApi.Features.CategoriesAndProducts
{
    public class GetSpecificItemEndpoint : Endpoint<SpecificItemRequest, ProductResponseDto>
    {
        public IMediator Mediator { get; set; }

        public override void Configure()
        {
            Verbs(Http.GET);
            Routes("api/products/{itemId}");
            Roles("admin, user");
        }

        public override async Task HandleAsync(SpecificItemRequest req, CancellationToken ct)
        {
            var products = Mediator.Send(new GetAllProductsQuery(), ct);

            if (products.Result.Any() && products.Result.FirstOrDefault(p => p.Id == req.ItemId) != null)
            {
                var p = products.Result.FirstOrDefault(p => p.Id == req.ItemId);

                await SendOkAsync(new ProductResponseDto(p.Id, p.Name, p.Description, p.Sku, p.Price, p.CategoryName, p.CompanyName), ct);
            }
            else
            {
                await SendNotFoundAsync(ct);
            }
        }
    }
}