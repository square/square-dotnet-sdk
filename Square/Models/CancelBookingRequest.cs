
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CancelBookingRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"IdempotencyKey = {(IdempotencyKey == null ? "null" : IdempotencyKey == string.Empty ? "" : IdempotencyKey)}");
            toStringOutput.Add($"BookingVersion = {(BookingVersion == null ? "null" : BookingVersion.ToString())}");
        }

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

            return obj is CancelBookingRequest other &&
                ((IdempotencyKey == null && other.IdempotencyKey == null) || (IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((BookingVersion == null && other.BookingVersion == null) || (BookingVersion?.Equals(other.BookingVersion) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1446943632;

            if (IdempotencyKey != null)
            {
               hashCode += IdempotencyKey.GetHashCode();
            }

            if (BookingVersion != null)
            {
               hashCode += BookingVersion.GetHashCode();
            }

            return hashCode;
        }

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