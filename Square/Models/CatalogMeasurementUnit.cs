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
        [JsonProperty("measurement_unit")]
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

            public CatalogMeasurementUnit Build()
            {
                return new CatalogMeasurementUnit(measurementUnit,
                    precision);
            }
        }
    }
}