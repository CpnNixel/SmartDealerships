using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartDealerships.DataAccess.Interfaces;
using SmartDealerships.DataAccess.Models;
using SmartDealerships.Infrastructure.Queries;
using SmartDealerships.Infrastructure.Responses;

namespace SmartDealerships.Infrastructure.Handlers;

public class GetCartStatusHandler : IRequestHandler<GetCartStatusQuery, CartStatusDto>
{
    private readonly IDealershipDbContext _dbContext;

    public GetCartStatusHandler(IDealershipDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CartStatusDto> Handle(GetCartStatusQuery request, CancellationToken ct)
    {
        var session = await _dbContext.ShoppingSessions
            .Include(s => s.CartItems)
            .ThenInclude(i => i.Product)
            .ThenInclude(p=>p.Category)
            .FirstOrDefaultAsync(s => s.Token == request.UserToken, ct);

        if (session == null)
            throw new Exception("session is null");

        if (session.CartItems.Count < 1)
        {
            return new CartStatusDto {Total = 0};
        }

        var cart = new CartStatusDto();
        try
        {
            cart.Total = session.Total;
            cart.Items = session.CartItems.ToList().Select(Map);

        }
        catch (Exception ex)
        {
            throw;
        }

        return cart;
    }

    private CartItemDto Map(CartItem item)
    {
        return new CartItemDto
        {
            Id = item.Id,
            Name = item.Product.Name ?? "no name",
            Quantity = item.Qty,
            Price = item.Price,
            SKU = item.Product.Sku ?? "no sku",
            Description = item.Product.Description ?? "no description",
            CategoryName = item.Product.Category.Name ?? "no category"
        };
    }
}