using APIMatic.Core.Types.Sdk;
using APIMatic.Core.Utilities;
using Square.Legacy.Exceptions;
using Square.Legacy.Http.Client;
using Square.Legacy.Http.Request;
using Square.Legacy.Http.Response;

namespace Square.Legacy.Utilities
{
    internal class CompatibilityFactory
        : ICompatibilityFactory<HttpRequest, HttpResponse, HttpContext, ApiException>
    {
        public ApiException CreateApiException(
            string reason,
            CoreContext<CoreRequest, CoreResponse> context
        ) => new ApiException(reason, CreateHttpContext(context.Request, context.Response));

        public HttpContext CreateHttpContext(CoreRequest request, CoreResponse response) =>
            new HttpContext(CreateHttpRequest(request), CreateHttpResponse(response));

        public HttpRequest CreateHttpRequest(CoreRequest request) =>
            new HttpRequest(
                request.HttpMethod,
                request.QueryUrl,
                request.Headers,
                request.Body,
                request.FormParameters,
                request.Username,
                request.Password,
                request.QueryParameters
            );

        public HttpResponse CreateHttpResponse(CoreResponse response)
        {
            if (response.Body != null)
            {
                return new HttpStringResponse(
                    response.StatusCode,
                    response.Headers,
                    response.RawBody,
                    response.Body
                );
            }
            return new HttpResponse(response.StatusCode, response.Headers, response.RawBody);
        }
    }
}
