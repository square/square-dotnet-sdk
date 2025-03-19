using System.Collections.Generic;
using APIMatic.Core.Types.Sdk;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Square.Legacy.Http.Client;
using Square.Legacy.Http.Request;
using Square.Legacy.Http.Response;

namespace Square.Legacy.Exceptions
{
    /// <summary>
    /// This is the base class for all exceptions that represent an error response
    /// from the server.
    /// </summary>
    public class ApiException : CoreApiException<HttpRequest, HttpResponse, HttpContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException"/> class.
        /// </summary>
        /// <param name="reason"> The reason for throwing exception.</param>
        /// <param name="context"> The HTTP context that encapsulates request and response objects.</param>
        public ApiException(string reason, HttpContext context = null)
            : base(reason, context) { }

        protected override void SetupAdditionalProperties(string responseBody)
        {
            base.SetupAdditionalProperties(responseBody);
            JObject body = JObject.Parse(responseBody);

            if (body.ContainsKey("payment"))
            {
                this.Data = body.GetValue("payment").ToObject<Models.Payment>();
            }

            // Map Square v1 error to v2 errors
            if (body.ContainsKey("errors"))
            {
                this.Errors = body.GetValue("errors").ToObject<List<Models.Error>>();
                return;
            }

            var errorBuilder = new Models.Error.Builder(
                "V1_ERROR",
                body.GetValue("type")?.ToObject<string>()
            )
                .Detail(body.GetValue("message")?.ToString())
                .Field(body.GetValue("field")?.ToString());

            this.Errors = new List<Models.Error> { errorBuilder.Build() };
        }

        /// <summary>
        /// Gets or sets the list of errors.
        /// </summary>
        [JsonProperty("errors")]
        public List<Models.Error> Errors { get; private set; } = new List<Models.Error>();

        /// <summary>
        /// Gets or sets the data about the steps that completed successfully before
        /// an error was raised. This field is currently only populated for the PaymentsApi.CreatePayment
        /// endpoint.
        /// </summary>
        [JsonProperty("data")]
        public new object Data { get; private set; }
    }
}
