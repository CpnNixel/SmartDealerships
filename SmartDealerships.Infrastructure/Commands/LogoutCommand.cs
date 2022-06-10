using MediatR;

namespace SmartDealerships.Infrastructure.Commands;

public class LogoutCommand : IRequest<bool>
{
    public LogoutCommand(string userToken)
    {
        UserToken = userToken;
    }
    
    public  string UserToken { get; init; }

}