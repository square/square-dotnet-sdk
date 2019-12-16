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
    public class CreateOrderRequestDiscount 
    {
        public CreateOrderRequestDiscount(string catalogObjectId = null,
            string name = null,
            string percentage = null,
            Models.Money amountMoney = null)
        {
            CatalogObjectId = catalogObjectId;
            Name = name;
            Percentage = percentage;
            AmountMoney = amountMoney;
        }

        /// <summary>
        /// Only used for catalog discounts.
        /// The catalog object ID for an existing [CatalogDiscount](#type-catalogdiscount).
        /// Do not provide a value for this field if you provide values in other fields for an ad hoc discount.
        /// </summary>
        [JsonProperty("catalog_object_id")]
        public string CatalogObjectId { get; }

        /// <summary>
        /// Only used for ad hoc discounts. The discount's name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// Only used for ad hoc discounts. The percentage of the discount, as a string representation of a decimal number.
        /// A value of `7.25` corresponds to a percentage of 7.25%. This value range between 0.0 up to 100.0
        /// </summary>
        [JsonProperty("percentage")]
        public string Percentage { get; }

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

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .CatalogObjectId(CatalogObjectId)
                .Name(Name)
                .Percentage(Percentage)
                .AmountMoney(AmountMoney);
            return builder;
        }

        public class Builder
        {
            private string catalogObjectId;
            private string name;
            private string percentage;
            private Models.Money amountMoney;

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

            public Builder Percentage(string value)
            {
                percentage = value;
                return this;
            }

            public Builder AmountMoney(Models.Money value)
            {
                amountMoney = value;
                return this;
            }

            public CreateOrderRequestDiscount Build()
            {
                return new CreateOrderRequestDiscount(catalogObjectId,
                    name,
                    percentage,
                    amountMoney);
            }
        }
    }
} 