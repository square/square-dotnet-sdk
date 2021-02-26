
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
    public class CatalogTax 
    {
        public CatalogTax(string name = null,
            string calculationPhase = null,
            string inclusionType = null,
            string percentage = null,
            bool? appliesToCustomAmounts = null,
            bool? enabled = null)
        {
            Name = name;
            CalculationPhase = calculationPhase;
            InclusionType = inclusionType;
            Percentage = percentage;
            AppliesToCustomAmounts = appliesToCustomAmounts;
            Enabled = enabled;
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogTax : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Name = {(Name == null ? "null" : Name == string.Empty ? "" : Name)}");
            toStringOutput.Add($"CalculationPhase = {(CalculationPhase == null ? "null" : CalculationPhase.ToString())}");
            toStringOutput.Add($"InclusionType = {(InclusionType == null ? "null" : InclusionType.ToString())}");
            toStringOutput.Add($"Percentage = {(Percentage == null ? "null" : Percentage == string.Empty ? "" : Percentage)}");
            toStringOutput.Add($"AppliesToCustomAmounts = {(AppliesToCustomAmounts == null ? "null" : AppliesToCustomAmounts.ToString())}");
            toStringOutput.Add($"Enabled = {(Enabled == null ? "null" : Enabled.ToString())}");
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

            return obj is CatalogTax other &&
                ((Name == null && other.Name == null) || (Name?.Equals(other.Name) == true)) &&
                ((CalculationPhase == null && other.CalculationPhase == null) || (CalculationPhase?.Equals(other.CalculationPhase) == true)) &&
                ((InclusionType == null && other.InclusionType == null) || (InclusionType?.Equals(other.InclusionType) == true)) &&
                ((Percentage == null && other.Percentage == null) || (Percentage?.Equals(other.Percentage) == true)) &&
                ((AppliesToCustomAmounts == null && other.AppliesToCustomAmounts == null) || (AppliesToCustomAmounts?.Equals(other.AppliesToCustomAmounts) == true)) &&
                ((Enabled == null && other.Enabled == null) || (Enabled?.Equals(other.Enabled) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 29476180;

            if (Name != null)
            {
               hashCode += Name.GetHashCode();
            }

            if (CalculationPhase != null)
            {
               hashCode += CalculationPhase.GetHashCode();
            }

            if (InclusionType != null)
            {
               hashCode += InclusionType.GetHashCode();
            }

            if (Percentage != null)
            {
               hashCode += Percentage.GetHashCode();
            }

            if (AppliesToCustomAmounts != null)
            {
               hashCode += AppliesToCustomAmounts.GetHashCode();
            }

            if (Enabled != null)
            {
               hashCode += Enabled.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Name(Name)
                .CalculationPhase(CalculationPhase)
                .InclusionType(InclusionType)
                .Percentage(Percentage)
                .AppliesToCustomAmounts(AppliesToCustomAmounts)
                .Enabled(Enabled);
            return builder;
        }

        public class Builder
        {
            private string name;
            private string calculationPhase;
            private string inclusionType;
            private string percentage;
            private bool? appliesToCustomAmounts;
            private bool? enabled;



            public Builder Name(string name)
            {
                this.name = name;
                return this;
            }

            public Builder CalculationPhase(string calculationPhase)
            {
                this.calculationPhase = calculationPhase;
                return this;
            }

            public Builder InclusionType(string inclusionType)
            {
                this.inclusionType = inclusionType;
                return this;
            }

            public Builder Percentage(string percentage)
            {
                this.percentage = percentage;
                return this;
            }

            public Builder AppliesToCustomAmounts(bool? appliesToCustomAmounts)
            {
                this.appliesToCustomAmounts = appliesToCustomAmounts;
                return this;
            }

            public Builder Enabled(bool? enabled)
            {
                this.enabled = enabled;
                return this;
            }

            public CatalogTax Build()
            {
                return new CatalogTax(name,
                    calculationPhase,
                    inclusionType,
                    percentage,
                    appliesToCustomAmounts,
                    enabled);
            }
        }
    }
}