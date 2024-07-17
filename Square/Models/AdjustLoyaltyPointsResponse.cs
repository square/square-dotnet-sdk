namespace Square.Models
{
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

    /// <summary>
    /// AdjustLoyaltyPointsResponse.
    /// </summary>
    public class AdjustLoyaltyPointsResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdjustLoyaltyPointsResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="mEvent">event.</param>
        public AdjustLoyaltyPointsResponse(
            IList<Models.Error> errors = null,
            Models.LoyaltyEvent mEvent = null)
        {
            this.Errors = errors;
            this.MEvent = mEvent;
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"AdjustLoyaltyPointsResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is AdjustLoyaltyPointsResponse other &&                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true)) &&
                ((this.MEvent == null && other.MEvent == null) || (this.MEvent?.Equals(other.MEvent) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1284922257;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.Errors, this.MEvent);

            return hashCode;
        }
        internal AdjustLoyaltyPointsResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"this.MEvent = {(this.MEvent == null ? "null" : this.MEvent.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .MEvent(this.MEvent);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.LoyaltyEvent mEvent;

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
            /// Builds class object.
            /// </summary>
            /// <returns> AdjustLoyaltyPointsResponse. </returns>
            public AdjustLoyaltyPointsResponse Build()
            {
                return new AdjustLoyaltyPointsResponse(
                    this.errors,
                    this.mEvent);
            }
        }
    }
}