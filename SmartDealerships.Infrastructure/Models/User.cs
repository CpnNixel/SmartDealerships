using System.ComponentModel.DataAnnotations;

namespace SmartDealerships.Infrastructure.Models;

public class User
{
    public int Id { get; set; }
    
    [Required]
    public string? FirstName { get; set; }
    
    public string? LastName { get; set; }

    public string? Password { get; set; }
    
    public string? Address { get; set; }
    
    [MaxLength(9)]  
    public string? Telephone { get; set; }
    
    public DateTime CreatedAt {get; set; }
    
    public DateTime ModifiedAt {get; set; }
}