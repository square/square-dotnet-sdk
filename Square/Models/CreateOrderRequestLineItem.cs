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
    public class CreateOrderRequestLineItem 
    {
        public CreateOrderRequestLineItem(string quantity,
            string name = null,
            Models.Money basePriceMoney = null,
            string variationName = null,
            string note = null,
            string catalogObjectId = null,
            IList<Models.CreateOrderRequestModifier> modifiers = null,
            IList<Models.CreateOrderRequestTax> taxes = null,
            IList<Models.CreateOrderRequestDiscount> discounts = null)
        {
            Name = name;
            Quantity = quantity;
            BasePriceMoney = basePriceMoney;
            VariationName = variationName;
            Note = note;
            CatalogObjectId = catalogObjectId;
            Modifiers = modifiers;
            Taxes = taxes;
            Discounts = discounts;
        }

        /// <summary>
        /// Only used for ad hoc line items. The name of the line item. This value cannot exceed 500 characters.
        /// Do not provide a value for this field if you provide a value for `catalog_object_id`.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// The quantity to purchase, as a string representation of a number.
        /// This string must have a positive integer value.
        /// </summary>
        [JsonProperty("quantity")]
        public string Quantity { get; }

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
        /// Only used for ad hoc line items. The variation name of the line item. This value cannot exceed 255 characters.
        /// If this value is not set for an ad hoc line item, the default value of `Regular` is used.
        /// Do not provide a value for this field if you provide a value for the `catalog_object_id`.
        /// </summary>
        [JsonProperty("variation_name")]
        public string VariationName { get; }

        /// <summary>
        /// The note of the line item. This value cannot exceed 500 characters.
        /// </summary>
        [JsonProperty("note")]
        public string Note { get; }

        /// <summary>
        /// Only used for Catalog line items.
        /// The catalog object ID for an existing [CatalogItemVariation](#type-catalogitemvariation).
        /// Do not provide a value for this field if you provide a value for `name` and `base_price_money`.
        /// </summary>
        [JsonProperty("catalog_object_id")]
        public string CatalogObjectId { get; }

        /// <summary>
        /// Only used for Catalog line items. The modifiers to include on the line item.
        /// </summary>
        [JsonProperty("modifiers")]
        public IList<Models.CreateOrderRequestModifier> Modifiers { get; }

        /// <summary>
        /// The taxes to include on the line item.
        /// </summary>
        [JsonProperty("taxes")]
        public IList<Models.CreateOrderRequestTax> Taxes { get; }

        /// <summary>
        /// The discounts to include on the line item.
        /// </summary>
        [JsonProperty("discounts")]
        public IList<Models.CreateOrderRequestDiscount> Discounts { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(Quantity)
                .Name(Name)
                .BasePriceMoney(BasePriceMoney)
                .VariationName(VariationName)
                .Note(Note)
                .CatalogObjectId(CatalogObjectId)
                .Modifiers(Modifiers)
                .Taxes(Taxes)
                .Discounts(Discounts);
            return builder;
        }

        public class Builder
        {
            private string quantity;
            private string name;
            private Models.Money basePriceMoney;
            private string variationName;
            private string note;
            private string catalogObjectId;
            private IList<Models.CreateOrderRequestModifier> modifiers = new List<Models.CreateOrderRequestModifier>();
            private IList<Models.CreateOrderRequestTax> taxes = new List<Models.CreateOrderRequestTax>();
            private IList<Models.CreateOrderRequestDiscount> discounts = new List<Models.CreateOrderRequestDiscount>();

            public Builder(string quantity)
            {
                this.quantity = quantity;
            }
            public Builder Quantity(string value)
            {
                quantity = value;
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

            public Builder VariationName(string value)
            {
                variationName = value;
                return this;
            }

            public Builder Note(string value)
            {
                note = value;
                return this;
            }

            public Builder CatalogObjectId(string value)
            {
                catalogObjectId = value;
                return this;
            }

            public Builder Modifiers(IList<Models.CreateOrderRequestModifier> value)
            {
                modifiers = value;
                return this;
            }

            public Builder Taxes(IList<Models.CreateOrderRequestTax> value)
            {
                taxes = value;
                return this;
            }

            public Builder Discounts(IList<Models.CreateOrderRequestDiscount> value)
            {
                discounts = value;
                return this;
            }

            public CreateOrderRequestLineItem Build()
            {
                return new CreateOrderRequestLineItem(quantity,
                    name,
                    basePriceMoney,
                    variationName,
                    note,
                    catalogObjectId,
                    modifiers,
                    taxes,
                    discounts);
            }
        }
    }
}