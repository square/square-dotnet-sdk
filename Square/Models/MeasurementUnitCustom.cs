
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
    public class MeasurementUnitCustom 
    {
        public MeasurementUnitCustom(string name,
            string abbreviation)
        {
            Name = name;
            Abbreviation = abbreviation;
        }

        /// <summary>
        /// The name of the custom unit, for example "bushel".
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// The abbreviation of the custom unit, such as "bsh" (bushel). This appears
        /// in the cart for the Point of Sale app, and in reports.
        /// </summary>
        [JsonProperty("abbreviation")]
        public string Abbreviation { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"MeasurementUnitCustom : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
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

            return obj is MeasurementUnitCustom other &&
                ((Name == null && other.Name == null) || (Name?.Equals(other.Name) == true)) &&
                ((Abbreviation == null && other.Abbreviation == null) || (Abbreviation?.Equals(other.Abbreviation) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -123623718;

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
            var builder = new Builder(Name,
                Abbreviation);
            return builder;
        }

        public class Builder
        {
            private string name;
            private string abbreviation;

            public Builder(string name,
                string abbreviation)
            {
                this.name = name;
                this.abbreviation = abbreviation;
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

            public MeasurementUnitCustom Build()
            {
                return new MeasurementUnitCustom(name,
                    abbreviation);
            }
        }
    }
}