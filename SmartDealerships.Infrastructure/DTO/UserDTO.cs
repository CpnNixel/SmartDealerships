namespace SmartDealerships.Infrastructure.DTO;

public class UserDTO
{
    public int Id { get; set; }
    
    public string? FirstName { get; set; }

    public string? RoleName { get; set; }
    
    public string? LastName { get; set; }

    public string? PasswordHash { get; set; }
    
    public string? Address { get; set; }
    
    public string? Telephone { get; set; }
    
    public DateTime CreatedAt {get; set; }
    
    public DateTime ModifiedAt {get; set; }
}