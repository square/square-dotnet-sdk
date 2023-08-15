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
    /// CatalogPricingRule.
    /// </summary>
    public class CatalogPricingRule
    {
        private readonly Dictionary<string, bool> shouldSerialize;
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
        /// <param name="minimumOrderSubtotalMoney">minimum_order_subtotal_money.</param>
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
            Models.Money minimumOrderSubtotalMoney = null,
            IList<string> customerGroupIdsAny = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "name", false },
                { "time_period_ids", false },
                { "discount_id", false },
                { "match_products_id", false },
                { "apply_products_id", false },
                { "exclude_products_id", false },
                { "valid_from_date", false },
                { "valid_from_local_time", false },
                { "valid_until_date", false },
                { "valid_until_local_time", false },
                { "customer_group_ids_any", false }
            };

            if (name != null)
            {
                shouldSerialize["name"] = true;
                this.Name = name;
            }

            if (timePeriodIds != null)
            {
                shouldSerialize["time_period_ids"] = true;
                this.TimePeriodIds = timePeriodIds;
            }

            if (discountId != null)
            {
                shouldSerialize["discount_id"] = true;
                this.DiscountId = discountId;
            }

            if (matchProductsId != null)
            {
                shouldSerialize["match_products_id"] = true;
                this.MatchProductsId = matchProductsId;
            }

            if (applyProductsId != null)
            {
                shouldSerialize["apply_products_id"] = true;
                this.ApplyProductsId = applyProductsId;
            }

            if (excludeProductsId != null)
            {
                shouldSerialize["exclude_products_id"] = true;
                this.ExcludeProductsId = excludeProductsId;
            }

            if (validFromDate != null)
            {
                shouldSerialize["valid_from_date"] = true;
                this.ValidFromDate = validFromDate;
            }

            if (validFromLocalTime != null)
            {
                shouldSerialize["valid_from_local_time"] = true;
                this.ValidFromLocalTime = validFromLocalTime;
            }

            if (validUntilDate != null)
            {
                shouldSerialize["valid_until_date"] = true;
                this.ValidUntilDate = validUntilDate;
            }

            if (validUntilLocalTime != null)
            {
                shouldSerialize["valid_until_local_time"] = true;
                this.ValidUntilLocalTime = validUntilLocalTime;
            }

            this.ExcludeStrategy = excludeStrategy;
            this.MinimumOrderSubtotalMoney = minimumOrderSubtotalMoney;
            if (customerGroupIdsAny != null)
            {
                shouldSerialize["customer_group_ids_any"] = true;
                this.CustomerGroupIdsAny = customerGroupIdsAny;
            }

        }
        internal CatalogPricingRule(Dictionary<string, bool> shouldSerialize,
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
            Models.Money minimumOrderSubtotalMoney = null,
            IList<string> customerGroupIdsAny = null)
        {
            this.shouldSerialize = shouldSerialize;
            Name = name;
            TimePeriodIds = timePeriodIds;
            DiscountId = discountId;
            MatchProductsId = matchProductsId;
            ApplyProductsId = applyProductsId;
            ExcludeProductsId = excludeProductsId;
            ValidFromDate = validFromDate;
            ValidFromLocalTime = validFromLocalTime;
            ValidUntilDate = validUntilDate;
            ValidUntilLocalTime = validUntilLocalTime;
            ExcludeStrategy = excludeStrategy;
            MinimumOrderSubtotalMoney = minimumOrderSubtotalMoney;
            CustomerGroupIdsAny = customerGroupIdsAny;
        }

        /// <summary>
        /// User-defined name for the pricing rule. For example, "Buy one get one
        /// free" or "10% off".
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// A list of unique IDs for the catalog time periods when
        /// this pricing rule is in effect. If left unset, the pricing rule is always
        /// in effect.
        /// </summary>
        [JsonProperty("time_period_ids")]
        public IList<string> TimePeriodIds { get; }

        /// <summary>
        /// Unique ID for the `CatalogDiscount` to take off
        /// the price of all matched items.
        /// </summary>
        [JsonProperty("discount_id")]
        public string DiscountId { get; }

        /// <summary>
        /// Unique ID for the `CatalogProductSet` that will be matched by this rule. A match rule
        /// matches within the entire cart, and can match multiple times. This field will always be set.
        /// </summary>
        [JsonProperty("match_products_id")]
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
        [JsonProperty("apply_products_id")]
        public string ApplyProductsId { get; }

        /// <summary>
        /// `CatalogProductSet` to exclude from the pricing rule.
        /// An exclude rule matches within the subset of the cart that fits the match rules (the match set).
        /// An exclude rule can only match once in the match set.
        /// If not supplied, the pricing will be applied to all products in the match set.
        /// Other products retain their base price, or a price generated by other rules.
        /// </summary>
        [JsonProperty("exclude_products_id")]
        public string ExcludeProductsId { get; }

        /// <summary>
        /// Represents the date the Pricing Rule is valid from. Represented in RFC 3339 full-date format (YYYY-MM-DD).
        /// </summary>
        [JsonProperty("valid_from_date")]
        public string ValidFromDate { get; }

        /// <summary>
        /// Represents the local time the pricing rule should be valid from. Represented in RFC 3339 partial-time format
        /// (HH:MM:SS). Partial seconds will be truncated.
        /// </summary>
        [JsonProperty("valid_from_local_time")]
        public string ValidFromLocalTime { get; }

        /// <summary>
        /// Represents the date the Pricing Rule is valid until. Represented in RFC 3339 full-date format (YYYY-MM-DD).
        /// </summary>
        [JsonProperty("valid_until_date")]
        public string ValidUntilDate { get; }

        /// <summary>
        /// Represents the local time the pricing rule should be valid until. Represented in RFC 3339 partial-time format
        /// (HH:MM:SS). Partial seconds will be truncated.
        /// </summary>
        [JsonProperty("valid_until_local_time")]
        public string ValidUntilLocalTime { get; }

        /// <summary>
        /// Indicates which products matched by a CatalogPricingRule
        /// will be excluded if the pricing rule uses an exclude set.
        /// </summary>
        [JsonProperty("exclude_strategy", NullValueHandling = NullValueHandling.Ignore)]
        public string ExcludeStrategy { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("minimum_order_subtotal_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money MinimumOrderSubtotalMoney { get; }

        /// <summary>
        /// A list of IDs of customer groups, the members of which are eligible for discounts specified in this pricing rule.
        /// Notice that a group ID is generated by the Customers API.
        /// If this field is not set, the specified discount applies to matched products sold to anyone whether the buyer
        /// has a customer profile created or not. If this `customer_group_ids_any` field is set, the specified discount
        /// applies only to matched products sold to customers belonging to the specified customer groups.
        /// </summary>
        [JsonProperty("customer_group_ids_any")]
        public IList<string> CustomerGroupIdsAny { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogPricingRule : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeName()
        {
            return this.shouldSerialize["name"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTimePeriodIds()
        {
            return this.shouldSerialize["time_period_ids"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDiscountId()
        {
            return this.shouldSerialize["discount_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMatchProductsId()
        {
            return this.shouldSerialize["match_products_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeApplyProductsId()
        {
            return this.shouldSerialize["apply_products_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeExcludeProductsId()
        {
            return this.shouldSerialize["exclude_products_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeValidFromDate()
        {
            return this.shouldSerialize["valid_from_date"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeValidFromLocalTime()
        {
            return this.shouldSerialize["valid_from_local_time"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeValidUntilDate()
        {
            return this.shouldSerialize["valid_until_date"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeValidUntilLocalTime()
        {
            return this.shouldSerialize["valid_until_local_time"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCustomerGroupIdsAny()
        {
            return this.shouldSerialize["customer_group_ids_any"];
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
            return obj is CatalogPricingRule other &&                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
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
                ((this.MinimumOrderSubtotalMoney == null && other.MinimumOrderSubtotalMoney == null) || (this.MinimumOrderSubtotalMoney?.Equals(other.MinimumOrderSubtotalMoney) == true)) &&
                ((this.CustomerGroupIdsAny == null && other.CustomerGroupIdsAny == null) || (this.CustomerGroupIdsAny?.Equals(other.CustomerGroupIdsAny) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1599740416;
            hashCode = HashCode.Combine(this.Name, this.TimePeriodIds, this.DiscountId, this.MatchProductsId, this.ApplyProductsId, this.ExcludeProductsId, this.ValidFromDate);

            hashCode = HashCode.Combine(hashCode, this.ValidFromLocalTime, this.ValidUntilDate, this.ValidUntilLocalTime, this.ExcludeStrategy, this.MinimumOrderSubtotalMoney, this.CustomerGroupIdsAny);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name)}");
            toStringOutput.Add($"this.TimePeriodIds = {(this.TimePeriodIds == null ? "null" : $"[{string.Join(", ", this.TimePeriodIds)} ]")}");
            toStringOutput.Add($"this.DiscountId = {(this.DiscountId == null ? "null" : this.DiscountId)}");
            toStringOutput.Add($"this.MatchProductsId = {(this.MatchProductsId == null ? "null" : this.MatchProductsId)}");
            toStringOutput.Add($"this.ApplyProductsId = {(this.ApplyProductsId == null ? "null" : this.ApplyProductsId)}");
            toStringOutput.Add($"this.ExcludeProductsId = {(this.ExcludeProductsId == null ? "null" : this.ExcludeProductsId)}");
            toStringOutput.Add($"this.ValidFromDate = {(this.ValidFromDate == null ? "null" : this.ValidFromDate)}");
            toStringOutput.Add($"this.ValidFromLocalTime = {(this.ValidFromLocalTime == null ? "null" : this.ValidFromLocalTime)}");
            toStringOutput.Add($"this.ValidUntilDate = {(this.ValidUntilDate == null ? "null" : this.ValidUntilDate)}");
            toStringOutput.Add($"this.ValidUntilLocalTime = {(this.ValidUntilLocalTime == null ? "null" : this.ValidUntilLocalTime)}");
            toStringOutput.Add($"this.ExcludeStrategy = {(this.ExcludeStrategy == null ? "null" : this.ExcludeStrategy.ToString())}");
            toStringOutput.Add($"this.MinimumOrderSubtotalMoney = {(this.MinimumOrderSubtotalMoney == null ? "null" : this.MinimumOrderSubtotalMoney.ToString())}");
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
                .MinimumOrderSubtotalMoney(this.MinimumOrderSubtotalMoney)
                .CustomerGroupIdsAny(this.CustomerGroupIdsAny);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "name", false },
                { "time_period_ids", false },
                { "discount_id", false },
                { "match_products_id", false },
                { "apply_products_id", false },
                { "exclude_products_id", false },
                { "valid_from_date", false },
                { "valid_from_local_time", false },
                { "valid_until_date", false },
                { "valid_until_local_time", false },
                { "customer_group_ids_any", false },
            };

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
            private Models.Money minimumOrderSubtotalMoney;
            private IList<string> customerGroupIdsAny;

             /// <summary>
             /// Name.
             /// </summary>
             /// <param name="name"> name. </param>
             /// <returns> Builder. </returns>
            public Builder Name(string name)
            {
                shouldSerialize["name"] = true;
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
                shouldSerialize["time_period_ids"] = true;
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
                shouldSerialize["discount_id"] = true;
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
                shouldSerialize["match_products_id"] = true;
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
                shouldSerialize["apply_products_id"] = true;
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
                shouldSerialize["exclude_products_id"] = true;
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
                shouldSerialize["valid_from_date"] = true;
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
                shouldSerialize["valid_from_local_time"] = true;
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
                shouldSerialize["valid_until_date"] = true;
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
                shouldSerialize["valid_until_local_time"] = true;
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
             /// MinimumOrderSubtotalMoney.
             /// </summary>
             /// <param name="minimumOrderSubtotalMoney"> minimumOrderSubtotalMoney. </param>
             /// <returns> Builder. </returns>
            public Builder MinimumOrderSubtotalMoney(Models.Money minimumOrderSubtotalMoney)
            {
                this.minimumOrderSubtotalMoney = minimumOrderSubtotalMoney;
                return this;
            }

             /// <summary>
             /// CustomerGroupIdsAny.
             /// </summary>
             /// <param name="customerGroupIdsAny"> customerGroupIdsAny. </param>
             /// <returns> Builder. </returns>
            public Builder CustomerGroupIdsAny(IList<string> customerGroupIdsAny)
            {
                shouldSerialize["customer_group_ids_any"] = true;
                this.customerGroupIdsAny = customerGroupIdsAny;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetName()
            {
                this.shouldSerialize["name"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetTimePeriodIds()
            {
                this.shouldSerialize["time_period_ids"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetDiscountId()
            {
                this.shouldSerialize["discount_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetMatchProductsId()
            {
                this.shouldSerialize["match_products_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetApplyProductsId()
            {
                this.shouldSerialize["apply_products_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetExcludeProductsId()
            {
                this.shouldSerialize["exclude_products_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetValidFromDate()
            {
                this.shouldSerialize["valid_from_date"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetValidFromLocalTime()
            {
                this.shouldSerialize["valid_from_local_time"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetValidUntilDate()
            {
                this.shouldSerialize["valid_until_date"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetValidUntilLocalTime()
            {
                this.shouldSerialize["valid_until_local_time"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCustomerGroupIdsAny()
            {
                this.shouldSerialize["customer_group_ids_any"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogPricingRule. </returns>
            public CatalogPricingRule Build()
            {
                return new CatalogPricingRule(shouldSerialize,
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
                    this.minimumOrderSubtotalMoney,
                    this.customerGroupIdsAny);
            }
        }
    }
}