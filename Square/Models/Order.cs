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

namespace Square.Models
{
    /// <summary>
    /// Order.
    /// </summary>
    public class Order
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// </summary>
        /// <param name="locationId">location_id.</param>
        /// <param name="id">id.</param>
        /// <param name="referenceId">reference_id.</param>
        /// <param name="source">source.</param>
        /// <param name="customerId">customer_id.</param>
        /// <param name="lineItems">line_items.</param>
        /// <param name="taxes">taxes.</param>
        /// <param name="discounts">discounts.</param>
        /// <param name="serviceCharges">service_charges.</param>
        /// <param name="fulfillments">fulfillments.</param>
        /// <param name="returns">returns.</param>
        /// <param name="returnAmounts">return_amounts.</param>
        /// <param name="netAmounts">net_amounts.</param>
        /// <param name="roundingAdjustment">rounding_adjustment.</param>
        /// <param name="tenders">tenders.</param>
        /// <param name="refunds">refunds.</param>
        /// <param name="metadata">metadata.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="updatedAt">updated_at.</param>
        /// <param name="closedAt">closed_at.</param>
        /// <param name="state">state.</param>
        /// <param name="version">version.</param>
        /// <param name="totalMoney">total_money.</param>
        /// <param name="totalTaxMoney">total_tax_money.</param>
        /// <param name="totalDiscountMoney">total_discount_money.</param>
        /// <param name="totalTipMoney">total_tip_money.</param>
        /// <param name="totalServiceChargeMoney">total_service_charge_money.</param>
        /// <param name="ticketName">ticket_name.</param>
        /// <param name="pricingOptions">pricing_options.</param>
        /// <param name="rewards">rewards.</param>
        /// <param name="netAmountDueMoney">net_amount_due_money.</param>
        public Order(
            string locationId,
            string id = null,
            string referenceId = null,
            Models.OrderSource source = null,
            string customerId = null,
            IList<Models.OrderLineItem> lineItems = null,
            IList<Models.OrderLineItemTax> taxes = null,
            IList<Models.OrderLineItemDiscount> discounts = null,
            IList<Models.OrderServiceCharge> serviceCharges = null,
            IList<Models.Fulfillment> fulfillments = null,
            IList<Models.OrderReturn> returns = null,
            Models.OrderMoneyAmounts returnAmounts = null,
            Models.OrderMoneyAmounts netAmounts = null,
            Models.OrderRoundingAdjustment roundingAdjustment = null,
            IList<Models.Tender> tenders = null,
            IList<Models.Refund> refunds = null,
            IDictionary<string, string> metadata = null,
            string createdAt = null,
            string updatedAt = null,
            string closedAt = null,
            string state = null,
            int? version = null,
            Models.Money totalMoney = null,
            Models.Money totalTaxMoney = null,
            Models.Money totalDiscountMoney = null,
            Models.Money totalTipMoney = null,
            Models.Money totalServiceChargeMoney = null,
            string ticketName = null,
            Models.OrderPricingOptions pricingOptions = null,
            IList<Models.OrderReward> rewards = null,
            Models.Money netAmountDueMoney = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "reference_id", false },
                { "customer_id", false },
                { "line_items", false },
                { "taxes", false },
                { "discounts", false },
                { "service_charges", false },
                { "fulfillments", false },
                { "metadata", false },
                { "ticket_name", false }
            };
            this.Id = id;
            this.LocationId = locationId;

            if (referenceId != null)
            {
                shouldSerialize["reference_id"] = true;
                this.ReferenceId = referenceId;
            }
            this.Source = source;

            if (customerId != null)
            {
                shouldSerialize["customer_id"] = true;
                this.CustomerId = customerId;
            }

            if (lineItems != null)
            {
                shouldSerialize["line_items"] = true;
                this.LineItems = lineItems;
            }

            if (taxes != null)
            {
                shouldSerialize["taxes"] = true;
                this.Taxes = taxes;
            }

            if (discounts != null)
            {
                shouldSerialize["discounts"] = true;
                this.Discounts = discounts;
            }

            if (serviceCharges != null)
            {
                shouldSerialize["service_charges"] = true;
                this.ServiceCharges = serviceCharges;
            }

            if (fulfillments != null)
            {
                shouldSerialize["fulfillments"] = true;
                this.Fulfillments = fulfillments;
            }
            this.Returns = returns;
            this.ReturnAmounts = returnAmounts;
            this.NetAmounts = netAmounts;
            this.RoundingAdjustment = roundingAdjustment;
            this.Tenders = tenders;
            this.Refunds = refunds;

            if (metadata != null)
            {
                shouldSerialize["metadata"] = true;
                this.Metadata = metadata;
            }
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            this.ClosedAt = closedAt;
            this.State = state;
            this.Version = version;
            this.TotalMoney = totalMoney;
            this.TotalTaxMoney = totalTaxMoney;
            this.TotalDiscountMoney = totalDiscountMoney;
            this.TotalTipMoney = totalTipMoney;
            this.TotalServiceChargeMoney = totalServiceChargeMoney;

            if (ticketName != null)
            {
                shouldSerialize["ticket_name"] = true;
                this.TicketName = ticketName;
            }
            this.PricingOptions = pricingOptions;
            this.Rewards = rewards;
            this.NetAmountDueMoney = netAmountDueMoney;
        }

        internal Order(
            Dictionary<string, bool> shouldSerialize,
            string locationId,
            string id = null,
            string referenceId = null,
            Models.OrderSource source = null,
            string customerId = null,
            IList<Models.OrderLineItem> lineItems = null,
            IList<Models.OrderLineItemTax> taxes = null,
            IList<Models.OrderLineItemDiscount> discounts = null,
            IList<Models.OrderServiceCharge> serviceCharges = null,
            IList<Models.Fulfillment> fulfillments = null,
            IList<Models.OrderReturn> returns = null,
            Models.OrderMoneyAmounts returnAmounts = null,
            Models.OrderMoneyAmounts netAmounts = null,
            Models.OrderRoundingAdjustment roundingAdjustment = null,
            IList<Models.Tender> tenders = null,
            IList<Models.Refund> refunds = null,
            IDictionary<string, string> metadata = null,
            string createdAt = null,
            string updatedAt = null,
            string closedAt = null,
            string state = null,
            int? version = null,
            Models.Money totalMoney = null,
            Models.Money totalTaxMoney = null,
            Models.Money totalDiscountMoney = null,
            Models.Money totalTipMoney = null,
            Models.Money totalServiceChargeMoney = null,
            string ticketName = null,
            Models.OrderPricingOptions pricingOptions = null,
            IList<Models.OrderReward> rewards = null,
            Models.Money netAmountDueMoney = null)
        {
            this.shouldSerialize = shouldSerialize;
            Id = id;
            LocationId = locationId;
            ReferenceId = referenceId;
            Source = source;
            CustomerId = customerId;
            LineItems = lineItems;
            Taxes = taxes;
            Discounts = discounts;
            ServiceCharges = serviceCharges;
            Fulfillments = fulfillments;
            Returns = returns;
            ReturnAmounts = returnAmounts;
            NetAmounts = netAmounts;
            RoundingAdjustment = roundingAdjustment;
            Tenders = tenders;
            Refunds = refunds;
            Metadata = metadata;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            ClosedAt = closedAt;
            State = state;
            Version = version;
            TotalMoney = totalMoney;
            TotalTaxMoney = totalTaxMoney;
            TotalDiscountMoney = totalDiscountMoney;
            TotalTipMoney = totalTipMoney;
            TotalServiceChargeMoney = totalServiceChargeMoney;
            TicketName = ticketName;
            PricingOptions = pricingOptions;
            Rewards = rewards;
            NetAmountDueMoney = netAmountDueMoney;
        }

        /// <summary>
        /// The order's unique ID.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The ID of the seller location that this order is associated with.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <summary>
        /// A client-specified ID to associate an entity in another system
        /// with this order.
        /// </summary>
        [JsonProperty("reference_id")]
        public string ReferenceId { get; }

        /// <summary>
        /// Represents the origination details of an order.
        /// </summary>
        [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
        public Models.OrderSource Source { get; }

        /// <summary>
        /// The ID of the [customer]($m/Customer) associated with the order.
        /// You should specify a `customer_id` on the order (or the payment) to ensure that transactions
        /// are reliably linked to customers. Omitting this field might result in the creation of new
        /// [instant profiles](https://developer.squareup.com/docs/customers-api/what-it-does#instant-profiles).
        /// </summary>
        [JsonProperty("customer_id")]
        public string CustomerId { get; }

        /// <summary>
        /// The line items included in the order.
        /// </summary>
        [JsonProperty("line_items")]
        public IList<Models.OrderLineItem> LineItems { get; }

        /// <summary>
        /// The list of all taxes associated with the order.
        /// Taxes can be scoped to either `ORDER` or `LINE_ITEM`. For taxes with `LINE_ITEM` scope, an
        /// `OrderLineItemAppliedTax` must be added to each line item that the tax applies to. For taxes
        /// with `ORDER` scope, the server generates an `OrderLineItemAppliedTax` for every line item.
        /// On reads, each tax in the list includes the total amount of that tax applied to the order.
        /// __IMPORTANT__: If `LINE_ITEM` scope is set on any taxes in this field, using the deprecated
        /// `line_items.taxes` field results in an error. Use `line_items.applied_taxes`
        /// instead.
        /// </summary>
        [JsonProperty("taxes")]
        public IList<Models.OrderLineItemTax> Taxes { get; }

        /// <summary>
        /// The list of all discounts associated with the order.
        /// Discounts can be scoped to either `ORDER` or `LINE_ITEM`. For discounts scoped to `LINE_ITEM`,
        /// an `OrderLineItemAppliedDiscount` must be added to each line item that the discount applies to.
        /// For discounts with `ORDER` scope, the server generates an `OrderLineItemAppliedDiscount`
        /// for every line item.
        /// __IMPORTANT__: If `LINE_ITEM` scope is set on any discounts in this field, using the deprecated
        /// `line_items.discounts` field results in an error. Use `line_items.applied_discounts`
        /// instead.
        /// </summary>
        [JsonProperty("discounts")]
        public IList<Models.OrderLineItemDiscount> Discounts { get; }

        /// <summary>
        /// A list of service charges applied to the order.
        /// </summary>
        [JsonProperty("service_charges")]
        public IList<Models.OrderServiceCharge> ServiceCharges { get; }

        /// <summary>
        /// Details about order fulfillment.
        /// Orders can only be created with at most one fulfillment. However, orders returned
        /// by the API might contain multiple fulfillments.
        /// </summary>
        [JsonProperty("fulfillments")]
        public IList<Models.Fulfillment> Fulfillments { get; }

        /// <summary>
        /// A collection of items from sale orders being returned in this one. Normally part of an
        /// itemized return or exchange. There is exactly one `Return` object per sale `Order` being
        /// referenced.
        /// </summary>
        [JsonProperty("returns", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.OrderReturn> Returns { get; }

        /// <summary>
        /// A collection of various money amounts.
        /// </summary>
        [JsonProperty("return_amounts", NullValueHandling = NullValueHandling.Ignore)]
        public Models.OrderMoneyAmounts ReturnAmounts { get; }

        /// <summary>
        /// A collection of various money amounts.
        /// </summary>
        [JsonProperty("net_amounts", NullValueHandling = NullValueHandling.Ignore)]
        public Models.OrderMoneyAmounts NetAmounts { get; }

        /// <summary>
        /// A rounding adjustment of the money being returned. Commonly used to apply cash rounding
        /// when the minimum unit of the account is smaller than the lowest physical denomination of the currency.
        /// </summary>
        [JsonProperty("rounding_adjustment", NullValueHandling = NullValueHandling.Ignore)]
        public Models.OrderRoundingAdjustment RoundingAdjustment { get; }

        /// <summary>
        /// The tenders that were used to pay for the order.
        /// </summary>
        [JsonProperty("tenders", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Tender> Tenders { get; }

        /// <summary>
        /// The refunds that are part of this order.
        /// </summary>
        [JsonProperty("refunds", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Refund> Refunds { get; }

        /// <summary>
        /// Application-defined data attached to this order. Metadata fields are intended
        /// to store descriptive references or associations with an entity in another system or store brief
        /// information about the object. Square does not process this field; it only stores and returns it
        /// in relevant API calls. Do not use metadata to store any sensitive information (such as personally
        /// identifiable information or card details).
        /// Keys written by applications must be 60 characters or less and must be in the character set
        /// `[a-zA-Z0-9_-]`. Entries can also include metadata generated by Square. These keys are prefixed
        /// with a namespace, separated from the key with a ':' character.
        /// Values have a maximum length of 255 characters.
        /// An application can have up to 10 entries per metadata field.
        /// Entries written by applications are private and can only be read or modified by the same
        /// application.
        /// For more information, see  [Metadata](https://developer.squareup.com/docs/build-basics/metadata).
        /// </summary>
        [JsonProperty("metadata")]
        public IDictionary<string, string> Metadata { get; }

        /// <summary>
        /// The timestamp for when the order was created, at server side, in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z").
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// The timestamp for when the order was last updated, at server side, in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z").
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

        /// <summary>
        /// The timestamp for when the order reached a terminal [state](entity:OrderState), in RFC 3339 format (for example "2016-09-04T23:59:33.123Z").
        /// </summary>
        [JsonProperty("closed_at", NullValueHandling = NullValueHandling.Ignore)]
        public string ClosedAt { get; }

        /// <summary>
        /// The state of the order.
        /// </summary>
        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; }

        /// <summary>
        /// The version number, which is incremented each time an update is committed to the order.
        /// Orders not created through the API do not include a version number and
        /// therefore cannot be updated.
        /// [Read more about working with versions](https://developer.squareup.com/docs/orders-api/manage-orders/update-orders).
        /// </summary>
        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public int? Version { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("total_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money TotalMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("total_tax_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money TotalTaxMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("total_discount_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money TotalDiscountMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("total_tip_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money TotalTipMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("total_service_charge_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money TotalServiceChargeMoney { get; }

        /// <summary>
        /// A short-term identifier for the order (such as a customer first name,
        /// table number, or auto-generated order number that resets daily).
        /// </summary>
        [JsonProperty("ticket_name")]
        public string TicketName { get; }

        /// <summary>
        /// Pricing options for an order. The options affect how the order's price is calculated.
        /// They can be used, for example, to apply automatic price adjustments that are based on preconfigured
        /// [pricing rules]($m/CatalogPricingRule).
        /// </summary>
        [JsonProperty("pricing_options", NullValueHandling = NullValueHandling.Ignore)]
        public Models.OrderPricingOptions PricingOptions { get; }

        /// <summary>
        /// A set-like list of Rewards that have been added to the Order.
        /// </summary>
        [JsonProperty("rewards", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.OrderReward> Rewards { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("net_amount_due_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money NetAmountDueMoney { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"Order : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeReferenceId()
        {
            return this.shouldSerialize["reference_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCustomerId()
        {
            return this.shouldSerialize["customer_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLineItems()
        {
            return this.shouldSerialize["line_items"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTaxes()
        {
            return this.shouldSerialize["taxes"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDiscounts()
        {
            return this.shouldSerialize["discounts"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeServiceCharges()
        {
            return this.shouldSerialize["service_charges"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeFulfillments()
        {
            return this.shouldSerialize["fulfillments"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMetadata()
        {
            return this.shouldSerialize["metadata"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTicketName()
        {
            return this.shouldSerialize["ticket_name"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is Order other &&
                (this.Id == null && other.Id == null ||
                 this.Id?.Equals(other.Id) == true) &&
                (this.LocationId == null && other.LocationId == null ||
                 this.LocationId?.Equals(other.LocationId) == true) &&
                (this.ReferenceId == null && other.ReferenceId == null ||
                 this.ReferenceId?.Equals(other.ReferenceId) == true) &&
                (this.Source == null && other.Source == null ||
                 this.Source?.Equals(other.Source) == true) &&
                (this.CustomerId == null && other.CustomerId == null ||
                 this.CustomerId?.Equals(other.CustomerId) == true) &&
                (this.LineItems == null && other.LineItems == null ||
                 this.LineItems?.Equals(other.LineItems) == true) &&
                (this.Taxes == null && other.Taxes == null ||
                 this.Taxes?.Equals(other.Taxes) == true) &&
                (this.Discounts == null && other.Discounts == null ||
                 this.Discounts?.Equals(other.Discounts) == true) &&
                (this.ServiceCharges == null && other.ServiceCharges == null ||
                 this.ServiceCharges?.Equals(other.ServiceCharges) == true) &&
                (this.Fulfillments == null && other.Fulfillments == null ||
                 this.Fulfillments?.Equals(other.Fulfillments) == true) &&
                (this.Returns == null && other.Returns == null ||
                 this.Returns?.Equals(other.Returns) == true) &&
                (this.ReturnAmounts == null && other.ReturnAmounts == null ||
                 this.ReturnAmounts?.Equals(other.ReturnAmounts) == true) &&
                (this.NetAmounts == null && other.NetAmounts == null ||
                 this.NetAmounts?.Equals(other.NetAmounts) == true) &&
                (this.RoundingAdjustment == null && other.RoundingAdjustment == null ||
                 this.RoundingAdjustment?.Equals(other.RoundingAdjustment) == true) &&
                (this.Tenders == null && other.Tenders == null ||
                 this.Tenders?.Equals(other.Tenders) == true) &&
                (this.Refunds == null && other.Refunds == null ||
                 this.Refunds?.Equals(other.Refunds) == true) &&
                (this.Metadata == null && other.Metadata == null ||
                 this.Metadata?.Equals(other.Metadata) == true) &&
                (this.CreatedAt == null && other.CreatedAt == null ||
                 this.CreatedAt?.Equals(other.CreatedAt) == true) &&
                (this.UpdatedAt == null && other.UpdatedAt == null ||
                 this.UpdatedAt?.Equals(other.UpdatedAt) == true) &&
                (this.ClosedAt == null && other.ClosedAt == null ||
                 this.ClosedAt?.Equals(other.ClosedAt) == true) &&
                (this.State == null && other.State == null ||
                 this.State?.Equals(other.State) == true) &&
                (this.Version == null && other.Version == null ||
                 this.Version?.Equals(other.Version) == true) &&
                (this.TotalMoney == null && other.TotalMoney == null ||
                 this.TotalMoney?.Equals(other.TotalMoney) == true) &&
                (this.TotalTaxMoney == null && other.TotalTaxMoney == null ||
                 this.TotalTaxMoney?.Equals(other.TotalTaxMoney) == true) &&
                (this.TotalDiscountMoney == null && other.TotalDiscountMoney == null ||
                 this.TotalDiscountMoney?.Equals(other.TotalDiscountMoney) == true) &&
                (this.TotalTipMoney == null && other.TotalTipMoney == null ||
                 this.TotalTipMoney?.Equals(other.TotalTipMoney) == true) &&
                (this.TotalServiceChargeMoney == null && other.TotalServiceChargeMoney == null ||
                 this.TotalServiceChargeMoney?.Equals(other.TotalServiceChargeMoney) == true) &&
                (this.TicketName == null && other.TicketName == null ||
                 this.TicketName?.Equals(other.TicketName) == true) &&
                (this.PricingOptions == null && other.PricingOptions == null ||
                 this.PricingOptions?.Equals(other.PricingOptions) == true) &&
                (this.Rewards == null && other.Rewards == null ||
                 this.Rewards?.Equals(other.Rewards) == true) &&
                (this.NetAmountDueMoney == null && other.NetAmountDueMoney == null ||
                 this.NetAmountDueMoney?.Equals(other.NetAmountDueMoney) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1044839112;
            hashCode = HashCode.Combine(hashCode, this.Id, this.LocationId, this.ReferenceId, this.Source, this.CustomerId, this.LineItems, this.Taxes);

            hashCode = HashCode.Combine(hashCode, this.Discounts, this.ServiceCharges, this.Fulfillments, this.Returns, this.ReturnAmounts, this.NetAmounts, this.RoundingAdjustment);

            hashCode = HashCode.Combine(hashCode, this.Tenders, this.Refunds, this.Metadata, this.CreatedAt, this.UpdatedAt, this.ClosedAt, this.State);

            hashCode = HashCode.Combine(hashCode, this.Version, this.TotalMoney, this.TotalTaxMoney, this.TotalDiscountMoney, this.TotalTipMoney, this.TotalServiceChargeMoney, this.TicketName);

            hashCode = HashCode.Combine(hashCode, this.PricingOptions, this.Rewards, this.NetAmountDueMoney);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {this.Id ?? "null"}");
            toStringOutput.Add($"this.LocationId = {this.LocationId ?? "null"}");
            toStringOutput.Add($"this.ReferenceId = {this.ReferenceId ?? "null"}");
            toStringOutput.Add($"this.Source = {(this.Source == null ? "null" : this.Source.ToString())}");
            toStringOutput.Add($"this.CustomerId = {this.CustomerId ?? "null"}");
            toStringOutput.Add($"this.LineItems = {(this.LineItems == null ? "null" : $"[{string.Join(", ", this.LineItems)} ]")}");
            toStringOutput.Add($"this.Taxes = {(this.Taxes == null ? "null" : $"[{string.Join(", ", this.Taxes)} ]")}");
            toStringOutput.Add($"this.Discounts = {(this.Discounts == null ? "null" : $"[{string.Join(", ", this.Discounts)} ]")}");
            toStringOutput.Add($"this.ServiceCharges = {(this.ServiceCharges == null ? "null" : $"[{string.Join(", ", this.ServiceCharges)} ]")}");
            toStringOutput.Add($"this.Fulfillments = {(this.Fulfillments == null ? "null" : $"[{string.Join(", ", this.Fulfillments)} ]")}");
            toStringOutput.Add($"this.Returns = {(this.Returns == null ? "null" : $"[{string.Join(", ", this.Returns)} ]")}");
            toStringOutput.Add($"this.ReturnAmounts = {(this.ReturnAmounts == null ? "null" : this.ReturnAmounts.ToString())}");
            toStringOutput.Add($"this.NetAmounts = {(this.NetAmounts == null ? "null" : this.NetAmounts.ToString())}");
            toStringOutput.Add($"this.RoundingAdjustment = {(this.RoundingAdjustment == null ? "null" : this.RoundingAdjustment.ToString())}");
            toStringOutput.Add($"this.Tenders = {(this.Tenders == null ? "null" : $"[{string.Join(", ", this.Tenders)} ]")}");
            toStringOutput.Add($"this.Refunds = {(this.Refunds == null ? "null" : $"[{string.Join(", ", this.Refunds)} ]")}");
            toStringOutput.Add($"Metadata = {(this.Metadata == null ? "null" : this.Metadata.ToString())}");
            toStringOutput.Add($"this.CreatedAt = {this.CreatedAt ?? "null"}");
            toStringOutput.Add($"this.UpdatedAt = {this.UpdatedAt ?? "null"}");
            toStringOutput.Add($"this.ClosedAt = {this.ClosedAt ?? "null"}");
            toStringOutput.Add($"this.State = {(this.State == null ? "null" : this.State.ToString())}");
            toStringOutput.Add($"this.Version = {(this.Version == null ? "null" : this.Version.ToString())}");
            toStringOutput.Add($"this.TotalMoney = {(this.TotalMoney == null ? "null" : this.TotalMoney.ToString())}");
            toStringOutput.Add($"this.TotalTaxMoney = {(this.TotalTaxMoney == null ? "null" : this.TotalTaxMoney.ToString())}");
            toStringOutput.Add($"this.TotalDiscountMoney = {(this.TotalDiscountMoney == null ? "null" : this.TotalDiscountMoney.ToString())}");
            toStringOutput.Add($"this.TotalTipMoney = {(this.TotalTipMoney == null ? "null" : this.TotalTipMoney.ToString())}");
            toStringOutput.Add($"this.TotalServiceChargeMoney = {(this.TotalServiceChargeMoney == null ? "null" : this.TotalServiceChargeMoney.ToString())}");
            toStringOutput.Add($"this.TicketName = {this.TicketName ?? "null"}");
            toStringOutput.Add($"this.PricingOptions = {(this.PricingOptions == null ? "null" : this.PricingOptions.ToString())}");
            toStringOutput.Add($"this.Rewards = {(this.Rewards == null ? "null" : $"[{string.Join(", ", this.Rewards)} ]")}");
            toStringOutput.Add($"this.NetAmountDueMoney = {(this.NetAmountDueMoney == null ? "null" : this.NetAmountDueMoney.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.LocationId)
                .Id(this.Id)
                .ReferenceId(this.ReferenceId)
                .Source(this.Source)
                .CustomerId(this.CustomerId)
                .LineItems(this.LineItems)
                .Taxes(this.Taxes)
                .Discounts(this.Discounts)
                .ServiceCharges(this.ServiceCharges)
                .Fulfillments(this.Fulfillments)
                .Returns(this.Returns)
                .ReturnAmounts(this.ReturnAmounts)
                .NetAmounts(this.NetAmounts)
                .RoundingAdjustment(this.RoundingAdjustment)
                .Tenders(this.Tenders)
                .Refunds(this.Refunds)
                .Metadata(this.Metadata)
                .CreatedAt(this.CreatedAt)
                .UpdatedAt(this.UpdatedAt)
                .ClosedAt(this.ClosedAt)
                .State(this.State)
                .Version(this.Version)
                .TotalMoney(this.TotalMoney)
                .TotalTaxMoney(this.TotalTaxMoney)
                .TotalDiscountMoney(this.TotalDiscountMoney)
                .TotalTipMoney(this.TotalTipMoney)
                .TotalServiceChargeMoney(this.TotalServiceChargeMoney)
                .TicketName(this.TicketName)
                .PricingOptions(this.PricingOptions)
                .Rewards(this.Rewards)
                .NetAmountDueMoney(this.NetAmountDueMoney);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "reference_id", false },
                { "customer_id", false },
                { "line_items", false },
                { "taxes", false },
                { "discounts", false },
                { "service_charges", false },
                { "fulfillments", false },
                { "metadata", false },
                { "ticket_name", false },
            };

            private string locationId;
            private string id;
            private string referenceId;
            private Models.OrderSource source;
            private string customerId;
            private IList<Models.OrderLineItem> lineItems;
            private IList<Models.OrderLineItemTax> taxes;
            private IList<Models.OrderLineItemDiscount> discounts;
            private IList<Models.OrderServiceCharge> serviceCharges;
            private IList<Models.Fulfillment> fulfillments;
            private IList<Models.OrderReturn> returns;
            private Models.OrderMoneyAmounts returnAmounts;
            private Models.OrderMoneyAmounts netAmounts;
            private Models.OrderRoundingAdjustment roundingAdjustment;
            private IList<Models.Tender> tenders;
            private IList<Models.Refund> refunds;
            private IDictionary<string, string> metadata;
            private string createdAt;
            private string updatedAt;
            private string closedAt;
            private string state;
            private int? version;
            private Models.Money totalMoney;
            private Models.Money totalTaxMoney;
            private Models.Money totalDiscountMoney;
            private Models.Money totalTipMoney;
            private Models.Money totalServiceChargeMoney;
            private string ticketName;
            private Models.OrderPricingOptions pricingOptions;
            private IList<Models.OrderReward> rewards;
            private Models.Money netAmountDueMoney;

            /// <summary>
            /// Initialize Builder for Order.
            /// </summary>
            /// <param name="locationId"> locationId. </param>
            public Builder(
                string locationId)
            {
                this.locationId = locationId;
            }

             /// <summary>
             /// LocationId.
             /// </summary>
             /// <param name="locationId"> locationId. </param>
             /// <returns> Builder. </returns>
            public Builder LocationId(string locationId)
            {
                this.locationId = locationId;
                return this;
            }

             /// <summary>
             /// Id.
             /// </summary>
             /// <param name="id"> id. </param>
             /// <returns> Builder. </returns>
            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

             /// <summary>
             /// ReferenceId.
             /// </summary>
             /// <param name="referenceId"> referenceId. </param>
             /// <returns> Builder. </returns>
            public Builder ReferenceId(string referenceId)
            {
                shouldSerialize["reference_id"] = true;
                this.referenceId = referenceId;
                return this;
            }

             /// <summary>
             /// Source.
             /// </summary>
             /// <param name="source"> source. </param>
             /// <returns> Builder. </returns>
            public Builder Source(Models.OrderSource source)
            {
                this.source = source;
                return this;
            }

             /// <summary>
             /// CustomerId.
             /// </summary>
             /// <param name="customerId"> customerId. </param>
             /// <returns> Builder. </returns>
            public Builder CustomerId(string customerId)
            {
                shouldSerialize["customer_id"] = true;
                this.customerId = customerId;
                return this;
            }

             /// <summary>
             /// LineItems.
             /// </summary>
             /// <param name="lineItems"> lineItems. </param>
             /// <returns> Builder. </returns>
            public Builder LineItems(IList<Models.OrderLineItem> lineItems)
            {
                shouldSerialize["line_items"] = true;
                this.lineItems = lineItems;
                return this;
            }

             /// <summary>
             /// Taxes.
             /// </summary>
             /// <param name="taxes"> taxes. </param>
             /// <returns> Builder. </returns>
            public Builder Taxes(IList<Models.OrderLineItemTax> taxes)
            {
                shouldSerialize["taxes"] = true;
                this.taxes = taxes;
                return this;
            }

             /// <summary>
             /// Discounts.
             /// </summary>
             /// <param name="discounts"> discounts. </param>
             /// <returns> Builder. </returns>
            public Builder Discounts(IList<Models.OrderLineItemDiscount> discounts)
            {
                shouldSerialize["discounts"] = true;
                this.discounts = discounts;
                return this;
            }

             /// <summary>
             /// ServiceCharges.
             /// </summary>
             /// <param name="serviceCharges"> serviceCharges. </param>
             /// <returns> Builder. </returns>
            public Builder ServiceCharges(IList<Models.OrderServiceCharge> serviceCharges)
            {
                shouldSerialize["service_charges"] = true;
                this.serviceCharges = serviceCharges;
                return this;
            }

             /// <summary>
             /// Fulfillments.
             /// </summary>
             /// <param name="fulfillments"> fulfillments. </param>
             /// <returns> Builder. </returns>
            public Builder Fulfillments(IList<Models.Fulfillment> fulfillments)
            {
                shouldSerialize["fulfillments"] = true;
                this.fulfillments = fulfillments;
                return this;
            }

             /// <summary>
             /// Returns.
             /// </summary>
             /// <param name="returns"> returns. </param>
             /// <returns> Builder. </returns>
            public Builder Returns(IList<Models.OrderReturn> returns)
            {
                this.returns = returns;
                return this;
            }

             /// <summary>
             /// ReturnAmounts.
             /// </summary>
             /// <param name="returnAmounts"> returnAmounts. </param>
             /// <returns> Builder. </returns>
            public Builder ReturnAmounts(Models.OrderMoneyAmounts returnAmounts)
            {
                this.returnAmounts = returnAmounts;
                return this;
            }

             /// <summary>
             /// NetAmounts.
             /// </summary>
             /// <param name="netAmounts"> netAmounts. </param>
             /// <returns> Builder. </returns>
            public Builder NetAmounts(Models.OrderMoneyAmounts netAmounts)
            {
                this.netAmounts = netAmounts;
                return this;
            }

             /// <summary>
             /// RoundingAdjustment.
             /// </summary>
             /// <param name="roundingAdjustment"> roundingAdjustment. </param>
             /// <returns> Builder. </returns>
            public Builder RoundingAdjustment(Models.OrderRoundingAdjustment roundingAdjustment)
            {
                this.roundingAdjustment = roundingAdjustment;
                return this;
            }

             /// <summary>
             /// Tenders.
             /// </summary>
             /// <param name="tenders"> tenders. </param>
             /// <returns> Builder. </returns>
            public Builder Tenders(IList<Models.Tender> tenders)
            {
                this.tenders = tenders;
                return this;
            }

             /// <summary>
             /// Refunds.
             /// </summary>
             /// <param name="refunds"> refunds. </param>
             /// <returns> Builder. </returns>
            public Builder Refunds(IList<Models.Refund> refunds)
            {
                this.refunds = refunds;
                return this;
            }

             /// <summary>
             /// Metadata.
             /// </summary>
             /// <param name="metadata"> metadata. </param>
             /// <returns> Builder. </returns>
            public Builder Metadata(IDictionary<string, string> metadata)
            {
                shouldSerialize["metadata"] = true;
                this.metadata = metadata;
                return this;
            }

             /// <summary>
             /// CreatedAt.
             /// </summary>
             /// <param name="createdAt"> createdAt. </param>
             /// <returns> Builder. </returns>
            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

             /// <summary>
             /// UpdatedAt.
             /// </summary>
             /// <param name="updatedAt"> updatedAt. </param>
             /// <returns> Builder. </returns>
            public Builder UpdatedAt(string updatedAt)
            {
                this.updatedAt = updatedAt;
                return this;
            }

             /// <summary>
             /// ClosedAt.
             /// </summary>
             /// <param name="closedAt"> closedAt. </param>
             /// <returns> Builder. </returns>
            public Builder ClosedAt(string closedAt)
            {
                this.closedAt = closedAt;
                return this;
            }

             /// <summary>
             /// State.
             /// </summary>
             /// <param name="state"> state. </param>
             /// <returns> Builder. </returns>
            public Builder State(string state)
            {
                this.state = state;
                return this;
            }

             /// <summary>
             /// Version.
             /// </summary>
             /// <param name="version"> version. </param>
             /// <returns> Builder. </returns>
            public Builder Version(int? version)
            {
                this.version = version;
                return this;
            }

             /// <summary>
             /// TotalMoney.
             /// </summary>
             /// <param name="totalMoney"> totalMoney. </param>
             /// <returns> Builder. </returns>
            public Builder TotalMoney(Models.Money totalMoney)
            {
                this.totalMoney = totalMoney;
                return this;
            }

             /// <summary>
             /// TotalTaxMoney.
             /// </summary>
             /// <param name="totalTaxMoney"> totalTaxMoney. </param>
             /// <returns> Builder. </returns>
            public Builder TotalTaxMoney(Models.Money totalTaxMoney)
            {
                this.totalTaxMoney = totalTaxMoney;
                return this;
            }

             /// <summary>
             /// TotalDiscountMoney.
             /// </summary>
             /// <param name="totalDiscountMoney"> totalDiscountMoney. </param>
             /// <returns> Builder. </returns>
            public Builder TotalDiscountMoney(Models.Money totalDiscountMoney)
            {
                this.totalDiscountMoney = totalDiscountMoney;
                return this;
            }

             /// <summary>
             /// TotalTipMoney.
             /// </summary>
             /// <param name="totalTipMoney"> totalTipMoney. </param>
             /// <returns> Builder. </returns>
            public Builder TotalTipMoney(Models.Money totalTipMoney)
            {
                this.totalTipMoney = totalTipMoney;
                return this;
            }

             /// <summary>
             /// TotalServiceChargeMoney.
             /// </summary>
             /// <param name="totalServiceChargeMoney"> totalServiceChargeMoney. </param>
             /// <returns> Builder. </returns>
            public Builder TotalServiceChargeMoney(Models.Money totalServiceChargeMoney)
            {
                this.totalServiceChargeMoney = totalServiceChargeMoney;
                return this;
            }

             /// <summary>
             /// TicketName.
             /// </summary>
             /// <param name="ticketName"> ticketName. </param>
             /// <returns> Builder. </returns>
            public Builder TicketName(string ticketName)
            {
                shouldSerialize["ticket_name"] = true;
                this.ticketName = ticketName;
                return this;
            }

             /// <summary>
             /// PricingOptions.
             /// </summary>
             /// <param name="pricingOptions"> pricingOptions. </param>
             /// <returns> Builder. </returns>
            public Builder PricingOptions(Models.OrderPricingOptions pricingOptions)
            {
                this.pricingOptions = pricingOptions;
                return this;
            }

             /// <summary>
             /// Rewards.
             /// </summary>
             /// <param name="rewards"> rewards. </param>
             /// <returns> Builder. </returns>
            public Builder Rewards(IList<Models.OrderReward> rewards)
            {
                this.rewards = rewards;
                return this;
            }

             /// <summary>
             /// NetAmountDueMoney.
             /// </summary>
             /// <param name="netAmountDueMoney"> netAmountDueMoney. </param>
             /// <returns> Builder. </returns>
            public Builder NetAmountDueMoney(Models.Money netAmountDueMoney)
            {
                this.netAmountDueMoney = netAmountDueMoney;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetReferenceId()
            {
                this.shouldSerialize["reference_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetCustomerId()
            {
                this.shouldSerialize["customer_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetLineItems()
            {
                this.shouldSerialize["line_items"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetTaxes()
            {
                this.shouldSerialize["taxes"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetDiscounts()
            {
                this.shouldSerialize["discounts"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetServiceCharges()
            {
                this.shouldSerialize["service_charges"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetFulfillments()
            {
                this.shouldSerialize["fulfillments"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetMetadata()
            {
                this.shouldSerialize["metadata"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetTicketName()
            {
                this.shouldSerialize["ticket_name"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> Order. </returns>
            public Order Build()
            {
                return new Order(
                    shouldSerialize,
                    this.locationId,
                    this.id,
                    this.referenceId,
                    this.source,
                    this.customerId,
                    this.lineItems,
                    this.taxes,
                    this.discounts,
                    this.serviceCharges,
                    this.fulfillments,
                    this.returns,
                    this.returnAmounts,
                    this.netAmounts,
                    this.roundingAdjustment,
                    this.tenders,
                    this.refunds,
                    this.metadata,
                    this.createdAt,
                    this.updatedAt,
                    this.closedAt,
                    this.state,
                    this.version,
                    this.totalMoney,
                    this.totalTaxMoney,
                    this.totalDiscountMoney,
                    this.totalTipMoney,
                    this.totalServiceChargeMoney,
                    this.ticketName,
                    this.pricingOptions,
                    this.rewards,
                    this.netAmountDueMoney);
            }
        }
    }
}