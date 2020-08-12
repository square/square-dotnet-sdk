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
            public Builder Id(string value)
            {
                id = value;
                return this;
            }

            public Builder SubscriptionEventType(string value)
            {
                subscriptionEventType = value;
                return this;
            }

            public Builder EffectiveDate(string value)
            {
                effectiveDate = value;
                return this;
            }

            public Builder PlanId(string value)
            {
                planId = value;
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