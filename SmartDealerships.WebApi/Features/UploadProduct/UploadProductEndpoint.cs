using FastEndpoints;
using MediatR;
using SmartDealerships.Infrastructure.Commands;

namespace SmartDealerships.WebApi.Features.UploadProduct
{
    public class UploadProductEndpoint : Endpoint<ProductUploadRequest, ProductUploadedResponse>
    {
        public IMediator Mediator { get; set; }

        public IHttpContextAccessor _httpContextAccessor { get; set; }


        public override void Configure()
        {
            Verbs(Http.POST);
            Routes("api/products/new");
            Roles("admin", "user");
        }

        public override async Task HandleAsync(ProductUploadRequest req, CancellationToken ct)
        {
            string authorizationHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];

            if (string.IsNullOrEmpty(authorizationHeader))
            {
                await SendErrorsAsync(StatusCodes.Status401Unauthorized, ct);
            }

            string token = authorizationHeader.Substring(7);

            var res = Mediator.Send(new UploadProductCommand(token, req.ProductName, req.ProductPrice, req.Sku, req.CategoryName, req.ImageLink));

            //if (!string.IsNullOrEmpty(res.Result))
            //{
            //    await SendOkAsync(new CheckoutResponse("success"), ct);
            //}
            //else
            //{
            //    await SendErrorsAsync(404, ct);
            //}
        }
    }
}
