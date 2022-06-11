using MediatR;
using SmartDealerships.Infrastructure.Responses;

namespace SmartDealerships.Infrastructure.Queries;

public class GetCompanyOrdersQuery : IRequest<OrderListDto>
{
    public string UserToken { get; set; }
}