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
    public class CreateSubscriptionRequest 
    {
        public CreateSubscriptionRequest(string idempotencyKey,
            string locationId,
            string planId,
            string customerId,
            string startDate = null,
            string canceledDate = null,
            string taxPercentage = null,
            Models.Money priceOverrideMoney = null,
            string cardId = null,
            string timezone = null)
        {
            IdempotencyKey = idempotencyKey;
            LocationId = locationId;
            PlanId = planId;
            CustomerId = customerId;
            StartDate = startDate;
            CanceledDate = canceledDate;
            TaxPercentage = taxPercentage;
            PriceOverrideMoney = priceOverrideMoney;
            CardId = cardId;
            Timezone = timezone;
        }

        /// <summary>
        /// A unique string that identifies this `CreateSubscription` request.
        /// If you do not provide a unique string (or provide an empty string as the value),
        /// the endpoint treats each request as independent.
        /// For more information, see [Idempotency keys](https://developer.squareup.com/docs/docs/working-with-apis/idempotency).
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <summary>
        /// The ID of the location the subscription is associated with.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <summary>
        /// The ID of the subscription plan. For more information, see 
        /// [Subscription Plan Overview](https://developer.squareup.com/docs/docs/subscriptions/overview).
        /// </summary>
        [JsonProperty("plan_id")]
        public string PlanId { get; }

        /// <summary>
        /// The ID of the [customer](#type-customer) profile.
        /// </summary>
        [JsonProperty("customer_id")]
        public string CustomerId { get; }

        /// <summary>
        /// The start date of the subscription, in YYYY-MM-DD format. For example,
        /// 2013-01-15. If the start date is left empty, the subscription begins 
        /// immediately.
        /// </summary>
        [JsonProperty("start_date")]
        public string StartDate { get; }

        /// <summary>
        /// The date when the subscription should be canceled, in 
        /// YYYY-MM-DD format (for example, 2025-02-29). This overrides the plan configuration 
        /// if it comes before the date the subscription would otherwise end.
        /// </summary>
        [JsonProperty("canceled_date")]
        public string CanceledDate { get; }

        /// <summary>
        /// The tax to add when billing the subscription.
        /// The percentage is expressed in decimal form, using a `'.'` as the decimal
        /// separator and without a `'%'` sign. For example, a value of 7.5
        /// corresponds to 7.5%.
        /// </summary>
        [JsonProperty("tax_percentage")]
        public string TaxPercentage { get; }

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
        /// The ID of the [customer](#type-customer) [card](#type-card) to charge.
        /// If not specified, Square sends an invoice via email. For an example to
        /// create a customer and add a card on file, see [Subscriptions Walkthrough](https://developer.squareup.com/docs/docs/subscriptions-api/walkthrough).
        /// </summary>
        [JsonProperty("card_id")]
        public string CardId { get; }

        /// <summary>
        /// The timezone that is used in date calculations for the subscription. If unset, defaults to
        /// the location timezone. If a timezone is not configured for the location, defaults to "America/New_York".
        /// Format: the IANA Timezone Database identifier for the location timezone. For
        /// a list of time zones, see [List of tz database time zones](https://en.wikipedia.org/wiki/List_of_tz_database_time_zones).
        /// </summary>
        [JsonProperty("timezone")]
        public string Timezone { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(IdempotencyKey,
                LocationId,
                PlanId,
                CustomerId)
                .StartDate(StartDate)
                .CanceledDate(CanceledDate)
                .TaxPercentage(TaxPercentage)
                .PriceOverrideMoney(PriceOverrideMoney)
                .CardId(CardId)
                .Timezone(Timezone);
            return builder;
        }

        public class Builder
        {
            private string idempotencyKey;
            private string locationId;
            private string planId;
            private string customerId;
            private string startDate;
            private string canceledDate;
            private string taxPercentage;
            private Models.Money priceOverrideMoney;
            private string cardId;
            private string timezone;

            public Builder(string idempotencyKey,
                string locationId,
                string planId,
                string customerId)
            {
                this.idempotencyKey = idempotencyKey;
                this.locationId = locationId;
                this.planId = planId;
                this.customerId = customerId;
            }
            public Builder IdempotencyKey(string value)
            {
                idempotencyKey = value;
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

            public Builder TaxPercentage(string value)
            {
                taxPercentage = value;
                return this;
            }

            public Builder PriceOverrideMoney(Models.Money value)
            {
                priceOverrideMoney = value;
                return this;
            }

            public Builder CardId(string value)
            {
                cardId = value;
                return this;
            }

            public Builder Timezone(string value)
            {
                timezone = value;
                return this;
            }

            public CreateSubscriptionRequest Build()
            {
                return new CreateSubscriptionRequest(idempotencyKey,
                    locationId,
                    planId,
                    customerId,
                    startDate,
                    canceledDate,
                    taxPercentage,
                    priceOverrideMoney,
                    cardId,
                    timezone);
            }
        }
    }
}