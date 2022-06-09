using MediatR;
using SmartDealerships.Infrastructure.Reponses;

namespace SmartDealerships.Infrastructure.Queries;

public class GetAllUsersQuery : IRequest<List<UserDto>>
{
    
}