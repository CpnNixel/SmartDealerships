namespace SmartDealerships.Infrastructure.Interfaces;

public interface IHashService
{
    public string HashPassword(string password);
}