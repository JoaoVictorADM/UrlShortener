namespace CARL.Communication.Responses;

public class ResponseErrorJson
{
    public IList<string> ErrorMessages { get; private set; }
    public bool TokenIsExpired { get; set; }

    public ResponseErrorJson(IList<string> errorMessages)
    {
        ErrorMessages = errorMessages;
    }

    public ResponseErrorJson(string errorMessage)
    {
        ErrorMessages = new List<string> { 
            errorMessage 
        };
    }
}
