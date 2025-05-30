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
    /// CreateBookingResponse.
    /// </summary>
    public class CreateBookingResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateBookingResponse"/> class.
        /// </summary>
        /// <param name="booking">booking.</param>
        /// <param name="errors">errors.</param>
        public CreateBookingResponse(
            Models.Booking booking = null,
            IList<Models.Error> errors = null
        )
        {
            this.Booking = booking;
            this.Errors = errors;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Represents a booking as a time-bound service contract for a seller's staff member to provide a specified service
        /// at a given location to a requesting customer in one or more appointment segments.
        /// </summary>
        [JsonProperty("booking", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Booking Booking { get; }

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
            return $"CreateBookingResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is CreateBookingResponse other
                && (
                    (this.Context == null && other.Context == null)
                    || this.Context?.Equals(other.Context) == true
                )
                && (
                    this.Booking == null && other.Booking == null
                    || this.Booking?.Equals(other.Booking) == true
                )
                && (
                    this.Errors == null && other.Errors == null
                    || this.Errors?.Equals(other.Errors) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1624993556;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(hashCode, this.Booking, this.Errors);

            return hashCode;
        }

        internal CreateBookingResponse ContextSetter(HttpContext context)
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
                $"this.Booking = {(this.Booking == null ? "null" : this.Booking.ToString())}"
            );
            toStringOutput.Add(
                $"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder().Booking(this.Booking).Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.Booking booking;
            private IList<Models.Error> errors;

            /// <summary>
            /// Booking.
            /// </summary>
            /// <param name="booking"> booking. </param>
            /// <returns> Builder. </returns>
            public Builder Booking(Models.Booking booking)
            {
                this.booking = booking;
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
            /// <returns> CreateBookingResponse. </returns>
            public CreateBookingResponse Build()
            {
                return new CreateBookingResponse(this.booking, this.errors);
            }
        }
    }
}
