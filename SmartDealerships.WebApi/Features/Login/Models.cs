using FastEndpoints;
using FluentValidation;

namespace SmartDealerships.WebApi.Features.Login;

public class LoginRequest
{
    public string Email { get; set; }
        
    public string Password { get; set; }
}

public class LoginResponse
{
    public string? Token { get; set; }
}

public class Validator : Validator<LoginRequest>
{
    public Validator()
    {
        // RuleFor(x => x.FirstName)
        //     .NotEmpty().WithMessage("{PropertyName} is required.")
        //     .Length(3, 50).WithMessage("{PropertyName} must be between 3 and 50 characters.");
        //
        // RuleFor(x => x.LastName)
        //     .NotEmpty().WithMessage("{PropertyName} is required.")
        //     .Length(3, 50).WithMessage("{PropertyName} must be between 3 and 50 characters.");
        //
        // RuleFor(x => x.MainCategory)
        //     .NotEmpty().WithMessage("{PropertyName} is required.")
        //     .Length(3, 50).WithMessage("{PropertyName} must be between 3 and 50 characters.");
        //
        // RuleFor(x => x.DateOfBirth)
        //     .NotEmpty().WithMessage("{PropertyName} is required.")
        //     .Must(date => date < DateTimeOffset.Now).WithMessage("{PropertyName} must be pass date.");
    }
}