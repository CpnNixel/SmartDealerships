using MediatR;
using SmartDealerships.Infrastructure.DTO;

namespace SmartDealerships.Infrastructure.Commands;

public class RegisterCommand : IRequest<LoginResponseDTO>
{
    public RegisterCommand(string? email, string? firstName, string? lastName, string? password, string? address, string? telephone)
    {
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        Password = password;
        Address = address;
        Telephone = telephone;
    }
    
    public string? Email { get; init; }
    
    public string? FirstName { get; init; }
    
    public string? LastName { get; init; }

    public string? Password { get; init; }
    
    public string? Address { get; init; }
    
    public string? Telephone { get; init; }
}