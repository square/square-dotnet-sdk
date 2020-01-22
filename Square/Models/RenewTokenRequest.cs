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
    public class RenewTokenRequest 
    {
        public RenewTokenRequest(string accessToken = null)
        {
            AccessToken = accessToken;
        }

        /// <summary>
        /// The token you want to renew.
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .AccessToken(AccessToken);
            return builder;
        }

        public class Builder
        {
            private string accessToken;

            public Builder() { }
            public Builder AccessToken(string value)
            {
                accessToken = value;
                return this;
            }

            public RenewTokenRequest Build()
            {
                return new RenewTokenRequest(accessToken);
            }
        }
    }
}