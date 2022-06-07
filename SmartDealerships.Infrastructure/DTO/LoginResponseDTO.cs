namespace SmartDealerships.Infrastructure.DTO;

public class LoginResponseDTO
{
    public bool IsSuccessful { get; set; } = false;
    
    public string? Token { get; set; }
}