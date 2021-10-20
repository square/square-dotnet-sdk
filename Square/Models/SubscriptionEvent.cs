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
    /// SubscriptionEvent.
    /// </summary>
    public class SubscriptionEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionEvent"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="subscriptionEventType">subscription_event_type.</param>
        /// <param name="effectiveDate">effective_date.</param>
        /// <param name="planId">plan_id.</param>
        /// <param name="info">info.</param>
        public SubscriptionEvent(
            string id,
            string subscriptionEventType,
            string effectiveDate,
            string planId,
            Models.SubscriptionEventInfo info = null)
        {
            this.Id = id;
            this.SubscriptionEventType = subscriptionEventType;
            this.EffectiveDate = effectiveDate;
            this.PlanId = planId;
            this.Info = info;
        }

        /// <summary>
        /// The ID of the subscription event.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// The possible subscription event types.
        /// </summary>
        [JsonProperty("subscription_event_type")]
        public string SubscriptionEventType { get; }

        /// <summary>
        /// The date, in YYYY-MM-DD format (for
        /// example, 2013-01-15), when the subscription event went into effect.
        /// </summary>
        [JsonProperty("effective_date")]
        public string EffectiveDate { get; }

        /// <summary>
        /// The ID of the subscription plan associated with the subscription.
        /// </summary>
        [JsonProperty("plan_id")]
        public string PlanId { get; }

        /// <summary>
        /// Provides information about the subscription event.
        /// </summary>
        [JsonProperty("info", NullValueHandling = NullValueHandling.Ignore)]
        public Models.SubscriptionEventInfo Info { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SubscriptionEvent : ({string.Join(", ", toStringOutput)})";
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

            return obj is SubscriptionEvent other &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.SubscriptionEventType == null && other.SubscriptionEventType == null) || (this.SubscriptionEventType?.Equals(other.SubscriptionEventType) == true)) &&
                ((this.EffectiveDate == null && other.EffectiveDate == null) || (this.EffectiveDate?.Equals(other.EffectiveDate) == true)) &&
                ((this.PlanId == null && other.PlanId == null) || (this.PlanId?.Equals(other.PlanId) == true)) &&
                ((this.Info == null && other.Info == null) || (this.Info?.Equals(other.Info) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1280044689;
            hashCode = HashCode.Combine(this.Id, this.SubscriptionEventType, this.EffectiveDate, this.PlanId, this.Info);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.SubscriptionEventType = {(this.SubscriptionEventType == null ? "null" : this.SubscriptionEventType.ToString())}");
            toStringOutput.Add($"this.EffectiveDate = {(this.EffectiveDate == null ? "null" : this.EffectiveDate == string.Empty ? "" : this.EffectiveDate)}");
            toStringOutput.Add($"this.PlanId = {(this.PlanId == null ? "null" : this.PlanId == string.Empty ? "" : this.PlanId)}");
            toStringOutput.Add($"this.Info = {(this.Info == null ? "null" : this.Info.ToString())}");
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
                this.PlanId)
                .Info(this.Info);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string id;
            private string subscriptionEventType;
            private string effectiveDate;
            private string planId;
            private Models.SubscriptionEventInfo info;

            public Builder(
                string id,
                string subscriptionEventType,
                string effectiveDate,
                string planId)
            {
                this.id = id;
                this.subscriptionEventType = subscriptionEventType;
                this.effectiveDate = effectiveDate;
                this.planId = planId;
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
             /// PlanId.
             /// </summary>
             /// <param name="planId"> planId. </param>
             /// <returns> Builder. </returns>
            public Builder PlanId(string planId)
            {
                this.planId = planId;
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
            /// Builds class object.
            /// </summary>
            /// <returns> SubscriptionEvent. </returns>
            public SubscriptionEvent Build()
            {
                return new SubscriptionEvent(
                    this.id,
                    this.subscriptionEventType,
                    this.effectiveDate,
                    this.planId,
                    this.info);
            }
        }
    }
}