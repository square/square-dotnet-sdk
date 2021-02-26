
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
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; }

        /// <summary>
        /// Represents the quantity of an item variation that is physically present
        /// at a specific location, verified by a seller or a seller's employee. For example,
        /// a physical count might come from an employee counting the item variations on
        /// hand or from syncing with an external system.
        /// </summary>
        [JsonProperty("physical_count", NullValueHandling = NullValueHandling.Ignore)]
        public Models.InventoryPhysicalCount PhysicalCount { get; }

        /// <summary>
        /// Represents a change in state or quantity of product inventory at a
        /// particular time and location.
        /// </summary>
        [JsonProperty("adjustment", NullValueHandling = NullValueHandling.Ignore)]
        public Models.InventoryAdjustment Adjustment { get; }

        /// <summary>
        /// Represents the transfer of a quantity of product inventory at a
        /// particular time from one location to another.
        /// </summary>
        [JsonProperty("transfer", NullValueHandling = NullValueHandling.Ignore)]
        public Models.InventoryTransfer Transfer { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"InventoryChange : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Type = {(Type == null ? "null" : Type.ToString())}");
            toStringOutput.Add($"PhysicalCount = {(PhysicalCount == null ? "null" : PhysicalCount.ToString())}");
            toStringOutput.Add($"Adjustment = {(Adjustment == null ? "null" : Adjustment.ToString())}");
            toStringOutput.Add($"Transfer = {(Transfer == null ? "null" : Transfer.ToString())}");
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            return obj is InventoryChange other &&
                ((Type == null && other.Type == null) || (Type?.Equals(other.Type) == true)) &&
                ((PhysicalCount == null && other.PhysicalCount == null) || (PhysicalCount?.Equals(other.PhysicalCount) == true)) &&
                ((Adjustment == null && other.Adjustment == null) || (Adjustment?.Equals(other.Adjustment) == true)) &&
                ((Transfer == null && other.Transfer == null) || (Transfer?.Equals(other.Transfer) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1849913550;

            if (Type != null)
            {
               hashCode += Type.GetHashCode();
            }

            if (PhysicalCount != null)
            {
               hashCode += PhysicalCount.GetHashCode();
            }

            if (Adjustment != null)
            {
               hashCode += Adjustment.GetHashCode();
            }

            if (Transfer != null)
            {
               hashCode += Transfer.GetHashCode();
            }

            return hashCode;
        }

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



            public Builder Type(string type)
            {
                this.type = type;
                return this;
            }

            public Builder PhysicalCount(Models.InventoryPhysicalCount physicalCount)
            {
                this.physicalCount = physicalCount;
                return this;
            }

            public Builder Adjustment(Models.InventoryAdjustment adjustment)
            {
                this.adjustment = adjustment;
                return this;
            }

            public Builder Transfer(Models.InventoryTransfer transfer)
            {
                this.transfer = transfer;
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