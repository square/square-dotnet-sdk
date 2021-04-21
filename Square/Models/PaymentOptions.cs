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
    /// PaymentOptions.
    /// </summary>
    public class PaymentOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentOptions"/> class.
        /// </summary>
        /// <param name="autocomplete">autocomplete.</param>
        public PaymentOptions(
            bool? autocomplete = null)
        {
            this.Autocomplete = autocomplete;
        }

        /// <summary>
        /// Indicates whether the `Payment` objects created from this `TerminalCheckout` are automatically
        /// `COMPLETED` or left in an `APPROVED` state for later modification.
        /// </summary>
        [JsonProperty("autocomplete", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Autocomplete { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"PaymentOptions : ({string.Join(", ", toStringOutput)})";
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

            return obj is PaymentOptions other &&
                ((this.Autocomplete == null && other.Autocomplete == null) || (this.Autocomplete?.Equals(other.Autocomplete) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 449968409;

            if (this.Autocomplete != null)
            {
               hashCode += this.Autocomplete.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Autocomplete = {(this.Autocomplete == null ? "null" : this.Autocomplete.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Autocomplete(this.Autocomplete);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private bool? autocomplete;

             /// <summary>
             /// Autocomplete.
             /// </summary>
             /// <param name="autocomplete"> autocomplete. </param>
             /// <returns> Builder. </returns>
            public Builder Autocomplete(bool? autocomplete)
            {
                this.autocomplete = autocomplete;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> PaymentOptions. </returns>
            public PaymentOptions Build()
            {
                return new PaymentOptions(
                    this.autocomplete);
            }
        }
    }
}