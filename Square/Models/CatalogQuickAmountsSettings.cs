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
    /// CatalogQuickAmountsSettings.
    /// </summary>
    public class CatalogQuickAmountsSettings
    {
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
            this.Option = option;
            this.EligibleForAutoAmounts = eligibleForAutoAmounts;
            this.Amounts = amounts;
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
        [JsonProperty("eligible_for_auto_amounts", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EligibleForAutoAmounts { get; }

        /// <summary>
        /// Represents a set of Quick Amounts at this location.
        /// </summary>
        [JsonProperty("amounts", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.CatalogQuickAmount> Amounts { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogQuickAmountsSettings : ({string.Join(", ", toStringOutput)})";
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

            return obj is CatalogQuickAmountsSettings other &&
                ((this.Option == null && other.Option == null) || (this.Option?.Equals(other.Option) == true)) &&
                ((this.EligibleForAutoAmounts == null && other.EligibleForAutoAmounts == null) || (this.EligibleForAutoAmounts?.Equals(other.EligibleForAutoAmounts) == true)) &&
                ((this.Amounts == null && other.Amounts == null) || (this.Amounts?.Equals(other.Amounts) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1326255280;

            if (this.Option != null)
            {
               hashCode += this.Option.GetHashCode();
            }

            if (this.EligibleForAutoAmounts != null)
            {
               hashCode += this.EligibleForAutoAmounts.GetHashCode();
            }

            if (this.Amounts != null)
            {
               hashCode += this.Amounts.GetHashCode();
            }

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
                this.amounts = amounts;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogQuickAmountsSettings. </returns>
            public CatalogQuickAmountsSettings Build()
            {
                return new CatalogQuickAmountsSettings(
                    this.option,
                    this.eligibleForAutoAmounts,
                    this.amounts);
            }
        }
    }
}