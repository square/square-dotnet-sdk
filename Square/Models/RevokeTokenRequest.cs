
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class RevokeTokenRequest 
    {
        public RevokeTokenRequest(string clientId = null,
            string accessToken = null,
            string merchantId = null,
            bool? revokeOnlyAccessToken = null)
        {
            ClientId = clientId;
            AccessToken = accessToken;
            MerchantId = merchantId;
            RevokeOnlyAccessToken = revokeOnlyAccessToken;
        }

        /// <summary>
        /// The Square issued ID for your application, available from the
        /// [application dashboard](https://connect.squareup.com/apps).
        /// </summary>
        [JsonProperty("client_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ClientId { get; }

        /// <summary>
        /// The access token of the merchant whose token you want to revoke.
        /// Do not provide a value for merchant_id if you provide this parameter.
        /// </summary>
        [JsonProperty("access_token", NullValueHandling = NullValueHandling.Ignore)]
        public string AccessToken { get; }

        /// <summary>
        /// The ID of the merchant whose token you want to revoke.
        /// Do not provide a value for access_token if you provide this parameter.
        /// </summary>
        [JsonProperty("merchant_id", NullValueHandling = NullValueHandling.Ignore)]
        public string MerchantId { get; }

        /// <summary>
        /// If `true`, terminate the given single access token, but do not
        /// terminate the entire authorization.
        /// Default: `false`
        /// </summary>
        [JsonProperty("revoke_only_access_token", NullValueHandling = NullValueHandling.Ignore)]
        public bool? RevokeOnlyAccessToken { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"RevokeTokenRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"ClientId = {(ClientId == null ? "null" : ClientId == string.Empty ? "" : ClientId)}");
            toStringOutput.Add($"AccessToken = {(AccessToken == null ? "null" : AccessToken == string.Empty ? "" : AccessToken)}");
            toStringOutput.Add($"MerchantId = {(MerchantId == null ? "null" : MerchantId == string.Empty ? "" : MerchantId)}");
            toStringOutput.Add($"RevokeOnlyAccessToken = {(RevokeOnlyAccessToken == null ? "null" : RevokeOnlyAccessToken.ToString())}");
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

            return obj is RevokeTokenRequest other &&
                ((ClientId == null && other.ClientId == null) || (ClientId?.Equals(other.ClientId) == true)) &&
                ((AccessToken == null && other.AccessToken == null) || (AccessToken?.Equals(other.AccessToken) == true)) &&
                ((MerchantId == null && other.MerchantId == null) || (MerchantId?.Equals(other.MerchantId) == true)) &&
                ((RevokeOnlyAccessToken == null && other.RevokeOnlyAccessToken == null) || (RevokeOnlyAccessToken?.Equals(other.RevokeOnlyAccessToken) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1546864389;

            if (ClientId != null)
            {
               hashCode += ClientId.GetHashCode();
            }

            if (AccessToken != null)
            {
               hashCode += AccessToken.GetHashCode();
            }

            if (MerchantId != null)
            {
               hashCode += MerchantId.GetHashCode();
            }

            if (RevokeOnlyAccessToken != null)
            {
               hashCode += RevokeOnlyAccessToken.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .ClientId(ClientId)
                .AccessToken(AccessToken)
                .MerchantId(MerchantId)
                .RevokeOnlyAccessToken(RevokeOnlyAccessToken);
            return builder;
        }

        public class Builder
        {
            private string clientId;
            private string accessToken;
            private string merchantId;
            private bool? revokeOnlyAccessToken;



            public Builder ClientId(string clientId)
            {
                this.clientId = clientId;
                return this;
            }

            public Builder AccessToken(string accessToken)
            {
                this.accessToken = accessToken;
                return this;
            }

            public Builder MerchantId(string merchantId)
            {
                this.merchantId = merchantId;
                return this;
            }

            public Builder RevokeOnlyAccessToken(bool? revokeOnlyAccessToken)
            {
                this.revokeOnlyAccessToken = revokeOnlyAccessToken;
                return this;
            }

            public RevokeTokenRequest Build()
            {
                return new RevokeTokenRequest(clientId,
                    accessToken,
                    merchantId,
                    revokeOnlyAccessToken);
            }
        }
    }
}