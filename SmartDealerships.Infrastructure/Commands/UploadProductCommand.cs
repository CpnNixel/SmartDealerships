using LanguageExt.Common;
using MediatR;

namespace SmartDealerships.Infrastructure.Commands
{
    public class UploadProductCommand : IRequest<Result<string>>
    {
        public UploadProductCommand(string token, string productName, decimal? productPrice, string sku, string categoryName, string imageLink)
        {
            Token = token;
            ProductName = productName;
            ProductPrice = productPrice;
            Sku = sku;
            CategoryName = categoryName;
            ImageLink = imageLink;
        }
        public string Token { get; set; }

        public string ProductName { get; set; }

        public decimal? ProductPrice { get; set; }

        public string Sku { get; set; }

        public string CategoryName { get; set; }

        public string ImageLink { get; set; }
    }
}
