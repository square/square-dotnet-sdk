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
    /// CancelBookingRequest.
    /// </summary>
    public class CancelBookingRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="CancelBookingRequest"/> class.
        /// </summary>
        /// <param name="idempotencyKey">idempotency_key.</param>
        /// <param name="bookingVersion">booking_version.</param>
        public CancelBookingRequest(
            string idempotencyKey = null,
            int? bookingVersion = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "idempotency_key", false },
                { "booking_version", false }
            };

            if (idempotencyKey != null)
            {
                shouldSerialize["idempotency_key"] = true;
                this.IdempotencyKey = idempotencyKey;
            }

            if (bookingVersion != null)
            {
                shouldSerialize["booking_version"] = true;
                this.BookingVersion = bookingVersion;
            }

        }
        internal CancelBookingRequest(Dictionary<string, bool> shouldSerialize,
            string idempotencyKey = null,
            int? bookingVersion = null)
        {
            this.shouldSerialize = shouldSerialize;
            IdempotencyKey = idempotencyKey;
            BookingVersion = bookingVersion;
        }

        /// <summary>
        /// A unique key to make this request an idempotent operation.
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <summary>
        /// The revision number for the booking used for optimistic concurrency.
        /// </summary>
        [JsonProperty("booking_version")]
        public int? BookingVersion { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CancelBookingRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeIdempotencyKey()
        {
            return this.shouldSerialize["idempotency_key"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBookingVersion()
        {
            return this.shouldSerialize["booking_version"];
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

            return obj is CancelBookingRequest other &&
                ((this.IdempotencyKey == null && other.IdempotencyKey == null) || (this.IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((this.BookingVersion == null && other.BookingVersion == null) || (this.BookingVersion?.Equals(other.BookingVersion) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1446943632;
            hashCode = HashCode.Combine(this.IdempotencyKey, this.BookingVersion);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.IdempotencyKey = {(this.IdempotencyKey == null ? "null" : this.IdempotencyKey == string.Empty ? "" : this.IdempotencyKey)}");
            toStringOutput.Add($"this.BookingVersion = {(this.BookingVersion == null ? "null" : this.BookingVersion.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .IdempotencyKey(this.IdempotencyKey)
                .BookingVersion(this.BookingVersion);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "idempotency_key", false },
                { "booking_version", false },
            };

            private string idempotencyKey;
            private int? bookingVersion;

             /// <summary>
             /// IdempotencyKey.
             /// </summary>
             /// <param name="idempotencyKey"> idempotencyKey. </param>
             /// <returns> Builder. </returns>
            public Builder IdempotencyKey(string idempotencyKey)
            {
                shouldSerialize["idempotency_key"] = true;
                this.idempotencyKey = idempotencyKey;
                return this;
            }

             /// <summary>
             /// BookingVersion.
             /// </summary>
             /// <param name="bookingVersion"> bookingVersion. </param>
             /// <returns> Builder. </returns>
            public Builder BookingVersion(int? bookingVersion)
            {
                shouldSerialize["booking_version"] = true;
                this.bookingVersion = bookingVersion;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetIdempotencyKey()
            {
                this.shouldSerialize["idempotency_key"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetBookingVersion()
            {
                this.shouldSerialize["booking_version"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CancelBookingRequest. </returns>
            public CancelBookingRequest Build()
            {
                return new CancelBookingRequest(shouldSerialize,
                    this.idempotencyKey,
                    this.bookingVersion);
            }
        }
    }
}