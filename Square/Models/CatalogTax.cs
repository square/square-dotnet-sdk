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
    /// CatalogTax.
    /// </summary>
    public class CatalogTax
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogTax"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="calculationPhase">calculation_phase.</param>
        /// <param name="inclusionType">inclusion_type.</param>
        /// <param name="percentage">percentage.</param>
        /// <param name="appliesToCustomAmounts">applies_to_custom_amounts.</param>
        /// <param name="enabled">enabled.</param>
        public CatalogTax(
            string name = null,
            string calculationPhase = null,
            string inclusionType = null,
            string percentage = null,
            bool? appliesToCustomAmounts = null,
            bool? enabled = null)
        {
            this.Name = name;
            this.CalculationPhase = calculationPhase;
            this.InclusionType = inclusionType;
            this.Percentage = percentage;
            this.AppliesToCustomAmounts = appliesToCustomAmounts;
            this.Enabled = enabled;
        }

        /// <summary>
        /// The tax's name. This is a searchable attribute for use in applicable query filters, and its value length is of Unicode code points.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; }

        /// <summary>
        /// When to calculate the taxes due on a cart.
        /// </summary>
        [JsonProperty("calculation_phase", NullValueHandling = NullValueHandling.Ignore)]
        public string CalculationPhase { get; }

        /// <summary>
        /// Whether to the tax amount should be additional to or included in the CatalogItem price.
        /// </summary>
        [JsonProperty("inclusion_type", NullValueHandling = NullValueHandling.Ignore)]
        public string InclusionType { get; }

        /// <summary>
        /// The percentage of the tax in decimal form, using a `'.'` as the decimal separator and without a `'%'` sign.
        /// A value of `7.5` corresponds to 7.5%.
        /// </summary>
        [JsonProperty("percentage", NullValueHandling = NullValueHandling.Ignore)]
        public string Percentage { get; }

        /// <summary>
        /// If `true`, the fee applies to custom amounts entered into the Square Point of Sale
        /// app that are not associated with a particular `CatalogItem`.
        /// </summary>
        [JsonProperty("applies_to_custom_amounts", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AppliesToCustomAmounts { get; }

        /// <summary>
        /// A Boolean flag to indicate whether the tax is displayed as enabled (`true`) in the Square Point of Sale app or not (`false`).
        /// </summary>
        [JsonProperty("enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Enabled { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogTax : ({string.Join(", ", toStringOutput)})";
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

            return obj is CatalogTax other &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.CalculationPhase == null && other.CalculationPhase == null) || (this.CalculationPhase?.Equals(other.CalculationPhase) == true)) &&
                ((this.InclusionType == null && other.InclusionType == null) || (this.InclusionType?.Equals(other.InclusionType) == true)) &&
                ((this.Percentage == null && other.Percentage == null) || (this.Percentage?.Equals(other.Percentage) == true)) &&
                ((this.AppliesToCustomAmounts == null && other.AppliesToCustomAmounts == null) || (this.AppliesToCustomAmounts?.Equals(other.AppliesToCustomAmounts) == true)) &&
                ((this.Enabled == null && other.Enabled == null) || (this.Enabled?.Equals(other.Enabled) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 29476180;

            if (this.Name != null)
            {
               hashCode += this.Name.GetHashCode();
            }

            if (this.CalculationPhase != null)
            {
               hashCode += this.CalculationPhase.GetHashCode();
            }

            if (this.InclusionType != null)
            {
               hashCode += this.InclusionType.GetHashCode();
            }

            if (this.Percentage != null)
            {
               hashCode += this.Percentage.GetHashCode();
            }

            if (this.AppliesToCustomAmounts != null)
            {
               hashCode += this.AppliesToCustomAmounts.GetHashCode();
            }

            if (this.Enabled != null)
            {
               hashCode += this.Enabled.GetHashCode();
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
            toStringOutput.Add($"this.CalculationPhase = {(this.CalculationPhase == null ? "null" : this.CalculationPhase.ToString())}");
            toStringOutput.Add($"this.InclusionType = {(this.InclusionType == null ? "null" : this.InclusionType.ToString())}");
            toStringOutput.Add($"this.Percentage = {(this.Percentage == null ? "null" : this.Percentage == string.Empty ? "" : this.Percentage)}");
            toStringOutput.Add($"this.AppliesToCustomAmounts = {(this.AppliesToCustomAmounts == null ? "null" : this.AppliesToCustomAmounts.ToString())}");
            toStringOutput.Add($"this.Enabled = {(this.Enabled == null ? "null" : this.Enabled.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Name(this.Name)
                .CalculationPhase(this.CalculationPhase)
                .InclusionType(this.InclusionType)
                .Percentage(this.Percentage)
                .AppliesToCustomAmounts(this.AppliesToCustomAmounts)
                .Enabled(this.Enabled);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string name;
            private string calculationPhase;
            private string inclusionType;
            private string percentage;
            private bool? appliesToCustomAmounts;
            private bool? enabled;

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
             /// CalculationPhase.
             /// </summary>
             /// <param name="calculationPhase"> calculationPhase. </param>
             /// <returns> Builder. </returns>
            public Builder CalculationPhase(string calculationPhase)
            {
                this.calculationPhase = calculationPhase;
                return this;
            }

             /// <summary>
             /// InclusionType.
             /// </summary>
             /// <param name="inclusionType"> inclusionType. </param>
             /// <returns> Builder. </returns>
            public Builder InclusionType(string inclusionType)
            {
                this.inclusionType = inclusionType;
                return this;
            }

             /// <summary>
             /// Percentage.
             /// </summary>
             /// <param name="percentage"> percentage. </param>
             /// <returns> Builder. </returns>
            public Builder Percentage(string percentage)
            {
                this.percentage = percentage;
                return this;
            }

             /// <summary>
             /// AppliesToCustomAmounts.
             /// </summary>
             /// <param name="appliesToCustomAmounts"> appliesToCustomAmounts. </param>
             /// <returns> Builder. </returns>
            public Builder AppliesToCustomAmounts(bool? appliesToCustomAmounts)
            {
                this.appliesToCustomAmounts = appliesToCustomAmounts;
                return this;
            }

             /// <summary>
             /// Enabled.
             /// </summary>
             /// <param name="enabled"> enabled. </param>
             /// <returns> Builder. </returns>
            public Builder Enabled(bool? enabled)
            {
                this.enabled = enabled;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogTax. </returns>
            public CatalogTax Build()
            {
                return new CatalogTax(
                    this.name,
                    this.calculationPhase,
                    this.inclusionType,
                    this.percentage,
                    this.appliesToCustomAmounts,
                    this.enabled);
            }
        }
    }
}