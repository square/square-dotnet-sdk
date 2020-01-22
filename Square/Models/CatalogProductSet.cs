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
    public class CatalogProductSet 
    {
        public CatalogProductSet(string name = null,
            IList<string> productIdsAny = null,
            IList<string> productIdsAll = null,
            long? quantityExact = null,
            long? quantityMin = null,
            long? quantityMax = null,
            bool? allProducts = null)
        {
            Name = name;
            ProductIdsAny = productIdsAny;
            ProductIdsAll = productIdsAll;
            QuantityExact = quantityExact;
            QuantityMin = quantityMin;
            QuantityMax = quantityMax;
            AllProducts = allProducts;
        }

        /// <summary>
        /// User-defined name for the product set. For example, "Clearance Items"
        /// or "Winter Sale Items".
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// Unique IDs for any `CatalogObject` included in this product set. Any
        /// number of these catalog objects can be in an order for a pricing rule to apply.
        /// This can be used with `product_ids_all` in a parent `CatalogProductSet` to
        /// match groups of products for a bulk discount, such as a discount for an
        /// entree and side combo.
        /// Only one of `product_ids_all`, `product_ids_any`, or `all_products` can be set.
        /// Max: 500 catalog object IDs.
        /// </summary>
        [JsonProperty("product_ids_any")]
        public IList<string> ProductIdsAny { get; }

        /// <summary>
        /// Unique IDs for any `CatalogObject` included in this product set.
        /// All objects in this set must be included in an order for a pricing rule to apply.
        /// Only one of `product_ids_all`, `product_ids_any`, or `all_products` can be set.
        /// Max: 500 catalog object IDs.
        /// </summary>
        [JsonProperty("product_ids_all")]
        public IList<string> ProductIdsAll { get; }

        /// <summary>
        /// If set, there must be exactly this many items from `products_any` or `products_all`
        /// in the cart for the discount to apply.
        /// Cannot be combined with either `quantity_min` or `quantity_max`.
        /// </summary>
        [JsonProperty("quantity_exact")]
        public long? QuantityExact { get; }

        /// <summary>
        /// If set, there must be at least this many items from `products_any` or `products_all`
        /// in a cart for the discount to apply. See `quantity_exact`. Defaults to 0 if
        /// `quantity_exact`, `quantity_min` and `quantity_max` are all unspecified.
        /// </summary>
        [JsonProperty("quantity_min")]
        public long? QuantityMin { get; }

        /// <summary>
        /// If set, the pricing rule will apply to a maximum of this many items from
        /// `products_any` or `products_all`.
        /// </summary>
        [JsonProperty("quantity_max")]
        public long? QuantityMax { get; }

        /// <summary>
        /// If set to `true`, the product set will include every item in the catalog.
        /// Only one of `product_ids_all`, `product_ids_any`, or `all_products` can be set.
        /// </summary>
        [JsonProperty("all_products")]
        public bool? AllProducts { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Name(Name)
                .ProductIdsAny(ProductIdsAny)
                .ProductIdsAll(ProductIdsAll)
                .QuantityExact(QuantityExact)
                .QuantityMin(QuantityMin)
                .QuantityMax(QuantityMax)
                .AllProducts(AllProducts);
            return builder;
        }

        public class Builder
        {
            private string name;
            private IList<string> productIdsAny = new List<string>();
            private IList<string> productIdsAll = new List<string>();
            private long? quantityExact;
            private long? quantityMin;
            private long? quantityMax;
            private bool? allProducts;

            public Builder() { }
            public Builder Name(string value)
            {
                name = value;
                return this;
            }

            public Builder ProductIdsAny(IList<string> value)
            {
                productIdsAny = value;
                return this;
            }

            public Builder ProductIdsAll(IList<string> value)
            {
                productIdsAll = value;
                return this;
            }

            public Builder QuantityExact(long? value)
            {
                quantityExact = value;
                return this;
            }

            public Builder QuantityMin(long? value)
            {
                quantityMin = value;
                return this;
            }

            public Builder QuantityMax(long? value)
            {
                quantityMax = value;
                return this;
            }

            public Builder AllProducts(bool? value)
            {
                allProducts = value;
                return this;
            }

            public CatalogProductSet Build()
            {
                return new CatalogProductSet(name,
                    productIdsAny,
                    productIdsAll,
                    quantityExact,
                    quantityMin,
                    quantityMax,
                    allProducts);
            }
        }
    }
}