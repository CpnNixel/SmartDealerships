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
        _dbContext.Users.ToList()
            .FirstOrDefault(u => u.Id == req.UserId)!
            .ShoppingSession = null;
        
        var sessions = _dbContext.ShoppingSessions
            .Where(u => u.UserId == req.UserId);
        
        _dbContext.ShoppingSessions.RemoveRange(sessions);
        
        // _dbContext.ShoppingSessions.RemoveRange(sessions);

        await _dbContext.SaveChangesAsync(ct);
        return true;
    }
}