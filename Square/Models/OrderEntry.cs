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
    public class OrderEntry 
    {
        public OrderEntry(string orderId = null,
            int? version = null,
            string locationId = null)
        {
            OrderId = orderId;
            Version = version;
            LocationId = locationId;
        }

        /// <summary>
        /// The id of the Order
        /// </summary>
        [JsonProperty("order_id")]
        public string OrderId { get; }

        /// <summary>
        /// Version number which is incremented each time an update is committed to the order.
        /// Orders that were not created through the API will not include a version and
        /// thus cannot be updated.
        /// [Read more about working with versions](https://developer.squareup.com/docs/orders-api/manage-orders#update-orders).
        /// </summary>
        [JsonProperty("version")]
        public int? Version { get; }

        /// <summary>
        /// The location id the Order belongs to.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .OrderId(OrderId)
                .Version(Version)
                .LocationId(LocationId);
            return builder;
        }

        public class Builder
        {
            private string orderId;
            private int? version;
            private string locationId;

            public Builder() { }
            public Builder OrderId(string value)
            {
                orderId = value;
                return this;
            }

            public Builder Version(int? value)
            {
                version = value;
                return this;
            }

            public Builder LocationId(string value)
            {
                locationId = value;
                return this;
            }

            public OrderEntry Build()
            {
                return new OrderEntry(orderId,
                    version,
                    locationId);
            }
        }
    }
}