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
    public class InventoryChange 
    {
        public InventoryChange(string type = null,
            Models.InventoryPhysicalCount physicalCount = null,
            Models.InventoryAdjustment adjustment = null,
            Models.InventoryTransfer transfer = null)
        {
            Type = type;
            PhysicalCount = physicalCount;
            Adjustment = adjustment;
            Transfer = transfer;
        }

        /// <summary>
        /// Indicates how the inventory change was applied to a tracked quantity of items.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; }

        /// <summary>
        /// Represents the quantity of an item variation that is physically present
        /// at a specific location, verified by a seller or a seller's employee. For example,
        /// a physical count might come from an employee counting the item variations on
        /// hand or from syncing with an external system.
        /// </summary>
        [JsonProperty("physical_count")]
        public Models.InventoryPhysicalCount PhysicalCount { get; }

        /// <summary>
        /// Represents a change in state or quantity of product inventory at a
        /// particular time and location.
        /// </summary>
        [JsonProperty("adjustment")]
        public Models.InventoryAdjustment Adjustment { get; }

        /// <summary>
        /// Represents the transfer of a quantity of product inventory at a
        /// particular time from one location to another.
        /// </summary>
        [JsonProperty("transfer")]
        public Models.InventoryTransfer Transfer { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Type(Type)
                .PhysicalCount(PhysicalCount)
                .Adjustment(Adjustment)
                .Transfer(Transfer);
            return builder;
        }

        public class Builder
        {
            private string type;
            private Models.InventoryPhysicalCount physicalCount;
            private Models.InventoryAdjustment adjustment;
            private Models.InventoryTransfer transfer;

            public Builder() { }
            public Builder Type(string value)
            {
                type = value;
                return this;
            }

            public Builder PhysicalCount(Models.InventoryPhysicalCount value)
            {
                physicalCount = value;
                return this;
            }

            public Builder Adjustment(Models.InventoryAdjustment value)
            {
                adjustment = value;
                return this;
            }

            public Builder Transfer(Models.InventoryTransfer value)
            {
                transfer = value;
                return this;
            }

            public InventoryChange Build()
            {
                return new InventoryChange(type,
                    physicalCount,
                    adjustment,
                    transfer);
            }
        }
    }
}