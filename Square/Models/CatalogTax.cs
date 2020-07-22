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
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// When to calculate the taxes due on a cart.
        /// </summary>
        [JsonProperty("calculation_phase")]
        public string CalculationPhase { get; }

        /// <summary>
        /// Whether to the tax amount should be additional to or included in the CatalogItem price.
        /// </summary>
        [JsonProperty("inclusion_type")]
        public string InclusionType { get; }

        /// <summary>
        /// The percentage of the tax in decimal form, using a `'.'` as the decimal separator and without a `'%'` sign.
        /// A value of `7.5` corresponds to 7.5%.
        /// </summary>
        [JsonProperty("percentage")]
        public string Percentage { get; }

        /// <summary>
        /// If `true`, the fee applies to custom amounts entered into the Square Point of Sale
        /// app that are not associated with a particular `CatalogItem`.
        /// </summary>
        [JsonProperty("applies_to_custom_amounts")]
        public bool? AppliesToCustomAmounts { get; }

        /// <summary>
        /// If `true`, the tax will be shown as enabled in the Square Point of Sale app.
        /// </summary>
        [JsonProperty("enabled")]
        public bool? Enabled { get; }

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

            public Builder() { }
            public Builder Name(string value)
            {
                name = value;
                return this;
            }

            public Builder CalculationPhase(string value)
            {
                calculationPhase = value;
                return this;
            }

            public Builder InclusionType(string value)
            {
                inclusionType = value;
                return this;
            }

            public Builder Percentage(string value)
            {
                percentage = value;
                return this;
            }

            public Builder AppliesToCustomAmounts(bool? value)
            {
                appliesToCustomAmounts = value;
                return this;
            }

            public Builder Enabled(bool? value)
            {
                enabled = value;
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