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
    /// QuantityRatio.
    /// </summary>
    public class QuantityRatio
    {
        private readonly Dictionary<string, bool> shouldSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuantityRatio"/> class.
        /// </summary>
        /// <param name="quantity">quantity.</param>
        /// <param name="quantityDenominator">quantity_denominator.</param>
        public QuantityRatio(int? quantity = null, int? quantityDenominator = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "quantity", false },
                { "quantity_denominator", false },
            };

            if (quantity != null)
            {
                shouldSerialize["quantity"] = true;
                this.Quantity = quantity;
            }

            if (quantityDenominator != null)
            {
                shouldSerialize["quantity_denominator"] = true;
                this.QuantityDenominator = quantityDenominator;
            }
        }

        internal QuantityRatio(
            Dictionary<string, bool> shouldSerialize,
            int? quantity = null,
            int? quantityDenominator = null
        )
        {
            this.shouldSerialize = shouldSerialize;
            Quantity = quantity;
            QuantityDenominator = quantityDenominator;
        }

        /// <summary>
        /// The whole or fractional quantity as the numerator.
        /// </summary>
        [JsonProperty("quantity")]
        public int? Quantity { get; }

        /// <summary>
        /// The whole or fractional quantity as the denominator.
        /// With fractional quantity this field is the denominator and quantity is the numerator.
        /// The default value is `1`. For example, when `quantity=3` and `quantity_denominator` is unspecified,
        /// the quantity ratio is `3` or `3/1`.
        /// </summary>
        [JsonProperty("quantity_denominator")]
        public int? QuantityDenominator { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"QuantityRatio : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeQuantity()
        {
            return this.shouldSerialize["quantity"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeQuantityDenominator()
        {
            return this.shouldSerialize["quantity_denominator"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is QuantityRatio other
                && (
                    this.Quantity == null && other.Quantity == null
                    || this.Quantity?.Equals(other.Quantity) == true
                )
                && (
                    this.QuantityDenominator == null && other.QuantityDenominator == null
                    || this.QuantityDenominator?.Equals(other.QuantityDenominator) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -151581231;
            hashCode = HashCode.Combine(hashCode, this.Quantity, this.QuantityDenominator);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add(
                $"this.Quantity = {(this.Quantity == null ? "null" : this.Quantity.ToString())}"
            );
            toStringOutput.Add(
                $"this.QuantityDenominator = {(this.QuantityDenominator == null ? "null" : this.QuantityDenominator.ToString())}"
            );
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
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "quantity", false },
                { "quantity_denominator", false },
            };

            private int? quantity;
            private int? quantityDenominator;

            /// <summary>
            /// Quantity.
            /// </summary>
            /// <param name="quantity"> quantity. </param>
            /// <returns> Builder. </returns>
            public Builder Quantity(int? quantity)
            {
                shouldSerialize["quantity"] = true;
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
                shouldSerialize["quantity_denominator"] = true;
                this.quantityDenominator = quantityDenominator;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetQuantity()
            {
                this.shouldSerialize["quantity"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetQuantityDenominator()
            {
                this.shouldSerialize["quantity_denominator"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> QuantityRatio. </returns>
            public QuantityRatio Build()
            {
                return new QuantityRatio(shouldSerialize, this.quantity, this.quantityDenominator);
            }
        }
    }
}
