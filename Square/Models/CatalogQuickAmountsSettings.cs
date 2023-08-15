namespace Square.Models
{
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

    /// <summary>
    /// CatalogQuickAmountsSettings.
    /// </summary>
    public class CatalogQuickAmountsSettings
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogQuickAmountsSettings"/> class.
        /// </summary>
        /// <param name="option">option.</param>
        /// <param name="eligibleForAutoAmounts">eligible_for_auto_amounts.</param>
        /// <param name="amounts">amounts.</param>
        public CatalogQuickAmountsSettings(
            string option,
            bool? eligibleForAutoAmounts = null,
            IList<Models.CatalogQuickAmount> amounts = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "eligible_for_auto_amounts", false },
                { "amounts", false }
            };

            this.Option = option;
            if (eligibleForAutoAmounts != null)
            {
                shouldSerialize["eligible_for_auto_amounts"] = true;
                this.EligibleForAutoAmounts = eligibleForAutoAmounts;
            }

            if (amounts != null)
            {
                shouldSerialize["amounts"] = true;
                this.Amounts = amounts;
            }

        }
        internal CatalogQuickAmountsSettings(Dictionary<string, bool> shouldSerialize,
            string option,
            bool? eligibleForAutoAmounts = null,
            IList<Models.CatalogQuickAmount> amounts = null)
        {
            this.shouldSerialize = shouldSerialize;
            Option = option;
            EligibleForAutoAmounts = eligibleForAutoAmounts;
            Amounts = amounts;
        }

        /// <summary>
        /// Determines a seller's option on Quick Amounts feature.
        /// </summary>
        [JsonProperty("option")]
        public string Option { get; }

        /// <summary>
        /// Represents location's eligibility for auto amounts
        /// The boolean should be consistent with whether there are AUTO amounts in the `amounts`.
        /// </summary>
        [JsonProperty("eligible_for_auto_amounts")]
        public bool? EligibleForAutoAmounts { get; }

        /// <summary>
        /// Represents a set of Quick Amounts at this location.
        /// </summary>
        [JsonProperty("amounts")]
        public IList<Models.CatalogQuickAmount> Amounts { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogQuickAmountsSettings : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEligibleForAutoAmounts()
        {
            return this.shouldSerialize["eligible_for_auto_amounts"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAmounts()
        {
            return this.shouldSerialize["amounts"];
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
            return obj is CatalogQuickAmountsSettings other &&                ((this.Option == null && other.Option == null) || (this.Option?.Equals(other.Option) == true)) &&
                ((this.EligibleForAutoAmounts == null && other.EligibleForAutoAmounts == null) || (this.EligibleForAutoAmounts?.Equals(other.EligibleForAutoAmounts) == true)) &&
                ((this.Amounts == null && other.Amounts == null) || (this.Amounts?.Equals(other.Amounts) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1326255280;
            hashCode = HashCode.Combine(this.Option, this.EligibleForAutoAmounts, this.Amounts);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Option = {(this.Option == null ? "null" : this.Option.ToString())}");
            toStringOutput.Add($"this.EligibleForAutoAmounts = {(this.EligibleForAutoAmounts == null ? "null" : this.EligibleForAutoAmounts.ToString())}");
            toStringOutput.Add($"this.Amounts = {(this.Amounts == null ? "null" : $"[{string.Join(", ", this.Amounts)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Option)
                .EligibleForAutoAmounts(this.EligibleForAutoAmounts)
                .Amounts(this.Amounts);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "eligible_for_auto_amounts", false },
                { "amounts", false },
            };

            private string option;
            private bool? eligibleForAutoAmounts;
            private IList<Models.CatalogQuickAmount> amounts;

            public Builder(
                string option)
            {
                this.option = option;
            }

             /// <summary>
             /// Option.
             /// </summary>
             /// <param name="option"> option. </param>
             /// <returns> Builder. </returns>
            public Builder Option(string option)
            {
                this.option = option;
                return this;
            }

             /// <summary>
             /// EligibleForAutoAmounts.
             /// </summary>
             /// <param name="eligibleForAutoAmounts"> eligibleForAutoAmounts. </param>
             /// <returns> Builder. </returns>
            public Builder EligibleForAutoAmounts(bool? eligibleForAutoAmounts)
            {
                shouldSerialize["eligible_for_auto_amounts"] = true;
                this.eligibleForAutoAmounts = eligibleForAutoAmounts;
                return this;
            }

             /// <summary>
             /// Amounts.
             /// </summary>
             /// <param name="amounts"> amounts. </param>
             /// <returns> Builder. </returns>
            public Builder Amounts(IList<Models.CatalogQuickAmount> amounts)
            {
                shouldSerialize["amounts"] = true;
                this.amounts = amounts;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetEligibleForAutoAmounts()
            {
                this.shouldSerialize["eligible_for_auto_amounts"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetAmounts()
            {
                this.shouldSerialize["amounts"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogQuickAmountsSettings. </returns>
            public CatalogQuickAmountsSettings Build()
            {
                return new CatalogQuickAmountsSettings(shouldSerialize,
                    this.option,
                    this.eligibleForAutoAmounts,
                    this.amounts);
            }
        }
    }
}