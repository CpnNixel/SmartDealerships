using MediatR;
using SmartDealerships.Infrastructure.Responses;

namespace SmartDealerships.Infrastructure.Queries;

public class GetAllUsersQuery : IRequest<List<UserDto>>
{
    
}