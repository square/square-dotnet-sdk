using Square.Http.Request;
using System.Threading.Tasks;

namespace Square.Authentication
{
    internal interface IAuthManager
    {
        HttpRequest Apply(HttpRequest httpRequest);

        Task<HttpRequest> ApplyAsync(HttpRequest httpRequest);
    }
}
