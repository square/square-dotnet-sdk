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
    /// GiftCardActivityBlock.
    /// </summary>
    public class GiftCardActivityBlock
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GiftCardActivityBlock"/> class.
        /// </summary>
        /// <param name="reason">reason.</param>
        public GiftCardActivityBlock(
            string reason)
        {
            this.Reason = reason;
        }

        /// <summary>
        /// Indicates the reason for blocking a [gift card]($m/GiftCard).
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"GiftCardActivityBlock : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is GiftCardActivityBlock other &&
                (this.Reason == null && other.Reason == null ||
                 this.Reason?.Equals(other.Reason) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -580952757;
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
            /// Initialize Builder for GiftCardActivityBlock.
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
            /// <returns> GiftCardActivityBlock. </returns>
            public GiftCardActivityBlock Build()
            {
                return new GiftCardActivityBlock(
                    this.reason);
            }
        }
    }
}