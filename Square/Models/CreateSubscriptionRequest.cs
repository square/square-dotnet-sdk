
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
        /// For more information, see [Idempotency keys](https://developer.squareup.com/docs/working-with-apis/idempotency).
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
        /// [Subscription Plan Overview](https://developer.squareup.com/docs/subscriptions/overview).
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
        [JsonProperty("start_date", NullValueHandling = NullValueHandling.Ignore)]
        public string StartDate { get; }

        /// <summary>
        /// The date when the subscription should be canceled, in 
        /// YYYY-MM-DD format (for example, 2025-02-29). This overrides the plan configuration 
        /// if it comes before the date the subscription would otherwise end.
        /// </summary>
        [JsonProperty("canceled_date", NullValueHandling = NullValueHandling.Ignore)]
        public string CanceledDate { get; }

        /// <summary>
        /// The tax to add when billing the subscription.
        /// The percentage is expressed in decimal form, using a `'.'` as the decimal
        /// separator and without a `'%'` sign. For example, a value of 7.5
        /// corresponds to 7.5%.
        /// </summary>
        [JsonProperty("tax_percentage", NullValueHandling = NullValueHandling.Ignore)]
        public string TaxPercentage { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("price_override_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money PriceOverrideMoney { get; }

        /// <summary>
        /// The ID of the [customer](#type-customer) [card](#type-card) to charge.
        /// If not specified, Square sends an invoice via email. For an example to
        /// create a customer and add a card on file, see [Subscriptions Walkthrough](https://developer.squareup.com/docs/subscriptions-api/walkthrough).
        /// </summary>
        [JsonProperty("card_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CardId { get; }

        /// <summary>
        /// The timezone that is used in date calculations for the subscription. If unset, defaults to
        /// the location timezone. If a timezone is not configured for the location, defaults to "America/New_York".
        /// Format: the IANA Timezone Database identifier for the location timezone. For
        /// a list of time zones, see [List of tz database time zones](https://en.wikipedia.org/wiki/List_of_tz_database_time_zones).
        /// </summary>
        [JsonProperty("timezone", NullValueHandling = NullValueHandling.Ignore)]
        public string Timezone { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateSubscriptionRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"IdempotencyKey = {(IdempotencyKey == null ? "null" : IdempotencyKey == string.Empty ? "" : IdempotencyKey)}");
            toStringOutput.Add($"LocationId = {(LocationId == null ? "null" : LocationId == string.Empty ? "" : LocationId)}");
            toStringOutput.Add($"PlanId = {(PlanId == null ? "null" : PlanId == string.Empty ? "" : PlanId)}");
            toStringOutput.Add($"CustomerId = {(CustomerId == null ? "null" : CustomerId == string.Empty ? "" : CustomerId)}");
            toStringOutput.Add($"StartDate = {(StartDate == null ? "null" : StartDate == string.Empty ? "" : StartDate)}");
            toStringOutput.Add($"CanceledDate = {(CanceledDate == null ? "null" : CanceledDate == string.Empty ? "" : CanceledDate)}");
            toStringOutput.Add($"TaxPercentage = {(TaxPercentage == null ? "null" : TaxPercentage == string.Empty ? "" : TaxPercentage)}");
            toStringOutput.Add($"PriceOverrideMoney = {(PriceOverrideMoney == null ? "null" : PriceOverrideMoney.ToString())}");
            toStringOutput.Add($"CardId = {(CardId == null ? "null" : CardId == string.Empty ? "" : CardId)}");
            toStringOutput.Add($"Timezone = {(Timezone == null ? "null" : Timezone == string.Empty ? "" : Timezone)}");
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            return obj is CreateSubscriptionRequest other &&
                ((IdempotencyKey == null && other.IdempotencyKey == null) || (IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((LocationId == null && other.LocationId == null) || (LocationId?.Equals(other.LocationId) == true)) &&
                ((PlanId == null && other.PlanId == null) || (PlanId?.Equals(other.PlanId) == true)) &&
                ((CustomerId == null && other.CustomerId == null) || (CustomerId?.Equals(other.CustomerId) == true)) &&
                ((StartDate == null && other.StartDate == null) || (StartDate?.Equals(other.StartDate) == true)) &&
                ((CanceledDate == null && other.CanceledDate == null) || (CanceledDate?.Equals(other.CanceledDate) == true)) &&
                ((TaxPercentage == null && other.TaxPercentage == null) || (TaxPercentage?.Equals(other.TaxPercentage) == true)) &&
                ((PriceOverrideMoney == null && other.PriceOverrideMoney == null) || (PriceOverrideMoney?.Equals(other.PriceOverrideMoney) == true)) &&
                ((CardId == null && other.CardId == null) || (CardId?.Equals(other.CardId) == true)) &&
                ((Timezone == null && other.Timezone == null) || (Timezone?.Equals(other.Timezone) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 801909259;

            if (IdempotencyKey != null)
            {
               hashCode += IdempotencyKey.GetHashCode();
            }

            if (LocationId != null)
            {
               hashCode += LocationId.GetHashCode();
            }

            if (PlanId != null)
            {
               hashCode += PlanId.GetHashCode();
            }

            if (CustomerId != null)
            {
               hashCode += CustomerId.GetHashCode();
            }

            if (StartDate != null)
            {
               hashCode += StartDate.GetHashCode();
            }

            if (CanceledDate != null)
            {
               hashCode += CanceledDate.GetHashCode();
            }

            if (TaxPercentage != null)
            {
               hashCode += TaxPercentage.GetHashCode();
            }

            if (PriceOverrideMoney != null)
            {
               hashCode += PriceOverrideMoney.GetHashCode();
            }

            if (CardId != null)
            {
               hashCode += CardId.GetHashCode();
            }

            if (Timezone != null)
            {
               hashCode += Timezone.GetHashCode();
            }

            return hashCode;
        }

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

            public Builder IdempotencyKey(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
                return this;
            }

            public Builder LocationId(string locationId)
            {
                this.locationId = locationId;
                return this;
            }

            public Builder PlanId(string planId)
            {
                this.planId = planId;
                return this;
            }

            public Builder CustomerId(string customerId)
            {
                this.customerId = customerId;
                return this;
            }

            public Builder StartDate(string startDate)
            {
                this.startDate = startDate;
                return this;
            }

            public Builder CanceledDate(string canceledDate)
            {
                this.canceledDate = canceledDate;
                return this;
            }

            public Builder TaxPercentage(string taxPercentage)
            {
                this.taxPercentage = taxPercentage;
                return this;
            }

            public Builder PriceOverrideMoney(Models.Money priceOverrideMoney)
            {
                this.priceOverrideMoney = priceOverrideMoney;
                return this;
            }

            public Builder CardId(string cardId)
            {
                this.cardId = cardId;
                return this;
            }

            public Builder Timezone(string timezone)
            {
                this.timezone = timezone;
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