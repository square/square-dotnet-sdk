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
    /// OfflinePaymentDetails.
    /// </summary>
    public class OfflinePaymentDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OfflinePaymentDetails"/> class.
        /// </summary>
        /// <param name="clientCreatedAt">client_created_at.</param>
        public OfflinePaymentDetails(
            string clientCreatedAt = null)
        {
            this.ClientCreatedAt = clientCreatedAt;
        }

        /// <summary>
        /// The client-side timestamp of when the offline payment was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("client_created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string ClientCreatedAt { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"OfflinePaymentDetails : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is OfflinePaymentDetails other &&
                (this.ClientCreatedAt == null && other.ClientCreatedAt == null ||
                 this.ClientCreatedAt?.Equals(other.ClientCreatedAt) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 513642090;
            hashCode = HashCode.Combine(hashCode, this.ClientCreatedAt);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ClientCreatedAt = {this.ClientCreatedAt ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .ClientCreatedAt(this.ClientCreatedAt);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string clientCreatedAt;

             /// <summary>
             /// ClientCreatedAt.
             /// </summary>
             /// <param name="clientCreatedAt"> clientCreatedAt. </param>
             /// <returns> Builder. </returns>
            public Builder ClientCreatedAt(string clientCreatedAt)
            {
                this.clientCreatedAt = clientCreatedAt;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> OfflinePaymentDetails. </returns>
            public OfflinePaymentDetails Build()
            {
                return new OfflinePaymentDetails(
                    this.clientCreatedAt);
            }
        }
    }
}