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
    public class CreateOrderRequestModifier 
    {
        public CreateOrderRequestModifier(string catalogObjectId = null,
            string name = null,
            Models.Money basePriceMoney = null)
        {
            CatalogObjectId = catalogObjectId;
            Name = name;
            BasePriceMoney = basePriceMoney;
        }

        /// <summary>
        /// The catalog object ID of a [CatalogModifier](#type-catalogmodifier).
        /// </summary>
        [JsonProperty("catalog_object_id")]
        public string CatalogObjectId { get; }

        /// <summary>
        /// Only used for ad hoc modifiers. The name of the modifier. `name` cannot exceed 255 characters.
        /// Do not provide a value for `name` if you provide a value for `catalog_object_id`.
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

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .CatalogObjectId(CatalogObjectId)
                .Name(Name)
                .BasePriceMoney(BasePriceMoney);
            return builder;
        }

        public class Builder
        {
            private string catalogObjectId;
            private string name;
            private Models.Money basePriceMoney;

            public Builder() { }
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

            public CreateOrderRequestModifier Build()
            {
                return new CreateOrderRequestModifier(catalogObjectId,
                    name,
                    basePriceMoney);
            }
        }
    }
} 