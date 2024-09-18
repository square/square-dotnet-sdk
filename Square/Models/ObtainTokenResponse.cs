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

namespace Square.Models
{
    /// <summary>
    /// ObtainTokenResponse.
    /// </summary>
    public class ObtainTokenResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ObtainTokenResponse"/> class.
        /// </summary>
        /// <param name="accessToken">access_token.</param>
        /// <param name="tokenType">token_type.</param>
        /// <param name="expiresAt">expires_at.</param>
        /// <param name="merchantId">merchant_id.</param>
        /// <param name="subscriptionId">subscription_id.</param>
        /// <param name="planId">plan_id.</param>
        /// <param name="idToken">id_token.</param>
        /// <param name="refreshToken">refresh_token.</param>
        /// <param name="shortLived">short_lived.</param>
        /// <param name="errors">errors.</param>
        /// <param name="refreshTokenExpiresAt">refresh_token_expires_at.</param>
        public ObtainTokenResponse(
            string accessToken = null,
            string tokenType = null,
            string expiresAt = null,
            string merchantId = null,
            string subscriptionId = null,
            string planId = null,
            string idToken = null,
            string refreshToken = null,
            bool? shortLived = null,
            IList<Models.Error> errors = null,
            string refreshTokenExpiresAt = null)
        {
            this.AccessToken = accessToken;
            this.TokenType = tokenType;
            this.ExpiresAt = expiresAt;
            this.MerchantId = merchantId;
            this.SubscriptionId = subscriptionId;
            this.PlanId = planId;
            this.IdToken = idToken;
            this.RefreshToken = refreshToken;
            this.ShortLived = shortLived;
            this.Errors = errors;
            this.RefreshTokenExpiresAt = refreshTokenExpiresAt;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// A valid OAuth access token.
        /// Provide the access token in a header with every request to Connect API
        /// endpoints. For more information, see [OAuth API: Walkthrough](https://developer.squareup.com/docs/oauth-api/walkthrough).
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
        /// __LEGACY FIELD__. The ID of a subscription plan the merchant signed up
        /// for. The ID is only present if the merchant signed up for a subscription plan during authorization.
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
        /// The OpenID token belonging to this person. This token is only present if the
        /// OPENID scope is included in the authorization request.
        /// </summary>
        [JsonProperty("id_token", NullValueHandling = NullValueHandling.Ignore)]
        public string IdToken { get; }

        /// <summary>
        /// A refresh token.
        /// For more information, see [Refresh, Revoke, and Limit the Scope of OAuth Tokens](https://developer.squareup.com/docs/oauth-api/refresh-revoke-limit-scope).
        /// </summary>
        [JsonProperty("refresh_token", NullValueHandling = NullValueHandling.Ignore)]
        public string RefreshToken { get; }

        /// <summary>
        /// A Boolean indicating that the access token is a short-lived access token.
        /// The short-lived access token returned in the response expires in 24 hours.
        /// </summary>
        [JsonProperty("short_lived", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ShortLived { get; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// The date when the `refresh_token` expires, in [ISO 8601](http://www.iso.org/iso/home/standards/iso8601.htm) format.
        /// </summary>
        [JsonProperty("refresh_token_expires_at", NullValueHandling = NullValueHandling.Ignore)]
        public string RefreshTokenExpiresAt { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ObtainTokenResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is ObtainTokenResponse other &&                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.AccessToken == null && other.AccessToken == null) || (this.AccessToken?.Equals(other.AccessToken) == true)) &&
                ((this.TokenType == null && other.TokenType == null) || (this.TokenType?.Equals(other.TokenType) == true)) &&
                ((this.ExpiresAt == null && other.ExpiresAt == null) || (this.ExpiresAt?.Equals(other.ExpiresAt) == true)) &&
                ((this.MerchantId == null && other.MerchantId == null) || (this.MerchantId?.Equals(other.MerchantId) == true)) &&
                ((this.SubscriptionId == null && other.SubscriptionId == null) || (this.SubscriptionId?.Equals(other.SubscriptionId) == true)) &&
                ((this.PlanId == null && other.PlanId == null) || (this.PlanId?.Equals(other.PlanId) == true)) &&
                ((this.IdToken == null && other.IdToken == null) || (this.IdToken?.Equals(other.IdToken) == true)) &&
                ((this.RefreshToken == null && other.RefreshToken == null) || (this.RefreshToken?.Equals(other.RefreshToken) == true)) &&
                ((this.ShortLived == null && other.ShortLived == null) || (this.ShortLived?.Equals(other.ShortLived) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true)) &&
                ((this.RefreshTokenExpiresAt == null && other.RefreshTokenExpiresAt == null) || (this.RefreshTokenExpiresAt?.Equals(other.RefreshTokenExpiresAt) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -62575650;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.AccessToken, this.TokenType, this.ExpiresAt, this.MerchantId, this.SubscriptionId, this.PlanId, this.IdToken);

            hashCode = HashCode.Combine(hashCode, this.RefreshToken, this.ShortLived, this.Errors, this.RefreshTokenExpiresAt);

            return hashCode;
        }
        internal ObtainTokenResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"this.AccessToken = {(this.AccessToken == null ? "null" : this.AccessToken)}");
            toStringOutput.Add($"this.TokenType = {(this.TokenType == null ? "null" : this.TokenType)}");
            toStringOutput.Add($"this.ExpiresAt = {(this.ExpiresAt == null ? "null" : this.ExpiresAt)}");
            toStringOutput.Add($"this.MerchantId = {(this.MerchantId == null ? "null" : this.MerchantId)}");
            toStringOutput.Add($"this.SubscriptionId = {(this.SubscriptionId == null ? "null" : this.SubscriptionId)}");
            toStringOutput.Add($"this.PlanId = {(this.PlanId == null ? "null" : this.PlanId)}");
            toStringOutput.Add($"this.IdToken = {(this.IdToken == null ? "null" : this.IdToken)}");
            toStringOutput.Add($"this.RefreshToken = {(this.RefreshToken == null ? "null" : this.RefreshToken)}");
            toStringOutput.Add($"this.ShortLived = {(this.ShortLived == null ? "null" : this.ShortLived.ToString())}");
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
            toStringOutput.Add($"this.RefreshTokenExpiresAt = {(this.RefreshTokenExpiresAt == null ? "null" : this.RefreshTokenExpiresAt)}");
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
                .IdToken(this.IdToken)
                .RefreshToken(this.RefreshToken)
                .ShortLived(this.ShortLived)
                .Errors(this.Errors)
                .RefreshTokenExpiresAt(this.RefreshTokenExpiresAt);
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
            private string idToken;
            private string refreshToken;
            private bool? shortLived;
            private IList<Models.Error> errors;
            private string refreshTokenExpiresAt;

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
             /// IdToken.
             /// </summary>
             /// <param name="idToken"> idToken. </param>
             /// <returns> Builder. </returns>
            public Builder IdToken(string idToken)
            {
                this.idToken = idToken;
                return this;
            }

             /// <summary>
             /// RefreshToken.
             /// </summary>
             /// <param name="refreshToken"> refreshToken. </param>
             /// <returns> Builder. </returns>
            public Builder RefreshToken(string refreshToken)
            {
                this.refreshToken = refreshToken;
                return this;
            }

             /// <summary>
             /// ShortLived.
             /// </summary>
             /// <param name="shortLived"> shortLived. </param>
             /// <returns> Builder. </returns>
            public Builder ShortLived(bool? shortLived)
            {
                this.shortLived = shortLived;
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
             /// RefreshTokenExpiresAt.
             /// </summary>
             /// <param name="refreshTokenExpiresAt"> refreshTokenExpiresAt. </param>
             /// <returns> Builder. </returns>
            public Builder RefreshTokenExpiresAt(string refreshTokenExpiresAt)
            {
                this.refreshTokenExpiresAt = refreshTokenExpiresAt;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ObtainTokenResponse. </returns>
            public ObtainTokenResponse Build()
            {
                return new ObtainTokenResponse(
                    this.accessToken,
                    this.tokenType,
                    this.expiresAt,
                    this.merchantId,
                    this.subscriptionId,
                    this.planId,
                    this.idToken,
                    this.refreshToken,
                    this.shortLived,
                    this.errors,
                    this.refreshTokenExpiresAt);
            }
        }
    }
}