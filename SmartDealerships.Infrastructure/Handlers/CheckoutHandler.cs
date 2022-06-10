using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartDealerships.DataAccess.Extensions;
using SmartDealerships.DataAccess.Interfaces;
using SmartDealerships.DataAccess.Models;
using SmartDealerships.Infrastructure.Commands;

namespace SmartDealerships.Infrastructure.Handlers;

public class CheckoutHandler : IRequestHandler<CheckoutCommand, string>
{
    private readonly IDealershipDbContext _dbContext;
    private readonly IMediator _mediator;

    public CheckoutHandler(IDealershipDbContext dbContext, IMediator mediator)
    {
        _dbContext = dbContext;
        _mediator = mediator;
    }


    public async Task<string> Handle(CheckoutCommand request, CancellationToken ct)
    {
        var session = await _dbContext.ShoppingSessions
            .Include(s=>s.CartItems)
            .ThenInclude(i=>i.Product)
            .FirstOrDefaultAsync(s => s.Token == request.UserToken, ct);

        if (session == null) 
            throw new Exception("session is null");

        _dbContext.OrderDetails.Add(new OrderDetails
        {
            UserId = session.UserId,
            Products = session.CartItems.Select(x => x.Product).ToList(),
            Total = session.Total,
            CreatedAt = DateTime.Now.SetKindUtc(),
            ModifiedAt = DateTime.Now.SetKindUtc()
        });

        await _dbContext.SaveChangesAsync(ct);
        
        await _mediator.Send(new EmptyCartCommand(request.UserToken), ct);
        
        return "success";
    }
}