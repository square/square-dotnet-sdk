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