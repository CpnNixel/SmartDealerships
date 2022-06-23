namespace SmartDealerships.WebApi.Features.UploadProduct;

public class ProductUploadRequest
{
    public ProductUploadRequest()
    {
    }


    public ProductUploadRequest(string token, string name, decimal? price, string sku, string category, string imageLink)
    {
        Token = token;
        ProductName = name;
        ProductPrice = price;
        Sku = sku;
        CategoryName = category;
        ImageLink = imageLink;
    }
    public string Token { get; set; }

    public string ProductName { get; set; }

    public decimal? ProductPrice { get; set; }

    public string Sku { get; set; }

    public string CategoryName { get; set; }

    public string ImageLink { get; set; }

}


public class ProductUploadedResponse
{
    public ProductUploadedResponse(string message, bool isSuccessful)
    {
        Message = message;
        IsSuccessful = isSuccessful;
    }

    public ProductUploadedResponse()
    {
    }
    public string Message { get; set; }

    public bool IsSuccessful { get; set; }
}
