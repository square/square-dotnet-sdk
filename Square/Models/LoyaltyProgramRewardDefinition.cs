
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
    public class LoyaltyProgramRewardDefinition 
    {
        public LoyaltyProgramRewardDefinition(string scope,
            string discountType,
            string percentageDiscount = null,
            IList<string> catalogObjectIds = null,
            Models.Money fixedDiscountMoney = null,
            Models.Money maxDiscountMoney = null)
        {
            Scope = scope;
            DiscountType = discountType;
            PercentageDiscount = percentageDiscount;
            CatalogObjectIds = catalogObjectIds;
            FixedDiscountMoney = fixedDiscountMoney;
            MaxDiscountMoney = maxDiscountMoney;
        }

        /// <summary>
        /// Indicates the scope of the reward tier. DEPRECATED at version 2020-12-16. Discount details
        /// are now defined using a catalog pricing rule and other catalog objects. For more information, see
        /// [Get discount details for the reward](https://developer.squareup.com/docs/loyalty-api/overview#get-discount-details).
        /// </summary>
        [JsonProperty("scope")]
        public string Scope { get; }

        /// <summary>
        /// The type of discount the reward tier offers. DEPRECATED at version 2020-12-16. Discount details
        /// are now defined using a catalog pricing rule and other catalog objects. For more information, see
        /// [Get discount details for the reward](https://developer.squareup.com/docs/loyalty-api/overview#get-discount-details).
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LoyaltyProgramRewardDefinition : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Scope = {(Scope == null ? "null" : Scope.ToString())}");
            toStringOutput.Add($"DiscountType = {(DiscountType == null ? "null" : DiscountType.ToString())}");
            toStringOutput.Add($"PercentageDiscount = {(PercentageDiscount == null ? "null" : PercentageDiscount == string.Empty ? "" : PercentageDiscount)}");
            toStringOutput.Add($"CatalogObjectIds = {(CatalogObjectIds == null ? "null" : $"[{ string.Join(", ", CatalogObjectIds)} ]")}");
            toStringOutput.Add($"FixedDiscountMoney = {(FixedDiscountMoney == null ? "null" : FixedDiscountMoney.ToString())}");
            toStringOutput.Add($"MaxDiscountMoney = {(MaxDiscountMoney == null ? "null" : MaxDiscountMoney.ToString())}");
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

            return obj is LoyaltyProgramRewardDefinition other &&
                ((Scope == null && other.Scope == null) || (Scope?.Equals(other.Scope) == true)) &&
                ((DiscountType == null && other.DiscountType == null) || (DiscountType?.Equals(other.DiscountType) == true)) &&
                ((PercentageDiscount == null && other.PercentageDiscount == null) || (PercentageDiscount?.Equals(other.PercentageDiscount) == true)) &&
                ((CatalogObjectIds == null && other.CatalogObjectIds == null) || (CatalogObjectIds?.Equals(other.CatalogObjectIds) == true)) &&
                ((FixedDiscountMoney == null && other.FixedDiscountMoney == null) || (FixedDiscountMoney?.Equals(other.FixedDiscountMoney) == true)) &&
                ((MaxDiscountMoney == null && other.MaxDiscountMoney == null) || (MaxDiscountMoney?.Equals(other.MaxDiscountMoney) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1536175793;

            if (Scope != null)
            {
               hashCode += Scope.GetHashCode();
            }

            if (DiscountType != null)
            {
               hashCode += DiscountType.GetHashCode();
            }

            if (PercentageDiscount != null)
            {
               hashCode += PercentageDiscount.GetHashCode();
            }

            if (CatalogObjectIds != null)
            {
               hashCode += CatalogObjectIds.GetHashCode();
            }

            if (FixedDiscountMoney != null)
            {
               hashCode += FixedDiscountMoney.GetHashCode();
            }

            if (MaxDiscountMoney != null)
            {
               hashCode += MaxDiscountMoney.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(Scope,
                DiscountType)
                .PercentageDiscount(PercentageDiscount)
                .CatalogObjectIds(CatalogObjectIds)
                .FixedDiscountMoney(FixedDiscountMoney)
                .MaxDiscountMoney(MaxDiscountMoney);
            return builder;
        }

        public class Builder
        {
            private string scope;
            private string discountType;
            private string percentageDiscount;
            private IList<string> catalogObjectIds;
            private Models.Money fixedDiscountMoney;
            private Models.Money maxDiscountMoney;

            public Builder(string scope,
                string discountType)
            {
                this.scope = scope;
                this.discountType = discountType;
            }

            public Builder Scope(string scope)
            {
                this.scope = scope;
                return this;
            }

            public Builder DiscountType(string discountType)
            {
                this.discountType = discountType;
                return this;
            }

            public Builder PercentageDiscount(string percentageDiscount)
            {
                this.percentageDiscount = percentageDiscount;
                return this;
            }

            public Builder CatalogObjectIds(IList<string> catalogObjectIds)
            {
                this.catalogObjectIds = catalogObjectIds;
                return this;
            }

            public Builder FixedDiscountMoney(Models.Money fixedDiscountMoney)
            {
                this.fixedDiscountMoney = fixedDiscountMoney;
                return this;
            }

            public Builder MaxDiscountMoney(Models.Money maxDiscountMoney)
            {
                this.maxDiscountMoney = maxDiscountMoney;
                return this;
            }

            public LoyaltyProgramRewardDefinition Build()
            {
                return new LoyaltyProgramRewardDefinition(scope,
                    discountType,
                    percentageDiscount,
                    catalogObjectIds,
                    fixedDiscountMoney,
                    maxDiscountMoney);
            }
        }
    }
}