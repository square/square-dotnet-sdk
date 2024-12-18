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
using Square.Http.Client;
using Square.Utilities;

namespace Square.Models
{
    /// <summary>
    /// UpdateWebhookSubscriptionResponse.
    /// </summary>
    public class UpdateWebhookSubscriptionResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateWebhookSubscriptionResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="subscription">subscription.</param>
        public UpdateWebhookSubscriptionResponse(
            IList<Models.Error> errors = null,
            Models.WebhookSubscription subscription = null)
        {
            this.Errors = errors;
            this.Subscription = subscription;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Information on errors encountered during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

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
            return $"UpdateWebhookSubscriptionResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is UpdateWebhookSubscriptionResponse other && 
                ((this.Context == null && other.Context == null) 
                 || this.Context?.Equals(other.Context) == true) && 
                (this.Errors == null && other.Errors == null ||
                 this.Errors?.Equals(other.Errors) == true) &&
                (this.Subscription == null && other.Subscription == null ||
                 this.Subscription?.Equals(other.Subscription) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 126925503;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(hashCode, this.Errors, this.Subscription);

            return hashCode;
        }

        internal UpdateWebhookSubscriptionResponse ContextSetter(HttpContext context)
        {
            this.Context = context;
            return this;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
            toStringOutput.Add($"this.Subscription = {(this.Subscription == null ? "null" : this.Subscription.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .Subscription(this.Subscription);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.WebhookSubscription subscription;

             /// <summary>
             /// Errors.
             /// </summary>
             /// <param name="errors"> errors. </param>
             /// <returns> Builder. </returns>
            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
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
            /// Builds class object.
            /// </summary>
            /// <returns> UpdateWebhookSubscriptionResponse. </returns>
            public UpdateWebhookSubscriptionResponse Build()
            {
                return new UpdateWebhookSubscriptionResponse(
                    this.errors,
                    this.subscription);
            }
        }
    }
}