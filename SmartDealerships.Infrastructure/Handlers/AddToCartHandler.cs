using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartDealerships.DataAccess.Extensions;
using SmartDealerships.DataAccess.Interfaces;
using SmartDealerships.DataAccess.Models;
using SmartDealerships.Infrastructure.Commands;

namespace SmartDealerships.Infrastructure.Handlers;

public class AddToCartHandler : IRequestHandler<AddToCartCommand, string>
{
    private readonly IDealershipDbContext _dbContext;

    public AddToCartHandler(IDealershipDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<string> Handle(AddToCartCommand request, CancellationToken ct)
    {
        var session = await _dbContext.ShoppingSessions
            .FirstOrDefaultAsync(s => s.Token == request.UserToken, ct);

        if (session == null) 
            throw new Exception("session is null");
        
        foreach (var cartItemDto in request.CartItems)
        {
            var item = Map(cartItemDto, session.Id);
            
            for (int i = 0; i < cartItemDto.Quantity; i++)
            {
                session.CartItems.Add(item);
                session.Total += item.Price;
            }
        }
        
        await _dbContext.SaveChangesAsync(ct);
        return "success";

    }

    private CartItem Map(CartItemMini item, int sessionId)
    {
        decimal price = _dbContext.Products.First(product => product.Id == item.ProductId).Price;
        
        return new CartItem
        {
            ShoppingSessionId = sessionId,
            ProductId = item.ProductId,
            Qty = item.Quantity,
            Price = price,
            CreatedAt = DateTime.Now.SetKindUtc(),
            ModifiedAt = DateTime.Now.SetKindUtc()
        };
    }
}