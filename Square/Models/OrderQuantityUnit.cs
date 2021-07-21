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
        /// <param name="catalogVersion">catalog_version.</param>
        public OrderQuantityUnit(
            Models.MeasurementUnit measurementUnit = null,
            int? precision = null,
            long? catalogVersion = null)
        {
            this.MeasurementUnit = measurementUnit;
            this.Precision = precision;
            this.CatalogVersion = catalogVersion;
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

        /// <summary>
        /// The version of the catalog object that this measurement unit references.
        /// This field is set when this is a catalog-backed measurement unit.
        /// </summary>
        [JsonProperty("catalog_version", NullValueHandling = NullValueHandling.Ignore)]
        public long? CatalogVersion { get; }

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
                ((this.Precision == null && other.Precision == null) || (this.Precision?.Equals(other.Precision) == true)) &&
                ((this.CatalogVersion == null && other.CatalogVersion == null) || (this.CatalogVersion?.Equals(other.CatalogVersion) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 174888101;

            if (this.MeasurementUnit != null)
            {
               hashCode += this.MeasurementUnit.GetHashCode();
            }

            if (this.Precision != null)
            {
               hashCode += this.Precision.GetHashCode();
            }

            if (this.CatalogVersion != null)
            {
               hashCode += this.CatalogVersion.GetHashCode();
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
            toStringOutput.Add($"this.CatalogVersion = {(this.CatalogVersion == null ? "null" : this.CatalogVersion.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .MeasurementUnit(this.MeasurementUnit)
                .Precision(this.Precision)
                .CatalogVersion(this.CatalogVersion);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.MeasurementUnit measurementUnit;
            private int? precision;
            private long? catalogVersion;

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
             /// CatalogVersion.
             /// </summary>
             /// <param name="catalogVersion"> catalogVersion. </param>
             /// <returns> Builder. </returns>
            public Builder CatalogVersion(long? catalogVersion)
            {
                this.catalogVersion = catalogVersion;
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
                    this.precision,
                    this.catalogVersion);
            }
        }
    }
}