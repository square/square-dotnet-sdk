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
    public class CreateOrderRequest 
    {
        public CreateOrderRequest(Models.Order order = null,
            string locationId = null,
            string idempotencyKey = null)
        {
            Order = order;
            LocationId = locationId;
            IdempotencyKey = idempotencyKey;
        }

        /// <summary>
        /// Contains all information related to a single order to process with Square,
        /// including line items that specify the products to purchase. Order objects also
        /// include information on any associated tenders, refunds, and returns.
        /// All Connect V2 Transactions have all been converted to Orders including all associated
        /// itemization data.
        /// </summary>
        [JsonProperty("order")]
        public Models.Order Order { get; }

        /// <summary>
        /// The ID of the business location to associate the order with.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <summary>
        /// A value you specify that uniquely identifies this
        /// order among orders you've created.
        /// If you're unsure whether a particular order was created successfully,
        /// you can reattempt it with the same idempotency key without
        /// worrying about creating duplicate orders.
        /// See [Idempotency](https://developer.squareup.com/docs/basics/api101/idempotency) for more information.
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Order(Order)
                .LocationId(LocationId)
                .IdempotencyKey(IdempotencyKey);
            return builder;
        }

        public class Builder
        {
            private Models.Order order;
            private string locationId;
            private string idempotencyKey;

            public Builder() { }
            public Builder Order(Models.Order value)
            {
                order = value;
                return this;
            }

            public Builder LocationId(string value)
            {
                locationId = value;
                return this;
            }

            public Builder IdempotencyKey(string value)
            {
                idempotencyKey = value;
                return this;
            }

            public CreateOrderRequest Build()
            {
                return new CreateOrderRequest(order,
                    locationId,
                    idempotencyKey);
            }
        }
    }
}