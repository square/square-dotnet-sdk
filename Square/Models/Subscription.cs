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
    /// Subscription.
    /// </summary>
    public class Subscription
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="Subscription"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="planVariationId">plan_variation_id.</param>
        /// <param name="customerId">customer_id.</param>
        /// <param name="startDate">start_date.</param>
        /// <param name="canceledDate">canceled_date.</param>
        /// <param name="chargedThroughDate">charged_through_date.</param>
        /// <param name="status">status.</param>
        /// <param name="taxPercentage">tax_percentage.</param>
        /// <param name="invoiceIds">invoice_ids.</param>
        /// <param name="priceOverrideMoney">price_override_money.</param>
        /// <param name="version">version.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="cardId">card_id.</param>
        /// <param name="timezone">timezone.</param>
        /// <param name="source">source.</param>
        /// <param name="actions">actions.</param>
        /// <param name="monthlyBillingAnchorDate">monthly_billing_anchor_date.</param>
        /// <param name="phases">phases.</param>
        public Subscription(
            string id = null,
            string locationId = null,
            string planVariationId = null,
            string customerId = null,
            string startDate = null,
            string canceledDate = null,
            string chargedThroughDate = null,
            string status = null,
            string taxPercentage = null,
            IList<string> invoiceIds = null,
            Models.Money priceOverrideMoney = null,
            long? version = null,
            string createdAt = null,
            string cardId = null,
            string timezone = null,
            Models.SubscriptionSource source = null,
            IList<Models.SubscriptionAction> actions = null,
            int? monthlyBillingAnchorDate = null,
            IList<Models.Phase> phases = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "canceled_date", false },
                { "tax_percentage", false },
                { "card_id", false },
                { "actions", false }
            };
            this.Id = id;
            this.LocationId = locationId;
            this.PlanVariationId = planVariationId;
            this.CustomerId = customerId;
            this.StartDate = startDate;

            if (canceledDate != null)
            {
                shouldSerialize["canceled_date"] = true;
                this.CanceledDate = canceledDate;
            }
            this.ChargedThroughDate = chargedThroughDate;
            this.Status = status;

            if (taxPercentage != null)
            {
                shouldSerialize["tax_percentage"] = true;
                this.TaxPercentage = taxPercentage;
            }
            this.InvoiceIds = invoiceIds;
            this.PriceOverrideMoney = priceOverrideMoney;
            this.Version = version;
            this.CreatedAt = createdAt;

            if (cardId != null)
            {
                shouldSerialize["card_id"] = true;
                this.CardId = cardId;
            }
            this.Timezone = timezone;
            this.Source = source;

            if (actions != null)
            {
                shouldSerialize["actions"] = true;
                this.Actions = actions;
            }
            this.MonthlyBillingAnchorDate = monthlyBillingAnchorDate;
            this.Phases = phases;
        }

        internal Subscription(
            Dictionary<string, bool> shouldSerialize,
            string id = null,
            string locationId = null,
            string planVariationId = null,
            string customerId = null,
            string startDate = null,
            string canceledDate = null,
            string chargedThroughDate = null,
            string status = null,
            string taxPercentage = null,
            IList<string> invoiceIds = null,
            Models.Money priceOverrideMoney = null,
            long? version = null,
            string createdAt = null,
            string cardId = null,
            string timezone = null,
            Models.SubscriptionSource source = null,
            IList<Models.SubscriptionAction> actions = null,
            int? monthlyBillingAnchorDate = null,
            IList<Models.Phase> phases = null)
        {
            this.shouldSerialize = shouldSerialize;
            Id = id;
            LocationId = locationId;
            PlanVariationId = planVariationId;
            CustomerId = customerId;
            StartDate = startDate;
            CanceledDate = canceledDate;
            ChargedThroughDate = chargedThroughDate;
            Status = status;
            TaxPercentage = taxPercentage;
            InvoiceIds = invoiceIds;
            PriceOverrideMoney = priceOverrideMoney;
            Version = version;
            CreatedAt = createdAt;
            CardId = cardId;
            Timezone = timezone;
            Source = source;
            Actions = actions;
            MonthlyBillingAnchorDate = monthlyBillingAnchorDate;
            Phases = phases;
        }

        /// <summary>
        /// The Square-assigned ID of the subscription.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The ID of the location associated with the subscription.
        /// </summary>
        [JsonProperty("location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationId { get; }

        /// <summary>
        /// The ID of the subscribed-to [subscription plan variation](entity:CatalogSubscriptionPlanVariation).
        /// </summary>
        [JsonProperty("plan_variation_id", NullValueHandling = NullValueHandling.Ignore)]
        public string PlanVariationId { get; }

        /// <summary>
        /// The ID of the subscribing [customer](entity:Customer) profile.
        /// </summary>
        [JsonProperty("customer_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomerId { get; }

        /// <summary>
        /// The `YYYY-MM-DD`-formatted date (for example, 2013-01-15) to start the subscription.
        /// </summary>
        [JsonProperty("start_date", NullValueHandling = NullValueHandling.Ignore)]
        public string StartDate { get; }

        /// <summary>
        /// The `YYYY-MM-DD`-formatted date (for example, 2013-01-15) to cancel the subscription,
        /// when the subscription status changes to `CANCELED` and the subscription billing stops.
        /// If this field is not set, the subscription ends according its subscription plan.
        /// This field cannot be updated, other than being cleared.
        /// </summary>
        [JsonProperty("canceled_date")]
        public string CanceledDate { get; }

        /// <summary>
        /// The `YYYY-MM-DD`-formatted date up to when the subscriber is invoiced for the
        /// subscription.
        /// After the invoice is sent for a given billing period,
        /// this date will be the last day of the billing period.
        /// For example,
        /// suppose for the month of May a subscriber gets an invoice
        /// (or charged the card) on May 1. For the monthly billing scenario,
        /// this date is then set to May 31.
        /// </summary>
        [JsonProperty("charged_through_date", NullValueHandling = NullValueHandling.Ignore)]
        public string ChargedThroughDate { get; }

        /// <summary>
        /// Supported subscription statuses.
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
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
        /// The IDs of the [invoices](entity:Invoice) created for the
        /// subscription, listed in order when the invoices were created
        /// (newest invoices appear first).
        /// </summary>
        [JsonProperty("invoice_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> InvoiceIds { get; }

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
        /// The version of the object. When updating an object, the version
        /// supplied must match the version in the database, otherwise the write will
        /// be rejected as conflicting.
        /// </summary>
        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public long? Version { get; }

        /// <summary>
        /// The timestamp when the subscription was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// The ID of the [subscriber's](entity:Customer) [card](entity:Card)
        /// used to charge for the subscription.
        /// </summary>
        [JsonProperty("card_id")]
        public string CardId { get; }

        /// <summary>
        /// Timezone that will be used in date calculations for the subscription.
        /// Defaults to the timezone of the location based on `location_id`.
        /// Format: the IANA Timezone Database identifier for the location timezone (for example, `America/Los_Angeles`).
        /// </summary>
        [JsonProperty("timezone", NullValueHandling = NullValueHandling.Ignore)]
        public string Timezone { get; }

        /// <summary>
        /// The origination details of the subscription.
        /// </summary>
        [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
        public Models.SubscriptionSource Source { get; }

        /// <summary>
        /// The list of scheduled actions on this subscription. It is set only in the response from
        /// [RetrieveSubscription]($e/Subscriptions/RetrieveSubscription) with the query parameter
        /// of `include=actions` or from
        /// [SearchSubscriptions]($e/Subscriptions/SearchSubscriptions) with the input parameter
        /// of `include:["actions"]`.
        /// </summary>
        [JsonProperty("actions")]
        public IList<Models.SubscriptionAction> Actions { get; }

        /// <summary>
        /// The day of the month on which the subscription will issue invoices and publish orders.
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
            return $"Subscription : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCanceledDate()
        {
            return this.shouldSerialize["canceled_date"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTaxPercentage()
        {
            return this.shouldSerialize["tax_percentage"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCardId()
        {
            return this.shouldSerialize["card_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeActions()
        {
            return this.shouldSerialize["actions"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is Subscription other &&
                (this.Id == null && other.Id == null ||
                 this.Id?.Equals(other.Id) == true) &&
                (this.LocationId == null && other.LocationId == null ||
                 this.LocationId?.Equals(other.LocationId) == true) &&
                (this.PlanVariationId == null && other.PlanVariationId == null ||
                 this.PlanVariationId?.Equals(other.PlanVariationId) == true) &&
                (this.CustomerId == null && other.CustomerId == null ||
                 this.CustomerId?.Equals(other.CustomerId) == true) &&
                (this.StartDate == null && other.StartDate == null ||
                 this.StartDate?.Equals(other.StartDate) == true) &&
                (this.CanceledDate == null && other.CanceledDate == null ||
                 this.CanceledDate?.Equals(other.CanceledDate) == true) &&
                (this.ChargedThroughDate == null && other.ChargedThroughDate == null ||
                 this.ChargedThroughDate?.Equals(other.ChargedThroughDate) == true) &&
                (this.Status == null && other.Status == null ||
                 this.Status?.Equals(other.Status) == true) &&
                (this.TaxPercentage == null && other.TaxPercentage == null ||
                 this.TaxPercentage?.Equals(other.TaxPercentage) == true) &&
                (this.InvoiceIds == null && other.InvoiceIds == null ||
                 this.InvoiceIds?.Equals(other.InvoiceIds) == true) &&
                (this.PriceOverrideMoney == null && other.PriceOverrideMoney == null ||
                 this.PriceOverrideMoney?.Equals(other.PriceOverrideMoney) == true) &&
                (this.Version == null && other.Version == null ||
                 this.Version?.Equals(other.Version) == true) &&
                (this.CreatedAt == null && other.CreatedAt == null ||
                 this.CreatedAt?.Equals(other.CreatedAt) == true) &&
                (this.CardId == null && other.CardId == null ||
                 this.CardId?.Equals(other.CardId) == true) &&
                (this.Timezone == null && other.Timezone == null ||
                 this.Timezone?.Equals(other.Timezone) == true) &&
                (this.Source == null && other.Source == null ||
                 this.Source?.Equals(other.Source) == true) &&
                (this.Actions == null && other.Actions == null ||
                 this.Actions?.Equals(other.Actions) == true) &&
                (this.MonthlyBillingAnchorDate == null && other.MonthlyBillingAnchorDate == null ||
                 this.MonthlyBillingAnchorDate?.Equals(other.MonthlyBillingAnchorDate) == true) &&
                (this.Phases == null && other.Phases == null ||
                 this.Phases?.Equals(other.Phases) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -186566747;
            hashCode = HashCode.Combine(hashCode, this.Id, this.LocationId, this.PlanVariationId, this.CustomerId, this.StartDate, this.CanceledDate, this.ChargedThroughDate);

            hashCode = HashCode.Combine(hashCode, this.Status, this.TaxPercentage, this.InvoiceIds, this.PriceOverrideMoney, this.Version, this.CreatedAt, this.CardId);

            hashCode = HashCode.Combine(hashCode, this.Timezone, this.Source, this.Actions, this.MonthlyBillingAnchorDate, this.Phases);

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
            toStringOutput.Add($"this.PlanVariationId = {this.PlanVariationId ?? "null"}");
            toStringOutput.Add($"this.CustomerId = {this.CustomerId ?? "null"}");
            toStringOutput.Add($"this.StartDate = {this.StartDate ?? "null"}");
            toStringOutput.Add($"this.CanceledDate = {this.CanceledDate ?? "null"}");
            toStringOutput.Add($"this.ChargedThroughDate = {this.ChargedThroughDate ?? "null"}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status.ToString())}");
            toStringOutput.Add($"this.TaxPercentage = {this.TaxPercentage ?? "null"}");
            toStringOutput.Add($"this.InvoiceIds = {(this.InvoiceIds == null ? "null" : $"[{string.Join(", ", this.InvoiceIds)} ]")}");
            toStringOutput.Add($"this.PriceOverrideMoney = {(this.PriceOverrideMoney == null ? "null" : this.PriceOverrideMoney.ToString())}");
            toStringOutput.Add($"this.Version = {(this.Version == null ? "null" : this.Version.ToString())}");
            toStringOutput.Add($"this.CreatedAt = {this.CreatedAt ?? "null"}");
            toStringOutput.Add($"this.CardId = {this.CardId ?? "null"}");
            toStringOutput.Add($"this.Timezone = {this.Timezone ?? "null"}");
            toStringOutput.Add($"this.Source = {(this.Source == null ? "null" : this.Source.ToString())}");
            toStringOutput.Add($"this.Actions = {(this.Actions == null ? "null" : $"[{string.Join(", ", this.Actions)} ]")}");
            toStringOutput.Add($"this.MonthlyBillingAnchorDate = {(this.MonthlyBillingAnchorDate == null ? "null" : this.MonthlyBillingAnchorDate.ToString())}");
            toStringOutput.Add($"this.Phases = {(this.Phases == null ? "null" : $"[{string.Join(", ", this.Phases)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(this.Id)
                .LocationId(this.LocationId)
                .PlanVariationId(this.PlanVariationId)
                .CustomerId(this.CustomerId)
                .StartDate(this.StartDate)
                .CanceledDate(this.CanceledDate)
                .ChargedThroughDate(this.ChargedThroughDate)
                .Status(this.Status)
                .TaxPercentage(this.TaxPercentage)
                .InvoiceIds(this.InvoiceIds)
                .PriceOverrideMoney(this.PriceOverrideMoney)
                .Version(this.Version)
                .CreatedAt(this.CreatedAt)
                .CardId(this.CardId)
                .Timezone(this.Timezone)
                .Source(this.Source)
                .Actions(this.Actions)
                .MonthlyBillingAnchorDate(this.MonthlyBillingAnchorDate)
                .Phases(this.Phases);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "canceled_date", false },
                { "tax_percentage", false },
                { "card_id", false },
                { "actions", false },
            };

            private string id;
            private string locationId;
            private string planVariationId;
            private string customerId;
            private string startDate;
            private string canceledDate;
            private string chargedThroughDate;
            private string status;
            private string taxPercentage;
            private IList<string> invoiceIds;
            private Models.Money priceOverrideMoney;
            private long? version;
            private string createdAt;
            private string cardId;
            private string timezone;
            private Models.SubscriptionSource source;
            private IList<Models.SubscriptionAction> actions;
            private int? monthlyBillingAnchorDate;
            private IList<Models.Phase> phases;

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
                shouldSerialize["canceled_date"] = true;
                this.canceledDate = canceledDate;
                return this;
            }

             /// <summary>
             /// ChargedThroughDate.
             /// </summary>
             /// <param name="chargedThroughDate"> chargedThroughDate. </param>
             /// <returns> Builder. </returns>
            public Builder ChargedThroughDate(string chargedThroughDate)
            {
                this.chargedThroughDate = chargedThroughDate;
                return this;
            }

             /// <summary>
             /// Status.
             /// </summary>
             /// <param name="status"> status. </param>
             /// <returns> Builder. </returns>
            public Builder Status(string status)
            {
                this.status = status;
                return this;
            }

             /// <summary>
             /// TaxPercentage.
             /// </summary>
             /// <param name="taxPercentage"> taxPercentage. </param>
             /// <returns> Builder. </returns>
            public Builder TaxPercentage(string taxPercentage)
            {
                shouldSerialize["tax_percentage"] = true;
                this.taxPercentage = taxPercentage;
                return this;
            }

             /// <summary>
             /// InvoiceIds.
             /// </summary>
             /// <param name="invoiceIds"> invoiceIds. </param>
             /// <returns> Builder. </returns>
            public Builder InvoiceIds(IList<string> invoiceIds)
            {
                this.invoiceIds = invoiceIds;
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
             /// Version.
             /// </summary>
             /// <param name="version"> version. </param>
             /// <returns> Builder. </returns>
            public Builder Version(long? version)
            {
                this.version = version;
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
             /// CardId.
             /// </summary>
             /// <param name="cardId"> cardId. </param>
             /// <returns> Builder. </returns>
            public Builder CardId(string cardId)
            {
                shouldSerialize["card_id"] = true;
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
             /// Actions.
             /// </summary>
             /// <param name="actions"> actions. </param>
             /// <returns> Builder. </returns>
            public Builder Actions(IList<Models.SubscriptionAction> actions)
            {
                shouldSerialize["actions"] = true;
                this.actions = actions;
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
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetCanceledDate()
            {
                this.shouldSerialize["canceled_date"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetTaxPercentage()
            {
                this.shouldSerialize["tax_percentage"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetCardId()
            {
                this.shouldSerialize["card_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetActions()
            {
                this.shouldSerialize["actions"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> Subscription. </returns>
            public Subscription Build()
            {
                return new Subscription(
                    shouldSerialize,
                    this.id,
                    this.locationId,
                    this.planVariationId,
                    this.customerId,
                    this.startDate,
                    this.canceledDate,
                    this.chargedThroughDate,
                    this.status,
                    this.taxPercentage,
                    this.invoiceIds,
                    this.priceOverrideMoney,
                    this.version,
                    this.createdAt,
                    this.cardId,
                    this.timezone,
                    this.source,
                    this.actions,
                    this.monthlyBillingAnchorDate,
                    this.phases);
            }
        }
    }
}