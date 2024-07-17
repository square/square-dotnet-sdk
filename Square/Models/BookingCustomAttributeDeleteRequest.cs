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
    /// BookingCustomAttributeDeleteRequest.
    /// </summary>
    public class BookingCustomAttributeDeleteRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookingCustomAttributeDeleteRequest"/> class.
        /// </summary>
        /// <param name="bookingId">booking_id.</param>
        /// <param name="key">key.</param>
        public BookingCustomAttributeDeleteRequest(
            string bookingId,
            string key)
        {
            this.BookingId = bookingId;
            this.Key = key;
        }

        /// <summary>
        /// The ID of the target [booking](entity:Booking).
        /// </summary>
        [JsonProperty("booking_id")]
        public string BookingId { get; }

        /// <summary>
        /// The key of the custom attribute to delete. This key must match the `key` of a
        /// custom attribute definition in the Square seller account. If the requesting application is not
        /// the definition owner, you must use the qualified key.
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BookingCustomAttributeDeleteRequest : ({string.Join(", ", toStringOutput)})";
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
            return obj is BookingCustomAttributeDeleteRequest other &&                ((this.BookingId == null && other.BookingId == null) || (this.BookingId?.Equals(other.BookingId) == true)) &&
                ((this.Key == null && other.Key == null) || (this.Key?.Equals(other.Key) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -289906734;
            hashCode = HashCode.Combine(this.BookingId, this.Key);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.BookingId = {(this.BookingId == null ? "null" : this.BookingId)}");
            toStringOutput.Add($"this.Key = {(this.Key == null ? "null" : this.Key)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.BookingId,
                this.Key);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string bookingId;
            private string key;

            /// <summary>
            /// Initialize Builder for BookingCustomAttributeDeleteRequest.
            /// </summary>
            /// <param name="bookingId"> bookingId. </param>
            /// <param name="key"> key. </param>
            public Builder(
                string bookingId,
                string key)
            {
                this.bookingId = bookingId;
                this.key = key;
            }

             /// <summary>
             /// BookingId.
             /// </summary>
             /// <param name="bookingId"> bookingId. </param>
             /// <returns> Builder. </returns>
            public Builder BookingId(string bookingId)
            {
                this.bookingId = bookingId;
                return this;
            }

             /// <summary>
             /// Key.
             /// </summary>
             /// <param name="key"> key. </param>
             /// <returns> Builder. </returns>
            public Builder Key(string key)
            {
                this.key = key;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BookingCustomAttributeDeleteRequest. </returns>
            public BookingCustomAttributeDeleteRequest Build()
            {
                return new BookingCustomAttributeDeleteRequest(
                    this.bookingId,
                    this.key);
            }
        }
    }
}