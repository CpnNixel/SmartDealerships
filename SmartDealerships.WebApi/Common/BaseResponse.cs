namespace SmartDealerships.WebApi.Common;

public class BaseResponse
{
    public BaseResponse(string message)
    {
        Message = message;
    }
    
    public BaseResponse()
    {
    }
    
    public string Message { get; init; }
}