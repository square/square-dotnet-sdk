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
    /// ResumeSubscriptionResponse.
    /// </summary>
    public class ResumeSubscriptionResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResumeSubscriptionResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="subscription">subscription.</param>
        /// <param name="actions">actions.</param>
        public ResumeSubscriptionResponse(
            IList<Models.Error> errors = null,
            Models.Subscription subscription = null,
            IList<Models.SubscriptionAction> actions = null)
        {
            this.Errors = errors;
            this.Subscription = subscription;
            this.Actions = actions;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Errors encountered during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Represents a subscription purchased by a customer.
        /// For more information, see
        /// [Manage Subscriptions](https://developer.squareup.com/docs/subscriptions-api/manage-subscriptions).
        /// </summary>
        [JsonProperty("subscription", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Subscription Subscription { get; }

        /// <summary>
        /// A list of `RESUME` actions created by the request and scheduled for the subscription.
        /// </summary>
        [JsonProperty("actions", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.SubscriptionAction> Actions { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"ResumeSubscriptionResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is ResumeSubscriptionResponse other && 
                ((this.Context == null && other.Context == null) 
                 || this.Context?.Equals(other.Context) == true) && 
                (this.Errors == null && other.Errors == null ||
                 this.Errors?.Equals(other.Errors) == true) &&
                (this.Subscription == null && other.Subscription == null ||
                 this.Subscription?.Equals(other.Subscription) == true) &&
                (this.Actions == null && other.Actions == null ||
                 this.Actions?.Equals(other.Actions) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -818197898;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(hashCode, this.Errors, this.Subscription, this.Actions);

            return hashCode;
        }

        internal ResumeSubscriptionResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"this.Actions = {(this.Actions == null ? "null" : $"[{string.Join(", ", this.Actions)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .Subscription(this.Subscription)
                .Actions(this.Actions);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.Subscription subscription;
            private IList<Models.SubscriptionAction> actions;

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
            public Builder Subscription(Models.Subscription subscription)
            {
                this.subscription = subscription;
                return this;
            }

             /// <summary>
             /// Actions.
             /// </summary>
             /// <param name="actions"> actions. </param>
             /// <returns> Builder. </returns>
            public Builder Actions(IList<Models.SubscriptionAction> actions)
            {
                this.actions = actions;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ResumeSubscriptionResponse. </returns>
            public ResumeSubscriptionResponse Build()
            {
                return new ResumeSubscriptionResponse(
                    this.errors,
                    this.subscription,
                    this.actions);
            }
        }
    }
}