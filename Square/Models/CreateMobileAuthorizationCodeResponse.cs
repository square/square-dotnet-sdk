
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
        [JsonProperty("authorization_code", NullValueHandling = NullValueHandling.Ignore)]
        public string AuthorizationCode { get; }

        /// <summary>
        /// The timestamp when `authorization_code` expires in
        /// [RFC 3339](https://tools.ietf.org/html/rfc3339) format, e.g., "2016-09-04T23:59:33.123Z".
        /// </summary>
        [JsonProperty("expires_at", NullValueHandling = NullValueHandling.Ignore)]
        public string ExpiresAt { get; }

        /// <summary>
        /// Represents an error encountered during a request to the Connect API.
        /// See [Handling errors](#handlingerrors) for more information.
        /// </summary>
        [JsonProperty("error", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Error Error { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateMobileAuthorizationCodeResponse : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"AuthorizationCode = {(AuthorizationCode == null ? "null" : AuthorizationCode == string.Empty ? "" : AuthorizationCode)}");
            toStringOutput.Add($"ExpiresAt = {(ExpiresAt == null ? "null" : ExpiresAt == string.Empty ? "" : ExpiresAt)}");
            toStringOutput.Add($"Error = {(Error == null ? "null" : Error.ToString())}");
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            return obj is CreateMobileAuthorizationCodeResponse other &&
                ((Context == null && other.Context == null) || (Context?.Equals(other.Context) == true)) &&
                ((AuthorizationCode == null && other.AuthorizationCode == null) || (AuthorizationCode?.Equals(other.AuthorizationCode) == true)) &&
                ((ExpiresAt == null && other.ExpiresAt == null) || (ExpiresAt?.Equals(other.ExpiresAt) == true)) &&
                ((Error == null && other.Error == null) || (Error?.Equals(other.Error) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -942988970;

            if (Context != null)
            {
                hashCode += Context.GetHashCode();
            }

            if (AuthorizationCode != null)
            {
               hashCode += AuthorizationCode.GetHashCode();
            }

            if (ExpiresAt != null)
            {
               hashCode += ExpiresAt.GetHashCode();
            }

            if (Error != null)
            {
               hashCode += Error.GetHashCode();
            }

            return hashCode;
        }

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



            public Builder AuthorizationCode(string authorizationCode)
            {
                this.authorizationCode = authorizationCode;
                return this;
            }

            public Builder ExpiresAt(string expiresAt)
            {
                this.expiresAt = expiresAt;
                return this;
            }

            public Builder Error(Models.Error error)
            {
                this.error = error;
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