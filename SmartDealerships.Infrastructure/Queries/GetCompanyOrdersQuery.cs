using LanguageExt.Common;
using MediatR;
using SmartDealerships.Infrastructure.Responses;

namespace SmartDealerships.Infrastructure.Queries;

public class GetCompanyOrdersQuery : IRequest<Result<List<OrderListDto>>>
{
    public string UserToken { get; set; }
}