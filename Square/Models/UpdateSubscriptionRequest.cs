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
    public class UpdateSubscriptionRequest 
    {
        public UpdateSubscriptionRequest(Models.Subscription subscription = null)
        {
            Subscription = subscription;
        }

        /// <summary>
        /// Represents a customer subscription to a subscription plan.
        /// For an overview of the `Subscription` type, see 
        /// [Subscription object](https://developer.squareup.com/docs/subscriptions-api/overview#subscription-object-overview).
        /// </summary>
        [JsonProperty("subscription", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Subscription Subscription { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Subscription(Subscription);
            return builder;
        }

        public class Builder
        {
            private Models.Subscription subscription;



            public Builder Subscription(Models.Subscription subscription)
            {
                this.subscription = subscription;
                return this;
            }

            public UpdateSubscriptionRequest Build()
            {
                return new UpdateSubscriptionRequest(subscription);
            }
        }
    }
}