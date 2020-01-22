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
    public class OrderReturnLineItemModifier 
    {
        public OrderReturnLineItemModifier(string uid = null,
            string sourceModifierUid = null,
            string catalogObjectId = null,
            string name = null,
            Models.Money basePriceMoney = null,
            Models.Money totalPriceMoney = null)
        {
            Uid = uid;
            SourceModifierUid = sourceModifierUid;
            CatalogObjectId = catalogObjectId;
            Name = name;
            BasePriceMoney = basePriceMoney;
            TotalPriceMoney = totalPriceMoney;
        }

        /// <summary>
        /// Unique ID that identifies the return modifier only within this order.
        /// </summary>
        [JsonProperty("uid")]
        public string Uid { get; }

        /// <summary>
        /// `uid` of the Modifier from the LineItem from the Order which contains the
        /// original sale of this line item modifier.
        /// </summary>
        [JsonProperty("source_modifier_uid")]
        public string SourceModifierUid { get; }

        /// <summary>
        /// The catalog object id referencing [CatalogModifier](#type-catalogmodifier).
        /// </summary>
        [JsonProperty("catalog_object_id")]
        public string CatalogObjectId { get; }

        /// <summary>
        /// The name of the item modifier.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("base_price_money")]
        public Models.Money BasePriceMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("total_price_money")]
        public Models.Money TotalPriceMoney { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Uid(Uid)
                .SourceModifierUid(SourceModifierUid)
                .CatalogObjectId(CatalogObjectId)
                .Name(Name)
                .BasePriceMoney(BasePriceMoney)
                .TotalPriceMoney(TotalPriceMoney);
            return builder;
        }

        public class Builder
        {
            private string uid;
            private string sourceModifierUid;
            private string catalogObjectId;
            private string name;
            private Models.Money basePriceMoney;
            private Models.Money totalPriceMoney;

            public Builder() { }
            public Builder Uid(string value)
            {
                uid = value;
                return this;
            }

            public Builder SourceModifierUid(string value)
            {
                sourceModifierUid = value;
                return this;
            }

            public Builder CatalogObjectId(string value)
            {
                catalogObjectId = value;
                return this;
            }

            public Builder Name(string value)
            {
                name = value;
                return this;
            }

            public Builder BasePriceMoney(Models.Money value)
            {
                basePriceMoney = value;
                return this;
            }

            public Builder TotalPriceMoney(Models.Money value)
            {
                totalPriceMoney = value;
                return this;
            }

            public OrderReturnLineItemModifier Build()
            {
                return new OrderReturnLineItemModifier(uid,
                    sourceModifierUid,
                    catalogObjectId,
                    name,
                    basePriceMoney,
                    totalPriceMoney);
            }
        }
    }
}