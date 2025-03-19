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
using Square.Legacy;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// ClearpayDetails.
    /// </summary>
    public class ClearpayDetails
    {
        private readonly Dictionary<string, bool> shouldSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClearpayDetails"/> class.
        /// </summary>
        /// <param name="emailAddress">email_address.</param>
        public ClearpayDetails(string emailAddress = null)
        {
            shouldSerialize = new Dictionary<string, bool> { { "email_address", false } };

            if (emailAddress != null)
            {
                shouldSerialize["email_address"] = true;
                this.EmailAddress = emailAddress;
            }
        }

        internal ClearpayDetails(
            Dictionary<string, bool> shouldSerialize,
            string emailAddress = null
        )
        {
            this.shouldSerialize = shouldSerialize;
            EmailAddress = emailAddress;
        }

        /// <summary>
        /// Email address on the buyer's Clearpay account.
        /// </summary>
        [JsonProperty("email_address")]
        public string EmailAddress { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"ClearpayDetails : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEmailAddress()
        {
            return this.shouldSerialize["email_address"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is ClearpayDetails other
                && (
                    this.EmailAddress == null && other.EmailAddress == null
                    || this.EmailAddress?.Equals(other.EmailAddress) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1541165303;
            hashCode = HashCode.Combine(hashCode, this.EmailAddress);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.EmailAddress = {this.EmailAddress ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder().EmailAddress(this.EmailAddress);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "email_address", false },
            };

            private string emailAddress;

            /// <summary>
            /// EmailAddress.
            /// </summary>
            /// <param name="emailAddress"> emailAddress. </param>
            /// <returns> Builder. </returns>
            public Builder EmailAddress(string emailAddress)
            {
                shouldSerialize["email_address"] = true;
                this.emailAddress = emailAddress;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetEmailAddress()
            {
                this.shouldSerialize["email_address"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ClearpayDetails. </returns>
            public ClearpayDetails Build()
            {
                return new ClearpayDetails(shouldSerialize, this.emailAddress);
            }
        }
    }
}
