using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartDealerships.DataAccess.Interfaces;
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
        
        foreach (var userItem in _dbContext.CartItems
                     .Include(x => x.ShoppingSession)
                     .Where(i => i.ShoppingSession.Token == req.UserToken))
        {
            userItem.ShoppingSessionId = 0;
            userItem.ShoppingSession = null;
        }
        
        var sessions = _dbContext.ShoppingSessions
            .Where(u => u.Token == req.UserToken);
        
        _dbContext.ShoppingSessions.RemoveRange(sessions);
        
        await _dbContext.SaveChangesAsync(ct);
        return true;
    }
}