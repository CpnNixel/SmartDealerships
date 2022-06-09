using MediatR;
using SmartDealerships.Infrastructure.Reponses;

namespace SmartDealerships.Infrastructure.Queries;

public class LoginUserQuery : IRequest<LoginResponseDto>
{
    public LoginUserQuery(string email, string password)
    {
        Email = email;
        Password = password;
    }
    
    public string? Email { get; init; }
    
    public string? Password { get; init; }
}