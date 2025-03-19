using APIMatic.Core.Types;
using APIMatic.Core.Types.Sdk;
using Square.Legacy.Http.Request;
using Square.Legacy.Http.Response;
using Square.Legacy.Utilities;

namespace Square.Legacy.Http.Client
{
    /// <summary>
    /// To use for the capturing of the outgoing HTTP request and incoming Http response.
    /// </summary>
    public class HttpCallback : HttpCallBack
    {
        private readonly CompatibilityFactory _compatibilityFactory = new CompatibilityFactory();

        /// <summary>
        /// The Http Request that was sent in the API Call.
        /// </summary>
        public new HttpRequest Request => _compatibilityFactory.CreateHttpRequest(base.Request);

        /// <summary>
        /// The Http Response that was received in the API Call.
        /// </summary>
        public new HttpResponse Response => _compatibilityFactory.CreateHttpResponse(base.Response);

        /// <summary>
        /// The overridden method to execute the callback handling provided in <see cref="OnBeforeRequest"/>.
        /// </summary>
        /// <param name="request">The Http Request.</param>
        public override void OnBeforeHttpRequestEventHandler(CoreRequest request)
        {
            base.OnBeforeHttpRequestEventHandler(request);
            OnBeforeRequest(_compatibilityFactory.CreateHttpRequest(request));
        }

        /// <summary>
        /// The overridden method to execute the callback handling provided in <see cref="OnBeforeRequest"/>.
        /// </summary>
        /// <param name="response">The Http Response.</param>
        public override void OnAfterHttpResponseEventHandler(CoreResponse response)
        {
            base.OnAfterHttpResponseEventHandler(response);
            OnAfterResponse(_compatibilityFactory.CreateHttpResponse(base.Response));
        }

        /// <summary>
        /// Callback to execute before sending the API Request.
        /// </summary>
        /// <param name="request"> The request being sent.</param>
        public virtual void OnBeforeRequest(HttpRequest request) { }

        /// <summary>
        /// Callback to execute after receiving the API Response.
        /// </summary>
        /// <param name="request"> The response being received.</param>
        public virtual void OnAfterResponse(HttpResponse request) { }
    }
}
