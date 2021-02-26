
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"UpdateSubscriptionRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Subscription = {(Subscription == null ? "null" : Subscription.ToString())}");
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

            return obj is UpdateSubscriptionRequest other &&
                ((Subscription == null && other.Subscription == null) || (Subscription?.Equals(other.Subscription) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -881287883;

            if (Subscription != null)
            {
               hashCode += Subscription.GetHashCode();
            }

            return hashCode;
        }

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