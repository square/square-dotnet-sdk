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
    /// OrderQuantityUnit.
    /// </summary>
    public class OrderQuantityUnit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderQuantityUnit"/> class.
        /// </summary>
        /// <param name="measurementUnit">measurement_unit.</param>
        /// <param name="precision">precision.</param>
        public OrderQuantityUnit(
            Models.MeasurementUnit measurementUnit = null,
            int? precision = null)
        {
            this.MeasurementUnit = measurementUnit;
            this.Precision = precision;
        }

        /// <summary>
        /// Represents a unit of measurement to use with a quantity, such as ounces
        /// or inches. Exactly one of the following fields are required: `custom_unit`,
        /// `area_unit`, `length_unit`, `volume_unit`, and `weight_unit`.
        /// </summary>
        [JsonProperty("measurement_unit", NullValueHandling = NullValueHandling.Ignore)]
        public Models.MeasurementUnit MeasurementUnit { get; }

        /// <summary>
        /// For non-integer quantities, represents the number of digits after the decimal point that are
        /// recorded for this quantity.
        /// For example, a precision of 1 allows quantities such as `"1.0"` and `"1.1"`, but not `"1.01"`.
        /// Min: 0. Max: 5.
        /// </summary>
        [JsonProperty("precision", NullValueHandling = NullValueHandling.Ignore)]
        public int? Precision { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrderQuantityUnit : ({string.Join(", ", toStringOutput)})";
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

            return obj is OrderQuantityUnit other &&
                ((this.MeasurementUnit == null && other.MeasurementUnit == null) || (this.MeasurementUnit?.Equals(other.MeasurementUnit) == true)) &&
                ((this.Precision == null && other.Precision == null) || (this.Precision?.Equals(other.Precision) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1647943202;

            if (this.MeasurementUnit != null)
            {
               hashCode += this.MeasurementUnit.GetHashCode();
            }

            if (this.Precision != null)
            {
               hashCode += this.Precision.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.MeasurementUnit = {(this.MeasurementUnit == null ? "null" : this.MeasurementUnit.ToString())}");
            toStringOutput.Add($"this.Precision = {(this.Precision == null ? "null" : this.Precision.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .MeasurementUnit(this.MeasurementUnit)
                .Precision(this.Precision);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.MeasurementUnit measurementUnit;
            private int? precision;

             /// <summary>
             /// MeasurementUnit.
             /// </summary>
             /// <param name="measurementUnit"> measurementUnit. </param>
             /// <returns> Builder. </returns>
            public Builder MeasurementUnit(Models.MeasurementUnit measurementUnit)
            {
                this.measurementUnit = measurementUnit;
                return this;
            }

             /// <summary>
             /// Precision.
             /// </summary>
             /// <param name="precision"> precision. </param>
             /// <returns> Builder. </returns>
            public Builder Precision(int? precision)
            {
                this.precision = precision;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> OrderQuantityUnit. </returns>
            public OrderQuantityUnit Build()
            {
                return new OrderQuantityUnit(
                    this.measurementUnit,
                    this.precision);
            }
        }
    }
}