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
    using Square.Utilities;

    /// <summary>
    /// BulkRetrieveBookingsRequest.
    /// </summary>
    public class BulkRetrieveBookingsRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BulkRetrieveBookingsRequest"/> class.
        /// </summary>
        /// <param name="bookingIds">booking_ids.</param>
        public BulkRetrieveBookingsRequest(
            IList<string> bookingIds)
        {
            this.BookingIds = bookingIds;
        }

        /// <summary>
        /// A non-empty list of [Booking](entity:Booking) IDs specifying bookings to retrieve.
        /// </summary>
        [JsonProperty("booking_ids")]
        public IList<string> BookingIds { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BulkRetrieveBookingsRequest : ({string.Join(", ", toStringOutput)})";
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
            return obj is BulkRetrieveBookingsRequest other &&                ((this.BookingIds == null && other.BookingIds == null) || (this.BookingIds?.Equals(other.BookingIds) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 304724873;
            hashCode = HashCode.Combine(this.BookingIds);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.BookingIds = {(this.BookingIds == null ? "null" : $"[{string.Join(", ", this.BookingIds)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.BookingIds);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<string> bookingIds;

            /// <summary>
            /// Initialize Builder for BulkRetrieveBookingsRequest.
            /// </summary>
            /// <param name="bookingIds"> bookingIds. </param>
            public Builder(
                IList<string> bookingIds)
            {
                this.bookingIds = bookingIds;
            }

             /// <summary>
             /// BookingIds.
             /// </summary>
             /// <param name="bookingIds"> bookingIds. </param>
             /// <returns> Builder. </returns>
            public Builder BookingIds(IList<string> bookingIds)
            {
                this.bookingIds = bookingIds;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BulkRetrieveBookingsRequest. </returns>
            public BulkRetrieveBookingsRequest Build()
            {
                return new BulkRetrieveBookingsRequest(
                    this.bookingIds);
            }
        }
    }
}