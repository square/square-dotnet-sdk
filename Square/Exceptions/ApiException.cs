using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Square.Utilities;
using Square.Http.Client;

namespace Square.Exceptions
{
    /// <summary>
    /// This is the base class for all exceptions that represent an error response 
    /// from the server.
    /// </summary>
    [JsonObject]
    public class ApiException : Exception
    {
        /// <summary>
        /// The HTTP response code from the API request.
        /// </summary>
        [JsonIgnore]
        public int ResponseCode
        {
            get { return this.HttpContext != null ? HttpContext.Response.StatusCode : -1; }
        }

        /// <summary>
        /// HttpContext stores the request and response.
        /// </summary>
        [JsonIgnore]
        public HttpContext HttpContext { get; internal set; }

        /// <summary>
        /// Stores the list of errors.
        /// </summary>
        [JsonProperty("errors")]
        public List<Models.Error> Errors { get; internal set; }

        /// <summary>
        /// Returns data about the steps that completed successfully before an error 
        /// was raised. This field is currently only populated for the PaymentsApi.CreatePayment 
        /// endpoint.
        /// </summary>
        [JsonProperty("data")]
        public new object Data { get; internal set; }

        /// <summary>
        /// Initializes a new ApiException object with the specified parameters.
        /// </summary>
        /// <param name="reason"> The reason for throwing exception </param>
        /// <param name="context"> The HTTP context that encapsulates request and response objects </param>
        public ApiException(string reason, HttpContext context) : base(reason)
        {
            this.HttpContext = context;

            //if a derived exception class is used, then perform deserialization of response body
            if ((context == null) || (context.Response == null)
                || (context.Response.RawBody == null)
                || (!context.Response.RawBody.CanRead))
                {
                    Errors = new List<Models.Error>();
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

                        if(!this.GetType().Name.Equals("ApiException", StringComparison.OrdinalIgnoreCase))
                        {
                            JsonConvert.PopulateObject(responseBody, this);
                        }

                        if (body.ContainsKey("payment"))
                        {
                            Data = body.GetValue("payment").ToObject<Models.Payment>();
                        }

                        // Map Square v1 error to v2 errors
                        if (body.ContainsKey("errors"))
                        {
                            Errors = body.GetValue("errors").ToObject<List<Models.Error>>();
                            return;
                        }

                        var errorBuilder = new Models.Error.Builder("V1_ERROR",
                            body.GetValue("type")?.ToObject<string>())
                            .Detail(body.GetValue("message")?.ToString())
                            .Field(body.GetValue("field")?.ToString());

                        Errors = new List<Models.Error> { errorBuilder.Build() };
                    }
                    catch (JsonReaderException)
                    {
                        // Ignore deserialization and IO issues to prevent exception being thrown when this exception
                        // instance is being constructed.
                    }
                }
            }
        }
    }
}