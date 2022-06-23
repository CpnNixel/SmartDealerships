using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartDealerships.DataAccess.Interfaces;
using SmartDealerships.DataAccess.Models;
using SmartDealerships.Infrastructure.Queries;
using SmartDealerships.Infrastructure.Responses;

namespace SmartDealerships.Infrastructure.Handlers;

public class GetOrdersHandler : IRequestHandler<GetCompanyOrdersQuery, Result<List<OrderListDto>>>
{
    private readonly IDealershipDbContext _dbContext;

    public GetOrdersHandler(IDealershipDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<List<OrderListDto>>> Handle(GetCompanyOrdersQuery request, CancellationToken cancellationToken)
    {
        var userId = await _dbContext.ShoppingSessions
            .FirstOrDefaultAsync(x => x.Token == request.UserToken);

        var orders = _dbContext.OrderDetails
            .Include(o => o.Products)
            .ThenInclude(p => p.Category)
            .Where(x => x.UserId == userId.UserId);

        if (orders == null)
            return new Result<List<OrderListDto>>(new NullReferenceException("no orders were found"));

        var res = orders.Select(o => new OrderListDto
        {
            Total = o.Total,
            Products = Map(o.Products).ToList(),
            Id = o.Id,
            DateCreated = o.CreatedAt.ToString("MM/dd/yyyy hh:mm tt")
        });

        return new Result<List<OrderListDto>>(res.ToList());
    }

    private static IEnumerable<CartItemDto> Map(ICollection<Product> items)
    {

        foreach (var item in items)
        {
            yield return new CartItemDto
            {
                Id = item.Id,
                Name = item.Name ?? "no name",
                ///////////////
                Quantity = 3,
                Price = item.Price,
                SKU = item.Sku ?? "no sku",
                Description = item.Description ?? "no description",
                CategoryName = item.Category.Name ?? "no category"
            };
        }
    }
}