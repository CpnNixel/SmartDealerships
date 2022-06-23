using MediatR;
using SmartDealerships.Infrastructure.Responses;

namespace SmartDealerships.Infrastructure.Queries
{
    public class GetUserByTokenQuery : IRequest<UserDto>
    {
        public GetUserByTokenQuery(string token)
        {
            Token = token;
        }

        public string Token { get; set; }
    }
}
