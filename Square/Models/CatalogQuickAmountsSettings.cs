
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
    public class CatalogQuickAmountsSettings 
    {
        public CatalogQuickAmountsSettings(string option,
            bool? eligibleForAutoAmounts = null,
            IList<Models.CatalogQuickAmount> amounts = null)
        {
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
        [JsonProperty("eligible_for_auto_amounts", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EligibleForAutoAmounts { get; }

        /// <summary>
        /// Represents a set of Quick Amounts at this location.
        /// </summary>
        [JsonProperty("amounts", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.CatalogQuickAmount> Amounts { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogQuickAmountsSettings : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Option = {(Option == null ? "null" : Option.ToString())}");
            toStringOutput.Add($"EligibleForAutoAmounts = {(EligibleForAutoAmounts == null ? "null" : EligibleForAutoAmounts.ToString())}");
            toStringOutput.Add($"Amounts = {(Amounts == null ? "null" : $"[{ string.Join(", ", Amounts)} ]")}");
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

            return obj is CatalogQuickAmountsSettings other &&
                ((Option == null && other.Option == null) || (Option?.Equals(other.Option) == true)) &&
                ((EligibleForAutoAmounts == null && other.EligibleForAutoAmounts == null) || (EligibleForAutoAmounts?.Equals(other.EligibleForAutoAmounts) == true)) &&
                ((Amounts == null && other.Amounts == null) || (Amounts?.Equals(other.Amounts) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1326255280;

            if (Option != null)
            {
               hashCode += Option.GetHashCode();
            }

            if (EligibleForAutoAmounts != null)
            {
               hashCode += EligibleForAutoAmounts.GetHashCode();
            }

            if (Amounts != null)
            {
               hashCode += Amounts.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(Option)
                .EligibleForAutoAmounts(EligibleForAutoAmounts)
                .Amounts(Amounts);
            return builder;
        }

        public class Builder
        {
            private string option;
            private bool? eligibleForAutoAmounts;
            private IList<Models.CatalogQuickAmount> amounts;

            public Builder(string option)
            {
                this.option = option;
            }

            public Builder Option(string option)
            {
                this.option = option;
                return this;
            }

            public Builder EligibleForAutoAmounts(bool? eligibleForAutoAmounts)
            {
                this.eligibleForAutoAmounts = eligibleForAutoAmounts;
                return this;
            }

            public Builder Amounts(IList<Models.CatalogQuickAmount> amounts)
            {
                this.amounts = amounts;
                return this;
            }

            public CatalogQuickAmountsSettings Build()
            {
                return new CatalogQuickAmountsSettings(option,
                    eligibleForAutoAmounts,
                    amounts);
            }
        }
    }
}