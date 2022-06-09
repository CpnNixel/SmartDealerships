namespace SmartDealerships.Infrastructure.Reponses;

public class ProductsDto
{
    public ProductsDto(List<ProductDto> products)
    {
        Products = products;
    }

    public List<ProductDto> Products { get; set; }

}

public record ProductDto(int Id, string Name, string Description, string Sku, decimal Price, string CategoryName, string CompanyName);