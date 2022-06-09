namespace SmartDealerships.Infrastructure.DTO;

public class ProductsDto
{
    public ProductsDto(List<ProductDto> products)
    {
        Products = products;
    }

    public List<ProductDto> Products { get; set; }
    // public int Id { get; set; }
    //
    // public string? Name { get; set; }
    //
    // public string? Description { get; set; }
    //
    // public string? Sku { get; set; }
    //
    // public decimal Price { get; set; }
    //
    // public string CategoryName { get; set; }
    //
    // public string CompanyName { get; set; }
}

public record ProductDto(int Id, string Name, string Description, string Sku, decimal Price, string CategoryName, string CompanyName);