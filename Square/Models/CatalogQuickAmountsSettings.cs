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
        [JsonProperty("eligible_for_auto_amounts")]
        public bool? EligibleForAutoAmounts { get; }

        /// <summary>
        /// Represents a set of Quick Amounts at this location.
        /// </summary>
        [JsonProperty("amounts")]
        public IList<Models.CatalogQuickAmount> Amounts { get; }

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
            private IList<Models.CatalogQuickAmount> amounts = new List<Models.CatalogQuickAmount>();

            public Builder(string option)
            {
                this.option = option;
            }
            public Builder Option(string value)
            {
                option = value;
                return this;
            }

            public Builder EligibleForAutoAmounts(bool? value)
            {
                eligibleForAutoAmounts = value;
                return this;
            }

            public Builder Amounts(IList<Models.CatalogQuickAmount> value)
            {
                amounts = value;
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