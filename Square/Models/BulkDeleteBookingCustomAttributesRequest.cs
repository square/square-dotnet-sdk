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
    /// BulkDeleteBookingCustomAttributesRequest.
    /// </summary>
    public class BulkDeleteBookingCustomAttributesRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BulkDeleteBookingCustomAttributesRequest"/> class.
        /// </summary>
        /// <param name="values">values.</param>
        public BulkDeleteBookingCustomAttributesRequest(
            IDictionary<string, Models.BookingCustomAttributeDeleteRequest> values)
        {
            this.Values = values;
        }

        /// <summary>
        /// A map containing 1 to 25 individual Delete requests. For each request, provide an
        /// arbitrary ID that is unique for this `BulkDeleteBookingCustomAttributes` request and the
        /// information needed to delete a custom attribute.
        /// </summary>
        [JsonProperty("values")]
        public IDictionary<string, Models.BookingCustomAttributeDeleteRequest> Values { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BulkDeleteBookingCustomAttributesRequest : ({string.Join(", ", toStringOutput)})";
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
            return obj is BulkDeleteBookingCustomAttributesRequest other &&                ((this.Values == null && other.Values == null) || (this.Values?.Equals(other.Values) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1661459547;
            hashCode = HashCode.Combine(this.Values);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Values = {(this.Values == null ? "null" : this.Values.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Values);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IDictionary<string, Models.BookingCustomAttributeDeleteRequest> values;

            public Builder(
                IDictionary<string, Models.BookingCustomAttributeDeleteRequest> values)
            {
                this.values = values;
            }

             /// <summary>
             /// Values.
             /// </summary>
             /// <param name="values"> values. </param>
             /// <returns> Builder. </returns>
            public Builder Values(IDictionary<string, Models.BookingCustomAttributeDeleteRequest> values)
            {
                this.values = values;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BulkDeleteBookingCustomAttributesRequest. </returns>
            public BulkDeleteBookingCustomAttributesRequest Build()
            {
                return new BulkDeleteBookingCustomAttributesRequest(
                    this.values);
            }
        }
    }
}