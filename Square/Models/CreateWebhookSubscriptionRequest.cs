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
    /// CreateWebhookSubscriptionRequest.
    /// </summary>
    public class CreateWebhookSubscriptionRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateWebhookSubscriptionRequest"/> class.
        /// </summary>
        /// <param name="subscription">subscription.</param>
        /// <param name="idempotencyKey">idempotency_key.</param>
        public CreateWebhookSubscriptionRequest(
            Models.WebhookSubscription subscription,
            string idempotencyKey = null)
        {
            this.IdempotencyKey = idempotencyKey;
            this.Subscription = subscription;
        }

        /// <summary>
        /// A unique string that identifies the [CreateWebhookSubscription](api-endpoint:WebhookSubscriptions-CreateWebhookSubscription) request.
        /// </summary>
        [JsonProperty("idempotency_key", NullValueHandling = NullValueHandling.Ignore)]
        public string IdempotencyKey { get; }

        /// <summary>
        /// Represents the details of a webhook subscription, including notification URL,
        /// event types, and signature key.
        /// </summary>
        [JsonProperty("subscription")]
        public Models.WebhookSubscription Subscription { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"CreateWebhookSubscriptionRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is CreateWebhookSubscriptionRequest other &&
                (this.IdempotencyKey == null && other.IdempotencyKey == null ||
                 this.IdempotencyKey?.Equals(other.IdempotencyKey) == true) &&
                (this.Subscription == null && other.Subscription == null ||
                 this.Subscription?.Equals(other.Subscription) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -2007075418;
            hashCode = HashCode.Combine(hashCode, this.IdempotencyKey, this.Subscription);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.IdempotencyKey = {this.IdempotencyKey ?? "null"}");
            toStringOutput.Add($"this.Subscription = {(this.Subscription == null ? "null" : this.Subscription.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Subscription)
                .IdempotencyKey(this.IdempotencyKey);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.WebhookSubscription subscription;
            private string idempotencyKey;

            /// <summary>
            /// Initialize Builder for CreateWebhookSubscriptionRequest.
            /// </summary>
            /// <param name="subscription"> subscription. </param>
            public Builder(
                Models.WebhookSubscription subscription)
            {
                this.subscription = subscription;
            }

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
             /// IdempotencyKey.
             /// </summary>
             /// <param name="idempotencyKey"> idempotencyKey. </param>
             /// <returns> Builder. </returns>
            public Builder IdempotencyKey(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CreateWebhookSubscriptionRequest. </returns>
            public CreateWebhookSubscriptionRequest Build()
            {
                return new CreateWebhookSubscriptionRequest(
                    this.subscription,
                    this.idempotencyKey);
            }
        }
    }
}