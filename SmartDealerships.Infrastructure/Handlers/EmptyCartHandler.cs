using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartDealerships.DataAccess.Extensions;
using SmartDealerships.DataAccess.Interfaces;
using SmartDealerships.DataAccess.Models;
using SmartDealerships.Infrastructure.Commands;

namespace SmartDealerships.Infrastructure.Handlers;

public class EmptyCartHandler : IRequestHandler<EmptyCartCommand, string>
{
    private readonly IDealershipDbContext _dbContext;

    public EmptyCartHandler(IDealershipDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<string> Handle(EmptyCartCommand request, CancellationToken ct)
    {
        var session = await _dbContext.ShoppingSessions
            .Include(s=>s.CartItems)
            .FirstOrDefaultAsync(s => s.Token == request.UserToken, ct);

        if (session == null) 
            throw new Exception("session is null");

        session.Total = 0;
        session.CartItems = new List<CartItem>();
        session.ModifiedAt = DateTime.Now.SetKindUtc();
        
        await _dbContext.SaveChangesAsync();
        
        return "success";
    }
}