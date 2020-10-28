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
    public class OrderCreated 
    {
        public OrderCreated(string orderId = null,
            int? version = null,
            string locationId = null,
            string state = null,
            string createdAt = null)
        {
            OrderId = orderId;
            Version = version;
            LocationId = locationId;
            State = state;
            CreatedAt = createdAt;
        }

        /// <summary>
        /// The order's unique ID.
        /// </summary>
        [JsonProperty("order_id", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderId { get; }

        /// <summary>
        /// Version number which is incremented each time an update is committed to the order.
        /// Orders that were not created through the API will not include a version and
        /// thus cannot be updated.
        /// [Read more about working with versions](https://developer.squareup.com/docs/docs/orders-api/manage-orders#update-orders)
        /// </summary>
        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public int? Version { get; }

        /// <summary>
        /// The ID of the merchant location this order is associated with.
        /// </summary>
        [JsonProperty("location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationId { get; }

        /// <summary>
        /// The state of the order.
        /// </summary>
        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; }

        /// <summary>
        /// Timestamp for when the order was created in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .OrderId(OrderId)
                .Version(Version)
                .LocationId(LocationId)
                .State(State)
                .CreatedAt(CreatedAt);
            return builder;
        }

        public class Builder
        {
            private string orderId;
            private int? version;
            private string locationId;
            private string state;
            private string createdAt;



            public Builder OrderId(string orderId)
            {
                this.orderId = orderId;
                return this;
            }

            public Builder Version(int? version)
            {
                this.version = version;
                return this;
            }

            public Builder LocationId(string locationId)
            {
                this.locationId = locationId;
                return this;
            }

            public Builder State(string state)
            {
                this.state = state;
                return this;
            }

            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

            public OrderCreated Build()
            {
                return new OrderCreated(orderId,
                    version,
                    locationId,
                    state,
                    createdAt);
            }
        }
    }
}