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
    public class LoyaltyProgramAccrualRule 
    {
        public LoyaltyProgramAccrualRule(string accrualType,
            int? points = null,
            Models.Money visitMinimumAmountMoney = null,
            Models.Money spendAmountMoney = null,
            string catalogObjectId = null)
        {
            AccrualType = accrualType;
            Points = points;
            VisitMinimumAmountMoney = visitMinimumAmountMoney;
            SpendAmountMoney = spendAmountMoney;
            CatalogObjectId = catalogObjectId;
        }

        /// <summary>
        /// The type of the accrual rule that defines how buyers can earn points.
        /// </summary>
        [JsonProperty("accrual_type")]
        public string AccrualType { get; }

        /// <summary>
        /// The number of points that 
        /// buyers earn based on the `accrual_type`.
        /// </summary>
        [JsonProperty("points")]
        public int? Points { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("visit_minimum_amount_money")]
        public Models.Money VisitMinimumAmountMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("spend_amount_money")]
        public Models.Money SpendAmountMoney { get; }

        /// <summary>
        /// The ID of the [catalog object](#type-CatalogObject) to purchase to earn the number of points defined by the
        /// rule. This is either an item variation or a category, depending on the type. This is defined on
        /// `ITEM_VARIATION` rules and `CATEGORY` rules.
        /// </summary>
        [JsonProperty("catalog_object_id")]
        public string CatalogObjectId { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(AccrualType)
                .Points(Points)
                .VisitMinimumAmountMoney(VisitMinimumAmountMoney)
                .SpendAmountMoney(SpendAmountMoney)
                .CatalogObjectId(CatalogObjectId);
            return builder;
        }

        public class Builder
        {
            private string accrualType;
            private int? points;
            private Models.Money visitMinimumAmountMoney;
            private Models.Money spendAmountMoney;
            private string catalogObjectId;

            public Builder(string accrualType)
            {
                this.accrualType = accrualType;
            }
            public Builder AccrualType(string value)
            {
                accrualType = value;
                return this;
            }

            public Builder Points(int? value)
            {
                points = value;
                return this;
            }

            public Builder VisitMinimumAmountMoney(Models.Money value)
            {
                visitMinimumAmountMoney = value;
                return this;
            }

            public Builder SpendAmountMoney(Models.Money value)
            {
                spendAmountMoney = value;
                return this;
            }

            public Builder CatalogObjectId(string value)
            {
                catalogObjectId = value;
                return this;
            }

            public LoyaltyProgramAccrualRule Build()
            {
                return new LoyaltyProgramAccrualRule(accrualType,
                    points,
                    visitMinimumAmountMoney,
                    spendAmountMoney,
                    catalogObjectId);
            }
        }
    }
}