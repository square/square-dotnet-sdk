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
    public class LoyaltyProgramExpirationPolicy 
    {
        public LoyaltyProgramExpirationPolicy(string expirationDuration)
        {
            ExpirationDuration = expirationDuration;
        }

        /// <summary>
        /// The duration of time before points expire, in RFC 3339 format.
        /// </summary>
        [JsonProperty("expiration_duration")]
        public string ExpirationDuration { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(ExpirationDuration);
            return builder;
        }

        public class Builder
        {
            private string expirationDuration;

            public Builder(string expirationDuration)
            {
                this.expirationDuration = expirationDuration;
            }
            public Builder ExpirationDuration(string value)
            {
                expirationDuration = value;
                return this;
            }

            public LoyaltyProgramExpirationPolicy Build()
            {
                return new LoyaltyProgramExpirationPolicy(expirationDuration);
            }
        }
    }
}