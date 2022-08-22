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
    /// ClearpayDetails.
    /// </summary>
    public class ClearpayDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClearpayDetails"/> class.
        /// </summary>
        /// <param name="emailAddress">email_address.</param>
        public ClearpayDetails(
            string emailAddress = null)
        {
            this.EmailAddress = emailAddress;
        }

        /// <summary>
        /// Email address on the buyer's Clearpay account.
        /// </summary>
        [JsonProperty("email_address", NullValueHandling = NullValueHandling.Ignore)]
        public string EmailAddress { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ClearpayDetails : ({string.Join(", ", toStringOutput)})";
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

            return obj is ClearpayDetails other &&
                ((this.EmailAddress == null && other.EmailAddress == null) || (this.EmailAddress?.Equals(other.EmailAddress) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1541165303;
            hashCode = HashCode.Combine(this.EmailAddress);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.EmailAddress = {(this.EmailAddress == null ? "null" : this.EmailAddress == string.Empty ? "" : this.EmailAddress)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .EmailAddress(this.EmailAddress);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string emailAddress;

             /// <summary>
             /// EmailAddress.
             /// </summary>
             /// <param name="emailAddress"> emailAddress. </param>
             /// <returns> Builder. </returns>
            public Builder EmailAddress(string emailAddress)
            {
                this.emailAddress = emailAddress;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ClearpayDetails. </returns>
            public ClearpayDetails Build()
            {
                return new ClearpayDetails(
                    this.emailAddress);
            }
        }
    }
}