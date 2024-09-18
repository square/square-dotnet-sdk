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

namespace Square.Models
{
    /// <summary>
    /// CompletePaymentRequest.
    /// </summary>
    public class CompletePaymentRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="CompletePaymentRequest"/> class.
        /// </summary>
        /// <param name="versionToken">version_token.</param>
        public CompletePaymentRequest(
            string versionToken = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "version_token", false }
            };

            if (versionToken != null)
            {
                shouldSerialize["version_token"] = true;
                this.VersionToken = versionToken;
            }

        }
        internal CompletePaymentRequest(Dictionary<string, bool> shouldSerialize,
            string versionToken = null)
        {
            this.shouldSerialize = shouldSerialize;
            VersionToken = versionToken;
        }

        /// <summary>
        /// Used for optimistic concurrency. This opaque token identifies the current `Payment`
        /// version that the caller expects. If the server has a different version of the Payment,
        /// the update fails and a response with a VERSION_MISMATCH error is returned.
        /// </summary>
        [JsonProperty("version_token")]
        public string VersionToken { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CompletePaymentRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeVersionToken()
        {
            return this.shouldSerialize["version_token"];
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
            return obj is CompletePaymentRequest other &&                ((this.VersionToken == null && other.VersionToken == null) || (this.VersionToken?.Equals(other.VersionToken) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 916056243;
            hashCode = HashCode.Combine(this.VersionToken);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.VersionToken = {(this.VersionToken == null ? "null" : this.VersionToken)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .VersionToken(this.VersionToken);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "version_token", false },
            };

            private string versionToken;

             /// <summary>
             /// VersionToken.
             /// </summary>
             /// <param name="versionToken"> versionToken. </param>
             /// <returns> Builder. </returns>
            public Builder VersionToken(string versionToken)
            {
                shouldSerialize["version_token"] = true;
                this.versionToken = versionToken;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetVersionToken()
            {
                this.shouldSerialize["version_token"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CompletePaymentRequest. </returns>
            public CompletePaymentRequest Build()
            {
                return new CompletePaymentRequest(shouldSerialize,
                    this.versionToken);
            }
        }
    }
}