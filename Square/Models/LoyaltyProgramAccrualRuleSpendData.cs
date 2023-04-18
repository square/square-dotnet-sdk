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
    /// LoyaltyProgramAccrualRuleSpendData.
    /// </summary>
    public class LoyaltyProgramAccrualRuleSpendData
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="LoyaltyProgramAccrualRuleSpendData"/> class.
        /// </summary>
        /// <param name="amountMoney">amount_money.</param>
        /// <param name="taxMode">tax_mode.</param>
        /// <param name="excludedCategoryIds">excluded_category_ids.</param>
        /// <param name="excludedItemVariationIds">excluded_item_variation_ids.</param>
        public LoyaltyProgramAccrualRuleSpendData(
            Models.Money amountMoney,
            string taxMode,
            IList<string> excludedCategoryIds = null,
            IList<string> excludedItemVariationIds = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "excluded_category_ids", false },
                { "excluded_item_variation_ids", false }
            };

            this.AmountMoney = amountMoney;
            if (excludedCategoryIds != null)
            {
                shouldSerialize["excluded_category_ids"] = true;
                this.ExcludedCategoryIds = excludedCategoryIds;
            }

            if (excludedItemVariationIds != null)
            {
                shouldSerialize["excluded_item_variation_ids"] = true;
                this.ExcludedItemVariationIds = excludedItemVariationIds;
            }

            this.TaxMode = taxMode;
        }
        internal LoyaltyProgramAccrualRuleSpendData(Dictionary<string, bool> shouldSerialize,
            Models.Money amountMoney,
            string taxMode,
            IList<string> excludedCategoryIds = null,
            IList<string> excludedItemVariationIds = null)
        {
            this.shouldSerialize = shouldSerialize;
            AmountMoney = amountMoney;
            ExcludedCategoryIds = excludedCategoryIds;
            ExcludedItemVariationIds = excludedItemVariationIds;
            TaxMode = taxMode;
        }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("amount_money")]
        public Models.Money AmountMoney { get; }

        /// <summary>
        /// The IDs of any `CATEGORY` catalog objects that are excluded from points accrual.
        /// You can use the [BatchRetrieveCatalogObjects](api-endpoint:Catalog-BatchRetrieveCatalogObjects)
        /// endpoint to retrieve information about the excluded categories.
        /// </summary>
        [JsonProperty("excluded_category_ids")]
        public IList<string> ExcludedCategoryIds { get; }

        /// <summary>
        /// The IDs of any `ITEM_VARIATION` catalog objects that are excluded from points accrual.
        /// You can use the [BatchRetrieveCatalogObjects](api-endpoint:Catalog-BatchRetrieveCatalogObjects)
        /// endpoint to retrieve information about the excluded item variations.
        /// </summary>
        [JsonProperty("excluded_item_variation_ids")]
        public IList<string> ExcludedItemVariationIds { get; }

        /// <summary>
        /// Indicates how taxes should be treated when calculating the purchase amount used for loyalty points accrual.
        /// This setting applies only to `SPEND` accrual rules or `VISIT` accrual rules that have a minimum spend requirement.
        /// </summary>
        [JsonProperty("tax_mode")]
        public string TaxMode { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LoyaltyProgramAccrualRuleSpendData : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeExcludedCategoryIds()
        {
            return this.shouldSerialize["excluded_category_ids"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeExcludedItemVariationIds()
        {
            return this.shouldSerialize["excluded_item_variation_ids"];
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

            return obj is LoyaltyProgramAccrualRuleSpendData other &&
                ((this.AmountMoney == null && other.AmountMoney == null) || (this.AmountMoney?.Equals(other.AmountMoney) == true)) &&
                ((this.ExcludedCategoryIds == null && other.ExcludedCategoryIds == null) || (this.ExcludedCategoryIds?.Equals(other.ExcludedCategoryIds) == true)) &&
                ((this.ExcludedItemVariationIds == null && other.ExcludedItemVariationIds == null) || (this.ExcludedItemVariationIds?.Equals(other.ExcludedItemVariationIds) == true)) &&
                ((this.TaxMode == null && other.TaxMode == null) || (this.TaxMode?.Equals(other.TaxMode) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1684104925;
            hashCode = HashCode.Combine(this.AmountMoney, this.ExcludedCategoryIds, this.ExcludedItemVariationIds, this.TaxMode);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.AmountMoney = {(this.AmountMoney == null ? "null" : this.AmountMoney.ToString())}");
            toStringOutput.Add($"this.ExcludedCategoryIds = {(this.ExcludedCategoryIds == null ? "null" : $"[{string.Join(", ", this.ExcludedCategoryIds)} ]")}");
            toStringOutput.Add($"this.ExcludedItemVariationIds = {(this.ExcludedItemVariationIds == null ? "null" : $"[{string.Join(", ", this.ExcludedItemVariationIds)} ]")}");
            toStringOutput.Add($"this.TaxMode = {(this.TaxMode == null ? "null" : this.TaxMode.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.AmountMoney,
                this.TaxMode)
                .ExcludedCategoryIds(this.ExcludedCategoryIds)
                .ExcludedItemVariationIds(this.ExcludedItemVariationIds);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "excluded_category_ids", false },
                { "excluded_item_variation_ids", false },
            };

            private Models.Money amountMoney;
            private string taxMode;
            private IList<string> excludedCategoryIds;
            private IList<string> excludedItemVariationIds;

            public Builder(
                Models.Money amountMoney,
                string taxMode)
            {
                this.amountMoney = amountMoney;
                this.taxMode = taxMode;
            }

             /// <summary>
             /// AmountMoney.
             /// </summary>
             /// <param name="amountMoney"> amountMoney. </param>
             /// <returns> Builder. </returns>
            public Builder AmountMoney(Models.Money amountMoney)
            {
                this.amountMoney = amountMoney;
                return this;
            }

             /// <summary>
             /// TaxMode.
             /// </summary>
             /// <param name="taxMode"> taxMode. </param>
             /// <returns> Builder. </returns>
            public Builder TaxMode(string taxMode)
            {
                this.taxMode = taxMode;
                return this;
            }

             /// <summary>
             /// ExcludedCategoryIds.
             /// </summary>
             /// <param name="excludedCategoryIds"> excludedCategoryIds. </param>
             /// <returns> Builder. </returns>
            public Builder ExcludedCategoryIds(IList<string> excludedCategoryIds)
            {
                shouldSerialize["excluded_category_ids"] = true;
                this.excludedCategoryIds = excludedCategoryIds;
                return this;
            }

             /// <summary>
             /// ExcludedItemVariationIds.
             /// </summary>
             /// <param name="excludedItemVariationIds"> excludedItemVariationIds. </param>
             /// <returns> Builder. </returns>
            public Builder ExcludedItemVariationIds(IList<string> excludedItemVariationIds)
            {
                shouldSerialize["excluded_item_variation_ids"] = true;
                this.excludedItemVariationIds = excludedItemVariationIds;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetExcludedCategoryIds()
            {
                this.shouldSerialize["excluded_category_ids"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetExcludedItemVariationIds()
            {
                this.shouldSerialize["excluded_item_variation_ids"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> LoyaltyProgramAccrualRuleSpendData. </returns>
            public LoyaltyProgramAccrualRuleSpendData Build()
            {
                return new LoyaltyProgramAccrualRuleSpendData(shouldSerialize,
                    this.amountMoney,
                    this.taxMode,
                    this.excludedCategoryIds,
                    this.excludedItemVariationIds);
            }
        }
    }
}