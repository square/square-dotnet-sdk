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
    /// OrderFulfillmentPickupDetailsCurbsidePickupDetails.
    /// </summary>
    public class OrderFulfillmentPickupDetailsCurbsidePickupDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderFulfillmentPickupDetailsCurbsidePickupDetails"/> class.
        /// </summary>
        /// <param name="curbsideDetails">curbside_details.</param>
        /// <param name="buyerArrivedAt">buyer_arrived_at.</param>
        public OrderFulfillmentPickupDetailsCurbsidePickupDetails(
            string curbsideDetails = null,
            string buyerArrivedAt = null)
        {
            this.CurbsideDetails = curbsideDetails;
            this.BuyerArrivedAt = buyerArrivedAt;
        }

        /// <summary>
        /// Specific details for curbside pickup, such as parking number and vehicle model.
        /// </summary>
        [JsonProperty("curbside_details", NullValueHandling = NullValueHandling.Ignore)]
        public string CurbsideDetails { get; }

        /// <summary>
        /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        /// indicating when the buyer arrived and is waiting for pickup. The timestamp must be in RFC 3339 format
        /// (for example, "2016-09-04T23:59:33.123Z").
        /// </summary>
        [JsonProperty("buyer_arrived_at", NullValueHandling = NullValueHandling.Ignore)]
        public string BuyerArrivedAt { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrderFulfillmentPickupDetailsCurbsidePickupDetails : ({string.Join(", ", toStringOutput)})";
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

            return obj is OrderFulfillmentPickupDetailsCurbsidePickupDetails other &&
                ((this.CurbsideDetails == null && other.CurbsideDetails == null) || (this.CurbsideDetails?.Equals(other.CurbsideDetails) == true)) &&
                ((this.BuyerArrivedAt == null && other.BuyerArrivedAt == null) || (this.BuyerArrivedAt?.Equals(other.BuyerArrivedAt) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -126196706;
            hashCode = HashCode.Combine(this.CurbsideDetails, this.BuyerArrivedAt);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CurbsideDetails = {(this.CurbsideDetails == null ? "null" : this.CurbsideDetails == string.Empty ? "" : this.CurbsideDetails)}");
            toStringOutput.Add($"this.BuyerArrivedAt = {(this.BuyerArrivedAt == null ? "null" : this.BuyerArrivedAt == string.Empty ? "" : this.BuyerArrivedAt)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .CurbsideDetails(this.CurbsideDetails)
                .BuyerArrivedAt(this.BuyerArrivedAt);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string curbsideDetails;
            private string buyerArrivedAt;

             /// <summary>
             /// CurbsideDetails.
             /// </summary>
             /// <param name="curbsideDetails"> curbsideDetails. </param>
             /// <returns> Builder. </returns>
            public Builder CurbsideDetails(string curbsideDetails)
            {
                this.curbsideDetails = curbsideDetails;
                return this;
            }

             /// <summary>
             /// BuyerArrivedAt.
             /// </summary>
             /// <param name="buyerArrivedAt"> buyerArrivedAt. </param>
             /// <returns> Builder. </returns>
            public Builder BuyerArrivedAt(string buyerArrivedAt)
            {
                this.buyerArrivedAt = buyerArrivedAt;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> OrderFulfillmentPickupDetailsCurbsidePickupDetails. </returns>
            public OrderFulfillmentPickupDetailsCurbsidePickupDetails Build()
            {
                return new OrderFulfillmentPickupDetailsCurbsidePickupDetails(
                    this.curbsideDetails,
                    this.buyerArrivedAt);
            }
        }
    }
}