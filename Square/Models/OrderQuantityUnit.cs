
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
    public class OrderQuantityUnit 
    {
        public OrderQuantityUnit(Models.MeasurementUnit measurementUnit = null,
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
        /// For non-integer quantities, represents the number of digits after the decimal point that are
        /// recorded for this quantity.
        /// For example, a precision of 1 allows quantities like `"1.0"` and `"1.1"`, but not `"1.01"`.
        /// Min: 0. Max: 5.
        /// </summary>
        [JsonProperty("precision", NullValueHandling = NullValueHandling.Ignore)]
        public int? Precision { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrderQuantityUnit : ({string.Join(", ", toStringOutput)})";
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

            return obj is OrderQuantityUnit other &&
                ((MeasurementUnit == null && other.MeasurementUnit == null) || (MeasurementUnit?.Equals(other.MeasurementUnit) == true)) &&
                ((Precision == null && other.Precision == null) || (Precision?.Equals(other.Precision) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1647943202;

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

            public OrderQuantityUnit Build()
            {
                return new OrderQuantityUnit(measurementUnit,
                    precision);
            }
        }
    }
}