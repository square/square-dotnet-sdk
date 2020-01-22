using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square.Http.Client;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class CreateMobileAuthorizationCodeResponse 
    {
        public CreateMobileAuthorizationCodeResponse(string authorizationCode = null,
            string expiresAt = null,
            Models.Error error = null)
        {
            AuthorizationCode = authorizationCode;
            ExpiresAt = expiresAt;
            Error = error;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Generated authorization code that connects a mobile application instance
        /// to a Square account.
        /// </summary>
        [JsonProperty("authorization_code")]
        public string AuthorizationCode { get; }

        /// <summary>
        /// The timestamp when `authorization_code` expires in
        /// [RFC 3339](https://tools.ietf.org/html/rfc3339) format, e.g., "2016-09-04T23:59:33.123Z".
        /// </summary>
        [JsonProperty("expires_at")]
        public string ExpiresAt { get; }

        /// <summary>
        /// Represents an error encountered during a request to the Connect API.
        /// See [Handling errors](#handlingerrors) for more information.
        /// </summary>
        [JsonProperty("error")]
        public Models.Error Error { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .AuthorizationCode(AuthorizationCode)
                .ExpiresAt(ExpiresAt)
                .Error(Error);
            return builder;
        }

        public class Builder
        {
            private string authorizationCode;
            private string expiresAt;
            private Models.Error error;

            public Builder() { }
            public Builder AuthorizationCode(string value)
            {
                authorizationCode = value;
                return this;
            }

            public Builder ExpiresAt(string value)
            {
                expiresAt = value;
                return this;
            }

            public Builder Error(Models.Error value)
            {
                error = value;
                return this;
            }

            public CreateMobileAuthorizationCodeResponse Build()
            {
                return new CreateMobileAuthorizationCodeResponse(authorizationCode,
                    expiresAt,
                    error);
            }
        }
    }
}