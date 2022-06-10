using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartDealerships.DataAccess.Interfaces;
using SmartDealerships.DataAccess.Models;
using SmartDealerships.Infrastructure.Commands;

namespace SmartDealerships.Infrastructure.Handlers;

public class LogoutHandler : IRequestHandler<LogoutCommand, bool>
{
    private readonly IDealershipDbContext _dbContext;

    public LogoutHandler(IDealershipDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> Handle(LogoutCommand req, CancellationToken ct)
    {
        var sessions = _dbContext.ShoppingSessions
            .Where(u => u.Token == req.UserToken)
            .Include(s => s.CartItems);
        
        _dbContext.CartItems.RemoveRange(sessions.SelectMany(s=>s.CartItems));
        
        foreach (var shoppingSession in sessions)
        {
            shoppingSession.Total = 0;
            shoppingSession.CartItems = new List<CartItem>();
        }

        await _dbContext.SaveChangesAsync(ct);
        return true;
    }
}