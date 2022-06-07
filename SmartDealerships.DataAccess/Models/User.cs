using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDealerships.DataAccess.Models;

public class User
{
    public int Id { get; set; }
    
    [Required]
    public string? Email { get; set; }
    
    [Required]
    public string? FirstName { get; set; }
    
    public string? LastName { get; set; }
    
    public int RoleId { get; set; }

    public Role? Role { get; set; }
    
    public int? ShoppingSessionId { get; set; }

    [ForeignKey("ShoppingSessionId")]
    public ShoppingSession? ShoppingSession { get; set; }    
    
    [Required]
    public string? PasswordHash { get; set; }
    
    public string? Address { get; set; }
    
    [MaxLength(13)]  
    public string? Telephone { get; set; }
    
    public DateTime CreatedAt {get; set; }
    
    public DateTime ModifiedAt {get; set; }
    
    public virtual ICollection<Company> Companies { get; set; }
}