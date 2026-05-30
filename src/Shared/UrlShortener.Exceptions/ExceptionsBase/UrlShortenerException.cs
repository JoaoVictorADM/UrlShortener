using System.Net;

namespace UrlShortener.Exceptions.ExceptionsBase;

public abstract class UrlShortenerException : SystemException
{
    protected UrlShortenerException(string message) : base(message)
    {

    }

    public abstract IList<string> GetErrorMessages();
    public abstract HttpStatusCode GetStatusCode();
}
