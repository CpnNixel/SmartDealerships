using MediatR;

namespace SmartDealerships.Infrastructure.Commands;

public class LogoutCommand : IRequest<bool>
{
    public LogoutCommand(int userId)
    {
        UserId = userId;
    }
    
    public  int  UserId { get; init; }

}