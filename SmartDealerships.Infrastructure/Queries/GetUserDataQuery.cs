using MediatR;
using SmartDealerships.Infrastructure.Responses;

namespace SmartDealerships.Infrastructure.Queries
{
    public class GetUserDataQuery : IRequest<UserDto>
    {
        public string Token { get; set; }

        public GetUserDataQuery(string token)
        {
            Token = token;
        }
    }
}
