namespace Square.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Square.Http.Client;
    using Square.Utilities;

    /// <summary>
    /// This is the base class for all exceptions that represent an error response
    /// from the server.
    /// </summary>
    [JsonObject]
    public class ApiException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException"/> class.
        /// </summary>
        /// <param name="reason"> The reason for throwing exception.</param>
        /// <param name="context"> The HTTP context that encapsulates request and response objects.</param>
        public ApiException(string reason, HttpContext context = null)
            : base(reason)
        {
            this.HttpContext = context;

            // If a derived exception class is used, then perform deserialization of response body.
            if ((context == null) || (context.Response == null)
                || (context.Response.RawBody == null)
                || (!context.Response.RawBody.CanRead))
                {
                    this.Errors = new List<Models.Error>();
                    return;
                }

            using (var reader = new StreamReader(context.Response.RawBody))
            {
                string responseBody = reader.ReadToEnd();
                if (!string.IsNullOrWhiteSpace(responseBody))
                {
                    try
                    {
                        JObject body = JObject.Parse(responseBody);

                        if (!this.GetType().Name.Equals("ApiException", StringComparison.OrdinalIgnoreCase))
                        {
                            JsonConvert.PopulateObject(responseBody, this);
                        }

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
                            body.GetValue("type")?.ToObject<string>())
                            .Detail(body.GetValue("message")?.ToString())
                            .Field(body.GetValue("field")?.ToString());

                        this.Errors = new List<Models.Error> { errorBuilder.Build() };
                    }
                    catch (JsonReaderException)
                    {
                        // Ignore deserialization and IO issues to prevent exception being thrown when this exception
                        // instance is being constructed.
                    }
                }
            }
        }

        /// <summary>
        /// Gets the HTTP response code from the API request.
        /// </summary>
        [JsonIgnore]
        public int ResponseCode
        {
            get { return this.HttpContext != null ? this.HttpContext.Response.StatusCode : -1; }
        }

        /// <summary>
        /// Gets or sets the HttpContext for the request and response.
        /// </summary>
        [JsonIgnore]
        public HttpContext HttpContext { get; internal set; }

        /// <summary>
        /// Gets or sets the list of errors.
        /// </summary>
        [JsonProperty("errors")]
        public List<Models.Error> Errors { get; internal set; }

        /// <summary>
        /// Gets or sets the data about the steps that completed successfully before
        /// an error was raised. This field is currently only populated for the PaymentsApi.CreatePayment
        /// endpoint.
        /// </summary>
        [JsonProperty("data")]
        public new object Data { get; internal set; }
    }
}