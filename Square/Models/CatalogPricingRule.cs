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
    /// CatalogPricingRule.
    /// </summary>
    public class CatalogPricingRule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogPricingRule"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="timePeriodIds">time_period_ids.</param>
        /// <param name="discountId">discount_id.</param>
        /// <param name="matchProductsId">match_products_id.</param>
        /// <param name="applyProductsId">apply_products_id.</param>
        /// <param name="excludeProductsId">exclude_products_id.</param>
        /// <param name="validFromDate">valid_from_date.</param>
        /// <param name="validFromLocalTime">valid_from_local_time.</param>
        /// <param name="validUntilDate">valid_until_date.</param>
        /// <param name="validUntilLocalTime">valid_until_local_time.</param>
        /// <param name="excludeStrategy">exclude_strategy.</param>
        /// <param name="customerGroupIdsAny">customer_group_ids_any.</param>
        public CatalogPricingRule(
            string name = null,
            IList<string> timePeriodIds = null,
            string discountId = null,
            string matchProductsId = null,
            string applyProductsId = null,
            string excludeProductsId = null,
            string validFromDate = null,
            string validFromLocalTime = null,
            string validUntilDate = null,
            string validUntilLocalTime = null,
            string excludeStrategy = null,
            IList<string> customerGroupIdsAny = null)
        {
            this.Name = name;
            this.TimePeriodIds = timePeriodIds;
            this.DiscountId = discountId;
            this.MatchProductsId = matchProductsId;
            this.ApplyProductsId = applyProductsId;
            this.ExcludeProductsId = excludeProductsId;
            this.ValidFromDate = validFromDate;
            this.ValidFromLocalTime = validFromLocalTime;
            this.ValidUntilDate = validUntilDate;
            this.ValidUntilLocalTime = validUntilLocalTime;
            this.ExcludeStrategy = excludeStrategy;
            this.CustomerGroupIdsAny = customerGroupIdsAny;
        }

        /// <summary>
        /// User-defined name for the pricing rule. For example, "Buy one get one
        /// free" or "10% off".
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; }

        /// <summary>
        /// A list of unique IDs for the catalog time periods when
        /// this pricing rule is in effect. If left unset, the pricing rule is always
        /// in effect.
        /// </summary>
        [JsonProperty("time_period_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> TimePeriodIds { get; }

        /// <summary>
        /// Unique ID for the `CatalogDiscount` to take off
        /// the price of all matched items.
        /// </summary>
        [JsonProperty("discount_id", NullValueHandling = NullValueHandling.Ignore)]
        public string DiscountId { get; }

        /// <summary>
        /// Unique ID for the `CatalogProductSet` that will be matched by this rule. A match rule
        /// matches within the entire cart, and can match multiple times. This field will always be set.
        /// </summary>
        [JsonProperty("match_products_id", NullValueHandling = NullValueHandling.Ignore)]
        public string MatchProductsId { get; }

        /// <summary>
        /// __Deprecated__: Please use the `exclude_products_id` field to apply
        /// an exclude set instead. Exclude sets allow better control over quantity
        /// ranges and offer more flexibility for which matched items receive a discount.
        /// `CatalogProductSet` to apply the pricing to.
        /// An apply rule matches within the subset of the cart that fits the match rules (the match set).
        /// An apply rule can only match once in the match set.
        /// If not supplied, the pricing will be applied to all products in the match set.
        /// Other products retain their base price, or a price generated by other rules.
        /// </summary>
        [JsonProperty("apply_products_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ApplyProductsId { get; }

        /// <summary>
        /// `CatalogProductSet` to exclude from the pricing rule.
        /// An exclude rule matches within the subset of the cart that fits the match rules (the match set).
        /// An exclude rule can only match once in the match set.
        /// If not supplied, the pricing will be applied to all products in the match set.
        /// Other products retain their base price, or a price generated by other rules.
        /// </summary>
        [JsonProperty("exclude_products_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ExcludeProductsId { get; }

        /// <summary>
        /// Represents the date the Pricing Rule is valid from. Represented in RFC 3339 full-date format (YYYY-MM-DD).
        /// </summary>
        [JsonProperty("valid_from_date", NullValueHandling = NullValueHandling.Ignore)]
        public string ValidFromDate { get; }

        /// <summary>
        /// Represents the local time the pricing rule should be valid from. Represented in RFC 3339 partial-time format
        /// (HH:MM:SS). Partial seconds will be truncated.
        /// </summary>
        [JsonProperty("valid_from_local_time", NullValueHandling = NullValueHandling.Ignore)]
        public string ValidFromLocalTime { get; }

        /// <summary>
        /// Represents the date the Pricing Rule is valid until. Represented in RFC 3339 full-date format (YYYY-MM-DD).
        /// </summary>
        [JsonProperty("valid_until_date", NullValueHandling = NullValueHandling.Ignore)]
        public string ValidUntilDate { get; }

        /// <summary>
        /// Represents the local time the pricing rule should be valid until. Represented in RFC 3339 partial-time format
        /// (HH:MM:SS). Partial seconds will be truncated.
        /// </summary>
        [JsonProperty("valid_until_local_time", NullValueHandling = NullValueHandling.Ignore)]
        public string ValidUntilLocalTime { get; }

        /// <summary>
        /// Indicates which products matched by a CatalogPricingRule
        /// will be excluded if the pricing rule uses an exclude set.
        /// </summary>
        [JsonProperty("exclude_strategy", NullValueHandling = NullValueHandling.Ignore)]
        public string ExcludeStrategy { get; }

        /// <summary>
        /// A list of IDs of customer groups, the members of which are eligible for discounts specified in this pricing rule.
        /// Notice that a group ID is generated by the Customers API.
        /// If this field is not set, the specified discount applies to matched products sold to anyone whether the buyer
        /// has a customer profile created or not. If this `customer_group_ids_any` field is set, the specified discount
        /// applies only to matched products sold to customers belonging to the specified customer groups.
        /// </summary>
        [JsonProperty("customer_group_ids_any", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> CustomerGroupIdsAny { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogPricingRule : ({string.Join(", ", toStringOutput)})";
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

            return obj is CatalogPricingRule other &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.TimePeriodIds == null && other.TimePeriodIds == null) || (this.TimePeriodIds?.Equals(other.TimePeriodIds) == true)) &&
                ((this.DiscountId == null && other.DiscountId == null) || (this.DiscountId?.Equals(other.DiscountId) == true)) &&
                ((this.MatchProductsId == null && other.MatchProductsId == null) || (this.MatchProductsId?.Equals(other.MatchProductsId) == true)) &&
                ((this.ApplyProductsId == null && other.ApplyProductsId == null) || (this.ApplyProductsId?.Equals(other.ApplyProductsId) == true)) &&
                ((this.ExcludeProductsId == null && other.ExcludeProductsId == null) || (this.ExcludeProductsId?.Equals(other.ExcludeProductsId) == true)) &&
                ((this.ValidFromDate == null && other.ValidFromDate == null) || (this.ValidFromDate?.Equals(other.ValidFromDate) == true)) &&
                ((this.ValidFromLocalTime == null && other.ValidFromLocalTime == null) || (this.ValidFromLocalTime?.Equals(other.ValidFromLocalTime) == true)) &&
                ((this.ValidUntilDate == null && other.ValidUntilDate == null) || (this.ValidUntilDate?.Equals(other.ValidUntilDate) == true)) &&
                ((this.ValidUntilLocalTime == null && other.ValidUntilLocalTime == null) || (this.ValidUntilLocalTime?.Equals(other.ValidUntilLocalTime) == true)) &&
                ((this.ExcludeStrategy == null && other.ExcludeStrategy == null) || (this.ExcludeStrategy?.Equals(other.ExcludeStrategy) == true)) &&
                ((this.CustomerGroupIdsAny == null && other.CustomerGroupIdsAny == null) || (this.CustomerGroupIdsAny?.Equals(other.CustomerGroupIdsAny) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1692018639;

            if (this.Name != null)
            {
               hashCode += this.Name.GetHashCode();
            }

            if (this.TimePeriodIds != null)
            {
               hashCode += this.TimePeriodIds.GetHashCode();
            }

            if (this.DiscountId != null)
            {
               hashCode += this.DiscountId.GetHashCode();
            }

            if (this.MatchProductsId != null)
            {
               hashCode += this.MatchProductsId.GetHashCode();
            }

            if (this.ApplyProductsId != null)
            {
               hashCode += this.ApplyProductsId.GetHashCode();
            }

            if (this.ExcludeProductsId != null)
            {
               hashCode += this.ExcludeProductsId.GetHashCode();
            }

            if (this.ValidFromDate != null)
            {
               hashCode += this.ValidFromDate.GetHashCode();
            }

            if (this.ValidFromLocalTime != null)
            {
               hashCode += this.ValidFromLocalTime.GetHashCode();
            }

            if (this.ValidUntilDate != null)
            {
               hashCode += this.ValidUntilDate.GetHashCode();
            }

            if (this.ValidUntilLocalTime != null)
            {
               hashCode += this.ValidUntilLocalTime.GetHashCode();
            }

            if (this.ExcludeStrategy != null)
            {
               hashCode += this.ExcludeStrategy.GetHashCode();
            }

            if (this.CustomerGroupIdsAny != null)
            {
               hashCode += this.CustomerGroupIdsAny.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name == string.Empty ? "" : this.Name)}");
            toStringOutput.Add($"this.TimePeriodIds = {(this.TimePeriodIds == null ? "null" : $"[{string.Join(", ", this.TimePeriodIds)} ]")}");
            toStringOutput.Add($"this.DiscountId = {(this.DiscountId == null ? "null" : this.DiscountId == string.Empty ? "" : this.DiscountId)}");
            toStringOutput.Add($"this.MatchProductsId = {(this.MatchProductsId == null ? "null" : this.MatchProductsId == string.Empty ? "" : this.MatchProductsId)}");
            toStringOutput.Add($"this.ApplyProductsId = {(this.ApplyProductsId == null ? "null" : this.ApplyProductsId == string.Empty ? "" : this.ApplyProductsId)}");
            toStringOutput.Add($"this.ExcludeProductsId = {(this.ExcludeProductsId == null ? "null" : this.ExcludeProductsId == string.Empty ? "" : this.ExcludeProductsId)}");
            toStringOutput.Add($"this.ValidFromDate = {(this.ValidFromDate == null ? "null" : this.ValidFromDate == string.Empty ? "" : this.ValidFromDate)}");
            toStringOutput.Add($"this.ValidFromLocalTime = {(this.ValidFromLocalTime == null ? "null" : this.ValidFromLocalTime == string.Empty ? "" : this.ValidFromLocalTime)}");
            toStringOutput.Add($"this.ValidUntilDate = {(this.ValidUntilDate == null ? "null" : this.ValidUntilDate == string.Empty ? "" : this.ValidUntilDate)}");
            toStringOutput.Add($"this.ValidUntilLocalTime = {(this.ValidUntilLocalTime == null ? "null" : this.ValidUntilLocalTime == string.Empty ? "" : this.ValidUntilLocalTime)}");
            toStringOutput.Add($"this.ExcludeStrategy = {(this.ExcludeStrategy == null ? "null" : this.ExcludeStrategy.ToString())}");
            toStringOutput.Add($"this.CustomerGroupIdsAny = {(this.CustomerGroupIdsAny == null ? "null" : $"[{string.Join(", ", this.CustomerGroupIdsAny)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Name(this.Name)
                .TimePeriodIds(this.TimePeriodIds)
                .DiscountId(this.DiscountId)
                .MatchProductsId(this.MatchProductsId)
                .ApplyProductsId(this.ApplyProductsId)
                .ExcludeProductsId(this.ExcludeProductsId)
                .ValidFromDate(this.ValidFromDate)
                .ValidFromLocalTime(this.ValidFromLocalTime)
                .ValidUntilDate(this.ValidUntilDate)
                .ValidUntilLocalTime(this.ValidUntilLocalTime)
                .ExcludeStrategy(this.ExcludeStrategy)
                .CustomerGroupIdsAny(this.CustomerGroupIdsAny);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string name;
            private IList<string> timePeriodIds;
            private string discountId;
            private string matchProductsId;
            private string applyProductsId;
            private string excludeProductsId;
            private string validFromDate;
            private string validFromLocalTime;
            private string validUntilDate;
            private string validUntilLocalTime;
            private string excludeStrategy;
            private IList<string> customerGroupIdsAny;

             /// <summary>
             /// Name.
             /// </summary>
             /// <param name="name"> name. </param>
             /// <returns> Builder. </returns>
            public Builder Name(string name)
            {
                this.name = name;
                return this;
            }

             /// <summary>
             /// TimePeriodIds.
             /// </summary>
             /// <param name="timePeriodIds"> timePeriodIds. </param>
             /// <returns> Builder. </returns>
            public Builder TimePeriodIds(IList<string> timePeriodIds)
            {
                this.timePeriodIds = timePeriodIds;
                return this;
            }

             /// <summary>
             /// DiscountId.
             /// </summary>
             /// <param name="discountId"> discountId. </param>
             /// <returns> Builder. </returns>
            public Builder DiscountId(string discountId)
            {
                this.discountId = discountId;
                return this;
            }

             /// <summary>
             /// MatchProductsId.
             /// </summary>
             /// <param name="matchProductsId"> matchProductsId. </param>
             /// <returns> Builder. </returns>
            public Builder MatchProductsId(string matchProductsId)
            {
                this.matchProductsId = matchProductsId;
                return this;
            }

             /// <summary>
             /// ApplyProductsId.
             /// </summary>
             /// <param name="applyProductsId"> applyProductsId. </param>
             /// <returns> Builder. </returns>
            public Builder ApplyProductsId(string applyProductsId)
            {
                this.applyProductsId = applyProductsId;
                return this;
            }

             /// <summary>
             /// ExcludeProductsId.
             /// </summary>
             /// <param name="excludeProductsId"> excludeProductsId. </param>
             /// <returns> Builder. </returns>
            public Builder ExcludeProductsId(string excludeProductsId)
            {
                this.excludeProductsId = excludeProductsId;
                return this;
            }

             /// <summary>
             /// ValidFromDate.
             /// </summary>
             /// <param name="validFromDate"> validFromDate. </param>
             /// <returns> Builder. </returns>
            public Builder ValidFromDate(string validFromDate)
            {
                this.validFromDate = validFromDate;
                return this;
            }

             /// <summary>
             /// ValidFromLocalTime.
             /// </summary>
             /// <param name="validFromLocalTime"> validFromLocalTime. </param>
             /// <returns> Builder. </returns>
            public Builder ValidFromLocalTime(string validFromLocalTime)
            {
                this.validFromLocalTime = validFromLocalTime;
                return this;
            }

             /// <summary>
             /// ValidUntilDate.
             /// </summary>
             /// <param name="validUntilDate"> validUntilDate. </param>
             /// <returns> Builder. </returns>
            public Builder ValidUntilDate(string validUntilDate)
            {
                this.validUntilDate = validUntilDate;
                return this;
            }

             /// <summary>
             /// ValidUntilLocalTime.
             /// </summary>
             /// <param name="validUntilLocalTime"> validUntilLocalTime. </param>
             /// <returns> Builder. </returns>
            public Builder ValidUntilLocalTime(string validUntilLocalTime)
            {
                this.validUntilLocalTime = validUntilLocalTime;
                return this;
            }

             /// <summary>
             /// ExcludeStrategy.
             /// </summary>
             /// <param name="excludeStrategy"> excludeStrategy. </param>
             /// <returns> Builder. </returns>
            public Builder ExcludeStrategy(string excludeStrategy)
            {
                this.excludeStrategy = excludeStrategy;
                return this;
            }

             /// <summary>
             /// CustomerGroupIdsAny.
             /// </summary>
             /// <param name="customerGroupIdsAny"> customerGroupIdsAny. </param>
             /// <returns> Builder. </returns>
            public Builder CustomerGroupIdsAny(IList<string> customerGroupIdsAny)
            {
                this.customerGroupIdsAny = customerGroupIdsAny;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogPricingRule. </returns>
            public CatalogPricingRule Build()
            {
                return new CatalogPricingRule(
                    this.name,
                    this.timePeriodIds,
                    this.discountId,
                    this.matchProductsId,
                    this.applyProductsId,
                    this.excludeProductsId,
                    this.validFromDate,
                    this.validFromLocalTime,
                    this.validUntilDate,
                    this.validUntilLocalTime,
                    this.excludeStrategy,
                    this.customerGroupIdsAny);
            }
        }
    }
}