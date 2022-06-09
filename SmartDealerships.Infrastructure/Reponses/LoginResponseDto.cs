namespace SmartDealerships.Infrastructure.Reponses;

public class LoginResponseDto
{
    public bool IsSuccessful { get; set; } = false;
    
    public string? Token { get; set; }
}