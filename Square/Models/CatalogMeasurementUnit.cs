namespace Square.Models
{
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

    /// <summary>
    /// CatalogMeasurementUnit.
    /// </summary>
    public class CatalogMeasurementUnit
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogMeasurementUnit"/> class.
        /// </summary>
        /// <param name="measurementUnit">measurement_unit.</param>
        /// <param name="precision">precision.</param>
        public CatalogMeasurementUnit(
            Models.MeasurementUnit measurementUnit = null,
            int? precision = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "precision", false }
            };

            this.MeasurementUnit = measurementUnit;
            if (precision != null)
            {
                shouldSerialize["precision"] = true;
                this.Precision = precision;
            }

        }
        internal CatalogMeasurementUnit(Dictionary<string, bool> shouldSerialize,
            Models.MeasurementUnit measurementUnit = null,
            int? precision = null)
        {
            this.shouldSerialize = shouldSerialize;
            MeasurementUnit = measurementUnit;
            Precision = precision;
        }

        /// <summary>
        /// Represents a unit of measurement to use with a quantity, such as ounces
        /// or inches. Exactly one of the following fields are required: `custom_unit`,
        /// `area_unit`, `length_unit`, `volume_unit`, and `weight_unit`.
        /// </summary>
        [JsonProperty("measurement_unit", NullValueHandling = NullValueHandling.Ignore)]
        public Models.MeasurementUnit MeasurementUnit { get; }

        /// <summary>
        /// An integer between 0 and 5 that represents the maximum number of
        /// positions allowed after the decimal in quantities measured with this unit.
        /// For example:
        /// - if the precision is 0, the quantity can be 1, 2, 3, etc.
        /// - if the precision is 1, the quantity can be 0.1, 0.2, etc.
        /// - if the precision is 2, the quantity can be 0.01, 0.12, etc.
        /// Default: 3
        /// </summary>
        [JsonProperty("precision")]
        public int? Precision { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogMeasurementUnit : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePrecision()
        {
            return this.shouldSerialize["precision"];
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
            return obj is CatalogMeasurementUnit other &&                ((this.MeasurementUnit == null && other.MeasurementUnit == null) || (this.MeasurementUnit?.Equals(other.MeasurementUnit) == true)) &&
                ((this.Precision == null && other.Precision == null) || (this.Precision?.Equals(other.Precision) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1544642162;
            hashCode = HashCode.Combine(this.MeasurementUnit, this.Precision);

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
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "precision", false },
            };

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
                shouldSerialize["precision"] = true;
                this.precision = precision;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetPrecision()
            {
                this.shouldSerialize["precision"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogMeasurementUnit. </returns>
            public CatalogMeasurementUnit Build()
            {
                return new CatalogMeasurementUnit(shouldSerialize,
                    this.measurementUnit,
                    this.precision);
            }
        }
    }
}