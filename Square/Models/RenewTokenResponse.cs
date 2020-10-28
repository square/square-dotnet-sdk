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