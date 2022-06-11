namespace SmartDealerships.Infrastructure.Responses;

public class OrderListDto
{
    public int Id { get; set; }

    public decimal? Total { get; set; }

    public List<CartItemDto> Products { get; set; }

    public int SellingCompany { get; set; }
}