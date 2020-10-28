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
    public class OrderFulfillmentPickupDetailsCurbsidePickupDetails 
    {
        public OrderFulfillmentPickupDetailsCurbsidePickupDetails(string curbsideDetails = null,
            string buyerArrivedAt = null)
        {
            CurbsideDetails = curbsideDetails;
            BuyerArrivedAt = buyerArrivedAt;
        }

        /// <summary>
        /// Specific details for curbside pickup, such as parking number, vehicle model, etc.
        /// </summary>
        [JsonProperty("curbside_details", NullValueHandling = NullValueHandling.Ignore)]
        public string CurbsideDetails { get; }

        /// <summary>
        /// The [timestamp](#workingwithdates) in RFC 3339 timestamp format, e.g., "2016-09-04T23:59:33.123Z",
        /// indicating when the buyer arrived and is waiting for pickup.
        /// </summary>
        [JsonProperty("buyer_arrived_at", NullValueHandling = NullValueHandling.Ignore)]
        public string BuyerArrivedAt { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .CurbsideDetails(CurbsideDetails)
                .BuyerArrivedAt(BuyerArrivedAt);
            return builder;
        }

        public class Builder
        {
            private string curbsideDetails;
            private string buyerArrivedAt;



            public Builder CurbsideDetails(string curbsideDetails)
            {
                this.curbsideDetails = curbsideDetails;
                return this;
            }

            public Builder BuyerArrivedAt(string buyerArrivedAt)
            {
                this.buyerArrivedAt = buyerArrivedAt;
                return this;
            }

            public OrderFulfillmentPickupDetailsCurbsidePickupDetails Build()
            {
                return new OrderFulfillmentPickupDetailsCurbsidePickupDetails(curbsideDetails,
                    buyerArrivedAt);
            }
        }
    }
}