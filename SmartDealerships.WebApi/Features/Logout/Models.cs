namespace SmartDealerships.WebApi.Features.Logout;

public class LogoutRequest
{
    public LogoutRequest(string userToken)
    {
    }
    
    public LogoutRequest()
    {
    }
    
    public string UserToken { get; set; }
}

public class LogoutResponse
{
    public string Message { get; set; }
}