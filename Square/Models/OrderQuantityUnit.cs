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
    /// OrderQuantityUnit.
    /// </summary>
    public class OrderQuantityUnit
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderQuantityUnit"/> class.
        /// </summary>
        /// <param name="measurementUnit">measurement_unit.</param>
        /// <param name="precision">precision.</param>
        /// <param name="catalogObjectId">catalog_object_id.</param>
        /// <param name="catalogVersion">catalog_version.</param>
        public OrderQuantityUnit(
            Models.MeasurementUnit measurementUnit = null,
            int? precision = null,
            string catalogObjectId = null,
            long? catalogVersion = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "precision", false },
                { "catalog_object_id", false },
                { "catalog_version", false }
            };

            this.MeasurementUnit = measurementUnit;
            if (precision != null)
            {
                shouldSerialize["precision"] = true;
                this.Precision = precision;
            }

            if (catalogObjectId != null)
            {
                shouldSerialize["catalog_object_id"] = true;
                this.CatalogObjectId = catalogObjectId;
            }

            if (catalogVersion != null)
            {
                shouldSerialize["catalog_version"] = true;
                this.CatalogVersion = catalogVersion;
            }

        }
        internal OrderQuantityUnit(Dictionary<string, bool> shouldSerialize,
            Models.MeasurementUnit measurementUnit = null,
            int? precision = null,
            string catalogObjectId = null,
            long? catalogVersion = null)
        {
            this.shouldSerialize = shouldSerialize;
            MeasurementUnit = measurementUnit;
            Precision = precision;
            CatalogObjectId = catalogObjectId;
            CatalogVersion = catalogVersion;
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
        [JsonProperty("precision")]
        public int? Precision { get; }

        /// <summary>
        /// The catalog object ID referencing the
        /// [CatalogMeasurementUnit](entity:CatalogMeasurementUnit).
        /// This field is set when this is a catalog-backed measurement unit.
        /// </summary>
        [JsonProperty("catalog_object_id")]
        public string CatalogObjectId { get; }

        /// <summary>
        /// The version of the catalog object that this measurement unit references.
        /// This field is set when this is a catalog-backed measurement unit.
        /// </summary>
        [JsonProperty("catalog_version")]
        public long? CatalogVersion { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrderQuantityUnit : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePrecision()
        {
            return this.shouldSerialize["precision"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCatalogObjectId()
        {
            return this.shouldSerialize["catalog_object_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCatalogVersion()
        {
            return this.shouldSerialize["catalog_version"];
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
            return obj is OrderQuantityUnit other &&                ((this.MeasurementUnit == null && other.MeasurementUnit == null) || (this.MeasurementUnit?.Equals(other.MeasurementUnit) == true)) &&
                ((this.Precision == null && other.Precision == null) || (this.Precision?.Equals(other.Precision) == true)) &&
                ((this.CatalogObjectId == null && other.CatalogObjectId == null) || (this.CatalogObjectId?.Equals(other.CatalogObjectId) == true)) &&
                ((this.CatalogVersion == null && other.CatalogVersion == null) || (this.CatalogVersion?.Equals(other.CatalogVersion) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1360372013;
            hashCode = HashCode.Combine(this.MeasurementUnit, this.Precision, this.CatalogObjectId, this.CatalogVersion);

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
            toStringOutput.Add($"this.CatalogObjectId = {(this.CatalogObjectId == null ? "null" : this.CatalogObjectId)}");
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
                .CatalogObjectId(this.CatalogObjectId)
                .CatalogVersion(this.CatalogVersion);
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
                { "catalog_object_id", false },
                { "catalog_version", false },
            };

            private Models.MeasurementUnit measurementUnit;
            private int? precision;
            private string catalogObjectId;
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
                shouldSerialize["precision"] = true;
                this.precision = precision;
                return this;
            }

             /// <summary>
             /// CatalogObjectId.
             /// </summary>
             /// <param name="catalogObjectId"> catalogObjectId. </param>
             /// <returns> Builder. </returns>
            public Builder CatalogObjectId(string catalogObjectId)
            {
                shouldSerialize["catalog_object_id"] = true;
                this.catalogObjectId = catalogObjectId;
                return this;
            }

             /// <summary>
             /// CatalogVersion.
             /// </summary>
             /// <param name="catalogVersion"> catalogVersion. </param>
             /// <returns> Builder. </returns>
            public Builder CatalogVersion(long? catalogVersion)
            {
                shouldSerialize["catalog_version"] = true;
                this.catalogVersion = catalogVersion;
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
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCatalogObjectId()
            {
                this.shouldSerialize["catalog_object_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCatalogVersion()
            {
                this.shouldSerialize["catalog_version"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> OrderQuantityUnit. </returns>
            public OrderQuantityUnit Build()
            {
                return new OrderQuantityUnit(shouldSerialize,
                    this.measurementUnit,
                    this.precision,
                    this.catalogObjectId,
                    this.catalogVersion);
            }
        }
    }
}