using MediatR;
using SmartDealerships.Infrastructure.DTO;

namespace SmartDealerships.Infrastructure.Queries;

public class GetUsersByNothing : IRequest<List<UserDTO>>
{
    
}