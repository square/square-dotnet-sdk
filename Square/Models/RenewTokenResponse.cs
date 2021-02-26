
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
    public class RenewTokenResponse 
    {
        public RenewTokenResponse(string accessToken = null,
            string tokenType = null,
            string expiresAt = null,
            string merchantId = null,
            string subscriptionId = null,
            string planId = null)
        {
            AccessToken = accessToken;
            TokenType = tokenType;
            ExpiresAt = expiresAt;
            MerchantId = merchantId;
            SubscriptionId = subscriptionId;
            PlanId = planId;
        }

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
        /// The date when access_token expires, in [ISO 8601](http://www.iso.org/iso/home/standards/iso8601.htm) format.
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
        /// the authorization. Only present if the merchant signed up for a subscription
        /// during authorization..
        /// </summary>
        [JsonProperty("subscription_id", NullValueHandling = NullValueHandling.Ignore)]
        public string SubscriptionId { get; }

        /// <summary>
        /// __LEGACY FIELD__. The ID of the subscription plan the merchant signed
        /// up for. Only present if the merchant signed up for a subscription during
        /// authorization.
        /// </summary>
        [JsonProperty("plan_id", NullValueHandling = NullValueHandling.Ignore)]
        public string PlanId { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"RenewTokenResponse : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"AccessToken = {(AccessToken == null ? "null" : AccessToken == string.Empty ? "" : AccessToken)}");
            toStringOutput.Add($"TokenType = {(TokenType == null ? "null" : TokenType == string.Empty ? "" : TokenType)}");
            toStringOutput.Add($"ExpiresAt = {(ExpiresAt == null ? "null" : ExpiresAt == string.Empty ? "" : ExpiresAt)}");
            toStringOutput.Add($"MerchantId = {(MerchantId == null ? "null" : MerchantId == string.Empty ? "" : MerchantId)}");
            toStringOutput.Add($"SubscriptionId = {(SubscriptionId == null ? "null" : SubscriptionId == string.Empty ? "" : SubscriptionId)}");
            toStringOutput.Add($"PlanId = {(PlanId == null ? "null" : PlanId == string.Empty ? "" : PlanId)}");
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

            return obj is RenewTokenResponse other &&
                ((Context == null && other.Context == null) || (Context?.Equals(other.Context) == true)) &&
                ((AccessToken == null && other.AccessToken == null) || (AccessToken?.Equals(other.AccessToken) == true)) &&
                ((TokenType == null && other.TokenType == null) || (TokenType?.Equals(other.TokenType) == true)) &&
                ((ExpiresAt == null && other.ExpiresAt == null) || (ExpiresAt?.Equals(other.ExpiresAt) == true)) &&
                ((MerchantId == null && other.MerchantId == null) || (MerchantId?.Equals(other.MerchantId) == true)) &&
                ((SubscriptionId == null && other.SubscriptionId == null) || (SubscriptionId?.Equals(other.SubscriptionId) == true)) &&
                ((PlanId == null && other.PlanId == null) || (PlanId?.Equals(other.PlanId) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1777017961;

            if (Context != null)
            {
                hashCode += Context.GetHashCode();
            }

            if (AccessToken != null)
            {
               hashCode += AccessToken.GetHashCode();
            }

            if (TokenType != null)
            {
               hashCode += TokenType.GetHashCode();
            }

            if (ExpiresAt != null)
            {
               hashCode += ExpiresAt.GetHashCode();
            }

            if (MerchantId != null)
            {
               hashCode += MerchantId.GetHashCode();
            }

            if (SubscriptionId != null)
            {
               hashCode += SubscriptionId.GetHashCode();
            }

            if (PlanId != null)
            {
               hashCode += PlanId.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .AccessToken(AccessToken)
                .TokenType(TokenType)
                .ExpiresAt(ExpiresAt)
                .MerchantId(MerchantId)
                .SubscriptionId(SubscriptionId)
                .PlanId(PlanId);
            return builder;
        }

        public class Builder
        {
            private string accessToken;
            private string tokenType;
            private string expiresAt;
            private string merchantId;
            private string subscriptionId;
            private string planId;



            public Builder AccessToken(string accessToken)
            {
                this.accessToken = accessToken;
                return this;
            }

            public Builder TokenType(string tokenType)
            {
                this.tokenType = tokenType;
                return this;
            }

            public Builder ExpiresAt(string expiresAt)
            {
                this.expiresAt = expiresAt;
                return this;
            }

            public Builder MerchantId(string merchantId)
            {
                this.merchantId = merchantId;
                return this;
            }

            public Builder SubscriptionId(string subscriptionId)
            {
                this.subscriptionId = subscriptionId;
                return this;
            }

            public Builder PlanId(string planId)
            {
                this.planId = planId;
                return this;
            }

            public RenewTokenResponse Build()
            {
                return new RenewTokenResponse(accessToken,
                    tokenType,
                    expiresAt,
                    merchantId,
                    subscriptionId,
                    planId);
            }
        }
    }
}