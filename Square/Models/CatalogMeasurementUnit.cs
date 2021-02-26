
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class CatalogMeasurementUnit 
    {
        public CatalogMeasurementUnit(Models.MeasurementUnit measurementUnit = null,
            int? precision = null)
        {
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
        [JsonProperty("precision", NullValueHandling = NullValueHandling.Ignore)]
        public int? Precision { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogMeasurementUnit : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"MeasurementUnit = {(MeasurementUnit == null ? "null" : MeasurementUnit.ToString())}");
            toStringOutput.Add($"Precision = {(Precision == null ? "null" : Precision.ToString())}");
        }

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

            return obj is CatalogMeasurementUnit other &&
                ((MeasurementUnit == null && other.MeasurementUnit == null) || (MeasurementUnit?.Equals(other.MeasurementUnit) == true)) &&
                ((Precision == null && other.Precision == null) || (Precision?.Equals(other.Precision) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1544642162;

            if (MeasurementUnit != null)
            {
               hashCode += MeasurementUnit.GetHashCode();
            }

            if (Precision != null)
            {
               hashCode += Precision.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .MeasurementUnit(MeasurementUnit)
                .Precision(Precision);
            return builder;
        }

        public class Builder
        {
            private Models.MeasurementUnit measurementUnit;
            private int? precision;



            public Builder MeasurementUnit(Models.MeasurementUnit measurementUnit)
            {
                this.measurementUnit = measurementUnit;
                return this;
            }

            public Builder Precision(int? precision)
            {
                this.precision = precision;
                return this;
            }

            public CatalogMeasurementUnit Build()
            {
                return new CatalogMeasurementUnit(measurementUnit,
                    precision);
            }
        }
    }
}