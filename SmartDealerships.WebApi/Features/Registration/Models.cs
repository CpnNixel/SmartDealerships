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