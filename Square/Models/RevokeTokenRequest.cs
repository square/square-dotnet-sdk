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
    using Square.Utilities;

    /// <summary>
    /// RevokeTokenRequest.
    /// </summary>
    public class RevokeTokenRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="RevokeTokenRequest"/> class.
        /// </summary>
        /// <param name="clientId">client_id.</param>
        /// <param name="accessToken">access_token.</param>
        /// <param name="merchantId">merchant_id.</param>
        /// <param name="revokeOnlyAccessToken">revoke_only_access_token.</param>
        public RevokeTokenRequest(
            string clientId = null,
            string accessToken = null,
            string merchantId = null,
            bool? revokeOnlyAccessToken = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "client_id", false },
                { "access_token", false },
                { "merchant_id", false },
                { "revoke_only_access_token", false }
            };

            if (clientId != null)
            {
                shouldSerialize["client_id"] = true;
                this.ClientId = clientId;
            }

            if (accessToken != null)
            {
                shouldSerialize["access_token"] = true;
                this.AccessToken = accessToken;
            }

            if (merchantId != null)
            {
                shouldSerialize["merchant_id"] = true;
                this.MerchantId = merchantId;
            }

            if (revokeOnlyAccessToken != null)
            {
                shouldSerialize["revoke_only_access_token"] = true;
                this.RevokeOnlyAccessToken = revokeOnlyAccessToken;
            }

        }
        internal RevokeTokenRequest(Dictionary<string, bool> shouldSerialize,
            string clientId = null,
            string accessToken = null,
            string merchantId = null,
            bool? revokeOnlyAccessToken = null)
        {
            this.shouldSerialize = shouldSerialize;
            ClientId = clientId;
            AccessToken = accessToken;
            MerchantId = merchantId;
            RevokeOnlyAccessToken = revokeOnlyAccessToken;
        }

        /// <summary>
        /// The Square-issued ID for your application, which is available on the **OAuth** page in the
        /// [Developer Dashboard](https://developer.squareup.com/apps).
        /// </summary>
        [JsonProperty("client_id")]
        public string ClientId { get; }

        /// <summary>
        /// The access token of the merchant whose token you want to revoke.
        /// Do not provide a value for `merchant_id` if you provide this parameter.
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; }

        /// <summary>
        /// The ID of the merchant whose token you want to revoke.
        /// Do not provide a value for `access_token` if you provide this parameter.
        /// </summary>
        [JsonProperty("merchant_id")]
        public string MerchantId { get; }

        /// <summary>
        /// If `true`, terminate the given single access token, but do not
        /// terminate the entire authorization.
        /// Default: `false`
        /// </summary>
        [JsonProperty("revoke_only_access_token")]
        public bool? RevokeOnlyAccessToken { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"RevokeTokenRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeClientId()
        {
            return this.shouldSerialize["client_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAccessToken()
        {
            return this.shouldSerialize["access_token"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMerchantId()
        {
            return this.shouldSerialize["merchant_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeRevokeOnlyAccessToken()
        {
            return this.shouldSerialize["revoke_only_access_token"];
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
            return obj is RevokeTokenRequest other &&                ((this.ClientId == null && other.ClientId == null) || (this.ClientId?.Equals(other.ClientId) == true)) &&
                ((this.AccessToken == null && other.AccessToken == null) || (this.AccessToken?.Equals(other.AccessToken) == true)) &&
                ((this.MerchantId == null && other.MerchantId == null) || (this.MerchantId?.Equals(other.MerchantId) == true)) &&
                ((this.RevokeOnlyAccessToken == null && other.RevokeOnlyAccessToken == null) || (this.RevokeOnlyAccessToken?.Equals(other.RevokeOnlyAccessToken) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1546864389;
            hashCode = HashCode.Combine(this.ClientId, this.AccessToken, this.MerchantId, this.RevokeOnlyAccessToken);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ClientId = {(this.ClientId == null ? "null" : this.ClientId)}");
            toStringOutput.Add($"this.AccessToken = {(this.AccessToken == null ? "null" : this.AccessToken)}");
            toStringOutput.Add($"this.MerchantId = {(this.MerchantId == null ? "null" : this.MerchantId)}");
            toStringOutput.Add($"this.RevokeOnlyAccessToken = {(this.RevokeOnlyAccessToken == null ? "null" : this.RevokeOnlyAccessToken.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .ClientId(this.ClientId)
                .AccessToken(this.AccessToken)
                .MerchantId(this.MerchantId)
                .RevokeOnlyAccessToken(this.RevokeOnlyAccessToken);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "client_id", false },
                { "access_token", false },
                { "merchant_id", false },
                { "revoke_only_access_token", false },
            };

            private string clientId;
            private string accessToken;
            private string merchantId;
            private bool? revokeOnlyAccessToken;

             /// <summary>
             /// ClientId.
             /// </summary>
             /// <param name="clientId"> clientId. </param>
             /// <returns> Builder. </returns>
            public Builder ClientId(string clientId)
            {
                shouldSerialize["client_id"] = true;
                this.clientId = clientId;
                return this;
            }

             /// <summary>
             /// AccessToken.
             /// </summary>
             /// <param name="accessToken"> accessToken. </param>
             /// <returns> Builder. </returns>
            public Builder AccessToken(string accessToken)
            {
                shouldSerialize["access_token"] = true;
                this.accessToken = accessToken;
                return this;
            }

             /// <summary>
             /// MerchantId.
             /// </summary>
             /// <param name="merchantId"> merchantId. </param>
             /// <returns> Builder. </returns>
            public Builder MerchantId(string merchantId)
            {
                shouldSerialize["merchant_id"] = true;
                this.merchantId = merchantId;
                return this;
            }

             /// <summary>
             /// RevokeOnlyAccessToken.
             /// </summary>
             /// <param name="revokeOnlyAccessToken"> revokeOnlyAccessToken. </param>
             /// <returns> Builder. </returns>
            public Builder RevokeOnlyAccessToken(bool? revokeOnlyAccessToken)
            {
                shouldSerialize["revoke_only_access_token"] = true;
                this.revokeOnlyAccessToken = revokeOnlyAccessToken;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetClientId()
            {
                this.shouldSerialize["client_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetAccessToken()
            {
                this.shouldSerialize["access_token"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetMerchantId()
            {
                this.shouldSerialize["merchant_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetRevokeOnlyAccessToken()
            {
                this.shouldSerialize["revoke_only_access_token"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> RevokeTokenRequest. </returns>
            public RevokeTokenRequest Build()
            {
                return new RevokeTokenRequest(shouldSerialize,
                    this.clientId,
                    this.accessToken,
                    this.merchantId,
                    this.revokeOnlyAccessToken);
            }
        }
    }
}