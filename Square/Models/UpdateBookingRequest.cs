using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class UpdateBookingRequest 
    {
        public UpdateBookingRequest(Models.Booking booking,
            string idempotencyKey = null)
        {
            IdempotencyKey = idempotencyKey;
            Booking = booking;
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

        public Builder ToBuilder()
        {
            var builder = new Builder(Booking)
                .IdempotencyKey(IdempotencyKey);
            return builder;
        }

        public class Builder
        {
            private Models.Booking booking;
            private string idempotencyKey;

            public Builder(Models.Booking booking)
            {
                this.booking = booking;
            }

            public Builder Booking(Models.Booking booking)
            {
                this.booking = booking;
                return this;
            }

            public Builder IdempotencyKey(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
                return this;
            }

            public UpdateBookingRequest Build()
            {
                return new UpdateBookingRequest(booking,
                    idempotencyKey);
            }
        }
    }
}