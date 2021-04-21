namespace Square.Http.Client
{
    using Square.Http.Request;
    using Square.Http.Response;

    /// <summary>
    /// Represents the contextual information of HTTP request and response.
    /// </summary>
    public sealed class HttpContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpContext"/> class.
        /// </summary>
        /// <param name="request">The http request in the current context.</param>
        /// <param name="response">The http response in the current context.</param>
        public HttpContext(HttpRequest request, HttpResponse response)
        {
            this.Request = request;
            this.Response = response;
        }

        /// <summary>
        /// Gets the http request in the current context.
        /// </summary>
        public HttpRequest Request { get; }

        /// <summary>
        /// Gets the http response in the current context.
        /// </summary>
        public HttpResponse Response { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $" Request = {this.Request}, " +
                $" Response = {this.Response}";
        }
    }
}
