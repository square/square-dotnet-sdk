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
    public class UpdateOrderRequest 
    {
        public UpdateOrderRequest(Models.Order order = null,
            IList<string> fieldsToClear = null,
            string idempotencyKey = null)
        {
            Order = order;
            FieldsToClear = fieldsToClear;
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
        /// The [dot notation paths](https://developer.squareup.com/docs/orders-api/manage-orders#on-dot-notation)
        /// fields to clear. For example, `line_items[uid].note`
        /// [Read more about Deleting fields](https://developer.squareup.com/docs/orders-api/manage-orders#delete-fields).
        /// </summary>
        [JsonProperty("fields_to_clear")]
        public IList<string> FieldsToClear { get; }

        /// <summary>
        /// A value you specify that uniquely identifies this update request
        /// If you're unsure whether a particular update was applied to an order successfully,
        /// you can reattempt it with the same idempotency key without
        /// worrying about creating duplicate updates to the order.
        /// The latest order version will be returned.
        /// See [Idempotency](https://developer.squareup.com/docs/basics/api101/idempotency) for more information.
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Order(Order)
                .FieldsToClear(FieldsToClear)
                .IdempotencyKey(IdempotencyKey);
            return builder;
        }

        public class Builder
        {
            private Models.Order order;
            private IList<string> fieldsToClear = new List<string>();
            private string idempotencyKey;

            public Builder() { }
            public Builder Order(Models.Order value)
            {
                order = value;
                return this;
            }

            public Builder FieldsToClear(IList<string> value)
            {
                fieldsToClear = value;
                return this;
            }

            public Builder IdempotencyKey(string value)
            {
                idempotencyKey = value;
                return this;
            }

            public UpdateOrderRequest Build()
            {
                return new UpdateOrderRequest(order,
                    fieldsToClear,
                    idempotencyKey);
            }
        }
    }
}