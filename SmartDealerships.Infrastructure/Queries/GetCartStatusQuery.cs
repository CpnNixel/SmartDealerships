using MediatR;
using SmartDealerships.Infrastructure.Responses;

namespace SmartDealerships.Infrastructure.Queries;

public class GetCartStatusQuery : IRequest<CartStatusDto>
{
    public GetCartStatusQuery(string userToken)
    {
        UserToken = userToken;
    }

    public string UserToken { get; init; }
}