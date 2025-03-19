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
    /// UpdateWebhookSubscriptionRequest.
    /// </summary>
    public class UpdateWebhookSubscriptionRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateWebhookSubscriptionRequest"/> class.
        /// </summary>
        /// <param name="subscription">subscription.</param>
        public UpdateWebhookSubscriptionRequest(Models.WebhookSubscription subscription = null)
        {
            this.Subscription = subscription;
        }

        /// <summary>
        /// Represents the details of a webhook subscription, including notification URL,
        /// event types, and signature key.
        /// </summary>
        [JsonProperty("subscription", NullValueHandling = NullValueHandling.Ignore)]
        public Models.WebhookSubscription Subscription { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"UpdateWebhookSubscriptionRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is UpdateWebhookSubscriptionRequest other
                && (
                    this.Subscription == null && other.Subscription == null
                    || this.Subscription?.Equals(other.Subscription) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 610834707;
            hashCode = HashCode.Combine(hashCode, this.Subscription);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add(
                $"this.Subscription = {(this.Subscription == null ? "null" : this.Subscription.ToString())}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder().Subscription(this.Subscription);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.WebhookSubscription subscription;

            /// <summary>
            /// Subscription.
            /// </summary>
            /// <param name="subscription"> subscription. </param>
            /// <returns> Builder. </returns>
            public Builder Subscription(Models.WebhookSubscription subscription)
            {
                this.subscription = subscription;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> UpdateWebhookSubscriptionRequest. </returns>
            public UpdateWebhookSubscriptionRequest Build()
            {
                return new UpdateWebhookSubscriptionRequest(this.subscription);
            }
        }
    }
}
