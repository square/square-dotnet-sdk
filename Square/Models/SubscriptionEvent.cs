
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
    public class SubscriptionEvent 
    {
        public SubscriptionEvent(string id,
            string subscriptionEventType,
            string effectiveDate,
            string planId)
        {
            Id = id;
            SubscriptionEventType = subscriptionEventType;
            EffectiveDate = effectiveDate;
            PlanId = planId;
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SubscriptionEvent : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Id = {(Id == null ? "null" : Id == string.Empty ? "" : Id)}");
            toStringOutput.Add($"SubscriptionEventType = {(SubscriptionEventType == null ? "null" : SubscriptionEventType.ToString())}");
            toStringOutput.Add($"EffectiveDate = {(EffectiveDate == null ? "null" : EffectiveDate == string.Empty ? "" : EffectiveDate)}");
            toStringOutput.Add($"PlanId = {(PlanId == null ? "null" : PlanId == string.Empty ? "" : PlanId)}");
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

            return obj is SubscriptionEvent other &&
                ((Id == null && other.Id == null) || (Id?.Equals(other.Id) == true)) &&
                ((SubscriptionEventType == null && other.SubscriptionEventType == null) || (SubscriptionEventType?.Equals(other.SubscriptionEventType) == true)) &&
                ((EffectiveDate == null && other.EffectiveDate == null) || (EffectiveDate?.Equals(other.EffectiveDate) == true)) &&
                ((PlanId == null && other.PlanId == null) || (PlanId?.Equals(other.PlanId) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -298722928;

            if (Id != null)
            {
               hashCode += Id.GetHashCode();
            }

            if (SubscriptionEventType != null)
            {
               hashCode += SubscriptionEventType.GetHashCode();
            }

            if (EffectiveDate != null)
            {
               hashCode += EffectiveDate.GetHashCode();
            }

            if (PlanId != null)
            {
               hashCode += PlanId.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(Id,
                SubscriptionEventType,
                EffectiveDate,
                PlanId);
            return builder;
        }

        public class Builder
        {
            private string id;
            private string subscriptionEventType;
            private string effectiveDate;
            private string planId;

            public Builder(string id,
                string subscriptionEventType,
                string effectiveDate,
                string planId)
            {
                this.id = id;
                this.subscriptionEventType = subscriptionEventType;
                this.effectiveDate = effectiveDate;
                this.planId = planId;
            }

            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

            public Builder SubscriptionEventType(string subscriptionEventType)
            {
                this.subscriptionEventType = subscriptionEventType;
                return this;
            }

            public Builder EffectiveDate(string effectiveDate)
            {
                this.effectiveDate = effectiveDate;
                return this;
            }

            public Builder PlanId(string planId)
            {
                this.planId = planId;
                return this;
            }

            public SubscriptionEvent Build()
            {
                return new SubscriptionEvent(id,
                    subscriptionEventType,
                    effectiveDate,
                    planId);
            }
        }
    }
}