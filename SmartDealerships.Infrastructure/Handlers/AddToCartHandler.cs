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
            .Include(x => x.CartItems)
            .FirstOrDefaultAsync(s => s.Token == request.UserToken, ct);

        var products = _dbContext.Products.Select(x => x.Id == request.ProductId);

        if (session == null)
            throw new Exception("session is null");

        var item = Map(request.ProductId, request.ProductQty, session.Id);

        if (session.Id == item.ShoppingSessionId && session.CartItems.Any(i => i.ProductId == item.ProductId))
        {
            session.CartItems.First(i => i.ProductId == item.ProductId).Qty += item.Qty;
            session.Total += item.Price * item.Qty;
        }
        else
        {
            for (int i = 0; i < request.ProductQty; i++)
            {
                session.CartItems.Add(item);
                session.Total += item.Price;

            }
        }


        await _dbContext.SaveChangesAsync(ct);
        return "success";

    }

    private CartItem Map(int productId, int qty, int sessionId)
    {
        decimal price = _dbContext.Products.First(product => product.Id == productId).Price;

        return new CartItem
        {
            ShoppingSessionId = sessionId,
            ProductId = productId,
            Qty = qty,
            Price = price,
            CreatedAt = DateTime.Now.SetKindUtc(),
            ModifiedAt = DateTime.Now.SetKindUtc()
        };
    }
}