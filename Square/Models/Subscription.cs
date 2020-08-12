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
    public class Subscription 
    {
        public Subscription(string id = null,
            string locationId = null,
            string planId = null,
            string customerId = null,
            string startDate = null,
            string canceledDate = null,
            string status = null,
            string taxPercentage = null,
            IList<string> invoiceIds = null,
            Models.Money priceOverrideMoney = null,
            long? version = null,
            string createdAt = null,
            string cardId = null,
            string paidUntilDate = null,
            string timezone = null)
        {
            Id = id;
            LocationId = locationId;
            PlanId = planId;
            CustomerId = customerId;
            StartDate = startDate;
            CanceledDate = canceledDate;
            Status = status;
            TaxPercentage = taxPercentage;
            InvoiceIds = invoiceIds;
            PriceOverrideMoney = priceOverrideMoney;
            Version = version;
            CreatedAt = createdAt;
            CardId = cardId;
            PaidUntilDate = paidUntilDate;
            Timezone = timezone;
        }

        /// <summary>
        /// The Square-assigned ID of the subscription.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// The ID of the location associated with the subscription.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <summary>
        /// The ID of the associated [subscription plan](#type-catalogsubscriptionplan).
        /// </summary>
        [JsonProperty("plan_id")]
        public string PlanId { get; }

        /// <summary>
        /// The ID of the associated [customer](#type-customer) profile.
        /// </summary>
        [JsonProperty("customer_id")]
        public string CustomerId { get; }

        /// <summary>
        /// The start date of the subscription, in YYYY-MM-DD format (for example,
        /// 2013-01-15).
        /// </summary>
        [JsonProperty("start_date")]
        public string StartDate { get; }

        /// <summary>
        /// The subscription cancellation date, in YYYY-MM-DD format (for
        /// example, 2013-01-15). On this date, the subscription status changes 
        /// to `CANCELED` and the subscription billing stops. 
        /// If you don't set this field, the subscription plan dictates if and 
        /// when subscription ends. 
        /// You cannot update this field, you can only clear it.
        /// </summary>
        [JsonProperty("canceled_date")]
        public string CanceledDate { get; }

        /// <summary>
        /// Possible subscription status values.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; }

        /// <summary>
        /// The tax amount applied when billing the subscription. The
        /// percentage is expressed in decimal form, using a `'.'` as the decimal
        /// separator and without a `'%'` sign. For example, a value of `7.5`
        /// corresponds to 7.5%.
        /// </summary>
        [JsonProperty("tax_percentage")]
        public string TaxPercentage { get; }

        /// <summary>
        /// The IDs of the [invoices](#type-invoice) created for the 
        /// subscription, listed in order when the invoices were created 
        /// (oldest invoices appear first).
        /// </summary>
        [JsonProperty("invoice_ids")]
        public IList<string> InvoiceIds { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("price_override_money")]
        public Models.Money PriceOverrideMoney { get; }

        /// <summary>
        /// The version of the object. When updating an object, the version
        /// supplied must match the version in the database, otherwise the write will
        /// be rejected as conflicting.
        /// </summary>
        [JsonProperty("version")]
        public long? Version { get; }

        /// <summary>
        /// The timestamp when the subscription was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; }

        /// <summary>
        /// The ID of the [customer](#type-customer) [card](#type-card)
        /// that is charged for the subscription.
        /// </summary>
        [JsonProperty("card_id")]
        public string CardId { get; }

        /// <summary>
        /// The date up to which the customer is invoiced for the
        /// subscription, in YYYY-MM-DD format (for example, 2013-01-15).
        /// After the invoice is paid for a given billing period,
        /// this date will be the last day of the billing period.
        /// For example,
        /// suppose for the month of May a customer gets an invoice
        /// (or charged the card) on May 1. For the monthly billing scenario,
        /// this date is then set to May 31.
        /// </summary>
        [JsonProperty("paid_until_date")]
        public string PaidUntilDate { get; }

        /// <summary>
        /// Timezone that will be used in date calculations for the subscription.
        /// Defaults to the timezone of the location based on `location_id`.
        /// Format: the IANA Timezone Database identifier for the location timezone (for example, `America/Los_Angeles`).
        /// </summary>
        [JsonProperty("timezone")]
        public string Timezone { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(Id)
                .LocationId(LocationId)
                .PlanId(PlanId)
                .CustomerId(CustomerId)
                .StartDate(StartDate)
                .CanceledDate(CanceledDate)
                .Status(Status)
                .TaxPercentage(TaxPercentage)
                .InvoiceIds(InvoiceIds)
                .PriceOverrideMoney(PriceOverrideMoney)
                .Version(Version)
                .CreatedAt(CreatedAt)
                .CardId(CardId)
                .PaidUntilDate(PaidUntilDate)
                .Timezone(Timezone);
            return builder;
        }

        public class Builder
        {
            private string id;
            private string locationId;
            private string planId;
            private string customerId;
            private string startDate;
            private string canceledDate;
            private string status;
            private string taxPercentage;
            private IList<string> invoiceIds = new List<string>();
            private Models.Money priceOverrideMoney;
            private long? version;
            private string createdAt;
            private string cardId;
            private string paidUntilDate;
            private string timezone;

            public Builder() { }
            public Builder Id(string value)
            {
                id = value;
                return this;
            }

            public Builder LocationId(string value)
            {
                locationId = value;
                return this;
            }

            public Builder PlanId(string value)
            {
                planId = value;
                return this;
            }

            public Builder CustomerId(string value)
            {
                customerId = value;
                return this;
            }

            public Builder StartDate(string value)
            {
                startDate = value;
                return this;
            }

            public Builder CanceledDate(string value)
            {
                canceledDate = value;
                return this;
            }

            public Builder Status(string value)
            {
                status = value;
                return this;
            }

            public Builder TaxPercentage(string value)
            {
                taxPercentage = value;
                return this;
            }

            public Builder InvoiceIds(IList<string> value)
            {
                invoiceIds = value;
                return this;
            }

            public Builder PriceOverrideMoney(Models.Money value)
            {
                priceOverrideMoney = value;
                return this;
            }

            public Builder Version(long? value)
            {
                version = value;
                return this;
            }

            public Builder CreatedAt(string value)
            {
                createdAt = value;
                return this;
            }

            public Builder CardId(string value)
            {
                cardId = value;
                return this;
            }

            public Builder PaidUntilDate(string value)
            {
                paidUntilDate = value;
                return this;
            }

            public Builder Timezone(string value)
            {
                timezone = value;
                return this;
            }

            public Subscription Build()
            {
                return new Subscription(id,
                    locationId,
                    planId,
                    customerId,
                    startDate,
                    canceledDate,
                    status,
                    taxPercentage,
                    invoiceIds,
                    priceOverrideMoney,
                    version,
                    createdAt,
                    cardId,
                    paidUntilDate,
                    timezone);
            }
        }
    }
}