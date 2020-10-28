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
    public class StandardUnitDescription 
    {
        public StandardUnitDescription(Models.MeasurementUnit unit = null,
            string name = null,
            string abbreviation = null)
        {
            Unit = unit;
            Name = name;
            Abbreviation = abbreviation;
        }

        /// <summary>
        /// Represents a unit of measurement to use with a quantity, such as ounces
        /// or inches. Exactly one of the following fields are required: `custom_unit`,
        /// `area_unit`, `length_unit`, `volume_unit`, and `weight_unit`.
        /// </summary>
        [JsonProperty("unit", NullValueHandling = NullValueHandling.Ignore)]
        public Models.MeasurementUnit Unit { get; }

        /// <summary>
        /// UI display name of the measurement unit. For example, 'Pound'.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; }

        /// <summary>
        /// UI display abbreviation for the measurement unit. For example, 'lb'.
        /// </summary>
        [JsonProperty("abbreviation", NullValueHandling = NullValueHandling.Ignore)]
        public string Abbreviation { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Unit(Unit)
                .Name(Name)
                .Abbreviation(Abbreviation);
            return builder;
        }

        public class Builder
        {
            private Models.MeasurementUnit unit;
            private string name;
            private string abbreviation;



            public Builder Unit(Models.MeasurementUnit unit)
            {
                this.unit = unit;
                return this;
            }

            public Builder Name(string name)
            {
                this.name = name;
                return this;
            }

            public Builder Abbreviation(string abbreviation)
            {
                this.abbreviation = abbreviation;
                return this;
            }

            public StandardUnitDescription Build()
            {
                return new StandardUnitDescription(unit,
                    name,
                    abbreviation);
            }
        }
    }
}