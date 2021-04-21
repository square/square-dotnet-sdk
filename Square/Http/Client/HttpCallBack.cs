namespace Square.Http.Client
{
    using Square.Http.Request;
    using Square.Http.Response;

    /// <summary>
    /// HttpCallBack.
    /// </summary>
    internal sealed class HttpCallBack
    {
        /// <summary>
        /// Gets http request.
        /// </summary>
        public HttpRequest Request { get; private set; }

        /// <summary>
        /// Gets http response.
        /// </summary>
        public HttpResponse Response { get; private set; }

        /// <summary>
        /// BeforeHttpRequestEventHandler.
        /// </summary>
        /// <param name="source">Http Client.</param>
        /// <param name="request">Http Request.</param>
        public void OnBeforeHttpRequestEventHandler(IHttpClient source, HttpRequest request)
        {
            this.Request = request;
        }

        /// <summary>
        /// AfterHttpResponseEventHandler.
        /// </summary>
        /// <param name="source">Http Client.</param>
        /// <param name="response">Http Response.</param>
        public void OnAfterHttpResponseEventHandler(IHttpClient source, HttpResponse response)
        {
            this.Response = response;
        }
    }
}