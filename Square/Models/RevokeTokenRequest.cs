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
            string merchantId = null)
        {
            ClientId = clientId;
            AccessToken = accessToken;
            MerchantId = merchantId;
        }

        /// <summary>
        /// The Square issued ID for your application, available from the
        /// [application dashboard](https://connect.squareup.com/apps).
        /// </summary>
        [JsonProperty("client_id")]
        public string ClientId { get; }

        /// <summary>
        /// The access token of the merchant whose token you want to revoke.
        /// Do not provide a value for merchant_id if you provide this parameter.
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; }

        /// <summary>
        /// The ID of the merchant whose token you want to revoke.
        /// Do not provide a value for access_token if you provide this parameter.
        /// </summary>
        [JsonProperty("merchant_id")]
        public string MerchantId { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .ClientId(ClientId)
                .AccessToken(AccessToken)
                .MerchantId(MerchantId);
            return builder;
        }

        public class Builder
        {
            private string clientId;
            private string accessToken;
            private string merchantId;

            public Builder() { }
            public Builder ClientId(string value)
            {
                clientId = value;
                return this;
            }

            public Builder AccessToken(string value)
            {
                accessToken = value;
                return this;
            }

            public Builder MerchantId(string value)
            {
                merchantId = value;
                return this;
            }

            public RevokeTokenRequest Build()
            {
                return new RevokeTokenRequest(clientId,
                    accessToken,
                    merchantId);
            }
        }
    }
}