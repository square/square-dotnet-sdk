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
    public class CancelBookingRequest 
    {
        public CancelBookingRequest(string idempotencyKey = null,
            int? bookingVersion = null)
        {
            IdempotencyKey = idempotencyKey;
            BookingVersion = bookingVersion;
        }

        /// <summary>
        /// A unique key to make this request an idempotent operation.
        /// </summary>
        [JsonProperty("idempotency_key", NullValueHandling = NullValueHandling.Ignore)]
        public string IdempotencyKey { get; }

        /// <summary>
        /// The revision number for the booking used for optimistic concurrency.
        /// </summary>
        [JsonProperty("booking_version", NullValueHandling = NullValueHandling.Ignore)]
        public int? BookingVersion { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .IdempotencyKey(IdempotencyKey)
                .BookingVersion(BookingVersion);
            return builder;
        }

        public class Builder
        {
            private string idempotencyKey;
            private int? bookingVersion;



            public Builder IdempotencyKey(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
                return this;
            }

            public Builder BookingVersion(int? bookingVersion)
            {
                this.bookingVersion = bookingVersion;
                return this;
            }

            public CancelBookingRequest Build()
            {
                return new CancelBookingRequest(idempotencyKey,
                    bookingVersion);
            }
        }
    }
}