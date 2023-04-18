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
    /// TestWebhookSubscriptionRequest.
    /// </summary>
    public class TestWebhookSubscriptionRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="TestWebhookSubscriptionRequest"/> class.
        /// </summary>
        /// <param name="eventType">event_type.</param>
        public TestWebhookSubscriptionRequest(
            string eventType = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "event_type", false }
            };

            if (eventType != null)
            {
                shouldSerialize["event_type"] = true;
                this.EventType = eventType;
            }

        }
        internal TestWebhookSubscriptionRequest(Dictionary<string, bool> shouldSerialize,
            string eventType = null)
        {
            this.shouldSerialize = shouldSerialize;
            EventType = eventType;
        }

        /// <summary>
        /// The event type that will be used to test the [Subscription](entity:WebhookSubscription). The event type must be
        /// contained in the list of event types in the [Subscription](entity:WebhookSubscription).
        /// </summary>
        [JsonProperty("event_type")]
        public string EventType { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"TestWebhookSubscriptionRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEventType()
        {
            return this.shouldSerialize["event_type"];
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

            return obj is TestWebhookSubscriptionRequest other &&
                ((this.EventType == null && other.EventType == null) || (this.EventType?.Equals(other.EventType) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 133393697;
            hashCode = HashCode.Combine(this.EventType);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.EventType = {(this.EventType == null ? "null" : this.EventType == string.Empty ? "" : this.EventType)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .EventType(this.EventType);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "event_type", false },
            };

            private string eventType;

             /// <summary>
             /// EventType.
             /// </summary>
             /// <param name="eventType"> eventType. </param>
             /// <returns> Builder. </returns>
            public Builder EventType(string eventType)
            {
                shouldSerialize["event_type"] = true;
                this.eventType = eventType;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetEventType()
            {
                this.shouldSerialize["event_type"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> TestWebhookSubscriptionRequest. </returns>
            public TestWebhookSubscriptionRequest Build()
            {
                return new TestWebhookSubscriptionRequest(shouldSerialize,
                    this.eventType);
            }
        }
    }
}