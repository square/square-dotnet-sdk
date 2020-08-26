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
    public class Order 
    {
        public Order(string locationId,
            string id = null,
            string referenceId = null,
            Models.OrderSource source = null,
            string customerId = null,
            IList<Models.OrderLineItem> lineItems = null,
            IList<Models.OrderLineItemTax> taxes = null,
            IList<Models.OrderLineItemDiscount> discounts = null,
            IList<Models.OrderServiceCharge> serviceCharges = null,
            IList<Models.OrderFulfillment> fulfillments = null,
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
            Models.OrderPricingOptions pricingOptions = null,
            IList<Models.OrderReward> rewards = null)
        {
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
            PricingOptions = pricingOptions;
            Rewards = rewards;
        }

        /// <summary>
        /// The order's unique ID.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// The ID of the merchant location this order is associated with.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <summary>
        /// A client specified identifier to associate an entity in another system
        /// with this order.
        /// </summary>
        [JsonProperty("reference_id")]
        public string ReferenceId { get; }

        /// <summary>
        /// Represents the origination details of an order.
        /// </summary>
        [JsonProperty("source")]
        public Models.OrderSource Source { get; }

        /// <summary>
        /// The [Customer](#type-customer) ID of the customer associated with the order.
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
        /// with `ORDER` scope, the server will generate an `OrderLineItemAppliedTax` for every line item.
        /// On reads, each tax in the list will include the total amount of that tax applied to the order.
        /// __IMPORTANT__: If `LINE_ITEM` scope is set on any taxes in this field, usage of the deprecated
        /// `line_items.taxes` field will result in an error. Please use `line_items.applied_taxes`
        /// instead.
        /// </summary>
        [JsonProperty("taxes")]
        public IList<Models.OrderLineItemTax> Taxes { get; }

        /// <summary>
        /// The list of all discounts associated with the order.
        /// Discounts can be scoped to either `ORDER` or `LINE_ITEM`. For discounts scoped to `LINE_ITEM`,
        /// an `OrderLineItemAppliedDiscount` must be added to each line item that the discount applies to.
        /// For discounts with `ORDER` scope, the server will generate an `OrderLineItemAppliedDiscount`
        /// for every line item.
        /// __IMPORTANT__: If `LINE_ITEM` scope is set on any discounts in this field, usage of the deprecated
        /// `line_items.discounts` field will result in an error. Please use `line_items.applied_discounts`
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
        /// Details on order fulfillment.
        /// Orders can only be created with at most one fulfillment. However, orders returned
        /// by the API may contain multiple fulfillments.
        /// </summary>
        [JsonProperty("fulfillments")]
        public IList<Models.OrderFulfillment> Fulfillments { get; }

        /// <summary>
        /// Collection of items from sale Orders being returned in this one. Normally part of an
        /// Itemized Return or Exchange.  There will be exactly one `Return` object per sale Order being
        /// referenced.
        /// </summary>
        [JsonProperty("returns")]
        public IList<Models.OrderReturn> Returns { get; }

        /// <summary>
        /// A collection of various money amounts.
        /// </summary>
        [JsonProperty("return_amounts")]
        public Models.OrderMoneyAmounts ReturnAmounts { get; }

        /// <summary>
        /// A collection of various money amounts.
        /// </summary>
        [JsonProperty("net_amounts")]
        public Models.OrderMoneyAmounts NetAmounts { get; }

        /// <summary>
        /// A rounding adjustment of the money being returned. Commonly used to apply Cash Rounding
        /// when the minimum unit of account is smaller than the lowest physical denomination of currency.
        /// </summary>
        [JsonProperty("rounding_adjustment")]
        public Models.OrderRoundingAdjustment RoundingAdjustment { get; }

        /// <summary>
        /// The Tenders which were used to pay for the Order.
        /// </summary>
        [JsonProperty("tenders")]
        public IList<Models.Tender> Tenders { get; }

        /// <summary>
        /// The Refunds that are part of this Order.
        /// </summary>
        [JsonProperty("refunds")]
        public IList<Models.Refund> Refunds { get; }

        /// <summary>
        /// Application-defined data attached to this order. Metadata fields are intended
        /// to store descriptive references or associations with an entity in another system or store brief
        /// information about the object. Square does not process this field; it only stores and returns it
        /// in relevant API calls. Do not use metadata to store any sensitive information (personally
        /// identifiable information, card details, etc.).
        /// Keys written by applications must be 60 characters or less and must be in the character set
        /// `[a-zA-Z0-9_-]`. Entries may also include metadata generated by Square. These keys are prefixed
        /// with a namespace, separated from the key with a ':' character.
        /// Values have a max length of 255 characters.
        /// An application may have up to 10 entries per metadata field.
        /// Entries written by applications are private and can only be read or modified by the same
        /// application.
        /// See [Metadata](https://developer.squareup.com/docs/build-basics/metadata) for more information.
        /// </summary>
        [JsonProperty("metadata")]
        public IDictionary<string, string> Metadata { get; }

        /// <summary>
        /// Timestamp for when the order was created. In RFC 3339 format, e.g., "2016-09-04T23:59:33.123Z".
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; }

        /// <summary>
        /// Timestamp for when the order was last updated. In RFC 3339 format, e.g., "2016-09-04T23:59:33.123Z".
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; }

        /// <summary>
        /// Timestamp for when the order reached a terminal [state](#property-state). In RFC 3339 format, e.g., "2016-09-04T23:59:33.123Z".
        /// </summary>
        [JsonProperty("closed_at")]
        public string ClosedAt { get; }

        /// <summary>
        /// The state of the order.
        /// </summary>
        [JsonProperty("state")]
        public string State { get; }

        /// <summary>
        /// Version number which is incremented each time an update is committed to the order.
        /// Orders that were not created through the API will not include a version and
        /// thus cannot be updated.
        /// [Read more about working with versions](https://developer.squareup.com/docs/orders-api/manage-orders#update-orders).
        /// </summary>
        [JsonProperty("version")]
        public int? Version { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("total_money")]
        public Models.Money TotalMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("total_tax_money")]
        public Models.Money TotalTaxMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("total_discount_money")]
        public Models.Money TotalDiscountMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("total_tip_money")]
        public Models.Money TotalTipMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("total_service_charge_money")]
        public Models.Money TotalServiceChargeMoney { get; }

        /// <summary>
        /// Pricing options for an order. The options affect how the order's price is calculated.
        /// They can be used, for example, to apply automatic price adjustments that are based on pre-configured
        /// [pricing rules](https://developer.squareup.com/docs/reference/square/objects/CatalogPricingRule).
        /// </summary>
        [JsonProperty("pricing_options")]
        public Models.OrderPricingOptions PricingOptions { get; }

        /// <summary>
        /// A set-like list of rewards that have been added to the order.
        /// </summary>
        [JsonProperty("rewards")]
        public IList<Models.OrderReward> Rewards { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(LocationId)
                .Id(Id)
                .ReferenceId(ReferenceId)
                .Source(Source)
                .CustomerId(CustomerId)
                .LineItems(LineItems)
                .Taxes(Taxes)
                .Discounts(Discounts)
                .ServiceCharges(ServiceCharges)
                .Fulfillments(Fulfillments)
                .Returns(Returns)
                .ReturnAmounts(ReturnAmounts)
                .NetAmounts(NetAmounts)
                .RoundingAdjustment(RoundingAdjustment)
                .Tenders(Tenders)
                .Refunds(Refunds)
                .Metadata(Metadata)
                .CreatedAt(CreatedAt)
                .UpdatedAt(UpdatedAt)
                .ClosedAt(ClosedAt)
                .State(State)
                .Version(Version)
                .TotalMoney(TotalMoney)
                .TotalTaxMoney(TotalTaxMoney)
                .TotalDiscountMoney(TotalDiscountMoney)
                .TotalTipMoney(TotalTipMoney)
                .TotalServiceChargeMoney(TotalServiceChargeMoney)
                .PricingOptions(PricingOptions)
                .Rewards(Rewards);
            return builder;
        }

        public class Builder
        {
            private string locationId;
            private string id;
            private string referenceId;
            private Models.OrderSource source;
            private string customerId;
            private IList<Models.OrderLineItem> lineItems = new List<Models.OrderLineItem>();
            private IList<Models.OrderLineItemTax> taxes = new List<Models.OrderLineItemTax>();
            private IList<Models.OrderLineItemDiscount> discounts = new List<Models.OrderLineItemDiscount>();
            private IList<Models.OrderServiceCharge> serviceCharges = new List<Models.OrderServiceCharge>();
            private IList<Models.OrderFulfillment> fulfillments = new List<Models.OrderFulfillment>();
            private IList<Models.OrderReturn> returns = new List<Models.OrderReturn>();
            private Models.OrderMoneyAmounts returnAmounts;
            private Models.OrderMoneyAmounts netAmounts;
            private Models.OrderRoundingAdjustment roundingAdjustment;
            private IList<Models.Tender> tenders = new List<Models.Tender>();
            private IList<Models.Refund> refunds = new List<Models.Refund>();
            private IDictionary<string, string> metadata = new Dictionary<string, string>();
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
            private Models.OrderPricingOptions pricingOptions;
            private IList<Models.OrderReward> rewards = new List<Models.OrderReward>();

            public Builder(string locationId)
            {
                this.locationId = locationId;
            }
            public Builder LocationId(string value)
            {
                locationId = value;
                return this;
            }

            public Builder Id(string value)
            {
                id = value;
                return this;
            }

            public Builder ReferenceId(string value)
            {
                referenceId = value;
                return this;
            }

            public Builder Source(Models.OrderSource value)
            {
                source = value;
                return this;
            }

            public Builder CustomerId(string value)
            {
                customerId = value;
                return this;
            }

            public Builder LineItems(IList<Models.OrderLineItem> value)
            {
                lineItems = value;
                return this;
            }

            public Builder Taxes(IList<Models.OrderLineItemTax> value)
            {
                taxes = value;
                return this;
            }

            public Builder Discounts(IList<Models.OrderLineItemDiscount> value)
            {
                discounts = value;
                return this;
            }

            public Builder ServiceCharges(IList<Models.OrderServiceCharge> value)
            {
                serviceCharges = value;
                return this;
            }

            public Builder Fulfillments(IList<Models.OrderFulfillment> value)
            {
                fulfillments = value;
                return this;
            }

            public Builder Returns(IList<Models.OrderReturn> value)
            {
                returns = value;
                return this;
            }

            public Builder ReturnAmounts(Models.OrderMoneyAmounts value)
            {
                returnAmounts = value;
                return this;
            }

            public Builder NetAmounts(Models.OrderMoneyAmounts value)
            {
                netAmounts = value;
                return this;
            }

            public Builder RoundingAdjustment(Models.OrderRoundingAdjustment value)
            {
                roundingAdjustment = value;
                return this;
            }

            public Builder Tenders(IList<Models.Tender> value)
            {
                tenders = value;
                return this;
            }

            public Builder Refunds(IList<Models.Refund> value)
            {
                refunds = value;
                return this;
            }

            public Builder Metadata(IDictionary<string, string> value)
            {
                metadata = value;
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

            public Builder ClosedAt(string value)
            {
                closedAt = value;
                return this;
            }

            public Builder State(string value)
            {
                state = value;
                return this;
            }

            public Builder Version(int? value)
            {
                version = value;
                return this;
            }

            public Builder TotalMoney(Models.Money value)
            {
                totalMoney = value;
                return this;
            }

            public Builder TotalTaxMoney(Models.Money value)
            {
                totalTaxMoney = value;
                return this;
            }

            public Builder TotalDiscountMoney(Models.Money value)
            {
                totalDiscountMoney = value;
                return this;
            }

            public Builder TotalTipMoney(Models.Money value)
            {
                totalTipMoney = value;
                return this;
            }

            public Builder TotalServiceChargeMoney(Models.Money value)
            {
                totalServiceChargeMoney = value;
                return this;
            }

            public Builder PricingOptions(Models.OrderPricingOptions value)
            {
                pricingOptions = value;
                return this;
            }

            public Builder Rewards(IList<Models.OrderReward> value)
            {
                rewards = value;
                return this;
            }

            public Order Build()
            {
                return new Order(locationId,
                    id,
                    referenceId,
                    source,
                    customerId,
                    lineItems,
                    taxes,
                    discounts,
                    serviceCharges,
                    fulfillments,
                    returns,
                    returnAmounts,
                    netAmounts,
                    roundingAdjustment,
                    tenders,
                    refunds,
                    metadata,
                    createdAt,
                    updatedAt,
                    closedAt,
                    state,
                    version,
                    totalMoney,
                    totalTaxMoney,
                    totalDiscountMoney,
                    totalTipMoney,
                    totalServiceChargeMoney,
                    pricingOptions,
                    rewards);
            }
        }
    }
}