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
    /// MeasurementUnitCustom.
    /// </summary>
    public class MeasurementUnitCustom
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MeasurementUnitCustom"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="abbreviation">abbreviation.</param>
        public MeasurementUnitCustom(
            string name,
            string abbreviation)
        {
            this.Name = name;
            this.Abbreviation = abbreviation;
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"MeasurementUnitCustom : ({string.Join(", ", toStringOutput)})";
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

            return obj is MeasurementUnitCustom other &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.Abbreviation == null && other.Abbreviation == null) || (this.Abbreviation?.Equals(other.Abbreviation) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -123623718;

            if (this.Name != null)
            {
               hashCode += this.Name.GetHashCode();
            }

            if (this.Abbreviation != null)
            {
               hashCode += this.Abbreviation.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name == string.Empty ? "" : this.Name)}");
            toStringOutput.Add($"this.Abbreviation = {(this.Abbreviation == null ? "null" : this.Abbreviation == string.Empty ? "" : this.Abbreviation)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Name,
                this.Abbreviation);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string name;
            private string abbreviation;

            public Builder(
                string name,
                string abbreviation)
            {
                this.name = name;
                this.abbreviation = abbreviation;
            }

             /// <summary>
             /// Name.
             /// </summary>
             /// <param name="name"> name. </param>
             /// <returns> Builder. </returns>
            public Builder Name(string name)
            {
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
                this.abbreviation = abbreviation;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> MeasurementUnitCustom. </returns>
            public MeasurementUnitCustom Build()
            {
                return new MeasurementUnitCustom(
                    this.name,
                    this.abbreviation);
            }
        }
    }
}