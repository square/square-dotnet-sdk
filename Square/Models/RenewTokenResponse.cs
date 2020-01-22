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
        [JsonProperty("access_token")]
        public string AccessToken { get; }

        /// <summary>
        /// This value is always _bearer_.
        /// </summary>
        [JsonProperty("token_type")]
        public string TokenType { get; }

        /// <summary>
        /// The date when access_token expires, in [ISO 8601](http://www.iso.org/iso/home/standards/iso8601.htm) format.
        /// </summary>
        [JsonProperty("expires_at")]
        public string ExpiresAt { get; }

        /// <summary>
        /// The ID of the authorizing merchant's business.
        /// </summary>
        [JsonProperty("merchant_id")]
        public string MerchantId { get; }

        /// <summary>
        /// __LEGACY FIELD__. The ID of the merchant subscription associated with
        /// the authorization. Only present if the merchant signed up for a subscription
        /// during authorization..
        /// </summary>
        [JsonProperty("subscription_id")]
        public string SubscriptionId { get; }

        /// <summary>
        /// __LEGACY FIELD__. The ID of the subscription plan the merchant signed
        /// up for. Only present if the merchant signed up for a subscription during
        /// authorization.
        /// </summary>
        [JsonProperty("plan_id")]
        public string PlanId { get; }

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

            public Builder() { }
            public Builder AccessToken(string value)
            {
                accessToken = value;
                return this;
            }

            public Builder TokenType(string value)
            {
                tokenType = value;
                return this;
            }

            public Builder ExpiresAt(string value)
            {
                expiresAt = value;
                return this;
            }

            public Builder MerchantId(string value)
            {
                merchantId = value;
                return this;
            }

            public Builder SubscriptionId(string value)
            {
                subscriptionId = value;
                return this;
            }

            public Builder PlanId(string value)
            {
                planId = value;
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