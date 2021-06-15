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
        /// Gets or sets Reason.
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
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            return obj is GiftCardActivityBlock other &&
                ((this.Reason == null && other.Reason == null) || (this.Reason?.Equals(other.Reason) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -580952757;

            if (this.Reason != null)
            {
               hashCode += this.Reason.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Reason = {(this.Reason == null ? "null" : this.Reason == string.Empty ? "" : this.Reason)}");
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