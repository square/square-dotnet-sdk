
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LoyaltyProgramExpirationPolicy : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"ExpirationDuration = {(ExpirationDuration == null ? "null" : ExpirationDuration == string.Empty ? "" : ExpirationDuration)}");
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

            return obj is LoyaltyProgramExpirationPolicy other &&
                ((ExpirationDuration == null && other.ExpirationDuration == null) || (ExpirationDuration?.Equals(other.ExpirationDuration) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1618599332;

            if (ExpirationDuration != null)
            {
               hashCode += ExpirationDuration.GetHashCode();
            }

            return hashCode;
        }

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

            public Builder ExpirationDuration(string expirationDuration)
            {
                this.expirationDuration = expirationDuration;
                return this;
            }

            public LoyaltyProgramExpirationPolicy Build()
            {
                return new LoyaltyProgramExpirationPolicy(expirationDuration);
            }
        }
    }
}