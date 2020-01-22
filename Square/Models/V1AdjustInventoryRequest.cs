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
    public class V1AdjustInventoryRequest 
    {
        public V1AdjustInventoryRequest(double? quantityDelta = null,
            string adjustmentType = null,
            string memo = null)
        {
            QuantityDelta = quantityDelta;
            AdjustmentType = adjustmentType;
            Memo = memo;
        }

        /// <summary>
        /// The number to adjust the variation's quantity by.
        /// </summary>
        [JsonProperty("quantity_delta")]
        public double? QuantityDelta { get; }

        /// <summary>
        /// Getter for adjustment_type
        /// </summary>
        [JsonProperty("adjustment_type")]
        public string AdjustmentType { get; }

        /// <summary>
        /// A note about the inventory adjustment.
        /// </summary>
        [JsonProperty("memo")]
        public string Memo { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .QuantityDelta(QuantityDelta)
                .AdjustmentType(AdjustmentType)
                .Memo(Memo);
            return builder;
        }

        public class Builder
        {
            private double? quantityDelta;
            private string adjustmentType;
            private string memo;

            public Builder() { }
            public Builder QuantityDelta(double? value)
            {
                quantityDelta = value;
                return this;
            }

            public Builder AdjustmentType(string value)
            {
                adjustmentType = value;
                return this;
            }

            public Builder Memo(string value)
            {
                memo = value;
                return this;
            }

            public V1AdjustInventoryRequest Build()
            {
                return new V1AdjustInventoryRequest(quantityDelta,
                    adjustmentType,
                    memo);
            }
        }
    }
}