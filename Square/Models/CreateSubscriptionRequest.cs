namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// CreateSubscriptionRequest.
    /// </summary>
    public class CreateSubscriptionRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSubscriptionRequest"/> class.
        /// </summary>
        /// <param name="locationId">location_id.</param>
        /// <param name="planId">plan_id.</param>
        /// <param name="customerId">customer_id.</param>
        /// <param name="idempotencyKey">idempotency_key.</param>
        /// <param name="startDate">start_date.</param>
        /// <param name="canceledDate">canceled_date.</param>
        /// <param name="taxPercentage">tax_percentage.</param>
        /// <param name="priceOverrideMoney">price_override_money.</param>
        /// <param name="cardId">card_id.</param>
        /// <param name="timezone">timezone.</param>
        public CreateSubscriptionRequest(
            string locationId,
            string planId,
            string customerId,
            string idempotencyKey = null,
            string startDate = null,
            string canceledDate = null,
            string taxPercentage = null,
            Models.Money priceOverrideMoney = null,
            string cardId = null,
            string timezone = null)
        {
            this.IdempotencyKey = idempotencyKey;
            this.LocationId = locationId;
            this.PlanId = planId;
            this.CustomerId = customerId;
            this.StartDate = startDate;
            this.CanceledDate = canceledDate;
            this.TaxPercentage = taxPercentage;
            this.PriceOverrideMoney = priceOverrideMoney;
            this.CardId = cardId;
            this.Timezone = timezone;
        }

        /// <summary>
        /// A unique string that identifies this `CreateSubscription` request.
        /// If you do not provide a unique string (or provide an empty string as the value),
        /// the endpoint treats each request as independent.
        /// For more information, see [Idempotency keys](https://developer.squareup.com/docs/working-with-apis/idempotency).
        /// </summary>
        [JsonProperty("idempotency_key", NullValueHandling = NullValueHandling.Ignore)]
        public string IdempotencyKey { get; }

        /// <summary>
        /// The ID of the location the subscription is associated with.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <summary>
        /// The ID of the subscription plan created using the Catalog API.
        /// For more information, see
        /// [Set Up and Manage a Subscription Plan](https://developer.squareup.com/docs/subscriptions-api/setup-plan) and
        /// [Subscriptions Walkthrough](https://developer.squareup.com/docs/subscriptions-api/walkthrough).
        /// </summary>
        [JsonProperty("plan_id")]
        public string PlanId { get; }

        /// <summary>
        /// The ID of the [customer]($m/Customer) profile.
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
        /// The ID of the [customer]($m/Customer) [card]($m/Card) to charge.
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateSubscriptionRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
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
                ((this.IdempotencyKey == null && other.IdempotencyKey == null) || (this.IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.PlanId == null && other.PlanId == null) || (this.PlanId?.Equals(other.PlanId) == true)) &&
                ((this.CustomerId == null && other.CustomerId == null) || (this.CustomerId?.Equals(other.CustomerId) == true)) &&
                ((this.StartDate == null && other.StartDate == null) || (this.StartDate?.Equals(other.StartDate) == true)) &&
                ((this.CanceledDate == null && other.CanceledDate == null) || (this.CanceledDate?.Equals(other.CanceledDate) == true)) &&
                ((this.TaxPercentage == null && other.TaxPercentage == null) || (this.TaxPercentage?.Equals(other.TaxPercentage) == true)) &&
                ((this.PriceOverrideMoney == null && other.PriceOverrideMoney == null) || (this.PriceOverrideMoney?.Equals(other.PriceOverrideMoney) == true)) &&
                ((this.CardId == null && other.CardId == null) || (this.CardId?.Equals(other.CardId) == true)) &&
                ((this.Timezone == null && other.Timezone == null) || (this.Timezone?.Equals(other.Timezone) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 801909259;

            if (this.IdempotencyKey != null)
            {
               hashCode += this.IdempotencyKey.GetHashCode();
            }

            if (this.LocationId != null)
            {
               hashCode += this.LocationId.GetHashCode();
            }

            if (this.PlanId != null)
            {
               hashCode += this.PlanId.GetHashCode();
            }

            if (this.CustomerId != null)
            {
               hashCode += this.CustomerId.GetHashCode();
            }

            if (this.StartDate != null)
            {
               hashCode += this.StartDate.GetHashCode();
            }

            if (this.CanceledDate != null)
            {
               hashCode += this.CanceledDate.GetHashCode();
            }

            if (this.TaxPercentage != null)
            {
               hashCode += this.TaxPercentage.GetHashCode();
            }

            if (this.PriceOverrideMoney != null)
            {
               hashCode += this.PriceOverrideMoney.GetHashCode();
            }

            if (this.CardId != null)
            {
               hashCode += this.CardId.GetHashCode();
            }

            if (this.Timezone != null)
            {
               hashCode += this.Timezone.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.IdempotencyKey = {(this.IdempotencyKey == null ? "null" : this.IdempotencyKey == string.Empty ? "" : this.IdempotencyKey)}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId == string.Empty ? "" : this.LocationId)}");
            toStringOutput.Add($"this.PlanId = {(this.PlanId == null ? "null" : this.PlanId == string.Empty ? "" : this.PlanId)}");
            toStringOutput.Add($"this.CustomerId = {(this.CustomerId == null ? "null" : this.CustomerId == string.Empty ? "" : this.CustomerId)}");
            toStringOutput.Add($"this.StartDate = {(this.StartDate == null ? "null" : this.StartDate == string.Empty ? "" : this.StartDate)}");
            toStringOutput.Add($"this.CanceledDate = {(this.CanceledDate == null ? "null" : this.CanceledDate == string.Empty ? "" : this.CanceledDate)}");
            toStringOutput.Add($"this.TaxPercentage = {(this.TaxPercentage == null ? "null" : this.TaxPercentage == string.Empty ? "" : this.TaxPercentage)}");
            toStringOutput.Add($"this.PriceOverrideMoney = {(this.PriceOverrideMoney == null ? "null" : this.PriceOverrideMoney.ToString())}");
            toStringOutput.Add($"this.CardId = {(this.CardId == null ? "null" : this.CardId == string.Empty ? "" : this.CardId)}");
            toStringOutput.Add($"this.Timezone = {(this.Timezone == null ? "null" : this.Timezone == string.Empty ? "" : this.Timezone)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.LocationId,
                this.PlanId,
                this.CustomerId)
                .IdempotencyKey(this.IdempotencyKey)
                .StartDate(this.StartDate)
                .CanceledDate(this.CanceledDate)
                .TaxPercentage(this.TaxPercentage)
                .PriceOverrideMoney(this.PriceOverrideMoney)
                .CardId(this.CardId)
                .Timezone(this.Timezone);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string locationId;
            private string planId;
            private string customerId;
            private string idempotencyKey;
            private string startDate;
            private string canceledDate;
            private string taxPercentage;
            private Models.Money priceOverrideMoney;
            private string cardId;
            private string timezone;

            public Builder(
                string locationId,
                string planId,
                string customerId)
            {
                this.locationId = locationId;
                this.planId = planId;
                this.customerId = customerId;
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
             /// PlanId.
             /// </summary>
             /// <param name="planId"> planId. </param>
             /// <returns> Builder. </returns>
            public Builder PlanId(string planId)
            {
                this.planId = planId;
                return this;
            }

             /// <summary>
             /// CustomerId.
             /// </summary>
             /// <param name="customerId"> customerId. </param>
             /// <returns> Builder. </returns>
            public Builder CustomerId(string customerId)
            {
                this.customerId = customerId;
                return this;
            }

             /// <summary>
             /// IdempotencyKey.
             /// </summary>
             /// <param name="idempotencyKey"> idempotencyKey. </param>
             /// <returns> Builder. </returns>
            public Builder IdempotencyKey(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
                return this;
            }

             /// <summary>
             /// StartDate.
             /// </summary>
             /// <param name="startDate"> startDate. </param>
             /// <returns> Builder. </returns>
            public Builder StartDate(string startDate)
            {
                this.startDate = startDate;
                return this;
            }

             /// <summary>
             /// CanceledDate.
             /// </summary>
             /// <param name="canceledDate"> canceledDate. </param>
             /// <returns> Builder. </returns>
            public Builder CanceledDate(string canceledDate)
            {
                this.canceledDate = canceledDate;
                return this;
            }

             /// <summary>
             /// TaxPercentage.
             /// </summary>
             /// <param name="taxPercentage"> taxPercentage. </param>
             /// <returns> Builder. </returns>
            public Builder TaxPercentage(string taxPercentage)
            {
                this.taxPercentage = taxPercentage;
                return this;
            }

             /// <summary>
             /// PriceOverrideMoney.
             /// </summary>
             /// <param name="priceOverrideMoney"> priceOverrideMoney. </param>
             /// <returns> Builder. </returns>
            public Builder PriceOverrideMoney(Models.Money priceOverrideMoney)
            {
                this.priceOverrideMoney = priceOverrideMoney;
                return this;
            }

             /// <summary>
             /// CardId.
             /// </summary>
             /// <param name="cardId"> cardId. </param>
             /// <returns> Builder. </returns>
            public Builder CardId(string cardId)
            {
                this.cardId = cardId;
                return this;
            }

             /// <summary>
             /// Timezone.
             /// </summary>
             /// <param name="timezone"> timezone. </param>
             /// <returns> Builder. </returns>
            public Builder Timezone(string timezone)
            {
                this.timezone = timezone;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CreateSubscriptionRequest. </returns>
            public CreateSubscriptionRequest Build()
            {
                return new CreateSubscriptionRequest(
                    this.locationId,
                    this.planId,
                    this.customerId,
                    this.idempotencyKey,
                    this.startDate,
                    this.canceledDate,
                    this.taxPercentage,
                    this.priceOverrideMoney,
                    this.cardId,
                    this.timezone);
            }
        }
    }
}