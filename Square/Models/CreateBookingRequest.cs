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
    /// CreateBookingRequest.
    /// </summary>
    public class CreateBookingRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateBookingRequest"/> class.
        /// </summary>
        /// <param name="booking">booking.</param>
        /// <param name="idempotencyKey">idempotency_key.</param>
        public CreateBookingRequest(
            Models.Booking booking,
            string idempotencyKey = null)
        {
            this.IdempotencyKey = idempotencyKey;
            this.Booking = booking;
        }

        /// <summary>
        /// A unique key to make this request an idempotent operation.
        /// </summary>
        [JsonProperty("idempotency_key", NullValueHandling = NullValueHandling.Ignore)]
        public string IdempotencyKey { get; }

        /// <summary>
        /// Represents a booking as a time-bound service contract for a seller's staff member to provide a specified service
        /// at a given location to a requesting customer in one or more appointment segments.
        /// </summary>
        [JsonProperty("booking")]
        public Models.Booking Booking { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateBookingRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is CreateBookingRequest other &&
                ((this.IdempotencyKey == null && other.IdempotencyKey == null) || (this.IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((this.Booking == null && other.Booking == null) || (this.Booking?.Equals(other.Booking) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -24081562;
            hashCode = HashCode.Combine(this.IdempotencyKey, this.Booking);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.IdempotencyKey = {(this.IdempotencyKey == null ? "null" : this.IdempotencyKey == string.Empty ? "" : this.IdempotencyKey)}");
            toStringOutput.Add($"this.Booking = {(this.Booking == null ? "null" : this.Booking.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Booking)
                .IdempotencyKey(this.IdempotencyKey);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.Booking booking;
            private string idempotencyKey;

            public Builder(
                Models.Booking booking)
            {
                this.booking = booking;
            }

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
             /// IdempotencyKey.
             /// </summary>
             /// <param name="idempotencyKey"> idempotencyKey. </param>
             /// <returns> Builder. </returns>
            public Builder IdempotencyKey(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CreateBookingRequest. </returns>
            public CreateBookingRequest Build()
            {
                return new CreateBookingRequest(
                    this.booking,
                    this.idempotencyKey);
            }
        }
    }
}