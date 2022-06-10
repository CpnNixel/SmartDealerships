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

public class LoginValidator : Validator<LoginRequest>
{
    public LoginValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("email address is required!")
            .EmailAddress()
            .Length(6, 40)
            .WithMessage("the format of your email address is wrong!");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .Length(6, 40);
        
        // WithMessage("{PropertyName} must be pass date.");

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