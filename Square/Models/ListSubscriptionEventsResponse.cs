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
    using Square.Http.Client;
    using Square.Utilities;

    /// <summary>
    /// ListSubscriptionEventsResponse.
    /// </summary>
    public class ListSubscriptionEventsResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListSubscriptionEventsResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="subscriptionEvents">subscription_events.</param>
        /// <param name="cursor">cursor.</param>
        public ListSubscriptionEventsResponse(
            IList<Models.Error> errors = null,
            IList<Models.SubscriptionEvent> subscriptionEvents = null,
            string cursor = null)
        {
            this.Errors = errors;
            this.SubscriptionEvents = subscriptionEvents;
            this.Cursor = cursor;
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
        /// The retrieved subscription events.
        /// </summary>
        [JsonProperty("subscription_events", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.SubscriptionEvent> SubscriptionEvents { get; }

        /// <summary>
        /// When the total number of resulting subscription events exceeds the limit of a paged response,
        /// the response includes a cursor for you to use in a subsequent request to fetch the next set of events.
        /// If the cursor is unset, the response contains the last page of the results.
        /// For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ListSubscriptionEventsResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is ListSubscriptionEventsResponse other &&                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true)) &&
                ((this.SubscriptionEvents == null && other.SubscriptionEvents == null) || (this.SubscriptionEvents?.Equals(other.SubscriptionEvents) == true)) &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1676672959;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.Errors, this.SubscriptionEvents, this.Cursor);

            return hashCode;
        }
        internal ListSubscriptionEventsResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"this.SubscriptionEvents = {(this.SubscriptionEvents == null ? "null" : $"[{string.Join(", ", this.SubscriptionEvents)} ]")}");
            toStringOutput.Add($"this.Cursor = {(this.Cursor == null ? "null" : this.Cursor == string.Empty ? "" : this.Cursor)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .SubscriptionEvents(this.SubscriptionEvents)
                .Cursor(this.Cursor);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private IList<Models.SubscriptionEvent> subscriptionEvents;
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
             /// SubscriptionEvents.
             /// </summary>
             /// <param name="subscriptionEvents"> subscriptionEvents. </param>
             /// <returns> Builder. </returns>
            public Builder SubscriptionEvents(IList<Models.SubscriptionEvent> subscriptionEvents)
            {
                this.subscriptionEvents = subscriptionEvents;
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
            /// <returns> ListSubscriptionEventsResponse. </returns>
            public ListSubscriptionEventsResponse Build()
            {
                return new ListSubscriptionEventsResponse(
                    this.errors,
                    this.subscriptionEvents,
                    this.cursor);
            }
        }
    }
}