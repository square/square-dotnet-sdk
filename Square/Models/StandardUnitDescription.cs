
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"StandardUnitDescription : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Unit = {(Unit == null ? "null" : Unit.ToString())}");
            toStringOutput.Add($"Name = {(Name == null ? "null" : Name == string.Empty ? "" : Name)}");
            toStringOutput.Add($"Abbreviation = {(Abbreviation == null ? "null" : Abbreviation == string.Empty ? "" : Abbreviation)}");
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

            return obj is StandardUnitDescription other &&
                ((Unit == null && other.Unit == null) || (Unit?.Equals(other.Unit) == true)) &&
                ((Name == null && other.Name == null) || (Name?.Equals(other.Name) == true)) &&
                ((Abbreviation == null && other.Abbreviation == null) || (Abbreviation?.Equals(other.Abbreviation) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -845994350;

            if (Unit != null)
            {
               hashCode += Unit.GetHashCode();
            }

            if (Name != null)
            {
               hashCode += Name.GetHashCode();
            }

            if (Abbreviation != null)
            {
               hashCode += Abbreviation.GetHashCode();
            }

            return hashCode;
        }

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