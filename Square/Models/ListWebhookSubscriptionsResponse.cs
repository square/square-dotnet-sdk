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
    /// ListWebhookSubscriptionsResponse.
    /// </summary>
    public class ListWebhookSubscriptionsResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListWebhookSubscriptionsResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="subscriptions">subscriptions.</param>
        /// <param name="cursor">cursor.</param>
        public ListWebhookSubscriptionsResponse(
            IList<Models.Error> errors = null,
            IList<Models.WebhookSubscription> subscriptions = null,
            string cursor = null)
        {
            this.Errors = errors;
            this.Subscriptions = subscriptions;
            this.Cursor = cursor;
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
        /// The requested list of [Subscription](entity:WebhookSubscription)s.
        /// </summary>
        [JsonProperty("subscriptions", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.WebhookSubscription> Subscriptions { get; }

        /// <summary>
        /// The pagination cursor to be used in a subsequent request. If empty,
        /// this is the final response.
        /// For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"ListWebhookSubscriptionsResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is ListWebhookSubscriptionsResponse other && 
                ((this.Context == null && other.Context == null) 
                 || this.Context?.Equals(other.Context) == true) && 
                (this.Errors == null && other.Errors == null ||
                 this.Errors?.Equals(other.Errors) == true) &&
                (this.Subscriptions == null && other.Subscriptions == null ||
                 this.Subscriptions?.Equals(other.Subscriptions) == true) &&
                (this.Cursor == null && other.Cursor == null ||
                 this.Cursor?.Equals(other.Cursor) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -2090514346;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(hashCode, this.Errors, this.Subscriptions, this.Cursor);

            return hashCode;
        }

        internal ListWebhookSubscriptionsResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"this.Subscriptions = {(this.Subscriptions == null ? "null" : $"[{string.Join(", ", this.Subscriptions)} ]")}");
            toStringOutput.Add($"this.Cursor = {this.Cursor ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .Subscriptions(this.Subscriptions)
                .Cursor(this.Cursor);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private IList<Models.WebhookSubscription> subscriptions;
            private string cursor;

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
             /// Subscriptions.
             /// </summary>
             /// <param name="subscriptions"> subscriptions. </param>
             /// <returns> Builder. </returns>
            public Builder Subscriptions(IList<Models.WebhookSubscription> subscriptions)
            {
                this.subscriptions = subscriptions;
                return this;
            }

             /// <summary>
             /// Cursor.
             /// </summary>
             /// <param name="cursor"> cursor. </param>
             /// <returns> Builder. </returns>
            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ListWebhookSubscriptionsResponse. </returns>
            public ListWebhookSubscriptionsResponse Build()
            {
                return new ListWebhookSubscriptionsResponse(
                    this.errors,
                    this.subscriptions,
                    this.cursor);
            }
        }
    }
}