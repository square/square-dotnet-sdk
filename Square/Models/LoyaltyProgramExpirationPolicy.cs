namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// LoyaltyProgramExpirationPolicy.
    /// </summary>
    public class LoyaltyProgramExpirationPolicy
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoyaltyProgramExpirationPolicy"/> class.
        /// </summary>
        /// <param name="expirationDuration">expiration_duration.</param>
        public LoyaltyProgramExpirationPolicy(
            string expirationDuration)
        {
            this.ExpirationDuration = expirationDuration;
        }

        /// <summary>
        /// The number of months before points expire, in `P[n]M` RFC 3339 duration format. For example, a value of `P12M` represents a duration of 12 months.
        /// Points are valid through the last day of the month in which they are scheduled to expire. For example, with a  `P12M` duration, points earned on July 6, 2020 expire on August 1, 2021.
        /// </summary>
        [JsonProperty("expiration_duration")]
        public string ExpirationDuration { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LoyaltyProgramExpirationPolicy : ({string.Join(", ", toStringOutput)})";
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

            return obj is LoyaltyProgramExpirationPolicy other &&
                ((this.ExpirationDuration == null && other.ExpirationDuration == null) || (this.ExpirationDuration?.Equals(other.ExpirationDuration) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1618599332;
            hashCode = HashCode.Combine(this.ExpirationDuration);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ExpirationDuration = {(this.ExpirationDuration == null ? "null" : this.ExpirationDuration == string.Empty ? "" : this.ExpirationDuration)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.ExpirationDuration);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string expirationDuration;

            public Builder(
                string expirationDuration)
            {
                this.expirationDuration = expirationDuration;
            }

             /// <summary>
             /// ExpirationDuration.
             /// </summary>
             /// <param name="expirationDuration"> expirationDuration. </param>
             /// <returns> Builder. </returns>
            public Builder ExpirationDuration(string expirationDuration)
            {
                this.expirationDuration = expirationDuration;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> LoyaltyProgramExpirationPolicy. </returns>
            public LoyaltyProgramExpirationPolicy Build()
            {
                return new LoyaltyProgramExpirationPolicy(
                    this.expirationDuration);
            }
        }
    }
}