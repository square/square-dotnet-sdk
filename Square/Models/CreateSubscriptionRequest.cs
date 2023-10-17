namespace Square.Models
{
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

    /// <summary>
    /// CreateSubscriptionRequest.
    /// </summary>
    public class CreateSubscriptionRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSubscriptionRequest"/> class.
        /// </summary>
        /// <param name="locationId">location_id.</param>
        /// <param name="customerId">customer_id.</param>
        /// <param name="idempotencyKey">idempotency_key.</param>
        /// <param name="planVariationId">plan_variation_id.</param>
        /// <param name="startDate">start_date.</param>
        /// <param name="canceledDate">canceled_date.</param>
        /// <param name="taxPercentage">tax_percentage.</param>
        /// <param name="priceOverrideMoney">price_override_money.</param>
        /// <param name="cardId">card_id.</param>
        /// <param name="timezone">timezone.</param>
        /// <param name="source">source.</param>
        /// <param name="monthlyBillingAnchorDate">monthly_billing_anchor_date.</param>
        /// <param name="phases">phases.</param>
        public CreateSubscriptionRequest(
            string locationId,
            string customerId,
            string idempotencyKey = null,
            string planVariationId = null,
            string startDate = null,
            string canceledDate = null,
            string taxPercentage = null,
            Models.Money priceOverrideMoney = null,
            string cardId = null,
            string timezone = null,
            Models.SubscriptionSource source = null,
            int? monthlyBillingAnchorDate = null,
            IList<Models.Phase> phases = null)
        {
            this.IdempotencyKey = idempotencyKey;
            this.LocationId = locationId;
            this.PlanVariationId = planVariationId;
            this.CustomerId = customerId;
            this.StartDate = startDate;
            this.CanceledDate = canceledDate;
            this.TaxPercentage = taxPercentage;
            this.PriceOverrideMoney = priceOverrideMoney;
            this.CardId = cardId;
            this.Timezone = timezone;
            this.Source = source;
            this.MonthlyBillingAnchorDate = monthlyBillingAnchorDate;
            this.Phases = phases;
        }

        /// <summary>
        /// A unique string that identifies this `CreateSubscription` request.
        /// If you do not provide a unique string (or provide an empty string as the value),
        /// the endpoint treats each request as independent.
        /// For more information, see [Idempotency keys](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency).
        /// </summary>
        [JsonProperty("idempotency_key", NullValueHandling = NullValueHandling.Ignore)]
        public string IdempotencyKey { get; }

        /// <summary>
        /// The ID of the location the subscription is associated with.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <summary>
        /// The ID of the [subscription plan variation](https://developer.squareup.com/docs/subscriptions-api/plans-and-variations#plan-variations) created using the Catalog API.
        /// </summary>
        [JsonProperty("plan_variation_id", NullValueHandling = NullValueHandling.Ignore)]
        public string PlanVariationId { get; }

        /// <summary>
        /// The ID of the [customer](entity:Customer) subscribing to the subscription plan variation.
        /// </summary>
        [JsonProperty("customer_id")]
        public string CustomerId { get; }

        /// <summary>
        /// The `YYYY-MM-DD`-formatted date to start the subscription.
        /// If it is unspecified, the subscription starts immediately.
        /// </summary>
        [JsonProperty("start_date", NullValueHandling = NullValueHandling.Ignore)]
        public string StartDate { get; }

        /// <summary>
        /// The `YYYY-MM-DD`-formatted date when the newly created subscription is scheduled for cancellation.
        /// This date overrides the cancellation date set in the plan variation configuration.
        /// If the cancellation date is earlier than the end date of a subscription cycle, the subscription stops
        /// at the canceled date and the subscriber is sent a prorated invoice at the beginning of the canceled cycle.
        /// When the subscription plan of the newly created subscription has a fixed number of cycles and the `canceled_date`
        /// occurs before the subscription plan expires, the specified `canceled_date` sets the date when the subscription
        /// stops through the end of the last cycle.
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
        /// The ID of the [subscriber's](entity:Customer) [card](entity:Card) to charge.
        /// If it is not specified, the subscriber receives an invoice via email with a link to pay for their subscription.
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

        /// <summary>
        /// The origination details of the subscription.
        /// </summary>
        [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
        public Models.SubscriptionSource Source { get; }

        /// <summary>
        /// The day-of-the-month to change the billing date to.
        /// </summary>
        [JsonProperty("monthly_billing_anchor_date", NullValueHandling = NullValueHandling.Ignore)]
        public int? MonthlyBillingAnchorDate { get; }

        /// <summary>
        /// array of phases for this subscription
        /// </summary>
        [JsonProperty("phases", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Phase> Phases { get; }

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
            return obj is CreateSubscriptionRequest other &&                ((this.IdempotencyKey == null && other.IdempotencyKey == null) || (this.IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.PlanVariationId == null && other.PlanVariationId == null) || (this.PlanVariationId?.Equals(other.PlanVariationId) == true)) &&
                ((this.CustomerId == null && other.CustomerId == null) || (this.CustomerId?.Equals(other.CustomerId) == true)) &&
                ((this.StartDate == null && other.StartDate == null) || (this.StartDate?.Equals(other.StartDate) == true)) &&
                ((this.CanceledDate == null && other.CanceledDate == null) || (this.CanceledDate?.Equals(other.CanceledDate) == true)) &&
                ((this.TaxPercentage == null && other.TaxPercentage == null) || (this.TaxPercentage?.Equals(other.TaxPercentage) == true)) &&
                ((this.PriceOverrideMoney == null && other.PriceOverrideMoney == null) || (this.PriceOverrideMoney?.Equals(other.PriceOverrideMoney) == true)) &&
                ((this.CardId == null && other.CardId == null) || (this.CardId?.Equals(other.CardId) == true)) &&
                ((this.Timezone == null && other.Timezone == null) || (this.Timezone?.Equals(other.Timezone) == true)) &&
                ((this.Source == null && other.Source == null) || (this.Source?.Equals(other.Source) == true)) &&
                ((this.MonthlyBillingAnchorDate == null && other.MonthlyBillingAnchorDate == null) || (this.MonthlyBillingAnchorDate?.Equals(other.MonthlyBillingAnchorDate) == true)) &&
                ((this.Phases == null && other.Phases == null) || (this.Phases?.Equals(other.Phases) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -161501428;
            hashCode = HashCode.Combine(this.IdempotencyKey, this.LocationId, this.PlanVariationId, this.CustomerId, this.StartDate, this.CanceledDate, this.TaxPercentage);

            hashCode = HashCode.Combine(hashCode, this.PriceOverrideMoney, this.CardId, this.Timezone, this.Source, this.MonthlyBillingAnchorDate, this.Phases);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.IdempotencyKey = {(this.IdempotencyKey == null ? "null" : this.IdempotencyKey)}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId)}");
            toStringOutput.Add($"this.PlanVariationId = {(this.PlanVariationId == null ? "null" : this.PlanVariationId)}");
            toStringOutput.Add($"this.CustomerId = {(this.CustomerId == null ? "null" : this.CustomerId)}");
            toStringOutput.Add($"this.StartDate = {(this.StartDate == null ? "null" : this.StartDate)}");
            toStringOutput.Add($"this.CanceledDate = {(this.CanceledDate == null ? "null" : this.CanceledDate)}");
            toStringOutput.Add($"this.TaxPercentage = {(this.TaxPercentage == null ? "null" : this.TaxPercentage)}");
            toStringOutput.Add($"this.PriceOverrideMoney = {(this.PriceOverrideMoney == null ? "null" : this.PriceOverrideMoney.ToString())}");
            toStringOutput.Add($"this.CardId = {(this.CardId == null ? "null" : this.CardId)}");
            toStringOutput.Add($"this.Timezone = {(this.Timezone == null ? "null" : this.Timezone)}");
            toStringOutput.Add($"this.Source = {(this.Source == null ? "null" : this.Source.ToString())}");
            toStringOutput.Add($"this.MonthlyBillingAnchorDate = {(this.MonthlyBillingAnchorDate == null ? "null" : this.MonthlyBillingAnchorDate.ToString())}");
            toStringOutput.Add($"this.Phases = {(this.Phases == null ? "null" : $"[{string.Join(", ", this.Phases)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.LocationId,
                this.CustomerId)
                .IdempotencyKey(this.IdempotencyKey)
                .PlanVariationId(this.PlanVariationId)
                .StartDate(this.StartDate)
                .CanceledDate(this.CanceledDate)
                .TaxPercentage(this.TaxPercentage)
                .PriceOverrideMoney(this.PriceOverrideMoney)
                .CardId(this.CardId)
                .Timezone(this.Timezone)
                .Source(this.Source)
                .MonthlyBillingAnchorDate(this.MonthlyBillingAnchorDate)
                .Phases(this.Phases);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string locationId;
            private string customerId;
            private string idempotencyKey;
            private string planVariationId;
            private string startDate;
            private string canceledDate;
            private string taxPercentage;
            private Models.Money priceOverrideMoney;
            private string cardId;
            private string timezone;
            private Models.SubscriptionSource source;
            private int? monthlyBillingAnchorDate;
            private IList<Models.Phase> phases;

            public Builder(
                string locationId,
                string customerId)
            {
                this.locationId = locationId;
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
             /// PlanVariationId.
             /// </summary>
             /// <param name="planVariationId"> planVariationId. </param>
             /// <returns> Builder. </returns>
            public Builder PlanVariationId(string planVariationId)
            {
                this.planVariationId = planVariationId;
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
             /// Source.
             /// </summary>
             /// <param name="source"> source. </param>
             /// <returns> Builder. </returns>
            public Builder Source(Models.SubscriptionSource source)
            {
                this.source = source;
                return this;
            }

             /// <summary>
             /// MonthlyBillingAnchorDate.
             /// </summary>
             /// <param name="monthlyBillingAnchorDate"> monthlyBillingAnchorDate. </param>
             /// <returns> Builder. </returns>
            public Builder MonthlyBillingAnchorDate(int? monthlyBillingAnchorDate)
            {
                this.monthlyBillingAnchorDate = monthlyBillingAnchorDate;
                return this;
            }

             /// <summary>
             /// Phases.
             /// </summary>
             /// <param name="phases"> phases. </param>
             /// <returns> Builder. </returns>
            public Builder Phases(IList<Models.Phase> phases)
            {
                this.phases = phases;
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
                    this.customerId,
                    this.idempotencyKey,
                    this.planVariationId,
                    this.startDate,
                    this.canceledDate,
                    this.taxPercentage,
                    this.priceOverrideMoney,
                    this.cardId,
                    this.timezone,
                    this.source,
                    this.monthlyBillingAnchorDate,
                    this.phases);
            }
        }
    }
}