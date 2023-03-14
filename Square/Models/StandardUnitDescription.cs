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
    /// StandardUnitDescription.
    /// </summary>
    public class StandardUnitDescription
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="StandardUnitDescription"/> class.
        /// </summary>
        /// <param name="unit">unit.</param>
        /// <param name="name">name.</param>
        /// <param name="abbreviation">abbreviation.</param>
        public StandardUnitDescription(
            Models.MeasurementUnit unit = null,
            string name = null,
            string abbreviation = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "name", false },
                { "abbreviation", false }
            };

            this.Unit = unit;
            if (name != null)
            {
                shouldSerialize["name"] = true;
                this.Name = name;
            }

            if (abbreviation != null)
            {
                shouldSerialize["abbreviation"] = true;
                this.Abbreviation = abbreviation;
            }

        }
        internal StandardUnitDescription(Dictionary<string, bool> shouldSerialize,
            Models.MeasurementUnit unit = null,
            string name = null,
            string abbreviation = null)
        {
            this.shouldSerialize = shouldSerialize;
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
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// UI display abbreviation for the measurement unit. For example, 'lb'.
        /// </summary>
        [JsonProperty("abbreviation")]
        public string Abbreviation { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"StandardUnitDescription : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeName()
        {
            return this.shouldSerialize["name"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAbbreviation()
        {
            return this.shouldSerialize["abbreviation"];
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

            return obj is StandardUnitDescription other &&
                ((this.Unit == null && other.Unit == null) || (this.Unit?.Equals(other.Unit) == true)) &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.Abbreviation == null && other.Abbreviation == null) || (this.Abbreviation?.Equals(other.Abbreviation) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -845994350;
            hashCode = HashCode.Combine(this.Unit, this.Name, this.Abbreviation);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Unit = {(this.Unit == null ? "null" : this.Unit.ToString())}");
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name == string.Empty ? "" : this.Name)}");
            toStringOutput.Add($"this.Abbreviation = {(this.Abbreviation == null ? "null" : this.Abbreviation == string.Empty ? "" : this.Abbreviation)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Unit(this.Unit)
                .Name(this.Name)
                .Abbreviation(this.Abbreviation);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "name", false },
                { "abbreviation", false },
            };

            private Models.MeasurementUnit unit;
            private string name;
            private string abbreviation;

             /// <summary>
             /// Unit.
             /// </summary>
             /// <param name="unit"> unit. </param>
             /// <returns> Builder. </returns>
            public Builder Unit(Models.MeasurementUnit unit)
            {
                this.unit = unit;
                return this;
            }

             /// <summary>
             /// Name.
             /// </summary>
             /// <param name="name"> name. </param>
             /// <returns> Builder. </returns>
            public Builder Name(string name)
            {
                shouldSerialize["name"] = true;
                this.name = name;
                return this;
            }

             /// <summary>
             /// Abbreviation.
             /// </summary>
             /// <param name="abbreviation"> abbreviation. </param>
             /// <returns> Builder. </returns>
            public Builder Abbreviation(string abbreviation)
            {
                shouldSerialize["abbreviation"] = true;
                this.abbreviation = abbreviation;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetName()
            {
                this.shouldSerialize["name"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetAbbreviation()
            {
                this.shouldSerialize["abbreviation"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> StandardUnitDescription. </returns>
            public StandardUnitDescription Build()
            {
                return new StandardUnitDescription(shouldSerialize,
                    this.unit,
                    this.name,
                    this.abbreviation);
            }
        }
    }
}