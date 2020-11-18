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
    public class ObtainTokenResponse 
    {
        public ObtainTokenResponse(string accessToken = null,
            string tokenType = null,
            string expiresAt = null,
            string merchantId = null,
            string subscriptionId = null,
            string planId = null,
            string idToken = null,
            string refreshToken = null,
            bool? shortLived = null)
        {
            AccessToken = accessToken;
            TokenType = tokenType;
            ExpiresAt = expiresAt;
            MerchantId = merchantId;
            SubscriptionId = subscriptionId;
            PlanId = planId;
            IdToken = idToken;
            RefreshToken = refreshToken;
            ShortLived = shortLived;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// A valid OAuth access token. OAuth access tokens are 64 bytes long.
        /// Provide the access token in a header with every request to Connect API
        /// endpoints. See [OAuth API: Walkthrough](https://developer.squareup.com/docs/oauth-api/walkthrough)
        /// for more information.
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
        /// __LEGACY FIELD__. The ID of a subscription plan the merchant signed up
        /// for. Only present if the merchant signed up for a subscription during authorization.
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

        /// <summary>
        /// Then OpenID token belonging to this this person. Only present if the
        /// OPENID scope is included in the authorize request.
        /// </summary>
        [JsonProperty("id_token", NullValueHandling = NullValueHandling.Ignore)]
        public string IdToken { get; }

        /// <summary>
        /// A refresh token. OAuth refresh tokens are 64 bytes long.
        /// For more information, see [OAuth access token management](https://developer.squareup.com/docs/authz/oauth/how-it-works#oauth-access-token-management).
        /// </summary>
        [JsonProperty("refresh_token", NullValueHandling = NullValueHandling.Ignore)]
        public string RefreshToken { get; }

        /// <summary>
        /// A boolean indicating the access token is a short-lived access token.
        /// The short-lived access token returned in the response will expire in 24 hours.
        /// </summary>
        [JsonProperty("short_lived", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ShortLived { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .AccessToken(AccessToken)
                .TokenType(TokenType)
                .ExpiresAt(ExpiresAt)
                .MerchantId(MerchantId)
                .SubscriptionId(SubscriptionId)
                .PlanId(PlanId)
                .IdToken(IdToken)
                .RefreshToken(RefreshToken)
                .ShortLived(ShortLived);
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
            private string idToken;
            private string refreshToken;
            private bool? shortLived;



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

            public Builder IdToken(string idToken)
            {
                this.idToken = idToken;
                return this;
            }

            public Builder RefreshToken(string refreshToken)
            {
                this.refreshToken = refreshToken;
                return this;
            }

            public Builder ShortLived(bool? shortLived)
            {
                this.shortLived = shortLived;
                return this;
            }

            public ObtainTokenResponse Build()
            {
                return new ObtainTokenResponse(accessToken,
                    tokenType,
                    expiresAt,
                    merchantId,
                    subscriptionId,
                    planId,
                    idToken,
                    refreshToken,
                    shortLived);
            }
        }
    }
}