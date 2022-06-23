namespace SmartDealerships.WebApi.Features.ProductSearch
{
    public class ProductSearchRequest
    {
        public string SearchString { get; set; }

        public ProductSearchRequest(string searchString)
        {
            SearchString = searchString;
        }

        public ProductSearchRequest()
        {
        }
    }
}
