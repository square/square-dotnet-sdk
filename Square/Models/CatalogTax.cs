using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIMatic.Core.Utilities.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    /// <summary>
    /// CatalogTax.
    /// </summary>
    public class CatalogTax
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogTax"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="calculationPhase">calculation_phase.</param>
        /// <param name="inclusionType">inclusion_type.</param>
        /// <param name="percentage">percentage.</param>
        /// <param name="appliesToCustomAmounts">applies_to_custom_amounts.</param>
        /// <param name="enabled">enabled.</param>
        /// <param name="appliesToProductSetId">applies_to_product_set_id.</param>
        public CatalogTax(
            string name = null,
            string calculationPhase = null,
            string inclusionType = null,
            string percentage = null,
            bool? appliesToCustomAmounts = null,
            bool? enabled = null,
            string appliesToProductSetId = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "name", false },
                { "percentage", false },
                { "applies_to_custom_amounts", false },
                { "enabled", false },
                { "applies_to_product_set_id", false }
            };

            if (name != null)
            {
                shouldSerialize["name"] = true;
                this.Name = name;
            }
            this.CalculationPhase = calculationPhase;
            this.InclusionType = inclusionType;

            if (percentage != null)
            {
                shouldSerialize["percentage"] = true;
                this.Percentage = percentage;
            }

            if (appliesToCustomAmounts != null)
            {
                shouldSerialize["applies_to_custom_amounts"] = true;
                this.AppliesToCustomAmounts = appliesToCustomAmounts;
            }

            if (enabled != null)
            {
                shouldSerialize["enabled"] = true;
                this.Enabled = enabled;
            }

            if (appliesToProductSetId != null)
            {
                shouldSerialize["applies_to_product_set_id"] = true;
                this.AppliesToProductSetId = appliesToProductSetId;
            }
        }

        internal CatalogTax(
            Dictionary<string, bool> shouldSerialize,
            string name = null,
            string calculationPhase = null,
            string inclusionType = null,
            string percentage = null,
            bool? appliesToCustomAmounts = null,
            bool? enabled = null,
            string appliesToProductSetId = null)
        {
            this.shouldSerialize = shouldSerialize;
            Name = name;
            CalculationPhase = calculationPhase;
            InclusionType = inclusionType;
            Percentage = percentage;
            AppliesToCustomAmounts = appliesToCustomAmounts;
            Enabled = enabled;
            AppliesToProductSetId = appliesToProductSetId;
        }

        /// <summary>
        /// The tax's name. This is a searchable attribute for use in applicable query filters, and its value length is of Unicode code points.
        /// </summary>
        [JsonProperty("name")]
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
        /// A value of `7.5` corresponds to 7.5%. For a location-specific tax rate, contact the tax authority of the location or a tax consultant.
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
        /// A Boolean flag to indicate whether the tax is displayed as enabled (`true`) in the Square Point of Sale app or not (`false`).
        /// </summary>
        [JsonProperty("enabled")]
        public bool? Enabled { get; }

        /// <summary>
        /// The ID of a `CatalogProductSet` object. If set, the tax is applicable to all products in the product set.
        /// </summary>
        [JsonProperty("applies_to_product_set_id")]
        public string AppliesToProductSetId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"CatalogTax : ({string.Join(", ", toStringOutput)})";
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
        public bool ShouldSerializePercentage()
        {
            return this.shouldSerialize["percentage"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAppliesToCustomAmounts()
        {
            return this.shouldSerialize["applies_to_custom_amounts"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEnabled()
        {
            return this.shouldSerialize["enabled"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAppliesToProductSetId()
        {
            return this.shouldSerialize["applies_to_product_set_id"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is CatalogTax other &&
                (this.Name == null && other.Name == null ||
                 this.Name?.Equals(other.Name) == true) &&
                (this.CalculationPhase == null && other.CalculationPhase == null ||
                 this.CalculationPhase?.Equals(other.CalculationPhase) == true) &&
                (this.InclusionType == null && other.InclusionType == null ||
                 this.InclusionType?.Equals(other.InclusionType) == true) &&
                (this.Percentage == null && other.Percentage == null ||
                 this.Percentage?.Equals(other.Percentage) == true) &&
                (this.AppliesToCustomAmounts == null && other.AppliesToCustomAmounts == null ||
                 this.AppliesToCustomAmounts?.Equals(other.AppliesToCustomAmounts) == true) &&
                (this.Enabled == null && other.Enabled == null ||
                 this.Enabled?.Equals(other.Enabled) == true) &&
                (this.AppliesToProductSetId == null && other.AppliesToProductSetId == null ||
                 this.AppliesToProductSetId?.Equals(other.AppliesToProductSetId) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -36050816;
            hashCode = HashCode.Combine(hashCode, this.Name, this.CalculationPhase, this.InclusionType, this.Percentage, this.AppliesToCustomAmounts, this.Enabled, this.AppliesToProductSetId);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Name = {this.Name ?? "null"}");
            toStringOutput.Add($"this.CalculationPhase = {(this.CalculationPhase == null ? "null" : this.CalculationPhase.ToString())}");
            toStringOutput.Add($"this.InclusionType = {(this.InclusionType == null ? "null" : this.InclusionType.ToString())}");
            toStringOutput.Add($"this.Percentage = {this.Percentage ?? "null"}");
            toStringOutput.Add($"this.AppliesToCustomAmounts = {(this.AppliesToCustomAmounts == null ? "null" : this.AppliesToCustomAmounts.ToString())}");
            toStringOutput.Add($"this.Enabled = {(this.Enabled == null ? "null" : this.Enabled.ToString())}");
            toStringOutput.Add($"this.AppliesToProductSetId = {this.AppliesToProductSetId ?? "null"}");
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
                .Enabled(this.Enabled)
                .AppliesToProductSetId(this.AppliesToProductSetId);
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
                { "percentage", false },
                { "applies_to_custom_amounts", false },
                { "enabled", false },
                { "applies_to_product_set_id", false },
            };

            private string name;
            private string calculationPhase;
            private string inclusionType;
            private string percentage;
            private bool? appliesToCustomAmounts;
            private bool? enabled;
            private string appliesToProductSetId;

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
                shouldSerialize["percentage"] = true;
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
                shouldSerialize["applies_to_custom_amounts"] = true;
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
                shouldSerialize["enabled"] = true;
                this.enabled = enabled;
                return this;
            }

             /// <summary>
             /// AppliesToProductSetId.
             /// </summary>
             /// <param name="appliesToProductSetId"> appliesToProductSetId. </param>
             /// <returns> Builder. </returns>
            public Builder AppliesToProductSetId(string appliesToProductSetId)
            {
                shouldSerialize["applies_to_product_set_id"] = true;
                this.appliesToProductSetId = appliesToProductSetId;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetName()
            {
                this.shouldSerialize["name"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetPercentage()
            {
                this.shouldSerialize["percentage"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetAppliesToCustomAmounts()
            {
                this.shouldSerialize["applies_to_custom_amounts"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetEnabled()
            {
                this.shouldSerialize["enabled"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetAppliesToProductSetId()
            {
                this.shouldSerialize["applies_to_product_set_id"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogTax. </returns>
            public CatalogTax Build()
            {
                return new CatalogTax(
                    shouldSerialize,
                    this.name,
                    this.calculationPhase,
                    this.inclusionType,
                    this.percentage,
                    this.appliesToCustomAmounts,
                    this.enabled,
                    this.appliesToProductSetId);
            }
        }
    }
}