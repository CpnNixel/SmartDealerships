using MediatR;
using SmartDealerships.Infrastructure.DTO;

namespace SmartDealerships.Infrastructure.Queries;

public class LoginUserQuery : IRequest<LoginResponseDTO>
{
    public LoginUserQuery(string email, string password)
    {
        Email = email;
        Password = password;
    }
    
    public string? Email { get; init; }
    
    public string? Password { get; init; }
}