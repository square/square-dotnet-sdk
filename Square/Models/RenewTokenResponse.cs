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
    /// RenewTokenResponse.
    /// </summary>
    public class RenewTokenResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RenewTokenResponse"/> class.
        /// </summary>
        /// <param name="accessToken">access_token.</param>
        /// <param name="tokenType">token_type.</param>
        /// <param name="expiresAt">expires_at.</param>
        /// <param name="merchantId">merchant_id.</param>
        /// <param name="subscriptionId">subscription_id.</param>
        /// <param name="planId">plan_id.</param>
        /// <param name="errors">errors.</param>
        public RenewTokenResponse(
            string accessToken = null,
            string tokenType = null,
            string expiresAt = null,
            string merchantId = null,
            string subscriptionId = null,
            string planId = null,
            IList<Models.Error> errors = null)
        {
            this.AccessToken = accessToken;
            this.TokenType = tokenType;
            this.ExpiresAt = expiresAt;
            this.MerchantId = merchantId;
            this.SubscriptionId = subscriptionId;
            this.PlanId = planId;
            this.Errors = errors;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The renewed access token.
        /// This value might be different from the `access_token` you provided in your request.
        /// You provide this token in a header with every request to Connect API endpoints.
        /// See [Request and response headers](https://developer.squareup.com/docs/api/connect/v2/#requestandresponseheaders) for the format of this header.
        /// </summary>
        [JsonProperty("access_token", NullValueHandling = NullValueHandling.Ignore)]
        public string AccessToken { get; }

        /// <summary>
        /// This value is always _bearer_.
        /// </summary>
        [JsonProperty("token_type", NullValueHandling = NullValueHandling.Ignore)]
        public string TokenType { get; }

        /// <summary>
        /// The date when the `access_token` expires, in [ISO 8601](http://www.iso.org/iso/home/standards/iso8601.htm) format.
        /// </summary>
        [JsonProperty("expires_at", NullValueHandling = NullValueHandling.Ignore)]
        public string ExpiresAt { get; }

        /// <summary>
        /// The ID of the authorizing merchant's business.
        /// </summary>
        [JsonProperty("merchant_id", NullValueHandling = NullValueHandling.Ignore)]
        public string MerchantId { get; }

        /// <summary>
        /// __LEGACY FIELD__. The ID of the merchant subscription associated with
        /// the authorization. The ID is only present if the merchant signed up for a subscription
        /// during authorization.
        /// </summary>
        [JsonProperty("subscription_id", NullValueHandling = NullValueHandling.Ignore)]
        public string SubscriptionId { get; }

        /// <summary>
        /// __LEGACY FIELD__. The ID of the subscription plan the merchant signed
        /// up for. The ID is only present if the merchant signed up for a subscription plan during
        /// authorization.
        /// </summary>
        [JsonProperty("plan_id", NullValueHandling = NullValueHandling.Ignore)]
        public string PlanId { get; }

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

            return $"RenewTokenResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is RenewTokenResponse other &&
                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.AccessToken == null && other.AccessToken == null) || (this.AccessToken?.Equals(other.AccessToken) == true)) &&
                ((this.TokenType == null && other.TokenType == null) || (this.TokenType?.Equals(other.TokenType) == true)) &&
                ((this.ExpiresAt == null && other.ExpiresAt == null) || (this.ExpiresAt?.Equals(other.ExpiresAt) == true)) &&
                ((this.MerchantId == null && other.MerchantId == null) || (this.MerchantId?.Equals(other.MerchantId) == true)) &&
                ((this.SubscriptionId == null && other.SubscriptionId == null) || (this.SubscriptionId?.Equals(other.SubscriptionId) == true)) &&
                ((this.PlanId == null && other.PlanId == null) || (this.PlanId?.Equals(other.PlanId) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -709188927;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.AccessToken, this.TokenType, this.ExpiresAt, this.MerchantId, this.SubscriptionId, this.PlanId, this.Errors);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.AccessToken = {(this.AccessToken == null ? "null" : this.AccessToken == string.Empty ? "" : this.AccessToken)}");
            toStringOutput.Add($"this.TokenType = {(this.TokenType == null ? "null" : this.TokenType == string.Empty ? "" : this.TokenType)}");
            toStringOutput.Add($"this.ExpiresAt = {(this.ExpiresAt == null ? "null" : this.ExpiresAt == string.Empty ? "" : this.ExpiresAt)}");
            toStringOutput.Add($"this.MerchantId = {(this.MerchantId == null ? "null" : this.MerchantId == string.Empty ? "" : this.MerchantId)}");
            toStringOutput.Add($"this.SubscriptionId = {(this.SubscriptionId == null ? "null" : this.SubscriptionId == string.Empty ? "" : this.SubscriptionId)}");
            toStringOutput.Add($"this.PlanId = {(this.PlanId == null ? "null" : this.PlanId == string.Empty ? "" : this.PlanId)}");
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .AccessToken(this.AccessToken)
                .TokenType(this.TokenType)
                .ExpiresAt(this.ExpiresAt)
                .MerchantId(this.MerchantId)
                .SubscriptionId(this.SubscriptionId)
                .PlanId(this.PlanId)
                .Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string accessToken;
            private string tokenType;
            private string expiresAt;
            private string merchantId;
            private string subscriptionId;
            private string planId;
            private IList<Models.Error> errors;

             /// <summary>
             /// AccessToken.
             /// </summary>
             /// <param name="accessToken"> accessToken. </param>
             /// <returns> Builder. </returns>
            public Builder AccessToken(string accessToken)
            {
                this.accessToken = accessToken;
                return this;
            }

             /// <summary>
             /// TokenType.
             /// </summary>
             /// <param name="tokenType"> tokenType. </param>
             /// <returns> Builder. </returns>
            public Builder TokenType(string tokenType)
            {
                this.tokenType = tokenType;
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
             /// SubscriptionId.
             /// </summary>
             /// <param name="subscriptionId"> subscriptionId. </param>
             /// <returns> Builder. </returns>
            public Builder SubscriptionId(string subscriptionId)
            {
                this.subscriptionId = subscriptionId;
                return this;
            }

             /// <summary>
             /// PlanId.
             /// </summary>
             /// <param name="planId"> planId. </param>
             /// <returns> Builder. </returns>
            public Builder PlanId(string planId)
            {
                this.planId = planId;
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
            /// <returns> RenewTokenResponse. </returns>
            public RenewTokenResponse Build()
            {
                return new RenewTokenResponse(
                    this.accessToken,
                    this.tokenType,
                    this.expiresAt,
                    this.merchantId,
                    this.subscriptionId,
                    this.planId,
                    this.errors);
            }
        }
    }
}