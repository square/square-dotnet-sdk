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
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
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
        [JsonProperty("product_ids_any", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> ProductIdsAny { get; }

        /// <summary>
        /// Unique IDs for any `CatalogObject` included in this product set.
        /// All objects in this set must be included in an order for a pricing rule to apply.
        /// Only one of `product_ids_all`, `product_ids_any`, or `all_products` can be set.
        /// Max: 500 catalog object IDs.
        /// </summary>
        [JsonProperty("product_ids_all", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> ProductIdsAll { get; }

        /// <summary>
        /// If set, there must be exactly this many items from `products_any` or `products_all`
        /// in the cart for the discount to apply.
        /// Cannot be combined with either `quantity_min` or `quantity_max`.
        /// </summary>
        [JsonProperty("quantity_exact", NullValueHandling = NullValueHandling.Ignore)]
        public long? QuantityExact { get; }

        /// <summary>
        /// If set, there must be at least this many items from `products_any` or `products_all`
        /// in a cart for the discount to apply. See `quantity_exact`. Defaults to 0 if
        /// `quantity_exact`, `quantity_min` and `quantity_max` are all unspecified.
        /// </summary>
        [JsonProperty("quantity_min", NullValueHandling = NullValueHandling.Ignore)]
        public long? QuantityMin { get; }

        /// <summary>
        /// If set, the pricing rule will apply to a maximum of this many items from
        /// `products_any` or `products_all`.
        /// </summary>
        [JsonProperty("quantity_max", NullValueHandling = NullValueHandling.Ignore)]
        public long? QuantityMax { get; }

        /// <summary>
        /// If set to `true`, the product set will include every item in the catalog.
        /// Only one of `product_ids_all`, `product_ids_any`, or `all_products` can be set.
        /// </summary>
        [JsonProperty("all_products", NullValueHandling = NullValueHandling.Ignore)]
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
            private IList<string> productIdsAny;
            private IList<string> productIdsAll;
            private long? quantityExact;
            private long? quantityMin;
            private long? quantityMax;
            private bool? allProducts;



            public Builder Name(string name)
            {
                this.name = name;
                return this;
            }

            public Builder ProductIdsAny(IList<string> productIdsAny)
            {
                this.productIdsAny = productIdsAny;
                return this;
            }

            public Builder ProductIdsAll(IList<string> productIdsAll)
            {
                this.productIdsAll = productIdsAll;
                return this;
            }

            public Builder QuantityExact(long? quantityExact)
            {
                this.quantityExact = quantityExact;
                return this;
            }

            public Builder QuantityMin(long? quantityMin)
            {
                this.quantityMin = quantityMin;
                return this;
            }

            public Builder QuantityMax(long? quantityMax)
            {
                this.quantityMax = quantityMax;
                return this;
            }

            public Builder AllProducts(bool? allProducts)
            {
                this.allProducts = allProducts;
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