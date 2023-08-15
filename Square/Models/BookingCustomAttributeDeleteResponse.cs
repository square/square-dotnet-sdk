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
    /// BookingCustomAttributeDeleteResponse.
    /// </summary>
    public class BookingCustomAttributeDeleteResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookingCustomAttributeDeleteResponse"/> class.
        /// </summary>
        /// <param name="bookingId">booking_id.</param>
        /// <param name="errors">errors.</param>
        public BookingCustomAttributeDeleteResponse(
            string bookingId = null,
            IList<Models.Error> errors = null)
        {
            this.BookingId = bookingId;
            this.Errors = errors;
        }

        /// <summary>
        /// The ID of the [booking](entity:Booking) associated with the custom attribute.
        /// </summary>
        [JsonProperty("booking_id", NullValueHandling = NullValueHandling.Ignore)]
        public string BookingId { get; }

        /// <summary>
        /// Any errors that occurred while processing the individual request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BookingCustomAttributeDeleteResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is BookingCustomAttributeDeleteResponse other &&                ((this.BookingId == null && other.BookingId == null) || (this.BookingId?.Equals(other.BookingId) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 738197412;
            hashCode = HashCode.Combine(this.BookingId, this.Errors);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.BookingId = {(this.BookingId == null ? "null" : this.BookingId)}");
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .BookingId(this.BookingId)
                .Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string bookingId;
            private IList<Models.Error> errors;

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
            /// <returns> BookingCustomAttributeDeleteResponse. </returns>
            public BookingCustomAttributeDeleteResponse Build()
            {
                return new BookingCustomAttributeDeleteResponse(
                    this.bookingId,
                    this.errors);
            }
        }
    }
}