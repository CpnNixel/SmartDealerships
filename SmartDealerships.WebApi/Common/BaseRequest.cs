namespace SmartDealerships.WebApi.Common;

public class BaseRequest
{
    public BaseRequest(string userToken)
    {
        UserToken = userToken;
    }

    public BaseRequest()
    {
    }

    public string UserToken { get; init; }
    
}