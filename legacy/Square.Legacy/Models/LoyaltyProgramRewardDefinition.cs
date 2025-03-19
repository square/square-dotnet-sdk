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
using Square.Legacy;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// LoyaltyProgramRewardDefinition.
    /// </summary>
    public class LoyaltyProgramRewardDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoyaltyProgramRewardDefinition"/> class.
        /// </summary>
        /// <param name="scope">scope.</param>
        /// <param name="discountType">discount_type.</param>
        /// <param name="percentageDiscount">percentage_discount.</param>
        /// <param name="catalogObjectIds">catalog_object_ids.</param>
        /// <param name="fixedDiscountMoney">fixed_discount_money.</param>
        /// <param name="maxDiscountMoney">max_discount_money.</param>
        public LoyaltyProgramRewardDefinition(
            string scope,
            string discountType,
            string percentageDiscount = null,
            IList<string> catalogObjectIds = null,
            Models.Money fixedDiscountMoney = null,
            Models.Money maxDiscountMoney = null
        )
        {
            this.Scope = scope;
            this.DiscountType = discountType;
            this.PercentageDiscount = percentageDiscount;
            this.CatalogObjectIds = catalogObjectIds;
            this.FixedDiscountMoney = fixedDiscountMoney;
            this.MaxDiscountMoney = maxDiscountMoney;
        }

        /// <summary>
        /// Indicates the scope of the reward tier. DEPRECATED at version 2020-12-16. Discount details
        /// are now defined using a catalog pricing rule and other catalog objects. For more information, see
        /// [Getting discount details for a reward tier](https://developer.squareup.com/docs/loyalty-api/loyalty-rewards#get-discount-details).
        /// </summary>
        [JsonProperty("scope")]
        public string Scope { get; }

        /// <summary>
        /// The type of discount the reward tier offers. DEPRECATED at version 2020-12-16. Discount details
        /// are now defined using a catalog pricing rule and other catalog objects. For more information, see
        /// [Getting discount details for a reward tier](https://developer.squareup.com/docs/loyalty-api/loyalty-rewards#get-discount-details).
        /// </summary>
        [JsonProperty("discount_type")]
        public string DiscountType { get; }

        /// <summary>
        /// The fixed percentage of the discount. Present if `discount_type` is `FIXED_PERCENTAGE`.
        /// For example, a 7.25% off discount will be represented as "7.25". DEPRECATED at version 2020-12-16. You can find this
        /// information in the `discount_data.percentage` field of the `DISCOUNT` catalog object referenced by the pricing rule.
        /// </summary>
        [JsonProperty("percentage_discount", NullValueHandling = NullValueHandling.Ignore)]
        public string PercentageDiscount { get; }

        /// <summary>
        /// The list of catalog objects to which this reward can be applied. They are either all item-variation ids or category ids, depending on the `type` field.
        /// DEPRECATED at version 2020-12-16. You can find this information in the `product_set_data.product_ids_any` field
        /// of the `PRODUCT_SET` catalog object referenced by the pricing rule.
        /// </summary>
        [JsonProperty("catalog_object_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> CatalogObjectIds { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("fixed_discount_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money FixedDiscountMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("max_discount_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money MaxDiscountMoney { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"LoyaltyProgramRewardDefinition : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is LoyaltyProgramRewardDefinition other
                && (
                    this.Scope == null && other.Scope == null
                    || this.Scope?.Equals(other.Scope) == true
                )
                && (
                    this.DiscountType == null && other.DiscountType == null
                    || this.DiscountType?.Equals(other.DiscountType) == true
                )
                && (
                    this.PercentageDiscount == null && other.PercentageDiscount == null
                    || this.PercentageDiscount?.Equals(other.PercentageDiscount) == true
                )
                && (
                    this.CatalogObjectIds == null && other.CatalogObjectIds == null
                    || this.CatalogObjectIds?.Equals(other.CatalogObjectIds) == true
                )
                && (
                    this.FixedDiscountMoney == null && other.FixedDiscountMoney == null
                    || this.FixedDiscountMoney?.Equals(other.FixedDiscountMoney) == true
                )
                && (
                    this.MaxDiscountMoney == null && other.MaxDiscountMoney == null
                    || this.MaxDiscountMoney?.Equals(other.MaxDiscountMoney) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1536175793;
            hashCode = HashCode.Combine(
                hashCode,
                this.Scope,
                this.DiscountType,
                this.PercentageDiscount,
                this.CatalogObjectIds,
                this.FixedDiscountMoney,
                this.MaxDiscountMoney
            );

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add(
                $"this.Scope = {(this.Scope == null ? "null" : this.Scope.ToString())}"
            );
            toStringOutput.Add(
                $"this.DiscountType = {(this.DiscountType == null ? "null" : this.DiscountType.ToString())}"
            );
            toStringOutput.Add($"this.PercentageDiscount = {this.PercentageDiscount ?? "null"}");
            toStringOutput.Add(
                $"this.CatalogObjectIds = {(this.CatalogObjectIds == null ? "null" : $"[{string.Join(", ", this.CatalogObjectIds)} ]")}"
            );
            toStringOutput.Add(
                $"this.FixedDiscountMoney = {(this.FixedDiscountMoney == null ? "null" : this.FixedDiscountMoney.ToString())}"
            );
            toStringOutput.Add(
                $"this.MaxDiscountMoney = {(this.MaxDiscountMoney == null ? "null" : this.MaxDiscountMoney.ToString())}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(this.Scope, this.DiscountType)
                .PercentageDiscount(this.PercentageDiscount)
                .CatalogObjectIds(this.CatalogObjectIds)
                .FixedDiscountMoney(this.FixedDiscountMoney)
                .MaxDiscountMoney(this.MaxDiscountMoney);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string scope;
            private string discountType;
            private string percentageDiscount;
            private IList<string> catalogObjectIds;
            private Models.Money fixedDiscountMoney;
            private Models.Money maxDiscountMoney;

            /// <summary>
            /// Initialize Builder for LoyaltyProgramRewardDefinition.
            /// </summary>
            /// <param name="scope"> scope. </param>
            /// <param name="discountType"> discountType. </param>
            public Builder(string scope, string discountType)
            {
                this.scope = scope;
                this.discountType = discountType;
            }

            /// <summary>
            /// Scope.
            /// </summary>
            /// <param name="scope"> scope. </param>
            /// <returns> Builder. </returns>
            public Builder Scope(string scope)
            {
                this.scope = scope;
                return this;
            }

            /// <summary>
            /// DiscountType.
            /// </summary>
            /// <param name="discountType"> discountType. </param>
            /// <returns> Builder. </returns>
            public Builder DiscountType(string discountType)
            {
                this.discountType = discountType;
                return this;
            }

            /// <summary>
            /// PercentageDiscount.
            /// </summary>
            /// <param name="percentageDiscount"> percentageDiscount. </param>
            /// <returns> Builder. </returns>
            public Builder PercentageDiscount(string percentageDiscount)
            {
                this.percentageDiscount = percentageDiscount;
                return this;
            }

            /// <summary>
            /// CatalogObjectIds.
            /// </summary>
            /// <param name="catalogObjectIds"> catalogObjectIds. </param>
            /// <returns> Builder. </returns>
            public Builder CatalogObjectIds(IList<string> catalogObjectIds)
            {
                this.catalogObjectIds = catalogObjectIds;
                return this;
            }

            /// <summary>
            /// FixedDiscountMoney.
            /// </summary>
            /// <param name="fixedDiscountMoney"> fixedDiscountMoney. </param>
            /// <returns> Builder. </returns>
            public Builder FixedDiscountMoney(Models.Money fixedDiscountMoney)
            {
                this.fixedDiscountMoney = fixedDiscountMoney;
                return this;
            }

            /// <summary>
            /// MaxDiscountMoney.
            /// </summary>
            /// <param name="maxDiscountMoney"> maxDiscountMoney. </param>
            /// <returns> Builder. </returns>
            public Builder MaxDiscountMoney(Models.Money maxDiscountMoney)
            {
                this.maxDiscountMoney = maxDiscountMoney;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> LoyaltyProgramRewardDefinition. </returns>
            public LoyaltyProgramRewardDefinition Build()
            {
                return new LoyaltyProgramRewardDefinition(
                    this.scope,
                    this.discountType,
                    this.percentageDiscount,
                    this.catalogObjectIds,
                    this.fixedDiscountMoney,
                    this.maxDiscountMoney
                );
            }
        }
    }
}
