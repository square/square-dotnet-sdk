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
    /// BulkRetrieveBookingsResponse.
    /// </summary>
    public class BulkRetrieveBookingsResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BulkRetrieveBookingsResponse"/> class.
        /// </summary>
        /// <param name="bookings">bookings.</param>
        /// <param name="errors">errors.</param>
        public BulkRetrieveBookingsResponse(
            IDictionary<string, Models.RetrieveBookingResponse> bookings = null,
            IList<Models.Error> errors = null)
        {
            this.Bookings = bookings;
            this.Errors = errors;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Requested bookings returned as a map containing `booking_id` as the key and `RetrieveBookingResponse` as the value.
        /// </summary>
        [JsonProperty("bookings", NullValueHandling = NullValueHandling.Ignore)]
        public IDictionary<string, Models.RetrieveBookingResponse> Bookings { get; }

        /// <summary>
        /// Errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BulkRetrieveBookingsResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is BulkRetrieveBookingsResponse other &&                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Bookings == null && other.Bookings == null) || (this.Bookings?.Equals(other.Bookings) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1741643215;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.Bookings, this.Errors);

            return hashCode;
        }
        internal BulkRetrieveBookingsResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"Bookings = {(this.Bookings == null ? "null" : this.Bookings.ToString())}");
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Bookings(this.Bookings)
                .Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IDictionary<string, Models.RetrieveBookingResponse> bookings;
            private IList<Models.Error> errors;

             /// <summary>
             /// Bookings.
             /// </summary>
             /// <param name="bookings"> bookings. </param>
             /// <returns> Builder. </returns>
            public Builder Bookings(IDictionary<string, Models.RetrieveBookingResponse> bookings)
            {
                this.bookings = bookings;
                return this;
            }

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
            /// Builds class object.
            /// </summary>
            /// <returns> BulkRetrieveBookingsResponse. </returns>
            public BulkRetrieveBookingsResponse Build()
            {
                return new BulkRetrieveBookingsResponse(
                    this.bookings,
                    this.errors);
            }
        }
    }
}