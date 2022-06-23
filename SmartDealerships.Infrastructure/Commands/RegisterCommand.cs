using MediatR;
using SmartDealerships.Infrastructure.Responses;

namespace SmartDealerships.Infrastructure.Commands;

public class RegisterCommand : IRequest<LoginResponseDto>
{
    public RegisterCommand(string? email, string? firstName, string? lastName, string? password, string? telephone)
    {
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        Password = password;
        Telephone = telephone;
    }

    public string? Email { get; init; }

    public string? FirstName { get; init; }

    public string? LastName { get; init; }

    public string? Password { get; init; }

    public string? Telephone { get; init; }
}