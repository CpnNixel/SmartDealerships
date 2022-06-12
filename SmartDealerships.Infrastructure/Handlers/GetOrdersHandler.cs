using MediatR;
using SmartDealerships.DataAccess.Interfaces;
using SmartDealerships.Infrastructure.Queries;
using SmartDealerships.Infrastructure.Responses;

namespace SmartDealerships.Infrastructure.Handlers;

public class GetOrdersHandler : IRequestHandler<GetCompanyOrdersQuery, OrderListDto>
{
    private readonly IDealershipDbContext _dbContext;

    public GetOrdersHandler(IDealershipDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<OrderListDto> Handle(GetCompanyOrdersQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}