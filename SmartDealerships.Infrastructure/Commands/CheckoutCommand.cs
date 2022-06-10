using MediatR;

namespace SmartDealerships.Infrastructure.Commands;

public class CheckoutCommand : IRequest<string>
{
    public CheckoutCommand(string userToken)
    {
        UserToken = userToken;
    }

    public CheckoutCommand()
    {
    }
    
    public string UserToken { get; init; }
}