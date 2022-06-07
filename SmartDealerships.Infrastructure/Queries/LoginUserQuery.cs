using MediatR;
using SmartDealerships.Infrastructure.DTO;

namespace SmartDealerships.Infrastructure.Queries;

public class LoginUserQuery : IRequest<LoginResponseDTO>
{
    public string? Email { get; set; }
    
    public string? Password { get; set; }
}