namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using APIMatic.Core.Utilities.Converters;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Http.Client;
    using Square.Utilities;

    /// <summary>
    /// CreateMobileAuthorizationCodeResponse.
    /// </summary>
    public class CreateMobileAuthorizationCodeResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMobileAuthorizationCodeResponse"/> class.
        /// </summary>
        /// <param name="authorizationCode">authorization_code.</param>
        /// <param name="expiresAt">expires_at.</param>
        /// <param name="errors">errors.</param>
        public CreateMobileAuthorizationCodeResponse(
            string authorizationCode = null,
            string expiresAt = null,
            IList<Models.Error> errors = null)
        {
            this.AuthorizationCode = authorizationCode;
            this.ExpiresAt = expiresAt;
            this.Errors = errors;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The generated authorization code that connects a mobile application instance
        /// to a Square account.
        /// </summary>
        [JsonProperty("authorization_code", NullValueHandling = NullValueHandling.Ignore)]
        public string AuthorizationCode { get; }

        /// <summary>
        /// The timestamp when `authorization_code` expires, in
        /// [RFC 3339](https://tools.ietf.org/html/rfc3339) format (for example, "2016-09-04T23:59:33.123Z").
        /// </summary>
        [JsonProperty("expires_at", NullValueHandling = NullValueHandling.Ignore)]
        public string ExpiresAt { get; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateMobileAuthorizationCodeResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
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
            return obj is CreateMobileAuthorizationCodeResponse other &&                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.AuthorizationCode == null && other.AuthorizationCode == null) || (this.AuthorizationCode?.Equals(other.AuthorizationCode) == true)) &&
                ((this.ExpiresAt == null && other.ExpiresAt == null) || (this.ExpiresAt?.Equals(other.ExpiresAt) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1694177242;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.AuthorizationCode, this.ExpiresAt, this.Errors);

            return hashCode;
        }
        internal CreateMobileAuthorizationCodeResponse ContextSetter(HttpContext context)
        {
            this.Context = context;
            return this;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.AuthorizationCode = {(this.AuthorizationCode == null ? "null" : this.AuthorizationCode)}");
            toStringOutput.Add($"this.ExpiresAt = {(this.ExpiresAt == null ? "null" : this.ExpiresAt)}");
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .AuthorizationCode(this.AuthorizationCode)
                .ExpiresAt(this.ExpiresAt)
                .Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string authorizationCode;
            private string expiresAt;
            private IList<Models.Error> errors;

             /// <summary>
             /// AuthorizationCode.
             /// </summary>
             /// <param name="authorizationCode"> authorizationCode. </param>
             /// <returns> Builder. </returns>
            public Builder AuthorizationCode(string authorizationCode)
            {
                this.authorizationCode = authorizationCode;
                return this;
            }

             /// <summary>
             /// ExpiresAt.
             /// </summary>
             /// <param name="expiresAt"> expiresAt. </param>
             /// <returns> Builder. </returns>
            public Builder ExpiresAt(string expiresAt)
            {
                this.expiresAt = expiresAt;
                return this;
            }

             /// <summary>
             /// Errors.
             /// </summary>
             /// <param name="errors"> errors. </param>
             /// <returns> Builder. </returns>
            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CreateMobileAuthorizationCodeResponse. </returns>
            public CreateMobileAuthorizationCodeResponse Build()
            {
                return new CreateMobileAuthorizationCodeResponse(
                    this.authorizationCode,
                    this.expiresAt,
                    this.errors);
            }
        }
    }
}