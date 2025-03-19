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
using Square.Legacy.Http.Client;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// AccumulateLoyaltyPointsResponse.
    /// </summary>
    public class AccumulateLoyaltyPointsResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccumulateLoyaltyPointsResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="mEvent">event.</param>
        /// <param name="events">events.</param>
        public AccumulateLoyaltyPointsResponse(
            IList<Models.Error> errors = null,
            Models.LoyaltyEvent mEvent = null,
            IList<Models.LoyaltyEvent> events = null
        )
        {
            this.Errors = errors;
            this.MEvent = mEvent;
            this.Events = events;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Provides information about a loyalty event.
        /// For more information, see [Search for Balance-Changing Loyalty Events](https://developer.squareup.com/docs/loyalty-api/loyalty-events).
        /// </summary>
        [JsonProperty("event", NullValueHandling = NullValueHandling.Ignore)]
        public Models.LoyaltyEvent MEvent { get; }

        /// <summary>
        /// The resulting loyalty events. If the purchase qualifies for points, the `ACCUMULATE_POINTS` event
        /// is always included. When using the Orders API, the `ACCUMULATE_PROMOTION_POINTS` event is included
        /// if the purchase also qualifies for a loyalty promotion.
        /// </summary>
        [JsonProperty("events", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.LoyaltyEvent> Events { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"AccumulateLoyaltyPointsResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is AccumulateLoyaltyPointsResponse other
                && (
                    (this.Context == null && other.Context == null)
                    || this.Context?.Equals(other.Context) == true
                )
                && (
                    this.Errors == null && other.Errors == null
                    || this.Errors?.Equals(other.Errors) == true
                )
                && (
                    this.MEvent == null && other.MEvent == null
                    || this.MEvent?.Equals(other.MEvent) == true
                )
                && (
                    this.Events == null && other.Events == null
                    || this.Events?.Equals(other.Events) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1983236594;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(hashCode, this.Errors, this.MEvent, this.Events);

            return hashCode;
        }

        internal AccumulateLoyaltyPointsResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add(
                $"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}"
            );
            toStringOutput.Add(
                $"this.MEvent = {(this.MEvent == null ? "null" : this.MEvent.ToString())}"
            );
            toStringOutput.Add(
                $"this.Events = {(this.Events == null ? "null" : $"[{string.Join(", ", this.Events)} ]")}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder().Errors(this.Errors).MEvent(this.MEvent).Events(this.Events);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.LoyaltyEvent mEvent;
            private IList<Models.LoyaltyEvent> events;

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
            /// MEvent.
            /// </summary>
            /// <param name="mEvent"> mEvent. </param>
            /// <returns> Builder. </returns>
            public Builder MEvent(Models.LoyaltyEvent mEvent)
            {
                this.mEvent = mEvent;
                return this;
            }

            /// <summary>
            /// Events.
            /// </summary>
            /// <param name="events"> events. </param>
            /// <returns> Builder. </returns>
            public Builder Events(IList<Models.LoyaltyEvent> events)
            {
                this.events = events;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> AccumulateLoyaltyPointsResponse. </returns>
            public AccumulateLoyaltyPointsResponse Build()
            {
                return new AccumulateLoyaltyPointsResponse(this.errors, this.mEvent, this.events);
            }
        }
    }
}
