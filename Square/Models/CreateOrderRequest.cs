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
            string idempotencyKey = null,
            string referenceId = null,
            IList<Models.CreateOrderRequestLineItem> lineItems = null,
            IList<Models.CreateOrderRequestTax> taxes = null,
            IList<Models.CreateOrderRequestDiscount> discounts = null)
        {
            Order = order;
            IdempotencyKey = idempotencyKey;
            ReferenceId = referenceId;
            LineItems = lineItems;
            Taxes = taxes;
            Discounts = discounts;
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
        /// A value you specify that uniquely identifies this
        /// order among orders you've created.
        /// If you're unsure whether a particular order was created successfully,
        /// you can reattempt it with the same idempotency key without
        /// worrying about creating duplicate orders.
        /// See [Idempotency](https://developer.squareup.com/docs/basics/api101/idempotency) for more information.
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <summary>
        /// __Deprecated__: Please set the reference_id on the nested [order](#type-order) field
        /// instead.
        /// An optional ID you can associate with the order for your own
        /// purposes (such as to associate the order with an entity ID in your
        /// own database).
        /// This value cannot exceed 40 characters.
        /// </summary>
        [JsonProperty("reference_id")]
        public string ReferenceId { get; }

        /// <summary>
        /// __Deprecated__: Please set the line_items on the nested [order](#type-order) field
        /// instead.
        /// The line items to associate with this order.
        /// Each line item represents a different product to include in a purchase.
        /// </summary>
        [JsonProperty("line_items")]
        public IList<Models.CreateOrderRequestLineItem> LineItems { get; }

        /// <summary>
        /// __Deprecated__: Please set the taxes on the nested [order](#type-order) field instead.
        /// The taxes to include on the order.
        /// </summary>
        [JsonProperty("taxes")]
        public IList<Models.CreateOrderRequestTax> Taxes { get; }

        /// <summary>
        /// __Deprecated__: Please set the discounts on the nested [order](#type-order) field instead.
        /// The discounts to include on the order.
        /// </summary>
        [JsonProperty("discounts")]
        public IList<Models.CreateOrderRequestDiscount> Discounts { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Order(Order)
                .IdempotencyKey(IdempotencyKey)
                .ReferenceId(ReferenceId)
                .LineItems(LineItems)
                .Taxes(Taxes)
                .Discounts(Discounts);
            return builder;
        }

        public class Builder
        {
            private Models.Order order;
            private string idempotencyKey;
            private string referenceId;
            private IList<Models.CreateOrderRequestLineItem> lineItems = new List<Models.CreateOrderRequestLineItem>();
            private IList<Models.CreateOrderRequestTax> taxes = new List<Models.CreateOrderRequestTax>();
            private IList<Models.CreateOrderRequestDiscount> discounts = new List<Models.CreateOrderRequestDiscount>();

            public Builder() { }
            public Builder Order(Models.Order value)
            {
                order = value;
                return this;
            }

            public Builder IdempotencyKey(string value)
            {
                idempotencyKey = value;
                return this;
            }

            public Builder ReferenceId(string value)
            {
                referenceId = value;
                return this;
            }

            public Builder LineItems(IList<Models.CreateOrderRequestLineItem> value)
            {
                lineItems = value;
                return this;
            }

            public Builder Taxes(IList<Models.CreateOrderRequestTax> value)
            {
                taxes = value;
                return this;
            }

            public Builder Discounts(IList<Models.CreateOrderRequestDiscount> value)
            {
                discounts = value;
                return this;
            }

            public CreateOrderRequest Build()
            {
                return new CreateOrderRequest(order,
                    idempotencyKey,
                    referenceId,
                    lineItems,
                    taxes,
                    discounts);
            }
        }
    }
}