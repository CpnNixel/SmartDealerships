namespace SmartDealerships.Infrastructure.Responses;

public class OrderListDto
{
    public int Id { get; set; }

    public decimal? Total { get; set; }

    public List<CartItemDto> Products { get; set; }

    public string DateCreated { get; set; }

    public int SellingCompany { get; set; }
}


public class OrderDto
{
    public int Id { get; set; }

    public OrderDto(int id, decimal total, int userId, int sellingCompanyId)
    {
        Id = id;
        Total = total;
        UserId = userId;
        SellingCompany = sellingCompanyId;
    }

    public decimal Total { get; set; }

    public int UserId { get; set; }

    public List<CartItemDto> Products { get; set; }

    public int SellingCompany { get; set; }
}