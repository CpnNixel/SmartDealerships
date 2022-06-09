namespace SmartDealerships.WebApi.Features.CategoriesAndProducts;

public class CategoriesAndProductsResponse
{
    public CategoriesAndProductsResponse()
    {
    }
    
    public CategoriesAndProductsResponse(List<ProductResponseDto> products)
    {
        Products = products;
    }

    public List<ProductResponseDto> Products { get; set; }

}

public record ProductResponseDto(int Id, string Name, string Description, string Sku, decimal Price, string CategoryName, string CompanyName);