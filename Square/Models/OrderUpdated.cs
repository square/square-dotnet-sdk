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
    public class OrderUpdated 
    {
        public OrderUpdated(string orderId = null,
            int? version = null,
            string locationId = null,
            string state = null,
            string createdAt = null,
            string updatedAt = null)
        {
            OrderId = orderId;
            Version = version;
            LocationId = locationId;
            State = state;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        /// <summary>
        /// The order's unique ID.
        /// </summary>
        [JsonProperty("order_id")]
        public string OrderId { get; }

        /// <summary>
        /// Version number which is incremented each time an update is committed to the order.
        /// Orders that were not created through the API will not include a version and
        /// thus cannot be updated.
        /// [Read more about working with versions](https://developer.squareup.com/docs/docs/orders-api/manage-orders#update-orders)
        /// </summary>
        [JsonProperty("version")]
        public int? Version { get; }

        /// <summary>
        /// The ID of the merchant location this order is associated with.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <summary>
        /// The state of the order.
        /// </summary>
        [JsonProperty("state")]
        public string State { get; }

        /// <summary>
        /// Timestamp for when the order was created in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; }

        /// <summary>
        /// Timestamp for when the order was last updated in RFC 3339 format.
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .OrderId(OrderId)
                .Version(Version)
                .LocationId(LocationId)
                .State(State)
                .CreatedAt(CreatedAt)
                .UpdatedAt(UpdatedAt);
            return builder;
        }

        public class Builder
        {
            private string orderId;
            private int? version;
            private string locationId;
            private string state;
            private string createdAt;
            private string updatedAt;

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

            public Builder State(string value)
            {
                state = value;
                return this;
            }

            public Builder CreatedAt(string value)
            {
                createdAt = value;
                return this;
            }

            public Builder UpdatedAt(string value)
            {
                updatedAt = value;
                return this;
            }

            public OrderUpdated Build()
            {
                return new OrderUpdated(orderId,
                    version,
                    locationId,
                    state,
                    createdAt,
                    updatedAt);
            }
        }
    }
}