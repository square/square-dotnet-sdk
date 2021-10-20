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
    /// QuantityRatio.
    /// </summary>
    public class QuantityRatio
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuantityRatio"/> class.
        /// </summary>
        /// <param name="quantity">quantity.</param>
        /// <param name="quantityDenominator">quantity_denominator.</param>
        public QuantityRatio(
            int? quantity = null,
            int? quantityDenominator = null)
        {
            this.Quantity = quantity;
            this.QuantityDenominator = quantityDenominator;
        }

        /// <summary>
        /// The whole or fractional quantity as the numerator.
        /// </summary>
        [JsonProperty("quantity", NullValueHandling = NullValueHandling.Ignore)]
        public int? Quantity { get; }

        /// <summary>
        /// The whole or fractional quantity as the denominator.
        /// In the case of fractional quantity this field is the denominator and quantity is the numerator.
        /// When unspecified, the value is `1`. For example, when `quantity=3` and `quantity_donominator` is unspecified,
        /// the quantity ratio is `3` or `3/1`.
        /// </summary>
        [JsonProperty("quantity_denominator", NullValueHandling = NullValueHandling.Ignore)]
        public int? QuantityDenominator { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"QuantityRatio : ({string.Join(", ", toStringOutput)})";
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

            return obj is QuantityRatio other &&
                ((this.Quantity == null && other.Quantity == null) || (this.Quantity?.Equals(other.Quantity) == true)) &&
                ((this.QuantityDenominator == null && other.QuantityDenominator == null) || (this.QuantityDenominator?.Equals(other.QuantityDenominator) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -151581231;
            hashCode = HashCode.Combine(this.Quantity, this.QuantityDenominator);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Quantity = {(this.Quantity == null ? "null" : this.Quantity.ToString())}");
            toStringOutput.Add($"this.QuantityDenominator = {(this.QuantityDenominator == null ? "null" : this.QuantityDenominator.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Quantity(this.Quantity)
                .QuantityDenominator(this.QuantityDenominator);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private int? quantity;
            private int? quantityDenominator;

             /// <summary>
             /// Quantity.
             /// </summary>
             /// <param name="quantity"> quantity. </param>
             /// <returns> Builder. </returns>
            public Builder Quantity(int? quantity)
            {
                this.quantity = quantity;
                return this;
            }

             /// <summary>
             /// QuantityDenominator.
             /// </summary>
             /// <param name="quantityDenominator"> quantityDenominator. </param>
             /// <returns> Builder. </returns>
            public Builder QuantityDenominator(int? quantityDenominator)
            {
                this.quantityDenominator = quantityDenominator;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> QuantityRatio. </returns>
            public QuantityRatio Build()
            {
                return new QuantityRatio(
                    this.quantity,
                    this.quantityDenominator);
            }
        }
    }
}