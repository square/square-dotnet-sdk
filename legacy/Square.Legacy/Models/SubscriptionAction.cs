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
using Square.Legacy;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// SubscriptionAction.
    /// </summary>
    public class SubscriptionAction
    {
        private readonly Dictionary<string, bool> shouldSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionAction"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="type">type.</param>
        /// <param name="effectiveDate">effective_date.</param>
        /// <param name="monthlyBillingAnchorDate">monthly_billing_anchor_date.</param>
        /// <param name="phases">phases.</param>
        /// <param name="newPlanVariationId">new_plan_variation_id.</param>
        public SubscriptionAction(
            string id = null,
            string type = null,
            string effectiveDate = null,
            int? monthlyBillingAnchorDate = null,
            IList<Models.Phase> phases = null,
            string newPlanVariationId = null
        )
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "effective_date", false },
                { "monthly_billing_anchor_date", false },
                { "phases", false },
                { "new_plan_variation_id", false },
            };
            this.Id = id;
            this.Type = type;

            if (effectiveDate != null)
            {
                shouldSerialize["effective_date"] = true;
                this.EffectiveDate = effectiveDate;
            }

            if (monthlyBillingAnchorDate != null)
            {
                shouldSerialize["monthly_billing_anchor_date"] = true;
                this.MonthlyBillingAnchorDate = monthlyBillingAnchorDate;
            }

            if (phases != null)
            {
                shouldSerialize["phases"] = true;
                this.Phases = phases;
            }

            if (newPlanVariationId != null)
            {
                shouldSerialize["new_plan_variation_id"] = true;
                this.NewPlanVariationId = newPlanVariationId;
            }
        }

        internal SubscriptionAction(
            Dictionary<string, bool> shouldSerialize,
            string id = null,
            string type = null,
            string effectiveDate = null,
            int? monthlyBillingAnchorDate = null,
            IList<Models.Phase> phases = null,
            string newPlanVariationId = null
        )
        {
            this.shouldSerialize = shouldSerialize;
            Id = id;
            Type = type;
            EffectiveDate = effectiveDate;
            MonthlyBillingAnchorDate = monthlyBillingAnchorDate;
            Phases = phases;
            NewPlanVariationId = newPlanVariationId;
        }

        /// <summary>
        /// The ID of an action scoped to a subscription.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// Supported types of an action as a pending change to a subscription.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; }

        /// <summary>
        /// The `YYYY-MM-DD`-formatted date when the action occurs on the subscription.
        /// </summary>
        [JsonProperty("effective_date")]
        public string EffectiveDate { get; }

        /// <summary>
        /// The new billing anchor day value, for a `CHANGE_BILLING_ANCHOR_DATE` action.
        /// </summary>
        [JsonProperty("monthly_billing_anchor_date")]
        public int? MonthlyBillingAnchorDate { get; }

        /// <summary>
        /// A list of Phases, to pass phase-specific information used in the swap.
        /// </summary>
        [JsonProperty("phases")]
        public IList<Models.Phase> Phases { get; }

        /// <summary>
        /// The target subscription plan variation that a subscription switches to, for a `SWAP_PLAN` action.
        /// </summary>
        [JsonProperty("new_plan_variation_id")]
        public string NewPlanVariationId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"SubscriptionAction : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEffectiveDate()
        {
            return this.shouldSerialize["effective_date"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMonthlyBillingAnchorDate()
        {
            return this.shouldSerialize["monthly_billing_anchor_date"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePhases()
        {
            return this.shouldSerialize["phases"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeNewPlanVariationId()
        {
            return this.shouldSerialize["new_plan_variation_id"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is SubscriptionAction other
                && (this.Id == null && other.Id == null || this.Id?.Equals(other.Id) == true)
                && (
                    this.Type == null && other.Type == null || this.Type?.Equals(other.Type) == true
                )
                && (
                    this.EffectiveDate == null && other.EffectiveDate == null
                    || this.EffectiveDate?.Equals(other.EffectiveDate) == true
                )
                && (
                    this.MonthlyBillingAnchorDate == null && other.MonthlyBillingAnchorDate == null
                    || this.MonthlyBillingAnchorDate?.Equals(other.MonthlyBillingAnchorDate) == true
                )
                && (
                    this.Phases == null && other.Phases == null
                    || this.Phases?.Equals(other.Phases) == true
                )
                && (
                    this.NewPlanVariationId == null && other.NewPlanVariationId == null
                    || this.NewPlanVariationId?.Equals(other.NewPlanVariationId) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -904463000;
            hashCode = HashCode.Combine(
                hashCode,
                this.Id,
                this.Type,
                this.EffectiveDate,
                this.MonthlyBillingAnchorDate,
                this.Phases,
                this.NewPlanVariationId
            );

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {this.Id ?? "null"}");
            toStringOutput.Add(
                $"this.Type = {(this.Type == null ? "null" : this.Type.ToString())}"
            );
            toStringOutput.Add($"this.EffectiveDate = {this.EffectiveDate ?? "null"}");
            toStringOutput.Add(
                $"this.MonthlyBillingAnchorDate = {(this.MonthlyBillingAnchorDate == null ? "null" : this.MonthlyBillingAnchorDate.ToString())}"
            );
            toStringOutput.Add(
                $"this.Phases = {(this.Phases == null ? "null" : $"[{string.Join(", ", this.Phases)} ]")}"
            );
            toStringOutput.Add($"this.NewPlanVariationId = {this.NewPlanVariationId ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(this.Id)
                .Type(this.Type)
                .EffectiveDate(this.EffectiveDate)
                .MonthlyBillingAnchorDate(this.MonthlyBillingAnchorDate)
                .Phases(this.Phases)
                .NewPlanVariationId(this.NewPlanVariationId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "effective_date", false },
                { "monthly_billing_anchor_date", false },
                { "phases", false },
                { "new_plan_variation_id", false },
            };

            private string id;
            private string type;
            private string effectiveDate;
            private int? monthlyBillingAnchorDate;
            private IList<Models.Phase> phases;
            private string newPlanVariationId;

            /// <summary>
            /// Id.
            /// </summary>
            /// <param name="id"> id. </param>
            /// <returns> Builder. </returns>
            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

            /// <summary>
            /// Type.
            /// </summary>
            /// <param name="type"> type. </param>
            /// <returns> Builder. </returns>
            public Builder Type(string type)
            {
                this.type = type;
                return this;
            }

            /// <summary>
            /// EffectiveDate.
            /// </summary>
            /// <param name="effectiveDate"> effectiveDate. </param>
            /// <returns> Builder. </returns>
            public Builder EffectiveDate(string effectiveDate)
            {
                shouldSerialize["effective_date"] = true;
                this.effectiveDate = effectiveDate;
                return this;
            }

            /// <summary>
            /// MonthlyBillingAnchorDate.
            /// </summary>
            /// <param name="monthlyBillingAnchorDate"> monthlyBillingAnchorDate. </param>
            /// <returns> Builder. </returns>
            public Builder MonthlyBillingAnchorDate(int? monthlyBillingAnchorDate)
            {
                shouldSerialize["monthly_billing_anchor_date"] = true;
                this.monthlyBillingAnchorDate = monthlyBillingAnchorDate;
                return this;
            }

            /// <summary>
            /// Phases.
            /// </summary>
            /// <param name="phases"> phases. </param>
            /// <returns> Builder. </returns>
            public Builder Phases(IList<Models.Phase> phases)
            {
                shouldSerialize["phases"] = true;
                this.phases = phases;
                return this;
            }

            /// <summary>
            /// NewPlanVariationId.
            /// </summary>
            /// <param name="newPlanVariationId"> newPlanVariationId. </param>
            /// <returns> Builder. </returns>
            public Builder NewPlanVariationId(string newPlanVariationId)
            {
                shouldSerialize["new_plan_variation_id"] = true;
                this.newPlanVariationId = newPlanVariationId;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetEffectiveDate()
            {
                this.shouldSerialize["effective_date"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetMonthlyBillingAnchorDate()
            {
                this.shouldSerialize["monthly_billing_anchor_date"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetPhases()
            {
                this.shouldSerialize["phases"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetNewPlanVariationId()
            {
                this.shouldSerialize["new_plan_variation_id"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SubscriptionAction. </returns>
            public SubscriptionAction Build()
            {
                return new SubscriptionAction(
                    shouldSerialize,
                    this.id,
                    this.type,
                    this.effectiveDate,
                    this.monthlyBillingAnchorDate,
                    this.phases,
                    this.newPlanVariationId
                );
            }
        }
    }
}
