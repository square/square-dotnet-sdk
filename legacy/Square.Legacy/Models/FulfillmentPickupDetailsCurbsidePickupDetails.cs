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
using Square.Legacy;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// FulfillmentPickupDetailsCurbsidePickupDetails.
    /// </summary>
    public class FulfillmentPickupDetailsCurbsidePickupDetails
    {
        private readonly Dictionary<string, bool> shouldSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="FulfillmentPickupDetailsCurbsidePickupDetails"/> class.
        /// </summary>
        /// <param name="curbsideDetails">curbside_details.</param>
        /// <param name="buyerArrivedAt">buyer_arrived_at.</param>
        public FulfillmentPickupDetailsCurbsidePickupDetails(
            string curbsideDetails = null,
            string buyerArrivedAt = null
        )
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "curbside_details", false },
                { "buyer_arrived_at", false },
            };

            if (curbsideDetails != null)
            {
                shouldSerialize["curbside_details"] = true;
                this.CurbsideDetails = curbsideDetails;
            }

            if (buyerArrivedAt != null)
            {
                shouldSerialize["buyer_arrived_at"] = true;
                this.BuyerArrivedAt = buyerArrivedAt;
            }
        }

        internal FulfillmentPickupDetailsCurbsidePickupDetails(
            Dictionary<string, bool> shouldSerialize,
            string curbsideDetails = null,
            string buyerArrivedAt = null
        )
        {
            this.shouldSerialize = shouldSerialize;
            CurbsideDetails = curbsideDetails;
            BuyerArrivedAt = buyerArrivedAt;
        }

        /// <summary>
        /// Specific details for curbside pickup, such as parking number and vehicle model.
        /// </summary>
        [JsonProperty("curbside_details")]
        public string CurbsideDetails { get; }

        /// <summary>
        /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        /// indicating when the buyer arrived and is waiting for pickup. The timestamp must be in RFC 3339 format
        /// (for example, "2016-09-04T23:59:33.123Z").
        /// </summary>
        [JsonProperty("buyer_arrived_at")]
        public string BuyerArrivedAt { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"FulfillmentPickupDetailsCurbsidePickupDetails : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCurbsideDetails()
        {
            return this.shouldSerialize["curbside_details"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBuyerArrivedAt()
        {
            return this.shouldSerialize["buyer_arrived_at"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is FulfillmentPickupDetailsCurbsidePickupDetails other
                && (
                    this.CurbsideDetails == null && other.CurbsideDetails == null
                    || this.CurbsideDetails?.Equals(other.CurbsideDetails) == true
                )
                && (
                    this.BuyerArrivedAt == null && other.BuyerArrivedAt == null
                    || this.BuyerArrivedAt?.Equals(other.BuyerArrivedAt) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1397619008;
            hashCode = HashCode.Combine(hashCode, this.CurbsideDetails, this.BuyerArrivedAt);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CurbsideDetails = {this.CurbsideDetails ?? "null"}");
            toStringOutput.Add($"this.BuyerArrivedAt = {this.BuyerArrivedAt ?? "null"}");
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
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "curbside_details", false },
                { "buyer_arrived_at", false },
            };

            private string curbsideDetails;
            private string buyerArrivedAt;

            /// <summary>
            /// CurbsideDetails.
            /// </summary>
            /// <param name="curbsideDetails"> curbsideDetails. </param>
            /// <returns> Builder. </returns>
            public Builder CurbsideDetails(string curbsideDetails)
            {
                shouldSerialize["curbside_details"] = true;
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
                shouldSerialize["buyer_arrived_at"] = true;
                this.buyerArrivedAt = buyerArrivedAt;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetCurbsideDetails()
            {
                this.shouldSerialize["curbside_details"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetBuyerArrivedAt()
            {
                this.shouldSerialize["buyer_arrived_at"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> FulfillmentPickupDetailsCurbsidePickupDetails. </returns>
            public FulfillmentPickupDetailsCurbsidePickupDetails Build()
            {
                return new FulfillmentPickupDetailsCurbsidePickupDetails(
                    shouldSerialize,
                    this.curbsideDetails,
                    this.buyerArrivedAt
                );
            }
        }
    }
}
