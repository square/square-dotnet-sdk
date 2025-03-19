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
    /// CatalogSubscriptionPlanVariation.
    /// </summary>
    public class CatalogSubscriptionPlanVariation
    {
        private readonly Dictionary<string, bool> shouldSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogSubscriptionPlanVariation"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="phases">phases.</param>
        /// <param name="subscriptionPlanId">subscription_plan_id.</param>
        /// <param name="monthlyBillingAnchorDate">monthly_billing_anchor_date.</param>
        /// <param name="canProrate">can_prorate.</param>
        /// <param name="successorPlanVariationId">successor_plan_variation_id.</param>
        public CatalogSubscriptionPlanVariation(
            string name,
            IList<Models.SubscriptionPhase> phases,
            string subscriptionPlanId = null,
            long? monthlyBillingAnchorDate = null,
            bool? canProrate = null,
            string successorPlanVariationId = null
        )
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "subscription_plan_id", false },
                { "monthly_billing_anchor_date", false },
                { "can_prorate", false },
                { "successor_plan_variation_id", false },
            };
            this.Name = name;
            this.Phases = phases;

            if (subscriptionPlanId != null)
            {
                shouldSerialize["subscription_plan_id"] = true;
                this.SubscriptionPlanId = subscriptionPlanId;
            }

            if (monthlyBillingAnchorDate != null)
            {
                shouldSerialize["monthly_billing_anchor_date"] = true;
                this.MonthlyBillingAnchorDate = monthlyBillingAnchorDate;
            }

            if (canProrate != null)
            {
                shouldSerialize["can_prorate"] = true;
                this.CanProrate = canProrate;
            }

            if (successorPlanVariationId != null)
            {
                shouldSerialize["successor_plan_variation_id"] = true;
                this.SuccessorPlanVariationId = successorPlanVariationId;
            }
        }

        internal CatalogSubscriptionPlanVariation(
            Dictionary<string, bool> shouldSerialize,
            string name,
            IList<Models.SubscriptionPhase> phases,
            string subscriptionPlanId = null,
            long? monthlyBillingAnchorDate = null,
            bool? canProrate = null,
            string successorPlanVariationId = null
        )
        {
            this.shouldSerialize = shouldSerialize;
            Name = name;
            Phases = phases;
            SubscriptionPlanId = subscriptionPlanId;
            MonthlyBillingAnchorDate = monthlyBillingAnchorDate;
            CanProrate = canProrate;
            SuccessorPlanVariationId = successorPlanVariationId;
        }

        /// <summary>
        /// The name of the plan variation.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// A list containing each [SubscriptionPhase](entity:SubscriptionPhase) for this plan variation.
        /// </summary>
        [JsonProperty("phases")]
        public IList<Models.SubscriptionPhase> Phases { get; }

        /// <summary>
        /// The id of the subscription plan, if there is one.
        /// </summary>
        [JsonProperty("subscription_plan_id")]
        public string SubscriptionPlanId { get; }

        /// <summary>
        /// The day of the month the billing period starts.
        /// </summary>
        [JsonProperty("monthly_billing_anchor_date")]
        public long? MonthlyBillingAnchorDate { get; }

        /// <summary>
        /// Whether bills for this plan variation can be split for proration.
        /// </summary>
        [JsonProperty("can_prorate")]
        public bool? CanProrate { get; }

        /// <summary>
        /// The ID of a "successor" plan variation to this one. If the field is set, and this object is disabled at all
        /// locations, it indicates that this variation is deprecated and the object identified by the successor ID be used in
        /// its stead.
        /// </summary>
        [JsonProperty("successor_plan_variation_id")]
        public string SuccessorPlanVariationId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"CatalogSubscriptionPlanVariation : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSubscriptionPlanId()
        {
            return this.shouldSerialize["subscription_plan_id"];
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
        public bool ShouldSerializeCanProrate()
        {
            return this.shouldSerialize["can_prorate"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSuccessorPlanVariationId()
        {
            return this.shouldSerialize["successor_plan_variation_id"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is CatalogSubscriptionPlanVariation other
                && (
                    this.Name == null && other.Name == null || this.Name?.Equals(other.Name) == true
                )
                && (
                    this.Phases == null && other.Phases == null
                    || this.Phases?.Equals(other.Phases) == true
                )
                && (
                    this.SubscriptionPlanId == null && other.SubscriptionPlanId == null
                    || this.SubscriptionPlanId?.Equals(other.SubscriptionPlanId) == true
                )
                && (
                    this.MonthlyBillingAnchorDate == null && other.MonthlyBillingAnchorDate == null
                    || this.MonthlyBillingAnchorDate?.Equals(other.MonthlyBillingAnchorDate) == true
                )
                && (
                    this.CanProrate == null && other.CanProrate == null
                    || this.CanProrate?.Equals(other.CanProrate) == true
                )
                && (
                    this.SuccessorPlanVariationId == null && other.SuccessorPlanVariationId == null
                    || this.SuccessorPlanVariationId?.Equals(other.SuccessorPlanVariationId) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1471838762;
            hashCode = HashCode.Combine(
                hashCode,
                this.Name,
                this.Phases,
                this.SubscriptionPlanId,
                this.MonthlyBillingAnchorDate,
                this.CanProrate,
                this.SuccessorPlanVariationId
            );

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Name = {this.Name ?? "null"}");
            toStringOutput.Add(
                $"this.Phases = {(this.Phases == null ? "null" : $"[{string.Join(", ", this.Phases)} ]")}"
            );
            toStringOutput.Add($"this.SubscriptionPlanId = {this.SubscriptionPlanId ?? "null"}");
            toStringOutput.Add(
                $"this.MonthlyBillingAnchorDate = {(this.MonthlyBillingAnchorDate == null ? "null" : this.MonthlyBillingAnchorDate.ToString())}"
            );
            toStringOutput.Add(
                $"this.CanProrate = {(this.CanProrate == null ? "null" : this.CanProrate.ToString())}"
            );
            toStringOutput.Add(
                $"this.SuccessorPlanVariationId = {this.SuccessorPlanVariationId ?? "null"}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(this.Name, this.Phases)
                .SubscriptionPlanId(this.SubscriptionPlanId)
                .MonthlyBillingAnchorDate(this.MonthlyBillingAnchorDate)
                .CanProrate(this.CanProrate)
                .SuccessorPlanVariationId(this.SuccessorPlanVariationId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "subscription_plan_id", false },
                { "monthly_billing_anchor_date", false },
                { "can_prorate", false },
                { "successor_plan_variation_id", false },
            };

            private string name;
            private IList<Models.SubscriptionPhase> phases;
            private string subscriptionPlanId;
            private long? monthlyBillingAnchorDate;
            private bool? canProrate;
            private string successorPlanVariationId;

            /// <summary>
            /// Initialize Builder for CatalogSubscriptionPlanVariation.
            /// </summary>
            /// <param name="name"> name. </param>
            /// <param name="phases"> phases. </param>
            public Builder(string name, IList<Models.SubscriptionPhase> phases)
            {
                this.name = name;
                this.phases = phases;
            }

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
            /// Phases.
            /// </summary>
            /// <param name="phases"> phases. </param>
            /// <returns> Builder. </returns>
            public Builder Phases(IList<Models.SubscriptionPhase> phases)
            {
                this.phases = phases;
                return this;
            }

            /// <summary>
            /// SubscriptionPlanId.
            /// </summary>
            /// <param name="subscriptionPlanId"> subscriptionPlanId. </param>
            /// <returns> Builder. </returns>
            public Builder SubscriptionPlanId(string subscriptionPlanId)
            {
                shouldSerialize["subscription_plan_id"] = true;
                this.subscriptionPlanId = subscriptionPlanId;
                return this;
            }

            /// <summary>
            /// MonthlyBillingAnchorDate.
            /// </summary>
            /// <param name="monthlyBillingAnchorDate"> monthlyBillingAnchorDate. </param>
            /// <returns> Builder. </returns>
            public Builder MonthlyBillingAnchorDate(long? monthlyBillingAnchorDate)
            {
                shouldSerialize["monthly_billing_anchor_date"] = true;
                this.monthlyBillingAnchorDate = monthlyBillingAnchorDate;
                return this;
            }

            /// <summary>
            /// CanProrate.
            /// </summary>
            /// <param name="canProrate"> canProrate. </param>
            /// <returns> Builder. </returns>
            public Builder CanProrate(bool? canProrate)
            {
                shouldSerialize["can_prorate"] = true;
                this.canProrate = canProrate;
                return this;
            }

            /// <summary>
            /// SuccessorPlanVariationId.
            /// </summary>
            /// <param name="successorPlanVariationId"> successorPlanVariationId. </param>
            /// <returns> Builder. </returns>
            public Builder SuccessorPlanVariationId(string successorPlanVariationId)
            {
                shouldSerialize["successor_plan_variation_id"] = true;
                this.successorPlanVariationId = successorPlanVariationId;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetSubscriptionPlanId()
            {
                this.shouldSerialize["subscription_plan_id"] = false;
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
            public void UnsetCanProrate()
            {
                this.shouldSerialize["can_prorate"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetSuccessorPlanVariationId()
            {
                this.shouldSerialize["successor_plan_variation_id"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogSubscriptionPlanVariation. </returns>
            public CatalogSubscriptionPlanVariation Build()
            {
                return new CatalogSubscriptionPlanVariation(
                    shouldSerialize,
                    this.name,
                    this.phases,
                    this.subscriptionPlanId,
                    this.monthlyBillingAnchorDate,
                    this.canProrate,
                    this.successorPlanVariationId
                );
            }
        }
    }
}
