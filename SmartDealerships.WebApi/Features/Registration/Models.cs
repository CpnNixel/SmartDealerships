using FastEndpoints;
using FluentValidation;
using SmartDealerships.WebApi.Features.Login;

namespace SmartDealerships.WebApi.Features.Registration;

public class RegistrationRequest
{
    public string? Email { get; set; }
    
    public string? FirstName { get; set; }
    
    public string? LastName { get; set; }

    public string? Password { get; set; }
    
    public string? Address { get; set; }
    
    public string? Telephone { get; set; }
}

public class RegistrationResponse : LoginResponse
{
}

public class RegisterValidator : Validator<RegistrationRequest>
{
    public RegisterValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("email address is required!")
            .EmailAddress()
            .Length(6, 40)
            .WithMessage("the format of your email address is wrong!");

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .Length(3, 50).WithMessage("{PropertyName} must be between 3 and 50 characters.")
            .NotEqual(x=>x.LastName)
            .WithMessage("{PropertyName} should not be equal to lLast name");;
        
        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .Length(3, 50).WithMessage("{PropertyName} must be between 3 and 50 characters.")
            .NotEqual(x=>x.FirstName)
            .WithMessage("{PropertyName} should not be equal to first name");
        
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .Length(6, 40)
            .NotEqual(x=>x.Telephone)
            .WithMessage("{PropertyName} should not be equal to other fields");
            
        
        RuleFor(x => x.Telephone)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .Length(6, 15)
            .NotEqual(x=>x.Email)
            .WithMessage("{PropertyName} should not be equal to email");;
        
    }
}