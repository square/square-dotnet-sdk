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
    /// GiftCardActivityDeactivate.
    /// </summary>
    public class GiftCardActivityDeactivate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GiftCardActivityDeactivate"/> class.
        /// </summary>
        /// <param name="reason">reason.</param>
        public GiftCardActivityDeactivate(
            string reason)
        {
            this.Reason = reason;
        }

        /// <summary>
        /// Indicates the reason for deactivating a [gift card]($m/GiftCard).
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"GiftCardActivityDeactivate : ({string.Join(", ", toStringOutput)})";
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
            return obj is GiftCardActivityDeactivate other &&                ((this.Reason == null && other.Reason == null) || (this.Reason?.Equals(other.Reason) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -2019174826;
            hashCode = HashCode.Combine(this.Reason);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Reason = {(this.Reason == null ? "null" : this.Reason.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Reason);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string reason;

            /// <summary>
            /// Initialize Builder for GiftCardActivityDeactivate.
            /// </summary>
            /// <param name="reason"> reason. </param>
            public Builder(
                string reason)
            {
                this.reason = reason;
            }

             /// <summary>
             /// Reason.
             /// </summary>
             /// <param name="reason"> reason. </param>
             /// <returns> Builder. </returns>
            public Builder Reason(string reason)
            {
                this.reason = reason;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> GiftCardActivityDeactivate. </returns>
            public GiftCardActivityDeactivate Build()
            {
                return new GiftCardActivityDeactivate(
                    this.reason);
            }
        }
    }
}