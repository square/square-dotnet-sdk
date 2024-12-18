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
    /// SubscriptionEvent.
    /// </summary>
    public class SubscriptionEvent
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionEvent"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="subscriptionEventType">subscription_event_type.</param>
        /// <param name="effectiveDate">effective_date.</param>
        /// <param name="planVariationId">plan_variation_id.</param>
        /// <param name="monthlyBillingAnchorDate">monthly_billing_anchor_date.</param>
        /// <param name="info">info.</param>
        /// <param name="phases">phases.</param>
        public SubscriptionEvent(
            string id,
            string subscriptionEventType,
            string effectiveDate,
            string planVariationId,
            int? monthlyBillingAnchorDate = null,
            Models.SubscriptionEventInfo info = null,
            IList<Models.Phase> phases = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "phases", false }
            };
            this.Id = id;
            this.SubscriptionEventType = subscriptionEventType;
            this.EffectiveDate = effectiveDate;
            this.MonthlyBillingAnchorDate = monthlyBillingAnchorDate;
            this.Info = info;

            if (phases != null)
            {
                shouldSerialize["phases"] = true;
                this.Phases = phases;
            }
            this.PlanVariationId = planVariationId;
        }

        internal SubscriptionEvent(
            Dictionary<string, bool> shouldSerialize,
            string id,
            string subscriptionEventType,
            string effectiveDate,
            string planVariationId,
            int? monthlyBillingAnchorDate = null,
            Models.SubscriptionEventInfo info = null,
            IList<Models.Phase> phases = null)
        {
            this.shouldSerialize = shouldSerialize;
            Id = id;
            SubscriptionEventType = subscriptionEventType;
            EffectiveDate = effectiveDate;
            MonthlyBillingAnchorDate = monthlyBillingAnchorDate;
            Info = info;
            Phases = phases;
            PlanVariationId = planVariationId;
        }

        /// <summary>
        /// The ID of the subscription event.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// Supported types of an event occurred to a subscription.
        /// </summary>
        [JsonProperty("subscription_event_type")]
        public string SubscriptionEventType { get; }

        /// <summary>
        /// The `YYYY-MM-DD`-formatted date (for example, 2013-01-15) when the subscription event occurred.
        /// </summary>
        [JsonProperty("effective_date")]
        public string EffectiveDate { get; }

        /// <summary>
        /// The day-of-the-month the billing anchor date was changed to, if applicable.
        /// </summary>
        [JsonProperty("monthly_billing_anchor_date", NullValueHandling = NullValueHandling.Ignore)]
        public int? MonthlyBillingAnchorDate { get; }

        /// <summary>
        /// Provides information about the subscription event.
        /// </summary>
        [JsonProperty("info", NullValueHandling = NullValueHandling.Ignore)]
        public Models.SubscriptionEventInfo Info { get; }

        /// <summary>
        /// A list of Phases, to pass phase-specific information used in the swap.
        /// </summary>
        [JsonProperty("phases")]
        public IList<Models.Phase> Phases { get; }

        /// <summary>
        /// The ID of the subscription plan variation associated with the subscription.
        /// </summary>
        [JsonProperty("plan_variation_id")]
        public string PlanVariationId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"SubscriptionEvent : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePhases()
        {
            return this.shouldSerialize["phases"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is SubscriptionEvent other &&
                (this.Id == null && other.Id == null ||
                 this.Id?.Equals(other.Id) == true) &&
                (this.SubscriptionEventType == null && other.SubscriptionEventType == null ||
                 this.SubscriptionEventType?.Equals(other.SubscriptionEventType) == true) &&
                (this.EffectiveDate == null && other.EffectiveDate == null ||
                 this.EffectiveDate?.Equals(other.EffectiveDate) == true) &&
                (this.MonthlyBillingAnchorDate == null && other.MonthlyBillingAnchorDate == null ||
                 this.MonthlyBillingAnchorDate?.Equals(other.MonthlyBillingAnchorDate) == true) &&
                (this.Info == null && other.Info == null ||
                 this.Info?.Equals(other.Info) == true) &&
                (this.Phases == null && other.Phases == null ||
                 this.Phases?.Equals(other.Phases) == true) &&
                (this.PlanVariationId == null && other.PlanVariationId == null ||
                 this.PlanVariationId?.Equals(other.PlanVariationId) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1755317815;
            hashCode = HashCode.Combine(hashCode, this.Id, this.SubscriptionEventType, this.EffectiveDate, this.MonthlyBillingAnchorDate, this.Info, this.Phases, this.PlanVariationId);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {this.Id ?? "null"}");
            toStringOutput.Add($"this.SubscriptionEventType = {(this.SubscriptionEventType == null ? "null" : this.SubscriptionEventType.ToString())}");
            toStringOutput.Add($"this.EffectiveDate = {this.EffectiveDate ?? "null"}");
            toStringOutput.Add($"this.MonthlyBillingAnchorDate = {(this.MonthlyBillingAnchorDate == null ? "null" : this.MonthlyBillingAnchorDate.ToString())}");
            toStringOutput.Add($"this.Info = {(this.Info == null ? "null" : this.Info.ToString())}");
            toStringOutput.Add($"this.Phases = {(this.Phases == null ? "null" : $"[{string.Join(", ", this.Phases)} ]")}");
            toStringOutput.Add($"this.PlanVariationId = {this.PlanVariationId ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Id,
                this.SubscriptionEventType,
                this.EffectiveDate,
                this.PlanVariationId)
                .MonthlyBillingAnchorDate(this.MonthlyBillingAnchorDate)
                .Info(this.Info)
                .Phases(this.Phases);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "phases", false },
            };

            private string id;
            private string subscriptionEventType;
            private string effectiveDate;
            private string planVariationId;
            private int? monthlyBillingAnchorDate;
            private Models.SubscriptionEventInfo info;
            private IList<Models.Phase> phases;

            /// <summary>
            /// Initialize Builder for SubscriptionEvent.
            /// </summary>
            /// <param name="id"> id. </param>
            /// <param name="subscriptionEventType"> subscriptionEventType. </param>
            /// <param name="effectiveDate"> effectiveDate. </param>
            /// <param name="planVariationId"> planVariationId. </param>
            public Builder(
                string id,
                string subscriptionEventType,
                string effectiveDate,
                string planVariationId)
            {
                this.id = id;
                this.subscriptionEventType = subscriptionEventType;
                this.effectiveDate = effectiveDate;
                this.planVariationId = planVariationId;
            }

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
             /// SubscriptionEventType.
             /// </summary>
             /// <param name="subscriptionEventType"> subscriptionEventType. </param>
             /// <returns> Builder. </returns>
            public Builder SubscriptionEventType(string subscriptionEventType)
            {
                this.subscriptionEventType = subscriptionEventType;
                return this;
            }

             /// <summary>
             /// EffectiveDate.
             /// </summary>
             /// <param name="effectiveDate"> effectiveDate. </param>
             /// <returns> Builder. </returns>
            public Builder EffectiveDate(string effectiveDate)
            {
                this.effectiveDate = effectiveDate;
                return this;
            }

             /// <summary>
             /// PlanVariationId.
             /// </summary>
             /// <param name="planVariationId"> planVariationId. </param>
             /// <returns> Builder. </returns>
            public Builder PlanVariationId(string planVariationId)
            {
                this.planVariationId = planVariationId;
                return this;
            }

             /// <summary>
             /// MonthlyBillingAnchorDate.
             /// </summary>
             /// <param name="monthlyBillingAnchorDate"> monthlyBillingAnchorDate. </param>
             /// <returns> Builder. </returns>
            public Builder MonthlyBillingAnchorDate(int? monthlyBillingAnchorDate)
            {
                this.monthlyBillingAnchorDate = monthlyBillingAnchorDate;
                return this;
            }

             /// <summary>
             /// Info.
             /// </summary>
             /// <param name="info"> info. </param>
             /// <returns> Builder. </returns>
            public Builder Info(Models.SubscriptionEventInfo info)
            {
                this.info = info;
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
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetPhases()
            {
                this.shouldSerialize["phases"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SubscriptionEvent. </returns>
            public SubscriptionEvent Build()
            {
                return new SubscriptionEvent(
                    shouldSerialize,
                    this.id,
                    this.subscriptionEventType,
                    this.effectiveDate,
                    this.planVariationId,
                    this.monthlyBillingAnchorDate,
                    this.info,
                    this.phases);
            }
        }
    }
}