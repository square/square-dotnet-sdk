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
    public class CatalogModifier 
    {
        public CatalogModifier(string name = null,
            Models.Money priceMoney = null)
        {
            Name = name;
            PriceMoney = priceMoney;
        }

        /// <summary>
        /// The modifier name. Searchable. This field has max length of 255 Unicode code points.
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
        [JsonProperty("price_money")]
        public Models.Money PriceMoney { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Name(Name)
                .PriceMoney(PriceMoney);
            return builder;
        }

        public class Builder
        {
            private string name;
            private Models.Money priceMoney;

            public Builder() { }
            public Builder Name(string value)
            {
                name = value;
                return this;
            }

            public Builder PriceMoney(Models.Money value)
            {
                priceMoney = value;
                return this;
            }

            public CatalogModifier Build()
            {
                return new CatalogModifier(name,
                    priceMoney);
            }
        }
    }
} 