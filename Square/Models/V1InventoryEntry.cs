using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square.Http.Client;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class V1InventoryEntry 
    {
        public V1InventoryEntry(string variationId = null,
            double? quantityOnHand = null)
        {
            VariationId = variationId;
            QuantityOnHand = quantityOnHand;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The variation that the entry corresponds to.
        /// </summary>
        [JsonProperty("variation_id")]
        public string VariationId { get; }

        /// <summary>
        /// The current available quantity of the item variation.
        /// </summary>
        [JsonProperty("quantity_on_hand")]
        public double? QuantityOnHand { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .VariationId(VariationId)
                .QuantityOnHand(QuantityOnHand);
            return builder;
        }

        public class Builder
        {
            private string variationId;
            private double? quantityOnHand;

            public Builder() { }
            public Builder VariationId(string value)
            {
                variationId = value;
                return this;
            }

            public Builder QuantityOnHand(double? value)
            {
                quantityOnHand = value;
                return this;
            }

            public V1InventoryEntry Build()
            {
                return new V1InventoryEntry(variationId,
                    quantityOnHand);
            }
        }
    }
}