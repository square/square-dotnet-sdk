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
        [JsonProperty("measurement_unit")]
        public Models.MeasurementUnit MeasurementUnit { get; }

        /// <summary>
        /// For non-integer quantities, represents the number of digits after the decimal point that are
        /// recorded for this quantity.
        /// For example, a precision of 1 allows quantities like `"1.0"` and `"1.1"`, but not `"1.01"`.
        /// Min: 0. Max: 5.
        /// </summary>
        [JsonProperty("precision")]
        public int? Precision { get; }

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

            public Builder() { }
            public Builder MeasurementUnit(Models.MeasurementUnit value)
            {
                measurementUnit = value;
                return this;
            }

            public Builder Precision(int? value)
            {
                precision = value;
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