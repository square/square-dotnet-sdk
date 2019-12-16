using Square.Http.Request;

namespace Square.Utilities
{
    internal interface IAuthManager
    {
        HttpRequest Apply(HttpRequest httpRequest);
    }
}
