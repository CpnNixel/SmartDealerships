using MediatR;
using SmartDealerships.Infrastructure.DTO;

namespace SmartDealerships.Infrastructure.Queries;

public class GetAllUsersQuery : IRequest<List<UserDTO>>
{
    
}