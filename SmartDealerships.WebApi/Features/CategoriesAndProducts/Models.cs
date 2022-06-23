namespace SmartDealerships.WebApi.Features.CategoriesAndProducts;

public class CategoriesAndProductsResponse
{
    public CategoriesAndProductsResponse()
    {
    }

    public CategoriesAndProductsResponse(List<ProductResponseDto> products, string message, bool isSuccessful = false)
    {
        Products = products;
        Message = message;
        IsSuccessful = isSuccessful;
    }

    public CategoriesAndProductsResponse(string message, bool isSuccessful = false)
    {
        Message = message;
        IsSuccessful = isSuccessful;
    }

    public List<ProductResponseDto> Products { get; set; }

    public string Message { get; set; }

    public bool IsSuccessful { get; set; }

}

public class ProductResponseDto
{

    public ProductResponseDto(int Id, string Name, string Description, string Sku, decimal Price, string CategoryName, string CompanyName)
    {
        this.Id = Id;
        this.Name = Name;
        this.Description = Description;
        this.Sku = Sku;
        this.Price = Price;
        this.CategoryName = CategoryName;
        this.CompanyName = CompanyName;
    }

    public ProductResponseDto()
    {
    }

    public int Id { get; }
    public string Name { get; }
    public string Description { get; }
    public string Sku { get; }
    public decimal Price { get; }
    public string CategoryName { get; }
    public string CompanyName { get; }
}

public class SpecificItemRequest
{
    public int ItemId { get; set; }

    public SpecificItemRequest(int itemId)
    {
        ItemId = itemId;
    }

    public SpecificItemRequest()
    {
    }
}