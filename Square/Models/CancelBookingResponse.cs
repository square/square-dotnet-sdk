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
    /// CancelBookingResponse.
    /// </summary>
    public class CancelBookingResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CancelBookingResponse"/> class.
        /// </summary>
        /// <param name="booking">booking.</param>
        /// <param name="errors">errors.</param>
        public CancelBookingResponse(
            Models.Booking booking = null,
            IList<Models.Error> errors = null)
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
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CancelBookingResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is CancelBookingResponse other &&
                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Booking == null && other.Booking == null) || (this.Booking?.Equals(other.Booking) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1594649358;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.Booking, this.Errors);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Booking = {(this.Booking == null ? "null" : this.Booking.ToString())}");
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Booking(this.Booking)
                .Errors(this.Errors);
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
            /// <returns> CancelBookingResponse. </returns>
            public CancelBookingResponse Build()
            {
                return new CancelBookingResponse(
                    this.booking,
                    this.errors);
            }
        }
    }
}