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
    /// GiftCardActivityUnblock.
    /// </summary>
    public class GiftCardActivityUnblock
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GiftCardActivityUnblock"/> class.
        /// </summary>
        /// <param name="reason">reason.</param>
        public GiftCardActivityUnblock(string reason)
        {
            this.Reason = reason;
        }

        /// <summary>
        /// Indicates the reason for unblocking a [gift card]($m/GiftCard).
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"GiftCardActivityUnblock : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is GiftCardActivityUnblock other
                && (
                    this.Reason == null && other.Reason == null
                    || this.Reason?.Equals(other.Reason) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1445456236;
            hashCode = HashCode.Combine(hashCode, this.Reason);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Reason = {this.Reason ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(this.Reason);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string reason;

            /// <summary>
            /// Initialize Builder for GiftCardActivityUnblock.
            /// </summary>
            /// <param name="reason"> reason. </param>
            public Builder(string reason)
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
            /// <returns> GiftCardActivityUnblock. </returns>
            public GiftCardActivityUnblock Build()
            {
                return new GiftCardActivityUnblock(this.reason);
            }
        }
    }
}
