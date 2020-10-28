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
        /// Indicates the scope of the reward tier.
        /// </summary>
        [JsonProperty("scope")]
        public string Scope { get; }

        /// <summary>
        /// The type of discount the reward tier offers.
        /// </summary>
        [JsonProperty("discount_type")]
        public string DiscountType { get; }

        /// <summary>
        /// Present if `discount_type` is `FIXED_PERCENTAGE`.
        /// For example, a 7.25% off discount will be represented as "7.25".
        /// </summary>
        [JsonProperty("percentage_discount", NullValueHandling = NullValueHandling.Ignore)]
        public string PercentageDiscount { get; }

        /// <summary>
        /// A list of [catalog object](#type-CatalogObject) ids to which this reward can be applied. They are either all item-variation ids or category ids, depending on the `type` field.
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