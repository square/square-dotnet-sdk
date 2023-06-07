namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Http.Client;
    using Square.Utilities;

    /// <summary>
    /// RetrieveTokenStatusResponse.
    /// </summary>
    public class RetrieveTokenStatusResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RetrieveTokenStatusResponse"/> class.
        /// </summary>
        /// <param name="scopes">scopes.</param>
        /// <param name="expiresAt">expires_at.</param>
        /// <param name="clientId">client_id.</param>
        /// <param name="merchantId">merchant_id.</param>
        /// <param name="errors">errors.</param>
        public RetrieveTokenStatusResponse(
            IList<string> scopes = null,
            string expiresAt = null,
            string clientId = null,
            string merchantId = null,
            IList<Models.Error> errors = null)
        {
            this.Scopes = scopes;
            this.ExpiresAt = expiresAt;
            this.ClientId = clientId;
            this.MerchantId = merchantId;
            this.Errors = errors;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The list of scopes associated with an access token.
        /// </summary>
        [JsonProperty("scopes", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> Scopes { get; }

        /// <summary>
        /// The date and time when the `access_token` expires, in RFC 3339 format. Empty if the token never expires.
        /// </summary>
        [JsonProperty("expires_at", NullValueHandling = NullValueHandling.Ignore)]
        public string ExpiresAt { get; }

        /// <summary>
        /// The Square-issued application ID associated with the access token. This is the same application ID used to obtain the token.
        /// </summary>
        [JsonProperty("client_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ClientId { get; }

        /// <summary>
        /// The ID of the authorizing merchant's business.
        /// </summary>
        [JsonProperty("merchant_id", NullValueHandling = NullValueHandling.Ignore)]
        public string MerchantId { get; }

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

            return $"RetrieveTokenStatusResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is RetrieveTokenStatusResponse other &&                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Scopes == null && other.Scopes == null) || (this.Scopes?.Equals(other.Scopes) == true)) &&
                ((this.ExpiresAt == null && other.ExpiresAt == null) || (this.ExpiresAt?.Equals(other.ExpiresAt) == true)) &&
                ((this.ClientId == null && other.ClientId == null) || (this.ClientId?.Equals(other.ClientId) == true)) &&
                ((this.MerchantId == null && other.MerchantId == null) || (this.MerchantId?.Equals(other.MerchantId) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1908720599;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.Scopes, this.ExpiresAt, this.ClientId, this.MerchantId, this.Errors);

            return hashCode;
        }
        internal RetrieveTokenStatusResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"this.Scopes = {(this.Scopes == null ? "null" : $"[{string.Join(", ", this.Scopes)} ]")}");
            toStringOutput.Add($"this.ExpiresAt = {(this.ExpiresAt == null ? "null" : this.ExpiresAt == string.Empty ? "" : this.ExpiresAt)}");
            toStringOutput.Add($"this.ClientId = {(this.ClientId == null ? "null" : this.ClientId == string.Empty ? "" : this.ClientId)}");
            toStringOutput.Add($"this.MerchantId = {(this.MerchantId == null ? "null" : this.MerchantId == string.Empty ? "" : this.MerchantId)}");
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Scopes(this.Scopes)
                .ExpiresAt(this.ExpiresAt)
                .ClientId(this.ClientId)
                .MerchantId(this.MerchantId)
                .Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<string> scopes;
            private string expiresAt;
            private string clientId;
            private string merchantId;
            private IList<Models.Error> errors;

             /// <summary>
             /// Scopes.
             /// </summary>
             /// <param name="scopes"> scopes. </param>
             /// <returns> Builder. </returns>
            public Builder Scopes(IList<string> scopes)
            {
                this.scopes = scopes;
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
             /// ClientId.
             /// </summary>
             /// <param name="clientId"> clientId. </param>
             /// <returns> Builder. </returns>
            public Builder ClientId(string clientId)
            {
                this.clientId = clientId;
                return this;
            }

             /// <summary>
             /// MerchantId.
             /// </summary>
             /// <param name="merchantId"> merchantId. </param>
             /// <returns> Builder. </returns>
            public Builder MerchantId(string merchantId)
            {
                this.merchantId = merchantId;
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
            /// <returns> RetrieveTokenStatusResponse. </returns>
            public RetrieveTokenStatusResponse Build()
            {
                return new RetrieveTokenStatusResponse(
                    this.scopes,
                    this.expiresAt,
                    this.clientId,
                    this.merchantId,
                    this.errors);
            }
        }
    }
}